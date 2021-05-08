# define InoDescription "RCarduino  :  03-May-2021"

// user settings ****************************
#define CommType 0          // 0 Serial USB, 1 UDP wired Nano, 2 UDP wifi Nano33

#define ModuleID 0			// unique ID 0-15
#define IPMac 110			// unique number for Arduino IP address and Mac part 6, 0-255
#define IPpart3 1			// ex: 192.168.IPpart3.255, 0-255

#define WifiSSID "tractor"
#define WifiPassword ""

const unsigned long LOOP_TIME = 100; //in msec = 10hz


// 0 use the defined relay as a normal relay
// 1 use the defined relay as a switched power pin - turns on when sketch starts, required for some Raven valves
#define UseSwitchedPowerPin 0	

#define UseMCP23017 0      // 0 use Nano pins for relays, 1 use MCP23017 to control relays

byte FlowOn[] = {HIGH, HIGH};		// on value for flowmeter or motor direction
byte SlowSpeed[] = { 9,9 };		// for vcn, low pwm rate, 0 fast, 9 slow
byte LowMsPulseTrigger[] = {50, 50}; 	// ms/pulse below which is low ms/pulse flow sensor

#define SensorCount 2

#define UseLocalSwitches 1   // 0 no switches, 1 read switches from this pcb

// ******************************************

#if (CommType == 1)
#include <EtherCard.h>
// ethernet interface ip address
static byte ArduinoIP[] = { 192, 168, IPpart3, IPMac };

// ethernet interface Mac address
static byte LocalMac[] = { 0x70, 0x2D, 0x31, 0x21, 0x62, IPMac };

// gateway ip address
static byte gwip[] = { 192, 168, IPpart3, 1 };
//DNS- you just need one anyway
static byte myDNS[] = { 8, 8, 8, 8 };
//mask
static byte mask[] = { 255, 255, 255, 0 };

// local ports on Arduino
unsigned int ListeningPort = 28888;	// to listen on
unsigned int SourcePort = 6100;		// to send from

// ethernet destination - Rate Controller
static byte DestinationIP[] = { 192, 168, IPpart3, 255 };	// broadcast 255
unsigned int DestinationPort = 29999; // Rate Controller listening port

byte Ethernet::buffer[500]; // udp send and receive buffer

//Array to send data back to AgOpenGPS
byte toSend[2][10] = { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
#endif

#if (CommType == 2)
#include <SPI.h>
#include <WiFiNINA.h>
#include <WiFiUdp.h>

int ConnectionStatus = WL_IDLE_STATUS;
char ssid[] = WifiSSID;        // your network SSID (name)
char pass[] = WifiPassword;    // your network password (use for WPA, or use as key for WEP)

char InBuffer[150];	 //buffer to hold incoming packet
byte toSend[2][10] = { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } }; //Array to send data back to AgOpenGPS

WiFiUDP UDPin;
WiFiUDP UDPout;

unsigned int ListeningPort = 28888;	// local port to listen on
unsigned int SourcePort = 6100;		// local port to send from

// ethernet destination - AOG
static byte DestinationIP[] = { 192, 168, IPpart3, 255 };	// broadcast 255
unsigned int DestinationPort = 29999; // RateControl port that listens

unsigned long CheckTime;
unsigned long ConnectedCount = 0;
unsigned long ReconnectCount = 0;
#endif

#if (UseMCP23017 == 1)
#include <Adafruit_MCP23017.h>

Adafruit_MCP23017 mcp;

// MCP23017 pins
#define Relay1 8
#define Relay2 9
#define Relay3 10
#define Relay4 11
#define Relay5 12
#define Relay6 13
#define Relay7 14
#define Relay8 15

#define Relay9 0
#define Relay10 1
#define Relay11 2
#define Relay12 3
#define Relay13 4
#define Relay14 5
#define Relay15 6
#define Relay16 7

// Nano pins
byte FlowPin[] = {3, 2}; // interrupt on this pin
byte FlowDir[] = {4, 6};
byte FlowPWM[] = {5, 9};

#else
// use Nano pins for relays

// If using the ENC28J60 ethernet shield these pins
// are used by it and unavailable for relays:
// 7,8,10,11,12,13. It also pulls pin D2 high.
// D2 can be used if pin D2 on the shield is cut off
// and then mount the shield on top of the Nano.

byte FlowPin[] = { 3, 2 }; // interrupt on this pin
byte FlowDir[] = { 4, 6 };
byte FlowPWM[] = { 5, 9 };

#define Relay1 A0
#define Relay2 A1
#define Relay3 A2
#define Relay4 A3
//#define Relay5 12
//#define Relay6 13
//#define Relay7 14
//#define Relay8 15

#endif

bool FlowEnabled[] = {false, false};
float rateError[] = {0, 0}; //for PID

float UPM[SensorCount];   // UPM rate
int pwmSetting[SensorCount];

// VCN
long VCN[] = {343, 343};
long SendTime[] = {400, 400};	// ms pwm is sent to valve
long WaitTime[] = {500, 500};	// ms to wait before adjusting valve again
byte VCNminPWM[] = {200, 200};
byte VCNmaxPWM[] = {255, 255};

// PID
byte PIDkp[] = {20, 20};
byte PIDminPWM[] = {50, 50};
byte PIDLowMax[] = {100, 100};
byte PIDHighMax[] = { 255, 255};
byte PIDdeadband[] = {3, 3};
byte PIDbrakePoint[] = {20, 20};

byte InCommand[] = {0, 0};		// command byte from RateController
byte ControlType[] = {0, 0};    	// 0 standard, 1 Fast Close, 2 Motor

float TotalPulses[SensorCount];
bool SimulateFlow[] = {true, true};
bool UseVCN[] = {1, 1};		// 0 PID, 1 VCN

byte ManualPWMsetting[] = {0, 0};
float RateSetting[] = {0.0, 0.0};	// auto UPM setting
float MeterCal[] = {1.0, 1.0};	// pulses per Unit

unsigned long CommTime[SensorCount];

//bit 0 is section 0
byte RelayHi = 0;	// sections 8-15
byte RelayLo = 0;	// sections 0-7

//loop time variables in microseconds
unsigned long lastTime = LOOP_TIME;
byte watchdogTimer = 0;

byte Temp = 0;
unsigned int UnSignedTemp = 0;

bool PGN32614Found;
bool PGN32615Found;
bool PGN32616Found;

byte MSB;
byte LSB;
unsigned int PGN;

bool AutoOn = true;

float NewRateFactor[2];
unsigned long ManualLast[2];

// WifiSwitches connection to Wemos D1 Mini
// Use Serial RX, remove RX wire before uploading
bool PGN32619Found;
bool PGN32620Found;
unsigned long WifiSwitchesTimer;
bool WifiSwitchesEnabled = false;
byte WifiSwitches[5];

byte SwitchBytes[4];
byte SwitchID[] = { 0,1,2,3,9,9,9,9,9,9,9,9,9,9,9,9 };

bool EthernetEnabled = false;

#if (UseLocalSwitches)
byte SwitchPGN[] = { 127,106,0,0 };     // PGN 32618
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
#endif

void setup()
{
    Serial.begin(38400);

    delay(5000);
    Serial.println();
    Serial.println(InoDescription);
    Serial.print("Module ID: ");
    Serial.println(ModuleID);
    Serial.println();

#if (UseMCP23017 == 1)
    mcp.begin();

    // MCP20317 pins
    mcp.pinMode(Relay1, OUTPUT);
    mcp.pinMode(Relay2, OUTPUT);
    mcp.pinMode(Relay3, OUTPUT);
    mcp.pinMode(Relay4, OUTPUT);
    mcp.pinMode(Relay5, OUTPUT);
    mcp.pinMode(Relay6, OUTPUT);
    mcp.pinMode(Relay7, OUTPUT);
    mcp.pinMode(Relay8, OUTPUT);

    mcp.pinMode(Relay9, OUTPUT);
    mcp.pinMode(Relay10, OUTPUT);
    mcp.pinMode(Relay11, OUTPUT);
    mcp.pinMode(Relay12, OUTPUT);
    mcp.pinMode(Relay13, OUTPUT);
    mcp.pinMode(Relay14, OUTPUT);
    mcp.pinMode(Relay15, OUTPUT);
    mcp.pinMode(Relay16, OUTPUT);

    // Nano pins
    for (int i = 0; i < SensorCount; i++)
    {
        pinMode(FlowPin[i], INPUT_PULLUP);
        pinMode(FlowDir[i], OUTPUT);
        pinMode(FlowPWM[i], OUTPUT);
    }
#if(UseSwitchedPowerPin == 1)
    // turn on
    mcp.digitalWrite(Relay8, HIGH);
#endif

#else
    // Nano pins
    pinMode(Relay1, OUTPUT);
    pinMode(Relay2, OUTPUT);
    pinMode(Relay3, OUTPUT);
    pinMode(Relay4, OUTPUT);
    //pinMode(Relay5, OUTPUT);
    //pinMode(Relay6, OUTPUT);
    //pinMode(Relay7, OUTPUT);
    //pinMode(Relay8, OUTPUT);

    for (int i = 0; i < SensorCount; i++)
    {
        pinMode(FlowPin[i], INPUT_PULLUP);
        pinMode(FlowDir[i], OUTPUT);
        pinMode(FlowPWM[i], OUTPUT);
    }
#if(UseSwitchedPowerPin == 1)
    // turn on
    digitalWrite(Relay4, HIGH);
#endif

#endif

    attachInterrupt(digitalPinToInterrupt(FlowPin[0]), PPM0isr, RISING);
    attachInterrupt(digitalPinToInterrupt(FlowPin[1]), PPM1isr, RISING);

#if (CommType == 1)
    EthernetEnabled = (ether.begin(sizeof Ethernet::buffer, LocalMac, 10) != 0);
    if (EthernetEnabled)
    {
        Serial.println("Ethernet controller found.");

        ether.staticSetup(ArduinoIP, gwip, myDNS, mask);

        ether.printIp("IP Address:     ", ether.myip);
        Serial.print("Destination IP: ");
        Serial.println(IPadd(DestinationIP));

        //register sub for received data
        ether.udpServerListenOnPort(&ReceiveUDPwired, ListeningPort);
    }
    else
    {
        Serial.println("Ethernet controller not found.");
    }
#endif

#if (CommType == 2)
    // check for the WiFi module:
    if (WiFi.status() == WL_NO_MODULE)
    {
        Serial.println("Communication with WiFi module failed!");
        // don't continue
        while (true);
    }

    String fv = WiFi.firmwareVersion();
    Serial.println("Wifi firmware version: " + fv);

    UDPin.begin(ListeningPort);
    UDPout.begin(SourcePort);
    delay(1000);
#endif

#if(UseLocalSwitches)
    pinMode(SW0pin, INPUT_PULLUP);
    pinMode(SW1pin, INPUT_PULLUP);
    pinMode(SW2pin, INPUT_PULLUP);

    pinMode(SW3pin, INPUT_PULLUP);
    pinMode(AutoPin, INPUT_PULLUP);
    pinMode(MasterOnPin, INPUT_PULLUP);

    pinMode(MasterOffPin, INPUT_PULLUP);
    pinMode(RateUpPin, INPUT_PULLUP);
    pinMode(RateDownPin, INPUT_PULLUP);
#endif

    Serial.println("Finished Setup.");
}

void loop()
{
    ReceiveSerial();

    GetUPM0();
    GetUPM1();

#if (CommType == 2)
    CheckWifi();
    ReceiveUDPWifi();
#endif

    for (int i = 0; i < SensorCount; i++)
    {
        FlowEnabled[i] = (millis() - CommTime[i] < 4000) && (RateSetting[i] > 0);
    }


    // Relays
    if (WifiSwitchesEnabled)
    {
        if (millis() - WifiSwitchesTimer > 60000)   // 60 second timer
        {
            // wifi switches have timed out
            WifiSwitchesEnabled = false;
            SetRelays(0, 0);
        }
    }
    else
    {
        if (FlowEnabled[0] || FlowEnabled[1])
        {
            SetRelays(RelayHi, RelayLo);
        }
        else
        {
            SetRelays(0, 0);
        }
    }

    motorDrive();

    if (millis() - lastTime >= LOOP_TIME)
    {
        lastTime = millis();
        if (AutoOn)
        {
            AutoControl();
        }
        else
        {
            ManualControl();
        }

#if(UseLocalSwitches)
        ReadSwitches();
#endif

        // check connection to AOG
        watchdogTimer++;
        if (watchdogTimer > 30)
        {
            //clean out serial buffer
            while (Serial.available() > 0) char t = Serial.read();

            watchdogTimer = 0;
        }
#if(CommType == 0)
        SendSerial();
    }
#endif

#if(CommType == 1)
        if(EthernetEnabled) SendUDPwired();
    }
    if (EthernetEnabled)
    {
        delay(10);

        //this must be called for ethercard functions to work.
        ether.packetLoop(ether.packetReceive());
    }
#endif

#if(CommType == 2)
    SendUDPWifi();
}
#endif
}

String IPadd(byte Address[])
{
  return String(Address[0]) + "." + String(Address[1]) + "." + String(Address[2]) + "." + String(Address[3]);
}

bool IsBitSet(byte b, int pos)
{
  return ((b >> pos) & 1) != 0;
}

byte ParseModID(byte ID)
{
  // top 4 bits
  return ID >> 4;
}

byte ParseSenID(byte ID)
{
  // bottom 4 bits
  return (ID & 0b00001111);
}

byte BuildModSenID(byte Mod_ID, byte Sen_ID)
{
  return ((Mod_ID << 4) | (Sen_ID & 0b00001111));
}

void AutoControl()
{
    for (int i = 0; i < SensorCount; i++)
    {
        switch (ControlType[i])
        {
        case 2:
            // motor control
            if (SimulateFlow[i]) SimulateMotor(PIDminPWM[i], PIDHighMax[i], i);
            rateError[i] = RateSetting[i] - UPM[i];

            // calculate new value
            pwmSetting[i] = ControlMotor(PIDkp[i], rateError[i], RateSetting[i], PIDminPWM[i],
                PIDHighMax[i], PIDdeadband[i], i);
            break;

        default:
            // valve control
            // calculate new value
            if (UseVCN[i])
            {
                if (SimulateFlow[i]) SimulateValve(VCNminPWM[i], VCNmaxPWM[i], i);
                rateError[i] = RateSetting[i] - UPM[i];

                pwmSetting[i] = VCNpwm(rateError[i], RateSetting[i], VCNminPWM[i], VCNmaxPWM[i],
                    VCN[i], UPM[i], SendTime[i], WaitTime[i], SlowSpeed[i], ControlType[i], i);
            }
            else
            {
                if (SimulateFlow[i]) SimulateValve(PIDminPWM[i], PIDHighMax[i], i);
                rateError[i] = RateSetting[i] - UPM[i];

                pwmSetting[i] = DoPID(PIDkp[i], rateError[i], RateSetting[i], PIDminPWM[i], PIDLowMax[i],
                    PIDHighMax[i], PIDbrakePoint[i], PIDdeadband[i], i);
            }
            break;
        }
    }
}

void ManualControl()
{
    for (int i = 0; i < SensorCount; i++)
    {
        if (millis() - ManualLast[i] > 1500)
        {
            ManualLast[i] = millis();

            // adjust rate
            if (RateSetting[i] == 0) RateSetting[i] = 1; // to make FlowEnabled

            switch (ControlType[i])
            {
            case 2:
                // motor control
                pwmSetting[i] *= NewRateFactor[i];
                if (pwmSetting[i] == 0 && NewRateFactor[i] > 0) pwmSetting[i] = PIDminPWM[i];
                break;

            default:
                // valve control
                if (NewRateFactor[i] < 1)
                {
                    // rate down
                    pwmSetting[i] = (1 - NewRateFactor[i]) * ((PIDHighMax[i] + PIDminPWM[i]) / 2) * -1;
                }
                else
                {
                    // rate up
                    pwmSetting[i] = (NewRateFactor[i] - 1) * ((PIDHighMax[i] + PIDminPWM[i]) / 2);
                }
                break;
            }
        }

        switch (ControlType[i])
        {
            // calculate application rate
        case 2:
            // motor control
            if (SimulateFlow[i]) SimulateMotor(PIDminPWM[i], PIDHighMax[i], i);
            rateError[i] = RateSetting[i] - UPM[i];
            break;

        default:
            // valve control
            if (SimulateFlow[i])
            {
                if (UseVCN[i])
                {
                    SimulateValve(VCNminPWM[i], VCNmaxPWM[i], i);
                }
                else
                {
                    SimulateValve(PIDminPWM[i], PIDHighMax[i], i);
                }
            }
            rateError[i] = RateSetting[i] - UPM[i];
            break;
        }
    }
}

void ToSerial(char* Description, float Val)
{
    Serial.print(Description);
    Serial.println(Val);
}
