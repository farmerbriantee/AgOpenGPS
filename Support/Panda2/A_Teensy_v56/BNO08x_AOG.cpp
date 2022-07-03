

#include "BNO08x_AOG.h"

//Attempt communication with the device
boolean BNO080::begin(uint8_t deviceAddress, TwoWire& wirePort)
{
	_deviceAddress = deviceAddress; //If provided, store the I2C address from user
	_i2cPort = &wirePort;			//Grab which port the user wants us to use

	//We expect caller to begin their I2C port, with the speed of their choice external to the library
	//But if they forget, we start the hardware here.
	//_i2cPort->begin();

	delay(300);

	Wire.beginTransmission(_deviceAddress);
	while (Wire.endTransmission() != 0);

	Serial.println("BNO found");

	Serial.print("SHTP advertising: ");
	shtpData[0] = 1;                                       // start condition
	while (shtpData[0] != 0)                               // repeat if length is still > 0
	{
		Wire.requestFrom((int)_deviceAddress, 32);
		int i = 0;
		while (Wire.available())
		{
			shtpData[i] = Wire.read();
			i++;
		}
		for (int j = 4; j < 32; j++)  // skip first 4 bytes 
		{
			Serial.print(shtpData[j], HEX);
			Serial.print(",");
		}
	}
	Serial.println();

	delay(300);

	return (true);
}

void BNO080::SensorRate()
{
	//Send the report update and mode to BNO
	Wire.beginTransmission(_deviceAddress);
	Wire.write(gameReportSetup, sizeof(gameReportSetup));
	Wire.endTransmission();
}

bool BNO080::GetQuaternion()
{
	// raw quaternion integer values
	int16_t rawQuatReal, rawQuatI, rawQuatJ, rawQuatK;                        

	//Slam all 21 with 1 request
	Wire.requestFrom((int)_deviceAddress, 21);

	//4 bytes for header
	for (byte i = 0; i < 4; i++)
	{
		shtpHeader[i] = _i2cPort->read();
	}

	//21 bytes for 0x08 Game Vector Message FB
	for (byte i = 0; i < 17; i++)
	{
		shtpData[i] = _i2cPort->read();
	}

	//Calculate the number of data bytes in this packet
	uint16_t dataLength = (((uint16_t)shtpHeader[1]) << 8) | ((uint16_t)shtpHeader[0]);
	
	//remove the leftmost bit
	dataLength &= -32769;

	//A normal GameVector Packet or AR/VR Game Vector packet
	if (dataLength == 21)
	{
		if (shtpData[5] == gameReport_ID)                                            // check for report 
		{
			rawQuatI = (((int16_t)shtpData[10] << 8) | shtpData[9]);
			rawQuatJ = (((int16_t)shtpData[12] << 8) | shtpData[11]);
			rawQuatK = (((int16_t)shtpData[14] << 8) | shtpData[13]);
			rawQuatReal = (((int16_t)shtpData[16] << 8) | shtpData[15]);

			// apply Q point (14), convert from fixed point integer
			dqw = rawQuatReal * QP14; dqx = rawQuatI * QP14; dqy = rawQuatJ * QP14; dqz = rawQuatK * QP14;    
 
			return(true);
		}
	}

	else //there is more then a single report, batched report, whatever - clean it.
	{
		//Ask for four bytes to find out how much data we need to read
		_i2cPort->requestFrom((uint8_t)_deviceAddress, (size_t)4); 

		shtpHeader[0] = _i2cPort->read(); //LSB
		shtpHeader[1] = _i2cPort->read(); //MSB
		_i2cPort->read();
		_i2cPort->read();

		//Calculate the number of data bytes in this packet
		uint16_t dataLength = (((uint16_t)shtpHeader[1]) << 8) | ((uint16_t)shtpHeader[0]);

		//exclude the multi-packet bit flag from length
		dataLength &= ~(1 << 15);

		dataLength -= 4;

		uint16_t dataSpot = 0; //Start at the beginning of shtpData array

		//Setup a series of chunked 32 byte reads
		while (dataLength > 0)
		{
			uint16_t numberOfBytesToRead = dataLength;
			if (numberOfBytesToRead > (28))
				numberOfBytesToRead = (28);

			_i2cPort->requestFrom((uint8_t)_deviceAddress, (size_t)(numberOfBytesToRead + 4));
			if (waitForI2C() == false)
				return (0); //Error

			//The first four bytes are header bytes and are throw away
			_i2cPort->read();
			_i2cPort->read();
			_i2cPort->read();
			_i2cPort->read();

			for (uint8_t x = 0; x < numberOfBytesToRead; x++)
			{
				uint8_t incoming = _i2cPort->read();
				if (dataSpot < MAX_PACKET_SIZE)
				{
					shtpData[dataSpot++] = incoming; //Store data into the shtpData array
				}
			}

			dataLength -= numberOfBytesToRead;
		}
		//Serial.println("  Cleaned ");
		//Serial.println(dataLength);

	}
	return (false); //Done - let the data die.
}

	/*  0 Report ID = 0x08
		1 Sequence number
		2 Status
		3 Delay
		4 Unit quaternion i component LSB
		5 Unit quaternion i component MSB
		6 Unit quaternion j component LSB
		7 Unit quaternion j component MSB
		8 Unit quaternion k component LSB
		9 Unit quaternion k component MSB
		10 Unit quaternion real component LSB
		11 Unit quaternion real component MSB */

//Calling this function with nothing sets the debug port to Serial
//You can also call it with other streams like Serial1, SerialUSB, etc.
void BNO080::enableDebugging(Stream &debugPort)
{
	_debugPort = &debugPort;
	_printDebug = true;
}

//Wait a certain time for incoming I2C bytes before giving up
//Returns false if failed
boolean BNO080::waitForI2C()
{
	for (uint8_t counter = 0; counter < 3; counter++) //Don't got more than 255
	{
		if (_i2cPort->available() > 0)
			return (true);
		delay(1);
	}

	//if (_printDebug == true)
	//	_debugPort->println(F("I2C timeout"));
	Serial.print(F("I2."));
	return (false);
}

//Pretty prints the contents of the current shtp header and data packets
void BNO080::printPacket(void)
{
	if (_printDebug == true)
	{
		uint16_t packetLength = (uint16_t)shtpHeader[1] << 8 | shtpHeader[0];

		//Print the four byte header
		_debugPort->print(F("Header:"));
		for (uint8_t x = 0; x < 4; x++)
		{
			_debugPort->print(F(" "));
			if (shtpHeader[x] < 0x10)
				_debugPort->print(F("0"));
			_debugPort->print(shtpHeader[x], HEX);
		}

		uint8_t printLength = packetLength - 4;
		if (printLength > 40)
			printLength = 40; //Artificial limit. We don't want the phone book.

		_debugPort->print(F(" Body:"));
		for (uint8_t x = 0; x < printLength; x++)
		{
			_debugPort->print(F(" "));
			if (shtpData[x] < 0x10)
				_debugPort->print(F("0"));
			_debugPort->print(shtpData[x], HEX);
		}

		//if (packetLength & 1 << 15)
		//{
		//	_debugPort->println(F(" [Continued packet] "));
		//	packetLength &= ~(1 << 15);
		//}

		_debugPort->print(F(" Length:"));
		_debugPort->print(packetLength);

		_debugPort->print(F(" Channel:"));
		if (shtpHeader[2] == 0)
			_debugPort->print(F("Command"));
		else if (shtpHeader[2] == 1)
			_debugPort->print(F("Executable"));
		else if (shtpHeader[2] == 2)
			_debugPort->print(F("Control"));
		else if (shtpHeader[2] == 3)
			_debugPort->print(F("Sensor-report"));
		else if (shtpHeader[2] == 4)
			_debugPort->print(F("Wake-report"));
		else if (shtpHeader[2] == 5)
			_debugPort->print(F("Gyro-vector"));
		else
			_debugPort->print(shtpHeader[2]);

		_debugPort->println();
	}
}
