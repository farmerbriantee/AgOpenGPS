//pwm variables
  int pwmDrive = 0, pwmDisplay = 0;
  float pValue = 0, iValue = 0, dValue = 0, drive = 0, sumSpeed=0;
  byte minPWMValue = 10;
 
  //PID variables
  float Ko = 1.0f;  //overall gain
  float Kp = 1.0f;  //proportional gain
  float Ki = 0.0f;//integral gain
  float Kd = 0.0f;  //derivative gain 

   //integral values - **** change as required *****
  int   maxIntErr = 200; //anti windup max
  int maxIntegralValue = 20; //max PWM value for integral PID component 

  //error values
  float lastError = 0, lastLastError = 0, integrated_error = 0, dError = 0;

  
void calcRatePID(void) {
  
  //Proportional
  pValue = 0.35 * rateError;// *Ko;  
/*  
  //Integral
  integrated_error = integrated_error + rateError;
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
*/

  drive = pValue + dValue + iValue;

  sumSpeed+= drive;
  sumSpeed = (constrain(sumSpeed, 0, 50)); 
  
  pwmDrive = int(sumSpeed);
  pwmDisplay = pwmDrive;
 }

 void motorDrive(void) 
  {
    if (pwmDrive > 0) bitSet(PORTB, 4);  //set the correct direction   
    
    analogWrite(PWM_PIN, pwmDrive);
  }


