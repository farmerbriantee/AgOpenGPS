  
void calcRatePIDLeft(void) {
  
	//Proportional
	pValueLeft = 0.5 * rateErrorLeft; 

	//Integral
	integrated_errorLeft = integrated_errorLeft + rateErrorLeft;
	if (integrated_errorLeft > maxIntErrLeft) integrated_errorLeft = maxIntErrLeft;
	if (integrated_errorLeft < -maxIntErrLeft) integrated_errorLeft = -maxIntErrLeft;

	//once it passes near center zero out the integrator error
	if (rateErrorLeft > 0) currentSignLeft = 1;
	else currentSignLeft = 0;

	//did we cross zero?
	if (currentSignLeft - prevSignLeft) integrated_errorLeft = 0; //zero out the integrator
	prevSignLeft = currentSignLeft;  //save a copy for next time
  
	iValueLeft = KiLeft * integrated_errorLeft;  
	if (iValueLeft > maxIntegralValueLeft) iValueLeft = maxIntegralValueLeft;
	if (iValueLeft < -maxIntegralValueLeft) iValueLeft = -maxIntegralValueLeft;

	//Derivative
	dErrorLeft = rateErrorLeft - lastLastErrorLeft;
	dValueLeft = KdLeft * (dErrorLeft) * KoLeft;
  
	//save history of errors
	lastLastErrorLeft = lastErrorLeft;
	lastErrorLeft = rateErrorLeft;

	driveLeft = pValueLeft + dValueLeft + iValueLeft;

	pwmDriveLeft = (constrain(driveLeft, -255, 255));

	//add throttle factor so no delay from motor resistance.
	if (pwmDriveLeft < 0 ) pwmDriveLeft -= minPWMValueLeft;
	else if (pwmDriveLeft > 0 ) pwmDriveLeft += minPWMValueLeft;
  
	//if (pwmDriveLeft > 200) pwmDriveLeft = 200;
	//if (pwmDriveLeft < -200) pwmDriveLeft = -200;
 }


 void motorDriveLeft(void)  // prepared for IBT_2
  {
    pwmDisplayLeft = pwmDriveLeft;
   
    if (pwmDriveLeft >= 0) 
    {
      analogWrite(PWM1_PIN, pwmDriveLeft);
      analogWrite(DIR1_PIN, 0);   //Set DIR PIN low
    }
    
    else if (pwmDriveLeft <= 0)
    {
      pwmDriveLeft = -1 * pwmDriveLeft;  
      analogWrite(DIR1_PIN, pwmDriveLeft);
      analogWrite(PWM1_PIN, 0);//Set PWM PIN low
    } 
  }
