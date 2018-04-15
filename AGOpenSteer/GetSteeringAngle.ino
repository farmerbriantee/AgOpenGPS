void GetSteeringAngle(void) {

  if(ANALOG) //Get steeringPosition from analog sensor
      {
        //steering position and steer angle
        analogRead(A0); //discard initial reading
        steeringPosition = analogRead(A0);    delay(4*PRESCALER);
        steeringPosition += analogRead(A0);    delay(4*PRESCALER);
        steeringPosition += analogRead(A0);    delay(4*PRESCALER);
        steeringPosition += analogRead(A0);    
        steeringPosition = steeringPosition >> 2; //divide by 4    
        steeringPosition = ( steeringPosition - steeringPositionZero + XeRoll/16.0);   //read the steering position sensor
        //steeringPosition = ( steeringPosition - steeringPositionZero);   //read the steering position sensor
        
        //convert position to steer angle. 6 counts per degree of steer pot position in my case
        //  ***** make sure that negative steer angle makes a left turn and positive value is a right turn *****
        // remove or add the minus for steerSensorCounts to do that.
        steerAngleActual = (float)(steeringPosition)/-steerSensorCounts;   
    }
 
  else if(QUADRATURE) //Get steeringPosition from Quadrature encoder
      {
      steerAngleActual=(float)(encCount);
    }
    
  else if(ISOBUSANGLE) //Get steeringPosition from for CANBUS
    {        
      //Get steeringPosition from for CANBUS (recieved outside timed loop)
      steerAngleActual=steerAngleActual;
    }
    
  else //Set 0 degree steering angle
    {
      steerAngleActual = 0; 
    }  
  
  }

