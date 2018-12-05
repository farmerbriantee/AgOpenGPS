//##########################################################################################################
//### Setup Zone ###########################################################################################
//##########################################################################################################
  
  #define Output_Driver 1       // 1 =  Steering Motor + Cytron MD30C Driver
                                // 2 =  Steering Motor + IBT 2  Driver
                                // 3 =  Steering Motor + JRK 2 Driver (see https://github.com/aortner/jrk)

  #define ADC_Mode 0           //0 = No ADS installed, Wheel Angle Sensor connected directly to Arduino at A0
                               //2 = ADS1115 Differential Mode - Connect Sensor GND to A1, Signal to A0
                               //3 = JRK 2 AD_Input (only for use with JRK 2 Motorcontroller)
  
  #define SteerPosZero 512     //vary this to get near 0 degrees when wheels are straight forward    
                               //with Arduino ADC start with 512 (0-1024)
                               //with ADS start with 13000  (possible Values are 0-26000 Counts) 
                               //with JRK 2 use 2046
  
  #define Invert_WAS 0                 // set to 1 to Change Direction of Wheel Angle Sensor - to + 
  
  #define IMU_Installed 0               // set to 1 to enable BNO055 IMU
  
  #define Inclinometer_Installed 0      // set to 1 if DOGS2 Inclinometer is installed
                                        // set to 2 if MMA8452 installed

  #define Relay_Type 0                  // set to 0 if up to 8 Section Relays will be used
                                        // set to 1 if up to 8 uTurn Relays will be used (only Serial Mode)
  
  //Ethernet Details
  #define EtherNet 0      // 0 = Serial/USB communcation with AOG
                          // 1 = Ethernet comunication with AOG (using a ENC28J60 chip)
  #define CS_Pin 10       // Arduino Nano= 10 depending how CS of Ethernet Controller ENC28J60 is Connected

  //##########################################################################################################
  //### End of Setup Zone ####################################################################################
  //##########################################################################################################

  #define STEERSW_PIN 3  //PD3
  #define WORKSW_PIN  4  //PD4
  #define PWM_PIN     5  //PD5  
  #define DIR_PIN     6  //PD6
  #define LED_PIN     7  //PD7 Autosteer LED
  #define W_A_S      A0  //PC0 Wheel Angle Sensor
  #define Dogs2_Roll A1  //PC1 EADOGS2 Inclinometer
  //ethercard 10,11,12,13   
  #define RELAY1_PIN 8   //PB0
  #define RELAY2_PIN 9   //PB1
  #define RELAY3_PIN A2  //PC2
  #define RELAY4_PIN A3  //PC3
  //#define RELAY5_PIN 10  //PB2  serial Mode only
  //#define RELAY6_PIN 11  //PB3  serial Mode only
  //#define RELAY7_PIN 12  //PB4  serial Mode only
  //#define RELAY8_PIN 13  //PB5  serial Mode only
  

  #include <Wire.h>
  #include <EEPROM.h>

#if (EtherNet)
  #include <EtherCard.h>
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


#if ADC_Mode==1 | ADC_Mode==2
  #include "Adafruit_ADS1015.h"
  Adafruit_ADS1115 ads;     // Use this for the 16-bit version ADS1115
#endif

#if Inclinometer_Installed ==2
    #include "MMA8452_AOG.h"  // MMA8452 (1) Inclinometer
    MMA8452 accelerometer;
#endif

#if IMU_Installed
  #include "BNO055_AOG.h"  // BNO055 IMU
  #define A 0X28             //I2C address selection pin LOW
  #define B 0x29             //                          HIGH
  #define RAD2GRAD 57.2957795
  BNO055 IMU(A);  // create an instance
#endif

#ifdef JRK_2_POLOLU
  #include <JrkG2.h>   // get from https://github.com/pololu/jrk-g2-arduino
  JrkG2I2C jrk;
  #define SteerPosZero 2046
  #define Invert_WAS 1
#endif

#define EEP_Ident 0xEDFE

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
const unsigned int LOOP_TIME = 100; //10hz
unsigned int lastTime = LOOP_TIME;
unsigned int currentTime = LOOP_TIME;
unsigned int dT = 50000;
byte count = 0;
byte watchdogTimer = 0;
byte serialResetTimer = 0; //if serial buffer is getting full, empty it

//Kalman variables
float rollK = 0, Pc = 0.0, G = 0.0, P = 1.0, Xp = 0.0, Zp = 0.0;
float XeRoll = 0;
const float varRoll = 0.1; // variance,
const float varProcess = 0.0001; //smaller is more filtering

//Program flow
bool isDataFound = false, isSettingFound = false;
int header = 0, tempHeader = 0, temp, EEread = 0;
byte relay = 0, uTurn = 0, speeed = 0, workSwitch = 0, steerSwitch = 1, switchByte = 0;
float distanceFromLine = 0, corr = 0;

//steering variables
float steerAngleActual = 0;
int steerPrevSign = 0, steerCurrentSign = 0; // the steering wheels angle currently and previous one
float steerAngleSetPoint = 0; //the desired angle from AgOpen
long steeringPosition = 0; //from steering sensor
float steerAngleError = 0; //setpoint - actual
float distanceError = 0; //
int steerZero = 0;

//inclinometer variables
int roll = 0;
uint16_t x_ , y_ , z_;

//pwm variables
int pwmDrive = 0, drive = 0, pwmDisplay = 0;
float pValue = 0, iValue = 0, dValue = 0;


void setup()
{    
  //keep pulled high and drag low to activate, noise free safe    
  pinMode(WORKSW_PIN, INPUT_PULLUP);   //Pin D4 PD4
  pinMode(STEERSW_PIN, INPUT_PULLUP);  //Pin 11 PB2	pinMode(RELAY1_PIN, OUTPUT); //configure RELAY1 for output //Pin 5
  //pinMode(RELAY1_PIN, OUTPUT); //configure RELAY2 for output //Pin 6
  pinMode(DIR_PIN, OUTPUT); // direction pin of PWM Board
  pinMode(PWM_PIN, OUTPUT);
  pinMode(LED_PIN, OUTPUT);

  //set up communication
  Wire.begin();
  Serial.begin(38400);

#if (IMU_Installed)  // BNO055 init
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
	
#if (Inclinometer_Installed ==2)
      // MMA8452 (1) Inclinometer
      bool initialized = accelerometer.init();
      accelerometer.setDataRate(MMA_800hz);
      accelerometer.setRange(MMA_RANGE_8G);
      accelerometer.setHighPassFilter(false); 
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
    if (EEread != SteerPosZero){
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

#if (IMU_Installed)
    IMU.readIMU();
#endif

		//If connection lost to AgOpenGPS, the watchdog will count up and turn off steering
		if (watchdogTimer++ > 250) watchdogTimer = 12;

#if (Inclinometer_Installed ==1)
    //DOGS2 inclinometer
		delay(1);
		analogRead(Dogs2_Roll); //discard
		delay(1);
		roll = analogRead(Dogs2_Roll);   delay(1);
		roll += analogRead(Dogs2_Roll);   delay(1);
		roll += analogRead(Dogs2_Roll);   delay(1);
		roll += analogRead(Dogs2_Roll);
		roll = roll >> 2; //divide by 4
		//inclinometer goes from -25 to 25 from 0 volts to 5 volts
    rollK = map(roll, -1023, 1023, -400, 400); //16 counts per degree
#endif

#if Inclinometer_Installed ==2
   // MMA8452 (1) Inclinometer
  accelerometer.getRawData(&x_, &y_, &z_);
  roll=x_; //Conversion uint to int
  if (roll > 4200)  roll =  4200;
  if (roll < -4200) roll = -4200;
  rollK = map(roll,-4200,4200,-960,960); //16 counts per degree (good for 0 - +/-30 degrees) 
#endif
	
    //Kalman filter
    Pc = P + varProcess;
    G = Pc / (Pc + varRoll);
    P = (1 - G) * Pc;
    Xp = XeRoll;
    Zp = Xp;
    XeRoll = G * (rollK - Zp) + Xp;

    workSwitch = digitalRead(WORKSW_PIN);  // read work switch
    steerSwitch = digitalRead(STEERSW_PIN); //read auto steer enable switch open = 0n closed = Off
    switchByte = 0;
    switchByte = steerSwitch << 1; //put steerswitch status in bit 1 position
    switchByte = workSwitch | switchByte;

#if Relay_Type==0
    SetRelays();       //turn on off section relays
#else
    SetuTurnRelays();  //turn on off uTurn relays
#endif

 //get steering position 
#if ADS_Mode==0   //WAS at arduino
    analogRead(W_A_S); //discard initial reading // Arduino ADC     
    steeringPosition = analogRead(W_A_S);    delay(1);
    steeringPosition += analogRead(W_A_S);    delay(1);
    steeringPosition += analogRead(W_A_S);    delay(1);
    steeringPosition += analogRead(W_A_S);
    steeringPosition = steeringPosition >> 2; //divide by 4
#endif 

#if ADC_Mode==2    //ADS1115 Differential Mode
    steeringPosition = ads.readADC_Differential_0_1();    delay(2);    //ADS1115 Differential Mode 
    steeringPosition += ads.readADC_Differential_0_1();   delay(2);    //Connect Sensor GND to A1
    steeringPosition += ads.readADC_Differential_0_1();   delay(2);    //Connect Sensor Signal to A0
    steeringPosition += ads.readADC_Differential_0_1();
    steeringPosition = steeringPosition >> 2; //divide by 4
#endif 
    
    steeringPosition = ( steeringPosition -steerSettings.steeringPositionZero);   //center the steering position sensor

#ifdef JRK_2_POLOLU  // JRK_2_POLOLU AD In
    steeringPosition = jrk.getScaledFeedback();  
    steeringPosition = ( steeringPosition -steerZero);   //center the steering position sensor
#endif      
    
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

    //close enough to center, 4 cm, remove any correction          
    //if (distanceFromLine < 40 && distanceFromLine > -40) steerAngleSetPoint = 0;
    if (distanceFromLine <= 40 && distanceFromLine >= -40) corr = 0;
    else
    {
      //use the integal value to adjust how much per cycle it increases
      corr += steerSettings.Ki;

      //provide a limit - the old max integral value
      if (corr > steerSettings.maxIntegralValue) corr = steerSettings.maxIntegralValue;

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

// Send Data to AOG
#if (EtherNet)
    transmitEthernet(); 
#else
    transmitSerial();
#endif
    
Serial.print("Steerposzero:  ");
Serial.println(steerSettings.steeringPositionZero);
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
      bitSet(PORTD, 7);   //turn LED on
      steerAngleError = steerAngleActual - steerAngleSetPoint;   //calculate the steering error
      calcSteeringPID();  //do the pid
      motorDrive();       //out to motors the pwm value
    }
  else
    {
      //we've lost the comm to AgOpenGPS
      pwmDrive = 0; //turn off steering motor
      motorDrive(); //out to motors the pwm value
      bitClear(PORTD, 7); //turn LED off
    }
} // end of main loop
