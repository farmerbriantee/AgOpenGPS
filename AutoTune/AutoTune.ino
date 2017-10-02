  #define LED_PIN 13 
  
  #define   DIR_PIN    12  //PB4
  #define   PWM_PIN    11  //PB3
  
  #define WORKSW_PIN 4  //PD4
  #define STEERSW_PIN 10 //PB2
  
  #define RELAY1_PIN 5  //PD5
  #define RELAY2_PIN 6  //PD6
  #define RELAY3_PIN 7  //PD7
  #define RELAY4_PIN 8  //PB0
  #define RELAY5_PIN 9  //PB1
  //#define RELAY6_PIN 10  //PB2
  //#define RELAY7_PIN A4  //PC4
  //#define RELAY8_PIN A5  //PC5
  
  #define RAD2GRAD 57.2957795
  
  //autotune variables
  int counter = 0;
  float testPID = 0;

//program flow
  bool isDataFound = false, isSettingFound = false;
  int header = 0, tempHeader = 0, temp;

  byte relay = 0, workSwitch = 0, steerSwitch = 1, speeed = 0;
  float distanceFromLine = 0; // not used

  //steering variables
  float steerAngleActual = 0;
  int steerPrevSign = 0, steerCurrentSign = 0; // the steering wheels angle currently and previous one
  float steerAngleSetPoint = 0; //the desired angle from AgOpen
  int steeringPosition = 0, steeringPositionZero = 512; //from steering sensor
  float steerAngleError = 0; //setpoint - actual

  //inclinometer variables
  int tilt = 0, roll = 0;

  //pwm variables
  int pwmDrive = 0, drive = 0, pwmDisplay = 0;
  float pValue = 0, iValue = 0, dValue = 0;
  byte minPWMValue = 10;
 
  //PID variables
  float Ko = 0.0f;  //overall gain
  float Kp = 0.0f;  //proportional gain
  float Ki = 0.0f;//integral gain
  float Kd = 0.0f;  //derivative gain 

  //integral values - **** change as required *****
  int   maxIntErr = 200; //anti windup max
  float maxIntegralValue = 20.0; //max PWM value for integral PID component 

  //error values
  float lastError = 0, lastLastError = 0, integrated_error = 0, dError = 0;


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
  
  pinMode(DIR_PIN, OUTPUT); //D11 PB3 direction pin of PWM Board
      
  pinMode(WORKSW_PIN, INPUT_PULLUP);   //Pin D4 PD4
  pinMode(STEERSW_PIN, INPUT_PULLUP);  //Pin 10 PB2
   
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
    steerSwitch = digitalRead(STEERSW_PIN); //read auto steer enable switch open = 0n closed = Off

    //analogReference(EXTERNAL);
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
    steeringPosition = (steeringPosition - steeringPositionZero); //zero it out
    
    bitSet(PINB, 5);              //turn LED on showing in headingDelta loop      

      counter++;

      if (counter == 30) testPID = 5;
      if (counter == 60) testPID = 0;
      if (counter == 90) testPID = -5;
      if (counter == 120) testPID = 0;

      if (counter > 150) counter = 0;

      //determine ideal approach angle based on distance from line. 
      steerAngleError = testPID - steeringPosition;                
   
      //calculate PID values and motor drive
      calcSteeringPID();                                                                                                           
      motorDrive();    //out to motors the pwm value

      //send to agopenGPS
      Serial.print(steeringPosition);
      Serial.print(",");    
      Serial.print(pValue);
      Serial.print(",");    
      Serial.print(iValue);
      Serial.print(",");    
      Serial.print(dValue);
      Serial.print(",");    
      Serial.print(pwmDisplay);
      Serial.print(",");
      Serial.println(testPID);   //tilt     
    
  }
  

  //Header has been found, presumably the next 7 bytes are the settings
  if (Serial.available() > 6 && isSettingFound)
  {  
    isSettingFound = false;

    //change the factors as required for your own PID values
    Kp = (float)Serial.read() * 1.0;   // read Kp from AgOpenGPS
    Ki = (float)Serial.read() * 0.1;   // read Ki from AgOpenGPS
    Kd = (float)Serial.read() * 1.0;   // read Kd from AgOpenGPS
    Ko = (float)Serial.read() * 0.1;   // read Ko from AgOpenGPS
    steeringPositionZero = 412 + Serial.read();  //read steering zero offset
    minPWMValue = Serial.read(); //read the minimum amount of PWM for instant on
    maxIntegralValue = Serial.read(); //
  }
}



