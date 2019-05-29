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
 
 #if (Output_Invert == 1) 
   pwmDrive *= -1;
 #endif
 }

//#########################################################################################

#if (Output_Driver == 1) //Steering Motor + Cytron MD30C Driver
void motorDrive(void) 
  {// Used with Cytron MD30C Driver
   // Steering Motor
   // Dir + PWM Signal
    
    pwmDisplay = pwmDrive;

#if (PinMapping == 0 )
  if (pwmDrive >= 0) analogWrite(DIR_PIN, 255);  //set the correct direction
  else{
       analogWrite(DIR_PIN, 0); 
       pwmDrive = -1 * pwmDrive;  
      }
#endif 

#if (PinMapping == 1 )
  if (pwmDrive >= 0) digitalWrite(DIR_PIN, HIGH);  //set the correct direction
  else{
       digitalWrite(DIR_PIN, LOW); 
       pwmDrive = -1 * pwmDrive;  
      }
#endif
    analogWrite(PWM1_PIN, pwmDrive);
  }
#endif

//#########################################################################################

#if (Output_Driver == 2 | Output_Driver == 3 ) // IBT_2 Driver + Steering Motor or PWM 2-coil valve
void motorDrive(void) 
  {// Used with IBT 2  Driver
   // Steering Motor and also 2-coil PWM valve
   // PWM Left + PWM Right Signal
   
   if (steerEnable == false) pwmDrive=0;
   
    pwmDisplay = pwmDrive; 

 #if (PinMapping == 0 )
  if (pwmDrive > 0)
    {
      analogWrite(PWM1_PIN, pwmDrive);
      analogWrite(DIR_PIN, 0);//Set DIR PIN low
    }
    
  if (pwmDrive <= 0)
    {
      pwmDrive = -1 * pwmDrive;  
      analogWrite(DIR_PIN, pwmDrive);
      analogWrite(PWM1_PIN, 0);//Set PWM PIN low
    }
 #endif 
 #if (PinMapping == 1 )
  if (pwmDrive > 0)
    {
      analogWrite(PWM1_PIN, pwmDrive);
      analogWrite(PWM2_PIN, 0);//Set DIR PIN low
    }
    
  if (pwmDrive <= 0)
    {
      pwmDrive = -1 * pwmDrive;  
      analogWrite(PWM2_PIN, pwmDrive);
      analogWrite(PWM1_PIN, 0);//Set PWM PIN low
    }
 #endif
  }
#endif

//#########################################################################################

#if (Output_Driver == 4) // Danfoss Valve + IBT_2 Driver
void motorDrive(void) 
  { // Danfoss: PWM 25% On = Left Position max  (below Valve=Center)
    // Danfoss: PWM 50% On = Center Position
    // Danfoss: PWM 75% On = Right Position max (above Valve=Center)
    if (pwmDrive >  250) pwmDrive =  250; 
    if (pwmDrive < -250) pwmDrive = -250;
  
 #if (PinMapping == 0 )
  if (steerEnable == true) analogWrite(DIR_PIN, 255); // turn on /off Power
  else 
    {
      analogWrite(DIR_PIN, 0); 
      pwmDrive=0;
    }
   

    pwmDrive = pwmDrive / 4;  
    pwmOut = pwmDrive+ 128;  // add Center Pos.
  
    pwmDisplay = pwmOut;
    analogWrite(PWM1_PIN, pwmOut);
 #endif
 #if (PinMapping == 1 )
    if (steerEnable == true) digitalWrite(DIR_PIN, HIGH); // turn on Valvepower
  else 
    {
      digitalWrite(DIR_PIN, LOW);
      pwmDrive=0;
    }
   

    pwmDrive = pwmDrive / 4;  
    pwmOut = pwmDrive+ 128;  // add Center Pos.
  
    pwmDisplay = pwmOut;
    analogWrite(PWM1_PIN, pwmOut);  
 #endif 
  }
#endif
