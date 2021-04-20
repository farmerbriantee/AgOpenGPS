//getData 7. Maerz 2021
void getDataFromAOGUSB(void* pvParameters)
{
	byte nextincommingBytesArrayNr;
	unsigned int packetLength;

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
				incomSentenceDigit = 0;
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
					isSteerDataFound = true;
					break;
				default:
					//Serial.println("no matching PGN");
					incomSentenceDigit = 0;
					break;
				}//switch
			}//==3
			else {// >3
				if (incomSentenceDigit == 4) {//lenght
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
							if (Set.debugmode) { Serial.println("Checksum error"); }
							isSteerDataFound = false;
							incomSentenceDigit = 255;
						}

						if (Set.debugmode) {
							for (byte b = 0; b <= (SentenceFromAOGLength + 5); b++) {
								Serial.print(SentenceFromAOG[b]); Serial.print(" ");
							}
							Serial.println();
						}

						if (isSteerDataFound) {
							/*
							SectGrFromAOG[0] = SentenceFromAOG[11];   // read Section control from AgOpenGPS
							SectGrFromAOG[1] = SentenceFromAOG[12];   // read Section control from AgOpenGPS

							Tram = SentenceFromAOG[10];

							gpsSpeed = ((float)(SentenceFromAOG[6] << 8 | SentenceFromAOG[5])) * 0.1;

							guidanceStatus = SentenceFromAOG[7];

							//Bit 8,9    set point steer angle * 100 is sent
							steerAngleSetPoint = ((float)(SentenceFromAOG[9] << 8 | SentenceFromAOG[8])) * 0.01; //high low bytes
							if (steerAngleSetPoint > 500) { steerAngleSetPoint -= 655.35; }
						//	Serial.print("SteerSetPoint: "); Serial.println(steerAngleSetPoint);
						*/

							newDataFromAOG = true;
							isSteerDataFound = false;
							incomSentenceDigit = 255;
							DataFromAOGTime = millis();
						}

					}//sentence complete


					incomSentenceDigit++;

					if (incomSentenceDigit > (SentenceFromAOGLength + 6)) {
						//Serial.println("sentence too long");
						incomSentenceDigit = 0;

					}
				}//>4
			}//==3
		}//<3
	}//for packetLength

	//this packet is done, prepare for new 
	incommingDataLength[incommingBytesArrayNrToParse] = 0;
	incommingBytesArrayNrToParse = (incommingBytesArrayNrToParse + 1) % incommingDataArraySize;
}


