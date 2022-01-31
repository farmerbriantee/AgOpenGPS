//getData 7. Maerz 2021
void getDataFromAOGUSB(void* pvParameters)
{
	byte nextincommingBytesArrayNr;
	unsigned int packetLength;

	vTaskDelay(5000);//wait for other tasks to start

	USBDataTaskRunning = true;
	if (Set.debugmode) { Serial.println("started Task get Data via USB"); }
	for (;;) {
		//get Data
		packetLength = Serial.available();
		if (packetLength > 0) {
			nextincommingBytesArrayNr = (incommingBytesArrayNr + 1) % incommingDataArraySize;
			for (int i = 0; i < packetLength; i++) { incommingBytes[nextincommingBytesArrayNr][i] = Serial.read(); }
			incommingBytesArrayNr = nextincommingBytesArrayNr;
			incommingDataLength[incommingBytesArrayNr] = packetLength;
		}
		else { vTaskDelay(10); }
	}
}

//-------------------------------------------------------------------------------------------------

void getDataFromAOGWiFi(void* pvParameters)
{
	byte nextincommingBytesArrayNr;
	unsigned int packetLength;

	WiFiDataTaskRunning = true;

	for (;;) {
		if (!WiFiUDPRunning) { vTaskDelay(3000); }
		else { break; }
	}
	if (Set.debugmode) { Serial.println("started Task get Data via WiFi"); }
	for (;;) {
		//get Data
		packetLength = WiFiUDPFromAOG.parsePacket();
		if (packetLength > 0) {
			nextincommingBytesArrayNr = (incommingBytesArrayNr + 1) % incommingDataArraySize;
			WiFiUDPFromAOG.read(incommingBytes[nextincommingBytesArrayNr], packetLength);
			incommingBytesArrayNr = nextincommingBytesArrayNr;
			incommingDataLength[incommingBytesArrayNr] = packetLength;
			//Serial.println("got Data");
		}
		else { vTaskDelay(10); }
	}
}

//-------------------------------------------------------------------------------------------------


void getDataFromAOGEth(void* pvParameters)
{
	byte nextincommingBytesArrayNr;
	unsigned int packetLength;

	EthDataTaskRunning = true;

	for (;;) {
		if (!EthUDPRunning) { vTaskDelay(3000); }
		else { break; }
	}
	if (Set.debugmode) { Serial.println("started Task get Data via Ethernet"); }
	for (;;) {
		//get Data		
		packetLength = EthUDPFromAOG.parsePacket();
		if (packetLength) {
			nextincommingBytesArrayNr = (incommingBytesArrayNr + 1) % incommingDataArraySize;
			EthUDPFromAOG.read(incommingBytes[nextincommingBytesArrayNr], packetLength);
			incommingBytesArrayNr = nextincommingBytesArrayNr;
			incommingDataLength[incommingBytesArrayNr] = packetLength;
		}
		else { vTaskDelay(10); }
	}
}

//-------------------------------------------------------------------------------------------------
//parseData 7. Maerz 2021

void parseDataFromAOG() {
	for (int i = 0; i < incommingDataLength[incommingBytesArrayNrToParse]; i++) {
		//sentence comming? V4.6: 80 81 7F PGN  V4.3: 7F PGN so for V4. incomSentenceDigit is set to 2 instead of 0 for new sentence
		if (incomSentenceDigit < 3) {
			if (incommingBytes[incommingBytesArrayNrToParse][i] == FromAOGSentenceHeader[incomSentenceDigit]) {
				//Serial.println("first 3 Bytes fit: sentence");
				SentenceFromAOG[incomSentenceDigit] = incommingBytes[incommingBytesArrayNrToParse][i];
				incomSentenceDigit++;
			}
			else {
				if (Set.aogVersion == 17) { incomSentenceDigit = 2; }
				else { incomSentenceDigit = 0; }
			}
		}//<3
		else {
			//write incoming Data to sentence array if it fits in
			if (incomSentenceDigit <= SentenceFromAOGMaxLength) {
				SentenceFromAOG[incomSentenceDigit] = incommingBytes[incommingBytesArrayNrToParse][i];
			}

			if (incomSentenceDigit == 3) {
				incomSentenceDigit++;
				//which sentence comming? PGN
				switch (incommingBytes[incommingBytesArrayNrToParse][i]) {
				case steerDataFromAOGHeader:
					if (Set.aogVersion == 17) { isSteerDataFoundV17 = true; SentenceFromAOGLength = 6; }//V4.3: no length, no crc but 4 header, starting at 0
					else{ isSteerDataFound = true; }
					break;
				case steerSettingsFromAOGHeader:
					if (Set.aogVersion == 17) { isSteerSettingFoundV17 = true; SentenceFromAOGLength = 6; }//V4.3: no length, no crc but 4 header, starting at 0
					else { isSteerSettingFound = true; }
					break;
				case steerArdConfFromAOGHeader:
					if (Set.aogVersion == 17) { isSteerArdConfFoundV17 = true; SentenceFromAOGLength = 6; }//V4.3: no length, no crc but 4 header, starting at 0
					else { isSteerArdConfFound = true; }
					break;
				default:
					//Serial.println("no matching PGN");
					if (Set.aogVersion == 17) { incomSentenceDigit = 2; }
					else { incomSentenceDigit = 0; }
					break;
				}//switch
			}//==3
			else {// >3
				if (incomSentenceDigit == 4) {//lenght
					if (Set.aogVersion != 17) {
						SentenceFromAOGLength = incommingBytes[incommingBytesArrayNrToParse][i];//+1 for CRC + 1 for Length 
					}
					incomSentenceDigit++;
					//if (Set.debugmodeDataFromAOG) {
						//Serial.print(" length of incomming sentence: ");
						//Serial.print(SentenceFromAOGLength);
						//Serial.print(" ESP time: "); Serial.println(millis());
					//}
				}//==4
				else
				{//>4	
					if (incomSentenceDigit == (SentenceFromAOGLength + 5)) { //sentence complete Length: + 4 byte header + 1 length + 1 CRC - 1 (starting at 0) 
						//sentence complete
						if (Set.aogVersion != 17) {//NO checksum in V 4.3
							int CRCDataFromAOG = 0;
							for (byte i = 2; i < sizeof(SentenceFromAOG) - 1; i++)
							{
								CRCDataFromAOG = (CRCDataFromAOG + SentenceFromAOG[i]);
							}
							if (byte(CRCDataFromAOG) == incommingBytes[incommingBytesArrayNrToParse][i]) {
							  //Serial.println("Checksum OK");
							}
							else
							{//checksum error
								if (Set.debugmodeDataFromAOG) { Serial.println("Checksum error"); }
								isSteerDataFound = false;
								isSteerSettingFound = false;
								isSteerArdConfigFound = false;
								incomSentenceDigit = 255;
							}
						}
						if (Set.debugmodeDataFromAOG) {
							for (byte b = 0; b <= (SentenceFromAOGLength + 5); b++) {
								Serial.print(SentenceFromAOG[b]); Serial.print(" ");
							}
							Serial.println();
						}

						if (isSteerDataFound) {
							SectGrFromAOG[0] = SentenceFromAOG[11];   // read Section control from AgOpenGPS 
							SectGrFromAOG[1] = SentenceFromAOG[12];   // read Section control from AgOpenGPS 

							Tram = SentenceFromAOG[10];

							gpsSpeed = ((float)(SentenceFromAOG[6] << 8 | SentenceFromAOG[5])) * 0.1;

							guidanceStatus = SentenceFromAOG[7];

							//Bit 8,9    set point steer angle * 100 is sent
							steerAngleSetPoint = ((float)(SentenceFromAOG[9] << 8 | SentenceFromAOG[8])) * 0.01; //high low bytes
							if (steerAngleSetPoint > 500) { steerAngleSetPoint -= 655.35; }
						//	Serial.print("SteerSetPoint: "); Serial.println(steerAngleSetPoint);

							newDataFromAOG = true;
							isSteerDataFound = false;
							incomSentenceDigit = 255;
							DataFromAOGTime = millis();
							watchdogTimer = 0;
							if (Set.debugmodeDataFromAOG) {
								Serial.print("speed: "); Serial.print(gpsSpeed);
								Serial.print(" GuidStat: "); Serial.print(guidanceStatus);
								Serial.print(" SteerAngSet: "); Serial.print(steerAngleSetPoint);
								Serial.print(" SectGrFromAOG[0]: "); Serial.print(SectGrFromAOG[0]);
								Serial.print(" SectGrFromAOG[1]: "); Serial.println(SectGrFromAOG[1]);
							}
						}
						else {

							if (isSteerDataFoundV17) {
								SectGrFromAOG[0] = SentenceFromAOG[4];   // read Section control from AgOpenGPS 
								SectGrFromAOG[1] = 0;   // not send in V4.3 

								gpsSpeed = ((float)(SentenceFromAOG[5])) * 0.25;

								//distance from the guidance line in mm
								distanceFromLine = (float)(SentenceFromAOG[6] << 8 | SentenceFromAOG[7]);   //high,low bytes     
								if (int(distanceFromLine) == 32020) { guidanceStatus = 0; }
								else { guidanceStatus = 1; }

								//set point steer angle * 10 is sent
								steerAngleSetPoint = ((float)(SentenceFromAOG[8] << 8 | SentenceFromAOG[9])) * 0.01; //high low bytes 

								if (steerAngleSetPoint > 500) { steerAngleSetPoint -= 655.35; }
								//Serial.print("SteerSetPoint V17: "); Serial.println(steerAngleSetPoint);


								newDataFromAOG = true;
								isSteerDataFoundV17 = false;
								incomSentenceDigit = 1;
								DataFromAOGTime = millis();
								watchdogTimer = 0;
								if (Set.debugmodeDataFromAOG) {
									Serial.print("speed: "); Serial.print(gpsSpeed);
									Serial.print(" GuidStat: "); Serial.print(guidanceStatus);
									Serial.print(" SteerAngSet: "); Serial.print(steerAngleSetPoint);
									Serial.print(" distFromLine: "); Serial.print(distanceFromLine);
									Serial.print(" SectGrFromAOG[0]: "); Serial.println(SectGrFromAOG[0]);
								}
							}
							else {

								if (isSteerSettingFound) {
									//PID values
									Set.Kp = ((float)SentenceFromAOG[5]);   // read Kp from AgOpenGPS
									Set.highPWM = SentenceFromAOG[6];
									Set.lowPWM = (float)SentenceFromAOG[7];   // read lowPWM from AgOpenGPS
									Set.minPWM = SentenceFromAOG[8]; //read the minimum amount of PWM for instant on
									Set.steerSensorCounts = float(SentenceFromAOG[9]); //sent as setting displayed in AOG
							//		Set.wasOffset = (SentenceFromAOG[10]);  //read was zero offset Hi
							//		Set.wasOffset |= (SentenceFromAOG[11] << 8);  //read was zero offset Lo
									Set.AckermanFix = SentenceFromAOG[12];

									EEprom_write_all();

									// for PWM High to Low interpolator
									highLowPerDeg = ((float)(Set.highPWM - Set.lowPWM)) / Set.MotorSlowDriveDegrees;

									if (Set.debugmodeDataFromAOG) { Serial.println("got NEW steer settings from AOG"); }
									isSteerSettingFound = false;
									incomSentenceDigit = 255;
								}

								if (isSteerSettingFoundV17) {
									/*				steerSettings.Kp = (float)udpData[2];       // read Kp from AgOpenGPS
													steerSettings.lowPWM = (float)udpData[3];     // read lowPWM from AgOpenGPS
													steerSettings.Kd = (float)udpData[4] * 1.0;       // read Kd from AgOpenGPS
													steerSettings.Ko = (float)udpData[5] * 0.1;       // read Ko from AgOpenGPS
													steerSettings.steeringPositionZero = (WAS_ZERO)+udpData[6];//read steering zero offset

													steerSettings.minPWM = udpData[7]; //read the minimum amount of PWM for instant on
													steerSettings.highPWM = udpData[8]; //
													steerSettings.steerSensorCounts = udpData[9];

													byte checksum = 0;
													for (int i = 2; i < 10; i++) checksum += udpData[i];

													//send udpData back - version number.
													SendTwoThirty((byte)checksum);
				*/
									Set.Kp = (float)SentenceFromAOG[4];       // read Kp from AgOpenGPS
									Set.lowPWM = (float)SentenceFromAOG[5];     // read deadZone from AgOpenGPS
									Set.Kd = (float)SentenceFromAOG[6] * 1.0;       // read Kd from AgOpenGPS
									Set.Ko = (float)SentenceFromAOG[7] * 0.1;       // read Ko from AgOpenGPS
									//Set.steeringPositionZero = (WAS_ZERO)+DataFromAOG[6];//read steering zero offset  
									Set.AOGSteerPositionZero = float(SentenceFromAOG[8]) - 127;//read steering zero offset  

									Set.minPWM = SentenceFromAOG[9]; //read the minimum amount of PWM for instant on
									Set.highPWM = SentenceFromAOG[10]; //

									Set.steerSensorCounts = SentenceFromAOG[11];

									int checksum = 0;
									for (byte i = 4; i < 12; i++) checksum += SentenceFromAOG[i];

									//send data back - version number. 
									SendTwoThirty((byte)checksum);

									highLowPerDeg = (Set.highPWM - Set.lowPWM) / Set.MotorSlowDriveDegrees;

									EEprom_write_all();

									if (Set.debugmodeDataFromAOG) { Serial.println("got NEW steer settings from AOG V4.3.10"); }

									isSteerSettingFoundV17 = false;
									incomSentenceDigit = 1;
								}

								if (isSteerArdConfigFound) {
									if (bitRead(SentenceFromAOG[5], 0)) Set.InvertWAS = 1; else Set.InvertWAS = 0;
									if (bitRead(SentenceFromAOG[5], 1)) Set.Relays_ON = 1; else Set.Relays_ON = 0;
									if (bitRead(SentenceFromAOG[5], 2)) Set.MotorDriveDirection = 1; else Set.MotorDriveDirection = 0;
									//if (bitRead(SentenceFromAOG[5], 3)) Set.SingleInputWAS = 1; else Set.SingleInputWAS = 0;
									//if (bitRead(SentenceFromAOG[5], 4)) Set.CytronDriver = 1; else Set.CytronDriver = 0;
									if (bitRead(SentenceFromAOG[5], 5)) Set.SteerSwitchType = 1;//switch to GND
									if (bitRead(SentenceFromAOG[5], 6)) Set.SteerSwitchType = 2;//button
									else {
										if (!bitRead(SentenceFromAOG[5], 5)) { Set.SteerSwitchType = 255; }//none
									}
									if (bitRead(SentenceFromAOG[5], 7)) Set.ShaftEncoder = 1; else Set.ShaftEncoder = 0;

									Set.pulseCountMax = SentenceFromAOG[6];

									//if (bitRead(SentenceFromAOG[8], 0)) Set.IsDanfoss = 1; else Set.IsDanfoss = 0;
									//if (bitRead(SentenceFromAOG[8], 1)) Set.PressureSensor = 1; else Set.PressureSensor = 0;
									//if (bitRead(SentenceFromAOG[8], 2)) Set.CurrentSensor = 1; else Set.CurrentSensor = 0;

									EEprom_write_all();

									if (Set.debugmodeDataFromAOG) { Serial.println("got NEW Arduino settings from AOG V4.6 or higher"); }

									isSteerArdConfigFound = false;
									incomSentenceDigit = 255;
								}

								if (isSteerArdConfigFoundV17) {
									/*		//set0
											byte sett = udpData[2];  //actual speed times 4, single byte
											if (bitRead(sett, 0)) aogSettings.InvertWAS = 1; else aogSettings.InvertWAS = 0;
											if (bitRead(sett, 1)) aogSettings.InvertRoll = 1; else aogSettings.InvertRoll = 0;
											if (bitRead(sett, 2)) aogSettings.MotorDriveDirection = 1; else aogSettings.MotorDriveDirection = 0;
											if (bitRead(sett, 3)) aogSettings.SingleInputWAS = 1; else aogSettings.SingleInputWAS = 0;
											if (bitRead(sett, 4)) aogSettings.CytronDriver = 1; else aogSettings.CytronDriver = 0;
											if (bitRead(sett, 5)) aogSettings.SteerSwitch = 1; else aogSettings.SteerSwitch = 0;
											if (bitRead(sett, 6)) aogSettings.UseMMA_X_Axis = 1; else aogSettings.UseMMA_X_Axis = 0;
											if (bitRead(sett, 7)) aogSettings.ShaftEncoder = 1; else aogSettings.ShaftEncoder = 0;

											//set1
											sett = udpData[3];
											if (bitRead(sett, 0)) aogSettings.BNOInstalled = 1; else aogSettings.BNOInstalled = 0;
											if (bitRead(sett, 1)) aogSettings.isRelayActiveHigh = 1; else aogSettings.isRelayActiveHigh = 0;

											aogSettings.maxSteerSpeed = udpData[4]; //actual speed
											aogSettings.minSteerSpeed = udpData[5];

											sett = udpData[6];
											aogSettings.InclinometerInstalled = sett & 192;
											aogSettings.InclinometerInstalled = aogSettings.InclinometerInstalled >> 6;
											aogSettings.PulseCountMax = sett & 63;

											aogSettings.AckermanFix = udpData[7];

											byte checksum = 0;
											for (int i = 2; i < 10; i++) checksum += udpData[i];
		*/
									isSteerArdConfigFoundV17 = false;
									incomSentenceDigit = 1;
								}
							}
						}
					}//sentence complete


					incomSentenceDigit++;

					if (incomSentenceDigit > (SentenceFromAOGLength + 6)) {
						//Serial.println("sentence too long");
						if (Set.aogVersion == 17) { incomSentenceDigit = 2; }
						else { incomSentenceDigit = 0; }
						
					}
				}//>4
			}//==3
		}//<3
	}//for packetLength

	//this packet is done, prepare for new 
	incommingDataLength[incommingBytesArrayNrToParse] = 0;
	incommingBytesArrayNrToParse = (incommingBytesArrayNrToParse + 1) % incommingDataArraySize;
}

//-------------------------------------------------------------------------------------------------
// 7. Maerz 2021

void AOGDataSend()
{
	//USB
	if (Set.DataTransVia < 5) {
		if (Set.aogVersion == 17) {
			for (byte idx = 0; idx < DataToAOGLength; idx++) {
				Serial.print(steerToAOG[idx]);
				if (idx < (DataToAOGLength - 1)) { Serial.print(","); }
			}
			Serial.println();
		}
		else {
			Serial.write(steerToAOG, DataToAOGLength);
		}
	}
#if HardwarePlatform == 1
	else {
		if (Set.DataTransVia < 10)
		{
			//WiFiUDPToAOG.writeTo(steerToAOG, SCDataSentenceToAOGLengthV17, WiFi_ipDestination, Set.PortDestination);
			for (byte idx = 0; idx < DataToAOGLength; idx++) {
				WiFiUDPToAOG.write(steerToAOG[idx]);
			}
		}
	}
#endif
#if HardwarePlatform == 0
	else {
	if (Set.DataTransVia < 10)//WiFi UDP
	{
		WiFiUDPToAOG.beginPacket(WiFi_ipDestination, Set.PortDestination);
		WiFiUDPToAOG.write(steerToAOG, DataToAOGLength);
		WiFiUDPToAOG.endPacket();
	}
	else //Ethernet
	{
		EthUDPToAOG.beginPacket(Eth_ipDestination, Set.PortDestination);
		EthUDPToAOG.write(steerToAOG, DataToAOGLength);
		EthUDPToAOG.endPacket();
	}
	}
#endif
}

//-------------------------------------------------------------------------------------------------
//send back checksum and version

void SendTwoThirty(byte check)
{
	if (Set.aogVersion == 17) {
		byte TwoThirtyV17[10] = { FromAOGSentenceHeader[2],230,check,Set.aogVersion,0,0,0,0,0,0 };
		if (Set.DataTransVia < 5) {
			for (byte n = 0; n < sizeof(TwoThirtyV17) - 1; n++) {
				Serial.print(TwoThirtyV17[n]); Serial.print(",");
			}
			Serial.println(TwoThirtyV17[sizeof(TwoThirtyV17)]);//drop , after byte 9
		}
		else {
			if (Set.DataTransVia > 10) {//WiFi UDP
				if (WiFiUDPRunning) {
					WiFiUDPToAOG.beginPacket(WiFi_ipDestination, Set.PortDestination);
					WiFiUDPToAOG.write(TwoThirtyV17, sizeof(TwoThirtyV17));
					WiFiUDPToAOG.endPacket();
				}
			}
			else {//Ethernet
				if (EthUDPRunning) {
					EthUDPToAOG.beginPacket(Eth_ipDestination, Set.PortDestination);
					EthUDPToAOG.write(TwoThirtyV17, sizeof(TwoThirtyV17));
					EthUDPToAOG.endPacket();
				}
			}
		}
	}
	else {
		byte TwoThirtyV20[] = { FromAOGSentenceHeader[0],FromAOGSentenceHeader[1],FromAOGSentenceHeader[2],230,2,check,Set.aogVersion, check + Set.aogVersion };
		if (Set.DataTransVia < 5) {//USB
			Serial.write(TwoThirtyV20, sizeof(TwoThirtyV20));
		}
		else {
			if (Set.DataTransVia > 10) {//WiFi UDP
				if (WiFiUDPRunning) {
					WiFiUDPToAOG.beginPacket(WiFi_ipDestination, Set.PortDestination);
					WiFiUDPToAOG.write(TwoThirtyV20, sizeof(TwoThirtyV20));
					WiFiUDPToAOG.endPacket();
				}
			}
			else {//Ethernet
				if (EthUDPRunning) {
					EthUDPToAOG.beginPacket(Eth_ipDestination, Set.PortDestination);
					EthUDPToAOG.write(TwoThirtyV20, sizeof(TwoThirtyV20));
					EthUDPToAOG.endPacket();
				}
			}
		}
	}
}
