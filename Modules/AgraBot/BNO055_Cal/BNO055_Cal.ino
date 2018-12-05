
#include "BNO055_AOG.h"
#include <Wire.h>

#define A 0X28  //I2C address selection pin LOW
#define B 0x29  //                          HIGH

BNO055 IMU(A);

int inByte = 0; // incoming serial byte
/*
const unsigned int calibrationDat[11] = 
{ 65511,65425,65535,        //accel
  65534,65535,1,            //gyro
  65300,15,55,              //mag
  100,980};                 //acc radius, mag radius
  */
void displayCalStatus(void)
{
    /* Get the four calibration values (0..3) */
    /* Any sensor data reporting 0 should be ignored, */
    /* 3 means 'fully calibrated" */
    uint8_t system, gyro, accel, mag;
    system = gyro = accel = mag = 0;
    IMU.getCalibration(&system, &gyro, &accel, &mag);

    /* The data should be ignored until the system calibration is > 0 */
    Serial.print("\t");
    if (!system)
    {
        Serial.print("! ");
    }

    /* Display the individual values */
    Serial.print("Sys:");
    Serial.print(system, DEC);
    Serial.print(" G:");
    Serial.print(gyro, DEC);
    Serial.print(" A:");
    Serial.print(accel, DEC);
    Serial.print(" M:");
    Serial.println(mag, DEC);
}

void displaySensorOffsets(const bno055_offsets_t &calibData)
{
    Serial.print("calibrationData.accel_offset_x = "); Serial.print(calibData.accel_offset_x); Serial.println(";");
    Serial.print("calibrationData.accel_offset_y = "); Serial.print(calibData.accel_offset_y); Serial.println(";");
    Serial.print("calibrationData.accel_offset_z = "); Serial.print(calibData.accel_offset_z); Serial.println(";");
				 
    Serial.print("calibrationData.gyro_offset_x = "); Serial.print(calibData.gyro_offset_x);  Serial.println(";");
    Serial.print("calibrationData.gyro_offset_y = "); Serial.print(calibData.gyro_offset_y);  Serial.println(";");
    Serial.print("calibrationData.gyro_offset_z = "); Serial.print(calibData.gyro_offset_z);  Serial.println(";");
				 
    Serial.print("calibrationData.mag_offset_x = "); Serial.print(calibData.mag_offset_x);	  Serial.println(";");
    Serial.print("calibrationData.mag_offset_y = "); Serial.print(calibData.mag_offset_y);	  Serial.println(";");
    Serial.print("calibrationData.mag_offset_z = "); Serial.print(calibData.mag_offset_z);	  Serial.println(";");
				
    Serial.print("calibrationData.accel_radius = "); Serial.print(calibData.accel_radius);   Serial.println(";");
    Serial.print("calibrationData.mag_radius = "); Serial.print(calibData.mag_radius);     Serial.println(";");
    Serial.println("");
    Serial.println("");
    Serial.println("Copy the calibration lines into ArdSectionRelay.INO");
    delay(500);
}

  void setup() {
    Wire.begin();
    Serial.begin(9600);
    IMU.init();
    //use external 32K crystal
    IMU.setExtCrystalUse(true);    

}

void loop() 
{
    Serial.println("Please Calibrate Sensor: ");
    while (!IMU.isFullyCalibrated())
    {   
        /* Optional: Display calibration status */
        displayCalStatus();

        /* Wait the specified delay before requesting new data */
        delay(50);
    }

    Serial.println("\nFully calibrated!");
    Serial.println("--------------------------------");
    Serial.println("Calibration Results: ");
    Serial.println("");
    Serial.println("");
    bno055_offsets_t newCalib;
    IMU.getSensorOffsets(newCalib);
    displaySensorOffsets(newCalib);
    Serial.println("");
    Serial.println("Unplug usb to arduino and power down IMU to run again");
    Serial.println("Otherwise it will still think its calibrated");
    delay(1000);
    exit(0);
}

