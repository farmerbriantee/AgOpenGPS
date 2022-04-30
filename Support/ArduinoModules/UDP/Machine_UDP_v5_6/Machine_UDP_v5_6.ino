    //Machine Control - Brian Tee - Cut and paste from everywhere


    //-----------------------------------------------------------------------------------------------
    // Change this number to reset and reload default parameters To EEPROM
    #define EEP_Ident 0x5422  
    
    //the default network address
    struct ConfigIP {
        uint8_t ipOne = 192;
        uint8_t ipTwo = 168;
        uint8_t ipThree = 1;
    };  ConfigIP networkAddress;   //3 bytes
    //-----------------------------------------------------------------------------------------------

    #include <EEPROM.h> 
    #include <Wire.h>
    #include "EtherCard_AOG.h"
    #include <IPAddress.h>

    // ethernet interface ip address
    static uint8_t myip[] = { 0,0,0,123 };

    // gateway ip address
    static uint8_t gwip[] = { 0,0,0,1 };

    //DNS- you just need one anyway
    static uint8_t myDNS[] = { 8,8,8,8 };

    //mask
    static uint8_t mask[] = { 255,255,255,0 };

    //this is port of this autosteer module
    uint16_t portMy = 5123;

    //sending back to where and which port
    static uint8_t ipDestination[] = { 0,0,0,255 };
    uint16_t portDestination = 9999; //AOG port that listens

    // ethernet mac address - must be unique on your network
    static uint8_t mymac[] = { 0x00,0x00,0x56,0x00,0x00,0x7B };

    uint8_t Ethernet::buffer[200]; // udp send and receive buffer

    //Variables for config - 0 is false  
    struct Config {
        uint8_t raiseTime = 2;
        uint8_t lowerTime = 4;
        uint8_t enableToolLift = 0;
        uint8_t isRelayActiveHigh = 0; //if zero, active low (default)

        uint8_t user1 = 0; //user defined values set in machine tab
        uint8_t user2 = 0;
        uint8_t user3 = 0;
        uint8_t user4 = 0;

    };  Config aogConfig;   //4 bytes

    //Program counter reset
    void(*resetFunc) (void) = 0;

    //ethercard 10,11,12,13 Nano = 10 depending how CS of ENC28J60 is Connected
    #define CS_Pin 10

    /*
    * Functions as below assigned to pins
    0: -
    1 thru 16: Section 1,Section 2,Section 3,Section 4,Section 5,Section 6,Section 7,Section 8,
                Section 9, Section 10, Section 11, Section 12, Section 13, Section 14, Section 15, Section 16,
    17,18    Hyd Up, Hyd Down,
    19 Tramline,
    20: Geo Stop
    21,22,23 - unused so far*/    
    uint8_t pin[] = { 1,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };

    //read value from Machine data and set 1 or zero according to list
    uint8_t relayState[] = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };

    //hello from AgIO
    uint8_t helloFromMachine[] = { 128, 129, 123, 123, 2, 1, 1, 71 };

    const uint8_t LOOP_TIME = 200; //5hz
    uint32_t lastTime = LOOP_TIME;
    uint32_t currentTime = LOOP_TIME;
    uint32_t fifthTime = 0;
    uint16_t count = 0;

    //Comm checks
    uint8_t watchdogTimer = 20; //make sure we are talking to AOG
    uint8_t serialResetTimer = 0; //if serial buffer is getting full, empty it

    bool isRaise = false, isLower = false;

    //Communication with AgOpenGPS
    int16_t temp, EEread = 0;

    //Parsing PGN
    bool isPGNFound = false, isHeaderFound = false;
    uint8_t pgn = 0, dataLength = 0, idx = 0;
    int16_t tempHeader = 0;

    //settings pgn
    uint8_t PGN_237[] = { 0x80,0x81, 0x7f, 237, 8, 1, 2, 3, 4, 0,0,0,0, 0xCC };
    int8_t PGN_237_Size = sizeof(PGN_237) - 1;

    //The variables used for storage
    uint8_t relayHi = 0, relayLo = 0, tramline = 0, uTurn = 0, hydLift = 0, geoStop = 0;
    float gpsSpeed;
    uint8_t raiseTimer = 0, lowerTimer = 0, lastTrigger = 0;
 

    void setup()
    {

        //set the baud rate
        Serial.begin(38400);
        //while (!Serial) { ; } // wait for serial port to connect. Needed for native USB

        EEPROM.get(0, EEread);              // read identifier

        if (EEread != EEP_Ident)   // check on first start and write EEPROM
        {
            EEPROM.put(0, EEP_Ident);
            EEPROM.put(6, aogConfig);
            EEPROM.put(20, pin);
            EEPROM.put(50, networkAddress);
        }
        else
        {
            EEPROM.get(6, aogConfig);
            EEPROM.get(20, pin);
            EEPROM.get(50, networkAddress);
        }

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

        //set the pins to be outputs (pin numbers)
        pinMode(4, OUTPUT);
        pinMode(5, OUTPUT);
        pinMode(6, OUTPUT);
        pinMode(7, OUTPUT);
        pinMode(8, OUTPUT);
        pinMode(9, OUTPUT);

        Serial.println("Setup complete, waiting for AgOpenGPS");

    }

    void loop()
    {
        //Loop triggers every 200 msec and sends back gyro heading, and roll, steer angle etc

        currentTime = millis();

        if (currentTime - lastTime >= LOOP_TIME)
        {
            lastTime = currentTime;

            //If connection lost to AgOpenGPS, the watchdog will count up 
            if (watchdogTimer++ > 250) watchdogTimer = 20;

            //clean out serial buffer to prevent buffer overflow
            if (serialResetTimer++ > 20)
            {
                while (Serial.available() > 0) Serial.read();
                serialResetTimer = 0;
            }

            if (watchdogTimer > 20)
            {
                if (aogConfig.isRelayActiveHigh) {
                    relayLo = 255;
                    relayHi = 255;
                }
                else {
                    relayLo = 0;
                    relayHi = 0;
                }
            }

            //hydraulic lift

            if (hydLift != lastTrigger && (hydLift == 1 || hydLift == 2))
            {
                lastTrigger = hydLift;
                lowerTimer = 0;
                raiseTimer = 0;

                //200 msec per frame so 5 per second
                switch (hydLift)
                {
                    //lower
                case 1:
                    lowerTimer = aogConfig.lowerTime * 5;
                    break;

                    //raise
                case 2:
                    raiseTimer = aogConfig.raiseTime * 5;
                    break;
                }
            }

            //countdown if not zero, make sure up only
            if (raiseTimer)
            {
                raiseTimer--;
                lowerTimer = 0;
            }
            if (lowerTimer) lowerTimer--;

            //if anything wrong, shut off hydraulics, reset last
            if ((hydLift != 1 && hydLift != 2) || watchdogTimer > 10) //|| gpsSpeed < 2)
            {
                lowerTimer = 0;
                raiseTimer = 0;
                lastTrigger = 0;
            }

            if (aogConfig.isRelayActiveHigh)
            {
                isLower = isRaise = false;
                if (lowerTimer) isLower = true;
                if (raiseTimer) isRaise = true;
            }
            else
            {
                isLower = isRaise = true;
                if (lowerTimer) isLower = false;
                if (raiseTimer) isRaise = false;
            }

            //section relays
            SetRelays();

            //checksum
            int16_t CK_A = 0;
            for (uint8_t i = 2; i < PGN_237_Size; i++)
            {
                CK_A = (CK_A + PGN_237[i]);
            }
            PGN_237[PGN_237_Size] = CK_A;

            //off to AOG
            ether.sendUdp(PGN_237, sizeof(PGN_237), portMy, ipDestination, portDestination);

        } //end of timed loop

        delay(1);

        //this must be called for ethercard functions to work. Calls udpSteerRecv() defined way below.
        ether.packetLoop(ether.packetReceive());
    }

  //callback when received packets
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

            if (udpData[3] == 239)  //machine data
            {
                uTurn = udpData[5];
                gpsSpeed = (float)udpData[6];//actual speed times 4, single uint8_t

                hydLift = udpData[7];
                tramline = udpData[8];  //bit 0 is right bit 1 is left

                relayLo = udpData[11];          // read relay control from AgOpenGPS
                relayHi = udpData[12];

                if (aogConfig.isRelayActiveHigh)
                {
                    tramline = 255 - tramline;
                    relayLo = 255 - relayLo;
                    relayHi = 255 - relayHi;
                }

                //Bit 13 CRC

                //reset watchdog
                watchdogTimer = 0;
            }

            else if (udpData[3] == 200) // Hello from AgIO
            {
                if (udpData[7] == 1)
                {
                    relayLo -= 255;
                    relayHi -= 255;
                    watchdogTimer = 0;
                }

                helloFromMachine[5] = relayLo;
                helloFromMachine[6] = relayHi;

                ether.sendUdp(helloFromMachine, sizeof(helloFromMachine), portMy, ipDestination, portDestination);
            }


            else if (udpData[3] == 238)
            {
                aogConfig.raiseTime = udpData[5];
                aogConfig.lowerTime = udpData[6];
                aogConfig.enableToolLift = udpData[7];

                //set1 
                uint8_t sett = udpData[8];  //setting0     
                if (bitRead(sett, 0)) aogConfig.isRelayActiveHigh = 1; else aogConfig.isRelayActiveHigh = 0;

                aogConfig.user1 = udpData[9];
                aogConfig.user2 = udpData[10];
                aogConfig.user3 = udpData[11];
                aogConfig.user4 = udpData[12];

                //crc

                //save in EEPROM and restart
                EEPROM.put(6, aogConfig);
                //resetFunc();
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
                    EEPROM.put(50, networkAddress);
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
                    uint8_t scanReply[] = { 128, 129, 123, 203, 4, 
                        networkAddress.ipOne, networkAddress.ipTwo, networkAddress.ipThree, 123, 23   };

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

            else if (udpData[3] == 236) //EC Relay Pin Settings 
            {
                for (uint8_t i = 0; i < 24; i++)
                {
                    pin[i] = udpData[i + 5];
                }

                //save in EEPROM and restart
                EEPROM.put(20, pin);
            }
        }
    }

    void SetRelays(void)
    {
        //pin, rate, duration  130 pp meter, 3.6 kmh = 1 m/sec or gpsSpeed * 130/3.6 or gpsSpeed * 36.1111
        //gpsSpeed is 10x actual speed so 3.61111
        gpsSpeed *= 3.61111;
        //tone(13, gpsSpeed);

        //Load the current pgn relay state - Sections
        for (uint8_t i = 0; i < 8; i++)
        {
            relayState[i] = bitRead(relayLo, i);
        }

        for (uint8_t i = 0; i < 8; i++)
        {
            relayState[i + 8] = bitRead(relayHi, i);
        }

        // Hydraulics
        relayState[16] = isLower;
        relayState[17] = isRaise;

        //Tram
        relayState[18] = bitRead(tramline, 0); //right
        relayState[19] = bitRead(tramline, 1); //left

        //GeoStop
        relayState[20] = (geoStop == 0) ? 0 : 1;

        if (pin[0]) digitalWrite(4, relayState[pin[0] - 1]);
        if (pin[1]) digitalWrite(5, relayState[pin[1] - 1]);
        if (pin[2]) digitalWrite(6, relayState[pin[2] - 1]);
        if (pin[3]) digitalWrite(7, relayState[pin[3] - 1]);

        if (pin[4]) digitalWrite(8, relayState[pin[4] - 1]);
        if (pin[5]) digitalWrite(9, relayState[pin[5] - 1]);

        //if (pin[6]) digitalWrite(10, relayState[pin[6]-1]);
        //if (pin[7]) digitalWrite(11, relayState[pin[7]-1]);

        //if (pin[8]) digitalWrite(12, relayState[pin[8]-1]);
        //if (pin[9]) digitalWrite(4, relayState[pin[9]-1]);

        //if (pin[10]) digitalWrite(IO#Here, relayState[pin[10]-1]);
        //if (pin[11]) digitalWrite(IO#Here, relayState[pin[11]-1]);
        //if (pin[12]) digitalWrite(IO#Here, relayState[pin[12]-1]);
        //if (pin[13]) digitalWrite(IO#Here, relayState[pin[13]-1]);
        //if (pin[14]) digitalWrite(IO#Here, relayState[pin[14]-1]);
        //if (pin[15]) digitalWrite(IO#Here, relayState[pin[15]-1]);
        //if (pin[16]) digitalWrite(IO#Here, relayState[pin[16]-1]);
        //if (pin[17]) digitalWrite(IO#Here, relayState[pin[17]-1]);
        //if (pin[18]) digitalWrite(IO#Here, relayState[pin[18]-1]);
        //if (pin[19]) digitalWrite(IO#Here, relayState[pin[19]-1]);
    }
