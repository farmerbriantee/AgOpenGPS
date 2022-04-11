
    /*
    * This program only turns the relays for section control
    * On and Off. Connect to the Relay Port in AgOpenGPS
    * 
    */
    
    //loop time variables in microseconds

    #include <Wire.h>
    #include <EEPROM.h> 

    #define EEP_Ident 0x5400  

    #define MCP1 0x20
    #define MCP2 0x21

    //Program counter reset
    void(* resetFunc) (void) = 0;

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

    /*
    * Functions as below assigned to pins
    0: -
    1 thru 16: Section 1,Section 2,Section 3,Section 4,Section 5,Section 6,Section 7,Section 8, 
                Section 9, Section 10, Section 11, Section 12, Section 13, Section 14, Section 15, Section 16, 
    17,18    Hyd Up, Hyd Down, 
    19 Tramline, 
    20: Geo Stop
    21,22,23 - unused so far
    */

    //24 possible pins assigned to these functions
    uint8_t pin[] = { 1,2,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };

    //read value from Machine data and set 1 or zero according to list
    uint8_t relayState[] = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };

    const uint8_t LOOP_TIME = 200; //5hz
    uint32_t lastTime = LOOP_TIME;
    uint32_t currentTime = LOOP_TIME;
    uint32_t fifthTime = 0;
    uint16_t count = 0;

    //Comm checks
    uint8_t watchdogTimer = 0; //make sure we are talking to AOG
    uint8_t serialResetTimer = 0; //if serial buffer is getting full, empty it

    bool isRaise = false;
    bool isLower = false;
  
    //Communication with AgOpenGPS
    int16_t temp, EEread = 0;

    //Parsing PGN
    bool isPGNFound = false, isHeaderFound = false;
    uint8_t pgn = 0, dataLength = 0, idx = 0;
    int16_t tempHeader = 0;
  
    uint8_t AOG[] = {0x80,0x81, 0x7f, 0xED, 8, 0, 0, 0, 0, 0,0,0,0, 0xCC };

    //The variables used for storage
    uint8_t relayHi=0, relayLo = 0, tramline = 0, uTurn = 0, hydLift = 0, geoStop = 0;
    float gpsSpeed;
  
    uint8_t raiseTimer = 0, lowerTimer = 0, lastTrigger = 0;  

    uint8_t mcpInput = 0;
 
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
        }
        else
        {
            EEPROM.get(6, aogConfig);
            EEPROM.get(20, pin);
        }

        //I2C  MCP23017
        
        Wire.beginTransmission(MCP1);
        Wire.write(0x00); // IODIRA register
        Wire.write(0x00); // set all of port A to outputs
        Wire.endTransmission();

        Wire.beginTransmission(MCP1);
        Wire.write(0x01); // IODIRA register
        Wire.write(0x00); // set all of port A to outputs
        Wire.endTransmission();

        Wire.beginTransmission(MCP2);
        Wire.write(0x00); // IODIRA register
        Wire.write(0x00); // set all of port A to outputs
        Wire.endTransmission();

        //MCP2 Port B is input by default
    }

    void loop()
    {
        //Loop triggers every 200 msec and sends back gyro heading, and roll, steer angle etc

        currentTime = millis();

        if (currentTime - lastTime >= LOOP_TIME)
        {
            lastTime = currentTime;

            //If connection lost to AgOpenGPS, the watchdog will count up 
            if (watchdogTimer++ > 250) watchdogTimer = 12;

            //clean out serial buffer to prevent buffer overflow
            if (serialResetTimer++ > 20)
            {
                while (Serial.available() > 0) Serial.read();
                serialResetTimer = 0;
            }

            if (watchdogTimer > 12)
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

            AOG[5] = pin[0];
            AOG[6] = pin[1];
            AOG[7] = mcpInput;


            //add the checksum
            int16_t CK_A = 0;
            for (uint8_t i = 2; i < sizeof(AOG) - 1; i++)
            {
                CK_A = (CK_A + AOG[i]);
            }
            AOG[sizeof(AOG) - 1] = CK_A;

            Serial.write(AOG, sizeof(AOG));
            Serial.flush();   // flush out buffer

        } //end of timed loop

        // Serial Receive
        //Do we have a match with 0x8081?    
        if (Serial.available() > 4 && !isHeaderFound && !isPGNFound)
        {
            uint8_t temp = Serial.read();
            if (tempHeader == 0x80 && temp == 0x81)
            {
                isHeaderFound = true;
                tempHeader = 0;
            }
            else
            {
                tempHeader = temp;     //save for next time
                return;
            }
        }

        //Find Source, PGN, and Length
        if (Serial.available() > 2 && isHeaderFound && !isPGNFound)
        {
            Serial.read(); //The 7F or less
            pgn = Serial.read();
            dataLength = Serial.read();
            isPGNFound = true;
            idx = 0;
        }

        //The data package
        if (Serial.available() > dataLength && isHeaderFound && isPGNFound)
        {
            if (pgn == 239) // EF Machine Data
            {
                uTurn = Serial.read();
                gpsSpeed = (float)Serial.read();

                hydLift = Serial.read();
                tramline = Serial.read();  //actual speed times 4, single uint8_t

                //just get the rest of bytes
                Serial.read();   //high,low bytes   
                Serial.read();

                relayLo = Serial.read();          // read relay control from AgOpenGPS
                relayHi = Serial.read();

                //Bit 13 CRC
                Serial.read();

                //reset watchdog
                watchdogTimer = 0;

                //Reset serial Watchdog  
                serialResetTimer = 0;

                //reset for next pgn sentence
                isHeaderFound = isPGNFound = false;
                pgn = dataLength = 0;
            }

            else if (pgn == 238) //EE Machine Settings 
            {
                aogConfig.raiseTime = Serial.read();
                aogConfig.lowerTime = Serial.read();
                aogConfig.enableToolLift = Serial.read();

                //set1 
                uint8_t sett = Serial.read();  //setting0     
                if (bitRead(sett, 0)) aogConfig.isRelayActiveHigh = 1; else aogConfig.isRelayActiveHigh = 0;

                aogConfig.user1 = Serial.read();
                aogConfig.user2 = Serial.read();
                aogConfig.user3 = Serial.read();
                aogConfig.user4 = Serial.read();

                //crc
                //udpData[13];        //crc
                Serial.read();

                //save in EEPROM and restart
                EEPROM.put(6, aogConfig);
                resetFunc();

                //reset for next pgn sentence
                isHeaderFound = isPGNFound = false;
                pgn = dataLength = 0;
            }

            else if (pgn == 236) //EC Relay Pin Settings 
            {
                for (uint8_t i = 0; i < 24; i++)
                {
                    pin[i] = Serial.read();
                }

                //save in EEPROM and restart
                EEPROM.put(20, pin);
                //resetFunc();

                //reset for next pgn sentence
                isHeaderFound = isPGNFound = false;
                pgn = dataLength = 0;
            }

            else //nothing found, clean up
            {
                isHeaderFound = isPGNFound = false;
                pgn = dataLength = 0;
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

        //set ouputs base on function and state
        uint8_t mcpOut = 0;
        mcpOut |=  relayState[pin[0] - 1];
        mcpOut |= (relayState[pin[1] - 1] << 1);
        mcpOut |= (relayState[pin[2] - 1] << 2);
        mcpOut |= (relayState[pin[3] - 1] << 3);
        mcpOut |= (relayState[pin[4] - 1] << 4);
        mcpOut |= (relayState[pin[5] - 1] << 5);
        mcpOut |= (relayState[pin[6] - 1] << 6);
        mcpOut |= (relayState[pin[7] - 1] << 7);

        if (!aogConfig.isRelayActiveHigh)  mcpOut = 255 - mcpOut;; //invert relays?

        Wire.beginTransmission(MCP1);
        Wire.write(0x12); // address port A of first MCP
        Wire.write(mcpOut); // value to send
        Wire.endTransmission();

        mcpOut = 0;
        mcpOut |=  relayState[pin[8] - 1];
        mcpOut |= (relayState[pin[9] - 1] << 1);
        mcpOut |= (relayState[pin[10] - 1] << 2);
        mcpOut |= (relayState[pin[11] - 1] << 3);
        mcpOut |= (relayState[pin[12] - 1] << 4);
        mcpOut |= (relayState[pin[13] - 1] << 5);
        mcpOut |= (relayState[pin[14] - 1] << 6);
        mcpOut |= (relayState[pin[15] - 1] << 7);

        if (!aogConfig.isRelayActiveHigh)  mcpOut = 255 - mcpOut;; //invert relays?

        Wire.beginTransmission(MCP1);
        Wire.write(0x13); // address port B
        Wire.write(mcpOut); // value to send
        Wire.endTransmission();

        mcpOut = 0;

        mcpOut |= relayState[pin[16] - 1];
        mcpOut |= (relayState[pin[17] - 1] << 1);
        mcpOut |= (relayState[pin[18] - 1] << 2);
        mcpOut |= (relayState[pin[19] - 1] << 3);
        mcpOut |= (relayState[pin[20] - 1] << 4);
        mcpOut |= (relayState[pin[21] - 1] << 5);
        mcpOut |= (relayState[pin[22] - 1] << 6);
        mcpOut |= (relayState[pin[23] - 1] << 7);

        if (!aogConfig.isRelayActiveHigh) mcpOut = 255 - mcpOut; //invert relays?

        Wire.beginTransmission(MCP2);
        Wire.write(0x12); // address port A of second MCP
        Wire.write(mcpOut); // value to send
        Wire.endTransmission();

        mcpOut = 0;

        //read the input port
        Wire.beginTransmission(MCP2);
        Wire.write(0x13); // set MCP23017 memory pointer to GPIOB address
        Wire.endTransmission();
        Wire.requestFrom(0x20, 1); // request one byte of data from second MCP20317
        mcpInput = Wire.read(); // store the incoming byte
    }
   