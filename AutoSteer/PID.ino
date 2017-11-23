void calcSteeringPID(void) {
  
  //Proportional
  pValue = Kp * steerAngleError *Ko;  
  
  //Integral
  integrated_error = integrated_error + steerAngleError;
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
  pwmDrive = int(constrain(drive, -255, 255));

  //add throttle factor so no delay from motor resistance.
  if (pwmDrive < 0 & pwmDrive > (-255 + minPWMValue)) pwmDrive = pwmDrive - minPWMValue;
  else if (pwmDrive > 0 & pwmDrive < (255 - minPWMValue)) pwmDrive = pwmDrive + minPWMValue;

  pwmDrive = int(constrain(drive, -200, 200));

 }

 void motorDrive(void) 
  {
    pwmDisplay = pwmDrive;
    if (pwmDrive > 0) bitSet(PORTB, 4);  //set the correct direction
    else   
    {
      bitClear(PORTB, 4); 
      pwmDrive = -1 * pwmDrive;  
   }
    analogWrite(PWM_PIN, pwmDrive);
  }


