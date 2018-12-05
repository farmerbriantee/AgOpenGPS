void calcSteeringPID(void) 
 {
 
  //Proportional
  pValue = steerSettings.Kp * steerAngleError *steerSettings.Ko;  

 /* //Derivative
  dError = steerAngleError - lastLastError;
  dValue = steerSettings.Kd * (dError) * steerSettings.Ko;
  
  //save history of errors
  lastLastError = lastError;
  lastError = steerAngleError;
 */
  
 
  drive = pValue;// + dValue;
  pwmDrive = (constrain(drive, -255, 255));


  //add throttle factor so no delay from motor resistance.
  if (pwmDrive < 0 ) pwmDrive -= steerSettings.minPWMValue;
  else if (pwmDrive > 0 ) pwmDrive += steerSettings.minPWMValue;
  
 if (pwmDrive > 255) pwmDrive = 255;
 if (pwmDrive < -255) pwmDrive = -255;

 }
 
#if (Output_Driver == 1) //Steering Motor + Cytron MD30C Driver
void motorDrive(void) 
  {// Used with Cytron MD30C Driver
   // Steering Motor
   // Dir + PWM Signal
    
    pwmDisplay = pwmDrive;
    if (pwmDrive >= 0) analogWrite(DIR_PIN, 255);  //set the correct direction
    else   
    {
      analogWrite(DIR_PIN, 0); 
      pwmDrive = -1 * pwmDrive;  
   }
    analogWrite(PWM_PIN, pwmDrive);
  }
#endif


#if (Output_Driver == 2) //Steering Motor + IBT_2 Driver
void motorDrive(void) 
  {// Used with IBT 2  Driver
   // Steering Motor
   // PWM Left + PWM Right Signal
   // Same Code as the PWM Valve
   
   if (steerEnable == false) pwmDrive=0;
   
    pwmDisplay = pwmDrive; 
  
  if (pwmDrive > 0)
    {
      analogWrite(PWM_PIN, pwmDrive);
      analogWrite(DIR_PIN, 0);//Set DIR PIN low
    }
    
  if (pwmDrive <= 0)
    {
      pwmDrive = -1 * pwmDrive;  
      analogWrite(DIR_PIN, pwmDrive);
      analogWrite(PWM_PIN, 0);//Set PWM PIN low
    } 
  }
#endif


#if (Output_Driver == 3) // PWM 2-coil-Valve + IBT_2 Driver
void motorDrive(void)
 { // Used with 2-Coil PWM Valves 
   // No coil powered = Center
   // Coil 1 steer right connected to PWM_PIN 11
   // Coil 2 steer left  connected to DIR_PIN 10
  
  if (steerEnable == false) pwmDrive=0;
   
  pwmDisplay = pwmDrive; 
  
  if (pwmDrive > 0)
    {
    analogWrite(PWM_PIN, pwmDrive);
    analogWrite(DIR_PIN, 0);
    }
    
  if (pwmDrive <= 0)
    {
      pwmDrive = -1 * pwmDrive;  
      analogWrite(DIR_PIN, pwmDrive);
      analogWrite(PWM_PIN, 0);
    }
 }  
#endif


#if (Output_Driver == 4) // Danfoss Valve + IBT_2 Driver
void motorDrive(void) 
  { // Danfoss: PWM 25% On = Left Position max  (below Valve=Center)
    // Danfoss: PWM 50% On = Center Position
    // Danfoss: PWM 75% On = Right Position max (above Valve=Center)
    if (pwmDrive >  250) pwmDrive =  250; 
    if (pwmDrive < -250) pwmDrive = -250;
  
  if (steerEnable == true) bitSet(PORTD, 6); // turn on /off Power
  else 
    {
      bitClear(PORTD, 6);  
      pwmDrive=0;
    }
   

    pwmDrive = pwmDrive / 4;  
    pwmOut = pwmDrive+ 128;  // add Center Pos.
  
    pwmDisplay = pwmOut;
    analogWrite(PWM_PIN, pwmOut);
  }
#endif
