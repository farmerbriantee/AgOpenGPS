#include <EtherCard.h>

// user settings ****************************

#define CommType 1			// 0 Serial/USB , 1 UDP wired Nano

#define IPpart3 1			// ex: 192.168.IPpart3.255, 0-255
#define IPMac 188			// unique number for Arduino IP address and Mac part 6, 0-255

// ******************************************

#if(CommType == 1)
// ethernet interface ip address
static byte ArduinoIP[] = { 192,168,IPpart3,IPMac };

// ethernet interface Mac address
static byte LocalMac[] = { 0x70,0x2D,0x31,0x21,0x62,IPMac };

// gateway ip address
static byte gwip[] = { 192,168,IPpart3,1 };
//DNS- you just need one anyway
static byte myDNS[] = { 8,8,8,8 };
//mask
static byte mask[] = { 255,255,255,0 };

// local ports on Arduino
unsigned int SourcePort = 6200;		// to send from 

// ethernet destination - Rate Controller
static byte DestinationIP[] = { 192, 168, IPpart3, 255 };	// broadcast 255
unsigned int DestinationPort = 29999; // Rate Controller listening port 

byte Ethernet::buffer[500]; // udp send and receive buffer
#endif

//Array to send data back 
byte toSend[] = { 127,106,0,0 };
byte Pins[] = { 0,0,0,0,0,0,0,0,0 };

#define SW0pin	A4
#define SW1pin	9
#define SW2pin	6

#define SW3pin 4
#define AutoPin 5
#define MasterOnPin 3

#define MasterOffPin A5	//2 
#define RateUpPin A3
#define RateDownPin A2

unsigned long LastTime;

void setup()
{
	Serial.begin(38400);

	delay(5000);
	Serial.println();
	Serial.println("SWarduino  :  10-Mar-2021");
	Serial.println();

	pinMode(SW0pin, INPUT_PULLUP);
	pinMode(SW1pin, INPUT_PULLUP);
	pinMode(SW2pin, INPUT_PULLUP);

	pinMode(SW3pin, INPUT_PULLUP);
	pinMode(AutoPin, INPUT_PULLUP);
	pinMode(MasterOnPin, INPUT_PULLUP);

	pinMode(MasterOffPin, INPUT_PULLUP);
	pinMode(RateUpPin, INPUT_PULLUP);
	pinMode(RateDownPin, INPUT_PULLUP);

#if(CommType==1)
	if (ether.begin(sizeof Ethernet::buffer, LocalMac, 10) == 0)
	{
		Serial.println(F("Failed to access Ethernet controller"));
	}
	else
	{
		Serial.println("Ethernet controller found!");
	}
	ether.staticSetup(ArduinoIP, gwip, myDNS, mask);

	ether.printIp("IP Address:     ", ether.myip);
	Serial.println("Destination IP: " + IPadd(DestinationIP));
#endif
}

void loop()
{
	if (millis() - LastTime > 200)
	{
		LastTime = millis();

		// read switches
		// toSend[2]
		Pins[0] = !digitalRead(SW0pin);			// 1
		Pins[1] = !digitalRead(SW1pin);			// 2
		Pins[2] = !digitalRead(SW2pin);			// 4
		Pins[3] = !digitalRead(SW3pin);			// 8

		// toSend[3]
		Pins[4] = !digitalRead(AutoPin);			// 1
		Pins[5] = !digitalRead(MasterOnPin);		// 2
		Pins[6] = !digitalRead(MasterOffPin);	// 4
		Pins[7] = !digitalRead(RateUpPin);		// 8
		Pins[8] = !digitalRead(RateDownPin);		// 16

		// build data
		toSend[2] = 0;
		toSend[3] = 0;

		for (int i = 0; i < 4; i++)
		{
			if(Pins[i]) toSend[2] = toSend[2] | (1 << i);
		}

		for (int i = 0; i < 5; i++)
		{
			if (Pins[i + 4]) toSend[3] = toSend[3] | (1 << i);
		}

		// PGN 32618

#if(CommType==1)
		// send UDP
		ether.sendUdp(toSend, sizeof(toSend), SourcePort, DestinationIP, DestinationPort);
#endif

		// send serial
		for (int i = 0; i < 4; i++)
		{
			Serial.print(toSend[i]);
			if (i < 3) Serial.print(",");
		}
		Serial.println();
		Serial.flush();
	}
#if(CommType==1)
	//this must be called for ethercard functions to work.
	ether.packetLoop(ether.packetReceive());
#endif
}

String IPadd(byte Address[])
{
	return String(Address[0]) + "." + String(Address[1]) + "." + String(Address[2]) + "." + String(Address[3]);
}

