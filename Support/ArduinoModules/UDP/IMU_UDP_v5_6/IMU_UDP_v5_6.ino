  /*
   * UDP IMU code for ENC28J60 module
   * For AgOpenGPS
   * 4 Feb 2021, Brian Tischler
   * Like all Arduino code - copied from somewhere else :)
   * So don't claim it as your own
   */

    #include <EEPROM.h> 
    #include <Wire.h>
    #include "EtherCard_AOG.h"
    #include <IPAddress.h>
    #include "BNO08x_AOG.h"
  
    //-----------------------------------------------------------------------------------------------
    // Change this number to reset and reload default parameters to EEPROM
    #define EEP_Ident 0x5420  

    //the default network address
    struct ConfigIP {
        uint8_t ipOne = 192;
        uint8_t ipTwo = 168;
        uint8_t ipThree = 1;
    };  ConfigIP networkAddress;   //4 bytes

    //-----------------------------------------------------------------------------------------------
    //decimal 121 = 79 hex
    
    // ethernet interface ip network address and host address 121
    static uint8_t myip[] = { 0,0,0,121 };

    // gateway ip address
    static uint8_t gwip[] = { 0,0,0,1 };

    //DNS- you just need one anyway
    static uint8_t myDNS[] = { 8,8,8,8 };

    //mask
    static uint8_t mask[] = { 255,255,255,0 };

    //this is port of this autosteer module
    uint16_t portMy = 5121; 
  
    //sending back to where and which port
    static uint8_t ipDestination[] = {0,0,0,255};
    uint16_t portDestination = 9999; //AOG port that listens
  
    // ethernet mac address - must be unique on your network
    static uint8_t mymac[] = { 0x00,0x00,0x56,0x00,0x00, 0x79 };
  
    uint8_t Ethernet::buffer[200]; // udp send and receive buffer
    
    // Address of CMPS14 shifted right one bit for arduino wire library
    #define CMPS14_ADDRESS 0x60

    // BNO08x definitions
    #define REPORT_INTERVAL 90 //Report interval in ms (same as the delay at the bottom)

    //ethercard 10,11,12,13  Nano = 10 depending how CS of ENC28J60 is Connected
    #define CS_Pin 10

    // 180/pi
    #define CONST_180_DIVIDED_BY_PI 57.2957795130823

    int16_t EEread = 0;

    //hello from IMU sent back
    uint8_t helloFromIMU[] = { 128, 129, 121, 121, 1, 1, 71 };

    //loop time variables in microseconds  
    const uint16_t LOOP_TIME = 100;  //10Hz    
    uint32_t lastTime = LOOP_TIME;
    uint32_t currentTime = LOOP_TIME;

    //CMPS IMU PGN - 211 - 0xD3
    uint8_t data[] = {128, 129, 121, 211, 8, 0,0,0,0, 0,0,0,0, 15};
    int16_t dataSize = sizeof(data);

    // booleans to see if we are using CMPS or BNO08x
    bool useCMPS = false, useBNO08x = false;

    // BNO08x address variables to check where it is
    const uint8_t bno08xAddresses[] = {0x4A,0x4B};
    const int16_t nrBNO08xAdresses = sizeof(bno08xAddresses)/sizeof(bno08xAddresses[0]);
    uint8_t bno08xAddress;
    BNO080 bno08x;

    float bno08xHeading = 0;
    double bno08xRoll = 0, bno08xPitch = 0;

    int16_t bno08xHeading10x = 0, bno08xRoll10x = 0;
  
    //Program counter reset
    void(*resetFunc) (void) = 0;

    void setup()
    {
        //set up communication
        Wire.begin();
        Serial.begin(38400);

        EEPROM.get(0, EEread);              // read identifier

        if (EEread != EEP_Ident)   // check on first start and write EEPROM
        {
            EEPROM.put(0, EEP_Ident);
            EEPROM.put(4, networkAddress);
        }
        else
        {
            EEPROM.get(4, networkAddress);
        }

        //test if CMPS working
        uint8_t error;
        Wire.beginTransmission(CMPS14_ADDRESS);
        error = Wire.endTransmission();

        if (error == 0)
        {
            Serial.println("Error = 0");
            Serial.print("CMPS14 ADDRESs: 0x");
            Serial.println(CMPS14_ADDRESS, HEX);
            Serial.println("CMPS14 Ok.");
            useCMPS = true;
        }
        else
        {
            Serial.println("Error = 4");
            Serial.println("CMPS not Connected or Found");
        }

        if (!useCMPS)
        {
            for (int16_t i = 0; i < nrBNO08xAdresses; i++)
            {
                bno08xAddress = bno08xAddresses[i];

                Serial.print("\r\nChecking for BNO08X on ");
                Serial.println(bno08xAddress, HEX);
                Wire.beginTransmission(bno08xAddress);
                error = Wire.endTransmission();

                if (error == 0)
                {
                    Serial.println("Error = 0");
                    Serial.print("BNO08X ADDRESs: 0x");
                    Serial.println(bno08xAddress, HEX);
                    Serial.println("BNO08X Ok.");

                    // Initialize BNO080 lib        
                    if (bno08x.begin(bno08xAddress))
                    {
                        Wire.setClock(400000); //Increase I2C data rate to 400kHz

                        // Use gameRotationVector
                        bno08x.enableGameRotationVector(REPORT_INTERVAL); //Send data update every REPORT_INTERVAL in ms for BNO085

                        // Retrieve the getFeatureResponse report to check if Rotation vector report is corectly enable
                        if (bno08x.getFeatureResponseAvailable() == true)
                        {
                            if (bno08x.checkReportEnable(SENSOR_REPORTID_GAME_ROTATION_VECTOR, REPORT_INTERVAL) == false) bno08x.printGetFeatureResponse();

                            // Break out of loop
                            useBNO08x = true;
                            break;
                        }
                        else
                        {
                            Serial.println("BNO08x init fails!!");
                        }
                    }
                    else
                    {
                        Serial.println("BNO080 not detected at given I2C address.");
                    }
                }
                else
                {
                    Serial.println("Error = 4");
                    Serial.println("BNO08X not Connected or Found");
                }
            }
        }

        //50Khz I2C
        TWBR = 144;

        if (ether.begin(sizeof Ethernet::buffer, mymac, CS_Pin) == 0)
            Serial.println(F("Failed to access Ethernet controller"));

        //grab the ip from EEPROM
        myip[0] = networkAddress.ipOne;
        myip[1] = networkAddress.ipTwo;
        myip[2] = networkAddress.ipThree;

        gwip[0] = networkAddress.ipOne;
        gwip[1] = networkAddress.ipTwo;
        gwip[2] = networkAddress.ipThree;

        ipDestination[0] = networkAddress.ipOne;
        ipDestination[1] = networkAddress.ipTwo;
        ipDestination[2] = networkAddress.ipThree;

        //set up connection
        ether.staticSetup(myip, gwip, myDNS, mask);
        ether.printIp("_IP_: ", ether.myip);
        ether.printIp("GWay: ", ether.gwip);
        ether.printIp("AgIO: ", ipDestination);

        //register to port 8888
        ether.udpServerListenOnPort(&udpSteerRecv, 8888);

        Serial.println("Setup complete");
    }// End of Setup

    void loop()
    {
        // Loop triggers every 100 msec and sends back  heading, and roll
        currentTime = millis();

        if (currentTime - lastTime >= LOOP_TIME)
        {
            lastTime = currentTime;

            if (useCMPS)
            {
                Wire.beginTransmission(CMPS14_ADDRESS);
                Wire.write(0x02);
                Wire.endTransmission();

                Wire.requestFrom(CMPS14_ADDRESS, 2);
                while (Wire.available() < 2);

                //the heading x10
                data[6] = Wire.read();
                data[5] = Wire.read();

                Wire.beginTransmission(CMPS14_ADDRESS);
                Wire.write(0x1C);
                Wire.endTransmission();

                Wire.requestFrom(CMPS14_ADDRESS, 2);
                while (Wire.available() < 2);

                //the roll x10
                data[8] = Wire.read();
                data[7] = Wire.read();
            }
            else if (useBNO08x)
            {
                if (bno08x.dataAvailable() == true)
                {
                    bno08xHeading = (bno08x.getYaw()) * CONST_180_DIVIDED_BY_PI; // Convert yaw / heading to degrees
                    bno08xHeading = -bno08xHeading; //BNO085 counter clockwise data to clockwise data

                    if (bno08xHeading < 0 && bno08xHeading >= -180) //Scale BNO085 yaw from [-180°;180°] to [0;360°]
                    {
                        bno08xHeading = bno08xHeading + 360;
                    }

                    bno08xRoll = (bno08x.getRoll()) * CONST_180_DIVIDED_BY_PI; //Convert roll to degrees
                    //bno08xPitch = (bno08x.getPitch()) * CONST_180_DIVIDED_BY_PI; // Convert pitch to degrees

                    bno08xHeading10x = (int16_t)(bno08xHeading * 10);
                    bno08xRoll10x = (int16_t)(bno08xRoll * 10);

                    //the heading x10
                    data[5] = (uint8_t)bno08xHeading10x;
                    data[6] = bno08xHeading10x >> 8;

                    //the roll x10
                    data[7] = (uint8_t)bno08xRoll10x;
                    data[8] = bno08xRoll10x >> 8;
                }
            }

            //checksum
            int16_t CK_A = 0;

            for (int16_t i = 2; i < dataSize - 1; i++)
            {
                CK_A = (CK_A + data[i]);
            }

            data[dataSize - 1] = CK_A;

            ether.sendUdp(data, sizeof(data), portMy, ipDestination, portDestination);
        } //end of timed loop

        delay(1);

        ether.packetLoop(ether.packetReceive());

    } // end of main loop

    void udpSteerRecv(uint16_t dest_port, uint8_t src_ip[IP_LEN], uint16_t src_port, uint8_t* udpData, uint16_t len)
    {
        /* IPAddress src(src_ip[0],src_ip[1],src_ip[2],src_ip[3]);
        Serial.print("dPort:");  Serial.print(dest_port);
        Serial.print("  sPort: ");  Serial.print(src_port);
        Serial.print("  sIP: ");  ether.printIp(src_ip);  Serial.println("  end");

        //for (int16_t i = 0; i < len; i++) {
        //Serial.print(udpData[i],HEX); Serial.print("\t"); } Serial.println(len);
        */

        if (udpData[0] == 0x80 && udpData[1] == 0x81 && udpData[2] == 0x7F) //Data
        {

            if (udpData[3] == 200) // Hello from AgIO
            {
                ether.sendUdp(helloFromIMU, sizeof(helloFromIMU), portMy, ipDestination, portDestination);
            }
            
            //whoami
            else if (udpData[3] == 202)
            {
                //make really sure this is the subnet pgn
                if (udpData[4] == 3 && udpData[5] == 202 && udpData[6] == 202)
                {
                    //hello from AgIO
                    uint8_t scanReply[] = { 128, 129, 121, 203, 4, 
                        networkAddress.ipOne, networkAddress.ipTwo, networkAddress.ipThree, 121, 23   };

                    //checksum
                    int16_t CK_A = 0;
                    for (uint8_t i = 2; i < sizeof(scanReply) - 1; i++)
                    {
                        CK_A = (CK_A + scanReply[i]);
                    }
                    scanReply[sizeof(scanReply)] = CK_A;

                    static uint8_t ipDest[] = { 255,255,255,255 };
                    uint16_t portDest = 9999; //AOG port that listens

                    //off to AOG
                    ether.sendUdp(scanReply, sizeof(scanReply), portMy, ipDest, portDest);
                }
            }


            else if (udpData[3] == 201)
            {
                //make really sure this is the subnet pgn
                if (udpData[4] == 5 && udpData[5] == 201 && udpData[6] == 201)
                {
                    networkAddress.ipOne = udpData[7];
                    networkAddress.ipTwo = udpData[8];
                    networkAddress.ipThree = udpData[9];

                    //save in EEPROM and restart
                    EEPROM.put(4, networkAddress);
                    resetFunc();
                }
            }


            //whoami
            else if (udpData[3] == 202)
            {
                //make really sure this is the subnet pgn
                if (udpData[4] == 3 && udpData[5] == 202 && udpData[6] == 202)
                {
                    //hello from AgIO
                    uint8_t scanReply[] = { 128, 129, 121, 203, 4,
                        networkAddress.ipOne, networkAddress.ipTwo, networkAddress.ipThree, 121, 23 };

                    //checksum
                    int16_t CK_A = 0;
                    for (uint8_t i = 2; i < sizeof(scanReply) - 1; i++)
                    {
                        CK_A = (CK_A + scanReply[i]);
                    }
                    scanReply[sizeof(scanReply)] = CK_A;

                    static uint8_t ipDest[] = { 255,255,255,255 };
                    uint16_t portDest = 9999; //AOG port that listens

                    //off to AOG
                    ether.sendUdp(scanReply, sizeof(scanReply), portMy, ipDest, portDest);
                }
            }
        }
    }
