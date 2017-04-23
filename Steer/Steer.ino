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
  float distanceError = 0;
  int headingError = 0;
  byte pidSetting = 0;
  
  int steeringPosition = 0, steeringPosZero = 512;  
  int pwmDrive = 0, drive = 0, pwmDisplay = 0;
  float pValue = 0, iValue = 0, dValue = 0;
 
  bool isDataFound = false, isSettingFound = false;
  int header = 0, tempHeader = 0, temp;

  //PID variables
  float Ko = 1.0f;  //overall gain
  float Kp = 0.1f;  //proportional gain
  float Ki = 0.008f;//integral gain
  float Kd = 3.0f;  //derivative gain
  
  int   maxIntErr = 3000; //anti windup max  
  float lastError = 0, lastLastError = 0, integrated_error = 0, dError = 0;

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
    distanceError = (float)(Serial.read() << 8 | Serial.read());   //high,low bytes     
    headingError = (float)(Serial.read() << 8 | Serial.read());     //high low bytes 
    
    isDataFound = false;    
    workSwitch = digitalRead(WORKSW_PIN);  // read work switch
    SetRelays();
    steeringPosition = ( analogRead(A0) - steeringPosZero);   //read the steering position sensor
    delay(2);
  
    if (distanceError == 32020 | distanceError == 32000       //auto Steer is off if 32020, invalid if 32000
          | abs(distanceError) > 3000 | headingError > 4000  // greater then 2 meters off, steep angle > .4 rads
          | speeed < 3)                                       //Speed is too slow
    {
      pwmDrive = 0; //turn off steering motor
      motorDrive();
      bitClear(PORTD, 6); //Digital Pin 6
      
      Serial.print(steeringPosition);
      Serial.print(" ");    
      Serial.print(Kp);
      Serial.print(" ");    
      Serial.print(Ki,4);
      Serial.print(" ");    
      Serial.print(Kd);
      Serial.print(" ");    
      Serial.print(Ko);
      Serial.print(" ");    
      Serial.println(maxIntErr);
      //bitClear(PINB, 5); 
    }
    
    else          //valid spot to turn on autosteer
    {
      bitSet(PORTD, 6);             //Digital Pin 6
      bitSet(PINB, 5);              //turn LED on showing in headingDelta loop      
      calcDistancePID();            //the distance loop                                                                                    
      
      if (distanceError > 0 )       //on the right side of line
      {                
      }  
      else                          //on the left side. 
      {      
      }       
      motorDrive();                 //out to motors the pwm value
      
      Serial.print(steeringPosition);
      Serial.print(" ");    
      Serial.print(pValue);
      Serial.print(" ");    
      Serial.print(iValue);
      Serial.print(" ");    
      Serial.print(dValue);
      Serial.print(" ");    
      Serial.println(pwmDisplay);
    } 
  }
  
  //Header has been found, presumably the next 5 bytes are the settings
  if (Serial.available() > 4 && isSettingFound)
  {  
    isSettingFound = false;
    Kp = (float)Serial.read() * 0.01;   // read Kp from AgOpenGPS
    Ki = (float)Serial.read() * 0.001;   // read Ki from AgOpenGPS
    Kd = (float)Serial.read() * 0.1;   // read Kd from AgOpenGPS
    Ko = (float)Serial.read() * 0.1;   // read Ko from AgOpenGPS
    maxIntErr = Serial.read() * 100;  
  }
   	
}
