/******************************************************************************
SparkFun_MMA8452Q.cpp
SparkFun_MMA8452Q Library Source File
Jim Lindblom @ SparkFun Electronics
Original Creation Date: June 3, 2014
https://github.com/sparkfun/MMA8452_Accelerometer

This file implements all functions of the MMA8452Q class. Functions here range
from higher level stuff, like reading/writing MMA8452Q registers to low-level,
hardware I2C reads and writes.

Development environment specifics:
	IDE: Arduino 1.0.5
	Hardware Platform: Arduino Uno

	**Updated for Arduino 1.6.4 5/2015**

This code is beerware; if you see me (or any other SparkFun employee) at the
local, and you've found our code helpful, please buy us a round!

Distributed as-is; no warranty is given.
******************************************************************************/

#include "MMA8452Q.h"
#include <Arduino.h>
#include <Wire.h>

// CONSTRUCTUR
//   This function, called when you initialize the class will simply write the
//   supplied address into a private variable for future use.
//   The variable addr should be either 0x1C or 0x1D, depending on which voltage
//   the SA0 pin is tied to (GND or 3.3V respectively).
MMA8452Q::MMA8452Q(byte addr)
{
	address = addr; // Store address into private variable
}

// INITIALIZATION
//	This function initializes the MMA8452Q. It sets up the scale (either 2, 4,
//	or 8g), output data rate, portrait/landscape detection and tap detection.
//	It also checks the WHO_AM_I register to make sure we can communicate with
//	the sensor. Returns a 0 if communication failed, 1 if successful.
byte MMA8452Q::init(MMA8452Q_Scale fsr, MMA8452Q_ODR odr)
{
	scale = fsr; // Haul fsr into our class variable, scale

	Wire.begin(); // Initialize I2C

	byte c = readRegister(WHO_AM_I);  // Read WHO_AM_I register

	if (c != 0x2A) // WHO_AM_I should always be 0x2A
	{
		return 0;
	}

	standby();  // Must be in standby to change registers

	setScale(scale);  // Set up accelerometer scale
	setODR(odr);  // Set up output data rate
	//setupPL();  // Set up portrait/landscape detection
	// Multiply parameter by 0.0625g to calculate threshold.
	//setupTap(0x80, 0x80, 0x08); // Disable x, y, set z to 0.5g

	active();  // Set to active to start reading

	return 1;
}

byte MMA8452Q::readID()
{
  return readRegister(WHO_AM_I);
}


// READ ACCELERATION DATA
//  This function will read the acceleration values from the MMA8452Q. After
//	reading, it will update two triplets of variables:
//		* int's x, y, and z will store the signed 12-bit values read out
//		  of the acceleromter.
//		* floats cx, cy, and cz will store the calculated acceleration from
//		  those 12-bit values. These variables are in units of g's.
void MMA8452Q::read()
{
	byte rawData[6];  // x/y/z accel register data stored here

	readRegisters(OUT_X_MSB, rawData, 4);  // Read the six raw data registers into data array

	x = ((short)(rawData[0]<<8 | rawData[1])) >> 4;
	y = ((short)(rawData[2]<<8 | rawData[3])) >> 4;
	//z = ((short)(rawData[4]<<8 | rawData[5])) >> 4;
	cx = (float) x / (float)(1<<11) * (float)(scale);
	cy = (float) y / (float)(1<<11) * (float)(scale);
	//cz = (float) z / (float)(1<<11) * (float)(scale);
}

// CHECK IF NEW DATA IS AVAILABLE
//	This function checks the status of the MMA8452Q to see if new data is availble.
//	returns 0 if no new data is present, or a 1 if new data is available.
byte MMA8452Q::available()
{
	return (readRegister(STATUS_MMA8452Q) & 0x08) >> 1;
}

// SET FULL-SCALE RANGE
//	This function sets the full-scale range of the x, y, and z axis accelerometers.
//	Possible values for the fsr variable are SCALE_2G, SCALE_4G, or SCALE_8G.
void MMA8452Q::setScale(MMA8452Q_Scale fsr)
{
	// Must be in standby mode to make changes!!!
	byte cfg = readRegister(XYZ_DATA_CFG);
	cfg &= 0xFC; // Mask out scale bits
	cfg |= (fsr >> 2);  // Neat trick, see page 22. 00 = 2G, 01 = 4A, 10 = 8G
	writeRegister(XYZ_DATA_CFG, cfg);
}

// SET THE OUTPUT DATA RATE
//	This function sets the output data rate of the MMA8452Q.
//	Possible values for the odr parameter are: ODR_800, ODR_400, ODR_200,
//	ODR_100, ODR_50, ODR_12, ODR_6, or ODR_1
void MMA8452Q::setODR(MMA8452Q_ODR odr)
{
	// Must be in standby mode to make changes!!!
	byte ctrl = readRegister(CTRL_REG1);
	ctrl &= 0xC7; // Mask out data rate bits
	ctrl |= (odr << 3);
	writeRegister(CTRL_REG1, ctrl);
}

// SET STANDBY MODE
//	Sets the MMA8452 to standby mode. It must be in standby to change most register settings
void MMA8452Q::standby()
{
	byte c = readRegister(CTRL_REG1);
	writeRegister(CTRL_REG1, c & ~(0x01)); //Clear the active bit to go into standby
}

// SET ACTIVE MODE
//	Sets the MMA8452 to active mode. Needs to be in this mode to output data
void MMA8452Q::active()
{
	byte c = readRegister(CTRL_REG1);
	writeRegister(CTRL_REG1, c | 0x01); //Set the active bit to begin detection
}

// WRITE A SINGLE REGISTER
// 	Write a single byte of data to a register in the MMA8452Q.
void MMA8452Q::writeRegister(MMA8452Q_Register reg, byte data)
{
	writeRegisters(reg, &data, 1);
}

// WRITE MULTIPLE REGISTERS
//	Write an array of "len" bytes ("buffer"), starting at register "reg", and
//	auto-incrmenting to the next.
void MMA8452Q::writeRegisters(MMA8452Q_Register reg, byte *buffer, byte len)
{
	Wire.beginTransmission(address);
	Wire.write(reg);
	for (int x = 0; x < len; x++)
		Wire.write(buffer[x]);
	Wire.endTransmission(); //Stop transmitting
}

// READ A SINGLE REGISTER
//	Read a byte from the MMA8452Q register "reg".
byte MMA8452Q::readRegister(MMA8452Q_Register reg)
{
	Wire.beginTransmission(address);
	Wire.write(reg);
	Wire.endTransmission(false); //endTransmission but keep the connection active

	Wire.requestFrom(address, (byte) 1); //Ask for 1 byte, once done, bus is released by default

	if(Wire.available()){ //Wait for the data to come back
		return Wire.read(); //Return this one byte
	}
	else{
		return 0;
	}
}

// READ MULTIPLE REGISTERS
//	Read "len" bytes from the MMA8452Q, starting at register "reg". Bytes are stored
//	in "buffer" on exit.
void MMA8452Q::readRegisters(MMA8452Q_Register reg, byte *buffer, byte len)
{
	Wire.beginTransmission(address);
	Wire.write(reg);
	Wire.endTransmission(false); //endTransmission but keep the connection active

	Wire.requestFrom(address, len); //Ask for bytes, once done, bus is released by default
	if(Wire.available() == len){
		for(int x = 0 ; x < len ; x++)
			buffer[x] = Wire.read();
	}
}
