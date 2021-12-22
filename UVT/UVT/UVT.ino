
#include <NMEAParser.h>

#include <Wire.h>

// Address of CMPS14 shifted right one bit for arduino wire library
#define CMPS14_ADDRESS 0x60  

 /* A parser is declared with 3 handlers at most */
NMEAParser<2> parser;

byte counter;
bool isTriggered = false;

/************************* User Settings *************************/
 
//is the GGA the second sentence?
const bool isLastSentenceGGA = true;

//loop time variables in microseconds  
const uint16_t DELAY_TIME = 80;  //how long after last sentence should imu sample   

// Set to GP or GN depending on constellation
const char* GxGGA = "GPGGA";
const char* GxVTG = "GPVTG";

/*****************************************************************/

uint32_t lastTime = DELAY_TIME;
uint32_t currentTime = DELAY_TIME;

void setup()
{
    Serial.begin(9600);
    Serial7.begin(9600);

    parser.setErrorHandler(errorHandler);
    parser.addHandler("GPGGA", GGA_Handler);
    parser.addHandler("GPVTG", VTG_Handler);

    Wire.begin();
}

void loop()
{

    if (Serial.available())
        parser << Serial.read();
    else
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

