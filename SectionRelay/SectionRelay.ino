  #define WORKSW_PIN 4  //PD4
  
  #define RELAY1_PIN 5  //PD5
  #define RELAY2_PIN 6  //PD6
  #define RELAY3_PIN 7  //PD7
  #define RELAY4_PIN 8  //PB0
  #define RELAY5_PIN 9  //PB1
  #define RELAY6_PIN 10  //PB2
  #define RELAY7_PIN A4  //PC4
  #define RELAY8_PIN A5  //PC5
  
  int relay = 0; // incoming serial byte
 
  void setup() {
    Serial.begin(19200);
    
    //pinMode(LED_PIN, OUTPUT); //configure LED for output
    pinMode(RELAY1_PIN, OUTPUT); //configure RELAY1 for output //Pin 5
    pinMode(RELAY2_PIN, OUTPUT); //configure RELAY2 for output //Pin 6
    pinMode(RELAY3_PIN, OUTPUT); //configure RELAY3 for output //Pin 7
    pinMode(RELAY4_PIN, OUTPUT); //configure RELAY4 for output //Pin 8
    pinMode(RELAY5_PIN, OUTPUT); //configure RELAY5 for output //Pin 9
    pinMode(RELAY6_PIN, OUTPUT); //configure RELAY6 for output //Pin 10
    pinMode(RELAY7_PIN, OUTPUT); //configure RELAY7 for output //Pin A4
    pinMode(RELAY8_PIN, OUTPUT); //configure RELAY8 for output //Pin A5        
    pinMode(WORKSW_PIN, INPUT_PULLUP);   //Pin D4 PD4
    
    //Pin D2 as input, pulled up.
    pinMode(WORKSW_PIN, INPUT_PULLUP);

    bitClear(PORTD, 5); 
    bitClear(PORTD, 6); 
    //establishContact(); // send a byte to establish contact until receiver responds
    while(Serial.available()){Serial.read();}
}

void loop() 
{
  if (Serial.available() > 0)
  {
    relay = Serial.read();   // read relay control from AgOpenGPS
    if (bitRead(relay,0)) bitSet(PORTD, 5); //Digital Pin 5
    else bitClear(PORTD, 5); 
    if (bitRead(relay,1)) bitSet(PORTD, 6); //Digital Pin 6
    else bitClear(PORTD, 6); 
    
    relay = digitalRead(WORKSW_PIN);  // read work switch
    Serial.println(relay);  // write byte as ascii 1 or 0 to AgOpenGPS
  }
  
  delay(20);   
}

void establishContact() 
{
  while (Serial.available() <= 0) 
  {
    Serial.print("X"); // send an initial string
    delay(500);
  }
}
