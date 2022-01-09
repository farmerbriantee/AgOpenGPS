

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
	gyroSum = 0.94 * gyroSum + 0.06 * gyro;

	//roll
	Wire.beginTransmission(CMPS14_ADDRESS);
	Wire.write(0x1C);
	Wire.endTransmission();

	Wire.requestFrom(CMPS14_ADDRESS, 2);
	while (Wire.available() < 2);

	roll = int16_t(Wire.read() << 8 | Wire.read());
	
	//Complementary filter
	rollSum = 0.9 * rollSum + 0.1 * roll;

	//save time to check for 10 msec
	lastGyroTime = millis();
}