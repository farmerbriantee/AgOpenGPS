
   /*
    * This program only turns the relays for section control
    * On and Off. Connect to the AutoSteer Port in AgOpenGPS
    * Pin5 is relay1 to pin 12 which is relay8 (section 1 to 8)
    */
    
  //loop time variables in microseconds
  const unsigned int LOOP_TIME = 200; //5hz
  unsigned int lastTime = LOOP_TIME;
  unsigned int currentTime = LOOP_TIME;
  unsigned int dT = 50000;
  unsigned int count = 0;
  byte watchdogTimer = 0;
  byte serialResetTimer = 0; //if serial buffer is getting full, empty it

  
   //program flow
  bool isDataFound = false, isSettingFound = false;
  int header = 0, tempHeader = 0, temp;

  byte relay = 0, uTurn = 0, gpsSpeed = 0, remoteSwitch = 0, workSwitch = 0, steerSwitch = 1, switchByte = 0;
 
void setup()
{
 	Serial.begin(38400);

  //set the pins to be outputs (pin numbers)
  pinMode(5, OUTPUT);
  pinMode(6, OUTPUT);
  pinMode(7, OUTPUT);
  pinMode(8, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(12, OUTPUT);  
}

void loop()
{
  //Loop triggers every 100 msec and sends back gyro heading, and roll, steer angle etc

	currentTime = millis();
	unsigned int time = currentTime;

	if (currentTime - lastTime >= LOOP_TIME)
	{
		dT = currentTime - lastTime;
		lastTime = currentTime;

		//If connection lost to AgOpenGPS, the watchdog will count up and turn off steering
		if (watchdogTimer++ > 250) watchdogTimer = 12;

		//clean out serial buffer to prevent buffer overflow
		if (serialResetTimer++ > 20)
		{
			while (Serial.available() > 0) char t = Serial.read();
			serialResetTimer = 0;
		}

    SetRelays();
 

		//Send to agopenGPS **** you must send 5 numbers ****
		Serial.print(0); //The actual steering angle in degrees times 100
		Serial.print(",");

		// *******  steer angle setpoint
    Serial.print(0); //setpoint in degrees * 100
		Serial.print(",");

    //heading 
    Serial.print(9999);
    Serial.print(",");

		//*******  if no roll is installed, send 9999
		Serial.print(9999);
		Serial.print(",");

    Serial.println(relay); //steering switch status
    
		Serial.flush();   // flush out buffer
	} //end of timed loop

  //****************************************************************************************
  //This runs continuously, outside of the timed loop, keeps checking UART for new data
  // header high/low, relay byte, speed byte, high distance, low distance, Steer high, steer low
	if (Serial.available() > 0 && !isDataFound && !isSettingFound) //find the header, 127H + 254L = 32766
	{
		int temp = Serial.read();
		header = tempHeader << 8 | temp;                //high,low bytes to make int
		tempHeader = temp;                              //save for next time
		if (header == 32766) isDataFound = true;        //Do we have a match?
		if (header == 32764) isSettingFound = true;     //Do we have a match?
	}

	//Data Header has been found, so the next 6 bytes are the data
	if (Serial.available() > 7 && isDataFound)
	{
		isDataFound = false;
		relay = Serial.read();          // read relay control from AgOpenGPS
		gpsSpeed = Serial.read() >> 2;  //actual speed times 4, single byte

		Serial.read() << 8 | Serial.read();   //high,low bytes

		//set point steer angle * 10 is sent
		Serial.read() << 8 | Serial.read(); //high low bytes

			watchdogTimer = 0;  //reset watchdog
			serialResetTimer = 0; //if serial buffer is getting full, empty it

    //uturn byte read in
    Serial.read();
	}

	//Settings Header has been found, 8 bytes are the settings
	if (Serial.available() > 7 && isSettingFound)
	{
		isSettingFound = false;  //reset the flag

		//change the factors as required for your own PID values
	  Serial.read() * 1.0;      // read Kp from AgOpenGPS
		Serial.read() * 1.0;    // read Ki from AgOpenGPS
		Serial.read() * 1.0;      // read Kd from AgOpenGPS
		Serial.read() * 0.1;      // read Ko from AgOpenGPS
   
		Serial.read();  //read steering zero offset
    
    Serial.read();                 //read the minimum amount of PWM for instant on
    
		Serial.read();   //
		Serial.read();      //
	}
}

