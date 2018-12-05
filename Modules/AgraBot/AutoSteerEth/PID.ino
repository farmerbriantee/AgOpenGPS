void calcSteeringPID(void) {
  
  //Proportional
  pValue = Kp * steerAngleError *Ko;    

 /* //Derivative
  dError = steerAngleError - lastLastError;
  dValue = Kd * (dError) * Ko;
  
  //save history of errors
  lastLastError = lastError;
  lastError = steerAngleError;
  */

  drive = pValue;// + dValue;
  pwmDrive = (constrain(drive, -255, 255));

  //add throttle factor so no delay from motor resistance.
  if (pwmDrive < 0 ) pwmDrive -= minPWMValue;
  else if (pwmDrive > 0 ) pwmDrive += minPWMValue;
  
 if (pwmDrive > 255) pwmDrive = 210;
 if (pwmDrive < -255) pwmDrive = -210;
 }

 void motorDrive(void) 
  {
    pwmDisplay = pwmDrive;
    //Pin D7
    if (pwmDrive >= 0) bitSet(PORTD, 7);  //set the correct direction
    else   
    {
      bitClear(PORTD, 7); 
      pwmDrive = -1 * pwmDrive;  
   }
    analogWrite(PWM_PIN, pwmDrive);
  }


