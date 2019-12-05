//##########################################################################################################
//### Setup Zone ###########################################################################################
//##########################################################################################################

  #define GPS_Refresh 10                 // Enter the Hz refresh rate, example 5 or 10 or 8 with ublox
                                         // Best is leave it at 10
                                        
  #define Motor_Valve_Driver_Board 1    // 1 =  Steering Motor/valves + Cytron MD30C, MD13A Driver
                                        // 2 =  Steering Motor/valves + IBT 2  Driver
                                
  #define A2D_Convertor_Mode 1          // 0 = No ADS, connect Wheel Angle Sensor (WAS) to Arduino A0
                                            // Really try to use the ADS, it is much much better.
                                        // 1 = ADS1115 Single Input Mode - Connect Signal to A0
                                            // These sensors are DIY installed ones.
                                        // 2 = ADS1115 Differential Mode - Connect Sensor GND to A1, Signal to A0
                                            // These sensors are factory installed and powered by tractor oem wiring.
                                 
  #define WAS_Invert 0                  // set to 1 to Change Direction of Wheel Angle Sensor, must be positive turning right 
  
  #define Motor_Direction_Invert 0      // 1 = reverse output direction (Valve & Motor) 0 = Normal

  #define SwitchOrButton 0              // set to 0 to use steer switch as switch
                                        // set to 1 to use steer switch as button
                                        // Button/switch pulls pin low to activate
 
  #define BNO_Installed 0               // set to 1 to enable BNO055 IMU, otherwise set to 0 for none
  
  #define Inclinometer_Installed 0      // set to 0 for none
                                        // set to 1 if DOGS2 Inclinometer is installed and connected to ADS pin A2
                                        // set to 2 if MMA8452 installed GY-45 (1C)
                                        // set to 3 if MMA8452 installed Sparkfun, Adafruit MMA8451 (1D)
                                        // set to 4 if DOGS2 installed and connected to Arduino pin A1
                                                                           
                                        // Depending on board orientation, choose the right Axis for MMA, 
                                        // arrow shaft on MMA points in same direction as axle
  #define UseMMA_X_Axis 1               // Set to 0 to use X axis of MMA
                                        // Set to 1 to use Y axis of MMA

  #define Roll_Invert 0                 // Roll to the right must be positive
                                        // Set to 1 if roll to right shows negative, otherwise set to 0

  #define Relay_Type 0    // set to 0 for No Relays
                          // set to 1 for Section Relays
                          // set to 2 for uTurn Relays
  
  #define EtherNet 0      // 0 = Serial/USB communcation with AOG
                          // 1 = Ethernet comunication with AOG (using a ENC28J60 chip)
                          
  #define CS_Pin 10       // Arduino Nano = 10 depending how CS of Ethernet Controller ENC28J60 is Connected

  #define   MaxSpeed  20     // km/h  above -> steering off
  #define   MinSpeed  1      // km/h  below -> sterring off (minimum = 0.25)


  //##########################################################################################################
  //### End of Setup Zone ####################################################################################
  //##########################################################################################################

  ////////////////////   ***********  Motor drive connections  **************888
  //Connect ground only for cytron, Connect Ground and +5v for IBT2
  
  //Dir1 for Cytron Dir, Both L and R enable for IBT2
  #define DIR1_RL_ENABLE  4  //PD4

  //PWM1 for Cytron PWM, Left PWM for IBT2
  #define PWM1_LPWM  3  //PD3

  //Not Connected for Cytron, Right PWM for IBT2
  #define PWM2_RPWM  9 //D9

  //--------------------------- Switch Input Pins ------------------------
  #define STEERSW_PIN 6 //PD6
  #define WORKSW_PIN 7  //PD7
  #define REMOTE_PIN 8  //PB0

  // -------------------------- Arduino A/D Input Pins ------------------
  #define WAS_Ard_A0 A0  //PC0 Wheel Angle Sensor
  #define Dogs2_Roll A1  //PC1 DOGS2 Inclinometer
  
  //ethercard 10,11,12,13     

  #include <Wire.h>
  #include <EEPROM.h>

  #if (EtherNet)
    #include "EtherCard_AOG.h"
    #include <IPAddress.h> 
  
    //Array to send data back to AgOpenGPS
    byte toSend[] = {0,0,0,0,0,0,0,0,0,0};
  
    // ethernet interface ip address
    static byte myip[] = { 192,168,1,77 };
    // gateway ip address
    static byte gwip[] = { 192,168,1,1 };
    //DNS- you just need one anyway
    static byte myDNS[] = { 8,8,8,8 };
    //mask
    static byte mask[] = { 255,255,255,0 };
    //this is port of this autosteer module
    unsigned int portMy = 5577; 
  
    //sending back to where and which port
    static byte ipDestination[] = {192, 168, 1, 255};
    unsigned int portDestination = 9999; //AOG port that listens
    
    // ethernet mac address - must be unique on your network
    static byte mymac[] = { 0x70,0x69,0x69,0x2D,0x30,0x31 };
    
    byte Ethernet::buffer[200]; // udp send and receive buffer
  #endif  
  
  #if A2D_Convertor_Mode==1 | A2D_Convertor_Mode == 2
    #include "ADS1015.h"
    Adafruit_ADS1115 ads;     // Use this for the 16-bit version ADS1115
      #define SteerPosZero 1660 
  #else
    #define SteerPosZero 512
  #endif
  
 #if Inclinometer_Installed == 2 | Inclinometer_Installed == 3
    #include "MMA8452_AOG.h"  // MMA8452 (1) Inclinometer
    #if Inclinometer_Installed == 3
      MMA8452 MMA(0x1D);
    #else
      MMA8452 MMA(0x1C);
    #endif
    uint16_t x_ , y_ , z_;      
  #endif
  
  #if BNO_Installed
    #include "BNO055_AOG.h"  // BNO055 IMU
    #define A 0X28             //I2C address selection pin LOW
    #define B 0x29             //                          HIGH
    #define RAD2GRAD 57.2957795
    BNO055 IMU(A);  // create an instance
  #endif
  
  #define EEP_Ident 0xEDFE
  
   //Variables for settings  
   struct Storage {
      float Ko = 0.0f;  //overall gain
      float Kp = 0.0f;  //proportional gain
      float Ki = 0.0f;  //integral gain
      float Kd = 0.0f;  //derivative gain 
      float steeringPositionZero = (float)SteerPosZero;
      byte minPWMValue=10;
      int maxIntegralValue=20;//max PWM value for integral PID component

      // Set the intial steer sensor counts
      #if A2D_Convertor_Mode==1 | A2D_Convertor_Mode == 2
        float steerSensorCounts=30;      
      #else
        float steerSensorCounts=9;
      #endif      
  };  Storage steerSettings;
  
  //loop time variables in microseconds

  
  const unsigned int LOOP_TIME = 1000/GPS_Refresh;      
  unsigned int lastTime = LOOP_TIME;
  unsigned int currentTime = LOOP_TIME;
  unsigned int dT = 50000;
  byte count = 0;
  byte watchdogTimer = 20;
  byte serialResetTimer = 100; //if serial buffer is getting full, empty it
  
  //Kalman variables
  float rollK = 0, Pc = 0.0, G = 0.0, P = 1.0, Xp = 0.0, Zp = 0.0;
  float XeRoll = 0;
  const float varRoll = 0.1; // variance,
  const float varProcess = 0.0001; //smaller is more filtering

  //inclinometer variables
  int roll = 0;
  
  //Program flow
  bool isDataFound = false, isSettingFound = false, MMAinitialized = false;
  int header = 0, tempHeader = 0, temp, EEread = 0;
  byte relay = 0, uTurn = 0, remoteSwitch = 0, workSwitch = 0, steerSwitch = 1, switchByte = 0;
  float distanceFromLine = 0, corr = 0, gpsSpeed = 0;
  
  //steering variables
  float steerAngleActual = 0;
  float steerAngleSetPoint = 0; //the desired angle from AgOpen
  long steeringPosition = 0; //from steering sensor
  float steerAngleError = 0; //setpoint - actual
  float distanceError = 0; //
  int steerZero = 0;
  float steeringPositionZero = 1660;
  float steerSensorCounts = 23;

    //pwm variables
  int pwmDrive = 0, drive = 0, pwmDisplay = 0;
  float pValue = 0;

  //Steer switch button  ***********************************************************************************************************
  byte currentState = 1;
  byte reading;
  byte previous = 0;
  byte test = 0;

void setup()
{    
  //keep pulled high and drag low to activate, noise free safe    
  pinMode(WORKSW_PIN, INPUT_PULLUP); 
  pinMode(STEERSW_PIN, INPUT_PULLUP); 
  pinMode(REMOTE_PIN, INPUT_PULLUP); 
  pinMode(DIR1_RL_ENABLE, OUTPUT);
  
  //set up communication
  Wire.begin();
  Serial.begin(38400);

  #if (BNO_Installed)  // BNO055 init
    IMU.init();
  
    //use external 32K crystal
    IMU.setExtCrystalUse(true);
  #endif  
  	
 #if Inclinometer_Installed ==2 | Inclinometer_Installed ==3
      // MMA8452 (1) Inclinometer
      MMAinitialized = MMA.init();
      if (MMAinitialized){
        MMA.setDataRate(MMA_800hz);
        MMA.setRange(MMA_RANGE_8G);
        MMA.setHighPassFilter(false); 
      }
      else Serial.println("MMA init fails!!");
  #endif

	//PWM rate settings Adjust to desired PWM Rate
	//TCCR1B = TCCR1B & B11111000 | B00000010;    // set timer 1 divisor to     8 for PWM frequency of  3921.16 Hz
	TCCR1B = TCCR1B & B11111000 | B00000011;    // set timer 1 divisor to    64 for PWM frequency of     490.20 Hz (The DEFAULT)

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
    
    //register udpSerialPrint() to port 8888
    ether.udpServerListenOnPort(&udpSteerRecv, 8888);
  #endif

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
    
    if (EEread != SteerPosZero)
    {
      EEPROM.put(2, SteerPosZero);    // if changed , rewrite
      steerSettings.steeringPositionZero = (SteerPosZero);  //use new steering zero offset now
      EEPROM.put(8, steerSettings);   
    }    
  } 
}// End of Setup

void loop()
{
	/*
	 * Loop triggers every 100 msec and sends back gyro heading, and roll, steer angle etc
	 * All imu code goes in the loop
	 *  Determine the header value and set the flag accordingly
	 *  Then the next group of serial data is according to the flag
	 *  Process accordingly updating values
	 */

	currentTime = millis();
	unsigned int time = currentTime;

	if (currentTime - lastTime >= LOOP_TIME)
	{
		dT = currentTime - lastTime;
		lastTime = currentTime;
   
    //If connection lost to AgOpenGPS, the watchdog will count up and turn off steering
    if (watchdogTimer++ > 250) watchdogTimer = 12;

    //clean out serial buffer to prevent buffer overflow
    if (serialResetTimer++ > 20)
    {
      while (Serial.available() > 0) char t = Serial.read();
      serialResetTimer = 0;
    }

    
    #if (BNO_Installed == 1)
        IMU.readIMU();
    #endif
    
    #if (Inclinometer_Installed ==1)
        //DOGS2 inclinometer
         rollK = ((ads.readADC_SingleEnded(2))); // 24,000 to 2700
          rollK = (rollK - 13300)/28;
    #endif
    
    #if (Inclinometer_Installed == 2 | Inclinometer_Installed == 3)
       // MMA8452 Inclinometer          
        if (MMAinitialized){
          MMA.getRawData(&x_, &y_, &z_);

          #if UseMMA_X_Axis == 0 
              roll= x_; //Conversion uint to int
          #else 
              roll = y_;
          #endif
          
          if (roll > 4200)  roll =  4200;
          if (roll < -4200) roll = -4200;
          rollK = map(roll,-4200,4200,-960,960); //16 counts per degree (good for 0 - +/-30 degrees) 
        }
    #endif

    #if (Inclinometer_Installed == 4) //DOGS2 inclinometer at A1 Arduino     
     analogRead(Dogs2_Roll); //discard
     delay(1);
     roll = analogRead(Dogs2_Roll);   delay(1);
     //inclinometer goes from -25 to 25 from 0.5 volts to 4.5 volts
     rollK = map(roll, 102, 921, -400, 400); //16 counts per degree
#endif
    
    //if not positive when rolling to the right
    #if Roll_Invert ==1
      rollK *= -1.0;
    #endif	
    
    //Kalman filter
    Pc = P + varProcess;
    G = Pc / (Pc + varRoll);
    P = (1 - G) * Pc;
    Xp = XeRoll;
    Zp = Xp;
    XeRoll = G * (rollK - Zp) + Xp;

    //read all the switches
    workSwitch = digitalRead(WORKSW_PIN);  // read work switch

    #if (SwitchOrButton == 0)
      steerSwitch = digitalRead(STEERSW_PIN); //read auto steer enable switch open = 0n closed = Off
      
    #else
      reading = digitalRead(STEERSW_PIN);      
      if (reading == LOW && previous == HIGH) 
      {
        test++;
        if (currentState == 1)
        {
          currentState = 0;
          steerSwitch = 0;
        }
        else
        {
          currentState = 1;
          steerSwitch = 1;
        }
      }      
      previous = reading;
     #endif
    
    remoteSwitch = digitalRead(REMOTE_PIN); //read auto steer enable switch open = 0n closed = Off
    switchByte = 0;
    switchByte |= (remoteSwitch << 2); //put remote in bit 2
    switchByte |= (steerSwitch << 1);   //put steerswitch status in bit 1 position
    switchByte |= workSwitch;

    #if Relay_Type == 1
        SetRelays();       //turn on off section relays
    #elif Relay_Type == 2
        SetuTurnRelays();  //turn on off uTurn relays
    #endif
  
    //get steering position 
    #if A2D_Convertor_Mode==0   //WAS at arduino
        analogRead(WAS_Ard_A0); //discard initial reading // Arduino ADC     
        steeringPosition = analogRead(WAS_Ard_A0);    delay(1);
        steeringPosition += analogRead(WAS_Ard_A0);    delay(1);
        steeringPosition += analogRead(WAS_Ard_A0);    delay(1);
        steeringPosition += analogRead(WAS_Ard_A0);
        steeringPosition = steeringPosition >> 2; //divide by 4
    #endif 
      
    #if A2D_Convertor_Mode==1   //Single Input ADS
      steeringPosition = ads.readADC_SingleEnded(0);    //ADS1115 Single Mode 
      steeringPosition = (steeringPosition >> 3); //bit shift by 3  0 to 3320 is 0 to 5v
    #endif 
    
    #if A2D_Convertor_Mode==2    //ADS1115 Differential Mode
      steeringPosition = ads.readADC_Differential_0_1(); //ADS1115 Differential Mode
      steeringPosition = (steeringPosition >> 3); //bit shift by 3  0 to 3320 is 0 to 5v
    #endif 
   
    //DETERMINE ACTUAL STEERING POSITION
    steeringPosition = (steeringPosition - steerSettings.steeringPositionZero);   //read the steering position sensor
          
      //convert position to steer angle. 32 counts per degree of steer pot position in my case
      //  ***** make sure that negative steer angle makes a left turn and positive value is a right turn *****
    #if WAS_Invert
        steerAngleActual = (float)(steeringPosition) / steerSettings.steerSensorCounts;
    #else
        steerAngleActual = (float)(steeringPosition) / -steerSettings.steerSensorCounts;
    #endif
  
    if (watchdogTimer < 10)
      { 
        #if Motor_Valve_Driver_Board == 2
          digitalWrite(DIR1_RL_ENABLE, 1); //Enable H Bridge for IBT2
        #endif
        
        steerAngleError = steerAngleActual - steerAngleSetPoint;   //calculate the steering error
        calcSteeringPID();  //do the pid
        motorDrive();       //out to motors the pwm value
      }
    else
      {
        //we've lost the comm to AgOpenGPS, or just stop request
       #if Motor_Valve_Driver_Board == 2
          digitalWrite(DIR1_RL_ENABLE, 0); //Disable H Bridge for IBT2
        #endif
        pwmDrive = 0; //turn off steering motor
        motorDrive(); //out to motors the pwm value
      }

    // Send Data to AOG
    #if (EtherNet)
      int temp;
      
      //actual steer angle
      temp = (100 * steerAngleActual);
      toSend[2] = (byte)(temp >> 8);
      toSend[3] = (byte)(temp);

         //heading  
      #if BNO_Installed
         temp = IMU.euler.head;       //heading in degrees * 16 from BNO
      #else
         temp = 9999;                 //No IMU installed
      #endif
      
      toSend[4] = (byte)(temp >> 8);
      toSend[5] = (byte)(temp);
      
      //setpoint steer angle  --- * 100 in degrees
      //temp = (100 * steerAngleSetPoint);
      //toSend[4] = (byte)(temp >> 8);
      //toSend[5] = (byte)(temp);

      #if Inclinometer_Installed !=0
        temp =(int)XeRoll;          //roll in degrees * 16
      #else
        temp =9999;                 //no Dogs installed
      #endif
          
      //Vehicle roll --- * 16 in degrees

      toSend[6] = (byte)(temp >> 8);
      toSend[7] = (byte)(temp);
          
      //switch byte
      toSend[8] = switchByte;
  
      //pwm value
      toSend[9] = pwmDisplay;
  
      //off to AOG
      ether.sendUdp(toSend, sizeof(toSend), portMy, ipDestination, portDestination);

      //Serial Diagnostics
      /*
      Serial.print(steerSettings.steerSensorCounts); //The actual steering angle in degrees
      Serial.print(",");
      Serial.print(steerSettings.steeringPositionZero); //The actual steering angle in degrees
      Serial.print(",");
      
      Serial.print(steeringPosition); //The actual steering angle in degrees
      Serial.print(",");
        
      Serial.println(currentState);   
      */   
  
    #else

      //Serial Send to agopenGPS **** you must send 5 numbers ****
      Serial.print((int)(steerAngleActual * 100)); //The actual steering angle in degrees
      Serial.print(",");
      Serial.print((int)(steerAngleSetPoint * 100));   //the setpoint originally sent
      Serial.print(",");
  
      // *******  if there is no gyro installed send 9999
      #if BNO_Installed
        Serial.print(IMU.euler.head);       //heading in degrees * 16 from BNO
      #else
        Serial.print(9999);                 //No IMU installed
      #endif
      
      Serial.print(",");
      
      //*******  if no roll is installed, send 9999
      #if Inclinometer_Installed !=0
        Serial.print((int)XeRoll);          //roll in degrees * 16
      #else
        Serial.print(9999);                 //no Dogs installed
      #endif
  
      Serial.print(","); 

      //the status of switch inputs
      Serial.println(switchByte); //steering switch status  
      Serial.flush();   // flush out buffer

    #endif
        
  	} //end of timed loop

      //This runs continuously, outside of the timed loop, keeps checking UART for new data
  
  #if (EtherNet)
    delay(10); 
    
    //this must be called for ethercard functions to work. Calls udpSteerRecv() defined way below.
    ether.packetLoop(ether.packetReceive());  

  //////////////////////////////////////  Serial Receive Data/Settings  //////////////////////////////////
  #else
    delay (10);
  // header high/low, relay byte, speed byte, high distance, low distance, Steer high, steer low
  if (Serial.available() > 0 && !isDataFound && !isSettingFound) //find the header, 127H + 254L = 32766
  {
    int temp = Serial.read();
    header = tempHeader << 8 | temp;               //high,low bytes to make int
    tempHeader = temp;                             //save for next time
    if (header == 32766) isDataFound = true;     //Do we have a match?
    if (header == 32764) isSettingFound = true;     //Do we have a match?
  }

  //Data Header has been found, so the next 6 bytes are the data
  if (Serial.available() > 6 && isDataFound)
  {
    isDataFound = false;
    relay = Serial.read();   // read relay control from AgOpenGPS
    gpsSpeed = Serial.read() * 0.25;  //actual speed times 4, single byte

    //distance from the guidance line in mm
    distanceFromLine = (float)(Serial.read() << 8 | Serial.read());   //high,low bytes

    //set point steer angle * 10 is sent
    steerAngleSetPoint = ((float)(Serial.read() << 8 | Serial.read()))*0.01; //high low bytes

    //auto Steer is off if 32020,Speed is too slow, motor pos or footswitch open
    if (distanceFromLine == 32020 | gpsSpeed < MinSpeed | gpsSpeed > MaxSpeed | steerSwitch == 1)
      {
       watchdogTimer = 12; //turn off steering motor
       }
    else          //valid conditions to turn on autosteer
      {
       watchdogTimer = 0;  //reset watchdog
       serialResetTimer = 0; //if serial buffer is getting full, empty it
      }

    //uturn byte read in
    uTurn = Serial.read();
  }

  //Settings Header has been found, 8 bytes are the settings
  if (Serial.available() > 7 && isSettingFound)
  {
    isSettingFound = false;  //reset the flag
    //change the factors as required for your own PID values
    steerSettings.Kp = (float)Serial.read() * 1.0;   // read Kp from AgOpenGPS
    steerSettings.Ki = (float)Serial.read() * 0.001;   // read Ki from AgOpenGPS
    steerSettings.Kd = (float)Serial.read() * 1.0;   // read Kd from AgOpenGPS
    steerSettings.Ko = (float)Serial.read() * 0.1;   // read Ko from AgOpenGPS
    byte offset = Serial.read();
    steerSettings.steeringPositionZero = (SteerPosZero-127) + offset;  //read steering zero offset
    //steerZero = (SteerPosZero-127) + 2 * offset; //double offset for JRK
    steerSettings.minPWMValue = Serial.read(); //read the minimum amount of PWM for instant on
    steerSettings.maxIntegralValue = Serial.read()*0.1; //
    steerSettings.steerSensorCounts = Serial.read(); //sent as 10 times the setting displayed in AOG
    EEPROM.put(8, steerSettings);
  }

  #endif
  
} // end of main loop

//////////////////////////////////    Ethernet  //////////////////////////////
#if (EtherNet == 1)

//callback when received packets
void udpSteerRecv(uint16_t dest_port, uint8_t src_ip[IP_LEN], uint16_t src_port, byte *data, uint16_t len)
{
  /* IPAddress src(src_ip[0],src_ip[1],src_ip[2],src_ip[3]); 
  Serial.print("dPort:");  Serial.print(dest_port);
  Serial.print("  sPort: ");  Serial.print(src_port); 
  Serial.print("  sIP: ");  ether.printIp(src_ip);  Serial.println("  end");*/

  //for (int i = 0; i < len; i++) {
  //Serial.print(data[i],HEX); Serial.print("\t"); } Serial.println(len);

  if (data[0] == 0x7F && data[1] == 0xFE) //Data
  {
    relay = data[2];   // read relay control from AgOpenGPS     
    gpsSpeed = data[3] * 0.25;  //actual speed times 4, single byte

    //distance from the guidance line in mm
    distanceFromLine = (float)(data[4] << 8 | data[5]);   //high,low bytes     

    //set point steer angle * 10 is sent
    steerAngleSetPoint = ((float)(data[6] << 8 | data[7])); //high low bytes 
    steerAngleSetPoint *= 0.01;  

    if (distanceFromLine == 32020 | gpsSpeed < MinSpeed | gpsSpeed > MaxSpeed | steerSwitch == 1)
    {
      watchdogTimer = 12;//turn off steering motor
    }
    else          //valid conditions to turn on autosteer
    {
      watchdogTimer = 0;  //reset watchdog
    }
    uTurn = 0; // no uTurn byte with Ethernet Mode
    /*    
    Serial.print(steerAngleActual);   //the pwm value to solenoids or motor
    Serial.print(",");
    Serial.println(XeRoll);
     */
  }

  //autosteer settings
  if (data[0] == 0x7F && data[1] == 0xFC)
  {
    steerSettings.Kp = (float)data[2] * 1.0;       // read Kp from AgOpenGPS
    steerSettings.Ki = (float)data[3] * 0.001;     // read Ki from AgOpenGPS
    steerSettings.Kd = (float)data[4] * 1.0;       // read Kd from AgOpenGPS
    steerSettings.Ko = (float)data[5] * 0.1;       // read Ko from AgOpenGPS
    
    steerSettings.steeringPositionZero = (SteerPosZero - 127) + data[6];//read steering zero offset  
    
    steerSettings.minPWMValue = data[7]; //read the minimum amount of PWM for instant on
    steerSettings.maxIntegralValue = data[8]*0.1; //
    steerSettings.steerSensorCounts = data[9]; 
    
    EEPROM.put(8, steerSettings);
    
    //for (int i = 0; i < len; i++) {
      //Serial.print(data[i],HEX); Serial.print("\t"); } Serial.println("<--");
    // }
  }
}
#endif //ethernet
