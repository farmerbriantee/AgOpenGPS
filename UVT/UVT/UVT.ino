
#include <TeensyThreads.h>
#include <NMEAParser.h>

#include <Wire.h>

// Address of CMPS14 shifted right one bit for arduino wire library
/************************* User Settings *************************/
 
//is the GGA the second sentence?
const bool isLastSentenceGGA = true;
bool blink;

//loop time variables in microseconds  
const uint16_t DELAY_TIME = 80;  //how long after last sentence should imu sample   

// Set to GP or GN depending on constellation
const char* GxGGA = "GPGGA";
const char* GxVTG = "GPVTG";

const int32_t baudAOG = 38400;
const int32_t baudGPS = 38400;

/*****************************************************************/

#define CMPS14_ADDRESS 0x60 

//Serial Ports
#define SerialGPS Serial7
#define SerialAOG Serial

 /* A parser is declared with 3 handlers at most */
NMEAParser<2> parser;

byte counter;
bool isTriggered = false;

uint32_t lastTime = DELAY_TIME;
uint32_t currentTime = DELAY_TIME;

void setup()
{
    SerialAOG.begin(baudAOG);
    SerialGPS.begin(baudGPS);

    parser.setErrorHandler(errorHandler);
    parser.addHandler(GxGGA, GGA_Handler);
    parser.addHandler(GxVTG, VTG_Handler);

    Wire.begin();

    pinMode(13, OUTPUT);
}

void loop()
{
    //Read incoming nmea from GPS
    if (SerialGPS.available())
        parser << SerialGPS.read();

    //Pass NTRIP etc to GPS
    if (SerialAOG.available())
        SerialGPS.print(SerialAOG.read());

    //else
    {
        currentTime = millis();

        if (isTriggered && currentTime - lastTime >= DELAY_TIME)
        {
            //read the imu
            imuHandler();

            //reset the timer for imu reading
            isTriggered = false;
        }
    }
}

