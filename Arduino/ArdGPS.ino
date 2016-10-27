int inByte = 0;         // incoming serial byte
  
void setup() {
  pinMode(8, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(12, OUTPUT);
  // start serial port at 9600 bps and wait for port to open:
  Serial.begin(9600);
  while (!Serial) {
    ; // wait for serial port to connect. Needed for native USB port only
  }


  //pinMode(2, INPUT);   // digital sensor is on digital pin 2
  establishContact();  // send a byte to establish contact until receiver responds
}

void loop() {
  // if we get a valid byte, read analog ins:
  if (Serial.available() > 0)
  {
    // get incoming byte:
    inByte = Serial.read();
    Serial.print(inByte);

    if (inByte == 0) 
    {
      digitalWrite(8, LOW);
      digitalWrite(9, LOW);
      digitalWrite(10, LOW);
      digitalWrite(11, LOW);
      digitalWrite(12, LOW);
      //Serial.print("Off");
    }

    //
    if (inByte == 1) 
    {
      digitalWrite(8, HIGH);
      digitalWrite(9, HIGH);
      digitalWrite(10, HIGH);
      digitalWrite(11, HIGH);
      digitalWrite(12, HIGH);
      //Serial.print("On");
    }
  }
  
}

void establishContact() {
  while (Serial.available() <= 0) {
    Serial.print("X");   // send an initial string
    delay(1000);
  }
}



