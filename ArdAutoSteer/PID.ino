/*
* Distance from Line -30,000 to +30,000 from AgOpenGPS
* Distance is in millimters no matter units setting in AgOpen
* 
* Delta is the difference between your heading and guidance line heading
* Delta is in radians * 10000
* -15,700 to +15,700 is Delta
* 
*/
//PID variables
float   Ko = 1.0f;
float   Kp = 0.1f;
float   Ki = 0.08f;
float   Kd = 3.0f;
int maxErr = 1550;
float pValue = 0;
float drive = 0;

void calcDistancePID(void) {

	//proportional
	pValue = Kp * distanceError;
	
	//Integral
	//integrated_error = integrated_error + pitchError;
	//if (integrated_error > maxErr) integrated_error = maxErr;
	//if (integrated_error < -maxErr) integrated_error = -maxErr;

	//once it passes near center zero out the integrator error
	//if (abs(robotPitch) < 2) integrated_error = 0;
	//iValue = Ki * integrated_error;

	//Derivative
	//if (abs(robotPitch) > 2) 
	//dError = pitchError - lastLastError;
	//dValue = Kd * (dError);
	
	//save history of errors
	//lastLastError = lastError;
	//lastError = pitchError;

	//drive = (pValue + iValue + dValue)*Ko;
  drive = (pValue)* Ko;

	pwmDrive = int(constrain(drive, -255, 255));


	if (pwmDrive < 0 & pwmDrive > -255) pwmDrive = pwmDrive - 6;
	else if (pwmDrive > 0 & pwmDrive < 255) pwmDrive = pwmDrive + 6;
}


