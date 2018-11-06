#include "BNO055_AOG.h"
#include <Wire.h>

#include <EtherCard.h>
#include <IPAddress.h> 

#define A 0X28  //I2C address selection pin LOW
#define B 0x29  //                        HIGH
  
//ethercard 8,11,12,13   

//instance of the imu
BNO055 IMU(A);

//loop time variables in microseconds
const unsigned int LOOP_TIME = 100; //10hz
unsigned int lastTime = LOOP_TIME;
unsigned int currentTime = LOOP_TIME;
unsigned int dT = 50000;
unsigned int count = 0;

//Kalman variables
float rollK = 0, Pc = 0.0, G = 0.0, P = 1.0, Xp = 0.0, Zp = 0.0;
float XeRoll = 0;
const float varRoll = 0.1; // variance,
const float varProcess = 0.0001; //smaller is more filtering
/*
float setK = 0, setPc = 0.0, setG = 0.0, setP = 1.0, setXp = 0.0, setZp = 0.0;
float setXe = 0;
const float setVariance = 0.1; // variance,
const float setProcess = 0.001; //smaller is more filtering
*/

//inclinometer variables
int roll = 0;

//Array to send data back to AgOpenGPS
byte toSend[] = {0,0,0,0,0,0,0,0,0,0};

// ethernet interface ip address
static byte myip[] = { 192,168,1,74 };
// gateway ip address
static byte gwip[] = { 192,168,1,1 };
//DNS- you just need one anyway
static byte myDNS[] = { 8,8,8,8 };
//mask
static byte mask[] = { 255,255,255,0 };
//this is port of this module
unsigned int portMy = 5544; 

//sending back to where and which port
static byte ipDestination[] = {192, 168, 1, 255};
unsigned int portDestination = 9999; 

// ethernet mac address - must be unique on your network
static byte mymac[] = { 0x70,0x71,0x71,0x2D,0x30,0x31 };

byte Ethernet::buffer[200]; // udp send and receive buffer

void setup()
{    
	//set up communication
	Wire.begin();
	Serial.begin(38400);
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

 if (ether.begin(sizeof Ethernet::buffer, mymac) == 0)
    Serial.println(F("Failed to access Ethernet controller"));

  //set up connection
  ether.staticSetup(myip, gwip, myDNS, mask); 
  ether.printIp("IP:  ", ether.myip);
  ether.printIp("GW:  ", ether.gwip);
  ether.printIp("DNS: ", ether.dnsip);

  //set up the pgn for returning data
  toSend[0] = 0x7F;
  toSend[1] = 0xEE;
  
  //register udpSerialPrint() to port 8888
  ether.udpServerListenOnPort(&udpIMU, 8888);
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

		IMU.readIMU();

		//inclinometer
		delay(1);
		analogRead(A1); //discard
		delay(1);
		roll = analogRead(A1);   delay(2);
		roll += analogRead(A1);   delay(2);
		roll += analogRead(A1);   delay(2);
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
    
    //Kalman filter for setpoint
    /* setPc = setP + setProcess;
    setG = setPc / (setPc + setVariance);
    setP = (1 - setG) * setPc;
    setXp = setXe;
    setZp = setXp;
    setXe = setG * (steerAngleSetPoint - setZp) + setXp;
    */
  
    int temp;

    //imu heading --- * 16 in degrees
    temp = IMU.euler.head;
    toSend[4] = (byte)(temp >> 8);
    toSend[5] = (byte)(temp);
    
    //Vehicle roll --- * 16 in degrees
    temp = XeRoll;
    toSend[6] = (byte)(temp >> 8);
    toSend[7] = (byte)(temp);

    //off to AOG
    ether.sendUdp(toSend, sizeof(toSend), portMy, ipDestination, portDestination);
    
	} //end of timed loop

  delay(10);
  //this must be called for ethercard functions to work.
  ether.packetLoop(ether.packetReceive());  
}

//callback when received packets
void udpIMU(uint16_t dest_port, uint8_t src_ip[IP_LEN], uint16_t src_port, byte *data, uint16_t len)
{
  /* IPAddress src(src_ip[0],src_ip[1],src_ip[2],src_ip[3]); 
  Serial.print("dPort:");  Serial.print(dest_port);
  Serial.print("  sPort: ");  Serial.print(src_port); 
  Serial.print("  sIP: ");  ether.printIp(src_ip);  Serial.println("  end");*/

  //for (int i = 0; i < len; i++) {
    //Serial.print(data[i],HEX); Serial.print("\t"); } Serial.println(len);

    if (data[0] == 0x7F && data[1] == 0xEF) //Data
    {

    }
    
}
