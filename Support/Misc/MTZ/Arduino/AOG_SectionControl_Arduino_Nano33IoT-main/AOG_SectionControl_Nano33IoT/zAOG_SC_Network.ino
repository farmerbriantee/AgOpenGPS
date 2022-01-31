// WIFI handling 8. März 2020 for Nano 33 IoT -------------------------------------------


//here supporting 2 WiFi networks, so set number of network!!

void WiFi_Start_STA() {
    unsigned long timeout, timeout2;

    if (WiFi_netw_nr == 2) {
        WiFi.begin(Set.ssid2, Set.password2);
        timeout = millis() + (Set.timeoutRouter2 * 1000);
        timeout2 = timeout - (Set.timeoutRouter2 * 500);
        Serial.print("try to connect to WiFi: "); Serial.println(Set.ssid2);
    }
    else {
        Serial.print("try to connect to WiFi: "); Serial.println(Set.ssid1);
        WiFi.begin(Set.ssid1, Set.password1);
        timeout = millis() + (Set.timeoutRouter * 1000);
        timeout2 = timeout - (Set.timeoutRouter * 500);
    }
    while (WiFi.status() != WL_CONNECTED && millis() < timeout) {
        delay(100);
        Serial.print(".");
        //switches -> set relais
        if ((Set.SectSWInst) || (Set.SectMainSWType != 0)) {
            SectSWRead();
        }
        SetRelays();
        //Rate switches and motor drive
        if ((Set.RateSWLeftInst == 1) || (Set.RateSWRightInst == 1)) { RateSWRead(); }
        if (Set.RateControlLeftInst == 0) { motorDrive(); } //if Manual do everytime, not only in timed loop
        delay(50);

        if ((millis() > timeout2) && (WiFi.status() != WL_CONNECTED)) {
            WiFi.end();
            delay(200);
            if (WiFi_netw_nr == 2) { WiFi.begin(Set.ssid2, Set.password2); }
            else { WiFi.begin(Set.ssid1, Set.password1); }
            timeout2 = timeout + 300;
        }
        //WIFI LED blink in double time while connecting
        WiFi_LED_blink(2);
    }  //connected or timeout  

    Serial.println(""); //NL  
    if (WiFi.status() == WL_CONNECTED)
    {
        delay(200);
        Serial.println();
        Serial.print("WiFi Client successfully connected to : ");
        if (WiFi_netw_nr == 2) { Serial.println(Set.ssid2); }
        else { Serial.println(Set.ssid1); }
        Serial.print("Connected IP - Address : ");
        IPAddress myip = WiFi.localIP();
        Serial.println(myip);
        IPAddress gwip = WiFi.gatewayIP();
        //after connecting get IP from router -> change it to x.x.x.IP Ending (from settings)
        if (myip[3] != Set.WiFi_myip[3]) {

            //switches -> set relais
            if ((Set.SectSWInst) || (Set.SectMainSWType != 0)) {
                SectSWRead();
            }
            SetRelays();
            //Rate switches and motor drive
            if ((Set.RateSWLeftInst == 1) || (Set.RateSWRightInst == 1)) { RateSWRead(); }
            if (Set.RateControlLeftInst == 0) { motorDrive(); } //if Manual do everytime, not only in timed loop


            myip[3] = Set.WiFi_myip[3]; //set ESP32 IP to x.x.x.myIP_ending
            Serial.print("changing IP to: ");
            Serial.println(myip);
 //nano 33iot
            WiFi.config(myip, gwip, gwip, Set.mask);
            delay(200);
            Serial.print("Connected IP - Address : ");
            myip = WiFi.localIP();
        }
        Set.WiFi_myip[0] = myip[0];
        Set.WiFi_myip[1] = myip[1];
        Set.WiFi_myip[2] = myip[2];
        Set.WiFi_myip[3] = myip[3];
        Serial.println(myip);
        Serial.print("Gateway IP - Address : ");
        Serial.println(gwip);
        Set.WiFi_gwip[0] = gwip[0];
        Set.WiFi_gwip[1] = gwip[1];
        Set.WiFi_gwip[2] = gwip[2];
        Set.WiFi_gwip[3] = gwip[3];
        WiFi_ipDestination[0] = myip[0];
        WiFi_ipDestination[1] = myip[1];
        WiFi_ipDestination[2] = myip[2];
        WiFi_ipDestination[3] = 255;//set IP to x.x.x.255 according to actual network
        LED_WIFI_ON = true;
        digitalWrite(Set.LEDWiFi_PIN, Set.LEDWiFi_ON_Level);
        my_WiFi_Mode = 1;// WIFI_STA;
    }
    else
    {
        // WiFi.end();
        Serial.println("WLAN-Client-Connection failed");
        Serial.println();
        LED_WIFI_ON = false;
        digitalWrite(Set.LEDWiFi_PIN, !Set.LEDWiFi_ON_Level);
    }
    delay(20);
}


//-------------------------------------------------------------------------------------------------
// start WiFi Access Point = only if no existing WiFi
// AccessPoint on Nano 33 IoT

void WiFi_Start_AP() {
    WiFi.end();
    delay(500);
    delay(300);

    WiFi.config(Set.WiFi_gwip, Set.WiFi_gwip, Set.WiFi_gwip, Set.mask);// set fix IP for AP  
    delay(300);  //right IP adress only with this delay
    byte my_Wifi_mode = WiFi.beginAP(Set.ssid_ap);
    delay(500);
    //switches -> set relais
    if ((Set.SectSWInst) || (Set.SectMainSWType != 0)) {
        SectSWRead();
    }
    SetRelays();
    //Rate switches and motor drive
    if ((Set.RateSWLeftInst == 1) || (Set.RateSWRightInst == 1)) { RateSWRead(); }
    if (Set.RateControlLeftInst == 0) { motorDrive(); } //if Manual do everytime, not only in timed loop
    delay(300);
    Serial.print("status of WiFi AP: ");
    Serial.println(my_Wifi_mode);
    IPAddress myip = WiFi.localIP();
    // delay(300);
    Serial.print("Accesspoint started - Name : ");
    Serial.println(Set.ssid_ap);
    Serial.print(" IP address: ");
    Serial.println(myip);
    Set.WiFi_myip[0] = myip[0];
    Set.WiFi_myip[1] = myip[1];
    Set.WiFi_myip[2] = myip[2];
    Set.WiFi_myip[3] = myip[3];
    WiFi_ipDestination[0] = myip[0];
    WiFi_ipDestination[1] = myip[1];
    WiFi_ipDestination[2] = myip[2];
    WiFi_ipDestination[3] = 255;//set IP to x.x.x.255 according to actual network    

    myip = WiFi.gatewayIP();
    Serial.print("Gateway IP - Address : ");
    Serial.println(myip);
    Set.WiFi_gwip[0] = myip[0];
    Set.WiFi_gwip[1] = myip[1];
    Set.WiFi_gwip[2] = myip[2];
    Set.WiFi_gwip[3] = myip[3];
    delay(50);

    LED_WIFI_ON = true;
    digitalWrite(Set.LEDWiFi_PIN, Set.LEDWiFi_ON_Level);
    my_WiFi_Mode = 2;
}



//-------------------------------------------------------------------------------------------------

void UDP_Start()
{   //init UPD
    if (WiFiUDPToAOG.begin(Set.PortSCToAOG))
    {
        Serial.print("UDP sendig to IP: ");
        for (byte n = 0; n < 4; n++) {
            Serial.print(WiFi_ipDestination[n]);
            Serial.print(".");
        }
        Serial.print(" from port: ");
        Serial.print(Set.PortSCToAOG);
        Serial.print(" to port: ");
        Serial.println(Set.PortDestination);
    }
    delay(300);
    if (WiFiUDPFromAOG.begin(Set.PortFromAOG))
    {
        Serial.print("UDP listening for AOG data on IP: ");
        Serial.println(WiFi.localIP());
        Serial.print(" on port: ");
        Serial.println(Set.PortFromAOG);
        WiFiUDPRunning = true;
    }
}


//-------------------------------------------------------------------------------------------------

/*
void WiFi_connection_check() {
    delay(5);
    if (WiFi.status() == WL_CONNECTED) {
        if (SectAuto) {
            //WIFI LED blink 8x faster while no new data
            WiFi_LED_blink(3);
#if HardwarePlatform == 1//nano 33iot
            pingResult = WiFi.ping(Set.gwip);
            delay(5);
            Serial.print("no Section control Data, ping to Gateway (ms): "); Serial.print(pingResult);
            Serial.print("   Watchdog counter: "); Serial.println(WiFiWatchDog);
            if (pingResult >= 0) { WiFiWatchDog = 0; }
            else WiFiWatchDog++;
        }
        if (WiFiWatchDog > 3) {//reconnect
            LED_WIFI_ON = false;
            digitalWrite(Set.LEDWiFi_PIN, !Set.LEDWiFi_ON_Level);
            Serial.print("WiFi error: no data for "); Serial.print(now - DataFromAOGTime);
            Serial.print(" ms. No ping to "); for (byte n = 0; n < 4; n++) { Serial.print(Set.gwip[n]); Serial.print("."); }
            Serial.println();
            Serial.print("Closing WiFi and try to reconnect to network: ");
            if (WiFi_netw_nr == 2) { Serial.println(Set.ssid2); }
            else { Serial.println(Set.ssid); }
            WiFi.end();
            delay(200);
            delay(200);
            timeout = millis() + 10000;//close wifi every 10s when no new connection
            WiFiWatchDog = 0;
#endif
        }
        if (WiFi.localIP()[3] != WiFi_ipDestination) {
#if HardwarePlatform == 0  //ESP32 
            if (!WiFi.config(Set.myip, Set.gwip, Set.mask, Set.gwip)) { Serial.println("STA Failed to configure"); }
#endif
#if HardwarePlatform == 1//nano 33iot
            WiFi.config(Set.myip, Set.gwip, Set.gwip, Set.mask);
#endif
            delay(200);
            delay(5);
            Serial.println();
            Serial.print("WiFi Client connected to : ");
            if (WiFi_netw_nr == 2) { Serial.println(Set.ssid2); }
            else { Serial.println(Set.ssid); }
            Serial.print("Connected IP - Address : ");
            Serial.println(WiFi.localIP());
            WiFiWatchDog = 0;
        }
        if (!WiFiUDPRunning) { UDP_Start(); }
    }
    else {
        //Serial.print("Wifi Watchdog: "); Serial.println(WiFiWatchDog);
        WiFiUDPRunning = false;
        digitalWrite(Set.LEDWiFi_PIN, !Set.LEDWiFi_ON_Level);
        LED_WIFI_ON = false;
        WiFiWatchDog++;
        if (WiFiWatchDog > 50) {
            WiFiWatchDog = 0;//give router some time to check request
            if (millis() > timeout) {
                Serial.println();
                Serial.print("Closing WiFi and try to reconnect to network: ");
                if (WiFi_netw_nr == 2) { Serial.println(Set.ssid2); }
                else { Serial.println(Set.ssid); }
#if HardwarePlatform == 0  //ESP32  
                WiFi.disconnect();
#endif
#if HardwarePlatform == 1//nano 33iot
                WiFi.end();
#endif
                delay(200);
                delay(200);
#if HardwarePlatform == 0  //ESP32  
                WiFi.mode(WIFI_STA);   //  Workstation
#endif
                timeout = millis() + 10000;//close wifi every 10s when no new connection
            }
            //reconnection
            Serial.print(".");
            if (WiFi_netw_nr == 2) { WiFi.begin(Set.ssid2, Set.password2); }
            else { WiFi.begin(Set.ssid, Set.password); }
            delay(10);
        }
    }
}





*/










/*// WIFI handling 7. Maerz 2021 for ESP32  -------------------------------------------

void WiFi_handle_connection() {
    IPAddress gwIP, myIP;

    if (now > WiFi_connect_timer + 450) {



        if (Set.debugmode) { Serial.print("WiFi_connect_step: "); Serial.println(WiFi_connect_step); }
        switch (WiFi_connect_step) {
            //WiFi network scan
        case 10:
            WiFi_netw_nr = 0;
            WebIORunning = false;
            WiFiUDPRunning = false;
            if (WiFi_network_search_timeout == 0) {   //first run                 
                WiFi_network_search_timeout = now + (Set.timeoutRouter * 1000);
            }
#if HardwarePlatform == 1  //Nano33IoT
            
            Serial.print("WiFi Status before network scan: "); Serial.println(WiFi.status());

            delay(1);
#endif   
            WiFi_scan_networks();
            Serial.print("number of network to connect: "); Serial.println(WiFi_netw_nr);
            Serial.print("WiFi Status after network scan: "); Serial.println(WiFi.status());
            //timeout?
            if (now > WiFi_network_search_timeout) { WiFi_connect_step = 50; }
            else {
                if (WiFi_netw_nr > 0) {
                    //found network                    
                    WiFi_network_search_timeout = 0;//reset timer
                    Serial.print("WiFi Status after network scan if in nr 10: "); Serial.println(WiFi.status());
                    WiFi_STA_connect_network();
                    delay(100);
                    Serial.print("WiFi Status after begin if in nr 10: "); Serial.println(WiFi.status());
                    if (WiFi.status() == WL_CONNECTED) { WiFi_connect_step = 14; }                    
                    else { WiFi_connect_step = 18; }
                    delay(10);
                }
            }
            WiFi_connect_timer = millis();
            break;

            //change IP / DHCP
        case 14:
            //connected
            delay(5);
            Serial.print("WiFi Status after connection nr 14: "); Serial.println(WiFi.status());
            Serial.println();
            Serial.println("WiFi Client successfully connected");
            Serial.print("Connected IP - Address : ");
            myIP = WiFi.localIP();
            delay(1);
            Serial.println(myIP);
            //after connecting get IP from router -> change it to x.x.x.IP Ending (from settings)
            myIP[3] = Set.WiFi_myip[3]; //set Nano33iot IP to x.x.x.myIP_ending
            Serial.print("changing IP to: ");
            Serial.println(myIP);
            delay(1);
            gwIP = WiFi.gatewayIP();
            delay(1);
            WiFi.config(myIP, gwIP, gwIP, Set.mask);
            delay(500);
            WiFi_connect_step++;
            WiFi_connect_timer = now;
            break;
        case 15:
            delay(1);
            myIP = WiFi.localIP();
            Serial.print("Connected IP - Address : "); Serial.println(myIP);
            WiFi_ipDestination = myIP;
            WiFi_ipDestination[3] = Set.WiFi_ipDest_ending;
            Serial.print("sending to IP - Address : "); Serial.println(WiFi_ipDestination);
            delay(1);
            gwIP = WiFi.gatewayIP();
            Serial.print("Gateway IP - Address : "); Serial.println(gwIP);
            my_WiFi_Mode = 1;// WIFI_STA;
            WiFi_connect_step = 20;
            WiFi_connect_timer = now;
            break;
            //no connection at first try, try again
        case 17:
            if (WiFi_STA_connect_call_nr > 2) { //create access point
                WiFi_connect_step = 50;
                WiFi_netw_nr = 0;
            }
            else {
               // WiFi.disconnect();
                delay(2);
                WiFi_connect_step++;
                Serial.print("-");
            }
            WiFi_connect_timer = now + 500;//wait a little longer
            break;
        case 18: 
            Serial.print("WiFi Status before end called: "); Serial.println(WiFi.status());
            WiFi.end();
            delay(200);
            Serial.print("WiFi Status after end called: "); Serial.println(WiFi.status());
            WiFi_connect_step = 10; //network search
            WiFi_connect_timer = now + 500;
            break;

            //UDP
        case 20://init WiFi UDP sending to AOG
            if (WiFiUDPToAOG.begin(Set.PortSCToAOG))
            {
                Serial.print("UDP writing to IP: ");
                Serial.println(WiFi_ipDestination);
                Serial.print("UDP writing to port: ");
                Serial.println(Set.PortDestination);
                Serial.print("UDP writing from port: ");
                Serial.println(Set.PortSCToAOG);
            }
            else { Serial.println("Error starting UDP"); }
            WiFi_connect_step++;
            WiFi_connect_timer = now;
            break;
        case 21:
            //init WiFi UPD listening to AOG 
            if (WiFiUDPFromAOG.begin(Set.PortFromAOG))
            {
                Serial.print("WiFi UDP Listening for AOG data to port: ");
                Serial.println(Set.PortFromAOG);
                Serial.println();
                WiFiUDPRunning = true;
            }
            else { Serial.println("Error starting UDP"); }
            delay(2);

            WiFi_connect_step = 100;
            WiFi_connect_timer = now;
            break;

            //Access point start
        case 50://start access point
            WiFi_Start_AP();
            WiFi_connect_step++;
            WiFi_connect_timer = now;
            break;
        case 51:
            if (my_WiFi_Mode == 2) { WiFi_connect_step++; }
            WiFi_connect_timer = now;
            break;
        case 52://init WiFi UDP sending to AOG
            WiFiUDPToAOG.begin(Set.PortSCToAOG);
            Serial.print("UDP writing to IP: ");
            Serial.println(WiFi_ipDestination);
            Serial.print("UDP writing to port: ");
            Serial.println(Set.PortDestination);
            Serial.print("UDP writing from port: ");
            Serial.println(Set.PortSCToAOG);
            WiFi_connect_step++;
            WiFi_connect_timer = now;
            break;
        case 53:
            //init WiFi UPD listening to AOG 
            WiFiUDPFromAOG.begin(Set.PortFromAOG);
            Serial.print("NTRIP WiFi UDP Listening to port: ");
            Serial.println(Set.PortFromAOG);
            Serial.println();
            delay(2);
            WiFi_connect_step = 100;
            WiFi_connect_timer = now;
            break;

            //Webserver start
        case 100:
            //start Server for Webinterface
           // WiFiStartServer();
            WiFi_connect_step++;
            WiFi_connect_timer = now;
            break;

        case 101:
            WebIOTimeOut = millis() + (long(Set.timeoutWebIO) * 60000);
            //xTaskCreate(doWebinterface, "WebIOHandle", 5000, NULL, 1, &taskHandle_WebIO);
            delay(300);
            WiFi_connect_step = 0;
            WiFi_connect_timer = 0;
            LED_WIFI_ON = true;
            Serial.println(); Serial.println();
#if HardwarePlatform == 0  //ESP32
            if (WiFi_netw_nr == 0) { myIP = WiFi.softAPIP(); }
            else {
#endif
                myIP = WiFi.localIP();
#if HardwarePlatform == 0  //ESP32 
            }
#endif

            Serial.print("started settings Webinterface at: ");
            for (byte i = 0; i < 3; i++) {
                Serial.print(myIP[i]); Serial.print(".");
            }
            Serial.println(myIP[3]);
            Serial.println("type IP in Internet browser to get to webinterface");
            Serial.print("you need to be in WiFi network ");
            switch (WiFi_netw_nr) {
            case 0: Serial.print(Set.ssid_ap); break;
            case 1: Serial.print(Set.ssid1); break;
            }
            Serial.println(" to get access"); Serial.println(); Serial.println();
#if useLED_BUILTIN
            digitalWrite(LED_BUILTIN, HIGH);
#endif
            digitalWrite(Set.LEDWiFi_PIN, Set.LEDWiFi_ON_Level);
            break;

        default:
            WiFi_connect_step++;
            Serial.print("default called at WiFi_connection_step "); Serial.println(WiFi_connect_step);
            break;
        }
    }
}

//---------------------------------------------------------------------
// scanning for known WiFi networks

void WiFi_scan_networks()
{

    Serial.println("scanning for WiFi networks");
    // WiFi.scanNetworks will return the number of networks found
    int WiFi_num_netw_inReach = WiFi.scanNetworks();
    delay(1);
    Serial.print("scan done: ");
    if (WiFi_num_netw_inReach <= 0) {
        Serial.println("no networks found");
    }
    else
    {
        Serial.print(WiFi_num_netw_inReach);
        Serial.println(" network(s) found");
        for (int i = 0; i < WiFi_num_netw_inReach; ++i) {
            Serial.println("#" + String(i + 1) + " network : " + WiFi.SSID(i));
            delay(1);
        }

        for (int i = 0; i < WiFi_num_netw_inReach; ++i) {
            delay(1);
            bool match = true;
            for (byte n; n < 24; n++) {
                if (WiFi.SSID(i)[n] != Set.ssid1[n]) {
                    match = false;
                    Serial.print(WiFi.SSID(i)[n]); Serial.println(Set.ssid1[n]);
                }
            }
            if (match) {
                // network found in list
                Serial.print("Connecting to: "); Serial.println(Set.ssid1);
                WiFi_netw_nr = 1;
                break;
            }
            delay(1);
            match = true; //reset
            for (byte n; n < 24; n++) {
                if (WiFi.SSID(i)[n] != Set.ssid2[n]) {
                    match = false;
                    Serial.print(WiFi.SSID(i)[n]); Serial.println(Set.ssid2[n]);
                }
            }
            if (match) {
                // network found in list
                Serial.print("Connecting to: "); Serial.println(Set.ssid2);
                WiFi_netw_nr = 1;
                break;
            }
            delay(1);
            match = true; //reset
            for (byte n; n < 24; n++) {
                if (WiFi.SSID(i)[n] != Set.ssid3[n]) {
                    match = false;
                    Serial.print(WiFi.SSID(i)[n]); Serial.println(Set.ssid3[n]);
                }
            }
            if (match) {
                // network found in list
                Serial.print("Connecting to: "); Serial.println(Set.ssid3);
                WiFi_netw_nr = 1;
                break;
            }
            delay(1);
            match = true; //reset
            for (byte n; n < 24; n++) {
                if (WiFi.SSID(i)[n] != Set.ssid4[n]) {
                    match = false;
                    Serial.print(WiFi.SSID(i)[n]); Serial.println(Set.ssid4[n]);
                }
            }
            if (match) {
                // network found in list
                Serial.print("Connecting to: "); Serial.println(Set.ssid4);
                WiFi_netw_nr = 1;
                break;
            }
            delay(1);
            match = true; //reset
            for (byte n; n < 24; n++) {
                if (WiFi.SSID(i)[n] != Set.ssid5[n]) {
                    match = false;
                    Serial.print(WiFi.SSID(i)[n]); Serial.println(Set.ssid5[n]);
                }
            }
            if (match) {
                // network found in list
                Serial.print("Connecting to: "); Serial.println(Set.ssid5);
                WiFi_netw_nr = 1;
                break;
            }           
        }

    }
}  //end WiFi_scan_networks()

//-------------------------------------------------------------------------------------------------
//connects to WiFi network

void WiFi_STA_connect_network() {//run WiFi_scan_networks first
   // Serial.print("netwNr: "); Serial.print(WiFi_netw_nr);
    switch (WiFi_netw_nr) {
    case 1: 
        Serial.print("WiFi Status before begin in connect void: "); Serial.println(WiFi.status()); 
        WiFi.begin(Set.ssid1, Set.password1);  
        delay(1000);
        while (WiFi.status() != WL_CONNECTED && millis() < WiFi_network_search_timeout) {
            delay(300);
            Serial.print(".");
        }
        delay(100);
        Serial.print("WiFi Status after begin in connect void: "); Serial.println(WiFi.status()); break;
    case 2: WiFi.begin(Set.ssid2, Set.password2); break;
    case 3: WiFi.begin(Set.ssid3, Set.password3); break;
    case 4: WiFi.begin(Set.ssid4, Set.password4); break;
    case 5: WiFi.begin(Set.ssid5, Set.password5); break;
    }
    //set IP to DHCP on first run. call immediately after begin
#if HardwarePlatform == 0  //ESP32 
    if (WiFi_STA_connect_call_nr == 0) { WiFi.config(0U, 0U, 0U); Serial.println("enable DHCP for WiFi"); WiFi_STA_connect_call_nr++; }
#endif
    delay(2);
}



*/

/*
// WIFI handling 7. Maerz 2021 for Nano33IoT  -------------------------------------------

void WiFi_handle_connection() {

    IPAddress gwIP, myIP;
    if (now > (WiFi_connect_timer + 500)) //do every 250 ms
    {
        if (Set.debugmode) { Serial.print("WiFi_connect_step: "); Serial.println(WiFi_connect_step); }
        switch (WiFi_connect_step) {
            //WiFi network scan
        case 10:
            WiFi_netw_nr = 1;//set to 1, no search
            WebIORunning = false;
            WiFiUDPRunning = false;
            Serial.print("number of networks in reach: "); Serial.println(WiFi.scanNetworks());
          //  WiFi.begin(Set.ssid1, Set.password1);
          //  delay(300);
          //  Serial.print("WiFi status direkt : "), Serial.println(WiFi.status());
   /*         if (WiFi_netw_nr == 2) {
                WiFi.begin(Set.ssid2, Set.password2);
                timeout = millis() + (Set.timeoutRouter * 1000);
                timeout2 = timeout - (Set.timeoutRouter * 500);
                Serial.print("try to connect to WiFi: "); Serial.println(Set.ssid2);
            }
            else {
                Serial.print("try to connect to WiFi: "); Serial.println(Set.ssid1);
                WiFi.begin(Set.ssid1, Set.password1);
                timeout = millis() + (Set.timeoutRouter * 1000);
                timeout2 = timeout - (Set.timeoutRouter * 500);
            }
            while (WiFi.status() != WL_CONNECTED && millis() < timeout) {
                delay(300);
                Serial.print(".");
                if ((millis() > timeout2) && (WiFi.status() != WL_CONNECTED)) {
                    WiFi.end();
                    delay(200);
                    if (WiFi_netw_nr == 2) { WiFi.begin(Set.ssid2, Set.password2); }
                    else { WiFi.begin(Set.ssid1, Set.password1); }
                    timeout2 = timeout + 300;
                }
                //WIFI LED blink in double time while connecting
                WiFi_LED_blink(2);
            }  //connected or timeout  

            Serial.println(""); //NL  
            if (WiFi.status() == WL_CONNECTED)
            {
                delay(200);
                Serial.println();
                Serial.print("WiFi Client successfully connected to : ");
                if (WiFi_netw_nr == 2) { Serial.println(Set.ssid2); }
                else { Serial.println(Set.ssid1); }
                Serial.print("Connected IP - Address : ");
                IPAddress myip = WiFi.localIP();
                Serial.println(myip);
                IPAddress gwip = WiFi.gatewayIP();
                //after connecting get IP from router -> change it to x.x.x.IP Ending (from settings)
                if (myip[3] != Set.WiFi_ipDest_ending) {
                    myip[3] = Set.WiFi_ipDest_ending; //set ESP32 IP to x.x.x.myIP_ending
                    Serial.print("changing IP to: ");
                    Serial.println(myip);
                    WiFi.config(myip, gwip, gwip, Set.mask);

                    delay(200);
                    Serial.print("Connected IP - Address : ");
                    myip = WiFi.localIP();
                }
                Set.WiFi_myip[0] = myip[0];
                Set.WiFi_myip[1] = myip[1];
                Set.WiFi_myip[2] = myip[2];
                Set.WiFi_myip[3] = myip[3];
                Serial.println(myip);
                Serial.print("Gateway IP - Address : ");
                Serial.println(gwip);
                Set.WiFi_gwip[0] = gwip[0];
                Set.WiFi_gwip[1] = gwip[1];
                Set.WiFi_gwip[2] = gwip[2];
                Set.WiFi_gwip[3] = gwip[3];
                WiFi_ipDestination[0] = myip[0];
                WiFi_ipDestination[1] = myip[1];
                WiFi_ipDestination[2] = myip[2];
                WiFi_ipDestination[3] = 255;//set IP to x.x.x.255 according to actual network
                LED_WIFI_ON = true;
                digitalWrite(Set.LEDWiFi_PIN, Set.LEDWiFi_ON_Level);
                my_WiFi_Mode = 1;// WIFI_STA;
            }
            else
            {
                // WiFi.end();
                Serial.println("WLAN-Client-Connection failed");
                Serial.println();
                LED_WIFI_ON = false;
                digitalWrite(Set.LEDWiFi_PIN, !Set.LEDWiFi_ON_Level);
            }
            delay(20);
        


*/

/*
            WiFi_connect_step = 12;
            break;
            //start WiFi connection
        case 12:
            if (WiFi_network_search_timeout == 0) {   //first run  
                WiFi_network_search_timeout = now + (Set.timeoutRouter * 500);//half time
            }
            WiFi_STA_connect_network();
            WiFi_connect_step++;
            //delay(300);
            WiFi_connect_timer = millis();;

            break;
        case 13:
            delay(300);
            Serial.print("WiFi status: "), Serial.println(WiFi.status());
            if (WiFi.status() == WL_CONNECTED) { 
                //connected
                WiFi_connect_step++;
                WiFi_network_search_timeout = 0;//reset timer
                WiFi_connect_timer = now + 700;//wait longer to get correct IP
                delay(50);                
            }
            else {
                Serial.print(".");
                now = millis();
                WiFi_connect_timer = now;
                if (now > WiFi_network_search_timeout) {
                    //timeout
                    WiFi_STA_connect_call_nr++;
                    WiFi_connect_step = 17;//close WiFi and try again
                    WiFi_network_search_timeout += (Set.timeoutRouter * 500);//add rest of time
                }
            }
            break;
            //change IP / DHCP
        case 14:
            //connected
            Serial.println();
            Serial.println("WiFi Client successfully connected");
            Serial.print("Connected IP - Address : ");
            myIP = WiFi.localIP();
            Serial.println(myIP);
            //after connecting get IP from router -> change it to x.x.x.IP Ending (from settings)
            myIP[3] = Set.WiFi_myip[3]; //set ESP32 IP to x.x.x.myIP_ending
            Serial.print("changing IP to: ");
            Serial.println(myIP);
            gwIP = WiFi.gatewayIP();
            WiFi.config(myIP, gwIP, gwIP, Set.mask);
            WiFi_connect_step++;
            WiFi_connect_timer = now;
            break;
        case 15:
            myIP = WiFi.localIP();
            Serial.print("Connected IP - Address : "); Serial.println(myIP);
            WiFi_ipDestination = myIP;
            WiFi_ipDestination[3] = Set.WiFi_ipDest_ending;
            Serial.print("sending to IP - Address : "); Serial.println(WiFi_ipDestination);
            gwIP = WiFi.gatewayIP();
            Serial.print("Gateway IP - Address : "); Serial.println(gwIP);
            my_WiFi_Mode = 1;// WIFI_STA;
            WiFi_connect_step = 20;
            WiFi_connect_timer = now;
            break;
            //no connection at first try, try again
        case 17:
            if (WiFi_STA_connect_call_nr >= 2) { //create access point
                if (WiFi_netw_nr == 4) {
                    WiFi_connect_step = 50;
                    WiFi_netw_nr = 0;
                }
                if (WiFi_netw_nr == 3) {
                    if (Set.ssid5 != "") {
                        WiFi_netw_nr = 4;
                        WiFi_STA_connect_call_nr = 0;
                        WiFi_network_search_timeout = now + (Set.timeoutRouter * 500);//half time
                    }
                }
                if (WiFi_netw_nr == 2) {
                    if (Set.ssid4 != "") {
                        WiFi_netw_nr = 3; WiFi_STA_connect_call_nr = 0;
                        WiFi_network_search_timeout = now + (Set.timeoutRouter * 500);//half time
                    }
                }
                if (WiFi_netw_nr == 1) {
                    if (Set.ssid3 != "") {
                        WiFi_netw_nr = 2; WiFi_STA_connect_call_nr = 0;
                        WiFi_network_search_timeout = now + (Set.timeoutRouter * 500);//half time
                    }
                }
                if ((WiFi_netw_nr == 0) && (WiFi_connect_step != 50)) {
                    if (Set.ssid2 != "") {
                        WiFi_netw_nr = 1; WiFi_STA_connect_call_nr = 0;
                        WiFi_network_search_timeout = now + (Set.timeoutRouter * 500);//half time
                    }
                }

            }
            else {
                WiFi_connect_step++;
                Serial.print("-");
            }
            WiFi_connect_timer = now + 500;//wait a little longer
            break;
        case 18:
            WiFi.end();
            WiFi_connect_step = 12; //set STA
            WiFi_connect_timer = now + 500;
            Serial.print("WiFi Netw Nr: "); Serial.println(WiFi_netw_nr);
            break;

            //UDP
        case 20://init WiFi UDP sending to AOG
            if (WiFiUDPToAOG.begin(Set.PortSCToAOG))
            {
                Serial.print("UDP writing to IP: ");
                Serial.println(WiFi_ipDestination);
                Serial.print("UDP writing to port: ");
                Serial.println(Set.PortDestination);
                Serial.print("UDP writing from port: ");
                Serial.println(Set.PortSCToAOG);
            }
            else { Serial.println("Error starting UDP"); }
            WiFi_connect_step++;
            WiFi_connect_timer = now;
            break;
        case 21:
            //init WiFi UPD listening to AOG 
            if (WiFiUDPFromAOG.begin(Set.PortFromAOG))
            {
                Serial.print("WiFi UDP Listening for AOG data to port: ");
                Serial.println(Set.PortFromAOG);
                Serial.println();
                WiFiUDPRunning = true;
            }
            else { Serial.println("Error starting UDP"); }
            delay(2);

            WiFi_connect_step = 100;
            WiFi_connect_timer = now;
            break;

            //Access point start
        case 50://start access point
            WiFi_Start_AP();
            WiFi_connect_step++;
            WiFi_connect_timer = now;
            break;
        case 51:
            if (my_WiFi_Mode == 2) { WiFi_connect_step++; }
            WiFi_connect_timer = now;
            break;
        case 52://init WiFi UDP sending to AOG
            WiFiUDPToAOG.begin(Set.PortSCToAOG);
            Serial.print("UDP writing to IP: ");
            Serial.println(WiFi_ipDestination);
            Serial.print("UDP writing to port: ");
            Serial.println(Set.PortDestination);
            Serial.print("UDP writing from port: ");
            Serial.println(Set.PortSCToAOG);
            WiFi_connect_step++;
            WiFi_connect_timer = now;
            break;
        case 53:
            //init WiFi UPD listening to AOG 
            WiFiUDPFromAOG.begin(Set.PortFromAOG);
            Serial.print("NTRIP WiFi UDP Listening to port: ");
            Serial.println(Set.PortFromAOG);
            Serial.println();
            delay(2);
            WiFi_connect_step = 100;
            WiFi_connect_timer = now;
            break;

            //Webserver start
        case 100:
            WebIOTimeOut = millis() + (long(Set.timeoutWebIO) * 60000);
            //xTaskCreate(doWebinterface, "WebIOHandle", 5000, NULL, 1, &taskHandle_WebIO);
            //delay(300);
            WiFi_connect_step = 0;
            WiFi_connect_timer = 0;
            Serial.println(); Serial.println();
            myIP = WiFi.localIP();
            Serial.print("started settings Webinterface at: ");
            for (byte i = 0; i < 3; i++) {
                Serial.print(myIP[i]); Serial.print(".");
            }
            Serial.println(myIP[3]);
            Serial.println("type IP in Internet browser to get to webinterface");
            Serial.print("you need to be in WiFi network ");
            switch (WiFi_netw_nr) {
            case 0: Serial.print(Set.ssid_ap); break;
            case 1: Serial.print(Set.ssid1); break;
            }
            Serial.println(" to get access"); Serial.println(); Serial.println();
#if useLED_BUILTIN
            digitalWrite(LED_BUILTIN, HIGH);
#endif
            digitalWrite(Set.LEDWiFi_PIN, Set.LEDWiFi_ON_Level);
            break;

        default:
            WiFi_connect_step++;
            Serial.print("default called at WiFi_connection_step "); Serial.println(WiFi_connect_step);
            break;
        }
    }
}


//-------------------------------------------------------------------------------------------------
//connects to WiFi network

void WiFi_STA_connect_network() {//run WiFi_scan_networks first
   // Serial.print("netwNr: "); Serial.print(WiFi_netw_nr);
    switch (WiFi_netw_nr) {
    case 1:
        Serial.print("connecting to WiFi: "); Serial.println(Set.ssid1); 
        WiFi.begin(Set.ssid1, Set.password1);
        
       
        Serial.print("Wifi status in void connect: "); Serial.println(WiFi.status());

        break;
    case 2: WiFi.begin(Set.ssid2, Set.password2);
        Serial.print("connecting to WiFi: "); Serial.println(Set.ssid2);
        break;
    case 3: WiFi.begin(Set.ssid3, Set.password3); 
        Serial.print("connecting to WiFi: "); Serial.println(Set.ssid3); 
        break;
    case 4: WiFi.begin(Set.ssid4, Set.password4); 
        Serial.print("connecting to WiFi: "); Serial.println(Set.ssid4);
        break;
    case 5: WiFi.begin(Set.ssid5, Set.password5); 
        Serial.print("connecting to WiFi: "); Serial.println(Set.ssid5); 
        break;
    }
    delay(2);
}*/
/*
//-------------------------------------------------------------------------------------------------
// start WiFi Access Point = only if no existing WiFi or connection fails
void WiFi_Start_AP() {
    WiFi.end();
    delay(500);
    delay(300);

    WiFi.config(Set.WiFi_gwip, Set.WiFi_gwip, Set.WiFi_gwip, Set.mask);// set fix IP for AP  
    delay(300);  //right IP adress only with this delay
    byte my_Wifi_mode = WiFi.beginAP(Set.ssid_ap);
    delay(500);
    delay(300);
    Serial.print("status of WiFi AP: ");
    Serial.println(my_Wifi_mode);
    IPAddress myip = WiFi.localIP();
    // delay(300);
    Serial.print("Accesspoint started - Name : ");
    Serial.println(Set.ssid_ap);
    Serial.print(" IP address: ");
    Serial.println(myip);
    Set.WiFi_gwip[0] = myip[0];
    Set.WiFi_gwip[1] = myip[1];
    Set.WiFi_gwip[2] = myip[2];
    Set.WiFi_gwip[3] = myip[3];
    WiFi_ipDestination[0] = myip[0];
    WiFi_ipDestination[1] = myip[1];
    WiFi_ipDestination[2] = myip[2];
    WiFi_ipDestination[3] = 255;//set IP to x.x.x.255 according to actual network    

    myip = WiFi.gatewayIP();
    Serial.print("Gateway IP - Address : ");
    Serial.println(myip);
    Set.WiFi_gwip[0] = myip[0];
    Set.WiFi_gwip[1] = myip[1];
    Set.WiFi_gwip[2] = myip[2];
    Set.WiFi_gwip[3] = myip[3];
    delay(50);

    LED_WIFI_ON = true;
    digitalWrite(Set.LEDWiFi_PIN, Set.LEDWiFi_ON_Level);
    my_WiFi_Mode = 2;
}
*/
//-------------------------------------------------------------------------------------------------
// Server Index Page for OTA update
//-------------------------------------------------------------------------------------------------
/*

const char* serverIndex =
"<script src='https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js'></script>"
"<head>"
"<title>Firmware updater</title>"
"<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0;\" />\r\n""<style>divbox {background-color: lightgrey;width: 200px;border: 5px solid red;padding:10px;margin: 10px;}</style>"
"</head>"
"<body bgcolor=\"#ccff66\">""<font color=\"#000000\" face=\"VERDANA,ARIAL,HELVETICA\">"
"<h1>ESP firmware update</h1>"
"ver 4.3 - 10. Mai. 2020<br><br>"
"<form method='POST' action='#' enctype='multipart/form-data' id='upload_form'>"
"<br>Create a .bin file with Arduino IDE: Sketch -> Export compiled Binary<br>"
"<br><b>select .bin file to upload</b>"
"<br>"
"<br>"
"<input type='file' name='update'>"
"<input type='submit' value='Update'>"
"</form>"
"<div id='prg'>progress: 0%</div>"
"<script>"
"$('form').submit(function(e){"
"e.preventDefault();"
"var form = $('#upload_form')[0];"
"var data = new FormData(form);"
" $.ajax({"
"url: '/update',"
"type: 'POST',"
"data: data,"
"contentType: false,"
"processData:false,"
"xhr: function() {"
"var xhr = new window.XMLHttpRequest();"
"xhr.upload.addEventListener('progress', function(evt) {"
"if (evt.lengthComputable) {"
"var per = evt.loaded / evt.total;"
"$('#prg').html('progress: ' + Math.round(per*100) + '%');"
"}"
"}, false);"
"return xhr;"
"},"
"success:function(d, s) {"
"console.log('success!')"
"},"
"error: function (a, b, c) {"
"}"
"});"
"});"
"</script>";

*/
