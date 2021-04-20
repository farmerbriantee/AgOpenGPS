void calcSteeringPID(void)
{
    //Proportional only
    pValue = Set.Kp * steerAngleError;
    pwmDrive = (int)pValue;

    errorAbs = abs(steerAngleError);
    float newMax = 0;

    if (errorAbs < Set.MotorSlowDriveDegrees)
    {
        newMax = (errorAbs * highLowPerDeg) + Set.lowPWM;
    }
    else newMax = Set.highPWM;

    //add min throttle factor so no delay from motor resistance.
    if (pwmDrive < 0) pwmDrive -= Set.minPWM;
    else if (pwmDrive > 0) pwmDrive += Set.minPWM;

    //Serial.print(newMax); //The actual steering angle in degrees
    //Serial.print(",");

 //limit the pwm drive
    if (pwmDrive > newMax) pwmDrive = newMax;
    if (pwmDrive < -newMax) pwmDrive = -newMax;

    if (Set.MotorDriveDirection) pwmDrive *= -1;
    if (Set.debugmode) { Serial.print("PWM for output: ");  Serial.println(pwmDrive); }
}

//-------------------------------------------------------------------------------------------------
// select output Driver
//---------------------------------------------------------------------
void motorDrive(void) 
{
  switch (Set.output_type) {
    case 1:
      motorDrive_Cytron();
      break;
    case 2:
      motorDrive_IBT_Mot();
      break;
    case 3:
      motorDrive_IBT_PWM();
      break;
    case 4:
      motorDrive_IBT_Danfoss();
      break;
    default:
      // if nothing else matches no Output
    break;
  }
}
 
//---------------------------------------------------------------------
// Used with Cytron MD30C Driver
// Steering Motor
// Dir + PWM Signal
//---------------------------------------------------------------------
void motorDrive_Cytron(void) 
  {    
    pwmDisplay = pwmDrive;
    if (pwmDrive >= 0) ledcWrite(1, 255);  // channel 1 = DIR_PIN  //set the correct direction
    else   
    {
      ledcWrite(1, 0);  // channel 1 = DIR_PIN 
      pwmDrive = -1 * pwmDrive;  
   }
    ledcWrite(0, pwmDrive);  // channel 0 = PWM_PIN
  }


//---------------------------------------------------------------------
// Used with IBT 2  Driver
// Steering Motor
// PWM Left + PWM Right Signal
// Same Code as the PWM Valve
//---------------------------------------------------------------------
void motorDrive_IBT_Mot(void) 
  {   
   if (steerEnable == false) pwmDrive=0;
   
    pwmDisplay = pwmDrive; 
  
  if (pwmDrive > 0)
    {
      ledcWrite(0, pwmDrive);  // channel 0 = PWM_PIN
      ledcWrite(1, 0);
      //digitalWrite(DIR_PIN, LOW);
    }
    
  if (pwmDrive <= 0)
    {
      pwmDrive = -1 * pwmDrive;  
      ledcWrite(1, pwmDrive);  // channel 1 = DIR_PIN
      ledcWrite(0, 0);
      //digitalWrite(PWM_PIN, LOW);
    } 
  }

//---------------------------------------------------------------------
// Used with 2-Coil PWM Valves 
// No coil powered = Center
// Coil 1 steer right connected to PWM_PIN 11
// Coil 2 steer left  connected to DIR_PIN 10
//---------------------------------------------------------------------
void motorDrive_IBT_PWM(void)
 { 
  if (steerEnable == false) pwmDrive=0;
   
  pwmDisplay = pwmDrive; 
  
  if (pwmDrive > 0)
    {
      ledcWrite(0, pwmDrive);  // channel 0 = PWM_PIN
      ledcWrite(1, 0);
      //digitalWrite(DIR_PIN, LOW);
    }
    
  if (pwmDrive <= 0)
    {
      pwmDrive = -1 * pwmDrive;  
      ledcWrite(1, pwmDrive);  // channel 1 = DIR_PIN
      ledcWrite(0, 0);
      //digitalWrite(PWM_PIN, LOW);
    }
 }  

//---------------------------------------------------------------------
// Danfoss: PWM 25% On = Left Position max  (below Valve=Center)
// Danfoss: PWM 50% On = Center Position
// Danfoss: PWM 75% On = Right Position max (above Valve=Center)
//---------------------------------------------------------------------
void motorDrive_IBT_Danfoss(void) 
  { 
    if (pwmDrive >  250) pwmDrive =  250; 
    if (pwmDrive < -250) pwmDrive = -250;
  
 /* if (steerEnable) digitalWrite(DIR_PIN, HIGH); // turn on /off Power
  else 
    {
      digitalWrite(DIR_PIN, LOW);  
      pwmDrive=0;
    }*/
  if (steerEnable) ledcWrite(1, 255);  // channel 1 = DIR_PIN // turn on /off Power
  else 
    {
      ledcWrite(1, 0);
      pwmDrive=0;
    }
    pwmDrive = pwmDrive / 4;  
    pwmOut = pwmDrive+ 128;  // add Center Pos.
    pwmDisplay = pwmOut;
    ledcWrite(0, pwmOut);  // channel 0 = PWM_PIN
  }

 
