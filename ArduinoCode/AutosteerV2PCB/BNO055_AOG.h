//--------------------------------------------------------------
//--  BNO055
//--  IMU 9DOF Sensor Fusion
//--------------------------------------------------------------
//--  Modified for AgOpenGPS by Brian Tischler
//--------------------------------------------------------------
//--  based on the work of
//--    Kris Winer (https://github.com/kriswiner/BNO-055)
//--------------------------------------------------------------
//--  Released on September 2015
//--  under the GPL v2
//--------------------------------------------------------------

#ifndef BNO055_AOG_h
#define BNO055_AOG_h

#include "Arduino.h"
#include <Wire.h>  

// BNO055 Register Map
// Datasheet: https://www.bosch-sensortec.com/en/homepage/products_3/sensor_hubs/iot_solutions/bno055_1/bno055_4
// BNO055 Page 0
#define BNO055_CHIP_ID          0x00    // should be 0xA0              
#define BNO055_ACC_ID           0x01    // should be 0xFB              
#define BNO055_MAG_ID           0x02    // should be 0x32              
#define BNO055_GYRO_ID          0x03    // should be 0x0F              
#define BNO055_SW_REV_ID_LSB    0x04                                                                          
#define BNO055_SW_REV_ID_MSB    0x05
#define BNO055_BL_REV_ID        0x06
#define BNO055_PAGE_ID          0x07
#define BNO055_ACC_DATA_X_LSB   0x08
#define BNO055_ACC_DATA_X_MSB   0x09
#define BNO055_ACC_DATA_Y_LSB   0x0A
#define BNO055_ACC_DATA_Y_MSB   0x0B
#define BNO055_ACC_DATA_Z_LSB   0x0C
#define BNO055_ACC_DATA_Z_MSB   0x0D
#define BNO055_MAG_DATA_X_LSB   0x0E
#define BNO055_MAG_DATA_X_MSB   0x0F
#define BNO055_MAG_DATA_Y_LSB   0x10
#define BNO055_MAG_DATA_Y_MSB   0x11
#define BNO055_MAG_DATA_Z_LSB   0x12
#define BNO055_MAG_DATA_Z_MSB   0x13
#define BNO055_GYR_DATA_X_LSB   0x14
#define BNO055_GYR_DATA_X_MSB   0x15
#define BNO055_GYR_DATA_Y_LSB   0x16
#define BNO055_GYR_DATA_Y_MSB   0x17
#define BNO055_GYR_DATA_Z_LSB   0x18
#define BNO055_GYR_DATA_Z_MSB   0x19
#define BNO055_EUL_HEADING_LSB  0x1A
#define BNO055_EUL_HEADING_MSB  0x1B
#define BNO055_EUL_ROLL_LSB     0x1C
#define BNO055_EUL_ROLL_MSB     0x1D
#define BNO055_EUL_PITCH_LSB    0x1E
#define BNO055_EUL_PITCH_MSB    0x1F
#define BNO055_QUA_DATA_W_LSB   0x20
#define BNO055_QUA_DATA_W_MSB   0x21
#define BNO055_QUA_DATA_X_LSB   0x22
#define BNO055_QUA_DATA_X_MSB   0x23
#define BNO055_QUA_DATA_Y_LSB   0x24
#define BNO055_QUA_DATA_Y_MSB   0x25
#define BNO055_QUA_DATA_Z_LSB   0x26
#define BNO055_QUA_DATA_Z_MSB   0x27
#define BNO055_LIA_DATA_X_LSB   0x28
#define BNO055_LIA_DATA_X_MSB   0x29
#define BNO055_LIA_DATA_Y_LSB   0x2A
#define BNO055_LIA_DATA_Y_MSB   0x2B
#define BNO055_LIA_DATA_Z_LSB   0x2C
#define BNO055_LIA_DATA_Z_MSB   0x2D
#define BNO055_GRV_DATA_X_LSB   0x2E
#define BNO055_GRV_DATA_X_MSB   0x2F
#define BNO055_GRV_DATA_Y_LSB   0x30
#define BNO055_GRV_DATA_Y_MSB   0x31
#define BNO055_GRV_DATA_Z_LSB   0x32
#define BNO055_GRV_DATA_Z_MSB   0x33
#define BNO055_TEMP             0x34
#define BNO055_CALIB_STAT       0x35
#define BNO055_ST_RESULT        0x36
#define BNO055_INT_STATUS       0x37
#define BNO055_SYS_CLK_STATUS   0x38
#define BNO055_SYS_STATUS       0x39
#define BNO055_SYS_ERR          0x3A
#define BNO055_UNIT_SEL         0x3B
#define BNO055_OPR_MODE         0x3D
#define BNO055_PWR_MODE         0x3E
#define BNO055_SYS_TRIGGER      0x3F
#define BNO055_TEMP_SOURCE      0x40
#define BNO055_AXIS_MAP_CONFIG  0x41
#define BNO055_AXIS_MAP_SIGN    0x42

// Offsets
#define BNO055_ACC_OFFSET_X_LSB 0x55
#define BNO055_ACC_OFFSET_X_MSB 0x56
#define BNO055_ACC_OFFSET_Y_LSB 0x57
#define BNO055_ACC_OFFSET_Y_MSB 0x58
#define BNO055_ACC_OFFSET_Z_LSB 0x59
#define BNO055_ACC_OFFSET_Z_MSB 0x5A
#define BNO055_MAG_OFFSET_X_LSB 0x5B
#define BNO055_MAG_OFFSET_X_MSB 0x5C
#define BNO055_MAG_OFFSET_Y_LSB 0x5D
#define BNO055_MAG_OFFSET_Y_MSB 0x5E
#define BNO055_MAG_OFFSET_Z_LSB 0x5F
#define BNO055_MAG_OFFSET_Z_MSB 0x60
#define BNO055_GYR_OFFSET_X_LSB 0x61
#define BNO055_GYR_OFFSET_X_MSB 0x62
#define BNO055_GYR_OFFSET_Y_LSB 0x63
#define BNO055_GYR_OFFSET_Y_MSB 0x64
#define BNO055_GYR_OFFSET_Z_LSB 0x65
#define BNO055_GYR_OFFSET_Z_MSB 0x66
#define BNO055_ACC_RADIUS_LSB   0x67
#define BNO055_ACC_RADIUS_MSB   0x68
#define BNO055_MAG_RADIUS_LSB   0x69
#define BNO055_MAG_RADIUS_MSB   0x6A

// BNO055 Page 1
#define BNO055_PAGE_ID          0x07
#define BNO055_ACC_CONFIG       0x08
#define BNO055_MAG_CONFIG       0x09
#define BNO055_GYRO_CONFIG_0    0x0A
#define BNO055_GYRO_CONFIG_1    0x0B
#define BNO055_ACC_SLEEP_CONFIG 0x0C
#define BNO055_GYR_SLEEP_CONFIG 0x0D
#define BNO055_INT_MSK          0x0F
#define BNO055_INT_EN           0x10
#define BNO055_ACC_AM_THRES     0x11
#define BNO055_ACC_INT_SETTINGS 0x12
#define BNO055_ACC_HG_DURATION  0x13
#define BNO055_ACC_HG_THRESH    0x14
#define BNO055_ACC_NM_THRESH    0x15
#define BNO055_ACC_NM_SET       0x16
#define BNO055_GYR_INT_SETTINGS 0x17
#define BNO055_GYR_HR_X_SET     0x18
#define BNO055_GYR_DUR_X        0x19
#define BNO055_GYR_HR_Y_SET     0x1A
#define BNO055_GYR_DUR_Y        0x1B
#define BNO055_GYR_HR_Z_SET     0x1C
#define BNO055_GYR_DUR_Z        0x1D
#define BNO055_GYR_AM_THRESH    0x1E
#define BNO055_GYR_AM_SET       0x1F

#define NUM_BNO055_OFFSET_REGISTERS (22)

typedef struct
{
  uint16_t accel_offset_x;
  uint16_t accel_offset_y;
  uint16_t accel_offset_z;
  uint16_t gyro_offset_x;
  uint16_t gyro_offset_y;
  uint16_t gyro_offset_z;
  uint16_t mag_offset_x;
  uint16_t mag_offset_y;
  uint16_t mag_offset_z;

  uint16_t accel_radius;
  uint16_t mag_radius;
} bno055_offsets_t;

//bno055_offsets_t offsets;

class BNO055{

  public:
    BNO055(uint8_t);
    void init();
    void readIMU();
    //void readTemp();
    void setSensorOffsets(const bno055_offsets_t &offsets_type);
    void setExtCrystalUse(boolean usextal);

    typedef struct {
      int16_t head, roll, pitch, angVel;
    } Euler;
    Euler euler;

  private:
    uint8_t BNO055_ADDRESS;
    void writeByte(uint8_t, uint8_t, uint8_t);
    uint8_t readByte(uint8_t, uint8_t);
    void readBytes(uint8_t, uint8_t, uint8_t, uint8_t *);

    uint8_t GPwrMode;         // Gyro power mode
    uint8_t Gscale;         // Gyro full scale
    //uint8_t Godr = GODR_250Hz;    // Gyro sample rate
    uint8_t Gbw;              // Gyro bandwidth
    uint8_t Ascale;           // Accel full scale
    //uint8_t Aodr = AODR_250Hz;    // Accel sample rate
    uint8_t APwrMode;         // Accel power mode
    uint8_t Abw;            // Accel bandwidth, accel sample rate divided by ABW_divx
    //uint8_t Mscale = MFS_4Gauss;  // Select magnetometer full-scale resolution
    uint8_t MOpMode;          // Select magnetometer perfomance mode
    uint8_t MPwrMode;         // Select magnetometer power mode
    uint8_t Modr;             // Select magnetometer ODR when in BNO055 bypass mode
    uint8_t PWRMode;          // Select BNO055 power mode
    uint8_t OPRMode;            // specify operation mode for sensors
    uint8_t status;                 // BNO055 data status register

     // Set initial input parameters
    enum Ascale {  // ACC Full Scale
      AFS_2G = 0,
      AFS_4G,
      AFS_8G,
      AFS_18G
    };
    enum Abw { // ACC Bandwidth
      ABW_7_81Hz = 0,
      ABW_15_63Hz,
      ABW_31_25Hz,
      ABW_62_5Hz,
      ABW_125Hz,    
      ABW_250Hz,
      ABW_500Hz,     
      ABW_1000Hz,    //0x07
    };
    enum APwrMode { // ACC Pwr Mode
      NormalA = 0,  
      SuspendA,
      LowPower1A,
      StandbyA,        
      LowPower2A,
      DeepSuspendA
    };
    enum Gscale {  // gyro full scale
      GFS_2000DPS = 0,
      GFS_1000DPS,
      GFS_500DPS,
      GFS_250DPS,
      GFS_125DPS    // 0x04
    };
    enum GPwrMode { // GYR Pwr Mode
      NormalG = 0,
      FastPowerUpG,
      DeepSuspendedG,
      SuspendG,
      AdvancedPowerSaveG
    };
    enum Gbw { // gyro bandwidth
      GBW_523Hz = 0,
      GBW_230Hz,
      GBW_116Hz,
      GBW_47Hz,
      GBW_23Hz,
      GBW_12Hz,
      GBW_64Hz,
      GBW_32Hz
    };
    enum OPRMode {  // BNO-55 operation modes
      CONFIGMODE = 0x00,
      // Sensor Mode
      ACCONLY,
      MAGONLY,
      GYROONLY,
      ACCMAG,
      ACCGYRO,
      MAGGYRO,
      AMG,            // 0x07
      // Fusion Mode
      IMU,
      COMPASS,
      M4G,
      NDOF_FMC_OFF,
      NDOF            // 0x0C
    };
    enum PWRMode {
      Normalpwr = 0,   
      Lowpower,       
      Suspendpwr       
    };
    enum Modr {         // magnetometer output data rate  
      MODR_2Hz = 0,     
      MODR_6Hz,
      MODR_8Hz,
      MODR_10Hz,  
      MODR_15Hz,
      MODR_20Hz,
      MODR_25Hz, 
      MODR_30Hz 
    };
    enum MOpMode { // MAG Op Mode
      LowPower = 0,
      Regular,
      EnhancedRegular,
      HighAccuracy
    };
    enum MPwrMode { // MAG power mode
      Normal = 0,   
      Sleep,     
      Suspend,
      ForceMode  
    };
    enum Posr {
      P_OSR_00 = 0,  // no op
      P_OSR_01,
      P_OSR_02,
      P_OSR_04,
      P_OSR_08,
      P_OSR_16
    };
    enum Tosr {
      T_OSR_00 = 0,  // no op
      T_OSR_01,
      T_OSR_02,
      T_OSR_04,
      T_OSR_08,
      T_OSR_16
    };
    enum IIRFilter {
      full = 0,  // bandwidth at full sample rate
      BW0_223ODR,
      BW0_092ODR,
      BW0_042ODR,
      BW0_021ODR // bandwidth at 0.021 x sample rate
    };
    enum Mode {
      BMP280Sleep = 0,
      forced,
      forced2,
      normal
    };
    enum SBy {
      t_00_5ms = 0,
      t_62_5ms,
      t_125ms,
      t_250ms,
      t_500ms,
      t_1000ms,
      t_2000ms,
      t_4000ms,
    };

};


 
#endif
        

