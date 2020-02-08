  ////////////////////   ***********  Motor drive connections  **************888
  //Connect ground only for cytron, Connect Ground and +5v for IBT2
  
  //Dir1 for Cytron Dir, Both L and R enable for IBT2
  #define DIR1_RL_ENABLE  4  //PD4

  //PWM1 for Cytron PWM, Left PWM for IBT2
  #define PWM1_LPWM  3  //PD3

  //Not Connected for Cytron, Right PWM for IBT2
  #define PWM2_RPWM  9 //D9

  //int0  Steering Wheel Encoder - turns Autosteer off
  #define encAPin     2   //PD2 

  //--------------------------- Switch Input Pins ------------------------
  #define STEERSW_PIN 6 //PD6
  #define WORKSW_PIN 7  //PD7
  #define REMOTE_PIN 8  //PB0

  #include <Wire.h>
  #include <EEPROM.h> 
  #include "zADS1015.h"
  Adafruit_ADS1115 ads;     // Use this for the 16-bit version ADS1115

  //GY-45 (1C)
  //installed Sparkfun, Adafruit MMA8451 (1D)   
  #include "MMA8452_AOG.h"  //MMA inclinometer
  
  MMA8452 MMA1D(0x1D);   
  MMA8452 MMA1C(0x1C);
      
  uint16_t x_ , y_ , z_;        

  #include "BNO055_AOG.h"  // BNO055 IMU
  #define A 0X28             //I2C address selection pin LOW
  #define B 0x29             //                          HIGH
  #define RAD2GRAD 57.2957795
  BNO055 IMU(A);  // create an instance
  
  #define EEP_Ident 0xEDFC  
 
  //loop time variables in microseconds  
  const unsigned int LOOP_TIME = 100;      
  unsigned long lastTime = LOOP_TIME;
  unsigned long currentTime = LOOP_TIME;
  byte watchdogTimer = 20;
  byte serialResetTimer = 100; //if serial buffer is getting full, empty it
  
  //Kalman variables
  float rollK = 0, Pc = 0.0, G = 0.0, P = 1.0, Xp = 0.0, Zp = 0.0;
  float XeRoll = 0;
  const float varRoll = 0.1; // variance,
  const float varProcess = 0.0001; //smaller is more filtering

  //inclinometer variables
  int roll = 0;
  
  //Program flow
  bool isDataFound = false, isSettingFound = false, isMachineFound=false, isAogSettingsFound = false; 
  bool MMAinitialized = false;
  int header = 0, tempHeader = 0, temp, EEread = 0;
  byte relay = 0, relayHi = 0, uTurn = 0;
  byte remoteSwitch = 0, workSwitch = 0, steerSwitch = 1, switchByte = 0;
  float distanceFromLine = 0, gpsSpeed = 0;
  
  //steering variables
  float steerAngleActual = 0;
  float steerAngleSetPoint = 0; //the desired angle from AgOpen
  long steeringPosition = 0; //from steering sensor
  float steerAngleError = 0; //setpoint - actual
  
    //pwm variables
  int pwmDrive = 0, drive = 0, pwmDisplay = 0;
  float pValue = 0;

  //Steer switch button  ***********************************************************************************************************
  byte currentState = 1;
  byte reading;
  byte previous = 0;
  byte test = 0;

  volatile int pulseCount = 0; // Steering Wheel Encoder

     //Variables for settings  
   struct Storage {
      float Ko = 0.0f;  //overall gain
      float Kp = 0.0f;  //proportional gain
      float Ki = 0.0f;  //integral gain
      float Kd = 0.0f;  //derivative gain 
      float steeringPositionZero = 1660.0;
      byte minPWMValue=10;
      int maxIntegralValue=20;//max PWM value for integral PID component
      float steerSensorCounts=30;        
  };  Storage steerSettings;  //27 bytes

    //Variables for settings - 0 is false  
   struct Setup {
      byte InvertWAS = 0;
      byte InvertRoll = 0;
      byte MotorDriveDirection = 0;
      byte SingleInputWAS = 1;
      byte CytronDriver = 1;
      byte SteerSwitch = 1;
      byte UseMMA_X_Axis = 0;
      byte ShaftEncoder = 0;
      
      byte BNOInstalled = 0;
      byte InclinometerInstalled = 0;   // set to 0 for none
                                        // set to 1 if DOGS2 Inclinometer is installed and connected to ADS pin A2
                                        // set to 2 if MMA8452 installed GY-45 (1C)
                                        // set to 3 if MMA8452 installed Sparkfun, Adafruit MMA8451 (1D)      
      byte MaxSpeed = 20;
      byte MinSpeed = 15;
      byte PulseCountMax = 5;      
  };  Setup aogSettings;   //10 bytes

void setup()
{    
  //keep pulled high and drag low to activate, noise free safe 
  pinMode(encAPin, INPUT_PULLUP);  
   
  pinMode(WORKSW_PIN, INPUT_PULLUP); 
  pinMode(STEERSW_PIN, INPUT_PULLUP); 
  pinMode(REMOTE_PIN, INPUT_PULLUP); 
  pinMode(DIR1_RL_ENABLE, OUTPUT);
  
  //set up communication
  Wire.begin();
  Serial.begin(38400);

  EEPROM.get(0, EEread);              // read identifier
    
  if (EEread != EEP_Ident)   // check on first start and write EEPROM
  {           
    EEPROM.put(0, EEP_Ident);
    EEPROM.put(2, 1660);
    EEPROM.put(10, steerSettings);   
    EEPROM.put(40, aogSettings);
  }
  else 
  { 
    EEPROM.get(2, EEread);            // read SteerPosZero
    EEPROM.get(10, steerSettings);     // read the Settings
    EEPROM.get(40, aogSettings);
  }

  // BNO055 init
  if (aogSettings.BNOInstalled) 
  { 
    IMU.init();  
    IMU.setExtCrystalUse(true);   //use external 32K crystal
  }  

  //interrupt pin
  attachInterrupt(digitalPinToInterrupt(encAPin), EncoderISR, RISING);// Hardware IRQ 0
  	
  if (aogSettings.InclinometerInstalled == 2 )
  { 
      // MMA8452 (1) Inclinometer
      MMAinitialized = MMA1C.init();
      
      if (MMAinitialized)
      {
        MMA1C.setDataRate(MMA_800hz);
        MMA1C.setRange(MMA_RANGE_8G);
        MMA1C.setHighPassFilter(false); 
      }
      //else Serial.println("MMA init fails!!");
  }
  else if (aogSettings.InclinometerInstalled == 3 )
  { 
      // MMA8452 (1) Inclinometer
      MMAinitialized = MMA1D.init();
      
      if (MMAinitialized)
      {
        MMA1D.setDataRate(MMA_800hz);
        MMA1D.setRange(MMA_RANGE_8G);
        MMA1D.setHighPassFilter(false); 
      }
      //else Serial.println("MMA init fails!!");
  }  
}// End of Setup

void loop()
{
	// Loop triggers every 100 msec and sends back gyro heading, and roll, steer angle etc	 
	currentTime = millis();
 
	if (currentTime - lastTime >= LOOP_TIME)
	{
		lastTime = currentTime;
   
    //If connection lost to AgOpenGPS, the watchdog will count up and turn off steering
    if (watchdogTimer++ > 250) watchdogTimer = 12;

    //clean out serial buffer to prevent buffer overflow
    if (serialResetTimer++ > 20)
    {
      while (Serial.available() > 0) char t = Serial.read();
      serialResetTimer = 0;
    }
    
    if (aogSettings.BNOInstalled)
        IMU.readIMU();
    
    if (aogSettings.InclinometerInstalled ==1)
    {
        //DOGS2 inclinometer
        rollK = ((ads.readADC_SingleEnded(2))); // 24,000 to 2700
        rollK = (rollK - 13300)*0.0357;
    }
    
    // MMA8452 Inclinometer (1C)           
    else if (aogSettings.InclinometerInstalled == 2)
    {
        if (MMAinitialized)
        {
          MMA1C.getRawData(&x_, &y_, &z_);

          if (aogSettings.UseMMA_X_Axis) 
              roll= x_; //Conversion uint to int
          else roll = y_;
                   
          if (roll > 4200)  roll =  4200;
          if (roll < -4200) roll = -4200;
          rollK = map(roll,-4200,4200,-960,960); //16 counts per degree (good for 0 - +/-30 degrees) 
        }
    }
    
    // MMA8452 Inclinometer (1D)        
    else if (aogSettings.InclinometerInstalled == 3)
    {
        if (MMAinitialized)
        {
          MMA1D.getRawData(&x_, &y_, &z_);

          if (aogSettings.UseMMA_X_Axis) 
              roll= x_; //Conversion uint to int
          else roll = y_;
                   
          if (roll > 4200)  roll =  4200;
          if (roll < -4200) roll = -4200;
          rollK = map(roll,-4200,4200,-960,960); //16 counts per degree (good for 0 - +/-30 degrees) 
        }
    } 
    
    //if not positive when rolling to the right
    if (aogSettings.InvertRoll)
      rollK *= -1.0;
    
    //Kalman filter
    Pc = P + varProcess;
    G = Pc / (Pc + varRoll);
    P = (1 - G) * Pc;
    Xp = XeRoll;
    Zp = Xp;
    XeRoll = G * (rollK - Zp) + Xp;

    //read all the switches
    workSwitch = digitalRead(WORKSW_PIN);  // read work switch
    
    if (aogSettings.SteerSwitch == 1) //steer switch on - off
    {
      steerSwitch = digitalRead(STEERSW_PIN); //read auto steer enable switch open = 0n closed = Off
    }
    else   //steer Button momentary
    {
      reading = digitalRead(STEERSW_PIN);      
      if (reading == LOW && previous == HIGH) 
      {
        test++;
        if (currentState == 1)
        {
          currentState = 0;
          steerSwitch = 0;
        }
        else
        {
          currentState = 1;
          steerSwitch = 1;
        }
      }      
      previous = reading;
    }
    
    if (aogSettings.ShaftEncoder && pulseCount >= aogSettings.PulseCountMax ) 
    {
      steerSwitch = 1; // from Steeringwheel encoder
      currentState = 1;
      previous = HIGH;
    }
    
    remoteSwitch = digitalRead(REMOTE_PIN); //read auto steer enable switch open = 0n closed = Off
    switchByte = 0;
    switchByte |= (remoteSwitch << 2); //put remote in bit 2
    switchByte |= (steerSwitch << 1);   //put steerswitch status in bit 1 position
    switchByte |= workSwitch;

    /*
    #if Relay_Type == 1
        SetRelays();       //turn on off section relays
    #elif Relay_Type == 2
        SetuTurnRelays();  //turn on off uTurn relays
    #endif
    */
  
    //get steering position       
    if (aogSettings.SingleInputWAS)   //Single Input ADS
    {
      steeringPosition = ads.readADC_SingleEnded(0);    //ADS1115 Single Mode 
      steeringPosition = (steeringPosition >> 3); //bit shift by 3  0 to 3320 is 0 to 5v
    }    
    else    //ADS1115 Differential Mode
    {
      steeringPosition = ads.readADC_Differential_0_1(); //ADS1115 Differential Mode
      steeringPosition = (steeringPosition >> 3); //bit shift by 3  0 to 3320 is 0 to 5v
    }
   
    //DETERMINE ACTUAL STEERING POSITION
    steeringPosition = (steeringPosition - steerSettings.steeringPositionZero);   //read the steering position sensor
          
      //convert position to steer angle. 32 counts per degree of steer pot position in my case
      //  ***** make sure that negative steer angle makes a left turn and positive value is a right turn *****
    if (aogSettings.InvertWAS)
        steerAngleActual = (float)(steeringPosition) / -steerSettings.steerSensorCounts;
    else
        steerAngleActual = (float)(steeringPosition) / steerSettings.steerSensorCounts; 
  
    if (watchdogTimer < 10)
      { 
        if (!aogSettings.CytronDriver)
          digitalWrite(DIR1_RL_ENABLE, 1); //Enable H Bridge for IBT2      
        
        steerAngleError = steerAngleActual - steerAngleSetPoint;   //calculate the steering error
        calcSteeringPID();  //do the pid
        motorDrive();       //out to motors the pwm value
      }
    else
      {
        //we've lost the comm to AgOpenGPS, or just stop request
        if (!aogSettings.CytronDriver)
          digitalWrite(DIR1_RL_ENABLE, 0); //Disable H Bridge for IBT2
        
        pwmDrive = 0; //turn off steering motor
        motorDrive(); //out to motors the pwm value
        pulseCount=0;
      }

      //Serial Send to agopenGPS **** you must send 5 numbers ****
      Serial.print((int)(steerAngleActual * 100)); //The actual steering angle in degrees
      Serial.print(",");
      Serial.print((int)(steerAngleSetPoint * 100));   //the setpoint originally sent
      Serial.print(",");
  
      // *******  if there is no gyro installed send 9999
      if (aogSettings.BNOInstalled)
        Serial.print((int)IMU.euler.head);       //heading in degrees * 16 from BNO
      else
        Serial.print(9999);                 //No IMU installed
      
      Serial.print(",");
      
      //*******  if no roll is installed, send 9999
      if (aogSettings.InclinometerInstalled)
        Serial.print((int)XeRoll);          //roll in degrees * 16
      else
        //Serial.print(9999);                 //no Dogs installed
        Serial.print(pulseCount);          //roll in degrees * 16
  
      Serial.print(","); 

      //the status of switch inputs
      Serial.println(switchByte); //steering switch status 
      Serial.flush();   // flush out buffer        
  	} //end of timed loop

      //This runs continuously, not timed //// Serial Receive Data/Settings /////////////////

  delay (10);
  
  if (Serial.available() > 0 && !isDataFound && !isSettingFound && !isMachineFound && !isAogSettingsFound) 
  {
    int temp = Serial.read();
    header = tempHeader << 8 | temp;               //high,low bytes to make int
    tempHeader = temp;                             //save for next time
    if (header == 32766) isDataFound = true;        //Do we have a match?
    if (header == 32764) isSettingFound = true;     //Do we have a match?
    if (header == 32762) isMachineFound = true;     //Do we have a match?    
    if (header == 32750) isAogSettingsFound = true;     //Do we have a match?    
  }

  //Data Header has been found, so the next 6 bytes are the data
  if (Serial.available() > 7 && isDataFound)
  {
    isDataFound = false;
    gpsSpeed = Serial.read() * 0.25;  //actual speed times 4, single byte

    //distance from the guidance line in mm
    distanceFromLine = (float)(Serial.read() << 8 | Serial.read());   //high,low bytes

    //set point steer angle * 10 is sent
    steerAngleSetPoint = ((float)(Serial.read() << 8 | Serial.read()))*0.01; //high low bytes

    //auto Steer is off if 32020,Speed is too slow, motor pos or footswitch open
    if (distanceFromLine == 32020 | gpsSpeed < aogSettings.MinSpeed | gpsSpeed > aogSettings.MaxSpeed | steerSwitch == 1)
      {
       watchdogTimer = 12; //turn off steering motor
       }
    else          //valid conditions to turn on autosteer
      {
       watchdogTimer = 0;  //reset watchdog
       serialResetTimer = 0; //if serial buffer is getting full, empty it
      }
      
    Serial.read();
    Serial.read();
    Serial.read();
  }

  //Machine Header has been found, so the next 8 bytes are the data
  if (Serial.available() > 7 && isMachineFound)
  {
    isMachineFound = false;

    relayHi = Serial.read();
    relay = Serial.read();    
    gpsSpeed = Serial.read() * 0.25;  //actual speed times 4, single byte
    uTurn = Serial.read();    
    
    Serial.read();
    Serial.read();
    Serial.read();
    Serial.read();
  }

  //ArdSettings has been found, so the next 8 bytes are the data
  if (Serial.available() > 7 && isAogSettingsFound)
  {
    isAogSettingsFound = false;
    
    byte sett = Serial.read(); //setting0
     
    if (bitRead(sett,0)) aogSettings.InvertWAS = 1; else aogSettings.InvertWAS = 0;
    if (bitRead(sett,1)) aogSettings.InvertRoll = 1; else aogSettings.InvertRoll = 0;
    if (bitRead(sett,2)) aogSettings.MotorDriveDirection = 1; else aogSettings.MotorDriveDirection = 0;
    if (bitRead(sett,3)) aogSettings.SingleInputWAS = 1; else aogSettings.SingleInputWAS = 0;
    if (bitRead(sett,4)) aogSettings.CytronDriver = 1; else aogSettings.CytronDriver = 0;
    if (bitRead(sett,5)) aogSettings.SteerSwitch = 1; else aogSettings.SteerSwitch = 0;
    if (bitRead(sett,6)) aogSettings.UseMMA_X_Axis = 1; else aogSettings.UseMMA_X_Axis = 0;
    if (bitRead(sett,7)) aogSettings.ShaftEncoder = 1; else aogSettings.ShaftEncoder = 0;
     
    sett = Serial.read();  //setting1  
    
    if (bitRead(sett,0)) aogSettings.BNOInstalled = 1; else aogSettings.BNOInstalled = 0;

    aogSettings.MaxSpeed = Serial.read();  //actual speed
    aogSettings.MinSpeed = Serial.read();    

    byte inc = Serial.read();
    aogSettings.InclinometerInstalled = inc & 192;
    aogSettings.InclinometerInstalled = aogSettings.InclinometerInstalled >> 6;
    aogSettings.PulseCountMax = inc & 63;

    Serial.read();
    Serial.read();
    
    EEPROM.put(40, aogSettings);
  }
    
  //Settings Header has been found, 8 bytes are the settings
  if (Serial.available() > 7 && isSettingFound)
  {
    isSettingFound = false;  //reset the flag
    //change the factors as required for your own PID values
    steerSettings.Kp = (float)Serial.read() * 1.0;   // read Kp from AgOpenGPS
    steerSettings.Ki = (float)Serial.read() * 0.001;   // read Ki from AgOpenGPS
    steerSettings.Kd = (float)Serial.read() * 1.0;   // read Kd from AgOpenGPS
    steerSettings.Ko = (float)Serial.read() * 0.1;   // read Ko from AgOpenGPS
    steerSettings.steeringPositionZero = 1533 + Serial.read();  //read steering zero offset
    steerSettings.minPWMValue = Serial.read(); //read the minimum amount of PWM for instant on
    steerSettings.maxIntegralValue = Serial.read()*0.1; //
    steerSettings.steerSensorCounts = Serial.read(); //sent as 10 times the setting displayed in AOG
    EEPROM.put(10, steerSettings);
  }  
} // end of main loop

//ISR Steering Wheel Encoder
  void EncoderISR()
  {        
     if (digitalRead(encAPin)==0) // decide if external triggered  
       {
         pulseCount++;
       }   
  } 
   
