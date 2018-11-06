
#include <Wire.h>

#include <EtherCard.h>
#include <IPAddress.h> 

//timer 2 controls 9,10
  #define WORKSW_PIN 4  //PD4
  #define STEERSW_PIN 5 //PD5
  #define RELAY1_PIN 6  //PD6
  #define   DIR_PIN  7  //PD7
  //pin 8 is ether
  #define   PWM_PIN  9  //PB1  
  //pin 10 is anothe timer 2 pwm
  
  //ethercard 8,11,12,13   

//loop time variables in microseconds
const unsigned int LOOP_TIME = 100; //10hz
unsigned int lastTime = LOOP_TIME;
unsigned int currentTime = LOOP_TIME;
unsigned int dT = 50000;
byte count = 0;
byte watchdogTimer = 0;

//Kalman variables
float rollK = 0, Pc = 0.0, G = 0.0, P = 1.0, Xp = 0.0, Zp = 0.0;
float XeRoll = 0;
const float varRoll = 0.1; // variance,
const float varProcess = 0.0001; //smaller is more filtering

byte relay = 0, speeed = 0, workSwitch = 0, steerSwitch = 1, switchByte = 0;
float distanceFromLine = 0, corr = 0;

//steering variables
float steerAngleActual = 0;
int steerPrevSign = 0, steerCurrentSign = 0; // the steering wheels angle currently and previous one
float steerAngleSetPoint = 0; //the desired angle from AgOpen
int steeringPosition = 0, steeringPositionZero = 512; //from steering sensor
float steerAngleError = 0; //setpoint - actual
float distanceError = 0; //
float steerSensorCounts = 4;

//inclinometer variables
int roll = 0;

//pwm variables
int pwmDrive = 0, drive = 0, pwmDisplay = 0;
float pValue = 0, iValue = 0, dValue = 0;
byte minPWMValue = 10;

//PID variables
float Ko = 0.0f;  //overall gain
float Kp = 0.0f;  //proportional gain
float Ki = 0.0f;//integral gain
float Kd = 0.0f;  //derivative gain

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
//this is port of this autosteer module
unsigned int portMy = 5577; 

//sending back to where and which port
static byte ipDestination[] = {192, 168, 1, 255};
unsigned int portDestination = 9999; //AOG port that listens

// ethernet mac address - must be unique on your network
static byte mymac[] = { 0x70,0x69,0x69,0x2D,0x30,0x31 };

byte Ethernet::buffer[200]; // udp send and receive buffer

void setup()
{    
  //keep pulled high and drag low to activate, noise free safe    
  pinMode(WORKSW_PIN, INPUT_PULLUP);   //Pin D4 PD4
  pinMode(STEERSW_PIN, INPUT_PULLUP);  //Pin 11 PB2	pinMode(RELAY1_PIN, OUTPUT); //configure RELAY1 for output //Pin 5
	pinMode(RELAY1_PIN, OUTPUT); //configure RELAY2 for output //Pin 6
	pinMode(DIR_PIN, OUTPUT); //D11 PB3 direction pin of PWM Board

	//set up communication
	Serial.begin(38400);

	//PWM rate settings Adjust to desired PWM Rate
	//TCCR1B = TCCR1B & B11111000 | B00000010;    // set timer 1 divisor to     8 for PWM frequency of  3921.16 Hz
	TCCR1B = TCCR1B & B11111000 | B00000011;    // set timer 1 divisor to    64 for PWM frequency of   490.20 Hz (The DEFAULT)

 if (ether.begin(sizeof Ethernet::buffer, mymac) == 0)
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
}

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

		//IMU.readIMU();

		//If connection lost to AgOpenGPS, the watchdog will count up and turn off steering
		if (watchdogTimer++ > 250) watchdogTimer = 12;

		//inclinometer
		delay(1);
		analogRead(A1); //discard
		delay(1);
		roll = analogRead(A1);   delay(1);
		roll += analogRead(A1);   delay(1);
		roll += analogRead(A1);   delay(1);
		roll += analogRead(A1);
		roll = roll >> 2; //divide by 4

		//inclinometer goes from -25 to 25 from 0 volts to 5 volts
		rollK = map(roll, 0, 1023, -500, 500); //20 counts per degree * 16.0
		rollK *= 0.8;

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

		SetRelays(); //turn on off sections

		//steering position and steer angle
		analogRead(A0); //discard initial reading
		steeringPosition = analogRead(A0);    delay(1);
		steeringPosition += analogRead(A0);    delay(1);
		steeringPosition += analogRead(A0);    delay(1);
		steeringPosition += analogRead(A0);
		steeringPosition = steeringPosition >> 2; //divide by 4
		steeringPosition = (steeringPosition - steeringPositionZero + (XeRoll * (Kd/24)) );   //read the steering position sensor
		//steeringPosition = ( steeringPosition - steeringPositionZero);   //read the steering position sensor

    //close enough to center, 4 cm, remove any correction          
    if (distanceFromLine < 40 && distanceFromLine > -40) steerAngleSetPoint = 0;
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
    
    //convert position to steer angle. 6 counts per degree of steer pot position in my case
    //  ***** make sure that negative steer angle makes a left turn and positive value is a right turn *****
    // remove or add the minus for steerSensorCounts to do that.
    steerAngleActual = (float)(steeringPosition) / -steerSensorCounts;
   
    int temp;
    //actual steer angle
    temp = (100 * steerAngleActual);
    toSend[2] = (byte)(temp >> 8);
    toSend[3] = (byte)(temp);
    
    //Vehicle roll --- * 16 in degrees
    temp = XeRoll;
    toSend[6] = (byte)(temp >> 8);
    toSend[7] = (byte)(temp);
        
    //switch byte
    toSend[8] = switchByte;

    //off to AOG
    ether.sendUdp(toSend, sizeof(toSend), portMy, ipDestination, portDestination);
    
	} //end of timed loop

  delay(50);
  //this must be called for ethercard functions to work.
  ether.packetLoop(ether.packetReceive());  
  
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
}

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
      speeed = data[3] >> 2;  //actual speed times 4, single byte
  
      //distance from the guidance line in mm
      distanceFromLine = (float)(data[4] << 8 | data[5]);   //high,low bytes     
  
      //set point steer angle * 10 is sent
      steerAngleSetPoint = ((float)(data[6] << 8 | data[7])); //high low bytes 
      steerAngleSetPoint *= 0.01;  

      if (distanceFromLine == 32020 | speeed < 1 | steerSwitch == 1)
      {
        watchdogTimer = 12;//turn off steering motor
      }
      else          //valid conditions to turn on autosteer
      {
        //bitSet(PINB, 5);   //turn LED on
        watchdogTimer = 0;  //reset watchdog
      }
      /*    
      Serial.print(steerAngleActual);   //the pwm value to solenoids or motor
      Serial.print(",");
      Serial.println(XeRoll);
       */
    }

    //autosteer settings
    if (data[0] == 0x7F && data[1] == 0xFC)
    {
      Kp = (float)data[2] * 1.0;   // read Kp from AgOpenGPS
      Ki = (float)data[3] * 0.001;   // read Ki from AgOpenGPS
      Kd = (float)data[4] * 1.0;   // read Kd from AgOpenGPS
      Ko = (float)data[5] * 0.1;   // read Ko from AgOpenGPS
      steeringPositionZero = 385 + data[6];  //read steering zero offset
      minPWMValue = data[7]; //read the minimum amount of PWM for instant on
      maxIntegralValue = data[8]*0.1; //
      steerSensorCounts = data[9]; //sent as 10 times the setting displayed in AOG

      for (int i = 0; i < len; i++) {
        Serial.print(data[i],HEX); Serial.print("\t"); } Serial.println("<--");
    }
    
}
