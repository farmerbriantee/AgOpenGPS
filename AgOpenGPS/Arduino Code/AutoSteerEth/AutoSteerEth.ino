//The 3.3V version
#include "MMA8452Q.h"

//It says 1015 but is used for both the ADS1015 and the ADS1115
#include "ADS1015.h"

#include <Wire.h>

#include <EtherCard.h>
#include <IPAddress.h> 

//##########################################################################################################
//### Setup Zone ###########################################################################################
//##########################################################################################################

  //Change depending on what happens. If the word is false use a 0, if its true use a 1
  //Only change from 0 if the response is incorrect. Start with all four set to 0.

                                            //Steering to the right should be a positive angle
  #define SteeringRightIsNotPositive 1      // Set to 0 if it steers the right way    
                                            // Set to 1 if steer to right shows negative

                                            // Does the motor spin the right way?
  #define SteerMotorDirectionBackwards 1    // Set to 0 if is correct direction
                                            // Set to 1 if it turns the wrong way
                                    
                                        // Depending on board orientation, choose the right Axis
  #define UseMMA_Y_Axis 1               // Set to 0 to use X axis of MMA
                                        // Set to 1 to use Y axis of MMA

                                        // When tractor rolls to the right, it should show positive angle
  #define IsRollToRightNotPositive 0    // Set to 0 if angle is positive to the right
                                        // Set to 1 if roll to right shows negative

                                        //using the dogs or not
  #define IsUsingDogs2 1                //set to 0 if using MMA
                                        //set to 1 if using DOGS2
                                    
  //##########################################################################################################
  //### End of Setup Zone ####################################################################################
  //##########################################################################################################

 //instance of inclinometer 0x2A
  MMA8452Q MMA;

  //instance of A/D convertor 0x48
  Adafruit_ADS1115 ads;
  
  #define DIR_PIN  4  //PD4
  #define PWM_PIN  3  //PD3  
  
  #define WORKSW_PIN 7  //PD7
  #define STEERSW_PIN 6 //PD6
  #define REMOTE_PIN 8  //PB0
  
  //ethercard 10,11,12,13   
   
  //loop time variables in microseconds
  const unsigned int LOOP_TIME = 100; //10hz
  unsigned int lastTime = LOOP_TIME;
  unsigned int currentTime = LOOP_TIME;
  unsigned int dT = 50000;
  unsigned int count = 0;
  byte watchdogTimer = 0;
  byte serialResetTimer = 0; //if serial buffer is getting full, empty it

  //Kalman variables
  float rollK = 0, Pc = 0.0, G = 0.0, P = 1.0, Xp = 0.0, Zp = 0.0;
  float XeRoll = 0;
  const float varRoll = 0.5; // variance,
  const float varProcess = 0.001; //smaller is more filtering

  //program flow
  float rollDogs = 0;
  bool isDataFound = false, isSettingFound = false;
  int header = 0, tempHeader = 0, temp;

  byte relay = 0, uTurn = 0, gpsSpeed = 0, remoteSwitch = 0, workSwitch = 0, steerSwitch = 1, switchByte = 0;
  float distanceFromLine = 0, corr = 0;

  //steering variables
  float steerAngleActual = 0;
  float steerAngleSetPoint = 0; //the desired angle from AgOpen
  long steeringPosition = 0;
  int steeringPositionZero = 1660; //from steering sensor
  float steerAngleError = 0; //setpoint - actual
  float distanceError = 0; //
  float steerSensorCounts = 32;

  //pwm variables
  int pwmDrive = 0, pwmDisplay = 0;
  float pValue = 0, iValue = 0, dValue = 0;
  byte minPWMValue = 10;

  //PID variables
  float Ko = 0.0f;  //overall gain
  float Kp = 0.0f;  //proportional gain
  float Ki = 0.0f;//integral gain
  float Kd = 0.0f;  //derivative gain
  
  //integral values - **** change as required *****
  float   maxIntErr = 200; //anti windup max
  float maxIntegralValue = 20; //max PWM value for integral PID component

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
  //this is port of this module
  unsigned int portMy = 5577; 
  
  //sending back to where and which port
  static byte ipDestination[] = {192, 168, 1, 255};
  unsigned int portDestination = 9999; 
  
  // ethernet mac address - must be unique on your network
  static byte mymac[] = { 0x70,0x69,0x69,0x2D,0x30,0x31 };
  
  // udp send and receive buffer
  byte Ethernet::buffer[200]; 
  
void setup()
{
  //keep pulled high and drag low to activate, noise free safe    
  pinMode(WORKSW_PIN, INPUT_PULLUP); 
  pinMode(STEERSW_PIN, INPUT_PULLUP); 
  pinMode(REMOTE_PIN, INPUT_PULLUP); 
  pinMode(DIR_PIN, OUTPUT); //D4 PD4

  //set up communication
  Wire.begin();
  Serial.begin(38400);

  // MMA8452 Inclinometer      
  if (!MMA.init()) 
    Serial.println("MMA init fails!!");
    
  //ads.setGain(GAIN_ONE);
 
  //Ethernet setup
  if (ether.begin(sizeof Ethernet::buffer, mymac) == 0)
    Serial.println(F("Failed to access Ethernet controller"));

  //set up connection
  ether.staticSetup(myip, gwip, myDNS, mask); 
  ether.printIp("IP:  ", ether.myip);
  ether.printIp("GW:  ", ether.gwip);
  ether.printIp("DNS: ", ether.dnsip);

  //set up the pgn for returning data
  toSend[0] = 0x7F;
  toSend[1] = 0xFD;
  
  //register udpSerialPrint() to port 8888
  ether.udpServerListenOnPort(&udpSteerRecv, 8888);
  }

void loop()
{
  //Loop triggers every 100 msec and sends back gyro heading, and roll, steer angle etc

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

    if (IsUsingDogs2)

    {
      rollK = ((ads.readADC_SingleEnded(2))); // 24,000 to 2700
      rollK = (rollK - 13300)/28;
      if (IsRollToRightNotPositive) rollK *= -1.0;
    }
    else
    {
      //inclinometer
      if (MMA.available()) //is there data available
      {      
        MMA.read(); // Reads only "x and y" accel
      }    
      
      //if is set to 1 //get the roll from MMA - value from 0 to 1
      if (UseMMA_Y_Axis) rollK = MMA.cy * 90 * 16; //UseMMa_Y_Axis is set to 1
      else rollK = MMA.cx * 90 * 16; 
      //if not positive when rolling to the right
      if (IsRollToRightNotPositive) rollK *= -1.0;
    }
    
		//Kalman filter
		Pc = P + varProcess;
		G = Pc / (Pc + varRoll);
		P = (1 - G) * Pc;
		Xp = XeRoll;
		Zp = Xp;
		XeRoll = G * (rollK - Zp) + Xp;

    //read all the switches
    workSwitch = digitalRead(WORKSW_PIN);  // read work switch
    steerSwitch = digitalRead(STEERSW_PIN); //read auto steer enable switch open = 0n closed = Off
    remoteSwitch = digitalRead(REMOTE_PIN); //read auto steer enable switch open = 0n closed = Off
    switchByte = 0;
    switchByte |= (remoteSwitch << 2); //put remote in bit 2
    switchByte |= (steerSwitch << 1);   //put steerswitch status in bit 1 position
    switchByte |= workSwitch;

    //steering position and steer angle   
    steeringPosition = ads.readADC_SingleEnded(0);    //ADS1115 Differential Mode 
    steeringPosition = (steeringPosition >> 3); //bit shift by 3  0 to 3320 is 0 to 5v
    
    steeringPosition = (steeringPosition - steeringPositionZero - (XeRoll * Kd/10 ) );   //read the steering position sensor
    if (SteeringRightIsNotPositive) steeringPosition *= -1.0;

    /*
    //close enough to center, remove any integral correction
    if (distanceFromLine <= 40 && distanceFromLine >= -40) corr = 0;
    else
    {
      //use the integal value to adjust how much per cycle it increases
      corr +=Ki;

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
    */
    
		//convert position to steer angle.
    steerAngleActual = (steeringPosition) / steerSensorCounts;

    //normal autosteer all ready to go
		if (watchdogTimer < 10)
		{
			steerAngleError = steerAngleActual - steerAngleSetPoint;   //calculate the steering error
			calcSteeringPID();  //do the pid
			motorDrive();       //out to motors the pwm value		
		}
		else
		{
			//we've lost the comm to AgOpenGPS
			pwmDrive = 0; //turn off steering motor
			motorDrive(); //out to motors the pwm value
		}

    int temp;
    
    //actual steer angle
    temp = (100 * steerAngleActual);
    toSend[2] = (byte)(temp >> 8);
    toSend[3] = (byte)(temp);
      
    //setpoint steer angle  --- * 100 in degrees
    temp = (100 * steerAngleSetPoint);
    toSend[4] = (byte)(temp >> 8);
    toSend[5] = (byte)(temp);
    
    //Vehicle roll --- * 16 in degrees
    temp = (int)XeRoll;
    toSend[6] = (byte)(temp >> 8);
    toSend[7] = (byte)(temp);
        
    //switch byte
    toSend[8] = switchByte;

    //pwm value
    toSend[9] = pwmDisplay;

    //off to AOG
    ether.sendUdp(toSend, sizeof(toSend), portMy, ipDestination, portDestination);

      //Serial.println(steerAngleSetPoint);
       
    
	} //end of timed loop

  delay(10);
  //this must be called for ethercard functions to work.
  ether.packetLoop(ether.packetReceive());  
  
}  //****************************************************************************************  

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
      gpsSpeed = data[3] >> 2;  //actual speed times 4, single byte
  
      //distance from the guidance line in mm
      distanceFromLine = (float)(data[4] << 8 | data[5]);   //high,low bytes     
  
      //set point steer angle * 10 is sent
      steerAngleSetPoint = ((float)(data[6] << 8 | data[7])); //high low bytes 
      steerAngleSetPoint *= 0.01;  

      if (distanceFromLine == 32020 | gpsSpeed < 1 | steerSwitch == 1)
      {
        watchdogTimer = 12;//turn off steering motor
      }
      else          //valid conditions to turn on autosteer
      {
        //bitSet(PINB, 5);   //turn LED on
        watchdogTimer = 0;  //reset watchdog
      }
      /*    
      Serial.print(IMU.euler.head);
      Serial.print(",");    
      Serial.print(steerAngleActual);   //the pwm value to solenoids or motor
      Serial.print(",");
      Serial.println(XeRoll);
       */
       return;
    }

    //autosteer settings
    if (data[0] == 0x7F && data[1] == 0xFC)
    {
      Kp = (float)data[2] * 1.0;      // read Kp from AgOpenGPS
      Ki = (float)data[3] * 1.0;    // read Ki from AgOpenGPS
      Kd = (float)data[4] * 1.0;      // read Kd from AgOpenGPS
      Ko = (float)data[5] * 0.1;      // read Ko from AgOpenGPS
      
      steeringPositionZero = 1530 + data[6];  //read steering zero offset
      
      minPWMValue = data[7];          //read the minimum amount of PWM for instant on
      maxIntegralValue = data[8]*0.1; //
      
      steerSensorCounts = data[9];    //divisor for counts to degrees

      //diagnostics
      for (int i = 0; i < len; i++) {
        Serial.print(data[i],HEX); Serial.print("\t"); } Serial.println("<--");
    }
}

