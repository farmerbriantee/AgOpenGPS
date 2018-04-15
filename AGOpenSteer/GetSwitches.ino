void GetSwitches(void)
 {
    Wire.beginTransmission(SWITCH_ADDRESS);  // Begin i2c tranfer
    Wire.requestFrom(SWITCH_ADDRESS, 1);    // Read 1 byte
    if(Wire.available())    // slave may send less than requested
    { 
      switchByte = Wire.read(); // receive switch byte
    }
    Wire.endTransmission();
        
    steerSwitch = digitalRead(A1); //read auto steer enable switch open = 0n closed = Off
    if (steerSwitch == 0) { //Pull steerswitch low to reset overcurrent and maxpulsecount
      overCurrent=0;
      pulseCount=0;   
    }
    if (pulseCount >= pulseCountMax | overCurrent) steerSwitch=0;  // Disable from Steeringwheel encoder
    steerEnable = steerSwitch; //digitalRead(A1); //Get enabled conditions
    steerSwitch <<= 1; //put steerswitch status in bit 1 position

    if (!ENCINDEX){
      workSwitch = analogRead(A6) > 512 ? 1 : 0;  //read work switch from A6
      switchByte = (~switchByte & 0b11111100) + (workSwitch | steerSwitch);
    }

    else{
            switchByte = (~switchByte & 0b1111101) ^ (steerSwitch);
      }

 }

  
