void assignGPIOs_start_extHardware() {
	delay(50);

	//init wire for ADS and MMA or BNO or CMPS
	if (!Wire.begin(Set.SDA, Set.SCL, 400000)) {
		Serial.println("error INIT wire, ADS, BNO, CMPS, MMA will not work");
	}
	delay(20);

	//init GPIO pins, if 255 = unused/not connected
#if useLED_BUILTIN
	pinMode(LED_BUILTIN, OUTPUT);
#endif	
	if (Set.LEDWiFi_PIN < 255) { pinMode(Set.LEDWiFi_PIN, OUTPUT); }
	if ((Set.WorkSW_mode > 0) && (Set.WORKSW_PIN < 255)) { pinMode(Set.WORKSW_PIN, INPUT_PULLUP); }
	if (Set.Relay_PIN[0] < 255) { pinMode(Set.Relay_PIN[0], OUTPUT); }
	if (Set.Relay_PIN[1] < 255) { pinMode(Set.Relay_PIN[1], OUTPUT); }

	//no check if < 255 as needed for autosteer in every case
	pinMode(Set.AutosteerLED_PIN, OUTPUT);
	pinMode(Set.PWM_PIN, OUTPUT);
	pinMode(Set.DIR_PIN, OUTPUT);
	delay(2);
	ledcSetup(0, Set.PWMOutFrequ, 8);  // PWM Output with channel 0, x kHz, 8-bit resolution (0-255)
	ledcSetup(1, Set.PWMOutFrequ, 8);  // PWM Output with channel 1, x kHz, 8-bit resolution (0-255)
	delay(2);
	ledcAttachPin(Set.PWM_PIN, 0);  // attach PWM PIN to Channel 0
	ledcAttachPin(Set.DIR_PIN, 1);  // attach PWM PIN to Channel 1

	//if (Set.WASType == 0)  Set.WebIOSteerPosZero = 2048;                //Starting Point with ESP ADC 2048 
	//if (Set.WASType > 0 && Set.WASType < 3)  Set.WebIOSteerPosZero = 13000;  //with ADS start with 13000  

	if (Set.SteerSwitchType == 0) { pinMode(Set.STEERSW_PIN, INPUT_PULLDOWN); }
	if (Set.SteerSwitchType > 0) { pinMode(Set.STEERSW_PIN, INPUT_PULLUP); }

	//Setup Interrupt -Steering Wheel encoder
	if (Set.encA_PIN < 255) { pinMode(Set.encA_PIN, INPUT_PULLUP); }
	if (Set.encB_PIN < 255) { pinMode(Set.encB_PIN, INPUT_PULLUP); }

	delay(50);


	//IMU
	byte error = 0;	
	switch (Set.IMUType) {		
	case 0:
		//roll no hardware = 8888
		steerToAOG[9] = 0xB8;
		steerToAOG[10] = 0x22;
		roll = 0;
		//heading16 no hardware = 9999     
		steerToAOG[7] = 0x0F;
		steerToAOG[8] = 0x27;
		heading = 0;
		break;

	case 1:	// BNO055 init
		BNO.init();
		delay(10);
		BNO.setExtCrystalUse(true);   //use external 32K crystal
		//roll no hardware = 8888
		steerToAOG[9] = 0xB8;
		steerToAOG[10] = 0x22;
		roll = 0;
		break;

	case 2://test if CMPS working			
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
		break;

	case 3:
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
		break;
	}//switch IMU

	if (Set.MMAInstalled == 1)
	{
		// MMA8452 (1) Inclinometer
		if (MMA1C.init()) {
			delay(10);

			MMA1C.setDataRate(MMA_800hz);
			MMA1C.setRange(MMA_RANGE_8G);
			MMA1C.setHighPassFilter(false);
			if (Set.debugmode) { Serial.println("MMA init OK"); }
		}
		else { Serial.println("MMA init fails at I2C address 1C!!"); Set.MMAInstalled = 0; }
	}
	else if (Set.MMAInstalled == 2)
	{
		// MMA8452 (1) Inclinometer
		if (MMA1D.init()) {
			delay(10);
			MMA1D.setDataRate(MMA_800hz);
			MMA1D.setRange(MMA_RANGE_8G);
			MMA1D.setHighPassFilter(false);
			if (Set.debugmode) { Serial.println("MMA init OK"); }
		}
		else { Serial.println("MMA init fails at I2C address 1D!!"); Set.MMAInstalled = 0; }
	}

	//ADS1115
	adc.setSampleRate(ADS1115_REG_CONFIG_DR_128SPS); //128 samples per second
	adc.setGain(ADS1115_REG_CONFIG_PGA_6_144V);

}