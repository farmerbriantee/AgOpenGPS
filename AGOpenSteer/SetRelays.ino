void SetRelays(void)
 {
    Wire.beginTransmission(RELAY_ADDRESS);  // Begin i2c tranfer
    Wire.write(~relay);                     // Write inverted for active low
    Wire.endTransmission();                 // end transfer
  }
  
void SetRelaysU(void)
 {
    Wire.beginTransmission(RELAYU_ADDRESS); // Begin i2c tranfer
    Wire.write( (~uTurn  ^ workSwitch*64 ^ steerSwitch*64) );                     // Write inverted for active low
    Wire.endTransmission();                 // end transfer
  }
