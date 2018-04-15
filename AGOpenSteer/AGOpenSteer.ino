  #include "BNO055_AOG.h"
  #include <ISOBUS.h> // 1. Download: https://github.com/pvanhaperen/ISOBUS/archive/master.zip      2. From Arduino Ide Menu:  Sketch > Include Library > Add .ZIP Library
  #include <Wire.h>
  #include <SPI.h>
  #include <Stepper.h>

// Constants
  #define PRESCALER 8 // As (64/devisor)
  #define RAD2GRAD 57.2957795
  #define MAXAMP1CW  50 //0.13v~1A  0-5v=0-1023
  #define MAXAMP1CWW 50 //0.13v~1A  0-5v=0-1023
  #define MAXAMP2CW  50 //0.13v~1A  0-5v=0-1023
  #define MAXAMP2CCW 50 //0.13v~1A  0-5v=0-1023

// Set i2c address of section, uturn and switch port expanders
  #define RELAY_ADDRESS 0x20
  #define RELAYU_ADDRESS 0x21
  #define SWITCH_ADDRESS 0x22

// 9DOF IMU installed   
  #define DOF9 0  
  // Instance of the IMU, 0X28=address selection LOW  0X29=address selection HIGH
    BNO055 IMU(0x28);
   
// Inclinometer installed   
  #define INCLINO 0
  
// CANBUS installed   
  #define CANBUS 0
  // Instance of ISOBUS
    ISOBUSMessage receiveMessage;

// SteerSensor type (ANALOG, PULSE, QUADRATURE CANBUS)
  #define ANALOG 1
  #define QUADRATURE 0
    #define ENCCOUNT 1024
      #define ENCINDEX 0  //IndexPulse, zero's steeringangle if present (workswitch will be read form i2c)
      #define ENCOFFSET 212 // Zero Offset
  #define ISOBUSANGLE 0
    #define ANGLE_PGN 61451 // NOT CONFRIMED
    #define ANGLE_SPN 2927  // NOT CONFRIMED

// SteerWheel type
  #define PULSE  1
    #define pulseCountMax  300 //Switch off Autosteer after 300 Pulses from Steering wheel encoder  
  
// Steermotor type (DC, STEPPER, VALVE, CANBUS)
  #define DC  1
  #define DCDUAL  0
  #define STEPPER 0
    #define STEPS 200   // amount of stepper steps
  #define VALVE 0       // Used with 2-Coil PWM Valves
  #define DANFOSS 0     // Used with danfoss valves
  #define CANBUSSTEER 0

// Loop time variables in microseconds
  const unsigned int LOOP_TIME = 100*PRESCALER; //100hz
  unsigned int lastTime = LOOP_TIME;
  unsigned int currentTime = LOOP_TIME;
  unsigned int dT = 50000;
  unsigned int count = 0;
  byte watchdogTimer = 0;
  byte serialResetTimer = 0; //if serial buffer is getting full, empty it

// Kalman variables
  float rollK = 0;
  float Pc = 0.0;
  float G = 0.0;
  float P = 1.0;
  float Xp = 0.0;
  float Zp = 0.0;
  float XeRoll = 0;
  const float varRoll = 0.1; // variance, smaller, more filtering
  const float varProcess = 0.00025; //works good for 10 hz
  
// Program flow
  bool isDataFound = false, isSettingFound = false;
  int header = 0, tempHeader = 0, temp;
  bool steerEnable = 0;
  volatile bool overCurrent = 0;
  byte relay = 0, uTurn = 0, speeed = 0, workSwitch = 0, steerSwitch = 1, switchByte = 0;
  float distanceFromLine = 0; // not used
  float olddist=0;

// Steering variables
  float steerAngleActual = 0;
  int steerPrevSign = 0, steerCurrentSign = 0; // the steering wheels angle currently and previous one
  float steerAngleSetPoint = 0; //the desired angle from AgOpen
  int steeringPosition = 0, steeringPositionZero = 512; //from steering sensor
  float steerAngleError = 0; //setpoint - actual
  float distanceError = 0; //
  float steerSensorCounts = 4;
  volatile int pulseCount = 0; // Steering Wheel Encoder
  volatile int encCount = 0; // Steering Angle Encoder
  volatile bool encZero = 0; // Steering Angle Referenced 


// Inclinometer variables
  int roll = 0;

// Pwm variables
  int pwmDrive = 0, drive = 0, pwmDisplay = 0;
  float pValue = 0, iValue = 0, dValue = 0;
  byte minPWMValue = 10;
 
// PID variables
  float Ko = 0.0f;  //overall gain
  float Kp = 0.0f;  //proportional gain
  float Ki = 0.0f;  //integral gain
  float Kd = 0.0f;  //derivative gain 

// Integral values - **** change as required *****
  int maxIntErr = 200; //anti windup max
  int maxIntegralValue = 20; //max PWM value for integral PID component 

// Error values
  float lastError = 0, lastLastError = 0, integrated_error = 0, dError = 0;
  
//ISOBUS values
  char spn_buffer[512];  //Data will be temporarily stored to this buffer before being written to the filechar buffer[512];

void setup()
{
  // Set prescaler for timer0 PWM frequency , changing this also effects delay() and millis() function. DEFINE CORRECT PRESCALER ALSO!!!!
  
  //TCCR0B = TCCR0B & B11111000 | B00000001;    // set timer 0 divisor to     1 for PWM frequency of 62500.00 Hz
  TCCR0B = TCCR0B & B11111000 | B00000010;    // set timer 0 divisor to     8 for PWM frequency of  7812.50 Hz   (Better PWM Freq for cooler motordriver)
  //TCCR0B = TCCR0B & B11111000 | B00000011;    // set timer 0 divisor to    64 for PWM frequency of   976.56 Hz (The DEFAULT)
  //TCCR0B = TCCR0B & B11111000 | B00000100;    // set timer 0 divisor to   256 for PWM frequency of   244.14 Hz
  //TCCR0B = TCCR0B & B11111000 | B00000101;    // set timer 0 divisor to  1024 for PWM frequency of    61.04 Hz

  //Pulled high inputs 
  if(ANALOG) {
  pinMode(A0, INPUT_PULLUP); //A0 Drag pot wiper high (also allows use of 2 wire pot)
  }
  pinMode(A1, INPUT_PULLUP);  //A1 Autosteer Switch (Also motors enabled)
    
  //Set outputs
  pinMode(4, OUTPUT); //D4 Motor 2 Clockwise
  pinMode(5, OUTPUT); //D5 Motor 1 PWM 
  pinMode(6, OUTPUT); //D6 Motor 2 PWM
  pinMode(7, OUTPUT); //D7 Motor 1 Clockwise
  pinMode(8, OUTPUT); //D8 Motor 1 Counter Clockwise
  pinMode(9, OUTPUT); //D9 Motor 2 Counter Clockwise

  // Set encoder interupts
  
  if(QUADRATURE) {
    attachInterrupt(digitalPinToInterrupt(2), QuadratureISR, CHANGE);
  }
  if(PULSE) {
    attachInterrupt(digitalPinToInterrupt(3), PulseEncoderISR, RISING);
  }
    
    
 //Set up communication 
  Serial.begin(38400);
  Wire.begin();
 
  
  //Check for IMU
  if(DOF9) 
  {
    IMU.init();
      // Restore calibration data from zeroing
      bno055_offsets_t calibrationData;
      
      calibrationData.accel_offset_x = 65520;
      calibrationData.accel_offset_y = 65421;
      calibrationData.accel_offset_z = 65421;
      calibrationData.gyro_offset_x = 65534;
      calibrationData.gyro_offset_y = 65533;
      calibrationData.gyro_offset_z = 1;
      calibrationData.mag_offset_x = 65305;
      calibrationData.mag_offset_y = 119;
      calibrationData.mag_offset_z = 65418;
      calibrationData.accel_radius = 1000;
      calibrationData.mag_radius = 979;
      
      IMU.setSensorOffsets(calibrationData);
    
      //use external 32K crystal
      IMU.setExtCrystalUse(true);  
    }  
  if(CANBUS) //Check for CANBUS
  {
    ISOBUS.begin(CAN_SPEED_250000);
    ISOBUS.setMode (CAN_MODE_NORMAL);
    }

} 

void loop()
{
  /*
   * Loop triggers every 100 msec and sends back gyro heading, and roll, steer angle etc
   * All imu code goes in the loop
   *  Determine the header value and set the flag accordingly
   *  Then the next group of serial data is according to the flag
   *  Process accordingly updating values
   */
 
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
      while(Serial.available() > 0) char t = Serial.read();
      serialResetTimer = 0;
    }
    
  if(DOF9) //check for IMU Option
    {
      IMU.readIMU();
      // kalman SINGLE VARIABLE process
      rollK = IMU.euler.roll; 
    } 
  if(INCLINO) //check for Inclinometer Option
      {
       //inclinometer
        delay(1);
        analogRead(A7); //discard
        delay(1);
        roll = analogRead(A7);   delay(4*PRESCALER);
        roll += analogRead(A7);   delay(4*PRESCALER);
        roll += analogRead(A7);   delay(4*PRESCALER);
        roll += analogRead(A7);   delay(4*PRESCALER);
        roll = roll >> 2; //divide by 4
        
        //inclinometer goes from -25 to 25 from 0 volts to 5 volts
        rollK = map(roll,0,1023,-500,500); //20 counts per degree * 16.0 
        rollK *= 0.8;
      }
    if(DOF9 | INCLINO){
        //Kalman filter
        Pc = P + varProcess;
        G = Pc / (Pc + varRoll);
        P = (1 - G) * Pc;
        Xp = XeRoll;
        Zp = Xp;
        XeRoll = G * (rollK - Zp) + Xp;
      }
  

    GetSwitches(); //Get the switch inputs
    
    SetRelays(); //Set the section relays
    SetRelaysU(); //Set the uturn relays
        
    GetSteeringAngle(); //Get the steeringangle

    if (watchdogTimer < 10){
      steerAngleError = steerAngleActual - steerAngleSetPoint;   //calculate the steering error 
      CalcSteeringPID();          //do the pid                                                                                                           
      DriveSteeringAngle();       //out to motors the pwm value
    }
    else{
      //we've lost the comm to AgOpenGPS      
      pwmDrive = 0;         //turn off steering motor
      DriveSteeringAngle(); //out to motors the pwm value         
    }
        
    //Send to agopenGPS **** you must send 5 numbers ****
    Serial.print(steerAngleActual); //The actual steering angle in degrees
    Serial.print(",");    
    Serial.print(pwmDisplay);   //the pwm value to solenoids or motor
    Serial.print(",");

    // *******  if there is no IMU installed send 9999
    if(DOF9){ //check for IMU
        Serial.print(IMU.euler.head); //heading in degrees * 16
      }
    else
      {
        Serial.print(9999);
      }
    Serial.print(",");
      
    //*******  if no roll is installed, send 9999
    if(INCLINO)
      {
      //Serial.print((9999); //roll in degrees * 16
      Serial.print((int)XeRoll); //roll in degrees * 16
      }
    else
    {
      Serial.print(9999);
    }
    
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
      header = tempHeader << 8 | temp;               //high,low bytes to make int
      tempHeader = temp;                             //save for next time
      if (header == 32766) isDataFound = true;       //Do we have a match? 
      if (header == 32764) isSettingFound = true;    //Do we have a match? 
    }
    
    //Data Header has been found, so the next 6 bytes are the data
    if (Serial.available()>6 && isDataFound)
    {  
      isDataFound = false;    
      relay = Serial.read();   // read relay control from AgOpenGPS     
      speeed = Serial.read()>>2;  //actual speed times 4, single byte
  
      //distance from the guidance line in mm
      distanceFromLine = (float)(Serial.read() << 8 | Serial.read());   //high,low bytes     
  
      //set point steer angle * 10 is sent
      steerAngleSetPoint = ((float)(Serial.read() << 8 | Serial.read()))*0.01; //high low bytes 

      uTurn = Serial.read();
  
     //auto Steer is off if 32020,Speed is too slow, Wheelencoder above Max
      if (distanceFromLine == 32020 | speeed < 1 | pulseCount >= pulseCountMax | overCurrent)
      {  
        steerEnable = false;
        watchdogTimer = 12;       //turn off steering motor
      }
  
      else                        //valid conditions to turn on autosteer
      { if (olddist == 32020) steerEnable = true; // Take over AOG State on startup
         

        if (steerEnable == true) 
           {
            watchdogTimer = 0;    //reset watchdog
            serialResetTimer = 0; //if serial buffer is getting full, empty it
           }
        else 
           {
            watchdogTimer = 12;   //turn off steering motor
           }
      } 
    }  
  
    //Settings Header has been found, 8 bytes are the settings
    if (Serial.available() > 7 && isSettingFound)
    {        
      isSettingFound = false;  //reset the flag
  
      //change the factors as required for your own PID values
      Kp = (float)Serial.read() * 1.0;   // read Kp from AgOpenGPS
      Ki = (float)Serial.read() * 0.1;   // read Ki from AgOpenGPS
      Kd = (float)Serial.read() * 1.0;   // read Kd from AgOpenGPS
      Ko = (float)Serial.read() * 0.1;   // read Ko from AgOpenGPS
      steeringPositionZero = 412 + Serial.read();  //read steering zero offset
      minPWMValue = Serial.read(); //read the minimum amount of PWM for instant on
      maxIntegralValue = Serial.read(); //
      steerSensorCounts = Serial.read(); //sent as 10 times the setting displayed in AOG
    }

    //Check Currentlimit
    if(analogRead(A2) > MAXAMP1CW | analogRead(A3) > MAXAMP2CW) {
      overCurrent = 1;
    }
    
    // Get steering angle from CANBUS.
    if(ISOBUSANGLE) { 
     if (ISOBUS.available() ) {
      receiveMessage = ISOBUS.getMessageISOBUS(ANGLE_PGN, ANGLE_SPN, spn_buffer);
        if (receiveMessage.status == 0)
        {
           steerAngleActual=(float)receiveMessage.spn_data;
        }
      }
    }
   
}

void PulseEncoderISR() {       
    pulseCount++;    
}

void QuadratureISR() {// If 2 and A0 are both high or both low, direction is CW. else CWW
  if (digitalRead(2)) digitalRead(A0) ? encCount++ : encCount--;
    else digitalRead(A0) ? encCount-- : encCount++;

    
   if (ENCINDEX & !encZero){ //Not referenced
       if  ( analogRead(A6) > 512){
          encCount=ENCOFFSET; 
          encZero = 1;
       } 
    }

 
 }





