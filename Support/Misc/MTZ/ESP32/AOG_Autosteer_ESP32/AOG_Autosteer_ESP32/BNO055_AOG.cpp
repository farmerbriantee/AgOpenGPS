//--------------------------------------------------------------
//--    BNO055
//--    IMU 9DOF Sensor Fusion
// -------------------------------------------------------------
//
//   Modified for AgOpenGPS by Brian Tischler
//
//--------------------------------------------------------------
//--    based on the work of
//--        Kris Winer (https://github.com/kriswiner/BNO-055)
//--------------------------------------------------------------
//--    Released on September 2015
//--    under the GPL v2
//--------------------------------------------------------------

#include "Arduino.h"
#include "BNO055_AOG.h"
#include <Wire.h>  


//PUBLIC

BNO055::BNO055(uint8_t address){
    BNO055_ADDRESS = address;

    GPwrMode = NormalG;    // Gyro power mode
    Gscale = GFS_250DPS;  // Gyro full scale
    //Godr = GODR_250Hz;    // Gyro sample rate
    Gbw = GBW_116Hz;       // Gyro bandwidth - changed to 116 hz
    Ascale = AFS_2G;      // Accel full scale - changed to 2G
    //Aodr = AODR_250Hz;    // Accel sample rate
    APwrMode = NormalA;    // Accel power mode
    Abw = ABW_31_25Hz;    // Accel bandwidth, accel sample rate divided by ABW_divx
    //Mscale = MFS_4Gauss;  // Select magnetometer full-scale resolution
    MOpMode = Regular;    // Select magnetometer perfomance mode
    MPwrMode = Normal;    // Select magnetometer power mode
    Modr = MODR_10Hz;     // Select magnetometer ODR when in BNO055 bypass mode
    PWRMode = Normalpwr;    // Select BNO055 power mode
    OPRMode = NDOF;       //
}


void BNO055::init() {
    // Select BNO055 config mode
    writeByte(BNO055_ADDRESS, BNO055_OPR_MODE, CONFIGMODE );
    delay(25);
    
    // Select page 0 to configure mapping
    writeByte(BNO055_ADDRESS, BNO055_PAGE_ID, 0x00);
    writeByte(BNO055_ADDRESS, BNO055_AXIS_MAP_CONFIG, 0x24); //(Default mapping)
    writeByte(BNO055_ADDRESS, BNO055_AXIS_MAP_SIGN,   0x02); //(invert Pitch)
    
    // Select page 1 to configure sensors
    writeByte(BNO055_ADDRESS, BNO055_PAGE_ID, 0x01);
    // Configure ACC
    writeByte(BNO055_ADDRESS, BNO055_ACC_CONFIG, APwrMode << 5 | Abw << 3 | Ascale );
    // Configure GYR
    writeByte(BNO055_ADDRESS, BNO055_GYRO_CONFIG_0, Gbw << 3 | Gscale );
    writeByte(BNO055_ADDRESS, BNO055_GYRO_CONFIG_1, GPwrMode);
    // Configure MAG
    writeByte(BNO055_ADDRESS, BNO055_MAG_CONFIG, MPwrMode << 5 | MOpMode << 3 | Modr );
    // Select page 0 to read sensors
    writeByte(BNO055_ADDRESS, BNO055_PAGE_ID, 0x00);
    // Select BNO055 gyro temperature source 
    writeByte(BNO055_ADDRESS, BNO055_TEMP_SOURCE, 0x01 );
    // Select BNO055 sensor units (temperature in degrees C, rate in dps, accel in mg)
    writeByte(BNO055_ADDRESS, BNO055_UNIT_SEL, 0x01 );
    // Select BNO055 system power mode
    writeByte(BNO055_ADDRESS, BNO055_PWR_MODE, PWRMode );
    // Select BNO055 system operation mode
    writeByte(BNO055_ADDRESS, BNO055_OPR_MODE, OPRMode );
    delay(25);
 }

void BNO055::setExtCrystalUse(boolean usextal)
{
  if (usextal) {
    writeByte(BNO055_ADDRESS, BNO055_SYS_TRIGGER, 0x80);
  }
  else {
    writeByte(BNO055_ADDRESS, BNO055_SYS_TRIGGER, 0x00);
  }
  delay(10);
  
  writeByte(BNO055_ADDRESS, BNO055_OPR_MODE, OPRMode); 
  delay(25);
}

void BNO055::setSensorOffsets(const bno055_offsets_t &offsets_type)
{
  writeByte(BNO055_ADDRESS, BNO055_OPR_MODE, CONFIGMODE);
  delay(25);

  // Select page 0 to read sensors
  writeByte(BNO055_ADDRESS, BNO055_PAGE_ID, 0x00);

  writeByte(BNO055_ADDRESS, BNO055_ACC_OFFSET_X_LSB, (offsets_type.accel_offset_x) & 0x0FF);
  writeByte(BNO055_ADDRESS, BNO055_ACC_OFFSET_X_MSB, (offsets_type.accel_offset_x >> 8) & 0x0FF);
  writeByte(BNO055_ADDRESS, BNO055_ACC_OFFSET_Y_LSB, (offsets_type.accel_offset_y) & 0x0FF);
  writeByte(BNO055_ADDRESS, BNO055_ACC_OFFSET_Y_MSB, (offsets_type.accel_offset_y >> 8) & 0x0FF);
  writeByte(BNO055_ADDRESS, BNO055_ACC_OFFSET_Z_LSB, (offsets_type.accel_offset_z) & 0x0FF);
  writeByte(BNO055_ADDRESS, BNO055_ACC_OFFSET_Z_MSB, (offsets_type.accel_offset_z >> 8) & 0x0FF);

  writeByte(BNO055_ADDRESS, BNO055_GYR_OFFSET_X_LSB, (offsets_type.gyro_offset_x) & 0x0FF);
  writeByte(BNO055_ADDRESS, BNO055_GYR_OFFSET_X_MSB, (offsets_type.gyro_offset_x >> 8) & 0x0FF);
  writeByte(BNO055_ADDRESS, BNO055_GYR_OFFSET_Y_LSB, (offsets_type.gyro_offset_y) & 0x0FF);
  writeByte(BNO055_ADDRESS, BNO055_GYR_OFFSET_Y_MSB, (offsets_type.gyro_offset_y >> 8) & 0x0FF);
  writeByte(BNO055_ADDRESS, BNO055_GYR_OFFSET_Z_LSB, (offsets_type.gyro_offset_z) & 0x0FF);
  writeByte(BNO055_ADDRESS, BNO055_GYR_OFFSET_Z_MSB, (offsets_type.gyro_offset_z >> 8) & 0x0FF);

  writeByte(BNO055_ADDRESS, BNO055_MAG_OFFSET_X_LSB, (offsets_type.mag_offset_x) & 0x0FF);
  writeByte(BNO055_ADDRESS, BNO055_MAG_OFFSET_X_MSB, (offsets_type.mag_offset_x >> 8) & 0x0FF);
  writeByte(BNO055_ADDRESS, BNO055_MAG_OFFSET_Y_LSB, (offsets_type.mag_offset_y) & 0x0FF);
  writeByte(BNO055_ADDRESS, BNO055_MAG_OFFSET_Y_MSB, (offsets_type.mag_offset_y >> 8) & 0x0FF);
  writeByte(BNO055_ADDRESS, BNO055_MAG_OFFSET_Z_LSB, (offsets_type.mag_offset_z) & 0x0FF);
  writeByte(BNO055_ADDRESS, BNO055_MAG_OFFSET_Z_MSB, (offsets_type.mag_offset_z >> 8) & 0x0FF);

  writeByte(BNO055_ADDRESS, BNO055_ACC_RADIUS_LSB, (offsets_type.accel_radius) & 0x0FF);
  writeByte(BNO055_ADDRESS, BNO055_ACC_RADIUS_MSB, (offsets_type.accel_radius >> 8) & 0x0FF);

  writeByte(BNO055_ADDRESS, BNO055_MAG_RADIUS_LSB, (offsets_type.mag_radius) & 0x0FF);
  writeByte(BNO055_ADDRESS, BNO055_MAG_RADIUS_MSB, (offsets_type.mag_radius >> 8) & 0x0FF);

  writeByte(BNO055_ADDRESS, BNO055_OPR_MODE, OPRMode);
  delay(25);

}
void BNO055::readIMU(){
    uint8_t rawData[8];  // x/y/z gyro register data stored here
    readBytes(BNO055_ADDRESS, BNO055_EUL_HEADING_LSB, 6, &rawData[0]);  // Read the six raw data registers sequentially into data array
    euler.head = ((int16_t)rawData[1] << 8) | rawData[0] ;  
    euler.roll = ((int16_t)rawData[3] << 8) | rawData[2] ;  
    euler.pitch = ((int16_t)rawData[5] << 8) | rawData[4] ;

  //read the vehicle turning around gyro
  readBytes(BNO055_ADDRESS, BNO055_GYR_DATA_X_LSB + 4, 6, &rawData[6]);                
  euler.angVel = ((int16_t)rawData[7] << 8) | rawData[6];

}


//PRIVATE


void BNO055::writeByte(uint8_t address, uint8_t subAddress, uint8_t data){
    Wire.beginTransmission(address);  // Initialize the Tx buffer
    Wire.write(subAddress);           // Put slave register address in Tx buffer
    Wire.write(data);                 // Put data in Tx buffer
    Wire.endTransmission();           // Send the Tx buffer
}



uint8_t BNO055::readByte(uint8_t address, uint8_t subAddress){
    uint8_t data; // `data` will store the register data   
    Wire.beginTransmission(address);         // Initialize the Tx buffer
    Wire.write(subAddress);                  // Put slave register address in Tx buffer
    Wire.endTransmission(false);             // Send the Tx buffer, but send a restart to keep connection alive
    Wire.requestFrom(address, (size_t) 1);   // Read one byte from slave register address 
    data = Wire.read();                      // Fill Rx buffer with result
    return data;                             // Return data read from slave register
}



void BNO055::readBytes(uint8_t address, uint8_t subAddress, uint8_t count, uint8_t * dest){  
    Wire.beginTransmission(address);   // Initialize the Tx buffer
    Wire.write(subAddress);            // Put slave register address in Tx buffer
    Wire.endTransmission(false);       // Send the Tx buffer, but send a restart to keep connection alive
    uint8_t i = 0;
    Wire.requestFrom(address, (size_t) count);  // Read bytes from slave register address 
    while (Wire.available()) {
        dest[i++] = Wire.read(); 
    }         
}

