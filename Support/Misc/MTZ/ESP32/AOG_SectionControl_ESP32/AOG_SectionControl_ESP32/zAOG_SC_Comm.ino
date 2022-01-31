
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
				case SteerDataFromAOGHeader:
					if (Set.aogVersion != 17) { isSteerDataFound = true;}//SC uses steer data in V4.6
					break;
				case SCSettingsFromRCHeader:
					isRCSettingFound = true;
					break;
				case SCDataFromAOGHeaderV17:
					isSCDataFoundV17 = true;
					SentenceFromAOGLength = 6;//no length, no crc but 4 header, starting at 0
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
						SentenceFromAOGLength = incommingBytes[incommingBytesArrayNrToParse][i];
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
								isSCDataFoundV17 = false;
								isRCSettingFound = false;
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

							gpsSpeed = ((float)(SentenceFromAOG[6] << 8 | SentenceFromAOG[5])) * 0.1;

							//newDataFromAOG = true;
							isSteerDataFound = false;
							if (Set.aogVersion == 17) { incomSentenceDigit = 1; }
							else { incomSentenceDigit = 255; }
							DataFromAOGTime = millis();
							if (Set.debugmodeDataFromAOG) {
								Serial.print("speed: "); Serial.print(gpsSpeed);
								Serial.print(" SectGr[0]: "); Serial.print(SectGrFromAOG[0]);
								Serial.print(" SectGr[1]: "); Serial.println(SectGrFromAOG[1]);
							}
						}
						else {

							if (isSCDataFoundV17) {
								SectGrFromAOG[0] = SentenceFromAOG[5];   // read Section control from AgOpenGPS 
								SectGrFromAOG[1] = SentenceFromAOG[4];   // not send in V4.3 

								gpsSpeed = ((float)(SentenceFromAOG[6])) * 0.25;

								//newDataFromAOG = true;
								isSCDataFoundV17 = false;
								incomSentenceDigit = 1;
								DataFromAOGTime = millis();
								if (Set.debugmodeDataFromAOG) {
									Serial.print("speed: "); Serial.print(gpsSpeed);
									Serial.print(" SectGr[0]: "); Serial.print(SectGrFromAOG[0]);
									Serial.print(" SectGr[1]: "); Serial.println(SectGrFromAOG[1]);
								}
							}
							else {

								if (isRCSettingFound) {


									isRCSettingFound = false;
									incomSentenceDigit = 255;
								}
							}
						}
					}//sentence complete


					incomSentenceDigit++;

					if (incomSentenceDigit > (SentenceFromAOGLength + 6)) {
						if (Set.aogVersion == 17) { incomSentenceDigit = 2; }
						else { incomSentenceDigit = 0; }
						//Serial.println("sentence too long");
					}
				}//>4
			}//==3
		}//<3
	}//for packetLength
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
				Serial.print(SCToAOG[idx]);
				if (idx < (DataToAOGLength - 1)) { Serial.print(","); }
			}
			Serial.println();
		}
		else {
			Serial.write(SCToAOG, DataToAOGLength);
		}
	}
    else {
        if (Set.DataTransVia < 10)//WiFi UDP
        {
            WiFiUDPToAOG.beginPacket(WiFi_ipDestination, Set.PortDestination);
            WiFiUDPToAOG.write(SCToAOG, DataToAOGLength);
            WiFiUDPToAOG.endPacket();
        }
        else //Ethernet
        {
            EthUDPToAOG.beginPacket(Eth_ipDestination, Set.PortDestination);
            EthUDPToAOG.write(SCToAOG, DataToAOGLength);
            EthUDPToAOG.endPacket();
        }
    }
}



