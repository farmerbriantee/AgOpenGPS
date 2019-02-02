//##########################################################################################################
//### Setup Zone ###########################################################################################
//##########################################################################################################
//High-Active Relays
  #define ON  1           // set to 0 for Low-active relays
  #define OFF 0           // set to 1 for Low-active relays

  #define AutoMan 0       // 0 = Auto/Manual Switch not installed
                          // 1 = Auto/Manual Switch installed
                          
  #define SectSw 0        // 0 = Section Switches not installed
                          // 1 = Section Switches installed
//Ethernet Details
  #define EtherNet 0      // 0 = Serial/USB communcation with AOG
                          // 1 = Ethernet comunication with AOG (using a ENC28J60 chip)

//##########################################################################################################
//### End of Setup Zone ####################################################################################
//##########################################################################################################
  
  #include "Var.h";

#if (EtherNet)
  #include <EtherCard.h>
  #include <IPAddress.h> 

  //Array to send data back to AgOpenGPS
  byte toSend[] = {0x7F,0xF9,0,0,0,0,0,0,0,0};

  // ethernet interface ip address
  static byte myip[] = { 192,168,1,71 };
  // gateway ip address
  static byte gwip[] = { 192,168,1,1 };
  //DNS- you just need one anyway
  static byte myDNS[] = { 8,8,8,8 };
  //mask
  static byte mask[] = { 255,255,255,0 };
  //this is port of this AG_rate module
  unsigned int portMy = 5555;

  //sending back to where and which port
  static byte ipDestination[] = {192, 168, 1, 255};
  unsigned int portDestination = 9999; //AOG port that listens
  // ethernet mac address - must be unique on your network
  static byte mymac[] = { 0x70,0x69,0x69,0x2F,0x31,0x35 };
  byte Ethernet::buffer[200]; // udp send and receive buffer
#endif

// Pin Configuration
#define WORKSW_PIN 4  //PD4

#if (!EtherNet)
 #define DIR1_PIN   10  //PB2  // Flow Control Valve 1 Left
 #define PWM1_PIN   11  //PB3  //   "
#endif

//TODO -> pins for pwm of second valve ( maybe 5+6 )
#define DIR2_PIN    0  //P??  // Flow Control Valve 2 Right
#define PWM2_PIN    0  //P??  // "

#define encPinLeft  2  //int0 D2 pin 2
#define encPinRight 3  //int1 D3 pin 3

#define RELAY1_PIN  5  //PD5
#define RELAY2_PIN  6  //PD6
#define RELAY3_PIN  7  //PD7
#define RELAY4_PIN  8  //PB0
#define RELAY5_PIN  9  //PB1
#define RELAY6_PIN A0  //PC0
#define RELAY7_PIN A1  //PC1
#define RELAY8_PIN A2  //PC2
#define RELAY9_PIN A3  //PC3
#define RELAY10_PIN A4 //PC4
#if (!EtherNet)
 #define RELAY11_PIN 12 //PB4
 #define RELAY12_PIN 13 //PB5
#endif

#define AUTO_SW     A7  // Section Switches
#define SECT1_SW    A6
#define SECT2_SW    A5


//loop time variables in microseconds
const unsigned long LOOP_TIME = 200; //in msec = 5hz
unsigned long lastTime = LOOP_TIME;
unsigned long currentTime = LOOP_TIME;
unsigned int dT = 100;
byte watchdogTimer = 0;

byte SectMainToAOG = 0;  // output the Switches to AOG
byte SectSWOffToAOG[]={0,0};
byte RelayToAOG[]={0,0};
bool autoMode=0,autoModeold=0;

//the ISR counter
volatile unsigned long pulseCountLeft = 0, pulseDurationLeft;
volatile unsigned long pulseCountRight = 0, pulseDurationRight;

void setup()
{
  pinMode(RELAY1_PIN, OUTPUT); //configure RELAY1 for output //Pin 5
  pinMode(RELAY2_PIN, OUTPUT); //configure RELAY2 for output //Pin 6
  pinMode(RELAY3_PIN, OUTPUT); //configure RELAY3 for output //Pin 7
  pinMode(RELAY4_PIN, OUTPUT); //configure RELAY4 for output //Pin 8
  pinMode(RELAY5_PIN, OUTPUT); //configure RELAY5 for output //Pin 9
  pinMode(RELAY6_PIN, OUTPUT); //configure RELAY6 for output //Pin A0
  pinMode(RELAY7_PIN, OUTPUT); //configure RELAY7 for output //Pin A1
  pinMode(RELAY8_PIN, OUTPUT); //configure RELAY8 for output //Pin A2
  pinMode(RELAY9_PIN, OUTPUT); //configure RELAY9 for output //Pin A3
  pinMode(RELAY10_PIN, OUTPUT); //configure RELAY10 for output //Pin A4
 #if (!EtherNet) 
  pinMode(RELAY11_PIN, OUTPUT); //configure RELAY11 for output //Pin 12
  pinMode(RELAY12_PIN, OUTPUT); //configure RELAY12 for output //Pin 13
  pinMode(DIR1_PIN, OUTPUT);
  pinMode(PWM1_PIN, OUTPUT);
 #endif
  
  pinMode(WORKSW_PIN, INPUT_PULLUP);

  pinMode(AUTO_SW, INPUT);  // Auto/Manual Switch
  pinMode(SECT1_SW, INPUT);
  pinMode(SECT2_SW, INPUT_PULLUP);
  
#if (EtherNet)
 if (ether.begin(sizeof Ethernet::buffer, mymac, 10) == 0)
    Serial.println(F("Failed to access Ethernet controller"));

  //set up connection
  ether.staticSetup(myip, gwip, myDNS, mask); 
  ether.printIp("IP:  ", ether.myip);
  ether.printIp("GW:  ", ether.gwip);
  ether.printIp("DNS: ", ether.dnsip);

  //register udpSerialPrint() to port 8888
  ether.udpServerListenOnPort(&udpRateRecv, 8888);
#endif
  
  //set up communication
  Serial.begin(38400);

  //use CHANGE for more ticks per liter
  attachInterrupt(digitalPinToInterrupt(encPinLeft), pinLeftChangeISR, CHANGE);
  attachInterrupt(digitalPinToInterrupt(encPinRight), pinRightChangeISR, CHANGE);
}

void loop()
{
	currentTime = millis();
	unsigned int time = currentTime;

	if (currentTime - lastTime >= LOOP_TIME)
	{
		dT = currentTime - lastTime;
		lastTime = currentTime;

		//reset ISR Left Side
		countsThisLoopLeft = pulseCountLeft;
		pulseCountLeft = 0;

		if (countsThisLoopLeft)
		{
			//total pulse time over counts in microseconds
			pulseAverageLeft = pulseDurationLeft / countsThisLoopLeft;
			pulseDurationLeft = 0;
		}

		//Right Side
		countsThisLoopRight = pulseCountRight;
		pulseCountRight = 0;

		if (countsThisLoopRight)
		{
			//total pulse time over counts in microseconds
			pulseAverageRight = pulseDurationRight / countsThisLoopRight;
			pulseDurationRight = 0;
		}

		//increase the watchdog - reset in data recv.
		watchdogTimer++;

		//clean out serial buffer
		if (watchdogTimer > 10)
		{
			while (Serial.available() > 0) char t = Serial.read();
			watchdogTimer = 0;
		}

		//accumulated counts from this cycle
		accumulatedCountsLeft += countsThisLoopLeft;
		accumulatedCountsRight += countsThisLoopRight;

		//only if there is flow
		if (countsThisLoopLeft) 
		{    //what is current flowrate from meter
			rateKLeft = (float)pulseAverageLeft * 0.001;
			if (rateKLeft < .001) rateKLeft = 0.1;//prevent divide by zero      //
			else rateKLeft = ((1.0 / rateKLeft) * 60) / flowmeterCalFactorLeft;

			//Kalman filter
			PcLeft = PLeft + varProcessLeft;
			GLeft = PcLeft / (PcLeft + varRateLeft);
			PLeft = (1 - GLeft) * PcLeft; XpLeft = XeRateLeft; ZpLeft = XpLeft;
			XeRateLeft = GLeft * (rateKLeft - ZpLeft) + XpLeft;

			rateAppliedLPMLeft = XeRateLeft * 100; //fill in formatted rateApplied
		}
		else 
		{
			rateKLeft = 0.1;
			rateAppliedLPMLeft = 0;
		}

		//only if there is flow
		if (countsThisLoopRight) 
		{      //what is current flowrate from meter
			rateKRight = (float)pulseAverageRight * 0.001;
			if (rateKRight < .001) rateKRight = 0.1;//prevent divide by zero    //
			else rateKRight = ((1.0 / rateKRight) * 60) / flowmeterCalFactorRight;

			//Kalman filter
			PcRight = PRight + varProcessRight;
			GRight = PcRight / (PcRight + varRateRight);
			PRight = (1 - GRight) * PcRight; XpRight = XeRateRight; ZpRight = XpRight;
			XeRateRight = GRight * (rateKRight - ZpRight) + XpRight;

			rateAppliedLPMRight = XeRateRight * 100; //fill in formatted rateApplied
		}
		else 
		{
			rateKRight = 0.1;
			rateAppliedLPMRight = 0;
		}

    // read the workswitch
    if (digitalRead(WORKSW_PIN)) SectMainToAOG = 1; else SectMainToAOG = 2;
  #if AutoMan   
    // read the Auto/Manual Switch (A7 is only analogRead, no Pullup)
    if (analogRead(AUTO_SW)>500) autoMode=1; else autoMode=0;
  #endif
    
  #if SectSw  
    // read Section 1 Switch (A6 is only analogRead, no Pullup)
    if (analogRead(SECT1_SW)<500){
        SectSWOffToAOG[0] |= 0x01;    // Sw Off means permanent Off in Auto-Mode
        RelayToAOG[0]     &= 0xFE;    // Sw Off means permanent Off in Manual-Mode
      } 
    else{
        if (autoMode){
          if (autoModeold==0) SectSWOffToAOG[0] |= 0x01; // short Off to switch back to SC
          else SectSWOffToAOG[0] &= 0xFE;                // Sw On means Section Ctrl in Auto-Mode
          RelayToAOG[0]    &= 0xFE;                      // No relay control
          autoModeold=1;
        }
        if (autoMode==0){
          SectSWOffToAOG[0] &= 0xFE;    // Sw On = No Switch Off control
          RelayToAOG[0]     |= 0x01;    // Sw On means permanent On in Manual-Mode
          autoModeold=0;
        }
      }


    
    // read Section 2 Switch  
    if (digitalRead(SECT2_SW)==0){
        SectSWOffToAOG[0] |= 0x02;    // Sw Off means permanent Off in Auto-Mode
        RelayToAOG[0]     &= 0xFD;    // Sw Off means permanent Off in Manual-Mode
      } 
    else{
        if (autoMode){
          if (autoModeold==0) SectSWOffToAOG[0] |= 0x02; // short Off to switch back to SC
          else SectSWOffToAOG[0] &= 0xFD;                // Sw On means Section Ctrl in Auto-Mode
          RelayToAOG[0]    &= 0xFD;                      // No relay control
          autoModeold=1;
        }
        if (autoMode==0){
          SectSWOffToAOG[0] &= 0xFD;    // Sw On = No Switch Off control
          RelayToAOG[0]     |= 0x02;    // Sw On means permanent On in Manual-Mode
          autoModeold=0;
        }
      }
   #else
      SectSWOffToAOG[0] = 0;    // Sw Off means permanent Off in Auto-Mode
      RelayToAOG[0]     = 0;    // Sw Off means permanent Off in Manual-Mode
   #endif
   
      //turn on appropriate sections

      SetRelays();

      //Do the PID - this placed in code depending on valve style
      rateErrorLeft = rateSetPointLeft - rateKLeft;
      rateErrorRight = rateSetPointRight - rateKRight;

      //Left side or single meter
      calcRatePIDLeft();
 #if (!EtherNet) // Since pins are reserved for Ethernet no Ratecontrol possible
      motorDriveLeft();
 #endif

      //Also needs right side for dual
      calcRatePIDRight();
      motorDriveRight();

  
  #if (EtherNet)
    transmitEthernet();
  #else 
    transmitSerial();
	#endif
  	
	} //end of timed loop

	//****************************************************************************************
	//This runs continuously, outside of the timed loop, keeps checking for new data
	// header high/low, relayHi/Lo byte, speed byte, rateSetPoint hi/lo
   
 #if (EtherNet)
  delay(10); 
  //this must be called for ethercard functions to work.
  ether.packetLoop(ether.packetReceive());  
 #else
  receiveSerial();
 #endif
	
} //end of main loop


//ISR
void pinLeftChangeISR() {
	static unsigned long pulseStartLeft = 0;
	pulseCountLeft++;
	pulseDurationLeft += (millis() - pulseStartLeft); // get the pulse length
	pulseStartLeft = millis(); // store the current microseconds and start clock again
}

void pinRightChangeISR() {
	static unsigned long pulseStartRight = 0;
	pulseCountRight++;
	pulseDurationRight += (millis() - pulseStartRight); // get the pulse length
	pulseStartRight = millis(); // store the current microseconds and start clock again       ctr++;
}
