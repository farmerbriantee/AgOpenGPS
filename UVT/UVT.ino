
#include "zNMEAParser.h"
#include <Wire.h>

#define CMPS14_ADDRESS 0x60 

//Serial Ports
#define SerialGPS Serial7
#define SerialAOG Serial

/************************* User Settings *************************/
 
//is the GGA the second sentence?
const bool isLastSentenceGGA = true;

const int32_t baudAOG = 115200;
const int32_t baudGPS = 115200;

/*****************************************************************/

 /* A parser is declared with 3 handlers at most */
NMEAParser<2> parser;

//how long after last sentence should imu sample
const uint16_t IMU_DELAY_TIME = 80;  
uint32_t lastTime = IMU_DELAY_TIME;
uint32_t currentTime = IMU_DELAY_TIME;

//how long after last time should imu sample again
const uint16_t GYRO_LOOP_TIME = 10;  
uint32_t lastGyroTime = GYRO_LOOP_TIME;

bool isTriggered = false, blink;

//100hz summing of gyro
float gyro, gyroSum;
float lastHeading;

void setup()
{
    SerialAOG.begin(baudAOG);
    SerialGPS.begin(baudGPS);

    parser.setErrorHandler(errorHandler);
    parser.addHandler("G-GGA", GGA_Handler);
    parser.addHandler("G-VTG", VTG_Handler);

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
        SerialGPS.write(SerialAOG.read());

    currentTime = millis();

    if (isTriggered && currentTime - lastTime >= IMU_DELAY_TIME)
    {
        //read the imu
        imuHandler();

        //reset the timer for imu reading
        isTriggered = false;
        currentTime = millis();
    }     

    if (currentTime - lastGyroTime >= GYRO_LOOP_TIME)
    {
        GyroHandler(currentTime - lastGyroTime);
    }
}
