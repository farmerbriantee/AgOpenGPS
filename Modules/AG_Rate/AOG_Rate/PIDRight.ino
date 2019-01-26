  
void calcRatePIDRight(void) {
  
	//Proportional
	pValueRight = 0.5 * rateErrorRight; 

	//Integral
	integrated_errorRight = integrated_errorRight + rateErrorRight;
	if (integrated_errorRight > maxIntErrRight) integrated_errorRight = maxIntErrRight;
	if (integrated_errorRight < -maxIntErrRight) integrated_errorRight = -maxIntErrRight;

	//once it passes near center zero out the integrator error
	if (rateErrorRight > 0) currentSignRight = 1;
	else currentSignRight = 0;

	//did we cross zero?
	if (currentSignRight - prevSignRight) integrated_errorRight = 0; //zero out the integrator
	prevSignRight = currentSignRight;  //save a copy for next time
  
	iValueRight = KiRight * integrated_errorRight;  
	if (iValueRight > maxIntegralValueRight) iValueRight = maxIntegralValueRight;
	if (iValueRight < -maxIntegralValueRight) iValueRight = -maxIntegralValueRight;

	//Derivative
	dErrorRight = rateErrorRight - lastLastErrorRight;
	dValueRight = KdRight * (dErrorRight) * KoRight;
  
	//save history of errors
	lastLastErrorRight = lastErrorRight;
	lastErrorRight = rateErrorRight;

	driveRight = pValueRight + dValueRight + iValueRight;

	pwmDriveRight = (constrain(driveRight, -255, 255));

	//add throttle factor so no delay from motor resistance.
	if (pwmDriveRight < 0 ) pwmDriveRight -= minPWMValueRight;
	else if (pwmDriveRight > 0 ) pwmDriveRight += minPWMValueRight;
  
	//if (pwmDriveRight > 200) pwmDriveRight = 200;
	//if (pwmDriveRight < -200) pwmDriveRight = -200;
 }

 void motorDriveRight(void) // prepared for IBT_2
  {
    pwmDisplayRight = pwmDriveRight;
    
    if (pwmDriveRight >= 0) 
	{
      analogWrite(PWM2_PIN, pwmDriveRight);
      analogWrite(DIR2_PIN, 0);   //Set DIR PIN low
    }
    
    else if (pwmDriveRight <= 0)
    {
      pwmDriveRight = -1 * pwmDriveRight;  
      analogWrite(DIR2_PIN, pwmDriveRight);
      analogWrite(PWM2_PIN, 0);//Set PWM PIN low
    }
  }
