void calcDistancePID(void) {
  
  //proportional
  pValue = Kp * distanceError;
  
  //Integral
  integrated_error = integrated_error + distanceError;
  if (integrated_error > maxErr) integrated_error = maxErr;
  if (integrated_error < -maxErr) integrated_error = -maxErr;

  //once it passes near center zero out the integrator error
  if (abs(distanceError) < 2) integrated_error = 0;
  iValue = Ki * integrated_error;

  //Derivative
  if (abs(distanceError) > 2) 
  dError = distanceError - lastError;
  dValue = Kd * (dError);
  
  //save history of errors
  lastLastError = lastError;
  lastError = distanceError;

  drive = (pValue + iValue + dValue)*Ko;
  pwmDrive = int(constrain(drive, -255, 255));

  //if (pwmDrive < 0 & pwmDrive > -255) pwmDrive = pwmDrive - 6;
  //else if (pwmDrive > 0 & pwmDrive < 255) pwmDrive = pwmDrive + 6;
}

 void motorDrive(void) 
  {
    if (pwmDrive > 0) bitSet(PORTB, 4);  //set the correct direction
    else   
    {
      bitClear(PORTB, 4); 
      pwmDrive = -1 * pwmDrive;  
   }
    analogWrite(PWM_PIN, pwmDrive);
  }



void setup()
{
  pinMode(LED_PIN, OUTPUT); //configure LED for output
  pinMode(RELAY1_PIN, OUTPUT); //configure RELAY1 for output //Pin 5
  pinMode(RELAY2_PIN, OUTPUT); //configure RELAY2 for output //Pin 6
  pinMode(RELAY3_PIN, OUTPUT); //configure RELAY3 for output //Pin 7
  pinMode(RELAY4_PIN, OUTPUT); //configure RELAY4 for output //Pin 8
  pinMode(RELAY5_PIN, OUTPUT); //configure RELAY5 for output //Pin 9
  pinMode(RELAY6_PIN, OUTPUT); //configure RELAY6 for output //Pin 10
  pinMode(RELAY7_PIN, OUTPUT); //configure RELAY7 for output //Pin A4
  pinMode(RELAY8_PIN, OUTPUT); //configure RELAY8 for output //Pin A5
  
  pinMode(DIR_PIN, OUTPUT); //D11 PB3 direction pin of PWM Board
      
  pinMode(WORKSW_PIN, INPUT_PULLUP);   //Pin D4 PD4
    
  Serial.begin(19200);  //open serial port
   
  //PWM rate settings Adjust to desired PWM Rate
  //TCCR1B = TCCR1B & B11111000 | B00000001;    // set timer 1 divisor to     1 for PWM frequency of 31372.55 Hz
  //TCCR1B = TCCR1B & B11111000 | B00000010;    // set timer 1 divisor to     8 for PWM frequency of  3921.16 Hz
  TCCR1B = TCCR1B & B11111000 | B00000011;    // set timer 1 divisor to    64 for PWM frequency of   490.20 Hz (The DEFAULT)
  //TCCR1B = TCCR1B & B11111000 | B00000100;    // set timer 1 divisor to   256 for PWM frequency of   122.55 Hz
  //TCCR1B = TCCR1B & B11111000 | B00000101;    // set timer 1 divisor to  1024 for PWM frequency of    30.64 Hz
} 
