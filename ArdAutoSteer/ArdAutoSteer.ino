int inByteHigh = 0; // incoming serial byte
int inByteLow = 0;
int distance = 0;
int delta = 0;

void setup() {
  //Pins 8 thru 12 as output, 8 is LSB
  DDRB = B00011111;

  //PORTB turn off 8 thru 12
  PORTB = B00000000;

  //Pin D2 as input, pulled up.
  pinMode(2, INPUT_PULLUP);  

  Serial.begin(19200);
  //while (!Serial) {}

  establishContact(); // send a byte to establish contact until receiver responds
}

void loop() 
{
  if (Serial.available() > 3)
  {
    inByteHigh = Serial.read();   // read relay control from AgOpenGPS
    inByteLow = Serial.read();
    distance = inByteHigh * 256 + inByteLow;
    inByteHigh = Serial.read();   // read relay control from AgOpenGPS
    inByteLow = Serial.read();
    delta = inByteHigh * 256 + inByteLow;
    
    Serial.print(distance);  // write byte as ascii 1 or 0 to AgOpenGPS
    Serial.print(",");
    Serial.println(delta);
    Serial.flush();           // flush out buffer
  }
  //delay(50);     
}

void establishContact() 
{
  while (Serial.available() <= 0) 
  {
    Serial.print("X"); // send an initial string
    delay(500);
  }
}
