// Single antenna, IMU, & dual antenna code for AgOpenGPS
// If dual right antenna is for position (must enter this location in AgOpen), left Antenna is for heading & roll
//
// connection plan:
// Teensy Serial 7 RX (28) to F9P Position receiver TX1 (Position data)
// Teensy Serial 7 TX (29) to F9P Position receiver RX1 (RTCM data for RTK)
// Teensy Serial 2 RX (7) to F9P Heading receiver TX1 (Relative position from left antenna to right antenna)
// Teensy Serial 2 TX (8) to F9P Heading receiver RX1
// F9P Position receiver TX2 to F9P Heading receiver RX2 (RTCM data for Moving Base)
//
// Configuration of receiver
// Position F9P
// CFG-RATE-MEAS - 100 ms -> 10 Hz
// CFG-UART1-BAUDRATE 115200
// Serial 1 In - RTCM (Correction Data from AGO)
// Serial 1 Out - NMEA GGA
// CFG-UART2-BAUDRATE 460800
// Serial 2 Out - RTCM 1074,1084,1094,1230,4072.0 (Correction data for Heading F9P, Moving Base)  
// 1124 is not needed (China’s BeiDou system) - Save F9P brain power 
//
// Heading F9P
// CFG-RATE-MEAS - 100 ms -> 10 Hz
// CFG-UART1-BAUDRATE 115200
// Serial 1 Out - UBX-NAV-RELPOSNED
// CFG-UART2-BAUDRATE 460800
// Serial 2 In RTCM

/************************* User Settings *************************/
// Serial Ports
#define SerialAOG Serial
#define SerialRTK Serial3
#define RAD_TO_DEG_X_10 572.95779513082320876798154814105


HardwareSerial* SerialGPS = &Serial7;   //Main postion receiver (GGA) (Serial2 must be used here with T4.0 / Basic Panda boards - Should auto swap)
HardwareSerial* SerialGPS2 = &Serial2;  //Dual heading receiver 
HardwareSerial* SerialGPSTmp = NULL;
//HardwareSerial* SerialAOG = &Serial;

const int32_t baudAOG = 115200;
const int32_t baudGPS = 115200;
const int32_t baudRTK = 9600;

#define ImuWire Wire        //SCL=19:A5 SDA=18:A4

// Swap BNO08x roll & pitch?
//const bool swapRollPitch = false;
const bool swapRollPitch = true;

// send GPS data via  0 = USB, 1 = Ethernet 
int send_Data_Via = 0;
int GGAReceivedLED = 13;

/*****************************************************************/

// Ethernet Options (Teensy 4.1 Only)
#ifdef ARDUINO_TEENSY41
#include <NativeEthernet.h>
#include <NativeEthernetUdp.h>

// IP & MAC address of this module of this module
byte Eth_myip[4] = { 192, 168, 1, 120 };
byte mac[] = {0x00, 0x00, 0x56, 0x00, 0x00, 0x78}; // original

byte Eth_ipDest_ending = 255;           // ending of IP address to send UDP data to
unsigned int portMy = 5120;             // port of this module
unsigned int AOGNtripPort = 2233;       // port NTRIP data from AOG comes in
unsigned int AOGAutoSteerPort = 8888;   // port Autosteer data from AOG comes in
unsigned int portDestination = 9999;    // Port of AOG that listens
char Eth_NTRIP_packetBuffer[512];       // buffer for receiving ntrip data

// An EthernetUDP instance to let us send and receive packets over UDP
EthernetUDP Eth_udpPAOGI;     //Out port 5544
EthernetUDP Eth_udpNtrip;     //In port 2233
EthernetUDP Eth_udpAutoSteer; //In & Out Port 8888

IPAddress Eth_ipDestination;
#endif // ARDUINO_TEENSY41

byte CK_A = 0;
byte CK_B = 0;
int relposnedByteCount = 0;

//Speed pulse output
unsigned long prev_PWM_Millis = 0;
byte velocityPWM_Pin = 36;      // Velocity (MPH speed) PWM pin

#include "zNMEAParser.h"
#include <Wire.h>
#include "BNO08x_AOG.h"

bool useDual = false;
bool dualReadyGGA = false;
bool dualReadyRelPos = false;

// booleans to see if we are using CMPS or BNO08x
bool useCMPS = false;
bool useBNO08x = false;

//CMPS always x60
#define CMPS14_ADDRESS 0x60

// BNO08x address variables to check where it is
const uint8_t bno08xAddresses[] = { 0x4A, 0x4B };
const int16_t nrBNO08xAdresses = sizeof(bno08xAddresses) / sizeof(bno08xAddresses[0]);
uint8_t bno08xAddress;
BNO080 bno08x;

//Dual
double headingcorr = 900;  //90deg heading correction (90deg*10)
// Heading correction 180 degrees, because normally the heading antenna is in front, but we have it at the back
//double headingcorr = 1800;  // 180deg heading correction (180deg*10)

float baseline;
float rollDual;
float rollDualRaw;
double relPosD;
double heading = 0;

byte ackPacket[72] = {0xB5, 0x62, 0x01, 0x3C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};

constexpr int serial_buffer_size = 512;
uint8_t GPSrxbuffer[serial_buffer_size];    //Extra serial rx buffer
uint8_t GPStxbuffer[serial_buffer_size];    //Extra serial tx buffer
uint8_t GPS2rxbuffer[serial_buffer_size];   //Extra serial rx buffer
uint8_t GPS2txbuffer[serial_buffer_size];   //Extra serial tx buffer
uint8_t RTKrxbuffer[serial_buffer_size]; //Extra serial rx buffer

/* A parser is declared with 3 handlers at most */
NMEAParser<2> parser;

bool isTriggered = false;
bool blink = false;

bool Autosteer_running = true; //Auto set off in autosteer setup
bool Ethernet_running = false; //Auto set on in ethernet setup
bool GGA_Available = false;     //Do we have GGA on correct port?
uint32_t PortSwapTime = 0;

float lastHeading;

float roll = 0;
float pitch = 0;
float yaw = 0;

// Buffer to read chars from Serial, to check if "!AOG" is found
uint8_t aogSerialCmd[4] = { '!', 'A', 'O', 'G'};
uint8_t aogSerialCmdBuffer[6];
uint8_t aogSerialCmdCounter = 0;

// Booleans to indictate to passthrough GPS or GPS2
bool passThroughGPS = false;
bool passThroughGPS2 = false;

// Setup procedure ------------------------
void setup()
{
  pinMode(GGAReceivedLED, OUTPUT);

  // the dash means wildcard
  parser.setErrorHandler(errorHandler);
  parser.addHandler("G-GGA", GGA_Handler);
  // Disabled VTG for now because speed is calculated by AOG
  //parser.addHandler("G-VTG", VTG_Handler);

  delay(10);
  Serial.begin(baudAOG);
  delay(10);
  Serial.println("Start setup");

  SerialGPS->begin(baudGPS);
  SerialGPS->addMemoryForRead(GPSrxbuffer, serial_buffer_size);
  SerialGPS->addMemoryForWrite(GPStxbuffer, serial_buffer_size);

  delay(10);
  SerialRTK.begin(baudRTK);
  SerialRTK.addMemoryForRead(RTKrxbuffer, serial_buffer_size);

  delay(10);
  SerialGPS2->begin(baudGPS);
  SerialGPS2->addMemoryForRead(GPS2rxbuffer, serial_buffer_size);
  SerialGPS2->addMemoryForWrite(GPS2txbuffer, serial_buffer_size);

  Serial.println("SerialAOG, SerialRTK, SerialGPS and SerialGPS2 initialized");
  
  Serial.println("\r\nStarting Ethernet...");
  EthernetStart();
  
  Serial.println("\r\nStarting AutoSteer...");
  autosteerSetup();

  Serial.println("\r\nStarting IMU...");
  //test if CMPS working
  uint8_t error;

  ImuWire.begin();
  
  //Serial.println("Checking for CMPS14");
  ImuWire.beginTransmission(CMPS14_ADDRESS);
  error = ImuWire.endTransmission();

  if (error == 0)
  {
    //Serial.println("Error = 0");
    Serial.print("CMPS14 ADDRESs: 0x");
    Serial.println(CMPS14_ADDRESS, HEX);
    Serial.println("CMPS14 Ok.");
    useCMPS = true;
  }
  else
  {
    //Serial.println("Error = 4");
    Serial.println("CMPS not Connected or Found");
  }

  if (!useCMPS)
  {
      for (int16_t i = 0; i < nrBNO08xAdresses; i++)
      {
          bno08xAddress = bno08xAddresses[i];

          //Serial.print("\r\nChecking for BNO08X on ");
          //Serial.println(bno08xAddress, HEX);
          ImuWire.beginTransmission(bno08xAddress);
          error = ImuWire.endTransmission();

          if (error == 0)
          {
              //Serial.println("Error = 0");
              Serial.print("0x");
              Serial.print(bno08xAddress, HEX);
              Serial.println(" BNO08X Ok.");

              // Initialize BNO080 lib
              if (bno08x.begin(bno08xAddress, ImuWire)) //??? Passing NULL to non pointer argument, remove maybe ???
              {
                  //Increase I2C data rate to 400kHz
                  ImuWire.setClock(400000); 

                  delay(300);

                  // Use gameRotationVector and set REPORT_INTERVAL
                  bno08x.enableGameRotationVector(20);
                  useBNO08x = true;
              }
              else
              {
                  Serial.println("BNO080 not detected at given I2C address.");
              }
          }
          else
          {
              //Serial.println("Error = 4");
              Serial.print("0x");
              Serial.print(bno08xAddress, HEX);
              Serial.println(" BNO08X not Connected or Found");
          }
          if (useBNO08x) break;
      }
  }

  delay(100);
  Serial.print("\r\nuseCMPS = ");
  Serial.println(useCMPS);
  Serial.print("useBNO08x = ");
  Serial.println(useBNO08x);

  Serial.println("\r\nEnd setup, waiting for GPS...\r\n");
}

void loop()
{
    if (GGA_Available == false && !passThroughGPS && !passThroughGPS2)
    {
        if (systick_millis_count - PortSwapTime >= 10000)
        {
            Serial.println("Swapping GPS ports...\r\n");
            SerialGPSTmp = SerialGPS;
            SerialGPS = SerialGPS2;
            SerialGPS2 = SerialGPSTmp;
            PortSwapTime = systick_millis_count;
        }
    }

    // Pass NTRIP etc to GPS
    if (SerialAOG.available())
    {
        uint8_t incoming_char = SerialAOG.read();

        // Check incoming char against the aogSerialCmd array
        // The configuration utility will send !AOGR1, !AOGR2 or !AOGED (close/end)
        if (aogSerialCmdCounter < 4 && aogSerialCmd[aogSerialCmdCounter] == incoming_char)
        {
            aogSerialCmdBuffer[aogSerialCmdCounter] = incoming_char;
            aogSerialCmdCounter++;
        }
        // Whole command prefix is in, handle it
        else if (aogSerialCmdCounter == 4)
        {
            aogSerialCmdBuffer[aogSerialCmdCounter] = incoming_char;
            aogSerialCmdBuffer[aogSerialCmdCounter + 1] = SerialAOG.read();

            if (aogSerialCmdBuffer[aogSerialCmdCounter] == 'R')
            {
                if (aogSerialCmdBuffer[aogSerialCmdCounter + 1] == '1')
                {
                    passThroughGPS = true;
                    passThroughGPS2 = false;
                }
                else if (aogSerialCmdBuffer[aogSerialCmdCounter + 1] == '2')
                {
                    passThroughGPS = false;
                    passThroughGPS2 = true;
                }

                // Rest SerialGPS and SerialGPS2
                SerialGPS = &Serial7;
                SerialGPS2 = &Serial2;

                // Check baudrate
                bool communicationSuccessfull = false;

                do
                {
                    uint8_t res[100];

                    // Poll navigation data byte -> UBX-NAV-PVT
                    byte mon_ver[] = {0xB5, 0x62, 0x0A, 0x04, 0x00, 0x00, 0x0E, 0x34};

                    // first send dumb data to make sure its on
                    SerialGPS->write(0xFF);

                    // Clear
                    while(SerialGPS->available() > 0)
                    {
                        SerialGPS->read();
                    }

                    uint32_t millis_read = systick_millis_count;
                    constexpr uint32_t UART_TIMEOUT = 1000;
                    int i = 0;

                    do
                    {
                        delay(0);
                        
                        while (SerialGPS->available() > 0) 
                        {
                            res[i++] = SerialGPS->read();
                            if (i < 100) continue;
                        }
                    } while (systick_millis_count - millis_read < UART_TIMEOUT);
                } while (!communicationSuccessfull);
            }
            // END command. maybe think of a different abbreviation
            else if (aogSerialCmdBuffer[aogSerialCmdCounter] == 'E' && aogSerialCmdBuffer[aogSerialCmdCounter + 1] == 'D')
            {
                passThroughGPS = false;
                passThroughGPS2 = false;
            }
        }
        else
        {
            aogSerialCmdCounter = 0;
        }

        if (passThroughGPS)
        {
            SerialGPS->write(incoming_char);
        }
        else if (passThroughGPS2)
        {
            SerialGPS2->write(incoming_char);
        }
        else
        {
            SerialGPS->write(incoming_char);
        }
    }

    // Read incoming nmea from GPS
    if (SerialGPS->available())
    {
        if (passThroughGPS)
        {
            SerialAOG.write(SerialGPS->read());
        }
        else
        {
            parser << SerialGPS->read();
        }
    }

    udpNtrip();

    // Check for RTK Radio
    if (SerialRTK.available())
    {
        SerialGPS->write(SerialRTK.read());
    }

    // If both dual messages are ready, send to AgOpen
    if (dualReadyGGA == true && dualReadyRelPos == true)
    {
        BuildNmea();
        dualReadyGGA = false;
        dualReadyRelPos = false;
    }

    // If anything comes in SerialGPS2 RelPos data
    if (SerialGPS2->available())
    {
        uint8_t incoming_char = SerialGPS2->read();  //Read RELPOSNED from F9P

        if (passThroughGPS2)
        {
            SerialAOG.write(incoming_char);
        }
        else
        {
            // Just increase the byte counter for the first 3 bytes
            if (relposnedByteCount < 4 && incoming_char == ackPacket[relposnedByteCount])
            {
                relposnedByteCount++;
            }
            else if (relposnedByteCount > 3)
            {
                // Real data, put the received bytes in the buffer
                ackPacket[relposnedByteCount] = incoming_char;
                relposnedByteCount++;
            }
            else
            {
                // Reset the counter, becaues the start sequence was broken
                relposnedByteCount = 0;
            }
        }
    }

    // Check the message when the buffer is full
    if (relposnedByteCount > 71)
    {
        if (calcChecksum())
        {
            //if(deBug) Serial.println("RelPos Message Recived");
            useDual = true;
            relPosDecode();
        }
        /*  else {
          if(deBug) Serial.println("ACK Checksum Failure: ");
          }
        */
        relposnedByteCount = 0;
    }

    if (Autosteer_running) autosteerLoop();
    else ReceiveUdp();

}//End Loop

//**************************************************************************

bool calcChecksum()
{
  CK_A = 0;
  CK_B = 0;

  for (int i = 2; i < 70; i++)
  {
    CK_A = CK_A + ackPacket[i];
    CK_B = CK_B + CK_A;
  }

  return (CK_A == ackPacket[70] && CK_B == ackPacket[71]);
}
