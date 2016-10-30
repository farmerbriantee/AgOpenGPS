int inByte = 0;         // incoming serial byte
  
void setup() {
    //Pins 8 thru 12 as output, 8 is LSB
    DDRB = B00011111;

    //PORTB turn off 8 thru 12
    PORTB = B00000000;
    
  Serial.begin(9600);
  while (!Serial) {}

  establishContact();  // send a byte to establish contact until receiver responds
}

void loop() {
  // if we get a valid byte, read analog ins:
  if (Serial.available() > 0)
  {
    // get incoming byte:
    inByte = Serial.read();
    Serial.print(inByte);

    PORTB = inByte;
 
  }
  
}

void establishContact() {
  while (Serial.available() <= 0) {
    Serial.print("X");   // send an initial string
    delay(500);
  }
}



