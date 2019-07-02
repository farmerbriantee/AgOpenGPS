//The 3.3v version
#include "MMA8452Q.h"

//It says 1015 but is used for both the ADS1015 and the ADS1115
#include "ADS1015.h"

//For I2C communication
#include <Wire.h>

//##########################################################################################################
//### Setup Zone ###########################################################################################
//##########################################################################################################

  //Change depending on what happens. If the word is false use a 0, if its true use a 1
  //Only change from 0 if the response is incorrect. Start with all four set to 0.

                                            //Steering to the right should be a positive angle
  #define SteeringRightIsNotPositive 0      // Set to 0 if it steers the right way    
                                            // Set to 1 if steer to right shows negative

                                            // Does the motor spin the right way?
  #define SteerMotorDirectionBackwards 0    // Set to 0 if is correct direction
                                            // Set to 1 if it turns the wrong way
                                    
                                        // Depending on board orientation, choose the right Axis
  #define UseMMA_Y_Axis 0               // Set to 0 to use X axis of MMA
                                        // Set to 1 to use Y axis of MMA

                                        // When tractor rolls to the right, it should show positive angle
  #define IsRollToRightNotPositive 0    // Set to 0 if angle is positive
                                        // Set to 1 if roll to right shows negative
  
                                        //using the dogs or not
  #define IsUsingDogs2 1                //set to 0 if using MMA
                                        //set to 1 if using DOGS2
                                  
  //##########################################################################################################
  //### End of Setup Zone ####################################################################################
  //##########################################################################################################

  //instance of inclinometer 0x2A
  MMA8452Q MMA;

  //instance of A/D convertor 0x48
  Adafruit_ADS1115 ads;
  
  #define DIR_PIN  4  //PD4
  #define PWM_PIN  3  //PD3  
  
  #define WORKSW_PIN 7  //PD7
  #define STEERSW_PIN 6 //PD6
  #define REMOTE_PIN 8  //PB0
  
  //ethercard 10,11,12,13   
  
  //loop time variables in microseconds
  const unsigned int LOOP_TIME = 100; //10hz
  unsigned int lastTime = LOOP_TIME;
  unsigned int currentTime = LOOP_TIME;
  unsigned int dT = 50000;
  unsigned int count = 0;
  byte watchdogTimer = 0;
  byte serialResetTimer = 0; //if serial buffer is getting full, empty it

  //Kalman variables
  float rollK = 0, Pc = 0.0, G = 0.0, P = 1.0, Xp = 0.0, Zp = 0.0;
  float XeRoll = 0;
  const float varRoll = 0.5; // variance,
  const float varProcess = 0.001; //smaller is more filtering

   //program flow
  float rollDogs = 0;
  bool isDataFound = false, isSettingFound = false;
  int header = 0, tempHeader = 0, temp;

  byte relay = 0, uTurn = 0, gpsSpeed = 0, remoteSwitch = 0, workSwitch = 0, steerSwitch = 1, switchByte = 0;
  float distanceFromLine = 0, corr = 0;

  //steering variables
  float steerAngleActual = 0;
  float steerAngleSetPoint = 0; //the desired angle from AgOpen
  long steeringPosition = 0;
  int steeringPositionZero = 1660; //from steering sensor
  float steerAngleError = 0; //setpoint - actual
  float distanceError = 0; //
  float steerSensorCounts = 32;

  //pwm variables
  int pwmDrive = 0, pwmDisplay = 0;
  float pValue = 0, iValue = 0, dValue = 0;
  byte minPWMValue = 10;

  //PID variables
  float Ko = 0.0f;  //overall gain
  float Kp = 0.0f;  //proportional gain
  float Ki = 0.0f;//integral gain
  float Kd = 0.0f;  //derivative gain
  
  //integral values - **** change as required *****
  float   maxIntErr = 200; //anti windup max
  float maxIntegralValue = 20; //max PWM value for integral PID component

void setup()
{
  //keep pulled high and drag low to activate, noise free safe    
  pinMode(WORKSW_PIN, INPUT_PULLUP); 
  pinMode(STEERSW_PIN, INPUT_PULLUP); 
	pinMode(REMOTE_PIN, INPUT_PULLUP); 
	pinMode(DIR_PIN, OUTPUT); //D4 PD4

	//set up communication
	Wire.begin();
	Serial.begin(38400);

  // MMA8452 Inclinometer      
  if (!MMA.init()) 
    Serial.println("MMA init fails!!");
    
  //ads.setGain(GAIN_ONE);
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


    if (IsUsingDogs2)
    {
      rollK = ((ads.readADC_SingleEnded(2))); // 24,000 to 2700
      rollK = (rollK - 13300)/28;
      if (IsRollToRightNotPositive) rollK *= -1.0;
    }
    else
    {
  		//inclinometer
      if (MMA.available()) //is there data available
      {      
        MMA.read(); // Reads only "x and y" accel
      }    
      
      //if is set to 1 //get the roll from MMA - value from 0 to 1
      if (UseMMA_Y_Axis) rollK = MMA.cy * 90 * 16; //UseMMa_Y_Axis is set to 1
      else rollK = MMA.cx * 90 * 16; 
      //if not positive when rolling to the right
      if (IsRollToRightNotPositive) rollK *= -1.0;
    }
    
		//Kalman filter
		Pc = P + varProcess;
		G = Pc / (Pc + varRoll);
		P = (1 - G) * Pc;
		Xp = XeRoll;
		Zp = Xp;
		XeRoll = G * (rollK - Zp) + Xp;

    //read all the switches
    workSwitch = digitalRead(WORKSW_PIN);  // read work switch
    steerSwitch = digitalRead(STEERSW_PIN); //read auto steer enable switch open = 0n closed = Off
    remoteSwitch = digitalRead(REMOTE_PIN); //read auto steer enable switch open = 0n closed = Off
    switchByte = 0;
    switchByte |= (remoteSwitch << 2); //put remote in bit 2
    switchByte |= (steerSwitch << 1);   //put steerswitch status in bit 1 position
    switchByte |= workSwitch;

    //steering position and steer angle   
    steeringPosition = ads.readADC_SingleEnded(0);    //ADS1115 Differential Mode 
    steeringPosition = (steeringPosition >> 3); //bit shift by 3  0 to 3320 is 0 to 5v
    
    steeringPosition = (steeringPosition - steeringPositionZero - (XeRoll * Kd/10 ) );   //read the steering position sensor
    if (SteeringRightIsNotPositive) steeringPosition *= -1.0;

    /*
    //close enough to center, remove any integral correction
    if (distanceFromLine <= 40 && distanceFromLine >= -40) corr = 0;
    else
    {
      //use the integal value to adjust how much per cycle it increases
      corr +=Ki;

      //provide a limit - the old max integral value
      if (corr > maxIntegralValue) corr = maxIntegralValue;

      //now add the correction to fool steering position
      if (distanceFromLine > 40) 
      {
        steerAngleSetPoint -= corr;
      }
      else
      {
        steerAngleSetPoint += corr;
      }
    }
    */
    
		//convert position to steer angle.
		steerAngleActual = (steeringPosition) / steerSensorCounts;

    //normal autosteer all ready to go
		if (watchdogTimer < 10)
		{
			steerAngleError = steerAngleActual - steerAngleSetPoint;   //calculate the steering error
			calcSteeringPID();  //do the pid
			motorDrive();       //out to motors the pwm value		
		}
		else
		{
			//we've lost the comm to AgOpenGPS
			pwmDrive = 0; //turn off steering motor
			motorDrive(); //out to motors the pwm value
		}

		//Send to agopenGPS **** you must send 5 numbers ****
		Serial.print(steerAngleActual * 100); //The actual steering angle in degrees times 100
		Serial.print(",");

		// *******  steer angle setpoint
    Serial.print(steerAngleSetPoint * 100); //setpoint in degrees * 100
		Serial.print(",");

    //heading 
    Serial.print(rollDogs);
    Serial.print(",");

		//*******  if no roll is installed, send 9999
		//Serial.print(9999);
		Serial.print((int)XeRoll); //roll in degrees * 16
		Serial.print(",");

    Serial.println(switchByte); //steering switch status
    
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

		//distance from the guidance line in mm
		distanceFromLine = (float)(Serial.read() << 8 | Serial.read());   //high,low bytes

		//set point steer angle * 10 is sent
		steerAngleSetPoint = ((float)(Serial.read() << 8 | Serial.read()))*0.01; //high low bytes

		//auto Steer is off if 32020,Speed is too slow, motor pos or footswitch open
		if (distanceFromLine == 32020 | gpsSpeed < 1 | steerSwitch == 1)
		{
			watchdogTimer = 12;//turn off steering motor
		}
		else          //valid conditions to turn on autosteer
		{
			watchdogTimer = 0;  //reset watchdog
			serialResetTimer = 0; //if serial buffer is getting full, empty it
		}

    //uturn byte read in
    uTurn = Serial.read();
	}

	//Settings Header has been found, 8 bytes are the settings
	if (Serial.available() > 7 && isSettingFound)
	{
		isSettingFound = false;  //reset the flag

		//change the factors as required for your own PID values
	  Kp = (float)Serial.read() * 1.0;      // read Kp from AgOpenGPS
		Ki = (float)Serial.read() * 1.0;    // read Ki from AgOpenGPS
		Kd = (float)Serial.read() * 1.0;      // read Kd from AgOpenGPS
		Ko = (float)Serial.read() * 0.1;      // read Ko from AgOpenGPS
   
		steeringPositionZero =  1530 + Serial.read();  //read steering zero offset
    
    minPWMValue = Serial.read();                 //read the minimum amount of PWM for instant on
    
		maxIntegralValue = Serial.read()*0.1;   //
		steerSensorCounts = Serial.read();      //
	}
}

