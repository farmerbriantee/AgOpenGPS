  //##########################################################################################################
  //### Setup Zone ###########################################################################################
  //##########################################################################################################
  
  #define Output_Driver 2       // 1 =  Steering Motor + Cytron MD30C Driver
                                // 2 =  Steering Motor + IBT 2  Driver
                                // 3 =  PWM 2-Coil Valve + IBT_2 Driver
                                // 4 =  Danfoss Valve PVE A/H/M + IBT_2 Driver

  #define ADC_Mode 0            //0 = No ADS installed, Wheel Angle Sensor connected directly to Arduino at A0
                                //2 = ADS1115 Differential Mode - Connect Sensor GND to A1, Signal to A0
                               
  #define SteerPosZero 512      //vary this to get near 0 degrees when wheels are straight forward    
                                //with Arduino ADC start with 512 (0-1024)
                                //with ADS start with 13000  (possible Values are 0-26000 Counts) 
                               
  #define Invert_WAS 0          // set to 1 to Change Direction of Wheel Angle Sensor - to +                      
  
  #define IMU_Installed  0      // set to 1 to enable BNO055 IMU
  
  #define Inclinometer_Installed 0      // set to 1 if DOGS2 Inclinometer is installed
                                        // set to 2 if MMA8452 is installed (Address 0x1C) (SA0=LOW)
                                        // set to 3 if MMA8452 is installed (Address 0x1D) (SA0=HIGH, Sparkfun)

  #define SWEncoder  0          // Steering Wheel ENCODER Installed
  #define pulseCountMax 3       // Switch off Autosteer after X Pulses from Steering wheel encoder  
  
  #define Relay_Type 0          // set to 0 if up to 8 Section Relays will be used
                                // set to 1 if up to 8 uTurn Relays will be used (only Serial Mode)
  
  //Ethernet Details
  #define EtherNet 0            // 0 = Serial/USB communcation with AOG
                                // 1 = Ethernet comunication with AOG (using a ENC28J60 chip)
  
  #define CS_Pin 10             // Arduino Nano= 10 depending how CS of Ethernet Controller ENC28J60 is Connected

  #define maxspeed  20          // km/h  above -> steering off
  #define minspeed  1           // km/h  below -> sterring off (min = 0.25)
  //##########################################################################################################
  //### End of Setup Zone ####################################################################################
  //##########################################################################################################

  // !! Attention!! New unified Pin Configuration
  #define encAPin     2   //PD2 int0  Steering Wheel Encoder - turns Autosteer off
  #define STEERSW_PIN 3   //PD3 button toggles Autosteer Mode (momentary switch)
  #define WORKSW_PIN  4   //PD4 Turn On/Off mark Switch (toggle switch)
  #define PWM_PIN     5   //PD5 Motor=PWM       //PWM Valve= Coil 1 right // Danfoss= Control PWM
  #define DIR_PIN     6   //PD6 Motor=direction //PWM Valve= Coil 2 left  // Danfoss= Valvepower
  #define LED_PIN     7   //PD7 Autosteer LED
  #define W_A_S      A0   //Wheel Angle Sensor w.o.ADS
  #define Dogs2_Roll A1   //EADOGS2    
  //ethercard 10,11,12,13   
  #define RELAY1_PIN 8   //PB0
  #define RELAY2_PIN 9   //PB1
  #define RELAY3_PIN A2  //PC2
  #define RELAY4_PIN A3  //PC3
  //#define RELAY5_PIN 10  //PB2  serial Mode only
  //#define RELAY6_PIN 11  //PB3  serial Mode only
  //#define RELAY7_PIN 12  //PB4  serial Mode only
  //#define RELAY8_PIN 13  //PB5  serial Mode only


  #define EEP_Ident 0xEDFE

  #include <Wire.h>       
  #include <EEPROM.h>

#if (EtherNet)
  #include <EtherCard.h>
  #include <IPAddress.h> 

  //Ethernet Communication
  static byte myip[]  = { 192, 168, 1, 77 }; // ethernet interface ip address
  static byte gwip[]  = { 192, 168, 1, 1 }; // gateway ip address
  static byte myDNS[] = { 8, 8, 8, 8 };    //DNS- you just need one anyway
  static byte mask[]  = { 255, 255, 255, 0 }; //mask
  unsigned int portMy = 5577;              //this is port of this module Autosteer = 5577
  
  //sending back to where and which port
  static byte ipDestination[] = {192, 168, 1, 255};
  unsigned int portDestination = 9999; //AOG port that listens

  // ethernet mac address - must be unique on your network
  static byte mymac[] = { 0x70,0x69,0x69,0x2D,0x30,0x31 };
 
  //Array to send data back to AgOpenGPS
  byte toSend[] = {0,0,0,0,0,0,0,0,0,0};
  // udp send and receive buffer
  byte Ethernet::buffer[200]; 
#endif  

#if ADC_Mode==2
  #include "Adafruit_ADS1015.h"
  Adafruit_ADS1115 ads; // Use this for the 16-bit version ADS1115
#endif

#if Inclinometer_Installed ==2 | Inclinometer_Installed ==3
    #include "MMA8452_AOG.h"  // MMA8452 (1) Inclinometer
    #if Inclinometer_Installed == 3
      MMA8452 accelerometer(0x1D); // SA0=HIGH
    #else
      MMA8452 accelerometer;       //Default=0x1C (SA=LOW)
    #endif
#endif

#if IMU_Installed
  #include "BNO055_AOG.h"  // BNO055 IMU
  #define A 0X28             //I2C address selection pin LOW
  #define B 0x29             //                          HIGH
  #define RAD2GRAD 57.2957795
  BNO055 IMU(A);  // create an instance
#endif
  

  //Variables   
  struct Storage {
    float Ko = 0.0f;  //overall gain
    float Kp = 0.0f;  //proportional gain
    float Ki = 0.0f;//integral gain
    float Kd = 0.0f;  //derivative gain 
    float steeringPositionZero = SteerPosZero;
    byte minPWMValue=10;
    int maxIntegralValue=20;//max PWM value for integral PID component
    float steerSensorCounts=20;
    byte oldsteerzero=0;  // stores old Steerzerovalue
  };  Storage steerSettings;

  //loop time variables in microseconds
  const unsigned int LOOP_TIME = 100; //100hz 
  unsigned int lastTime = LOOP_TIME;
  unsigned int currentTime = LOOP_TIME;
  unsigned int dT = 50000;
  byte count = 0;
  byte watchdogTimer = 0;
  byte serialResetTimer = 0; //if serial buffer is getting full, empty it
  
  //Kalman variables
  float rollK = 0, Pc = 0.0, G = 0.0, P = 1.0, Xp = 0.0, Zp = 0.0;
  float XeRoll = 0;
  const float varRoll = 0.1; // variance
  const float varProcess = 0.00025; //smaller is more filtering

  //program flow
  bool isDataFound = false, isSettingFound = false, MMAinitialized = false;
  int header = 0, tempHeader = 0, temp, EEread = 0;
  bool steerEnable = false;
  int buttonState;             // the current reading from the Autosteer Button
  int lastButtonState = HIGH;   // the previous reading from the Autosteer Button
  unsigned long lastDebounceTime = 0;  // the last time the output was toggled

  byte relay = 0, uTurn = 0, workSwitch = 0, steerSwitch = 1, switchByte = 0;
  float distanceFromLine = 0, corr = 0, speeed = 0;
  float olddist = 0;
  
  //steering variables
  float steerAngleActual = 0;
  int steerPrevSign = 0, steerCurrentSign = 0; // the steering wheels angle currently and previous one
  float steerAngleSetPoint = 0; //the desired angle from AgOpen
  long steeringPosition = 0, actualSteerPos; //from steering sensor
  float steerAngleError = 0; //setpoint - actual
  float distanceError = 0; //
  volatile int pulseCount = 0; // Steering Wheel Encoder

  //inclinometer variables
  int roll = 0;
  uint16_t x_ , y_ , z_;

  //pwm variables
  int pwmDrive = 0, drive = 0, pwmDisplay = 0, pwmOut = 0;
  float pValue = 0, iValue = 0, dValue = 0;
  //byte minPWMValue = 10; //moved to structure
  
  //integral values - **** change as required *****
  //int   maxIntErr = 200; //anti windup max
  int maxIntegralValue = 20; //max PWM value for integral PID component 

  //error values
  //float lastError = 0, lastLastError = 0, integrated_error = 0, dError = 0;
   
  
void setup()
{ 
  //keep pulled high and drag low to activate, noise free safe    
  pinMode(WORKSW_PIN, INPUT_PULLUP);   //Pin D4 PD4
  pinMode(STEERSW_PIN, INPUT_PULLUP);  //Pin 11 PD3  

  //preset Outputs
  pinMode(DIR_PIN, OUTPUT); // direction pin of PWM Board
  pinMode(PWM_PIN, OUTPUT);
  pinMode(LED_PIN, OUTPUT);  
  pinMode(RELAY1_PIN, OUTPUT); //configure RELAY1 for output
  pinMode(RELAY2_PIN, OUTPUT); //configure RELAY2 for output
  pinMode(RELAY3_PIN, OUTPUT); //configure RELAY3 for output
  pinMode(RELAY4_PIN, OUTPUT); //configure RELAY4 for output
  //pinMode(RELAY5_PIN, OUTPUT); //configure RELAY5 for output
  //pinMode(RELAY6_PIN, OUTPUT); //configure RELAY6 for output
  //pinMode(RELAY7_PIN, OUTPUT); //configure RELAY7 for output
  //pinMode(RELAY8_PIN, OUTPUT); //configure RELAY8 for output
  
  //set up communication
  Wire.begin();
  Serial.begin(38400);

#if IMU_Installed  // BNO055 init
  IMU.init();
  // Restore calibration data from zeroing
  bno055_offsets_t calibrationData;
  calibrationData.accel_offset_x = 65520;
  calibrationData.accel_offset_y = 65421;
  calibrationData.accel_offset_z = 65421;
  calibrationData.gyro_offset_x = 65534;
  calibrationData.gyro_offset_y = 65533;
  calibrationData.gyro_offset_z = 1;
  calibrationData.mag_offset_x = 65305;
  calibrationData.mag_offset_y = 119;
  calibrationData.mag_offset_z = 65418;
  calibrationData.accel_radius = 1000;
  calibrationData.mag_radius = 979;
  IMU.setSensorOffsets(calibrationData);
  //use external 32K crystal
  IMU.setExtCrystalUse(true);
#endif  

#if Inclinometer_Installed ==2 | Inclinometer_Installed ==3
  // MMA8452 (1) Inclinometer
  MMAinitialized = accelerometer.init();
  if (MMAinitialized){
	  accelerometer.setDataRate(MMA_800hz);
    accelerometer.setRange(MMA_RANGE_8G);
    accelerometer.setHighPassFilter(false); 
  }
  else Serial.println("MMA init fails!!");
#endif

  //PWM rate settings Adjust to desired PWM Rate
  //TCCR1B = TCCR1B & B11111000 | B00000010;    // set timer 1 divisor to     8 for PWM frequency of  3921.16 Hz
  TCCR1B = TCCR1B & B11111000 | B00000011;    // set timer 1 divisor to    64 for PWM frequency of   490.20 Hz (The DEFAULT)

#if (EtherNet)
  if (ether.begin(sizeof Ethernet::buffer, mymac, CS_Pin) == 0)
    Serial.println(F("Failed to access Ethernet controller"));
  
  //set up connection
  ether.staticSetup(myip, gwip, myDNS, mask); 
  ether.printIp("IP:  ", ether.myip);
  ether.printIp("GW:  ", ether.gwip);
  ether.printIp("DNS: ", ether.dnsip);

  //set up the pgn for returning data for autosteer
  toSend[0] = 0x7F;
  toSend[1] = 0xFD;
  
  //register udpSerialPrint() to port 8888.
  ether.udpServerListenOnPort(&udpSteerRecv, 8888);
#endif

  // Reset Output
  digitalWrite(LED_PIN, 0); // Turn off Autosteer LED
  digitalWrite(DIR_PIN, 0); // Set Motordir to left //turn off PWM Coil 2 // Turn off Danfoss Valve
  pwmDrive = 0;       // turn Motor off       //turn off PWM Coil 1 // Center Danfoss Valve
  motorDrive();
  
  //Setup Interrupt -Steering Wheel encoder + SteerSwitchbutton
  attachInterrupt(digitalPinToInterrupt(encAPin), EncoderISR, FALLING);// Hardware IRQ 0
  //attachInterrupt(digitalPinToInterrupt(STEERSW_PIN), Steersw_ISR, FALLING);// Hardware IRQ 1
  
  interrupts();                      // Enable interrupts
 
EEPROM.get(0, EEread);              // read identifier
 if (EEread != EEP_Ident){           // check on first start and write EEPROM
    EEPROM.put(0, EEP_Ident);
    EEPROM.put(2, SteerPosZero);
    EEPROM.put(8, steerSettings);   
  }
 else 
  { 
    EEPROM.get(8, steerSettings);     // read the Settings
    EEPROM.get(2, EEread);            // read SteerPosZero
    if (EEread != SteerPosZero){
      EEPROM.put(2, SteerPosZero);    // if changed , rewrite
      steerSettings.steeringPositionZero = (SteerPosZero);  //use new steering zero offset now
      EEPROM.put(8, steerSettings);   
    }
  }
} // End of Setup



void loop()
{ /*
      Loop triggers every 100 msec and sends back gyro heading, and roll, steer angle etc
      All imu code goes in the loop
       Determine the header value and set the flag accordingly
       Then the next group of serial data is according to the flag
       Process accordingly updating values
  */

  currentTime = millis();
  unsigned int time = currentTime;

  if (currentTime - lastTime >= LOOP_TIME)
  {
    dT = currentTime - lastTime;
    lastTime = currentTime;

#if IMU_Installed   // BNO055 IMU
   IMU.readIMU();
#endif

    //If connection lost to AgOpenGPS, the watchdog will count up and turn off steering
    if (watchdogTimer++ > 250) watchdogTimer = 12;

#if Inclinometer_Installed ==1  //DOGS2 inclinometer
    delay(1);
    analogRead(Dogs2_Roll); //discard
    delay(1);
    roll = analogRead(Dogs2_Roll);   delay(1);
    roll += analogRead(Dogs2_Roll);   delay(1);
    roll += analogRead(Dogs2_Roll);   delay(1);
    roll += analogRead(Dogs2_Roll);
    roll = roll >> 2; //divide by 4
    //inclinometer goes from -25 to 25 from 0.5 volts to 4.5 volts
    rollK = map(roll, 0, 1023, -400, 400); //16 counts per degree

#endif

#if Inclinometer_Installed ==2 | Inclinometer_Installed ==3   // MMA8452 (1) Inclinometer
  if (MMAinitialized){
    accelerometer.getRawData(&x_, &y_, &z_);
    roll=x_; //Conversion uint to int
    if (roll > 4200)  roll =  4200;
    if (roll < -4200) roll = -4200;
    rollK = map(roll,-4200,4200,-960,960); //16 counts per degree (good for 0 - +/-30 degrees)
  }
#endif
 
    //Kalman filter
    Pc = P + varProcess;
    G = Pc / (Pc + varRoll);
    P = (1 - G) * Pc;
    Xp = XeRoll;
    Zp = Xp;
    XeRoll = G * (rollK - Zp) + Xp;

    workSwitch = digitalRead(WORKSW_PIN);  // read work switch
    steerSwitch = steerEnable;  //take the Enable status as indicator of mode
    if (pulseCount >= pulseCountMax ) steerSwitch = 0; // from Steeringwheel encoder
    steerSwitch <<= 1; //put steerswitch status in bit 1 position
    switchByte = 0;
    switchByte = workSwitch | steerSwitch;

#if Relay_Type==0
    SetRelays();       //turn on off section relays
#else
    SetuTurnRelays();  //turn on off uTurn relays
#endif

    //steering position and steer angle
#if ADC_Mode==0
    analogRead(W_A_S); //discard initial reading // Arduino ADC     
    steeringPosition = analogRead(W_A_S);    delay(1);
    steeringPosition += analogRead(W_A_S);    delay(1);
    steeringPosition += analogRead(W_A_S);    delay(1);
    steeringPosition += analogRead(W_A_S);
#endif  
#if ADC_Mode==2    
    steeringPosition = ads.readADC_Differential_0_1();    delay(2);    //ADS1115 Differential Mode 
    steeringPosition += ads.readADC_Differential_0_1();   delay(2);    //Connect Sensor GND to A1
    steeringPosition += ads.readADC_Differential_0_1();   delay(2);    //Connect Sensor Signal to A0
    steeringPosition += ads.readADC_Differential_0_1();
#endif 
   
    steeringPosition = steeringPosition >> 2; //divide by 4 
    actualSteerPos=steeringPosition;  // stored for >zero< Funktion  

    steeringPosition = (steeringPosition - steerSettings.steeringPositionZero);   //center the steering position sensor

    //convert position to steer angle. 6 counts per degree of steer pot position in my case
    //  ***** make sure that negative steer angle makes a left turn and positive value is a right turn *****
    // remove or add the minus for steerSensorCounts to do that.

#if Invert_WAS
    steerAngleActual = (float)(steeringPosition) /   steerSettings.steerSensorCounts;
#else
    steerAngleActual = (float)(steeringPosition) / - steerSettings.steerSensorCounts;
#endif

#if Inclinometer_Installed != 0
    steerAngleActual = steerAngleActual - (XeRoll * (steerSettings.Kd/800));     // add the roll
#endif

   //close enough to center, remove any correction
   //if (distanceFromLine < 40 && distanceFromLine > -40) steerAngleSetPoint = 0;
   if (distanceFromLine <= 40 && distanceFromLine >= -40) corr = 0;
   else
    {
      //use the integal value to adjust how much per cycle it increases
      corr += steerSettings.Ki;

      //provide a limit - the old max integral value
      if (corr > maxIntegralValue) corr = maxIntegralValue;

      //now add the correction to fool steering position
      if (distanceFromLine > 40)
        {
         steerAngleSetPoint -= corr;
        }
      else
        {
         steerAngleSetPoint += corr;
        }
     }
           

//debug Plotter
 //Serial.print(rollK/16);             // Inclinometer before kalman
 //Serial.print(" ");                  //
 //Serial.print(XeRoll/16);            // Inclinometer after kalman
 //Serial.print(" ");                  //
 //Serial.print(steerAngleActual);     // Steer Angle Sensor
 //Serial.print(" ");                  //
 //Serial.print(IMU.euler.head/16);    // Heading from IMU in degree
 //Serial.print(" ");                  //
 //Serial.print(steerSettings.Kd);     // 
 //Serial.println(); // End of line 
   


    // Send Data to AOG
#if (EtherNet)
    transmitEthernet(); 
#else
    transmitSerial();
#endif

//Debug Print Processor load
//Serial.print("Timed Loop time: ");  
//Serial.println(millis()-lastTime);

  } //end of timed loop


#if (EtherNet)
  delay(10); 
  //this must be called for ethercard functions to work.
  ether.packetLoop(ether.packetReceive());  
#else
  receiveSerial();
#endif
    
  if (watchdogTimer < 10)
    {
      steerAngleError = steerAngleActual - steerAngleSetPoint;   //calculate the steering error 
      calcSteeringPID();   //do the pid     
      motorDrive();       //out to motors the pwm value     

    }
  else
    {
      //we've lost the comm to AgOpenGPS 
      pwmDrive = 0; //turn off steering motor
      motorDrive(); //out to motors the pwm value   
      pulseCount=0; //Reset counter if Autosteer is offline    
    }

  int SteerswReading = digitalRead(STEERSW_PIN); //get actual button state
  if (SteerswReading != lastButtonState)    lastDebounceTime = millis();
  if ((millis() - lastDebounceTime) > 50) 
   {
    if (SteerswReading != buttonState) 
     {
      buttonState = SteerswReading;
      if (buttonState == LOW) steerEnable = !steerEnable; // toggle the Autosteer Mode on/off
      if (steerEnable) watchdogTimer = 0;
     }
   } 
  lastButtonState = SteerswReading; 
}//end of main loop



//ISR Steering Wheel Encoder
  void EncoderISR()
  {       
    #if (SWEncoder)      
     if (digitalRead(encAPin)==0) // decide if external triggered  
       {
         pulseCount++; 
       }
    #endif     
  } 
   
