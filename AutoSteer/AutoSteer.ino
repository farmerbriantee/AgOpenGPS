  #include <EEPROM.h>
  #define LED_PIN 13 


  
  #define WORKSW_PIN 4  //PD4
  //#define STEERSW_PIN 10 //PB2 Define to use steer motor
  #define AUTOSTEER_ENABLE 2 //Define to use pushbutton enable
  #define AUTOSTEER_LED 3
  #ifdef AUTOSTEER_ENABLE 
  #define   PWM_LEFT    10  //PB4
  #define   PWM_RIGHT    11  //PB3
  #endif
  #ifdef STEERSW_PIN
  #define   DIR_PIN    12  //PB4
  #define   PWM_PIN    11  //PB3
  #endif 
  
  
  #define RELAY1_PIN 5  //PD5
  #define RELAY2_PIN 6  //PD6
  #define RELAY3_PIN 7  //PD7
  #define RELAY4_PIN 8  //PB0
  #define RELAY5_PIN 9  //PB1
  //#define RELAY6_PIN 10  //PB2
  //#define RELAY7_PIN A4  //PC4
  //#define RELAY8_PIN A5  //PC5
  
  #define RAD2GRAD 57.2957795

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


  //program flow
  bool isDataFound = false, isSettingFound = false;
  int header = 0, tempHeader = 0, temp;

  byte relay = 0, workSwitch = 0, steerSwitch = 1, speeed = 0;
  float distanceFromLine = 0; // not used
  

  //steering variables
  float steerAngleActual = 0;
  int steerPrevSign = 0, steerCurrentSign = 0; // the steering wheels angle currently and previous one
  float steerAngleSetPoint = 0; //the desired angle from AgOpen
  int steeringPosition = 0; //from steering sensor
  float steerAngleError = 0; //setpoint - actual
  

  //inclinometer variables
  int tilt = 0, roll = 0;

  //pwm variables
  int pwmDrive = 0, drive = 0, pwmDisplay = 0;
  float pValue = 0, iValue = 0, dValue = 0;
  

  //integral values - **** change as required *****
  int   maxIntErr = 200; //anti windup max
  

  //error values
  float lastError = 0, lastLastError = 0, integrated_error = 0, dError = 0;
  volatile bool steerEnable = false;

void setup()
{
  //analogReference(EXTERNAL);
  pinMode(LED_PIN, OUTPUT); //configure LED for output
  pinMode(RELAY1_PIN, OUTPUT); //configure RELAY1 for output //Pin 5
  pinMode(RELAY2_PIN, OUTPUT); //configure RELAY2 for output //Pin 6
  pinMode(RELAY3_PIN, OUTPUT); //configure RELAY3 for output //Pin 7
  pinMode(RELAY4_PIN, OUTPUT); //configure RELAY4 for output //Pin 8
  pinMode(RELAY5_PIN, OUTPUT); //configure RELAY5 for output //Pin 9
  //pinMode(RELAY6_PIN, OUTPUT); //configure RELAY6 for output //Pin 10
  //pinMode(RELAY7_PIN, OUTPUT); //configure RELAY7 for output //Pin A4
  //pinMode(RELAY8_PIN, OUTPUT); //configure RELAY8 for output //Pin A5
  #ifdef STEERSW_PIN
  pinMode(DIR_PIN, OUTPUT); //D11 PB3 direction pin of PWM Board
  pinMode(STEERSW_PIN, INPUT_PULLUP);  //Pin 10 PB2
  #endif
  //keep pulled high and drag low to activate, noise free safe    
  pinMode(WORKSW_PIN, INPUT_PULLUP);   //Pin D4 PD4

  #ifdef AUTOSTEER_ENABLE
  pinMode(AUTOSTEER_ENABLE, INPUT_PULLUP);
  analogWrite(PWM_LEFT, 0);
  analogWrite(PWM_RIGHT, 0);
  attachInterrupt(digitalPinToInterrupt(2), toggle, FALLING);
  #endif
  analogWrite(AUTOSTEER_LED, 0);

  EEPROM.get(0, steerSettings);
    
  Serial.begin(19200);  //open serial port
   
  //PWM rate settings Adjust to desired PWM Rate
  //TCCR1B = TCCR1B & B11111000 | B00000001;    // set timer 1 divisor to     1 for PWM frequency of 31372.55 Hz
  //TCCR1B = TCCR1B & B11111000 | B00000010;    // set timer 1 divisor to     8 for PWM frequency of  3921.16 Hz
  TCCR1B = TCCR1B & B11111000 | B00000011;    // set timer 1 divisor to    64 for PWM frequency of   490.20 Hz (The DEFAULT)
  //TCCR1B = TCCR1B & B11111000 | B00000100;    // set timer 1 divisor to   256 for PWM frequency of   122.55 Hz
  //TCCR1B = TCCR1B & B11111000 | B00000101;    // set timer 1 divisor to  1024 for PWM frequency of    30.64 Hz
} 

void loop()
{
  // header high/low, relay byte, speed byte, high distance, low distance, high delta, low delta, PID Settings byte
  if (Serial.available() > 0 && !isDataFound && !isSettingFound) //find the header, 127H + 254L = 32766
  {
    int temp = Serial.read();
    header = tempHeader << 8 | temp;               //high,low bytes to make int
    tempHeader = temp;                             //save for next time
    if (header == 32766) isDataFound = true;     //Do we have a match? 
    if (header == 32764) isSettingFound = true;     //Do we have a match? 
  }
  
  //Header has been found, presumably the next 6 bytes are the data
  if (Serial.available()> 5 && isDataFound)
  {  
    isDataFound = false;    
    relay = Serial.read();   // read relay control from AgOpenGPS

    //actual speed times 4
    speeed = Serial.read()>>2;  //single byte

    //distance from the guidance line in mm
    distanceFromLine = (float)(Serial.read() << 8 | Serial.read());   //high,low bytes     

    //set point steer angle * 10 is sent
    steerAngleSetPoint = (float)(Serial.read() << 8 | Serial.read()); //high low bytes 
    steerAngleSetPoint /=10.0;
    
    workSwitch = digitalRead(WORKSW_PIN);  // read work switch
    #ifdef STEERSW_PIN
    steerSwitch = digitalRead(STEERSW_PIN); //read auto steer enable switch open = 0n closed = Off
    #endif
    SetRelays();

    //analogReference(EXTERNAL);
      
    //steering position and steer angle
    analogRead(A0); //discard initial reading
    steeringPosition = analogRead(A0);
    delay(1);
    steeringPosition += analogRead(A0);
    delay(1);
    steeringPosition += analogRead(A0);
    delay(1);
    steeringPosition += analogRead(A0);
    delay(1);
    steeringPosition = steeringPosition >> 2; //divide by 4    
    steeringPosition = ( steeringPosition - steerSettings.steeringPositionZero);   //read the steering position sensor

    //convert position to steer angle. 4 counts per degree of steer pot position in my case
    //  ***** make sure that negative steer angle makes a left turn and positive value is a right turn *****
    // remove or add the minus for steerSensorCounts to do that.
    steerAngleActual = (float)(steeringPosition)/-steerSettings.steerSensorCounts;    

    //inclinometer
    delay(1);
    analogRead(A1); //discard
    delay(1);
    tilt = analogRead(A1);
   delay(1);
    tilt += analogRead(A1);
   delay(1);
    tilt += analogRead(A1);
   delay(1);
    tilt += analogRead(A1);

    tilt = tilt >> 2; //divide by 4

    //inclinometer goes from -25 to 25 from 0 volts to 5 volts
    tilt = map(tilt,0,1023,-500,500);

    //the steering part - if not off or invalid
    #ifdef STEERSW_PIN
    if (distanceFromLine == 32020 | distanceFromLine == 32000             //auto Steer is off if 32020, invalid if 32000
          | speeed < 1 | steerSwitch == 0)                                             //Speed is too slow, motor or footswitch out of place or pulling pin low
    #endif
    #ifdef AUTOSTEER_ENABLE
    if (distanceFromLine == 32020 | distanceFromLine == 32000             //auto Steer is off if 32020, invalid if 32000
          | speeed < 1)
    #endif
    
    {
      pwmDrive = 0; //turn off steering motor
      motorDrive();
      #ifdef AUTOSTEER_ENABLE
      steerEnable = false;
      #endif

      //send to AgOpenGPS - autosteer is off
      Serial.print(steerAngleActual);
      Serial.print(",");    
      Serial.print(steerSettings.Kp);
      Serial.print(",");    
      Serial.print(steerSettings.Ki,2);
      Serial.print(",");    
      Serial.print(steerSettings.Kd);
      Serial.print(",");    
      Serial.print(steerSettings.Ko);
      Serial.print(",");    
      Serial.println(tilt); //tilt
    }
     
    else          //valid spot to turn on autosteer
    {
      bitSet(PINB, 5);              //turn LED on showing in headingDelta loop      

      //calculate the steering error
      steerAngleError = steerAngleActual - steerAngleSetPoint;                    

      //do the pid
      calcSteeringPID();                                                                                                            
      motorDrive();    //out to motors the pwm value

      //send to agopenGPS
      Serial.print(steerAngleActual);
      Serial.print(",");    
      Serial.print((int)pValue);
      Serial.print(",");    
      Serial.print((int)iValue);
      Serial.print(",");    
      Serial.print((int)dValue);
      Serial.print(",");    
      Serial.print(pwmDisplay);
      Serial.print(",");
      Serial.println(tilt);   //tilt     
    } 
  }  

  //Header has been found, presumably the next 8 bytes are the settings
  if (Serial.available() > 7 && isSettingFound)
  {  
    isSettingFound = false;

    //change the factors as required for your own PID values
    steerSettings.Kp = (float)Serial.read() * 1.0;   // read Kp from AgOpenGPS
    steerSettings.Ki = (float)Serial.read() * 0.1;   // read Ki from AgOpenGPS
    steerSettings.Kd = (float)Serial.read() * 1.0;   // read Kd from AgOpenGPS
    steerSettings.Ko = (float)Serial.read() * 0.1;   // read Ko from AgOpenGPS
    steerSettings.steeringPositionZero = 412 + Serial.read();  //read steering zero offset
    steerSettings.minPWMValue = Serial.read(); //read the minimum amount of PWM for instant on
    steerSettings.maxIntegralValue = Serial.read(); //
    steerSettings.steerSensorCounts = Serial.read()*0.1; //sent as 10 times the setting displayed in AOG
    EEPROM.put(0, steerSettings);
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



