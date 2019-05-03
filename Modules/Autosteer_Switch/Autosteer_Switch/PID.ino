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
 
#if (Output_Invert == 1) 
  pwmDrive *= -1;
#endif
 
#if (Output_Driver == 3) // JRK2 Pololu Driver
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


#if (Output_Driver == 2) //Steering Motor + IBT_2 Driver
void motorDrive(void) 
  {// Used with IBT 2  Driver
   // Steering Motor
   // PWM Left + PWM Right Signal
   
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

#if (Output_Driver == 3) //Steering Motor + JRK2 Pololu Driver
 void motorDrive(void) 
   {// Used with JRK 2  Driver
    // Steering Motor
 
    if (pwmDrive == 0) jrk.stopMotor();
    else jrk.setTarget(pValue);
   }   
#endif
