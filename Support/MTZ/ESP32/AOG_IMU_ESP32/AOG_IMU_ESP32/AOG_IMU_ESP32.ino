// ESP32 code for IMU unit for AgOpenGPS

// with this code you can place an ESP32 and an IMU chip anywhere in your tractor
// supported IMUs: CMPS14 and BNO080 + BNO085

// ready for AOG V5.x.20 Version
// by MTZ8302 see GitHub https://github.com/mtz8302 and Youtube Ma Ha MTZ8302 https://www.youtube.com/channel/UCv44DlUXQJKbQjzaOUssVgw

byte vers_nr = 40;
char VersionTXT[120] = " - 5. April 2021 by MTZ8302<br>(V5, CMPS and Ethernet support)";

//##########################################################################################################
//### Setup Zone ###########################################################################################
//
//Set default values here. They can be changed in webinterface later. (x.x.x.75 or 192.168.1.1)
//
//If you don't get access to webinterface, use serial monitor with USB. IP address is displayed at start.
//
//##########################################################################################################

#define useLED_BUILTIN  0	          // some ESP board have a build in LED (set 1), some not (set 0). Here it's the same funtion as the WiFi LED


struct Storage {
	//WiFi---------------------------------------------------------------------------------------------
	//tractors WiFi or mobile hotspots. Connections are checked in this order
	char ssid1[24] = "GPS_unit_ESP_M8T";	  // WiFi network Client name
	char password1[24] = "";                // WiFi network password//Accesspoint name and password
	char ssid2[24] = "Fendt_209V";			    // WiFi network Client name
	char password2[24] = "";                // WiFi network password//Accesspoint name and password
	char ssid3[24] = "GPS_unit_F9P_Net";    // WiFi network Client name
	char password3[24] = "";                // WiFi network password//Accesspoint name and password
	char ssid4[24] = "CAT S41";             // WiFi network Client name
	char password4[24] = "";                // WiFi network password//Accesspoint name and password
	char ssid5[24] = "WLANHammer";          // WiFi network Client name
	char password5[24] = "";                // WiFi network password//Accesspoint name and password

	char ssid_ap[24] = "IMU_Net";           // name of Access point, if no WiFi found, no password!!
	uint8_t timeoutRouter = 120;//s         // time (s) to search for existing WiFi, than starting Accesspoint 
	byte timeoutWebIO = 10;//min  		      // time (min) afterwards webinterface is switched off	

	byte WiFi_myip[4] = { 192, 168, 1, 75 };      // IMU module 
	byte WiFi_gwip[4] = { 192, 168, 1, 1 };       // Gateway IP only used if Accesspoint created
	byte WiFi_ipDest_ending = 255;                // ending of IP address to send UDP data to
	byte mask[4] = { 255, 255, 255, 0 };
	byte myDNS[4] = { 8, 8, 8, 8 };               // optional

	//Ethernet
	byte Eth_myip[4] = { 192, 168, 1, 76 };       // autosteer module 
	byte Eth_ipDest_ending = 255;                 // ending of IP address to send UDP data to
	byte Eth_mac[6] = { 0x70,0x69,0x69,0x2D,0x30,0x30 };  // must be unique in the network
	bool Eth_static_IP = false;					          // false = use DHPC and set last number to 80 (x.x.x.80) / true = use IP as set above

	unsigned int PortIMUToAOG = 5566;             // this is port of this module: Autosteer = 5577 IMU = 5566 GPS = 
	unsigned int PortFromAOG = 8888;              // port to listen for AOG
	unsigned int PortDestination = 9999;          // Port of AOG that listens
	
	//general settings
	uint8_t aogVersion = 20;			                // Version number of AOG V5: 20	

	byte DataTransVia = 7;                        // transfer data via 0 = USB / 7 = WiFi UDP / 10 = Ethernet UDP

	byte IMUDataRate = 0;							            // 0 = 10 Hz (default) 

	uint8_t IMUType = 2;                          // 0: none, 2: CMPS14, 3: BNO080/85 IMU

	uint8_t InvertRoll = 0;		                    // 0: no, set to 1 to change roll direction

	// BNO08x
	uint8_t bno08xAddresses[2] = { 0x4A,0x4B };	  // BNO08x address variables to check where it is
	float BNOHeadingCorrection = 0.0;		          // not used at the moment
	float BNORollCorrection = 0.0;		            // not used at the moment
	uint8_t BNOUsedAxis = 0;			                // not used at the moment

	//CMPS14
	int CMPS14_ADDRESS = 0x60;                    // Address of CMPS14 shifted right one bit for arduino wire library
	float CMPS14HeadingCorrection = 0.0;		      // not used at the moment
	float CMPS14RollCorrection = 0.0;		          // not used at the moment
	uint8_t CMPS14UsedAxis = 0;		                // not used at the moment

	// IO pins ------------------------------------------------------------------
	// set to 255 for unused

	uint8_t LEDWiFi_PIN = 2;		                  // WiFi Status LED 255 = off
	uint8_t LEDWiFi_ON_Level = 1;                 // 1 = HIGH = LED on high, 0 = LOW = LED on low

	uint8_t SDA = 21;			                        // I2C Pins for CMPS14 / BNO
	uint8_t SCL = 22;

	uint8_t Eth_CS_PIN = 5;		                    // CS PIN with SPI Ethernet hardware  SPI config: MOSI 23 / MISO 19 / CLK18 / CS5


	//##########################################################################################################
	//### End of Setup Zone ####################################################################################
	//##########################################################################################################
	
	bool debugmode = false;

};  Storage Set;

boolean EEPROM_clear = false;  //set to true when changing settings to write them as default values: true -> flash -> boot -> false -> flash again



// sentences to AOG V4.6 and up -------------------------------------------------------------------	
const byte FromAOGSentenceHeader[3] = { 0x80,0x81,0x7F };
#define FromIMUHeader 0x7D
#define IMUDataToAOGHeader  0xD3
#define steerDataFromAOGHeader  0xFE 
#define IMUDataSentenceToAOGLength  10

//global, as serial/USB may not come at once, so values must stay for next loop
byte incomSentenceDigit = 0,DataToAOGLength;
bool isSteerDataFound = false;

#define incommingDataArraySize 5
byte incommingBytes[incommingDataArraySize][500], incommingBytesArrayNr = 0, incommingBytesArrayNrToParse = 0;
unsigned int incommingDataLength[incommingDataArraySize] = { 0,0,0,0,0 };
#define SentenceFromAOGMaxLength 14
byte SentenceFromAOG[SentenceFromAOGMaxLength], SentenceFromAOGLength;

byte IMUToAOG[10] = { 0,0,0,0,0,0,0,0,0,0};


//libraries ---------------------------------------------------------------------------------------
#include "EEPROM.h"
#include <Update.h>
#include "Wire.h"
#include <WiFiUdp.h>
#include <WebServer.h>
#include <WiFiClient.h>
#include <WiFi.h>
#include <Ethernet.h>
#include <EthernetUdp.h>   
#include "BNO08x_AOG.h"

// Instances --------------------------------------------------------------------------------------
WiFiUDP WiFiUDPFromAOG;
WiFiUDP WiFiUDPToAOG;
EthernetUDP EthUDPToAOG;
EthernetUDP EthUDPFromAOG;
WebServer WiFi_Server(80);
BNO080 bno08x;

TaskHandle_t taskHandle_Eth_connect;
TaskHandle_t taskHandle_WiFi_connect;
TaskHandle_t taskHandle_DataFromAOGUSB; bool USBDataTaskRunning = false;
TaskHandle_t taskHandle_DataFromAOGWiFi; bool WiFiDataTaskRunning = false;
TaskHandle_t taskHandle_DataFromAOGEth; bool EthDataTaskRunning = false;
TaskHandle_t taskHandle_WebIO;
TaskHandle_t taskHandle_LEDBlink;


// Variables --------------------------------------------------------------------------------------
// WiFi status LED blink times: searching WIFI: blinking 4x faster; connected: blinking as times set; data available: light on; no data for 2 seconds: blinking
unsigned long LED_WIFI_time = 0, DataFromAOGTime = 0;
#define LED_WIFI_pulse 1000   //light on in ms 
#define LED_WIFI_pause 700    //light off in ms
boolean LED_WIFI_ON = false;

//WIFI+Ethernet
unsigned long WebIOTimeOut = 0, WiFi_network_search_timeout = 0;
byte Eth_connect_step, WiFi_connect_step = 10, WiFi_STA_connect_call_nr = 1, WiFi_netw_nr = 0, my_WiFi_Mode = 0; // WIFI_STA = 1 = Workstation  WIFI_AP = 2  = Accesspoint
IPAddress WiFi_ipDestination, Eth_ipDestination; //set in network.ino
bool EthUDPRunning = false, WebIORunning = true, WiFiUDPRunning = false, newDataFromAOG = false;

//loop time variables in microseconds
unsigned int LOOP_TIME = 20; //50hz 
unsigned int lastTime = LOOP_TIME, now = LOOP_TIME;
byte watchdogTimer = 0;

//IMU, inclinometer variables
//bool imu_initialized = false;
float roll = 0, heading = 0;
int roll16 = 0, heading16 = 0;
// BNO08x address variables to check where it is
int nrBNO08xAdresses = sizeof(Set.bno08xAddresses) / sizeof(Set.bno08xAddresses[0]);
byte bno08xAddress, REPORT_INTERVAL;

float bno08xHeading = 0;
double bno08xRoll = 0;
double bno08xPitch = 0;

int bno08xHeading10x = 0, bno08xRoll10x = 0;

//webpage
long argVal = 0;



// Setup procedure -----------------------------------------------------------------------------------------------

void setup() {
	delay(300);//wait for power to stabilize
	delay(300);//wait for IO chips to get ready

	//init USB
	Serial.begin(38400);
	delay(200); //without waiting, no serial print
	Serial.println();

	//get EEPROM data
	restoreEEprom();
	delay(100);

	//write PGN to output sentence	
	IMUToAOG[0] = FromAOGSentenceHeader[0];   //0x80
	IMUToAOG[1] = FromAOGSentenceHeader[1];   //0x81
	IMUToAOG[2] = FromIMUHeader;   //0x7D
	IMUToAOG[3] = IMUDataToAOGHeader;
	IMUToAOG[4] = IMUDataSentenceToAOGLength - 6; //length of data = all - header - length - CRC
	DataToAOGLength = IMUDataSentenceToAOGLength;
	incomSentenceDigit = 0;


	//set GPIOs
	assignGPIOs_start_extHardware();
	delay(100);

	//data rate 10Hz or 50 Hz
	if (Set.IMUDataRate == 0) { REPORT_INTERVAL = 100; LOOP_TIME = 100; }
	if (Set.IMUDataRate == 1) { REPORT_INTERVAL = 25; LOOP_TIME = 25; }
	if (Set.IMUDataRate == 2) { REPORT_INTERVAL = 25; LOOP_TIME = 28; } //40 Hz but waiting longer for new AOG data



	//start Ethernet
	if (Set.DataTransVia == 10) {
		Eth_connect_step = 10;
		xTaskCreate(Eth_handle_connection, "EthConnectHandle", 3072, NULL, 1, &taskHandle_Eth_connect);
		delay(500);
	}
	else { Eth_connect_step = 255; }

	WiFi_connect_step = 10;//step 10 = begin of starting a WiFi connection

	//start WiFi
	xTaskCreate(WiFi_handle_connection, "WiFiConnectHandle", 3072, NULL, 1, &taskHandle_WiFi_connect);
	delay(500);

	//get Data
	if (Set.DataTransVia < 5) {//USB
		xTaskCreate(getDataFromAOGUSB, "DataFromAOGHandleUSB", 5000, NULL, 1, &taskHandle_DataFromAOGUSB);
	}
	else {
		if (Set.DataTransVia < 10) {//WiFi UDP
			xTaskCreate(getDataFromAOGWiFi, "DataFromAOGHandleWiFi", 5000, NULL, 1, &taskHandle_DataFromAOGWiFi);
		}
		else {
			if (Set.DataTransVia == 10) {//Ethernet UDP
				xTaskCreate(getDataFromAOGEth, "DataFromAOGHandleEth", 5000, NULL, 1, &taskHandle_DataFromAOGEth);
			}
		}
	}
	delay(500);

	//handle WiFi LED status
	xTaskCreate(WiFi_LED_blink, "WiFiLEDBlink", 3072, NULL, 0, &taskHandle_LEDBlink);
	delay(500);

	vTaskDelay(5000); //waiting for other tasks to start

}


// Main loop -----------------------------------------------------------------------------------------------

void loop() {

	//runs allways (not in timed loop)	

	//check for Autosteer Data to get IMU snycron with autosteer
	if (Set.IMUType == 2) {
		//new data from AOG? Data comes via extra task and is written into byte array. Parsing called here
		if (incommingDataLength[incommingBytesArrayNrToParse] != 0) { parseDataFromAOG(); }
		else { vTaskDelay(3); }//wait if no new data to give time to other tasks 
	}
	else vTaskDelay(3);//do other stuff


	//timed loop
	// Loop triggers every 20 msec or when data from AOG came in and sends back  heading and roll
	now = millis();

	if ((now - lastTime >= LOOP_TIME) || (newDataFromAOG))
	{
		newDataFromAOG = false;
		lastTime = millis();

		switch (Set.IMUType) {
		case 0:
			//heading no hardware = 9999     
			IMUToAOG[5] = 0x0F;
			IMUToAOG[6] = 0x27;
			//roll no hardware = 8888
			IMUToAOG[7] = 0xB8;
			IMUToAOG[8] = 0x22;
			LOOP_TIME = 10000; //10 sec
			Serial.println();
			Serial.println("external IMU error: no IMU set or found");
			Serial.println();
			break;

		case 2: //CMPS14
			Wire.beginTransmission(Set.CMPS14_ADDRESS);
			Wire.write(0x02);
			Wire.endTransmission();

			Wire.requestFrom(Set.CMPS14_ADDRESS, 2);
			while (Wire.available() < 2);

			//the heading x10
			IMUToAOG[6] = Wire.read();
			IMUToAOG[5] = Wire.read();
			//convert to float for WebIO
			heading16 = IMUToAOG[6];
			heading16 <<= 8;
			heading16 += IMUToAOG[5];
			heading = float(heading16) / 10;

			Wire.beginTransmission(Set.CMPS14_ADDRESS);
			Wire.write(0x1C);
			Wire.endTransmission();

			Wire.requestFrom(Set.CMPS14_ADDRESS, 2);
			while (Wire.available() < 2);

			//the roll x10
			IMUToAOG[8] = Wire.read();
			IMUToAOG[7] = Wire.read();
			//convert to float for WebIO
			roll16 = IMUToAOG[8];
			roll16 <<= 8;
			roll16 += IMUToAOG[7];
			roll = float(roll16) / 10;
			if (bitRead(roll16, 15)) { roll -= 6554; }
			if (Set.InvertRoll) { roll *= -1; }	//affects only number shown in Webinterface
			break;		
		
		case 3:
			if (bno08x.dataAvailable() == false) { vTaskDelay(2); }//wait 2ms if no new data from BNO			
			if (bno08x.dataAvailable() == true)
			{
				bno08xHeading = (bno08x.getYaw()) * 180.0 / PI; // Convert yaw / heading to degrees
				bno08xHeading = -bno08xHeading; //BNO085 counter clockwise data to clockwise data

				if (bno08xHeading < 0 && bno08xHeading >= -180) //Scale BNO085 yaw from [-180�;180�] to [0;360�]
				{
					bno08xHeading = bno08xHeading + 360;
				}

				bno08xRoll = (bno08x.getRoll()) * 180.0 / PI; //Convert roll to degrees
				bno08xPitch = (bno08x.getPitch()) * 180.0 / PI; // Convert pitch to degrees

				bno08xHeading10x = (int)(bno08xHeading * 10);
				bno08xRoll10x = (int)(bno08xRoll * 10);
				heading = bno08xHeading;
				roll = float(bno08xRoll);

				//the heading x10
				IMUToAOG[5] = (byte)bno08xHeading10x;
				IMUToAOG[6] = bno08xHeading10x >> 8;

				//the roll x10
				IMUToAOG[7] = (byte)bno08xRoll10x;
				IMUToAOG[8] = bno08xRoll10x >> 8;
			}
			break;

		}//end switch case

		//add the checksum
		int CRCtoAOG = 0;
		for (byte i = 2; i < sizeof(IMUToAOG) - 1; i++)
		{
			CRCtoAOG = (CRCtoAOG + IMUToAOG[i]);
		}
		IMUToAOG[sizeof(IMUToAOG) - 1] = CRCtoAOG;

		//Build IMU Packet completed
		//send packet  0 = USB / 7 = WiFi UDP / 10 = Ethernet UDP
		if (Set.DataTransVia < 5) {//USB
			Serial.write(IMUToAOG, sizeof(IMUToAOG));
		}
		else {
			if (Set.DataTransVia < 10) {//WiFi UDP
				if (WiFiUDPRunning) {
					WiFiUDPToAOG.beginPacket(WiFi_ipDestination, Set.PortDestination);
					WiFiUDPToAOG.write(IMUToAOG, sizeof(IMUToAOG));
					WiFiUDPToAOG.endPacket();

				}
			}
			else {//Ethernet
				if (EthUDPRunning) {
					EthUDPToAOG.beginPacket(Eth_ipDestination, Set.PortDestination);
					EthUDPToAOG.write(IMUToAOG, sizeof(IMUToAOG));
					EthUDPToAOG.endPacket();
				}
			}
		}//transmit to AOG

		if (Set.debugmode) {
			Serial.print("Data to AOG: IMU heading: ");
			Serial.print(heading);
			Serial.print(" roll: ");
			Serial.print(roll);
			Serial.print(" checksum: ");
			Serial.println(CRCtoAOG);
			Serial.print("ESP time (millis): ");
			Serial.println(millis());
		}

		vTaskDelay(5);//all done, time to do other stuff

	}  //end of timed loop
}
