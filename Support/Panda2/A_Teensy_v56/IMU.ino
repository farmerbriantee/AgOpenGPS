#define RAD_TO_DEG_X_10 572.95779513082320876798154814105

void imuReader()
{
    int16_t temp = 0;

    if (useCMPS)
    {
        //roll
        Wire.beginTransmission(CMPS14_ADDRESS);
        Wire.write(0x1C);
        Wire.endTransmission();

        Wire.requestFrom(CMPS14_ADDRESS, 2);
        while (Wire.available() < 2);

        roll = int16_t(Wire.read() << 8 | Wire.read());

        temp = (int16_t)roll;
        itoa(temp, imuRoll, 10);

        // Yaw
        Wire.beginTransmission(CMPS14_ADDRESS);
        Wire.write(0x02);
        Wire.endTransmission();

        Wire.requestFrom(CMPS14_ADDRESS, 3);
        while (Wire.available() < 3);

        temp = Wire.read() << 8 | Wire.read();
        itoa(temp, imuHeading, 10);

        // Pitch
        int8_t pitch = Wire.read();
        itoa(pitch, imuPitch, 10);

        //Z gyro
        Wire.beginTransmission(CMPS14_ADDRESS);
        Wire.write(0x16);
        Wire.endTransmission();

        temp = Wire.read() << 8 | Wire.read();
        while (Wire.available() < 2);

        itoa(temp, imuYawRate, 10);
    }

    if (useBNO)
    {
        BNO.GetQuaternion();

        //BNO.printPacket();

        //float norm = sqrt(dqw * dqw + dqx * dqx + dqy * dqy + dqz * dqz);
        //dqw = dqw / norm;
        //dqx = dqx / norm;
        //dqy = dqy / norm;
        //dqz = dqz / norm;

        float ysqr = BNO.dqy * BNO.dqy;

        // yaw (z-axis rotation)
        float t3 = +2.0 * (BNO.dqw * BNO.dqz + BNO.dqx * BNO.dqy);
        float t4 = +1.0 - 2.0 * (ysqr + BNO.dqz * BNO.dqz);
        yaw = atan2(t3, t4);

        // Convert yaw to degrees x10
        yaw = (int16_t)((yaw * -RAD_TO_DEG_X_10));
        if (yaw < 0) yaw += 3600;

        // pitch (y-axis rotation)
        float t2 = +2.0 * (BNO.dqw * BNO.dqy - BNO.dqz * BNO.dqx);
        t2 = t2 > 1.0 ? 1.0 : t2;
        t2 = t2 < -1.0 ? -1.0 : t2;
        pitch = asin(t2) * RAD_TO_DEG_X_10;

        // roll (x-axis rotation)
        float t0 = +2.0 * (BNO.dqw * BNO.dqx + BNO.dqy * BNO.dqz);
        float t1 = +1.0 - 2.0 * (BNO.dqx * BNO.dqx + ysqr);
        roll = atan2(t0, t1) * RAD_TO_DEG_X_10;

        //Serial.print(yaw);
        //Serial.print("\t");

        //Serial.print(pitch);
        //Serial.print("\t");

        //Serial.println(roll);

        //Serial.print(BNO.dqx, 4);
        //Serial.print(F(","));
        //Serial.print(BNO.dqy, 4);
        //Serial.print(F(","));
        //Serial.print(BNO.dqz, 4);
        //Serial.print(F(","));
        //Serial.println(BNO.dqw, 4);

        //uint32_t tim = micros();

        //tim = micros() - tim;
        //Serial.println(tim);

        // Fill rest of Panda Sentence - Yaw
        temp = yaw;
        itoa(temp, imuHeading, 10);

        // the pitch x10
        temp = (int16_t)pitch;
        itoa(temp, imuPitch, 10);

        // the roll x10
        temp = (int16_t)roll;
        itoa(temp, imuRoll, 10);

        // YawRate - 0 for now
        itoa(0, imuYawRate, 10);
    }

    // No else, because we want to use dual heading
    // and IMU roll when both connected
    if (useDual)
    {
        // Heading
        dtostrf(heading, 3, 1, imuHeading);

        // the pitch x10
        temp = 0;
        itoa(pitch, imuPitch, 10);

        // Use pitch and roll and YawRate from IMU when attached
        if (useCMPS || useBNO)
        {
            // the pitch
            temp = (int16_t)pitch * 0.1;
            itoa(pitch, imuPitch, 10);

            // the roll
            temp = (int16_t)roll * 0.1;
            itoa(temp, imuRoll, 10);

            // YawRate
            itoa(0, imuYawRate, 10);
        }
        else
        {
            // the roll x10
            dtostrf(rollDual, 3, 1, imuRoll);

            // YawRate
            temp = 0;
            itoa(temp, imuYawRate, 10);
        }
    }
}

