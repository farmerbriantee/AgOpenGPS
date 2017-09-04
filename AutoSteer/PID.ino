void calcSteeringPID(void) {
  
  //proportional
  pValue = Kp * steerAngleError;
  
 /* 
  //Integral

  integrated_error = integrated_error + steerAngleError;
  if (integrated_error > maxIntErr) integrated_error = maxIntErr;
  if (integrated_error < -maxIntErr) integrated_error = -maxIntErr;

  //once it passes near center zero out the integrator error
  //if (abs(headingError) < 2) integrated_error = 0;
  iValue = Ki * integrated_error;
*/
  //Derivative
  dError = steerAngleError - lastError;
  dValue = Kd * (dError);
  
  //save history of errors
  lastLastError = lastError;
  lastError = steerAngleError;

  drive = (pValue + iValue + dValue)*Ko;
  pwmDrive = int(constrain(drive, -255, 255));

  //add throttle factor so no delay from motor resistance.
  if (pwmDrive < 0 & pwmDrive > (-255 + minPWMValue)) pwmDrive = pwmDrive - minPWMValue;
  else if (pwmDrive > 0 & pwmDrive < (255 - minPWMValue)) pwmDrive = pwmDrive + minPWMValue;

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


