void calcSteeringPID(void) 
 {  
  //Proportional only
  pValue = steerSettings.Kp * steerAngleError * 0.5;
  pwmDrive = (int)pValue;
  
  errorAbs = abs(steerAngleError);
  float newMax = 0; 
   
  if (errorAbs < DEGREES)
  {
    newMax = (errorAbs * highLowPerDeg) + steerSettings.deadZone;
  }
  else newMax = steerSettings.maxPWM;
    
  //add min throttle factor so no delay from motor resistance.
  if (pwmDrive < 0 ) pwmDrive -= steerSettings.minPWM;
  else if (pwmDrive > 0 ) pwmDrive += steerSettings.minPWM;
  
     //Serial.print(newMax); //The actual steering angle in degrees
     //Serial.print(",");

  //limit the pwm drive
  if (pwmDrive > newMax) pwmDrive = newMax;
  if (pwmDrive < -newMax) pwmDrive = -newMax;

  if (aogSettings.MotorDriveDirection) pwmDrive *= -1;
      Serial.println(pwmDrive);
 }

//#########################################################################################

void motorDrive(void) 
  {
    // Used with Cytron MD30C Driver
    // Steering Motor
    // Dir + PWM Signal
    if (aogSettings.CytronDriver)
    {     
      pwmDisplay = pwmDrive;
  
      //fast set the direction accordingly (this is pin DIR1_RL_ENABLE, port D, 4)
      if (pwmDrive >= 0) bitSet(PORTD, 4);  //set the correct direction
      else   
      {
        bitClear(PORTD, 4); 
        pwmDrive = -1 * pwmDrive;  
      }
  
      //write out the 0 to 255 value 
      analogWrite(PWM1_LPWM, pwmDrive);
    }
    else
    {
      // Used with IBT 2  Driver for Steering Motor
      // Dir1 connected to BOTH enables
      // PWM Left + PWM Right Signal     
      pwmDisplay = pwmDrive; 
    
      if (pwmDrive > 0)
      {
        analogWrite(PWM2_RPWM, 0);//Turn off before other one on
        analogWrite(PWM1_LPWM, pwmDrive);
      }      
      else
      {
        pwmDrive = -1 * pwmDrive;  
        analogWrite(PWM1_LPWM, 0);//Turn off before other one on
        analogWrite(PWM2_RPWM, pwmDrive);
      }
    }
  }
