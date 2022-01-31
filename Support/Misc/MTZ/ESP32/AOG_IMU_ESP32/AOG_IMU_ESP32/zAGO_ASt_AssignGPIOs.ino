void assignGPIOs_start_extHardware() {
	delay(50);

	//init wire for ADS and MMA or BNO or CMPS
	if (!Wire.begin(Set.SDA, Set.SCL, 400000)) {
		Serial.println("error INIT wire, ADS, BNO, CMPS, MMA will not work");
	}
	delay(100);

	//init GPIO pins, if 255 = unused/not connected
#if useLED_BUILTIN
	pinMode(LED_BUILTIN, OUTPUT);
#endif	
	if (Set.LEDWiFi_PIN < 255) { pinMode(Set.LEDWiFi_PIN, OUTPUT); }

	delay(100);

	//test if CMPS working
	if (Set.IMUType == 2) {
		byte error;
		Wire.beginTransmission(Set.CMPS14_ADDRESS);
		error = Wire.endTransmission();
		if (error == 0)
		{
			if (Set.debugmode) {
				Serial.println("Error = 0");
				Serial.print("CMPS14 ADDRESs: 0x");
				Serial.println(Set.CMPS14_ADDRESS, HEX);
				Serial.println("CMPS14 Ok.");
			}
		}
		else
		{
			Serial.println("Error = 4");
			Serial.print("CMPS not Connected or Found at address 0x");
			Serial.println(Set.CMPS14_ADDRESS, HEX);
			Set.IMUType = 0;
		}
	}
    else {
        if (Set.IMUType == 3) {
            byte error;
            for (int i = 0; i < nrBNO08xAdresses; i++)
            {
                bno08xAddress = Set.bno08xAddresses[i];

                Serial.print("\r\nChecking for BNO08X on ");
                Serial.println(bno08xAddress, HEX);
                Wire.beginTransmission(bno08xAddress);
                error = Wire.endTransmission();

                if (error == 0)
                {
                    Serial.println("Error = 0");
                    Serial.print("BNO08X ADDRESs: 0x");
                    Serial.println(bno08xAddress, HEX);
                    Serial.println("BNO08X Ok.");

                    // Initialize BNO080 lib        
                    if (bno08x.begin(bno08xAddress))
                    {
                        Wire.setClock(400000); //Increase I2C data rate to 400kHz

                        // Use gameRotationVector
                        bno08x.enableGameRotationVector(REPORT_INTERVAL); //Send data update every REPORT_INTERVAL in ms for BNO085

                        // Retrieve the getFeatureResponse report to check if Rotation vector report is corectly enable
                        if (bno08x.getFeatureResponseAvailable() == true)
                        {
                            if (bno08x.checkReportEnable(SENSOR_REPORTID_GAME_ROTATION_VECTOR, REPORT_INTERVAL) == false) bno08x.printGetFeatureResponse();

                            // Break out of loop
                           // useBNO08x = true;
                            break;
                        }
                        else
                        {
                            Set.IMUType = 0;
                            Serial.println("BNO08x init fails!!");
                        }
                    }
                    else
                    {
                        Serial.println("BNO080 not detected at given I2C address.");
                    }
                }
                else
                {
                    Serial.println("Error = 4");
                    Serial.println("BNO08X not Connected or Found");
                }
            }
        }
    }
}