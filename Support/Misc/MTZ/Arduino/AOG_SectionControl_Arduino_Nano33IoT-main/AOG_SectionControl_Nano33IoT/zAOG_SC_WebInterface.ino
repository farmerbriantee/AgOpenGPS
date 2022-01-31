// Wifi variables & definitions
#define MAX_PACKAGE_SIZE 2048
char HTML_String[10000];//pagelength 7506 11.3.2021
char HTTP_Header[150];

// Allgemeine Variablen

int Aufruf_Zaehler = 0;

#define ACTION_SET_SSID         1  
#define ACTION_SET_SSID2        2
#define ACTION_SET_OUTPUT_TYPE  3  
#define ACTION_SET_loadDefault  4
#define ACTION_SET_Msg          5
#define ACTION_SET_SectNum      6
#define ACTION_SET_IOFunctions  7
#define ACTION_SET_THRESHOLD    8
#define ACTION_SET_debugmode    9
#define ACTION_SET_RESTART     13
#define ACTION_SET_GPIO        14
#define ACTION_SET_aogVers     15
#define ACTION_SET_DataTransfVia 21
//#define ACTION_SET_WiFiLEDon    22

int action;

//-------------------------------------------------------------------------------------------------
// 11. Maerz 2020

void doWebInterface() {

    unsigned long my_timeout;

    // Check if a client has connected
    client_page = server.available();

    if (!client_page)  return;

    Serial.println("New Client:");           // print a message out the serial port

    my_timeout = millis() + 250L;
    while (!client_page.available() && (millis() < my_timeout)) { delay(10); }
    delay(10);
    if (millis() > my_timeout)
    {
        Serial.println("Client connection timeout!");
        client_page.flush();
        client_page.stop();
        return;
    }

    //---------------------------------------------------------------------
    //htmlPtr = 0;
    char c;
    if (client_page) {                        // if you get a client,
      //Serial.print("New Client.\n");                   // print a message out the serial port
        String currentLine = "";                // make a String to hold incoming data from the client
        while (client_page.connected()) {       // loop while the client's connected
            delay(0);
            if (client_page.available()) {        // if there's bytes to read from the client,
                char c = client_page.read();        // read a byte, then
                Serial.print(c);                             // print it out the serial monitor
                if (c == '\n') {                    // if the byte is a newline character

                  // if the current line is blank, you got two newline characters in a row.
                  // that's the end of the client HTTP request, so send a response:
                    if (currentLine.length() == 0) {

                        make_HTML01();  // create Page array
                       //---------------------------------------------------------------------
                       // HTTP headers always start with a response code (e.g. HTTP/1.1 200 OK)
                       // and a content-type so the client knows what's coming, then a blank line:
                        strcpy(HTTP_Header, "HTTP/1.1 200 OK\r\n");
                        strcat(HTTP_Header, "Content-Length: ");
                        strcati(HTTP_Header, strlen(HTML_String));
                        strcat(HTTP_Header, "\r\n");
                        strcat(HTTP_Header, "Content-Type: text/html\r\n");
                        strcat(HTTP_Header, "Connection: close\r\n");
                        strcat(HTTP_Header, "\r\n");

                        client_page.print(HTTP_Header);
                        delay(20);
                        send_HTML();
                        WebIOTimeOut = millis() + long((Set.timeoutWebIO * 60000));
                        // break out of the while loop:
                        break;
                    }
                    else {    // if you got a newline, then clear currentLine:
                        currentLine = "";
                    }
                }
                else if (c != '\r')
                { // if you got anything else but a carriage return character,
                    currentLine += c;      // add it to the end of the currentLine
                    if (currentLine.endsWith("HTTP"))
                    {
                        if (currentLine.startsWith("GET "))
                        {
                            currentLine.toCharArray(HTML_String, currentLine.length());
                            Serial.println(); //NL
                            exhibit("Request : ", HTML_String);
                            process_Request();
                        }
                    }
                }//end else
            } //end client available
        } //end while client.connected
        // close the connection:
        client_page.stop();
        Serial.print("Pagelength : ");
        Serial.print((long)strlen(HTML_String));
        Serial.print("   --> Client Disconnected\n");
    }// end if client 
}

//-------------------------------------------------------------------------------------------------
// Process given values
//-------------------------------------------------------------------------------------------------
void process_Request()
{
    int myIndex;

    if (Find_Start("/?", HTML_String) < 0 && Find_Start("GET / HTTP", HTML_String) < 0)
    {
        //nothing to process
        return;
    }
    action = Pick_Parameter_Zahl("ACTION=", HTML_String);

    if (action != ACTION_SET_RESTART) { EEprom_unblock_restart(); }
    if (action == ACTION_SET_loadDefault) {
        EEprom_read_default();
        delay(5);
    }
    // WiFi access data
    if (action == ACTION_SET_SSID) {

        myIndex = Find_End("SSID_MY=", HTML_String);
        if (myIndex >= 0) {
            for (int i = 0; i < 24; i++) Set.ssid1[i] = 0x00;
            Pick_Text(Set.ssid1, &HTML_String[myIndex], 24);
        }
        myIndex = Find_End("Password_MY=", HTML_String);
        if (myIndex >= 0) {
            for (int i = 0; i < 24; i++) Set.password1[i] = 0x00;
            Pick_Text(Set.password1, &HTML_String[myIndex], 24);
        }
        int tempint = Pick_Parameter_Zahl("timeoutRout=", HTML_String);
        if ((tempint >= 20) && (tempint <= 1000)) { Set.timeoutRouter = tempint; }
        /*        char* seachstr = "myip1=";
                tempint = Pick_Parameter_Zahl(seachstr, HTML_String);
                if ((tempint > 0) && (tempint < 256)) {
                    Set.myip[0] = tempint;
                    strcati(seachstr, tempint);
                    strcat(seachstr, ".");
                    tempint = Pick_Parameter_Zahl(seachstr, HTML_String);
                    if ((tempint > 0) && (tempint < 256)) {
                        Set.myip[1] = tempint;
                        strcati(seachstr, tempint);
                        strcat(seachstr, ".");
                        tempint = Pick_Parameter_Zahl(seachstr, HTML_String);
                        if ((tempint > 0) && (tempint < 256)) {
                            Set.myip[2] = tempint;
                            strcati(seachstr, tempint);
                            strcat(seachstr, ".");
                            tempint = Pick_Parameter_Zahl(seachstr, HTML_String);
                            if ((tempint > 0) && (tempint < 256)) {
                                Set.myip[3] = tempint;
                                strcati(seachstr, tempint);
                                strcat(seachstr, ".");
                                tempint = Pick_Parameter_Zahl(seachstr, HTML_String);
                            }
                        }
                    }
                }*/
        EEprom_write_all();
    }
    if (action == ACTION_SET_SSID2) {

        myIndex = Find_End("SSID2_MY=", HTML_String);
        if (myIndex >= 0) {
            for (int i = 0; i < 24; i++) Set.ssid2[i] = 0x00;
            Pick_Text(Set.ssid2, &HTML_String[myIndex], 24);
        }
        myIndex = Find_End("Password2_MY=", HTML_String);
        if (myIndex >= 0) {
            for (int i = 0; i < 24; i++) Set.password2[i] = 0x00;
            Pick_Text(Set.password2, &HTML_String[myIndex], 24);
        }
        int tempint = Pick_Parameter_Zahl("timeoutRout2=", HTML_String);
        if ((tempint >= 1) && (tempint <= 1000)) { Set.timeoutRouter2 = tempint; }
        EEprom_write_all();

    }
    if (action == ACTION_SET_DataTransfVia) {
        //int temp = Pick_Parameter_Zahl("AOGNTRIP=", HTML_String);
        if (Pick_Parameter_Zahl("DataTransfVia=", HTML_String) == 0) Set.DataTransVia = 0;
        if (Pick_Parameter_Zahl("DataTransfVia=", HTML_String) == 7) Set.DataTransVia = 7;
        //if (Pick_Parameter_Zahl("DataTransfVia=", HTML_String) == 4) Set.DataTransVia = 4;
        EEprom_write_all();
    }
    if (action == ACTION_SET_IOFunctions) {
        if (Pick_Parameter_Zahl("useRel=", HTML_String) == 1) { Set.SectRelaysInst = 1; }
        else { Set.SectRelaysInst = 0; }
        if (Pick_Parameter_Zahl("RelaySprayOn=", HTML_String) == 1) { Set.SectRelaysON = 1; }
        else { Set.SectRelaysON = 0; }
        if (Pick_Parameter_Zahl("useSw=", HTML_String) == 1) { Set.SectSWInst = 1; }
        else { Set.SectSWInst = 0; }
        if (Pick_Parameter_Zahl("DocOnly=", HTML_String) == 1) { Set.DocOnly = 1; }
        else { Set.DocOnly = 0; }
        if (Pick_Parameter_Zahl("DocSWspr=", HTML_String) == 1) { Set.SectSWAutoOrOn = 1; }
        else { Set.SectSWAutoOrOn = 0; }
        if (Pick_Parameter_Zahl("useRCSw=", HTML_String) == 1) { Set.RateSWLeftInst = 1; }
        else { Set.RateSWLeftInst = 0; }
        int MSwtyp = Pick_Parameter_Zahl("MSw=", HTML_String);
        if (MSwtyp >= 0) { Set.SectMainSWType = MSwtyp; }
        assignGPIOs();
        EEprom_write_all();
    }
    if (action == ACTION_SET_THRESHOLD) {
        unsigned int WSThres_avg = 0;
        if (Set.SectMainSW_PIN < 255) {
            for (int i = 0; i < 8; i++) {
                WSThres_avg += analogRead(Set.SectMainSW_PIN);
                delay(100);
            }
            Set.HitchLevelVal = WSThres_avg >> 3;
            EEprom_write_all();
        }
    }
    if (action == ACTION_SET_aogVers) {
        int temp = Pick_Parameter_Zahl("aogVers=", HTML_String);
        if (temp > 0) { Set.aogVersion = temp; }
        if (Set.aogVersion == 17) {
            SCToAOG[0] = AOGSentenceHeader[2];
            SCToAOGOld[0] = AOGSentenceHeader[2];
            SCToAOG[1] = SCDataToAOGHeaderV17;
            SCToAOGOld[1] = SCDataToAOGHeaderV17;
            SCToAOG[2] = 0;
            SCToAOG[3] = 0;
            SCToAOG[4] = 0;
            SCToAOG[5] = 0;
            SCToAOG[6] = 0;
            DataToAOGLength = SCDataSentenceToAOGLengthV17;
            incomSentenceDigit = 2;
        }
        else {
            SCToAOG[0] = AOGSentenceHeader[0];   //0x80
            SCToAOG[1] = AOGSentenceHeader[1];   //0x81
            SCToAOG[2] = AOGSentenceHeader[2];   //0x7F
            SCToAOG[3] = SCDataToAOGHeader;		 //0xEA
            SCToAOG[4] = SCDataSentenceToAOGLength - 6; //length of data = all - header - length - CRC
            SCToAOGOld[0] = AOGSentenceHeader[0];
            SCToAOGOld[1] = AOGSentenceHeader[1];
            SCToAOGOld[2] = AOGSentenceHeader[2];
            SCToAOGOld[3] = SCDataToAOGHeader;
            SCToAOG[4] = SCDataSentenceToAOGLength - 6;
            SCToAOG[6] = 0;
            SCToAOG[7] = 0;
            SCToAOG[8] = 0;
            DataToAOGLength = SCDataSentenceToAOGLength;
            incomSentenceDigit = 0;
        }
        EEprom_write_all();
    }
    if (action == ACTION_SET_SectNum) {
        int temp = Pick_Parameter_Zahl("SectNum=", HTML_String);

        if (temp > 0) { Set.SectNum = temp; assignGPIOs(); }
        EEprom_write_all();
    }
    if (action == ACTION_SET_debugmode)
    {
        byte tempby = Pick_Parameter_Zahl("debugmode=", HTML_String);
        if (tempby == 1) {
            Set.debugmode = true;
        }
        else { Set.debugmode = false; }//no value back from page = 0

        tempby = Pick_Parameter_Zahl("debugmRel=", HTML_String);
        if (tempby == 1) {
            Set.debugmodeRelay = true;
        }
        else { Set.debugmodeRelay = false; }//no value back from page = 0

        tempby = Pick_Parameter_Zahl("debugmSw=", HTML_String);
        if (tempby == 1) {
            Set.debugmodeSwitches = true;
        }
        else { Set.debugmodeSwitches = false; }//no value back from page = 0

        tempby = Pick_Parameter_Zahl("debugmDatToAOG=", HTML_String);
        if (tempby == 1) {
            Set.debugmodeDataToAOG = true;
        }
        else { Set.debugmodeDataToAOG = false; }//no value back from page = 0

        tempby = Pick_Parameter_Zahl("debugmDatFrAOG=", HTML_String);
        if (tempby == 1) {
            Set.debugmodeDataFromAOG = true;
        }
        else { Set.debugmodeDataFromAOG = false; }//no value back from page = 0
        EEprom_write_all();
    }
    if (action == ACTION_SET_GPIO) {//crashes ESP, so commended out in HTML code ???
        char* seachStr = "RP";
        for (byte num = 0; num < Set.SectNum; num++) {
            Serial.print("Sect Num: "); Serial.print(num);
            seachStr = "RP";
            strcati(seachStr, num);
            strcat(seachStr, "=");
            int temp = Pick_Parameter_Zahl(seachStr, HTML_String);
            Serial.print(" PIN: "); Serial.println(temp);
            if ((temp >= 0) && (temp <= 255)) { Set.Relay_PIN[num] = temp; }
        }
        assignGPIOs();
        delay(50);
        EEprom_write_all();
    }
    if (action == ACTION_SET_RESTART) {
        EEprom_block_restart();//prevents from restarting, when webpage is reloaded. Is set to 0, when other ACTION than restart is called
        delay(1000);
        WiFi.end();
        delay(2000);
        Serial.println("restarting WiFi");
        WiFi_connect_step = 10;
        WiFi_netw_nr = 1;
    }
}

//-------------------------------------------------------------------------------------------------
// HTML Seite 01 aufbauen
//-------------------------------------------------------------------------------------------------
void make_HTML01() {

    strcpy(HTML_String, "<!DOCTYPE html>");
    strcat(HTML_String, "<html>");
    strcat(HTML_String, "<head>");
    strcat(HTML_String, "<title>Section Control Config Page</title>");
    strcat(HTML_String, "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0;\" />\r\n");
    //strcat( HTML_String, "<meta http-equiv=\"refresh\" content=\"10\">");
    strcat(HTML_String, "<style>divbox {background-color: lightgrey;width: 200px;border: 5px solid red;padding:10px;margin: 10px;}</style>");
    strcat(HTML_String, "</head>");
    strcat(HTML_String, "<body bgcolor=\"#ccff66\">");//ff9900
    strcat(HTML_String, "<font color=\"#000000\" face=\"VERDANA,ARIAL,HELVETICA\">");
    strcat(HTML_String, "<h1>Section control setup</h1>");
    strcat(HTML_String, "Section control software for AgOpenGPS running on Nano33IoT<br>");
    strcat(HTML_String, "supports data via USB / WiFi UDP <br>");
    strcat(HTML_String, "more settings like IPs, UPD ports... in setup zone of INO code<br><br>Version: ");
    strcati(HTML_String, vers_nr);
    strcat(HTML_String, VersionTXT);
    strcat(HTML_String, "<br><hr>");


    //---------------------------------------------------------------------------------------------  
    //load values of INO setup zone
    strcat(HTML_String, "<h2>Load default values of INO setup zone</h2>");
    strcat(HTML_String, "<form>");
    strcat(HTML_String, "<table>");
    set_colgroup(270, 250, 150, 0, 0);

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td colspan=\"2\">Only load default values, does NOT save them</td>");
    strcat(HTML_String, "<td><button style= \"width:150px\" name=\"ACTION\" value=\"");
    strcati(HTML_String, ACTION_SET_loadDefault);
    strcat(HTML_String, "\">Load default values</button></td>");
    strcat(HTML_String, "</tr>");
    strcat(HTML_String, "</table>");
    strcat(HTML_String, "</form>");
    strcat(HTML_String, "<br><hr>");


    //-----------------------------------------------------------------------------------------
    // WiFi Client Access Data1
    strcat( HTML_String, "<h2>#1 WiFi Network Client Access Data</h2>");
    strcat(HTML_String, "<form>");
    strcat(HTML_String, "If access fails, the WiFi network #2 will be tried<br><b>");
    strcat(HTML_String,"<br><br><table>");
    set_colgroup(250, 300, 150, 0, 0);

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td><b>#1 Network SSID:</b></td>");
    strcat(HTML_String, "<td>");
    strcat(HTML_String, "<input type=\"text\" style= \"width:200px\" name=\"SSID_MY\" maxlength=\"22\" Value =\"");
    strcat(HTML_String, Set.ssid1);
    strcat(HTML_String, "\"></td>");

    strcat(HTML_String, "<td><button style= \"width:120px\" name=\"ACTION\" value=\"");
    strcati(HTML_String, ACTION_SET_SSID);
    strcat(HTML_String, "\">Apply and Save</button></td>");
    strcat(HTML_String, "</tr>");

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td><b>#1 Password:</b></td>");
    strcat(HTML_String, "<td>");
    strcat(HTML_String, "<input type=\"text\" style= \"width:200px\" name=\"Password_MY\" maxlength=\"22\" Value =\"");
    strcat(HTML_String, Set.password1);
    strcat(HTML_String, "\"></td>");
    strcat(HTML_String, "</tr>");

    strcat(HTML_String, "<tr><td colspan=\"3\">&nbsp;</td></tr>");
    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td colspan=\"3\"><b></b>time, trying to connect to network #1</td></tr>");
    strcat(HTML_String, "<td colspan=\"3\">after time has passed, network #2 is tried</td></tr>");
    strcat(HTML_String, "<tr><td><b>#1 Timeout (s):</td><td><input type = \"number\"  name = \"timeoutRout\" min = \"20\" max = \"1000\" step = \"1\" style= \"width:200px\" value = \"");// placeholder = \"");
    strcati(HTML_String, Set.timeoutRouter);
    strcat(HTML_String, "\"></td>");
    strcat(HTML_String, "</tr>");
    strcat(HTML_String, "<tr><td colspan=\"3\">&nbsp;</td></tr>");
/*
    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td colspan=\"3\"><b></b>IP Addresses in network #1</td></tr>");
    strcat(HTML_String, "<tr><td><b>My IP:</td><td><input type = \"text\"  name = \"myip1\" min = \"20\" max = \"1000\" step = \"1\" style= \"width:200px\" value = \"");// placeholder = \"");
    strcati(HTML_String, Set.myip[0]); strcat(HTML_String, "."); strcati(HTML_String, Set.myip[1]); strcat(HTML_String, "."); strcati(HTML_String, Set.myip[2]); strcat(HTML_String, "."); strcati(HTML_String, Set.myip[3]);
    strcat(HTML_String, "\" pattern=\"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$\"></td>");
    strcat(HTML_String, "</tr>");
    strcat(HTML_String, "<tr><td><b>Gateway IP:</td><td><input type = \"text\"  name = \"gwip1\" min = \"20\" max = \"1000\" step = \"1\" style= \"width:200px\" value = \"");// placeholder = \"");
    strcati(HTML_String, Set.gwip[0]); strcat(HTML_String, "."); strcati(HTML_String, Set.gwip[1]); strcat(HTML_String, "."); strcati(HTML_String, Set.gwip[2]); strcat(HTML_String, "."); strcati(HTML_String, Set.gwip[3]);
    strcat(HTML_String, "\" pattern=\"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$\"></td>");
    strcat(HTML_String, "</tr>");
    strcat(HTML_String, "<tr><td colspan=\"3\"><b>Gateway IP and My IP should only be different in the last number</td></tr>");
    strcat(HTML_String, "<tr><td colspan=\"3\">AgOpenGPS IP will be Gateway IP x.x.x.255</td></tr>");
    strcat(HTML_String, "<tr><td colspan=\"3\">&nbsp;</td> </tr>");
    */

    strcat(HTML_String, "<tr><td colspan=\"2\"><b>Restart WiFi client for changes to take effect</b></td>");
    strcat(HTML_String, "<td><button style= \"width:120px\" name=\"ACTION\" value=\"");
    strcati(HTML_String, ACTION_SET_RESTART);
    strcat(HTML_String, "\">Restart</button></td>");
    strcat(HTML_String, "</tr>");

    strcat(HTML_String, "</table>");
    strcat(HTML_String, "</form>");
    strcat(HTML_String, "<br><hr>");

    //---------------------------------------------------------------------------------------------         
    // WiFi Client Access Data2
    strcat( HTML_String, "<h2>#2 WiFi Network Client Access Data</h2>");
    strcat(HTML_String, "<form>");
    strcat(HTML_String, "</b>If access to both networks fails, an accesspoint will be created:<br>SSID: <b>");
    strcat(HTML_String, Set.ssid_ap);
    strcat(HTML_String, "</b>     with no password<br><br><table>");
    set_colgroup(250, 300, 150, 0, 0);

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td><b>#2 Network SSID:</b></td>");
    strcat(HTML_String, "<td>");
    strcat(HTML_String, "<input type=\"text\" style= \"width:200px\" name=\"SSID2_MY\" maxlength=\"22\" Value =\"");
    strcat(HTML_String, Set.ssid2);
    strcat(HTML_String, "\"></td>");

    strcat(HTML_String, "<td><button style= \"width:120px\" name=\"ACTION\" value=\"");
    strcati(HTML_String, ACTION_SET_SSID2);
    strcat(HTML_String, "\">Apply and Save</button></td>");
    strcat(HTML_String, "</tr>");

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td><b>#2 Password:</b></td>");
    strcat(HTML_String, "<td>");
    strcat(HTML_String, "<input type=\"text\" style= \"width:200px\" name=\"Password2_MY\" maxlength=\"22\" Value =\"");
    strcat(HTML_String, Set.password2);
    strcat(HTML_String, "\"></td>");
    strcat(HTML_String, "</tr>");

    strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");
    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td colspan=\"3\">time, trying to connect to network #2</td></tr>");
    strcat(HTML_String, "<td colspan=\"3\">after time has passed access point is opened</td></tr>");
    strcat(HTML_String, "<tr><td><b>#2 Timeout (s):</td><td><input type = \"number\"  name = \"timeoutRout2\" min = \"1\" max = \"1000\" step = \"1\" style= \"width:200px\" value = \"");// placeholder = \"");
    strcati(HTML_String, Set.timeoutRouter2);
    strcat(HTML_String, "\"></td>");
    strcat(HTML_String, "</tr>");

    strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");
    strcat(HTML_String, "<tr><td colspan=\"2\"><b>Restart WiFi client for changes to take effect</b></td>");
    strcat(HTML_String, "<td><button style= \"width:120px\" name=\"ACTION\" value=\"");
    strcati(HTML_String, ACTION_SET_RESTART);
    strcat(HTML_String, "\">Restart</button></td>");
    strcat(HTML_String, "</tr>");

    strcat(HTML_String, "</table>");
    strcat(HTML_String, "</form>");
    strcat(HTML_String, "<br><hr>");

    //-----------------------------------------------------------------------------------------		
    // Data transfer via USB/Wifi 
    strcat(HTML_String, "<h2>USB or WiFi data transfer</h2>");
    strcat(HTML_String, "<form>");
    strcat(HTML_String, "<table>");
    set_colgroup(300, 250, 150, 0, 0);

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td>USB</td><td><input type = \"radio\" name=\"DataTransfVia\" id=\"JZ\" value=\"0\"");
    if (Set.DataTransVia == 0)strcat(HTML_String, " CHECKED");
    strcat(HTML_String, "><label for=\"JZ\"></label></td>");
    strcat(HTML_String, "<td><button style= \"width:120px\" name=\"ACTION\" value=\"");
    strcati(HTML_String, ACTION_SET_DataTransfVia);
    strcat(HTML_String, "\">Apply and Save</button></td>");
    strcat(HTML_String, "</tr>");

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td>WiFi UDP</td><td><input type = \"radio\" name=\"DataTransfVia\" id=\"JZ\" value=\"7\"");
    if (Set.DataTransVia == 7)strcat(HTML_String, " CHECKED");
    strcat(HTML_String, "><label for=\"JZ\">(default)</label></td></tr>");

    strcat(HTML_String, "</table>");
    strcat(HTML_String, "</form>");
    strcat(HTML_String, "<br><hr>");

    //---------------------------------------------------------------------------------------------  
// Version number

    strcat(HTML_String, "<h2>AOG version number</h2>");

    strcat(HTML_String, "<form>");
    strcat(HTML_String, "<table>");
    set_colgroup(300, 250, 150, 0, 0);

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td>for V4.3.10 use 17<br>for V4.6 use 20</td><td><input type = \"number\"  name = \"aogVers\" min = \" 1\" max = \"99\" step = \"1\" style= \"width:100px\" value = \"");// placeholder = \"");
    strcati(HTML_String, Set.aogVersion);
    strcat(HTML_String, "\"></td>");
    strcat(HTML_String, "<td><button style= \"width:120px\" name=\"ACTION\" value=\"");
    strcati(HTML_String, ACTION_SET_aogVers);
    strcat(HTML_String, "\">Apply and Save</button></td>");
    strcat(HTML_String, "</tr>");
    strcat(HTML_String, "</table></form><br><hr>");

 /*   //---------------------------------------------------------------------------------------------  
    // WiFi LED light on high/low 
    strcat(HTML_String, "<h2>WiFi LED light on</h2>");
    strcat(HTML_String, "<form>");
    strcat(HTML_String, "<table>");
    set_colgroup(150, 270, 150, 0, 0);

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td></td><td><input type = \"radio\" name=\"WiFiLEDon\" id=\"JZ\" value=\"0\"");
    if (Set.LEDWiFi_ON_Level == 0)strcat(HTML_String, " CHECKED");
    strcat(HTML_String, "><label for=\"JZ\">LOW</label></td>");
    strcat(HTML_String, "<td><button style= \"width:120px\" name=\"ACTION\" value=\"");
    strcati(HTML_String, ACTION_SET_WiFiLEDon);
    strcat(HTML_String, "\">Apply and Save</button></td>");
    strcat(HTML_String, "</tr>");

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td></td><td><input type = \"radio\" name=\"WiFiLEDon\" id=\"JZ\" value=\"1\"");
    if (Set.LEDWiFi_ON_Level == 1)strcat(HTML_String, " CHECKED");
    strcat(HTML_String, "><label for=\"JZ\">HIGH</label></td></tr>");

    strcat(HTML_String, "</table>");
    strcat(HTML_String, "</form>");
    strcat(HTML_String, "<br><hr>");
    */
    //---------------------------------------------------------------------------------------------  
    // Number of sections

    strcat(HTML_String, "<h2>Number of sections</h2>");

    strcat(HTML_String, "<form>");
    strcat(HTML_String, "<table>");
    set_colgroup(300, 250, 150, 0, 0);

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td></td><td><input type = \"number\"  name = \"SectNum\" min = \" 1\" max = \"16\" step = \"1\" style= \"width:100px\" value = \"");// placeholder = \"");
    strcati(HTML_String, Set.SectNum);
    strcat(HTML_String, "\"></td>");
    strcat(HTML_String, "<td><button style= \"width:120px\" name=\"ACTION\" value=\"");
    strcati(HTML_String, ACTION_SET_SectNum);
    strcat(HTML_String, "\">Apply and Save</button></td>");
    strcat(HTML_String, "</tr>");
    strcat(HTML_String, "</table></form><br><hr>");


    //---------------------------------------------------------------------------------------------  
    // Checkboxes IO functions
    strcat(HTML_String, "<h2>Section control uses</h2>");
    strcat(HTML_String, "<form>");
    strcat(HTML_String, "<table>");
    set_colgroup(300, 50, 200, 150, 0);

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td></td><td colspan=\"2\"><input type=\"checkbox\" name=\"useRel\" id = \"funct\" value = \"1\" ");
    if (Set.SectRelaysInst == 1) strcat(HTML_String, "checked ");
    strcat(HTML_String, "> ");
    strcat(HTML_String, "<label for =\"funct\">Relay output</label>");
    strcat(HTML_String, "</td>");
    strcat(HTML_String, "<td><button style= \"width:120px\" name=\"ACTION\" value=\"");
    strcati(HTML_String, ACTION_SET_IOFunctions);
    strcat(HTML_String, "\">Apply and Save</button></td>");

    if (Set.SectRelaysInst == 1) {
        //strcat(HTML_String, "<tr><td colspan=\"2\"></td></tr>");
        strcat(HTML_String, "<tr><td>Relays spray on</td><td></td><td><input type = \"radio\" name=\"RelaySprayOn\" id=\"JZ\" value=\"0\"");
        if (Set.SectRelaysON == 0)strcat(HTML_String, " CHECKED");
        strcat(HTML_String, "><label for=\"JZ\">LOW</label></td>");
        strcat(HTML_String, "</tr>");
        strcat(HTML_String, "<tr>");
        strcat(HTML_String, "<td></td><td></td><td><input type = \"radio\" name=\"RelaySprayOn\" id=\"JZ\" value=\"1\"");
        if (Set.SectRelaysON == 1)strcat(HTML_String, " CHECKED");
        strcat(HTML_String, "><label for=\"JZ\">HIGH</label></td></tr>");
        strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");
    }

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td></td><td colspan=\"2\"><input type=\"checkbox\" name=\"useSw\" id = \"MSw\" value = \"1\" ");
    if (Set.SectSWInst == 1) strcat(HTML_String, "checked ");
    strcat(HTML_String, "> ");
    strcat(HTML_String, "<label for =\"MSw\">Switches for Sections</label>");
    strcat(HTML_String, "</td></tr>");
    strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");

    if (Set.SectSWInst == 1) {
        strcat(HTML_String, "<tr><td colspan=\"4\">Use as section control,<br>or documentation = AgOpenGPS writes status of input switches.</td></tr>");
        strcat(HTML_String, "<tr>");
        strcat(HTML_String, "<td></td><td colspan=\"2\"><input type=\"checkbox\" name=\"DocOnly\" id = \"DO\" value = \"1\"");
        if (Set.DocOnly == 1) strcat(HTML_String, " CHECKED");
        strcat(HTML_String, "> ");
        strcat(HTML_String, "<label for =\"DO\">Documentation only</label>");
        strcat(HTML_String, "</td></tr>");
        if (Set.DocOnly) {
            strcat(HTML_String, "<tr><td>Switches spray on</td><td></td><td><input type = \"radio\" name=\"DocSWspr\" id=\"DoSW\" value=\"0\"");
            if (Set.SectSWAutoOrOn == 0)strcat(HTML_String, " CHECKED");
            strcat(HTML_String, "><label for=\"DoSW\">LOW</label></td>");
            strcat(HTML_String, "</tr>");
            strcat(HTML_String, "<tr>");
            strcat(HTML_String, "<td></td><td></td><td><input type = \"radio\" name=\"DocSWspr\" id=\"DoSW\" value=\"1\"");
            if (Set.SectSWAutoOrOn == 1)strcat(HTML_String, " CHECKED");
            strcat(HTML_String, "><label for=\"DoSW\">HIGH</label></td></tr>");


        }        
        strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");
    }

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td></td><td colspan=\"3\"><input type=\"checkbox\" name=\"useRCSw\" id = \"RCS\" value = \"1\" ");
    if (Set.RateControlLeftInst == 1) strcat(HTML_String, "checked ");
    strcat(HTML_String, "> ");
    strcat(HTML_String, "<label for =\"RCS\">Rate Control Switch only for +/- Motor valve</label>");
    strcat(HTML_String, "</td></tr>");

    //Main SW
    strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");
    strcat(HTML_String, "<tr><td><b>Main switch for section control</b></td>");
    strcat(HTML_String, "<td colspan=\"3\"><input type = \"radio\" name=\"MSw\" id=\"MS\" value=\"0\"");
    if (Set.SectMainSWType == 0)strcat(HTML_String, " CHECKED");
    strcat(HTML_String, "><label for=\"MS\">none</label></td></tr>");

    strcat(HTML_String, "<tr><td></td>");
    strcat(HTML_String, "<td colspan=\"3\"><input type = \"radio\" name=\"MSw\" id=\"MS\" value=\"1\"");
    if (Set.SectMainSWType == 1)strcat(HTML_String, " CHECKED");
    strcat(HTML_String, "><label for=\"MS\">(ON)-OFF-(ON) toggle switch or push buttons</label></td></tr>");

    strcat(HTML_String, "<tr><td></td>");
    strcat(HTML_String, "<td colspan=\"3\"><input type = \"radio\" name=\"MSw\" id=\"MS\" value=\"2\"");
    if (Set.SectMainSWType == 2)strcat(HTML_String, " CHECKED");
    strcat(HTML_String, "><label for=\"MS\">connected to hitch level sensor</label></td></tr>");

    strcat(HTML_String, "<tr><td></td>");
    strcat(HTML_String, "<td colspan=\"3\"><input type = \"radio\" name=\"MSw\" id=\"MS\" value=\"3\"");
    if (Set.SectMainSWType == 3)strcat(HTML_String, " CHECKED");
    strcat(HTML_String, "><label for=\"MS\">inverted hitch level sensor</label></td></tr>");
    
    //analog MAIN SW from hitch level
    if (Set.SectMainSWType > 1) {
        strcat(HTML_String, "<tr>");
        strcat(HTML_String, "<td><br>Analog Main Section control Threshold value</td>");
        strcat(HTML_String, "<td><divbox align=\"right\"><font size=\"+2\"><b>");
        strcati(HTML_String, (Set.HitchLevelVal));
        strcat(HTML_String, "</b></font></divbox></td><td>0-4095</td>");

        strcat(HTML_String, "<tr>");
        strcat(HTML_String, "<td><b>Set Threshold</b></td>");
        strcat(HTML_String, "<td><button style= \"width:120px\" name=\"ACTION\" value=\"");
        strcati(HTML_String, ACTION_SET_THRESHOLD);
        strcat(HTML_String, "\">Use Current</button></td>");
        strcat(HTML_String, "<td colspan=\"2\">Set Threshold value to current position</td></tr>");
    }
    strcat(HTML_String, "</table>");
    strcat(HTML_String, "</form>");
    strcat(HTML_String, "<br><hr>");

    //-------------------------------------------------------------
  // Checkboxes debugmode
    strcat(HTML_String, "<h2>Debugmode</h2>");
    strcat(HTML_String, "<form>");
    strcat(HTML_String, "<table>");
    set_colgroup(300, 250, 150, 0, 0);

    strcat(HTML_String, "<tr> <td colspan=\"2\">debugmode sends messages to USB serial</td>");
    strcat(HTML_String, "<td><button style= \"width:120px\" name=\"ACTION\" value=\"");
    strcati(HTML_String, ACTION_SET_debugmode);
    strcat(HTML_String, "\">Apply and Save</button></td></tr>");

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td colspan=\"2\"><input type=\"checkbox\" name=\"debugmode\" id = \"Part\" value = \"1\" ");
    if (Set.debugmode == 1) strcat(HTML_String, "checked ");
    strcat(HTML_String, "> ");
    strcat(HTML_String, "<label for =\"Part\"> debugmode on</label>");
    strcat(HTML_String, "</td></tr>");

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td colspan=\"3\"><input type=\"checkbox\" name=\"debugmRel\" id = \"Part\" value = \"1\" ");
    if (Set.debugmodeRelay == 1) strcat(HTML_String, "checked ");
    strcat(HTML_String, "> ");
    strcat(HTML_String, "<label for =\"Part\"> debugmode Relais</label>");
    strcat(HTML_String, "</td></tr>");

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td colspan=\"3\"><input type=\"checkbox\" name=\"debugmSw\" id = \"Part\" value = \"1\" ");
    if (Set.debugmodeSwitches == 1) strcat(HTML_String, "checked ");
    strcat(HTML_String, "> ");
    strcat(HTML_String, "<label for =\"Part\"> debugmode Switches</label>");
    strcat(HTML_String, "</td></tr>");

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td colspan=\"3\"><input type=\"checkbox\" name=\"debugmDatToAOG\" id = \"Part\" value = \"1\" ");
    if (Set.debugmodeDataToAOG == 1) strcat(HTML_String, "checked ");
    strcat(HTML_String, "> ");
    strcat(HTML_String, "<label for =\"Part\"> debugmode Data to AgOpenGPS</label>");
    strcat(HTML_String, "</td></tr>");

    strcat(HTML_String, "<tr>");
    strcat(HTML_String, "<td colspan=\"3\"><input type=\"checkbox\" name=\"debugmDatFrAOG\" id = \"Part\" value = \"1\" ");
    if (Set.debugmodeDataFromAOG == 1) strcat(HTML_String, "checked ");
    strcat(HTML_String, "> ");
    strcat(HTML_String, "<label for =\"Part\"> debugmode Data from AgOpenGPS</label>");
    strcat(HTML_String, "</td></tr>");

    strcat(HTML_String, "</table>");
    strcat(HTML_String, "</form>");
    strcat(HTML_String, "<br><hr>");

/*
    //---------------------------------------------------------------------------------------------  
    // Relay PINs selection

    //ESP crashes sometimes, when GPIOs are changed, Nano33iot: not enough memory HTML string lenght: 60000
    if (Set.SectRelaysEquiped) {
        strcat(HTML_String, "<h2>Relay pin setting</h2>");
        strcat(HTML_String, "<br>");

        strcat(HTML_String, "<form>");
        strcat(HTML_String, "<table><col width=\"50\"><col width=\"50\"><col width=\"50\"><col width=\"50\"><col width=\"50\"><col width=\"50\"><col width=\"50\"><col width=\"50\"><col width=\"50\">");
        strcat(HTML_String, "<col width = \"50\"><col width=\"50\"><col width=\"50\"><col width=\"50\"><col width=\"50\"><col width=\"50\"><col width=\"50\"><col width=\"50\">");

        strcat(HTML_String, "<tr><td colspan=\"11\"><b>select for every section relay a GPIO pin</b></td>");
        strcat(HTML_String, "<td colspan=\"3\"><button style= \"width:120px\" name=\"ACTION\" value=\"");
        strcati(HTML_String, ACTION_SET_GPIO);
        strcat(HTML_String, "\">Apply and Save</button></td></tr>");
        strcat(HTML_String, "<tr><td colspan=\"17\"><b>!! NO check, if pin is selected twice!!  Use every pin only 1 time !!</b></td>");
        strcat(HTML_String, "<tr> <td colspan=\"17\">&nbsp;</td> </tr>");

        strcat(HTML_String, "<tr><td></td><td></td><td colspan=\"6\"><b>section #</b></td>");
        strcat(HTML_String, "</tr><tr><td></td>");
        byte num = 0;
        for (num = 0; num < Set.SectNum; num++) {
            strcat(HTML_String, "<td align=center><b>");
            strcati(HTML_String, (num + 1));
            strcat(HTML_String, "</b></td>");
        }
        strcat(HTML_String, "</tr>");

        strcat(HTML_String, "<tr><td><b>GPIO</b></td>");
        for (num = 0; num < Set.SectNum; num++) {//colums            
            strcat(HTML_String, "<td><input type = \"radio\" name=\"RP");
            strcati(HTML_String, num);
            strcat(HTML_String, "\" id=\"Rel");
            strcati(HTML_String, num);
            strcat(HTML_String, "\" value=\"255\"");
            if (Set.Relay_PIN[num] == 255) { strcat(HTML_String, " CHECKED"); }
            strcat(HTML_String, "><label for=\"Rel");
            strcati(HTML_String, num);
            strcat(HTML_String, "\">nc</label></td>");
        }
        strcat(HTML_String, "</tr>");


        for (int io = 2; io < 40; io++) {//rows
            //skip not usabel GPIOs
            if (io == 3) { io++; } //3: 6-11: not use! USB 12: ESP wouldn't boot
            if (io == 6) { io = 13; }

            strcat(HTML_String, "<tr><td>pin #</td>");
            num = 0;
            for (num = 0; num < Set.SectNum; num++) {//colums            
                strcat(HTML_String, "<td><input type = \"radio\" name=\"RP");
                strcati(HTML_String, num);
                strcat(HTML_String, "\" id=\"R");
                strcati(HTML_String, num);
                strcat(HTML_String, "\" value=\"");
                strcati(HTML_String, io);
                strcat(HTML_String, "\"");
                if (Set.Relay_PIN[num] == io) { strcat(HTML_String, " CHECKED"); }
                strcat(HTML_String, "><label for=\"R");
                strcati(HTML_String, num);
                strcat(HTML_String, "\">");
                strcati(HTML_String, io);
                strcat(HTML_String, "</label></td>");
            }
            strcat(HTML_String, "</tr>");
        }
        strcat(HTML_String, "</table>");
        strcat(HTML_String, "</form>");
    }*/
}
//--------------------------------------------------------------------------
void send_not_found() {

	Serial.print("\nSend Not Found\n");

	client_page.print("HTTP/1.1 404 Not Found\r\n\r\n");
	delay(20);
	//client_page.stop();
}

//--------------------------------------------------------------------------
void send_HTML() {
	char my_char;
	int  my_len = strlen(HTML_String);
	int  my_ptr = 0;
	int  my_send = 0;

	//--------------------------------------------------------------------------
	// in Portionen senden
	while ((my_len - my_send) > 0) {
		my_send = my_ptr + MAX_PACKAGE_SIZE;
		if (my_send > my_len) {
			client_page.print(&HTML_String[my_ptr]);
			delay(10);

			//Serial.println(&HTML_String[my_ptr]);

			my_send = my_len;
		}
		else {
			my_char = HTML_String[my_send];
			// Auf Anfang eines Tags positionieren
			while (my_char != '<') my_char = HTML_String[--my_send];
			HTML_String[my_send] = 0;
			client_page.print(&HTML_String[my_ptr]);
			delay(10);

			//Serial.println(&HTML_String[my_ptr]);

			HTML_String[my_send] = my_char;
			my_ptr = my_send;
		}
	}
	//client_page.stop();
}

//----------------------------------------------------------------------------------------------
void set_colgroup(int w1, int w2, int w3, int w4, int w5) {
	strcat(HTML_String, "<colgroup>");
	set_colgroup1(w1);
	set_colgroup1(w2);
	set_colgroup1(w3);
	set_colgroup1(w4);
	set_colgroup1(w5);
	strcat(HTML_String, "</colgroup>");

}
//------------------------------------------------------------------------------------------
void set_colgroup1(int ww) {
	if (ww == 0) return;
	strcat(HTML_String, "<col width=\"");
	strcati(HTML_String, ww);
	strcat(HTML_String, "\">");
}


//---------------------------------------------------------------------
void strcatf(char* tx, float f, byte leng, byte dezim) {
	char tmp[8];

//	dtostrf(f, leng, dezim, tmp);//f,6,2,tmp
	strcat(tx, tmp);
}
//---------------------------------------------------------------------
//void strcatl(char* tx, long l) {
  //char tmp[sizeof l];
  //memcpy(tmp, l, sizeof l);
  //strcat (tx, tmp);
//}

//---------------------------------------------------------------------
void strcati(char* tx, int i) {
	char tmp[8];

	itoa(i, tmp, 10);
	strcat(tx, tmp);
}

//---------------------------------------------------------------------
void strcati2(char* tx, int i) {
	char tmp[8];

	itoa(i, tmp, 10);
	if (strlen(tmp) < 2) strcat(tx, "0");
	strcat(tx, tmp);
}

//---------------------------------------------------------------------
int Pick_Parameter_Zahl(const char* par, char* str) {
	int myIdx = Find_End(par, str);

	if (myIdx >= 0) return  Pick_Dec(str, myIdx);
	else return -1;
}
//---------------------------------------------------------------------
int Find_End(const char* such, const char* str) {
	int tmp = Find_Start(such, str);
	if (tmp >= 0)tmp += strlen(such);
	return tmp;
}

//---------------------------------------------------------------------
int Find_Start(const char* such, const char* str) {
	int tmp = -1;
	int ww = strlen(str) - strlen(such);
	int ll = strlen(such);

	for (int i = 0; i <= ww && tmp == -1; i++) {
		if (strncmp(such, &str[i], ll) == 0) tmp = i;
	}
	return tmp;
}
//---------------------------------------------------------------------
int Pick_Dec(const char* tx, int idx) {
	int tmp = 0;

	for (int p = idx; p < idx + 5 && (tx[p] >= '0' && tx[p] <= '9'); p++) {
		tmp = 10 * tmp + tx[p] - '0';
	}
	return tmp;
}
//----------------------------------------------------------------------------
int Pick_N_Zahl(const char* tx, char separator, byte n) {//never used?

	int ll = strlen(tx);
	int tmp = -1;
	byte anz = 1;
	byte i = 0;
	while (i < ll && anz < n) {
		if (tx[i] == separator)anz++;
		i++;
	}
	if (i < ll) return Pick_Dec(tx, i);
	else return -1;
}

//---------------------------------------------------------------------
int Pick_Hex(const char* tx, int idx) {
	int tmp = 0;

	for (int p = idx; p < idx + 5 && ((tx[p] >= '0' && tx[p] <= '9') || (tx[p] >= 'A' && tx[p] <= 'F')); p++) {
		if (tx[p] <= '9')tmp = 16 * tmp + tx[p] - '0';
		else tmp = 16 * tmp + tx[p] - 55;
	}

	return tmp;
}

//---------------------------------------------------------------------
void Pick_Text(char* tx_ziel, char* tx_quelle, int max_ziel) {

	int p_ziel = 0;
	int p_quelle = 0;
	int len_quelle = strlen(tx_quelle);

	while (p_ziel < max_ziel && p_quelle < len_quelle && tx_quelle[p_quelle] && tx_quelle[p_quelle] != ' ' && tx_quelle[p_quelle] != '&') {
		if (tx_quelle[p_quelle] == '%') {
			tx_ziel[p_ziel] = (HexChar_to_NumChar(tx_quelle[p_quelle + 1]) << 4) + HexChar_to_NumChar(tx_quelle[p_quelle + 2]);
			p_quelle += 2;
		}
		else if (tx_quelle[p_quelle] == '+') {
			tx_ziel[p_ziel] = ' ';
		}
		else {
			tx_ziel[p_ziel] = tx_quelle[p_quelle];
		}
		p_ziel++;
		p_quelle++;
	}

	tx_ziel[p_ziel] = 0;
}
//---------------------------------------------------------------------
char HexChar_to_NumChar(char c) {
	if (c >= '0' && c <= '9') return c - '0';
	if (c >= 'A' && c <= 'F') return c - 55;
	return 0;
}
//---------------------------------------------------------------------
void exhibit(const char* tx, int v) {
	Serial.print(tx);
	Serial.print(v, 1);
}
//---------------------------------------------------------------------
void exhibit(const char* tx, unsigned int v) {
	Serial.print(tx);
	Serial.print((int)v, 1);
}
//---------------------------------------------------------------------
void exhibit(const char* tx, unsigned long v) {
	Serial.print(tx);
	Serial.print((long)v, 1);
}
//---------------------------------------------------------------------
void exhibit(const char* tx, const char* v) {
	Serial.print(tx);
	Serial.print(v);
}
