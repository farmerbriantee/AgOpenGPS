#define LED_PIN 13 

#define   DIR_PIN    12  //PB4
#define   PWM_PIN    11  //PB3

#define WORKSW_PIN 4  //PD4

#define RELAY1_PIN 5  //PD5
#define RELAY2_PIN 6  //PD6
#define RELAY3_PIN 7  //PD6
#define RELAY4_PIN 8  //PB0
#define RELAY5_PIN 9  //PB1
#define RELAY6_PIN 10  //PB2
#define RELAY7_PIN A4  //PC4
#define RELAY8_PIN A5  //PC5

#define RAD2GRAD 57.2957795

  int pwmDrive = 0;
  byte relay = 0; // incoming serial byte
  byte workSwitch = 0;
  byte speeed = 0;
  float distanceError = 0;
  int steeringPosition = 512;
  int headingDelta = 0;

  void motorDrive(void) 
  {
    if (pwmDrive > 0) bitSet(PORTB, 4);  //set the correct direction
    else   
    {
      bitClear(PORTB, 4); 
      pwmDrive = -1 * pwmDrive;  
   }
    analogWrite(PWM_PIN, pwmDrive);
  }

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
  	
	Serial.begin(19600);	//open serial port
   
	//PWM rate settings Adjust to desired PWM Rate
	//TCCR1B = TCCR1B & B11111000 | B00000001;    // set timer 1 divisor to     1 for PWM frequency of 31372.55 Hz
	//TCCR1B = TCCR1B & B11111000 | B00000010;    // set timer 1 divisor to     8 for PWM frequency of  3921.16 Hz
	TCCR1B = TCCR1B & B11111000 | B00000011;    // set timer 1 divisor to    64 for PWM frequency of   490.20 Hz (The DEFAULT)
	//TCCR1B = TCCR1B & B11111000 | B00000100;    // set timer 1 divisor to   256 for PWM frequency of   122.55 Hz
	//TCCR1B = TCCR1B & B11111000 | B00000101;    // set timer 1 divisor to  1024 for PWM frequency of    30.64 Hz
} 

void loop()
{
    // relay byte, speed byte, high distance, low distance, high delta, low delta
    if (Serial.available() > 5)
    {
        relay = Serial.read();   // read relay control from AgOpenGPS
        
        if (bitRead(relay,0)) bitSet(PORTD, 5); //Digital Pin 5
        else bitClear(PORTD, 5); 
        if (bitRead(relay,1)) bitSet(PORTD, 6); //Digital Pin 6
        else bitClear(PORTD, 6); 
        //if (bitRead(relay,2)) bitSet(PORTD, 7); //Digital Pin 7
        //else bitClear(PORTD, 7); 
        //if (bitRead(relay,3)) bitSet(PORTB, 0); //Digital Pin 8
        //else bitClear(PORTB, 0); 
        //if (bitRead(relay,4)) bitSet(PORTB, 1); //Digital Pin 9
        //else bitClear(PORTB, 1); 
        //if (bitRead(relay,5)) bitSet(PORTB, 2); //Digital Pin 10
        //else bitClear(PORTB, 2); 
        //if (bitRead(relay,6)) bitSet(PORTC, 4); //analog Pin A4
        //else bitClear(PORTC, 4); 
        //if (bitRead(relay,7)) bitSet(PORTC, 5); //Analog Pin A5
        //else bitClear(PORTC, 5); 
                
        workSwitch = digitalRead(WORKSW_PIN);  // read work switch, save a variable by reusing int relay
  
        speeed = Serial.read()>>2;  //single byte
        distanceError = (float)(Serial.read() << 8 | Serial.read());   //high,low bytes     
        headingDelta = (float)(Serial.read() << 8 | Serial.read());     //high low bytes

        //read the steering position sensor
        int steeringPosition = analogRead(A0);

        if (distanceError == 32020 | distanceError == 32000) //auto Steer is off if 32020, invalid if 32000
        {
          pwmDrive = 0;
        }
        else
        {
          calcDistancePID(); //the distance loop
   
          if (distanceError > 0 )       //on the right side of line
          {
                      
          }
  
          else                          //on the left side. 
          {
  
            
          }
        }

        Serial.print(workSwitch);  // write byte as ascii 1 or 0 to AgOpenGPS
        Serial.print(",");    
        Serial.print(relay);
        Serial.print(",");    
        Serial.print(speeed);
        Serial.print(",");    
        Serial.print(distanceError);
        Serial.print(",");    
        Serial.println(pwmDrive);        
      
        while(Serial.available()) {Serial.read();}
              // empty out recv buffer
      
    }

		//flash the LED13
		bitSet(PINB, 5);
		//serialOut_GUI();
		//getTuning();
  	
}
