#pragma once

#if (ARDUINO >= 100)
#include "Arduino.h"
#else
#include "WProgram.h"
#endif

#include <Wire.h>

//The default I2C address SparkX breakout is 0x4B, AdaFruit 0x4A. 
#define BNO080_DEFAULT_ADDRESS 0x4A
#define MAX_PACKET_SIZE 128 //Packets can be up to 32k but we don't have that much RAM.

class BNO080
{
public:
	boolean begin(uint8_t deviceAddress = BNO080_DEFAULT_ADDRESS, TwoWire& wirePort = Wire); //By default use the default I2C addres, and use Wire port, and don't declare an INT pin

	bool GetQuaternion();
	void SensorRate();

	boolean waitForI2C(); //Delay based polling for I2C traffic
	void printPacket(void); //Prints the current shtp header and data packets
	void enableDebugging(Stream& debugPort = Serial); //Turn on debug printing. If user doesn't specify then Serial will be used.

public:
	uint8_t shtpData[MAX_PACKET_SIZE];
	uint8_t shtpHeader[4];

	double dqw, dqx, dqy, dqz;
	uint8_t sensorStatus;                                    // Status (0-3)
	uint8_t sensorDelay;
	const uint8_t gameReport_ID = 0x08;          // defines kind of rotation vector (0x05), geomagnetic (0x09), AR/VR (0x28)

	//Q Point conversion from fixed to double
	const double QP14 = (double)1.0 / (double)16384;
				
	//in microseconds
	uint32_t sensorRate = 80000;
	uint8_t B0_rate = sensorRate & 0xFF;                       //calculates LSB (byte 0)
	uint8_t B1_rate = (sensorRate >> 8) & 0xFF;
	uint8_t B2_rate = (sensorRate >> 16) & 0xFF;
	uint8_t B3_rate = sensorRate >> 24; 	
	uint8_t gameReportSetup[21] = { 21,0,2,0,0xFD,gameReport_ID,
	0,0,0,B0_rate,B1_rate,B2_rate,B3_rate,0,0,0,0,0,0,0,0 };
	
private:
	//Variables
	TwoWire* _i2cPort;		//The generic connection to user's chosen I2C hardware
	uint8_t _deviceAddress; //Keeps track of I2C address. setI2CAddress changes this.

	Stream* _debugPort;			 //The stream to send debug messages to if enabled. Usually Serial.
	boolean _printDebug = false; //Flag to print debugging variables	
};
