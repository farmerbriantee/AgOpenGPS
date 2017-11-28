  #include "BNO055_AOG.h"
  #include <Wire.h>
<<<<<<< HEAD
  #include<EEPROM.h>
=======
>>>>>>> 962d2153957fa8c06889550c91f1d79b5a141105
  
  #define A 0X28  //I2C address selection pin LOW
  #define B 0x29  //                        HIGH
  #define RAD2GRAD 57.2957795
<<<<<<< HEAD

  #define HYDRAULIC_STEER   //Uncomment this line if you want to use Hydraulic steering

  
  
  #define LED_PIN 13   
   
=======
  
  #define LED_PIN 13   
  #define   DIR_PIN    12  //PB4
  #define   PWM_PIN    11  //PB3  
>>>>>>> 962d2153957fa8c06889550c91f1d79b5a141105
  #define WORKSW_PIN 4  //PD4
  #define STEERSW_PIN 10 //PB2

  #ifdef HYDRAULIC_STEER
  #define PWM_LEFT    10  //PB4
  #define PWM_RIGHT    11  //PB3
  #define AUTOSTEER_ENABLE 2
  #define AUTOSTEER_LED 3
  #else
  #define DIR_PIN    12  //PB4
  #define PWM_PIN    11  //PB3 
  #endif
  
  #define RELAY1_PIN 5  //PD5
  #define RELAY2_PIN 6  //PD6
  #define RELAY3_PIN 7  //PD7
  #define RELAY4_PIN 8  //PB0
  #define RELAY5_PIN 9  //PB1
<<<<<<< HEAD

  struct Storage {
    float Kp;
    float Ki;
    float Kd;
    float Ko;
    float steeringPositionZero;
    byte minPWMValue;
    int maxIntegralValue;
    float steerSensorCounts;
  };

  Storage steerSettings;
  
  //instance of the imu
   BNO055 IMU(A);

  //loop time variables in microseconds
  const unsigned int LOOP_TIME = 100; //100hz 
  unsigned int lastTime = LOOP_TIME;
  unsigned int currentTime = LOOP_TIME;
  unsigned int dT = 50000;
  unsigned int count = 0;
  unsigned int watchdogTimer = 0;

=======
   
  //instance of the imu
   BNO055 IMU(A);

  //loop time variables in microseconds
  const unsigned int LOOP_TIME = 100; //100hz 
  unsigned int lastTime = LOOP_TIME;
  unsigned int currentTime = LOOP_TIME;
  unsigned int dT = 50000;
  unsigned int count = 0;
  unsigned int watchdogTimer = 0;

>>>>>>> 962d2153957fa8c06889550c91f1d79b5a141105
  //Kalman variables
  float rollK = 0;
  float Pc = 0.0;
  float G = 0.0;
  float P = 1.0;
  float Xp = 0.0;
  float Zp = 0.0;
  float XeRoll = 0;
  const float varRoll = 0.1; // variance, smaller, more filtering
  const float varProcess = 0.002;
  
   //program flow
  bool isDataFound = false, isSettingFound = false;
  int header = 0, tempHeader = 0, temp;

  byte relay = 0, speeed = 0, workSwitch = 0, steerSwitch = 1, switchByte = 0;
  float distanceFromLine = 0; // not used
  

  //steering variables
  float steerAngleActual = 0;
  int steerPrevSign = 0, steerCurrentSign = 0; // the steering wheels angle currently and previous one
  float steerAngleSetPoint = 0; //the desired angle from AgOpen
  int steeringPosition = 0; //from steering sensor
  float steerAngleError = 0; //setpoint - actual

  //inclinometer variables
  int roll = 0;

  //pwm variables
  int pwmDrive = 0, drive = 0, pwmDisplay = 0;
  float pValue = 0, iValue = 0, dValue = 0;
  

  //integral values - **** change as required *****
  int   maxIntErr = 200; //anti windup max
  int maxIntegralValue = 20; //max PWM value for integral PID component 

  //error values
  float lastError = 0, lastLastError = 0, integrated_error = 0, dError = 0;

  #ifdef HYDRAULIC_STEER
  volatile bool steerEnable = false;
  #endif

void setup()
{

  pinMode(LED_PIN, OUTPUT); //configure LED for output
  pinMode(RELAY1_PIN, OUTPUT); //configure RELAY1 for output //Pin 5
  pinMode(RELAY2_PIN, OUTPUT); //configure RELAY2 for output //Pin 6
  pinMode(RELAY3_PIN, OUTPUT); //configure RELAY3 for output //Pin 7
  pinMode(RELAY4_PIN, OUTPUT); //configure RELAY4 for output //Pin 8
  pinMode(RELAY5_PIN, OUTPUT); //configure RELAY5 for output //Pin 9
  //pinMode(RELAY6_PIN, OUTPUT); //configure RELAY6 for output //Pin 10
  //pinMode(RELAY7_PIN, OUTPUT); //configure RELAY7 for output //Pin A4
  //pinMode(RELAY8_PIN, OUTPUT); //configure RELAY8 for output //Pin A5

  #ifdef HYDRAULIC_STEER
  pinMode(AUTOSTEER_ENABLE, INPUT_PULLUP);
  analogWrite(PWM_LEFT, 0);
  analogWrite(PWM_RIGHT, 0);
  attachInterrupt(digitalPinToInterrupt(AUTOSTEER_ENABLE), toggle, FALLING);
  analogWrite(AUTOSTEER_LED, 0);
  #else
  pinMode(DIR_PIN, OUTPUT); //D11 PB3 direction pin of PWM Board
  pinMode(STEERSW_PIN, INPUT_PULLUP);  //Pin 10 PB2
  #endif

  EEPROM.get(0, steerSettings);

  //keep pulled high and drag low to activate, noise free safe    
  pinMode(WORKSW_PIN, INPUT_PULLUP);   //Pin D4 PD4
<<<<<<< HEAD
=======
  pinMode(STEERSW_PIN, INPUT_PULLUP);  //Pin 10 PB2
>>>>>>> 962d2153957fa8c06889550c91f1d79b5a141105

  //set up communication  
  Wire.begin();
  Serial.begin(38400);
  IMU.init();

  // Restore calibration data from zeroing
  bno055_offsets_t calibrationData;
  
  calibrationData.accel_offset_x = 65506;
  calibrationData.accel_offset_y = 65438;
  calibrationData.accel_offset_z = 5;
  calibrationData.gyro_offset_x = 65534;
  calibrationData.gyro_offset_y = 65533;
  calibrationData.gyro_offset_z = 1;
  calibrationData.mag_offset_x = 65350;
  calibrationData.mag_offset_y = 19;
  calibrationData.mag_offset_z = 27;
  calibrationData.accel_radius = 1000;
  calibrationData.mag_radius = 968;
  
  IMU.setSensorOffsets(calibrationData);

  //use external 32K crystal
  IMU.setExtCrystalUse(true);    
    
  //PWM rate settings Adjust to desired PWM Rate
  //TCCR1B = TCCR1B & B11111000 | B00000010;    // set timer 1 divisor to     8 for PWM frequency of  3921.16 Hz
  TCCR1B = TCCR1B & B11111000 | B00000011;    // set timer 1 divisor to    64 for PWM frequency of   490.20 Hz (The DEFAULT)
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

    IMU.readIMU();

    // kalman SINGLE VARIABLE process
    rollK = IMU.euler.roll; 

   //inclinometer
    delay(1);
    analogRead(A1); //discard
    delay(1);
    roll = analogRead(A1);   delay(1);
    roll += analogRead(A1);   delay(1);
    roll += analogRead(A1);   delay(1);
    roll += analogRead(A1);
    roll = roll >> 2; //divide by 4
    
    //inclinometer goes from -25 to 25 from 0 volts to 5 volts
    rollK = map(roll,0,1023,-500,500); //20 counts per degree * 16.0 
    rollK *= 0.8;
     
     //Kalman filter
    Pc = P + varProcess;
    G = Pc / (Pc + varRoll);
    P = (1 - G) * Pc;
    Xp = XeRoll;
    Zp = Xp;
    XeRoll = G * (rollK - Zp) + Xp;

    workSwitch = digitalRead(WORKSW_PIN);  // read work switch

    #ifndef HYDRAULIC_STEER
    steerSwitch = digitalRead(STEERSW_PIN); //read auto steer enable switch open = 0n closed = Off
<<<<<<< HEAD
    #else
    steerSwitch = (int)steerEnable;
    #endif

=======
>>>>>>> 962d2153957fa8c06889550c91f1d79b5a141105
    steerSwitch << 1; //put steerswitch status in bit 1 position
    switchByte = workSwitch+steerSwitch;
    
    //SetRelays(); //turn on off sections
       
    //steering position and steer angle
    analogRead(A0); //discard initial reading
    steeringPosition = analogRead(A0);    delay(1);
    steeringPosition += analogRead(A0);    delay(1);
    steeringPosition += analogRead(A0);    delay(1);
    steeringPosition += analogRead(A0);    delay(1);
    steeringPosition = steeringPosition >> 2; //divide by 4    
<<<<<<< HEAD
    steeringPosition = ( steeringPosition - steerSettings.steeringPositionZero + XeRoll/16.0);   //read the steering position sensor
=======
    steeringPosition = ( steeringPosition - steeringPositionZero + XeRoll/16.0);   //read the steering position sensor
>>>>>>> 962d2153957fa8c06889550c91f1d79b5a141105
    
    //convert position to steer angle. 6 counts per degree of steer pot position in my case
    //  ***** make sure that negative steer angle makes a left turn and positive value is a right turn *****
    // remove or add the minus for steerSensorCounts to do that.
<<<<<<< HEAD
    steerAngleActual = (float)(steeringPosition)/-steerSettings.steerSensorCounts;    
=======
    steerAngleActual = (float)(steeringPosition)/-steerSensorCounts;    
>>>>>>> 962d2153957fa8c06889550c91f1d79b5a141105
           
    if (watchdogTimer < 5)
    {
      steerAngleError = steerAngleActual - steerAngleSetPoint;   //calculate the steering error 
      calcSteeringPID();  //do the pid                                                                                                           
      motorDrive();       //out to motors the pwm value
    }
    else
    {      
      pwmDrive = 0; //turn off steering motor
<<<<<<< HEAD
      motorDrive(); //out to motors the pwm value
      #ifdef HYDRAULIC_STEER
      steerEnable = false;         
      #endif
=======
      motorDrive(); //out to motors the pwm value         
>>>>>>> 962d2153957fa8c06889550c91f1d79b5a141105
    }

    //If connection lost to AgOpenGPS, the watchdog will count up and turn off steering
    watchdogTimer++; 
    
    //Send to agopenGPS **** you must send 5 numbers ****
    Serial.print(steerAngleActual); //The actual steering angle in degrees
    Serial.print(",");    
    Serial.print(pwmDisplay);   //the pwm value to solenoids or motor
    Serial.print(",");

    // *******  if there is no gyro installed send 9999
    Serial.print(9999); //heading in degrees * 16
    //Serial.print(IMU.euler.head); //heading in degrees * 16
    Serial.print(",");

    //*******  if no roll is installed, send 9999
    Serial.print(9999); //roll in degrees * 16
    //Serial.print((int)XeRoll); //roll in degrees * 16
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
      if (header == 32766) isDataFound = true;     //Do we have a match? 
      if (header == 32764) isSettingFound = true;     //Do we have a match? 
    }
    
    //Data Header has been found, so the next 6 bytes are the data
    if (Serial.available()> 5 && isDataFound)
    {  
      isDataFound = false;    
      relay = Serial.read();   // read relay control from AgOpenGPS     
      speeed = Serial.read()>>2;  //actual speed times 4, single byte
  
      //distance from the guidance line in mm
      distanceFromLine = (float)(Serial.read() << 8 | Serial.read());   //high,low bytes     
  
      //set point steer angle * 10 is sent
      steerAngleSetPoint = ((float)(Serial.read() << 8 | Serial.read())/10.0); //high low bytes 
  
      //auto Steer is off if 32020,Speed is too slow, motor pos or footswitch open
<<<<<<< HEAD
      #ifdef HYDRAULIC_STEER
      if (distanceFromLine == 32020 | speeed < 1 | steerEnable == false )
      #else
      if (distanceFromLine == 32020 | speeed < 1 | steerSwitch == 1 )  
      #endif
=======
      if (distanceFromLine == 32020 | speeed < 1 | steerSwitch == 1 )  
>>>>>>> 962d2153957fa8c06889550c91f1d79b5a141105
      {      
        watchdogTimer = 100;//turn off steering motor
      }    
      else          //valid conditions to turn on autosteer
      {
        bitSet(PINB, 5);   //turn LED on   
        watchdogTimer = 0;  //reset watchdog
      } 
    }  
  
    //Settings Header has been found, 8 bytes are the settings
    if (Serial.available() > 7 && isSettingFound)
    {        
      isSettingFound = false;  //reset the flag
  
      //change the factors as required for your own PID values
<<<<<<< HEAD
      steerSettings.Kp = (float)Serial.read() * 1.0;   // read Kp from AgOpenGPS
      steerSettings.Ki = (float)Serial.read() * 0.1;   // read Ki from AgOpenGPS
      steerSettings.Kd = (float)Serial.read() * 1.0;   // read Kd from AgOpenGPS
      steerSettings.Ko = (float)Serial.read() * 0.1;   // read Ko from AgOpenGPS
      steerSettings.steeringPositionZero = 412 + Serial.read();  //read steering zero offset
      steerSettings.minPWMValue = Serial.read(); //read the minimum amount of PWM for instant on
      steerSettings.maxIntegralValue = Serial.read(); //
      steerSettings.steerSensorCounts = Serial.read(); //
      EEPROM.put(0, steerSettings);
=======
      Kp = (float)Serial.read() * 1.0;   // read Kp from AgOpenGPS
      Ki = (float)Serial.read() * 0.1;   // read Ki from AgOpenGPS
      Kd = (float)Serial.read() * 1.0;   // read Kd from AgOpenGPS
      Ko = (float)Serial.read() * 0.1;   // read Ko from AgOpenGPS
      steeringPositionZero = 412 + Serial.read();  //read steering zero offset
      minPWMValue = Serial.read(); //read the minimum amount of PWM for instant on
      maxIntegralValue = Serial.read(); //
      steerSensorCounts = Serial.read(); //
>>>>>>> 962d2153957fa8c06889550c91f1d79b5a141105
    }
}
#ifdef AUTOSTEER_ENABLE
  void toggle(){
  static unsigned long last_interrupt_time = 0;
 unsigned long interrupt_time = millis();
 // If interrupts come faster than 200ms, assume it's a bounce and ignore
 if (interrupt_time - last_interrupt_time > 200) 
 {
  steerEnable = !steerEnable;
 }
 last_interrupt_time = interrupt_time;
}
#endif


