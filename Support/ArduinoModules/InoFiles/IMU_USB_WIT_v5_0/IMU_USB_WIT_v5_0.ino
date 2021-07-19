   /*      
  * USB IMU code for For AgOpenGPS
  * 4 Feb 2021, Brian Tischler
  * Like all Arduino code - copied from somewhere else :)
  * So don't claim it as your own
  */

  #include "JY901.h"
  #define REPORT_INTERVAL 95 //Report interval in ms (same as the delay at the bottom)
  
  #define CONST_180_DIVIDED_BY_PI 57.2957795130823

  //CMPS PGN - 211
  uint8_t data[] = {0x80,0x81,0x7D,0xD3,8, 0,0,0,0, 0,0,0,0, 15};
  int16_t dataSize = sizeof(data);

  float hwt901Heading = 0;
  double hwt901Roll = 0;

  int16_t hwt901Heading10x = 0;
  int16_t hwt901Roll10x = 0;
    
  void setup()
  {
    Serial.begin(38400);  // Start serial port set baudrate in accodance with your witmotion setup
    
  }
  
  void loop()
  {
        while (Serial.available()) 
          {
            JY901.CopeSerialData(Serial.read()); //Call JY901 data cope function
          }
        hwt901Heading = (JY901.stcAngle.Angle[2]);
        hwt901Roll = (JY901.stcAngle.Angle[0]);
        hwt901Heading = (hwt901Heading) / 32768;
        hwt901Heading = (hwt901Heading) * 180;
        hwt901Heading = -hwt901Heading;
        
        if (hwt901Heading < 0 && hwt901Heading >= -180) //Scale BNO085 yaw from [-180°;180°] to [0;360°]
        {
          hwt901Heading = hwt901Heading + 360;
        }
            
        hwt901Heading10x = (int16_t)(hwt901Heading) * 10;
        hwt901Roll10x = (int16_t)(hwt901Roll) / 18;

        //the heading x10
        data[5] = (uint8_t)hwt901Heading10x;
        data[6] = hwt901Heading10x >> 8;

        //the roll x10
        data[7] = (uint8_t)hwt901Roll10x;
        data[8] = hwt901Roll10x >> 8;

    int16_t CK_A = 0;
    
    for (int16_t i = 2; i < dataSize - 1; i++)
    {
        CK_A = (CK_A + data[i]);
    }
    
    data[dataSize - 1] = CK_A;

    Serial.write(data, dataSize);
    Serial.flush();

    //10 hz
    delay(REPORT_INTERVAL);                           
  }
