void calcSteeringPID(void) 
 {  
  //Proportional only
  pValue = steerSettings.Kp * steerAngleError;
  pwmDrive = (int16_t)pValue;
  
  errorAbs = abs(steerAngleError);
  int16_t newMax = 0; 
   
  if (errorAbs < LOW_HIGH_DEGREES)
  {
    newMax = (errorAbs * highLowPerDeg) + steerSettings.lowPWM;
  }
  else newMax = steerSettings.highPWM;
    
  //add min throttle factor so no delay from motor resistance.
  if (pwmDrive < 0 ) pwmDrive -= steerSettings.minPWM;
  else if (pwmDrive > 0 ) pwmDrive += steerSettings.minPWM;
  
  //Serial.print(newMax); //The actual steering angle in degrees
  //Serial.print(",");

  //limit the pwm drive
  if (pwmDrive > newMax) pwmDrive = newMax;
  if (pwmDrive < -newMax) pwmDrive = -newMax;

  if (steerConfig.MotorDriveDirection) pwmDrive *= -1;

  if (steerConfig.IsDanfoss)
  {
    // Danfoss: PWM 25% On = Left Position max  (below Valve=Center)
    // Danfoss: PWM 50% On = Center Position
    // Danfoss: PWM 75% On = Right Position max (above Valve=Center)
    pwmDrive = (constrain(pwmDrive, -250, 250));

    // Calculations below make sure pwmDrive values are between 65 and 190
    // This means they are always positive, so in motorDrive, no need to check for
    // steerConfig.isDanfoss anymore
    pwmDrive = pwmDrive >> 2; // Devide by 4
    pwmDrive += 128;          // add Center Pos.
  }
 }

//#########################################################################################

void motorDrive(void) 
  {
    // Used with Cytron MD30C Driver
    // Steering Motor
    // Dir + PWM Signal
    if (steerConfig.CytronDriver)
    {
      // Cytron MD30C Driver Dir + PWM Signal
      if (pwmDrive >= 0)
      {
        bitSet(PORTD, 4);  //set the correct direction
      }
      else   
      {
        bitClear(PORTD, 4); 
        pwmDrive = -1 * pwmDrive;  
      }
  
      //write out the 0 to 255 value 
      analogWrite(PWM1_LPWM, pwmDrive);
      pwmDisplay = pwmDrive;
    }
    else
    {
      // IBT 2 Driver Dir1 connected to BOTH enables
      // PWM Left + PWM Right Signal     
    
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
      
      pwmDisplay = pwmDrive;
    }  
  }
