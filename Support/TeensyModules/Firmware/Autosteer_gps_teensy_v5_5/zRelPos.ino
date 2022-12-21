
void relPosDecode() {

    int carrSoln;
    bool gnssFixOk, diffSoln, relPosValid;
    //bool refPosHeadingValid, relPosNormalized, isMoving, refPosMiss, refObsMiss;

    heading = (int32_t)ackPacket[30] + ((int32_t)ackPacket[31] << 8) 
        + ((int32_t)ackPacket[32] << 16) + ((int32_t)ackPacket[33] << 24);
    heading *= 0.0001;

    heading += headingcorr;
    if (heading >= 3600) heading -= 3600;
    if (heading < 0) heading += 3600;
    heading *= 0.1;

    baseline = (int32_t)ackPacket[26] + ((int32_t)ackPacket[27] << 8)
        + ((int32_t)ackPacket[28] << 16) + ((int32_t)ackPacket[29] << 24);
    baseline *= 0.01;
    baseline += ((double)ackPacket[41] * 0.0001);

    relPosD = (int32_t)ackPacket[22] + ((int32_t)ackPacket[23] << 8)
        + ((int32_t)ackPacket[24] << 16) + ((int32_t)ackPacket[25] << 24);
    relPosD *= 0.01;
    relPosD += ((double)ackPacket[40] * 0.00001);
    
    uint32_t flags = ackPacket[66];

    //  Serial.println(flags, BIN);

    gnssFixOk = flags & 1;
    diffSoln = flags & 2;
    relPosValid = flags & 4;
    carrSoln = (flags & 24) >> 3;
    //isMoving = flags & (32);
    //refPosMiss = flags & (64);
    //refObsMiss = flags & (128);
    //refPosHeadingValid = flags & (256);
    //relPosNormalized = flags & (512);

    //must be all ok
    if (!gnssFixOk || !diffSoln || !relPosValid) return;

//Base Line Check **********************************************************    

    bool baseLineCheck;
    static double autoBaseLine = 150;
    if (carrSoln == 2)
    {
      autoBaseLine = (autoBaseLine * 0.99) + baseline;
    }
        
    if((baseline*100) > (autoBaseLine - baseLineLimit) && (baseline*100) < (autoBaseLine + baseLineLimit))
    {
      baseLineCheck = true;
    }
    else
    {
      baseLineCheck = false;
    }
//**************************************************************************
    double p = sqrt((baseline * baseline) - (relPosD * relPosD));

    if (carrSoln == 2 && baseLineCheck)
    {
        rollDual = (atan(relPosD / p)) * -RAD_TO_DEG;
        digitalWrite(GPSGREEN_LED, HIGH);   //Turn green GPS LED ON
    }
    else
    {
        rollDual *= 0.9;
        digitalWrite(GPSGREEN_LED, blink);  //Flash the green GPS LED
    }

    if (carrSoln == 2)
    {
      if (useBNO08x || useCMPS)
      {
        if (baseLineCheck)
        {
          imuDualDelta();         //Find the error between latest IMU reading and this dual message
        }
        dualReadyRelPos = false;  //RelPos ready is false because we just saved the error for running from the IMU
      }
      else
      {
        imuHandler();             //No IMU so use dual data direct
        dualReadyRelPos = true;   //RelPos ready is true so PAOGI will send when the GGA is also ready
      }
    }  
}

void imuDualDelta()
{
                                        //correctionHeading is IMU heading in radians
    gpsHeading = heading * DEG_TO_RAD;  //gpsHeading is Dual heading in radians

    //Difference between the IMU heading and the GPS heading
    gyroDelta = (correctionHeading + imuGPS_Offset) - gpsHeading;
    if (gyroDelta < 0) gyroDelta += twoPI;

    //calculate delta based on circular data problem 0 to 360 to 0, clamp to +- 2 Pi
    if (gyroDelta >= -PIBy2 && gyroDelta <= PIBy2) gyroDelta *= -1.0;
    else
    {
        if (gyroDelta > PIBy2) { gyroDelta = twoPI - gyroDelta; }
        else { gyroDelta = (twoPI + gyroDelta) * -1.0; }
    }
    if (gyroDelta > twoPI) gyroDelta -= twoPI;
    if (gyroDelta < -twoPI) gyroDelta += twoPI;

    //if the gyro and last corrected fix is < 10 degrees, super low pass for gps
    if (abs(gyroDelta) < 0.18)
    {
        //a bit of delta and add to correction to current gyro
        imuGPS_Offset += (gyroDelta * (0.1));
        if (imuGPS_Offset > twoPI) imuGPS_Offset -= twoPI;
        if (imuGPS_Offset < -twoPI) imuGPS_Offset += twoPI;
    }
    else
    {
        //a bit of delta and add to correction to current gyro
        imuGPS_Offset += (gyroDelta * (0.2));
        if (imuGPS_Offset > twoPI) imuGPS_Offset -= twoPI;
        if (imuGPS_Offset < -twoPI) imuGPS_Offset += twoPI;
    }

    //So here how we have the difference between the IMU heading and the Dual GPS heading
    //This "imuGPS_Offset" will be used in imuHandler() when the GGA arrives 

    //Calculate the diffrence between dual and imu roll
    float imuRoll;
    imuRoll = (int16_t)roll * 0.1;
    rollDelta = rollDual - imuRoll;
    rollDeltaSmooth = (rollDeltaSmooth * 0.7) + (rollDelta * 0.3);
}

void fuseIMU()
{     
    //determine the Corrected heading based on gyro and GPS
    imuCorrected = correctionHeading + imuGPS_Offset;
    if (imuCorrected > twoPI) imuCorrected -= twoPI;
    if (imuCorrected < 0) imuCorrected += twoPI;

    imuCorrected = imuCorrected * RAD_TO_DEG; 
}
