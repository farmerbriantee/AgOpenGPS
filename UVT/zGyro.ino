
void GyroHandler(uint32_t delta)
{
	//Get the Z gyro
	Wire.beginTransmission(CMPS14_ADDRESS);
	Wire.write(0x16);
	Wire.endTransmission();

	Wire.requestFrom(CMPS14_ADDRESS, 2);
	while (Wire.available() < 2);

	gyro = int16_t(Wire.read() << 8 | Wire.read());

	//Complementary filter
	gyroSum = 0.92 * gyroSum + 0.08 * gyro;

	//save time to check for 10 msec
	lastGyroTime = millis();
}