void calcSteeringPID(void) 
 {
  
  //Proportional
  pValue = steerSettings.Kp * steerAngleError *steerSettings.Ko;    

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
  if (pwmDrive < 0 ) pwmDrive -= steerSettings.minPWMValue;
  else if (pwmDrive > 0 ) pwmDrive += steerSettings.minPWMValue;
  
  if (pwmDrive > 255) pwmDrive = 255;
  if (pwmDrive < -255) pwmDrive = -255;

#ifdef JRK_2_POLOLU 
  pValue = steerAngleSetPoint * steerSettings.steerSensorCounts + steerZero;
  pwmDrive=1; //  !=0
#endif
 }

//#########################################################################################

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

#if (Output_Driver == 3) //Steering Motor + JRK2 Pololu Driver
 void motorDrive(void) 
   {// Used with JRK 2  Driver
    // Steering Motor
 
    if (pwmDrive == 0) jrk.stopMotor();
    else jrk.setTarget(pValue);
   }   
#endif
