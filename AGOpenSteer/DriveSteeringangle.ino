 void DriveSteeringAngle(void) 
{
   if(DC) //Used with single DC motor
    {
       
      //add throttle factor so no delay from motor resistance.
      if (pwmDrive < 0 ) pwmDrive -= minPWMValue;
      else if (pwmDrive > 0 ) pwmDrive += minPWMValue;
      //Limit max PWM
      if (pwmDrive > 200) pwmDrive = 200;
      if (pwmDrive < -200) pwmDrive = -200;
      
      if (steerEnable == false) pwmDrive=0;
     
      pwmDisplay = pwmDrive;
      
      if (pwmDrive > 0) //Clockwise
      {
        digitalWrite(8, LOW); 
        digitalWrite(7, HIGH);
        }
      else if (pwmDrive < 0) //Counter ClockWise
      {
        digitalWrite(7, LOW);
        digitalWrite(8, HIGH); 
        pwmDrive = -pwmDrive;
       }
       else  // turn off
      {
        digitalWrite(7, LOW);  
        digitalWrite(8, LOW); 
       }
       
      analogWrite(5, pwmDrive); //Set motor pwm

    }


    else if(DCDUAL) //Used with single DC motor
    {
       
      //add throttle factor so no delay from motor resistance.
      if (pwmDrive < 0 ) pwmDrive -= minPWMValue;
      else if (pwmDrive > 0 ) pwmDrive += minPWMValue;
      //Limit max PWM
      if (pwmDrive > 200) pwmDrive = 200;
      if (pwmDrive < -200) pwmDrive = -200;
      
      if (steerEnable == false) pwmDrive=0;
     
      pwmDisplay = pwmDrive + speeed;
      
      if (pwmDrive > 0) //Clockwise
      {
        digitalWrite(7, HIGH);
        digitalWrite(8, LOW); 
        digitalWrite(4, LOW); 
        digitalWrite(9, HIGH);
        analogWrite(5, speeed + pwmDrive); //Set motor1 pwm
        analogWrite(6, speeed - pwmDrive); //Set motor2 pwm
        }
      else if (pwmDrive < 0) //Counter ClockWise
      {
        digitalWrite(7, HIGH);
        digitalWrite(8, LOW); 
        digitalWrite(4, LOW); 
        digitalWrite(9, HIGH);
        pwmDrive = -pwmDrive;
        analogWrite(5, speeed - pwmDrive); //Set motor1 pwm
        analogWrite(6, speeed + pwmDrive); //Set motor2 pwm
       }
       else if (speeed = 0) //Stop driving
      {
        digitalWrite(4, LOW); 
        digitalWrite(7, LOW);  
        digitalWrite(8, LOW);
        digitalWrite(9, LOW);
        pwmDisplay =  speeed;
      }
       else  //Drive straight
      {
        digitalWrite(7, HIGH);
        digitalWrite(8, LOW); 
        digitalWrite(4, LOW); 
        digitalWrite(9, HIGH);
        analogWrite(5, speeed + minPWMValue); //Set motor1 pwm
        analogWrite(6, speeed + minPWMValue); //Set motor2 pwm
        pwmDisplay =  speeed + minPWMValue;
       }
    }
    
  else if(VALVE) //Used with 2-Coil PWM Valves
   {  
   
    if (steerEnable == false) pwmDrive=0;
     
    pwmDisplay = pwmDrive; 
    
    if (pwmDrive > 0)
      {
        //turn off coil 2
        digitalWrite(4, LOW); 
        digitalWrite(9, LOW);
        //enable coil 1
        digitalWrite(7, LOW); 
        digitalWrite(8, HIGH); 
      }
      else if (pwmDrive < 0)
      {
        pwmDrive = -pwmDrive; 
        //turn off coil 1
        digitalWrite(7, LOW); 
        digitalWrite(8, LOW);
        //enable coil 2
        digitalWrite(4, LOW); 
        digitalWrite(9, HIGH);
      }
       else  // turn all off
        {
        digitalWrite(4, LOW); 
        digitalWrite(7, LOW);  
        digitalWrite(8, LOW);
        digitalWrite(9, LOW); 
         }
         
      analogWrite(5, pwmDrive); //Set coil1 pwm
      analogWrite(6, pwmDrive); //Set coil2 pwm
      
   }  
   
  else if(DANFOSS) // Used with danfoss Valves
     {        // Danfoss: PWM 25% On = Left Position max  (below Valve=Center)
              // Danfoss: PWM 50% On = Center Position
              // Danfoss: PWM 75% On = Right Position max (above Valve=Center)
              
      int pwmFix = 0; // correct at Center to 50% Duty Cycle
  
      if (steerEnable == true) digitalWrite(7, HIGH); // turn on /off Power
      else 
        {
          digitalWrite(7, LOW);  
          pwmDrive=0;
        }
       
    
        pwmDrive = pwmDrive / 4;  
        pwmDisplay = pwmDrive+ 128 + pwmFix;  // add Center Pos.

    analogWrite(5, pwmDisplay);
  }



 else if(STEPPER) //Drive Stepper motor
  {
    if (steerEnable == false) pwmDrive=0;
    
    pwmDisplay = pwmDrive; 
  }


 else if(CANBUSSTEER) //Send canbus commands
  {
    if (steerEnable == false) pwmDrive=0;
    
    pwmDisplay = pwmDrive; 
  }

 else // Send 0 PWM 
  {
    pwmDisplay = 0; 
  }
}      
   



