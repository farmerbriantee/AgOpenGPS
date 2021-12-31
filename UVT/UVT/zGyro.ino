
void GyroHandler(uint32_t delta)
{
	//Get the Z gyro
	Wire.beginTransmission(CMPS14_ADDRESS);
	Wire.write(0x16);
	Wire.endTransmission();

	Wire.requestFrom(CMPS14_ADDRESS, 2);
	while (Wire.available() < 2);

	float gyro = int16_t(Wire.read() << 8 | Wire.read());

	//Complementary filter
	gyroSum = 0.8 * gyroSum + 0.2 * gyro;

	//Kalman filter
	Pc = P + varProcess;
	G = Pc / (Pc + varRoll);
	P = (1 - G) * Pc;
	Xp = kalGyro;
	Zp = Xp;
	kalGyro = (G * (gyroSum - Zp) + Xp);

	//save time to check for 10 msec
	lastGyroTime = millis();
}