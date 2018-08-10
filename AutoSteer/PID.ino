void calcSteeringPID(void) {
  
  //Proportional
  pValue = steerSettings.Kp * steerAngleError * steerSettings.Ko;   
/*
  //if (abs(distanceFromLine) < 15)
  //{
    //Integral
    integrated_error = integrated_error + steerAngleError;
  //}
  //else
  {
    //integrated_error = integrated_error + distanceFromLine/10;    
  }

  if (integrated_error > maxIntErr) integrated_error = maxIntErr;
  if (integrated_error < -maxIntErr) integrated_error = -maxIntErr;

  //once it passes near center zero out the integrator error
  if (steerAngleError > 0) steerCurrentSign = 1;
  else steerCurrentSign = 0;

  //did we cross zero?
  if (steerCurrentSign - steerPrevSign) integrated_error = 0; //zero out the integrator
  steerPrevSign = steerCurrentSign;  //save a copy for next time
  
  iValue = Ki * integrated_error;  
  if (iValue > maxIntegralValue) iValue = maxIntegralValue;
  if (iValue < -maxIntegralValue) iValue = -maxIntegralValue;


  

  //Derivative
  dError = steerAngleError - lastLastError;
  dValue = Kd * (dError) * Ko;
  
  //save history of errors
  lastLastError = lastError;
  lastError = steerAngleError;
  

  drive = pValue + dValue + iValue;
  */
  drive = pValue;
  pwmDrive = (constrain(drive, -255, 255));

  //add throttle factor so no delay from motor resistance.
  if (pwmDrive < 0 & pwmDrive > (-255 + steerSettings.minPWMValue)) pwmDrive = pwmDrive - steerSettings.minPWMValue;
  else if (pwmDrive > 0 & pwmDrive < (255 - steerSettings.minPWMValue)) pwmDrive = pwmDrive + steerSettings.minPWMValue;

  pwmDrive = (constrain(drive, -200, 200));
 }

 void motorDrive(void) 
  {
    pwmDisplay = pwmDrive;
     #ifndef HYDRAULIC_STEER
    if (pwmDrive > 0) bitSet(PORTB, 4);  //set the correct direction
    else   
    {
      bitClear(PORTB, 4); 
      pwmDrive = -1 * pwmDrive;  
   }
    analogWrite(PWM_PIN, pwmDrive);
    
    #else
    if (steerEnable == true)
    {
    analogWrite(AUTOSTEER_LED, 200);
     }
    else
    {
      analogWrite(AUTOSTEER_LED, 0);
      pwmDrive = 0;
    }
    
    if (pwmDrive > 0)
    {
    analogWrite(PWM_RIGHT, pwmDrive);
    analogWrite(PWM_LEFT, 0);
    }
    
    else if (pwmDrive <= 0)
    {
      pwmDrive = -1 * pwmDrive;  
      analogWrite(PWM_LEFT, pwmDrive);
      analogWrite(PWM_RIGHT, 0);
   }
    
    #endif
  }


