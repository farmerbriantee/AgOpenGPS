#include <SPI.h>
#include <ISOBUS.h>

char spn_buffer[512];  //Data will be temporarily stored to this buffer before being written to the filechar buffer[512];  //Data will be temporarily stored to this buffer before being written to the file

ISOBUSMessage receiveMessage;

void setup()
{
  ISOBUS.begin(CAN_SPEED_250000);
  ISOBUS.setMode (CAN_MODE_NORMAL);
  Serial.begin(19200);

  // initialize digital pin 2 and 3 as an output.
  pinMode(2, OUTPUT);
  pinMode(3, OUTPUT);
}

void loop()
{
  /* Receive data if available */
  if (ISOBUS.available()) {
    receiveMessage = ISOBUS.getMessageISOBUS(EEC1_PGN, EngineSpeed_SPN, spn_buffer);
    if (receiveMessage.status == 0)
    {
      Serial.print(receiveMessage.status);
      Serial.print(",");
      Serial.print(receiveMessage.id);
      Serial.print(",");
      Serial.print(receiveMessage.pgn);
      Serial.print(",");
      Serial.print(receiveMessage.spn_data);
      Serial.print(",");
      Serial.println(spn_buffer);

      // control outputs based on engine speed
      if (receiveMessage.spn_data > 850) {
        digitalWrite(2, HIGH);
        digitalWrite(3, HIGH);
      }
      else {
        digitalWrite(2, LOW);
        digitalWrite(3, LOW);
      }

    }
  }
}









