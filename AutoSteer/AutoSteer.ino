  #define LED_PIN 13 
  
  #define   DIR_PIN    12  //PB4
  #define   PWM_PIN    11  //PB3
  
  #define WORKSW_PIN 4  //PD4
  
  #define RELAY1_PIN 5  //PD5
  #define RELAY2_PIN 6  //PD6
  #define RELAY3_PIN 7  //PD7
  #define RELAY4_PIN 8  //PB0
  #define RELAY5_PIN 9  //PB1
  #define RELAY6_PIN 10  //PB2
  #define RELAY7_PIN A4  //PC4
  #define RELAY8_PIN A5  //PC5
  
  #define RAD2GRAD 57.2957795

  byte relay = 0, workSwitch = 0, speeed = 0;
  float distanceActual = 0;
  float headingActual = 0;
  float headingError = 0;
  
  byte pidSetting = 0;
  
  int steeringPosition = 0, steeringPositionZero = 512; 
  int tilt = 0, roll = 0;
  int pwmDrive = 0, drive = 0, pwmDisplay = 0;
  float pValue = 0, iValue = 0, dValue = 0;
  byte minPWMValue = 10;
 
  bool isDataFound = false, isSettingFound = false;
  int header = 0, tempHeader = 0, temp;

  //PID variables
  float Ko = 1.0f;  //overall gain
  float Kp = 0.1f;  //proportional gain
  float Ki = 0.008f;//integral gain
  float Kd = 3.0f;  //derivative gain  
  int   maxIntErr = 3000; //anti windup max  
  float lastError = 0, lastLastError = 0, integrated_error = 0, dError = 0;

void setup()
{
  pinMode(LED_PIN, OUTPUT); //configure LED for output
  pinMode(RELAY1_PIN, OUTPUT); //configure RELAY1 for output //Pin 5
  pinMode(RELAY2_PIN, OUTPUT); //configure RELAY2 for output //Pin 6
  pinMode(RELAY3_PIN, OUTPUT); //configure RELAY3 for output //Pin 7
  pinMode(RELAY4_PIN, OUTPUT); //configure RELAY4 for output //Pin 8
  pinMode(RELAY5_PIN, OUTPUT); //configure RELAY5 for output //Pin 9
  pinMode(RELAY6_PIN, OUTPUT); //configure RELAY6 for output //Pin 10
  pinMode(RELAY7_PIN, OUTPUT); //configure RELAY7 for output //Pin A4
  pinMode(RELAY8_PIN, OUTPUT); //configure RELAY8 for output //Pin A5
  
  pinMode(DIR_PIN, OUTPUT); //D11 PB3 direction pin of PWM Board
      
  pinMode(WORKSW_PIN, INPUT_PULLUP);   //Pin D4 PD4
    
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
    relay = Serial.read();   // read relay control from AgOpenGPS
    speeed = Serial.read()>>2;  //single byte
    distanceActual = (float)(Serial.read() << 8 | Serial.read());   //high,low bytes     
    headingActual = (float)(Serial.read() << 8 | Serial.read());     //high low bytes 
    
    isDataFound = false;    
    workSwitch = digitalRead(WORKSW_PIN);  // read work switch
    SetRelays();
    steeringPosition = ( analogRead(A0) - steeringPositionZero);   //read the steering position sensor
    delay(1);
    analogRead(A1); //discard
    tilt = analogRead(A1);

    //inclinometer goes from -25 to 25 from 0 volts to 5 volts
    tilt = map(tilt,0,1023,-500,500);

    //the steering part - if not off or invalid
    if (distanceActual == 32020 | distanceActual == 32000             //auto Steer is off if 32020, invalid if 32000
          | abs(distanceActual) > 4000 | abs (headingActual) > 6000   // greater then 4 meters off, steep angle > .4 radians
          | speeed < 1)                                               //Speed is too slow
    {
      pwmDrive = 0; //turn off steering motor
      motorDrive();
      bitClear(PORTD, 6); //Digital Pin 6

      //send to AgOpenGPS - autosteer is off
      Serial.print(steeringPosition);
      Serial.print(",");    
      Serial.print(Kp);
      Serial.print(",");    
      Serial.print(Ki,4);
      Serial.print(",");    
      Serial.print(Kd);
      Serial.print(",");    
      Serial.print(Ko);
      Serial.print(",");    
      Serial.println(tilt); //tilt
      //bitClear(PINB, 5); 
    }

    /* Positive distance is on the right side of the line, subtract the heading Delta
     *  Negative distance is on the left side of the line, add the heading Delta
     *  Positive heading, heading to the line, negative is away from the line
     *  Positive error - turn left   <<<<<
     *  Negative error - turn right  >>>>>
     */
     
    else          //valid spot to turn on autosteer
    {
      bitSet(PORTD, 6);             //Digital Pin 6 turn relay 2 on
      bitSet(PINB, 5);              //turn LED on showing in headingDelta loop      

      //determine ideal approach angle based on distance from line. 
      if (distanceActual > 0 )       //positive on the right side of line
      { 
        headingError = (distanceActual - headingActual)/50 - steeringPosition;                
      }  
      
      else                            //on the left side and has negative distance from line 
      {      
       headingError = (distanceActual + headingActual)/50 - steeringPosition;                                                                                                                                                                           
      } 
      
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
      Serial.println(tilt);   //tilt     
    } 
  }
  

  //Header has been found, presumably the next 6 bytes are the settings
  if (Serial.available() > 5 && isSettingFound)
  {  
    isSettingFound = false;

    //change the factors as required for your own PID values
    Kp = (float)Serial.read() * 0.01;   // read Kp from AgOpenGPS
    Ki = (float)Serial.read() * 0.001;   // read Ki from AgOpenGPS
    Kd = (float)Serial.read() * 0.1;   // read Kd from AgOpenGPS
    Ko = (float)Serial.read() * 0.1;   // read Ko from AgOpenGPS
    steeringPositionZero = 412 + Serial.read();  //read steering zero offset
    minPWMValue = Serial.read(); //read the minimum amount of PWM for instant on
  }
}



