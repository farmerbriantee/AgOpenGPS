#include "MMA8452_AOG.h"

#define BIT_0 0x01
#define BIT_1 0x02
#define BIT_2 0x04
#define BIT_3 0x08
#define BIT_4 0x10
#define BIT_5 0x20
#define BIT_6 0x40
#define BIT_7 0x80

bool MMA8452::init()
{
	// Check who-am-i register
	uint8_t reg = 0;
	if (!readMultiple(WHO_AM_I, &reg, 1)) return false; // catch read fail!!
	if (reg != 0x2A && reg != 0x1A )
	 {
	  // 8452 will always return 0x2A, 8451 returns 0x1A, otherwise connections probably wrong
	  Serial.print("MMA not responding, should be 0x2A or 0x1A, is:");
          Serial.println(reg,HEX);	
	  return false;
	 }
  if (reg==0x2A) Serial.println("MMA 8452 found!");
	if (reg==0x1A) Serial.println("MMA 8451 found!");
	// range on startup is always 2g, we'll need to know the range for G calculation
	range = MMA_RANGE_2G;
	active = true; // active by default
	return true;
}

void MMA8452::getRawData(uint16_t *x, uint16_t *y, uint16_t *z)
{
	// the x, y, z registers are consecutive so read them in one go
	// data: x [msb, lsb]   y [msb, lsb]   z [msb, lsb]
	uint8_t data[6];
	readMultiple(OUT_X_MSB, data, 6);
	*x = (data[0] << 8) | data[1];
	*y = (data[2] << 8) | data[3];
	*z = (data[4] << 8) | data[5];
}

void MMA8452::getAcceleration(float *x, float *y, float *z)
{
	uint16_t rawX;
	uint16_t rawY;
	uint16_t rawZ;
	getRawData(&rawX, &rawY, &rawZ);
	*x = convertGCounts(rawX);
	*y = convertGCounts(rawY);
	*z = convertGCounts(rawZ);
}

mma8452_mode_t MMA8452::getMode()
{
	uint8_t sysmode = read(SYSMOD);
	return (mma8452_mode_t)(sysmode & 0x3);
}

void MMA8452::setRange(mma8452_range_t newRange)
{
	uint8_t reg = read(XYZ_DATA_CFG);
	reg &= ~0x3;
	reg |= newRange;
	write(XYZ_DATA_CFG, reg);
	range = newRange;
}

mma8452_range_t MMA8452::getRange()
{
	uint8_t reg = read(XYZ_DATA_CFG);
	return (mma8452_range_t)(reg & 0x3);
}

void MMA8452::setHighPassFilter(bool enabled, mma8452_highpass_mode_t mode)
{
	uint8_t reg = read(XYZ_DATA_CFG);
	reg &= ~BIT_4;
	if (enabled) reg |= BIT_4;
	write(XYZ_DATA_CFG, reg);

	reg = read(HP_FILTER_CUTOFF);
	reg &= ~(0x03);
	reg |= mode;
	write(HP_FILTER_CUTOFF, reg);
}

void MMA8452::setDataRate(mma_datarate_t dataRate)
{
	uint8_t ctrl_reg1 = read(CTRL_REG1);
	ctrl_reg1 &= ~(0x7 << 3);
	ctrl_reg1 |= (dataRate << 3);
	write(CTRL_REG1, ctrl_reg1);
}

void MMA8452::setLowNoiseMode(bool enabled)
{
	uint8_t ctrl_reg1 = read(CTRL_REG1);
	ctrl_reg1 &= ~BIT_2;
	if (enabled) ctrl_reg1 |= BIT_2;
	write(CTRL_REG1, ctrl_reg1);
}

void MMA8452::set8BitMode(bool enabled)
{
	uint8_t ctrl_reg1 = read(CTRL_REG1);
	ctrl_reg1 &= ~BIT_1;
	if (enabled) ctrl_reg1 |= BIT_1;
	write(CTRL_REG1, ctrl_reg1);
}

void MMA8452::reset()
{
	uint8_t reg2 = read(CTRL_REG2);
	reg2 |= BIT_6;
	write(CTRL_REG2, reg2);
}

void MMA8452::setPowerMode(mma_power_mode_t powerMode)
{
	uint8_t ctrl_reg2 = read(CTRL_REG2);
	ctrl_reg2 &= ~0x3;
	ctrl_reg2 |= powerMode;
	write(CTRL_REG2, ctrl_reg2);
}

void MMA8452::setOffsets(int8_t x, int8_t y, int8_t z)
{
	x = convertTo2sComplement(x);
	y = convertTo2sComplement(y);
	z = convertTo2sComplement(z);
	write(OFF_X, x);
	write(OFF_Y, y);
	write(OFF_Z, z);
}

void MMA8452::setActive(bool newActive)
{
	active = newActive;
	standby(!active);
}

/**************************************************************************/
// Instantiates a new MMA class 
/**************************************************************************/
MMA8452::MMA8452(uint8_t i2cAddress) 
{
   MMA8452_ADDRESS = i2cAddress;
}

// -- private --

void MMA8452::standby(bool standby)
{
	uint8_t reg_ctrl1 = read(CTRL_REG1);
	reg_ctrl1 &= ~BIT_0;
	reg_ctrl1 |= !standby;
#ifdef ARDUINO
	Wire.beginTransmission(MMA8452_ADDRESS);
	Wire.write(CTRL_REG1);
	Wire.write(reg_ctrl1);
	Wire.endTransmission();
#else
	i2c_start_wait((MMA8452_ADDRESS << 1));
	i2c_write(CTRL_REG1);
	i2c_write(reg_ctrl1);
	i2c_stop();
#endif
}

uint8_t MMA8452::read(uint8_t reg)
{
	uint8_t buf = 0;
	readMultiple(reg, &buf, 1);
	return buf;
}

void MMA8452::write(uint8_t reg, uint8_t value)
{
	// need to go to standby mode to modify registers
	// except CTRL_REG1[STANDBY] and CTRL_REG2[RST]
	// no need to go to standby if we're not active anyway
	bool needsStandby = (!(
							(reg == CTRL_REG1 && (value & 0x1)) || 
						  	(reg == CTRL_REG2 && ((value >> 6) & 0x1))
						) && active);
	needsStandby = true;
	if (needsStandby) standby(true);
#ifdef ARDUINO
	Wire.beginTransmission(MMA8452_ADDRESS);
	Wire.write(reg);
	Wire.write(value);
	Wire.endTransmission();
#else
	i2c_start_wait((MMA8452_ADDRESS << 1));
	i2c_write(reg);
	i2c_write(value);
	i2c_stop();
#endif
	if (needsStandby) standby(false);
}

bool MMA8452::readMultiple(uint8_t reg, uint8_t *buffer, uint8_t numBytes)
{

#ifdef ARDUINO
	Wire.beginTransmission(MMA8452_ADDRESS);
	Wire.write(reg);
	Wire.endTransmission(false);
	Wire.requestFrom((uint8_t)MMA8452_ADDRESS, numBytes);
	long timeout=millis();
	while (Wire.available() < numBytes) {
	   if ((millis() - timeout)> 2000) return false;
	  }
	while (numBytes--)
	{
		*buffer++ = Wire.read();
	}
#else
	i2c_start_wait((MMA8452_ADDRESS << 1));
	i2c_write(reg);
	i2c_rep_start((MMA8452_ADDRESS << 1) + 1);
	while (numBytes-- > 1)
	{
		*buffer++ = i2c_readAck();
	}
	*buffer++ = i2c_readNak();
	i2c_stop();
#endif
return true;
}

float MMA8452::convertGCounts(uint16_t data)
{
	int16_t gCount = (data >> 4); // data is 12bit

	// first bit is sign
	if (gCount > 0x7FF)
	{
		gCount = (0xFFF & ~gCount) + 1;	// data is 2’s complement, flip and add one
		gCount *= -1;					// we're negative so add sign
	}

	float countsPerG[3] = {
		1024.0f, 512.0f, 256.0f
	};
	float divider = countsPerG[range];

	// todo: would be nice to do this without floating point math
	float output = gCount;
	output /= divider;

	return output;
}

int8_t MMA8452::convertTo2sComplement(int8_t value)
{
	if (value >= 0) return value;
	value = (0xFF && ~value) + 1;
	return value;
}
