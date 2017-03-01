int inByte = 0; // incoming serial byte

void setup() {
  //Pins 8 thru 12 as output, 8 is LSB
  DDRB = B00011111;

  //PORTB turn off 8 thru 12
  PORTB = B00000000;

  //Pin D2 as input, pulled up.
  pinMode(2, INPUT_PULLUP);  

  Serial.begin(9600);
  //while (!Serial) {}

  establishContact(); // send a byte to establish contact until receiver responds
}

void loop() 
{
  if (Serial.available() > 0)
  {
    inByte = Serial.read();   // read relay control from AgOpenGPS
    PORTB = inByte;           // write out to relays
    inByte = digitalRead(2);  // read work switch
    Serial.write(inByte+48);  // write byte as ascii 1 or 0 to AgOpenGPS
    Serial.flush();           // flush out buffer
  }
  delay(100);     
}

void establishContact() 
{
  while (Serial.available() <= 0) 
  {
    Serial.print("X"); // send an initial string
    delay(500);
  }
}
