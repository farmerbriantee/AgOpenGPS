
// Section Control code for AgOpenGPS V 4.3.10 (=V17) and V5 for Arduino Nano 33 IoT

// by MTZ8302 see GitHub https://github.com/mtz8302 and Youtube Ma Ha MTZ8302 https://www.youtube.com/channel/UCv44DlUXQJKbQjzaOUssVgw

// can be used as output only = relais for sections
// or for documentation = input only = input to ESP32 -> enables mapping for active (=switch to GND) section in AOG
// or any combination = section control with input switch
// main and pressure switches are (ON)-0-(ON) toggle switches (GND)- 1.75V - (3,3V). So use 2 resistors GND- 1K - (COM on toggle switch) - 1K - 3.3V
// code fits for WEder section control PCB

// connects to existing WiFi network or creates access point. Settings below or in WebInterface at 192.168.1.71



byte vers_nr = 46;
char VersionTXT[150] = " - 5. April 2021 by MTZ8302 WebIO by coffeetrac<br>(Nano 33Iot only, V5 ready, 2 WiFi networks)";

struct set {
	//User config: ***********************************************************************************

	uint8_t DataTransVia = 7;			    //transfer data via 0 = USB / 7 = UDP
	uint8_t aogVersion = 20;

	uint8_t LEDWiFi_PIN = 13;			    // WiFi Status LED 0 = off
	uint8_t LEDWiFi_ON_Level = 1;		  // 1 = HIGH = LED on high, 0 = LOW = LED on low

	//WiFi---------------------------------------------------------------------------------------------
	//tractors WiFi or mobile hotspots. Connections are checked in this order
	char ssid1[24] = "GPS_unit_ESP_M8T";	    // WiFi network Client name
	char password1[24] = "";				          // WiFi network password//Accesspoint name and password
	char ssid2[24] = "Deutz_6006";			      // WiFi network Client name
	char password2[24] = "";                  // WiFi network password//Accesspoint name and password

	char ssid_ap[24] = "SectionControlNet";   // name of Access point, if no WiFi found, no password!!
	uint8_t timeoutRouter = 30;               // time (s) to search for existing WiFi, then starting Accesspoint
	uint8_t timeoutRouter2 = 30;
	byte timeoutWebIO = 10;					          //time (min) afterwards webinterface is switched off	

	//WiFi
	byte WiFi_myip[4] = { 192, 168, 1, 71 };   // Roofcontrol module 
	byte WiFi_gwip[4] = { 192, 168, 1, 1 };    // Gateway IP only used if Accesspoint created
	byte WiFi_ipDest_ending = 255;				     //ending of IP address to send UDP data to
	byte mask[4] = { 255, 255, 255, 0 };
	byte myDNS[4] = { 8, 8, 8, 8 };				     //optional

	uint16_t PortSCToAOG = 5555;		           // this is port of this module: Autosteer = 5577 IMU = 5566 Section Control = 5555 GPS = 5544
	uint16_t PortFromAOG = 8888;               // port to listen for AOG
	uint16_t PortDestination = 9999;           // Port of AOG that listens
	uint16_t BaudRate = 38400;                 // Baudrate = speed of serial port or USB or Bluetooth. AOG uses 38400 for UART

//the following lines should be configed by the user to fit the programm to the sprayer/ESP32
//GPIOs of the ESP32 (current setting is for the layout shown as example WIKI)

// if only 1 flowrate is used, use left
//Example1: motor valve is controled only by Switch not by AOG, no Flowmeter, : RateControl..Equiped = false; RateSW..Equiped = true; RateControlPWM = false;
//Example2: PWM valve, with flowmeter all controled by AOG:   RateControl..Equiped = true; RateSW..Equiped = true; RateControlPWM = true;	
	uint8_t RateControlLeftInst = 0;		// 1 if Rate control is there, else: 0
	uint8_t RateSWLeftInst = 1;			    // 1 if Rate control Pressure switch is there, else: 0
	uint8_t RateSWLeft_PIN = A6;			  // Rate +/- switch
	uint8_t RateControlPWM = 0;				  // 1 if PWM valve, 0 if Motor drive for pressure change		

	uint8_t	FlowDirLeft_PIN = 12;			  // Rate-Control Valve/Motor Direktion
	uint8_t	FlowPWMLeft_PIN = 11;			  // Rate-Control Valve PWM/Motor ON/OFF
	uint8_t	FlowEncALeft_PIN = 255;			// Flowmeter left/1

	uint8_t RateControlRightInst = 0;	  // 1 if Rate control is there, else: 0
	uint8_t RateSWRightInst = 0;			  // 1 if Rate control Pressure switch is there, else: 0	
	uint8_t	RateSWRight_PIN = 255;			// Rate +/- switch (ON)-0-(ON) toggle switch (GND)- 1.75V - (3,3V)
	uint8_t	FlowDirRight_PIN = 255;			// 255  = unused Rate-Control Valve Direktion
	uint8_t	FlowPWMRight_PIN = 255;			// 255  = unused Rate-Control Valve PWM
	uint8_t	FlowEncARight_PIN = 255;		// Flowmeter right/2 

	uint8_t SectNum = 6;					      // number of sections
	uint8_t SectRelaysInst = 1;				  // relays for SC output are equiped (0=no output, only documentation)
	uint8_t SectRelaysON = 1;				    // relays spray on 1 or 0 (high or low)
	uint8_t Relay_PIN[16] = { 10,9,8,7,6,5,255,255,255,255,255,255,255,255,255,255 };  //GPIOs of ESP32 OUT to sections of sprayer HIGH/3.3V = ON
	uint8_t Relais_MainValve_PIN = 255;	// PIN for Main fluid valve 255 = unused
	uint8_t SectSWInst = 1;					    // 1 if section input switches are equiped, else: 0	
	uint8_t SectSWAutoOrOn = 1;				  // Section switches spray/auto on 1 = high = used with pullup, 0 = low = pulldown 

	uint8_t SectSW_PIN[16] = { A0,A1,A2,A3,A4,A5,3,255,255,255,255,255,255,255,255,255 };// section switches to GPIOs of ESP32 GND = section off, open/+3.3V section auto/on

	uint8_t	SectMainSWType = 1;				  // 0 = not equiped 1 = (ON)-OFF-(ON) toggle switch or push buttons 2 = connected to hitch level sensor 3 = inverted hitch level sensor
	uint16_t HitchLevelVal = 500;		    // Value for hitch level: switch AOG section control to Auto if lower than... ESP:2000 nano 500
	uint8_t	SectMainSW_PIN = A7;			  // Nano33IoT to AOG Main auto toggle switch open=nothing/AOG button GND=OFF +3,3=AOG Auto on	OR connected to hitch level sensor	
	uint8_t	SectAutoManSW_PIN = 4;			// Main Auto/Manual switch 39:!!no internal pullup!!

	uint8_t DocOnly = 0;					      // 0: use as section control, 1: Documentation only = AOG writes the state of the input switches



	bool debugmode = false;
	bool debugmodeRelay = false;
	bool debugmodeSwitches = false;
	bool debugmodeDataFromAOG = false;
	bool debugmodeDataToAOG = false;

	// END of user config ****************************************************************************
}; set Set;


bool EEPROM_clear = false;



byte SCToAOG[14] = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0}, SCToAOGOld[14] = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0};

//Sentence up to V4.3 -----------------------------------------------------------------------------	
#define SCDataFromAOGHeaderV17  0xFA
#define SCDataToAOGHeaderV17  0xF9
#define SCDataSentenceToAOGLengthV17  10

// sentences to AOG V4.6 and up -------------------------------------------------------------------	
const byte AOGSentenceHeader[3] = { 0x80,0x81,0x7F };
#define SCDataToAOGHeader  0xEA
#define SteerDataFromAOGHeader  0xFE  //take section info from steer packet
#define SCSettingsFromRCHeader  0xFC
#define SCDataSentenceToAOGLength  14

//write incoming Data to sentence array if it fits in
#define SentenceFromAOGMaxLength 14
byte SentenceFromAOG[SentenceFromAOGMaxLength], SentenceFromAOGLength;

//global, as serial/USB may not come at once, so values must stay for next loop
byte incomSentenceDigit = 0,DataToAOGLength;
bool isSteerDataFound = false, isRCSettingFound = false;
bool isSCDataFoundV17 = false;

#define incommingDataArraySize 5
byte incommingBytes[incommingDataArraySize][500], incommingBytesArrayNr = 0, incommingBytesArrayNrToParse = 0;
unsigned int incommingDataLength[incommingDataArraySize] = { 0,0,0,0,0 };

//WIFI+Ethernet
IPAddress WiFi_ipDestination, Eth_ipDestination; //set in network.ino
byte WiFi_connect_step = 10, WiFi_netw_nr = 0, WiFi_STA_connect_call_nr = 0, my_WiFi_Mode = 0; // WIFI_STA = 1 = Workstation  WIFI_AP = 2  = Accesspoint
//int pingResult, WiFiWatchDog = 0;
bool WiFiUDPRunning = false, EthUDPRunning = false;
unsigned long WebIOTimeOut = 0,  WiFi_connect_timer = 0, WiFi_network_search_timeout = 0;//PingToNetworkLastTime = 0,
//webpage
long argVal = 0;
bool WebIORunning = false;

// WiFi LED blink times: searching WIFI: blinking 4x faster; connected: blinking as times set; data available: light on; no data for 2 seconds: blinking
unsigned int LED_WIFI_time = 0;
unsigned int LED_WIFI_pulse = 2000;   //light on in ms 
unsigned int LED_WIFI_pause = 1500;    //light off in ms
boolean LED_WIFI_ON = false;
unsigned long timeout, timeout2;



//ToDo: - Rate / flowmeter doesn't work, interrupt mode ect not defined
//      - line 260 PWM + Interrupt mode ect...
//		  - Right side Rate caluclation / output / Motordrive
//      - Manual mode for Rate Control
//		  - what to do if no WIFI??


//libraries -------------------------------
#include <WiFiNINA.h>
#include <FlashAsEEPROM.h>
#include <WiFiUdp.h>
#include <WiFiServer.h>
#include <WiFiClient.h>
#include <WiFi.h>
WiFiServer server(80);
WiFiClient client_page;
WiFiUDP WiFiUDPFromAOG = WiFiUDP();
WiFiUDP WiFiUDPToAOG = WiFiUDP();

//values to decide position of section switch
#define SWOFF 300 // analog in is lower than .. for off
#define SWON  700 // analog in is lower than .. for auto/on

//analog value of the toggle switches (default: middle=unpressed)
int MainSWVal = (SWOFF + SWON) / 2;
int MainSWValOld = (SWOFF + SWON) / 2;
int RateSWLeftVal = (SWOFF + SWON) / 2;
int RateSWRightVal = (SWOFF + SWON) / 2;

//state of the switches HIGH = ON/Auto LOW = OFF	
boolean SectSWVal[16] = { HIGH,HIGH,HIGH,HIGH,HIGH,HIGH,HIGH,HIGH,HIGH,HIGH,HIGH,HIGH,HIGH,HIGH,HIGH,HIGH };
boolean AutoSWVal = HIGH;
byte debugmodeSwitchesBak = 3;  //0 = false 1 = true 3 = not used

//loop time variables in microseconds
const unsigned long LOOP_TIME_sendDataToAOG = 1000;// 400; //in msec; 1000 = 1 Hz
const unsigned long LOOP_TIME_WiFiAndBlinkHandle = 50;
const unsigned long SectSWDelayTime = 200;// 1500;//1400; //time the arduino waits after manual Switch is used before acception command from AOG in msec
unsigned long now, lastTime_LOOP_WiFiAndBlinkHandle = 0, lastTime_LOOP_DataToAOG = 0;
unsigned long DataFromAOGTime = 0;
unsigned long SectAutoSWTime = LOOP_TIME_sendDataToAOG;
unsigned long SectAutoSWlastTime = LOOP_TIME_sendDataToAOG;
unsigned long SectMainSWlastTime = LOOP_TIME_sendDataToAOG;
unsigned long RateSWlastTimeLeft = LOOP_TIME_sendDataToAOG;
unsigned long RateSWDelayTime = 250; //time to pass before a new toggle of switch is accepted = if hold down, time between steps
unsigned long RateSWlastTimeRight = LOOP_TIME_sendDataToAOG;
unsigned long SectSWcurrentTime = LOOP_TIME_sendDataToAOG;


/* no rate control in AOG
//Kalman variables Left
float rateKLeft = 0;
float PcLeft = 0.0;
float GLeft = 0.0;
float PLeft = 1.0;
float XpLeft = 0.0;
float ZpLeft = 0.0;
float XeRateLeft = 0; //the filtered flowrate
const float varRateLeft = 100; // variance, smaller, more filtering
const float varProcessLeft = 10;

//Kalman variables Right
float rateKRight = 0;
float PcRight = 0.0;
float GRight = 0.0;
float PRight = 1.0;
float XpRight = 0.0;
float ZpRight = 0.0;
float XeRateRight = 0; //the filtered flowrate
const float varRateRight = 100; // variance, smaller, more filtering
const float varProcessRight = 10;
*/

//program flow
//bool NewDataFromAOG = false, NewSettingFromAOG = false;

//bit 0 on byte[0] is section 1
byte SectGrFromAOG[] = { 0, 0 }; //Sections ON / OFF Bitwise !!! 
byte RelayOUT[] = { 0,0 }; //Sections ON / OFF Bitwise !!! 
byte RelayOUTOld[] = { 0,0 };
byte SectSWOffToAOG[] = { 0,0 };
byte SectMainToAOG = 0;
byte uTurnRelay = 0;
//  byte flowRateSW1 = 0;
boolean SectMainSWpressed = false;
boolean SectSWpressed = false;
boolean SectSWpressedLoop = false;
boolean SectAuto = true;
boolean SectAutoOld = true;
boolean SectAutoSWpressed = false;
//boolean RateAuto = false;
boolean RateManUpLeft = false;
boolean RateManUpRight = false;
boolean RateManDownLeft = false;
boolean RateManDownRight = false;

boolean SectMainOn = false;

boolean newDataToAOG = false;// newDataFromAOG = false;

float gpsSpeed = 0; //speed from AgOpenGPS
float rateSetPointLeft = 0.0;
float countsThisLoopLeft = 0;
float rateErrorLeft = 0; //for PID
int rateAppliedLPMLeft = 0;
float rateSetPointRight = 0.0;
float countsThisLoopRight = 0;
float rateErrorRight = 0; //for PID
int rateAppliedLPMRight = 0;

unsigned long accumulatedCountsLeft = 0;
float flowmeterCalFactorLeft = 50;
unsigned long accumulatedCountsRight = 0;
float flowmeterCalFactorRight = 50;
unsigned long accumulatedCountsDual = 0;

float pulseAverageLeft = 0;
float pulseAverageRight = 0;

//the ISR counter
volatile unsigned long pulseCountLeft = 0, pulseDurationLeft;
volatile unsigned long pulseCountRight = 0, pulseDurationRight;
bool state = false;



void setup()
{
	delay(200);//wait for power to stabilize
	delay(200);//wait for IO chips to get ready
	//set up communication
	Serial.begin(Set.BaudRate);
	delay(10);
	delay(50);
	Serial.println();
	Serial.println("begin of setup");
	//get EEPROM data
	restoreEEprom();
	delay(100);
	if (Set.aogVersion == 17) {
		SCToAOG[0] = AOGSentenceHeader[2];
		SCToAOGOld[0] = AOGSentenceHeader[2];
		SCToAOG[1] = SCDataToAOGHeaderV17;
		SCToAOGOld[1] = SCDataToAOGHeaderV17;
		SCToAOG[2] = 0;
		SCToAOG[3] = 0;
		SCToAOG[4] = 0;
		SCToAOG[5] = 0;
		SCToAOG[6] = 0;
		DataToAOGLength = SCDataSentenceToAOGLengthV17;
		incomSentenceDigit = 2;
	}
	else {
		SCToAOG[0] = AOGSentenceHeader[0];   //0x80
		SCToAOG[1] = AOGSentenceHeader[1];   //0x81
		SCToAOG[2] = AOGSentenceHeader[2];   //0x7F
		SCToAOG[3] = SCDataToAOGHeader;		 //0xEA
		SCToAOG[4] = SCDataSentenceToAOGLength - 6; //length of data = all - header - length - CRC
		SCToAOGOld[0] = AOGSentenceHeader[0];
		SCToAOGOld[1] = AOGSentenceHeader[1];
		SCToAOGOld[2] = AOGSentenceHeader[2];
		SCToAOGOld[3] = SCDataToAOGHeader;
		SCToAOG[4] = SCDataSentenceToAOGLength - 6;
		SCToAOG[6] = 0;
		SCToAOG[7] = 0;
		SCToAOG[8] = 0;
		DataToAOGLength = SCDataSentenceToAOGLength;
		incomSentenceDigit = 0;
	}

	//set GPIOs
	assignGPIOs();

	delay(50);

	//switches -> set relais
	if ((Set.SectSWInst) || (Set.SectMainSWType != 0)) {
		SectSWRead();
	}
	SetRelays();
	//Rate switches and motor drive
	if ((Set.RateSWLeftInst == 1) || (Set.RateSWRightInst == 1)) { RateSWRead(); }
	if (Set.RateControlLeftInst == 0) { motorDrive(); } //if Manual do everytime, not only in timed loop

	//start WiFi
	WiFi_netw_nr = 1;
	WiFi_Start_STA();
	delay(200);
	//try 2. wifi network if no connection
	if (my_WiFi_Mode == 0) { WiFi_netw_nr = 2; WiFi_Start_STA(); }
	delay(200);
	if (my_WiFi_Mode == 0) {// if failed start AP
		WiFi_netw_nr = 0;
		WiFi_Start_AP();
		delay(100);
	}
	delay(100);

	UDP_Start();
	delay(100);
	//start server for settings homepage
	server.begin();
	delay(100);
	if (Set.DataTransVia < 5) { Serial.println("data transfer via USB"); }
	else {
		 Serial.println("data transfer via UDP"); 
	}
	WebIORunning = true;
	WebIOTimeOut = millis() + long((Set.timeoutWebIO * 60000));
}


//-------------------------------------------------------------------------------------------------

void loop() {
	//Serial.println("begin of loop");

	if (Set.DataTransVia < 5) {
		for (;;) {
			if (!getDataFromAOGUSB()) { break; }
		}
	}
	else {
		for (;;) {
			delay(0);
			if (!getDataFromAOGWiFi()) { break; }
		}
	}
	//Serial.println("after get data");

	//new data from AOG? Data comes via extra task and is written into byte array. Parsing called here
	if (incommingDataLength[incommingBytesArrayNrToParse] != 0) { parseDataFromAOG(); }
	else { delay(1); }//wait if no new data to give time to other tasks 

	//read switches/inputs
	if ((Set.SectSWInst) || (Set.SectMainSWType != 0))
	{
		SectSWRead(); //checks if section switch is toggled and sets RelayOUT

		//reset debugSwitches: has been change to true, if debugmodeDataToAOG = true for 1 loop
		if ((Set.debugmodeSwitches) && (debugmodeSwitchesBak == 0)) { Set.debugmodeSwitches = false; }

		if (Set.aogVersion == 17) {
			//SCToAOG 5+6 set in ReadSwitches_buildBytes HiByte, LowByte if bit set -> AOG section forced ON
			SCToAOG[7] = SectSWOffToAOG[1]; //HiByte if bit set -> AOG section forced off
			SCToAOG[8] = SectSWOffToAOG[0]; //LowByte if bit set -> AOG section forced off
			SCToAOG[9] = SectMainToAOG; // Bits: AOG section control AUTO, Section control OFF, Rate L+R ...
			//new data?
			for (byte idx = 2; idx < DataToAOGLength; idx++) {
				if (SCToAOG[idx] != SCToAOGOld[idx]) {
					newDataToAOG = true;
					SCToAOGOld[idx] = SCToAOG[idx];
				}
			}
		}
		else {
			SCToAOG[10] = SectSWOffToAOG[0]; //LowByte if bit set -> AOG section forced off
			SCToAOG[12] = SectSWOffToAOG[1]; //HiByte if bit set -> AOG section forced off
			SCToAOG[5] = SectMainToAOG; // Bits: AOG section control AUTO, Section control OFF, Rate L+R ...
			//new data?
			for (byte idx = 5; idx < DataToAOGLength; idx++) {
				if (SCToAOG[idx] != SCToAOGOld[idx]) {
					newDataToAOG = true;
					SCToAOGOld[idx] = SCToAOG[idx];
				}
			}
		}
	}
	//no switches: set Relais as AOG commands
	else { RelayOUT[0] = SectGrFromAOG[0]; RelayOUT[1] = SectGrFromAOG[1]; }

	SetRelays();

	delay(0);//do WiFi

	//Rate switches and motor drive
	if ((Set.RateSWLeftInst == 1) || (Set.RateSWRightInst == 1)) { RateSWRead(); }

	if (Set.RateControlLeftInst == 0) { motorDrive(); } //if Manual do everytime, not only in timed loop

	delay(0);

if (WebIORunning){
		doWebInterface(); //does the Webinterface
		delay(0);
		if (millis() > WebIOTimeOut) {
			WebIORunning = false;
		}
	}

	now = millis();

	//50ms LOOP
	if (now > LOOP_TIME_WiFiAndBlinkHandle + lastTime_LOOP_WiFiAndBlinkHandle) {

		//check if data is comming in as it should
		if ((now > (DataFromAOGTime + 600)) && (DataFromAOGTime > 0)) {
			if (SectAuto) { WiFi_LED_blink(3); }
			else { WiFi_LED_blink(0); }

			//check WiFi connection and reconnect if neccesary
			//if ((SCSet.DataTransVia == 1) && (NetWorkNum > 0)) { WiFi_connection_check(); }
		}
		else {
			if (!LED_WIFI_ON) {// turn LED on
				digitalWrite(Set.LEDWiFi_PIN, Set.LEDWiFi_ON_Level);
				LED_WIFI_ON = true;
			}
		}

		delay(1);

		now = millis();
		lastTime_LOOP_WiFiAndBlinkHandle = now;
	}

	

	//1000 ms timed loop: runs with 1Hz or if new data from switches to send data to AOG
	//must run, also if nothing changed on switches, to keep GUI syncron (important if a section switch is off)
	if ((now > LOOP_TIME_sendDataToAOG + lastTime_LOOP_DataToAOG) || (newDataToAOG)) {
		
		delay(1);

		lastTime_LOOP_DataToAOG = millis();

		if (Set.aogVersion != 17) {
			//add the checksum
			int CRCtoAOG = 0;
			for (byte i = 2; i < sizeof(SCToAOG) - 1; i++)
			{
				CRCtoAOG = (CRCtoAOG + SCToAOG[i]);
			}
			SCToAOG[sizeof(SCToAOG) - 1] = CRCtoAOG;

		}

		AOGDataSend();
		if (newDataToAOG) {
			delay(5);
			newDataToAOG = false;
			AOGDataSend(); //send 2. time for safety

			//delay(10);
			//AOGDataSend(); //send 3. time for safety
		}

		if (Set.debugmodeDataToAOG) {
			Serial.print("Data to AOG ");
			for (byte n = 0; n < DataToAOGLength; n++) {
				Serial.print(SCToAOG[n]); Serial.print(" ");
			}
			Serial.println();
			//printing swich input 1x:
			if (!Set.debugmodeSwitches) {
				debugmodeSwitchesBak = 0;
				Set.debugmodeSwitches = true;
			}
			else debugmodeSwitchesBak = 1;
		}

	}
}
