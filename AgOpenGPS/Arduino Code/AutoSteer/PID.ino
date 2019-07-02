void calcSteeringPID(void) 
  {
  
    //Proportional
    pValue = Kp * steerAngleError *Ko;    
  
    pwmDrive = (constrain(pValue, -255, 255));
  
    //add throttle factor so no delay from motor resistance.
    if (pwmDrive < 0 ) pwmDrive -= minPWMValue;
    else if (pwmDrive > 0 ) pwmDrive += minPWMValue;
    
    if (pwmDrive > 230) pwmDrive = 230;
    if (pwmDrive < -230) pwmDrive = -230;
  }

 void motorDrive(void) 
  {
    pwmDisplay = pwmDrive;

    if (SteerMotorDirectionBackwards)
    {
      if (pwmDrive >= 0) bitClear(PORTD, 4);  //set the correct direction
      else   
      {
        bitSet(PORTD, 4); 
        pwmDrive = -1 * pwmDrive;  
      }
    }
    
    else
    {
      if (pwmDrive >= 0) bitSet(PORTD, 4);  //set the correct direction
      else   
      {
        bitClear(PORTD, 4); 
        pwmDrive = -1 * pwmDrive;  
      }
    }
    analogWrite(PWM_PIN, pwmDrive);
  }


