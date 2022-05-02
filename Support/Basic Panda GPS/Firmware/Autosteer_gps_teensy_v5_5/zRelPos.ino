
void relPosDecode() {

    int carrSoln;
    bool gnssFixOk, diffSoln, relPosValid;
    //bool refPosHeadingValid, relPosNormalized, isMoving, refPosMiss, refObsMiss;

    heading = (uint32_t)ackPacket[30] + ((uint32_t)ackPacket[31] << 8) 
        + ((uint32_t)ackPacket[32] << 16) + ((uint32_t)ackPacket[33] << 24);
    heading *= 0.0001;

    heading += headingcorr;
    if (heading >= 3600) heading -= 3600;
    if (heading < 0) heading += 3600;
    heading *= 0.1;

    baseline = (uint32_t)ackPacket[26] + ((uint32_t)ackPacket[27] << 8)
        + ((uint32_t)ackPacket[28] << 16) + ((uint32_t)ackPacket[29] << 24);
    baseline *= 0.01;
    baseline += ((double)ackPacket[41] * 0.0001);

    relPosD = (uint32_t)ackPacket[22] + ((uint32_t)ackPacket[23] << 8)
        + ((uint32_t)ackPacket[24] << 16) + ((uint32_t)ackPacket[25] << 24);
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

    double p = sqrt((baseline * baseline) - (relPosD * relPosD));

    if (carrSoln == 2)
    {
        rollDual = (atan(relPosD / p)) * -RAD_TO_DEG;
    }
    else
    {
        rollDual *= 0.9;
    }

    imuHandler();

    if (carrSoln == 2)
    {
        dualReadyRelPos = true;
        //Serial.println("Dual Ready1");
    }
}
