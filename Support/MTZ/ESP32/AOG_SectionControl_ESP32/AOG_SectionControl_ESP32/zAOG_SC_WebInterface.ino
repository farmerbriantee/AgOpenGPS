
// Wifi variables & definitions
char HTML_String[22000];
int action;
long temLong = 0;
double temDoub = 0;

#define ACTION_LoadDefaultVal   1
#define ACTION_RESTART          2
#define ACTION_SET_WS_THRESHOLD 3




//-------------------------------------------------------------------------------------------------
//7. Maerz 2021

void doWebinterface(void* pvParameters) {
	for (;;){
		WiFi_Server.handleClient(); //does the Webinterface
		if (WebIOTimeOut < millis() + long((Set.timeoutWebIO * 60000)) - 3000) {//not called in the last 10 sec
			vTaskDelay(1500);
		}
		else {
			vTaskDelay(100);
		}
		if ((now > WebIOTimeOut) && (Set.timeoutWebIO != 255)) {
			WebIORunning = false;
			WiFi_Server.close();
			Serial.println("closing Webinterface task");
			delay(1);
			vTaskDelete(NULL);
			delay(1);
		}
	}
}

//-------------------------------------------------------------------------------------------------
//7. Maerz 2021

void handleRoot() {
	make_HTML01();
	WiFi_Server.sendHeader("Connection", "close");
	WiFi_Server.send(200, "text/html", HTML_String);
	WebIOTimeOut = millis() + long((Set.timeoutWebIO * 60000));
	if (Set.debugmode) {
		Serial.println("Webpage root"); Serial.print("Timeout WebIO: "); Serial.println(WebIOTimeOut);
	}
	process_Request();
}

//-------------------------------------------------------------------------------------------------
//7. Maerz 2021

void WiFiStartServer() {	

	WiFi_Server.on("/", HTTP_GET, []() {handleRoot(); });

	//file selection for firmware update
	WiFi_Server.on("/serverIndex", HTTP_GET, []() {
		WiFi_Server.sendHeader("Connection", "close");
		WiFi_Server.send(200, "text/html", serverIndex);
		});
	//handling uploading firmware file 
	WiFi_Server.on("/update", HTTP_POST, []() {
		WiFi_Server.sendHeader("Connection", "close");
		WiFi_Server.send(200, "text/plain", (Update.hasError()) ? "FAIL" : "OK");
		ESP.restart();
		}, []() {
			HTTPUpload& upload = WiFi_Server.upload();
			if (upload.status == UPLOAD_FILE_START) {
				Serial.printf("Update: %s\n", upload.filename.c_str());
				if (!Update.begin(UPDATE_SIZE_UNKNOWN)) { //start with max available size
					Update.printError(Serial);
				}
			}
			else if (upload.status == UPLOAD_FILE_WRITE) {
				// flashing firmware to ESP
				if (Update.write(upload.buf, upload.currentSize) != upload.currentSize) {
					Update.printError(Serial);
				}
			}
			else if (upload.status == UPLOAD_FILE_END) {
				if (Update.end(true)) { //true to set the size to the current progress
					Serial.printf("Update Success: %u\nRebooting...\n", upload.totalSize);
				}
				else {
					Update.printError(Serial);
				}
			}
		});
	WiFi_Server.onNotFound(handleNotFound);

	WiFi_Server.begin();
}

//---------------------------------------------------------------------
// Process given values 10. Mai 2020
//---------------------------------------------------------------------
void process_Request()
{
	int temInt = 0;
	action = 0;
	if (Set.debugmode) { Serial.print("From webinterface: number of arguments: "); Serial.println(WiFi_Server.args()); }
	for (byte n = 0; n < WiFi_Server.args(); n++) {
		if (Set.debugmode) {
			Serial.print("argName "); Serial.print(WiFi_Server.argName(n));
			Serial.print(" val: "); Serial.println(WiFi_Server.arg(n));
		}
		if (WiFi_Server.argName(n) == "ACTION") {
			action = int(WiFi_Server.arg(n).toInt());
			if (Set.debugmode) { Serial.print("Action found: "); Serial.println(action); }
			if (action != ACTION_RESTART) { EEprom_unblock_restart(); }
			if (action == ACTION_LoadDefaultVal) {
				if (Set.debugmode) { Serial.println("load default settings from EEPROM"); }
				EEprom_read_default();
				delay(2);
			}
			if (action == ACTION_SET_WS_THRESHOLD) {
				unsigned int WSThres_avg = 0;
				for (int i = 0; i < 8; i++) {
					WSThres_avg += analogRead(Set.SectMainSW_PIN);
					delay(100);
				}
				Set.HitchLevelVal = WSThres_avg >> 3;
				EEprom_write_all();
			}
			if (action == ACTION_RESTART) {
				Serial.println("reboot ESP32: selected by webinterface");
				EEprom_block_restart();//prevents from restarting, when webpage is reloaded. Is set to 0, when other ACTION than restart is called
				delay(1000);
				WiFi.disconnect();
				delay(500);
				ESP.restart();
			}
		}
		//save changes
		if (WiFi_Server.argName(n) == "Save") {
			if (Set.debugmode) { Serial.println("Save button pressed in webinterface"); }
			EEprom_write_all();
		}
		if (WiFi_Server.argName(n) == "SSID_MY1") {
			for (int i = 0; i < 24; i++) Set.ssid1[i] = 0x00;
			temInt = WiFi_Server.arg(n).length() + 1;
			WiFi_Server.arg(n).toCharArray(Set.ssid1, temInt);
		}
		if (WiFi_Server.argName(n) == "Password_MY1") {
			for (int i = 0; i < 24; i++) Set.password1[i] = 0x00;
			temInt = WiFi_Server.arg(n).length() + 1;
			WiFi_Server.arg(n).toCharArray(Set.password1, temInt);
		}
		if (WiFi_Server.argName(n) == "SSID_MY2") {
			for (int i = 0; i < 24; i++) Set.ssid2[i] = 0x00;
			temInt = WiFi_Server.arg(n).length() + 1;
			WiFi_Server.arg(n).toCharArray(Set.ssid2, temInt);
		}
		if (WiFi_Server.argName(n) == "Password_MY2") {
			for (int i = 0; i < 24; i++) Set.password2[i] = 0x00;
			temInt = WiFi_Server.arg(n).length() + 1;
			WiFi_Server.arg(n).toCharArray(Set.password2, temInt);
		}
		if (WiFi_Server.argName(n) == "SSID_MY3") {
			for (int i = 0; i < 24; i++) Set.ssid3[i] = 0x00;
			temInt = WiFi_Server.arg(n).length() + 1;
			WiFi_Server.arg(n).toCharArray(Set.ssid3, temInt);
		}
		if (WiFi_Server.argName(n) == "Password_MY3") {
			for (int i = 0; i < 24; i++) Set.password3[i] = 0x00;
			temInt = WiFi_Server.arg(n).length() + 1;
			WiFi_Server.arg(n).toCharArray(Set.password3, temInt);
		}
		if (WiFi_Server.argName(n) == "SSID_MY4") {
			for (int i = 0; i < 24; i++) Set.ssid4[i] = 0x00;
			temInt = WiFi_Server.arg(n).length() + 1;
			WiFi_Server.arg(n).toCharArray(Set.ssid4, temInt);
		}
		if (WiFi_Server.argName(n) == "Password_MY4") {
			for (int i = 0; i < 24; i++) Set.password4[i] = 0x00;
			temInt = WiFi_Server.arg(n).length() + 1;
			WiFi_Server.arg(n).toCharArray(Set.password4, temInt);
		}
		if (WiFi_Server.argName(n) == "SSID_MY5") {
			for (int i = 0; i < 24; i++) Set.ssid5[i] = 0x00;
			temInt = WiFi_Server.arg(n).length() + 1;
			WiFi_Server.arg(n).toCharArray(Set.ssid5, temInt);
		}
		if (WiFi_Server.argName(n) == "Password_MY5") {
			for (int i = 0; i < 24; i++) Set.password5[i] = 0x00;
			temInt = WiFi_Server.arg(n).length() + 1;
			WiFi_Server.arg(n).toCharArray(Set.password5, temInt);
		}
		if (WiFi_Server.argName(n) == "timeoutRout") {
			argVal = WiFi_Server.arg(n).toInt();
			if ((argVal >= 20) && (argVal <= 200)) { Set.timeoutRouter = byte(argVal); }
		}
		if (WiFi_Server.argName(n) == "timeoutWebIO") {
			temLong = WiFi_Server.arg(n).toInt();
			if ((temLong >= 2) && (temLong <= 255)) { Set.timeoutWebIO = byte(temLong); }
		}
		if (WiFi_Server.argName(n) == "WiFiIP0") {
			temInt = WiFi_Server.arg(n).toInt();
			Set.WiFi_myip[0] = byte(temInt);
		}
		if (WiFi_Server.argName(n) == "WiFiIP1") {
			temInt = WiFi_Server.arg(n).toInt();
			Set.WiFi_myip[1] = byte(temInt);
		}
		if (WiFi_Server.argName(n) == "WiFiIP2") {
			temInt = WiFi_Server.arg(n).toInt();
			Set.WiFi_myip[2] = byte(temInt);
		}
		if (WiFi_Server.argName(n) == "WiFiIP3") {
			temInt = WiFi_Server.arg(n).toInt();
			Set.WiFi_myip[3] = byte(temInt);
		}
		if (WiFi_Server.argName(n) == "WiFiIPDest") {
			temInt = WiFi_Server.arg(n).toInt();
			Set.WiFi_ipDest_ending = byte(temInt);
		}
		if (WiFi_Server.argName(n) == "EthIP0") {
			temInt = WiFi_Server.arg(n).toInt();
			Set.Eth_myip[0] = byte(temInt);
		}
		if (WiFi_Server.argName(n) == "EthIP1") {
			temInt = WiFi_Server.arg(n).toInt();
			Set.Eth_myip[1] = byte(temInt);
		}
		if (WiFi_Server.argName(n) == "EthIP2") {
			temInt = WiFi_Server.arg(n).toInt();
			Set.Eth_myip[2] = byte(temInt);
		}
		if (WiFi_Server.argName(n) == "EthIP3") {
			temInt = WiFi_Server.arg(n).toInt();
			Set.Eth_myip[3] = byte(temInt);
		}
		if (WiFi_Server.argName(n) == "EthStatIP") {
			temInt = WiFi_Server.arg(n).toInt();
			if (temInt == 1) { Set.Eth_static_IP = true; }
			else { Set.Eth_static_IP = false; }
		}
		if (WiFi_Server.argName(n) == "EthIPDest") {
			temInt = WiFi_Server.arg(n).toInt();
			Set.Eth_ipDest_ending = byte(temInt);
		}
		if (WiFi_Server.argName(n) == "EthMac0") {
			temInt = WiFi_Server.arg(n).toInt();
			Set.Eth_mac[0] = byte(temInt);
		}
		if (WiFi_Server.argName(n) == "EthMac1") {
			temInt = WiFi_Server.arg(n).toInt();
			Set.Eth_mac[1] = byte(temInt);
		}
		if (WiFi_Server.argName(n) == "EthMac2") {
			temInt = WiFi_Server.arg(n).toInt();
			Set.Eth_mac[2] = byte(temInt);
		}
		if (WiFi_Server.argName(n) == "EthMac3") {
			temInt = WiFi_Server.arg(n).toInt();
			Set.Eth_mac[3] = byte(temInt);
		}
		if (WiFi_Server.argName(n) == "EthMac4") {
			temInt = WiFi_Server.arg(n).toInt();
			Set.Eth_mac[4] = byte(temInt);
		}
		if (WiFi_Server.argName(n) == "EthMac5") {
			temInt = WiFi_Server.arg(n).toInt();
			Set.Eth_mac[5] = byte(temInt);
		}

		if (WiFi_Server.argName(n) == "DataTransfVia") {
			temLong = WiFi_Server.arg(n).toInt();
			if ((temLong <= 20) && (temLong >= 0)) { Set.DataTransVia = byte(temLong); }
			if (Set.DataTransVia == 10) {
				if (Eth_connect_step == 255) {
					Eth_connect_step = 10;
					xTaskCreate(Eth_handle_connection, "Core1EthConnectHandle", 3072, NULL, 1, &taskHandle_Eth_connect);
					delay(500);
				}
			}
			if (Set.DataTransVia < 5) {//USB
				if (!USBDataTaskRunning) {
					xTaskCreate(getDataFromAOGUSB, "DataFromAOGHandleUSB", 5000, NULL, 1, &taskHandle_DataFromAOGUSB);
					delay(500);
				}
				if (WiFiDataTaskRunning) { vTaskDelete(taskHandle_DataFromAOGWiFi); delay(5); WiFiDataTaskRunning = false; }
				if (EthDataTaskRunning) { vTaskDelete(taskHandle_DataFromAOGEth); delay(5); EthDataTaskRunning = false; }
			}
			else {
				if (Set.DataTransVia < 10) {//WiFi UDP
					if (!WiFiDataTaskRunning) {
						xTaskCreate(getDataFromAOGWiFi, "DataFromAOGHandleWiFi", 5000, NULL, 1, &taskHandle_DataFromAOGWiFi);
						delay(500);
					}
					if (USBDataTaskRunning) { vTaskDelete(taskHandle_DataFromAOGUSB); delay(5); USBDataTaskRunning = false; }
					if (EthDataTaskRunning) { vTaskDelete(taskHandle_DataFromAOGEth); delay(5); EthDataTaskRunning = false;	}
				}
				else {
					if (Set.DataTransVia == 10) {//Ethernet UDP
						if (!EthDataTaskRunning) {
							xTaskCreate(getDataFromAOGEth, "DataFromAOGHandleEth", 5000, NULL, 1, &taskHandle_DataFromAOGEth);
						delay(500);
						}
						if (WiFiDataTaskRunning) { vTaskDelete(taskHandle_DataFromAOGWiFi); delay(5); WiFiDataTaskRunning = false;}
						if (USBDataTaskRunning) { vTaskDelete(taskHandle_DataFromAOGUSB); delay(5); USBDataTaskRunning = false;	}
					}
				}
			}			
		}
					
		if (WiFi_Server.argName(n) == "aogVer") {
			argVal = WiFi_Server.arg(n).toInt();
			if ((argVal >= 0) && (argVal <= 255)) {
				Set.aogVersion = byte(argVal);
				if (Set.aogVersion == 17) {
					SCToAOG[0] = FromAOGSentenceHeader[2];
					SCToAOGOld[0] = FromAOGSentenceHeader[2];
					SCToAOG[1] = SCDataToAOGHeaderV17;
					SCToAOGOld[1] = SCDataToAOGHeaderV17;
					SCToAOG[2] = 0;
					SCToAOGOld[2] = 0;
					SCToAOG[3] = 0;
					SCToAOGOld[3] = 0;
					SCToAOG[4] = 0;
					SCToAOGOld[4] = 0;
					SCToAOG[5] = 0;
					SCToAOGOld[5] = 0;
					SCToAOG[6] = 0;
					SCToAOGOld[6] = 0;
					DataToAOGLength = SCDataSentenceToAOGLengthV17;
				}
				else {
					SCToAOG[0] = FromAOGSentenceHeader[0];   //0x80
					SCToAOG[1] = FromAOGSentenceHeader[1];   //0x81
					SCToAOG[2] = FromSCHeader;				 //0x7B
					SCToAOG[3] = SCDataToAOGHeader;			 //0xEA
					SCToAOG[4] = SCDataSentenceToAOGLength - 6; //length of data = all - header - length - CRC
					SCToAOGOld[0] = FromAOGSentenceHeader[0];
					SCToAOGOld[1] = FromAOGSentenceHeader[1];
					SCToAOGOld[2] = FromSCHeader;
					SCToAOGOld[3] = SCDataToAOGHeader;
					SCToAOG[4] = SCDataSentenceToAOGLength - 6;
					DataToAOGLength = SCDataSentenceToAOGLength;
				}
			}
		}
		if (WiFi_Server.argName(n) == "SectNum") {
			argVal = WiFi_Server.arg(n).toInt();
			if ((argVal >= 1) && (argVal <= 100)) { Set.SectNum = byte(argVal); }
		}
		if (WiFi_Server.argName(n) == "seRelInst") {
			if (WiFi_Server.arg(n) == "true") { Set.SectRelaysInst = 1; }
			else { Set.SectRelaysInst = 0; }
		}
		if (WiFi_Server.argName(n) == "seRelON") {
			if (WiFi_Server.arg(n) == "1") { Set.SectRelaysON = 1; }
			else { Set.SectRelaysON = 0; }
		}
		if (WiFi_Server.argName(n) == "seSWInst") {
			if (WiFi_Server.arg(n) == "true") { Set.SectSWInst = 1; }
			else { Set.SectSWInst = 0; }
		}
		if (WiFi_Server.argName(n) == "DocOnly") {
			if (WiFi_Server.arg(n) == "true") { Set.DocOnly = 1; }
			else { Set.DocOnly = 0; }
		}
		if (WiFi_Server.argName(n) == "DocSWspr") {
			if (WiFi_Server.arg(n) == "1") { Set.SectSWAutoOrOn = 1; }
			else { Set.SectSWAutoOrOn = 0; }
		}
		if (WiFi_Server.argName(n) == "RCSWInst") {
			if (WiFi_Server.arg(n) == "true") { Set.RateSWLeftInst = 1; }
			else { Set.RateSWLeftInst = 0; }
		}
		if (WiFi_Server.argName(n) == "MainSW") {
			argVal = WiFi_Server.arg(n).toInt();
			if ((argVal >= 0) && (argVal <= 5)) { Set.SectMainSWType = byte(argVal); }
		}
		if (WiFi_Server.argName(n) == "debugmode") {
			if (WiFi_Server.arg(n) == "true") { Set.debugmode = true; }
			else { Set.debugmode = false; }
		}
		if (WiFi_Server.argName(n) == "debugmSW") {
			if (WiFi_Server.arg(n) == "true") { Set.debugmodeSwitches = true; }
			else { Set.debugmodeSwitches = false; }
		}
		if (WiFi_Server.argName(n) == "debugmRel") {
			if (WiFi_Server.arg(n) == "true") { Set.debugmodeRelay = true; }
			else { Set.debugmodeRelay = false; }
		}
		if (WiFi_Server.argName(n) == "debugmDatFromAOG") {
			if (WiFi_Server.arg(n) == "true") { Set.debugmodeDataFromAOG = true; }
			else { Set.debugmodeDataFromAOG = false; }
		}
		if (WiFi_Server.argName(n) == "debugmDatToAOG") {
			if (WiFi_Server.arg(n) == "true") { Set.debugmodeDataToAOG = true; }
			else { Set.debugmodeDataToAOG = false; }
		}
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
	strcat(HTML_String, "Section control software for AgOpenGPS running on ESP32<br>");
	strcat(HTML_String, "supports data via USB / WiFi UDP / Ethernet UDP<br>");
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
	strcat(HTML_String, "<td><input type= \"button\" onclick= \"sendVal('/?ACTION=");
	strcati(HTML_String, ACTION_LoadDefaultVal);
	strcat(HTML_String, "')\" style= \"width:150px\" value=\"Load default values\"></button></td>");
	strcat(HTML_String, "</tr>");
	strcat(HTML_String, "</table></form><br><hr>");

	//-----------------------------------------------------------------------------------------
// WiFi Client Access Data

	strcat(HTML_String, "<h2>WiFi Network Client Access Data</h2>");
	strcat(HTML_String, "<b>Data to access tractor WiFi or mobil phone hotspots.<br>Connections are checked in this order.</b><br><br>");
	strcat(HTML_String, "If access to networks fails, an accesspoint will be created:<br>SSID: <b>");
	strcat(HTML_String, Set.ssid_ap);
	strcat(HTML_String, "</b>     with no password<br><br><table>");
	strcat(HTML_String, "<form>");
	set_colgroup(250, 300, 150, 0, 0);

	strcat(HTML_String, "<tr><td><b>#1 Network SSID:</b></td>");
	strcat(HTML_String, "<td><input type=\"text\" onchange=\"sendVal('/?SSID_MY1='+this.value)\" style= \"width:200px\" name=\"SSID_MY1\" maxlength=\"22\" Value =\"");
	strcat(HTML_String, Set.ssid1);
	strcat(HTML_String, "\"></td>");
	strcat(HTML_String, "<td><input type= \"button\" onclick= \"sendVal('/?Save=true')\" style= \"width:120px\" value=\"Save\"></button></td></tr>");

	strcat(HTML_String, "<tr><td><b>#1 Password:</b></td>");
	strcat(HTML_String, "<td>");
	strcat(HTML_String, "<input type=\"text\" onchange=\"sendVal('/?Password_MY1='+this.value)\" style= \"width:200px\" name=\"Password_MY1\" maxlength=\"22\" Value =\"");
	strcat(HTML_String, Set.password1);
	strcat(HTML_String, "\"></td></tr>");

	strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");

	strcat(HTML_String, "<tr><td><b>#2 Network SSID:</b></td>");
	strcat(HTML_String, "<td><input type=\"text\" onchange=\"sendVal('/?SSID_MY2='+this.value)\" style= \"width:200px\" name=\"SSID_MY2\" maxlength=\"22\" Value =\"");
	strcat(HTML_String, Set.ssid2);
	strcat(HTML_String, "\"></td>");

	strcat(HTML_String, "<tr><td><b>#2 Password:</b></td>");
	strcat(HTML_String, "<td>");
	strcat(HTML_String, "<input type=\"text\" onchange=\"sendVal('/?Password_MY2='+this.value)\" style= \"width:200px\" name=\"Password_MY2\" maxlength=\"22\" Value =\"");
	strcat(HTML_String, Set.password2);
	strcat(HTML_String, "\"></td></tr>");

	strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");

	strcat(HTML_String, "<tr><td><b>#3 Network SSID:</b></td>");
	strcat(HTML_String, "<td><input type=\"text\" onchange=\"sendVal('/?SSID_MY3='+this.value)\" style= \"width:200px\" name=\"SSID_MY3\" maxlength=\"22\" Value =\"");
	strcat(HTML_String, Set.ssid3);
	strcat(HTML_String, "\"></td>");

	strcat(HTML_String, "<tr><td><b>#3 Password:</b></td>");
	strcat(HTML_String, "<td>");
	strcat(HTML_String, "<input type=\"text\" onchange=\"sendVal('/?Password_MY3='+this.value)\" style= \"width:200px\" name=\"Password_MY3\" maxlength=\"22\" Value =\"");
	strcat(HTML_String, Set.password3);
	strcat(HTML_String, "\"></td></tr>");

	strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");

	strcat(HTML_String, "<tr><td><b>#4 Network SSID:</b></td>");
	strcat(HTML_String, "<td><input type=\"text\" onchange=\"sendVal('/?SSID_MY4='+this.value)\" style= \"width:200px\" name=\"SSID_MY4\" maxlength=\"22\" Value =\"");
	strcat(HTML_String, Set.ssid4);
	strcat(HTML_String, "\"></td>");

	strcat(HTML_String, "<tr><td><b>#4 Password:</b></td>");
	strcat(HTML_String, "<td>");
	strcat(HTML_String, "<input type=\"text\" onchange=\"sendVal('/?Password_MY4='+this.value)\" style= \"width:200px\" name=\"Password_MY4\" maxlength=\"22\" Value =\"");
	strcat(HTML_String, Set.password4);
	strcat(HTML_String, "\"></td></tr>");

	strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");

	strcat(HTML_String, "<tr><td><b>#5 Network SSID:</b></td>");
	strcat(HTML_String, "<td><input type=\"text\" onchange=\"sendVal('/?SSID_MY5='+this.value)\" style= \"width:200px\" name=\"SSID_MY5\" maxlength=\"22\" Value =\"");
	strcat(HTML_String, Set.ssid5);
	strcat(HTML_String, "\"></td>");

	strcat(HTML_String, "<tr><td><b>#5 Password:</b></td>");
	strcat(HTML_String, "<td>");
	strcat(HTML_String, "<input type=\"text\" onchange=\"sendVal('/?Password_MY5='+this.value)\" style= \"width:200px\" name=\"Password_MY5\" maxlength=\"22\" Value =\"");
	strcat(HTML_String, Set.password5);
	strcat(HTML_String, "\"></td></tr>");

	strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");

	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td colspan=\"3\">time, trying to connect to networks from list above</td></tr>");
	strcat(HTML_String, "<td colspan=\"3\">after time has passed, access point is opened: <b>");
	strcat(HTML_String, Set.ssid_ap);
	strcat(HTML_String, "</b> with no password</td></tr>");
	strcat(HTML_String, "<tr><td><b>Timeout (s):</b></td><td><input type = \"number\" onchange=\"sendVal('/?timeoutRout='+this.value)\" name = \"timeoutRout\" min = \"20\" max = \"1000\" step = \"1\" style= \"width:200px\" value = \"");// placeholder = \"");
	strcati(HTML_String, Set.timeoutRouter);
	strcat(HTML_String, "\"></td>");
	strcat(HTML_String, "<td><input type= \"button\" onclick= \"sendVal('/?Save=true')\" style= \"width:120px\" value=\"Save\"></button></td>");
	strcat(HTML_String, "</tr>");

	strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");
	strcat(HTML_String, "<tr><td colspan=\"2\"><b>Restart section control unit</b></td>");
	strcat(HTML_String, "<td><input type= \"button\" onclick= \"sendVal('/?ACTION=");
	strcati(HTML_String, ACTION_RESTART);
	strcat(HTML_String, "')\" style= \"width:120px\" value=\"Restart\"></button></td>");
	strcat(HTML_String, "</tr>");

	strcat(HTML_String, "</table>");
	strcat(HTML_String, "</form>");
	strcat(HTML_String, "<br><hr>");

	//-----------------------------------------------------------------------------------------
	// timeout webinterface

	strcat(HTML_String, "<h2>Webinterface timeout</h2>");
	strcat(HTML_String, "<form>");
	strcat(HTML_String, "<b>Webinterface needs lots of calculation time, so if switched off, GPS runs better.</b><br>");
	strcat(HTML_String, "After this time (minutes) from restart, or last usage, webinterface is turned off.<br><br>");
	strcat(HTML_String, "Set to 255 to keep active.<br><br><table>");
	set_colgroup(250, 300, 150, 0, 0);

	strcat(HTML_String, "<tr><td><b>Webinterface timeout (min)</b></td><td><input type = \"number\"  onchange=\"sendVal('/?timeoutWebIO='+this.value)\" name = \"timeoutWebIO\" min = \"2\" max = \"255\" step = \"1\" style= \"width:200px\" value = \"");// placeholder = \"");
	strcati(HTML_String, Set.timeoutWebIO);
	strcat(HTML_String, "\"></td>");

	strcat(HTML_String, "<td><input type= \"button\" onclick= \"sendVal('/?Save=true')\" style= \"width:120px\" value=\"Save\"></button></td>");
	strcat(HTML_String, "</tr>");


	strcat(HTML_String, "</table>");
	strcat(HTML_String, "</form>");
	strcat(HTML_String, "<br><hr>");

	//---------------------------------------------------------------------------------------------  
	// Data transfer via USB/Wifi 
	strcat(HTML_String, "<h2>USB, WiFi or Ethernet data transfer</h2>");
	strcat(HTML_String, "<form>");
	strcat(HTML_String, "<table>");
	set_colgroup(150, 400, 150, 0, 0);

	//transfer data via 0 = USB / 7 = WiFi UDP / 10 = Ethernet
	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td></td><td><input type = \"radio\" onclick=\"sendVal('/?DataTransfVia=0')\" name=\"DataTransfVia\" id=\"JZ\" value=\"0\"");
	if (Set.DataTransVia == 0)strcat(HTML_String, " CHECKED");
	strcat(HTML_String, "><label for=\"JZ\">USB</label></td>");
	strcat(HTML_String, "<td><input type= \"button\" onclick= \"sendVal('/?Save=true')\" style= \"width:120px\" value=\"Save\"></button></td>");
	strcat(HTML_String, "</tr>");

	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td></td><td><input type = \"radio\" onclick=\"sendVal('/?DataTransfVia=7')\" name=\"DataTransfVia\" id=\"JZ\" value=\"7\"");
	if (Set.DataTransVia == 7)strcat(HTML_String, " CHECKED");
	strcat(HTML_String, "><label for=\"JZ\">WiFi (UDP) (default)</label></td></tr>");

	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td></td><td colspan=\"2\"><input type = \"radio\" onclick=\"sendVal('/?DataTransfVia=10')\" name=\"DataTransfVia\" id=\"JZ\" value=\"10\"");
	if (Set.DataTransVia == 10)strcat(HTML_String, " CHECKED");
	strcat(HTML_String, "><label for=\"JZ\">Ethernet (UDP) Ethernet hardware needed!!</label></td></tr>");
	strcat(HTML_String, "</table>");
	strcat(HTML_String, "</form><br><hr>");

	//-----------------------------------------------------------------------------------------
    // AOG Version

	strcat(HTML_String, "<h2>AOG Version number</h2>");
	strcat(HTML_String, "<form>");
	strcat(HTML_String, "<b>For AgOpenGPS version 4.3 and below set 17, for V 4.6 and above set 20</b><br>");
	strcat(HTML_String, "AOG 4.3.10 = 4 + 3 + 10 = 17<br><br><table>");
	set_colgroup(250, 300, 150, 0, 0);

	strcat(HTML_String, "<tr><td><b>AOG Version code</b></td><td><input type = \"number\"  onchange=\"sendVal('/?aogVer='+this.value)\" name = \"aogVer\" min = \"0\" max = \"255\" step = \"1\" style= \"width:200px\" value = \"");// placeholder = \"");
	strcati(HTML_String, Set.aogVersion);
	strcat(HTML_String, "\"></td>");

	strcat(HTML_String, "<td><input type= \"button\" onclick= \"sendVal('/?Save=true')\" style= \"width:120px\" value=\"Save\"></button></td>");
	strcat(HTML_String, "</tr>");


	strcat(HTML_String, "</table>");
	strcat(HTML_String, "</form><br><hr>");


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
	set_colgroup(250, 300, 150, 0, 0);

	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td colspan=\"3\">Set number of sections (1-16).</td></tr>");
	strcat(HTML_String, "<tr><td><b>number of sections</b></td><td><input type = \"number\"  onchange=\"sendVal('/?SectNum='+this.value)\" name = \"SectNum\" min = \"1\" max = \"100\" step = \"1\" style= \"width:200px\" value = \"");
	strcati(HTML_String, Set.SectNum);
	strcat(HTML_String, "\"></td>");

	strcat(HTML_String, "<td><input type= \"button\" onclick= \"sendVal('/?Save=true')\" style= \"width:120px\" value=\"Save\"></button></td>");
	strcat(HTML_String, "</tr>");

	strcat(HTML_String, "</table></form><br><hr>");


	//---------------------------------------------------------------------------------------------
	// Checkboxes IO functions
	strcat(HTML_String, "<h2>Section control uses</h2>");
	strcat(HTML_String, "<form>");
	strcat(HTML_String, "<table>");
	set_colgroup(150, 250, 150, 145, 150);

	//relais
	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td colspan=\"2\"><b>Relay output</b></td><td colspan=\"2\"><input type=\"checkbox\" onclick=\"sendVal('/?seRelInst='+this.checked)\" name=\"seRelInst\" id = \"Part\" value = \"1\" ");
	if (Set.SectRelaysInst == 1) strcat(HTML_String, "checked ");
	strcat(HTML_String, "> ");
	strcat(HTML_String, "<label for =\"Part\"> installed</label>");
	strcat(HTML_String, "</td>");
	strcat(HTML_String, "<td><input type= \"button\" onclick= \"sendVal('/?Save=true')\" style= \"width:120px\" value=\"Save\"></button></td>");

	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td></td><td>if installed</td><td><input type = \"radio\" onclick=\"sendVal('/?seRelON=0')\" name=\"seRelON\" id=\"JZ\" value=\"0\"");
	if (Set.SectRelaysON == 0)strcat(HTML_String, " CHECKED");
	strcat(HTML_String, "><label for=\"JZ\"> LOW</label></td>");
	strcat(HTML_String, "</tr>");

	strcat(HTML_String, "<td></td><td>relays spray on</td><td><input type = \"radio\" onclick=\"sendVal('/?seRelON=1')\" name=\"seRelON\" id=\"JZ\" value=\"1\"");
	if (Set.SectRelaysON == 1)strcat(HTML_String, " CHECKED");
	strcat(HTML_String, "><label for=\"JZ\"> HIGH</label></td>");
	strcat(HTML_String, "</tr>");

	strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");

	//switches
	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td colspan=\"2\"><b>Switches for sections</b></td><td colspan=\"2\"><input type=\"checkbox\" onclick=\"sendVal('/?seSWInst='+this.checked)\" name=\"seSWInst\" id = \"Part\" value = \"1\" ");
	if (Set.SectSWInst == 1) strcat(HTML_String, "checked ");
	strcat(HTML_String, "> ");
	strcat(HTML_String, "<label for =\"Part\"> installed</label>");
	strcat(HTML_String, "</td>");
	strcat(HTML_String, "<td><input type= \"button\" onclick= \"sendVal('/?Save=true')\" style= \"width:120px\" value=\"Save\"></button></td>");

	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td></td><td>if installed</td><td><input type = \"radio\" onclick=\"sendVal('/?DocSWspr=0')\" name=\"DocSWspr\" id=\"JZ\" value=\"0\"");
	if (Set.SectSWAutoOrOn == 0)strcat(HTML_String, " CHECKED");
	strcat(HTML_String, "><label for=\"JZ\"> LOW</label></td>");
	strcat(HTML_String, "</tr>");

	strcat(HTML_String, "<td></td><td>switches spray on</td><td><input type = \"radio\" onclick=\"sendVal('/?DocSWspr=1')\" name=\"DocSWspr\" id=\"JZ\" value=\"1\"");
	if (Set.SectSWAutoOrOn == 1)strcat(HTML_String, " CHECKED");
	strcat(HTML_String, "><label for=\"JZ\"> HIGH</label></td>");
	strcat(HTML_String, "</tr>");

	strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");

	strcat(HTML_String, "<tr><td colspan=\"4\"><b>Use as section control, or documentation<br>doc = AgOpenGPS writes status of input switches.</b></td></tr>");
	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td colspan=\"2\"></td><td colspan=\"2\"><input type=\"checkbox\" onclick=\"sendVal('/?DocOnly='+this.checked)\" name=\"DocOnly\" id = \"Part\" value = \"1\" ");
	if (Set.DocOnly == 1) strcat(HTML_String, "checked ");
	strcat(HTML_String, "> ");
	strcat(HTML_String, "<label for =\"Part\"> Documentation only</label>");
	strcat(HTML_String, "</td></tr>");

	strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");


	//rate SW
	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td colspan=\"4\"><b>Rate Control Switch only for +/- Motor valve</b></td>");
	strcat(HTML_String, "<tr><td colspan=\"2\"></td><td><input type = \"checkbox\" onclick=\"sendVal('/?RCSWInst='+this.checked)\" name=\"RCSWInst\" id = \"RCS\" value = \"1\" ");
	if (Set.RateSWLeftInst == 1) strcat(HTML_String, "checked ");
	strcat(HTML_String, "> ");
	strcat(HTML_String, "<label for =\"RCS\"> installed</label>");
	strcat(HTML_String, "</td>");
	strcat(HTML_String, "<td></td><td><input type= \"button\" onclick= \"sendVal('/?Save=true')\" style= \"width:120px\" value=\"Save\"></button></td>");

	strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");

	//main SW
	strcat(HTML_String, "<tr><td colspan=\"4\"><b>Main switch for section control</b></td>");
	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td></td><td colspan=\"3\"><input type = \"radio\" onclick=\"sendVal('/?MainSW=0')\" name=\"MainSW\" id=\"MS\" value=\"0\"");
	if (Set.SectMainSWType == 0)strcat(HTML_String, " CHECKED");
	strcat(HTML_String, "><label for=\"MS\"> none</label></td>");
	strcat(HTML_String, "<td><input type= \"button\" onclick= \"sendVal('/?Save=true')\" style= \"width:120px\" value=\"Save\"></button></td>");
	strcat(HTML_String, "</tr>");

	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td></td><td colspan=\"3\"><input type = \"radio\" onclick=\"sendVal('/?MainSW=1')\" name=\"MainSW\" id=\"MS\" value=\"1\"");
	if (Set.SectMainSWType == 1)strcat(HTML_String, " CHECKED");
	strcat(HTML_String, "><label for=\"MS\"> (ON)-OFF-(ON) toggle switch or push buttons</label></td></tr>");

	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td></td><td colspan=\"3\"><input type = \"radio\" onclick=\"sendVal('/?MainSW=2')\" name=\"MainSW\" id=\"MS\" value=\"2\"");
	if (Set.SectMainSWType == 2)strcat(HTML_String, " CHECKED");
	strcat(HTML_String, "><label for=\"MS\"> connected to hitch level sensor</label></td></tr>");

	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td></td><td colspan=\"3\"><input type = \"radio\" onclick=\"sendVal('/?MainSW=3')\" name=\"MainSW\" id=\"MS\" value=\"3\"");
	if (Set.SectMainSWType == 3)strcat(HTML_String, " CHECKED");
	strcat(HTML_String, "><label for=\"MS\"> inverted hitch level sensor</label></td></tr>");

	strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");

	//analog MAIN SW from hitch level
	if (Set.SectMainSWType > 1) {
		strcat(HTML_String, "<tr>");
		strcat(HTML_String, "<td colspan=\"4\"><br>Analog Main Section control Threshold value</td></tr>");
		strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");

		strcat(HTML_String, "<tr><td></td><td><divbox align=\"right\"><font size=\"+2\"><b>");
		strcati(HTML_String, (Set.HitchLevelVal));
		strcat(HTML_String, "</b></font></divbox></td><td colspan=\"2\">0-4095</td>");
		//Refresh button
		strcat(HTML_String, "<td><input type= \"button\" onclick= \"location.reload()\" style= \"width:120px\" value=\"Refresh\"></button></td>");
		strcat(HTML_String, "</tr>");

		strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");
		//set treshold
		strcat(HTML_String, "<tr><td></td><td><input type= \"button\" onclick= \"sendVal('/?ACTION=");
		strcati(HTML_String, ACTION_SET_WS_THRESHOLD);
		strcat(HTML_String, "')\" style= \"width:200px\" value=\"Use Current\"></button></td></tr>");
		strcat(HTML_String, "<tr><td colspan=\"4\"><b>Put your tool in the middle between ON and OFF position.</b></td>");
	}

	strcat(HTML_String, "</table></form><br><hr>");

	//---------------------------------------------------------------------------------------------  
	// WiFi IP settings 
	strcat(HTML_String, "<h2>WiFi IP settings</h2>");
	strcat(HTML_String, "<form>");
	//IP
	strcat(HTML_String, "<b>IP address for WiFi</b><br>When using DHCP the last number is set as IP from here, the first 3 numbers are set by DHCP.<br>");
	strcat(HTML_String, "<b>Default for last number is 71, it's also the address of the Webinterface.</b>");
	strcat(HTML_String, "<table>");
	set_colgroup(150, 50, 50, 50, 50);
	strcat(HTML_String, "<tr><td>IP address</td><td><input type = \"number\"  onchange=\"sendVal('/?WiFiIP0='+this.value)\" name = \"WiFiIP\" min = \"0\" max = \"255\" step = \"1\" style= \"width:40px\" value = \"");
	strcati(HTML_String, Set.WiFi_myip[0]);
	strcat(HTML_String, "\"></td>");
	strcat(HTML_String, "<td><input type = \"number\"  onchange=\"sendVal('/?WiFiIP1='+this.value)\" name = \"WiFiIP\" min = \"0\" max = \"255\" step = \"1\" style= \"width:40px\" value = \"");
	strcati(HTML_String, Set.WiFi_myip[1]);
	strcat(HTML_String, "\"></td>");
	strcat(HTML_String, "<td><input type = \"number\"  onchange=\"sendVal('/?WiFiIP2='+this.value)\" name = \"WiFiIP\" min = \"0\" max = \"255\" step = \"1\" style= \"width:40px\" value = \"");
	strcati(HTML_String, Set.WiFi_myip[2]);
	strcat(HTML_String, "\"></td>");
	strcat(HTML_String, "<td><input type = \"number\"  onchange=\"sendVal('/?WiFiIP3='+this.value)\" name = \"WiFiIP\" min = \"0\" max = \"255\" step = \"1\" style= \"width:40px\" value = \"");
	strcati(HTML_String, Set.WiFi_myip[3]);
	strcat(HTML_String, "\"></td></table><br>");

	//IP destination    
	strcat(HTML_String, "<table>");
	set_colgroup(250, 300, 150, 0, 0);
	strcat(HTML_String, "<tr><td colspan=\"2\"><b>IP address of destination</b></td>");
	strcat(HTML_String, "<td><input type= \"button\" onclick= \"sendVal('/?Save=true')\" style= \"width:120px\" value=\"Save\"></button></td>");
	strcat(HTML_String, "</tr></table><table>");
	strcat(HTML_String, "Destination's IP address, the first 3 numbers are set by DHCP, or as above.<br>");
	strcat(HTML_String, "<b>Use 255 to send to every device in network (default).</b> Use IP of your Computer, if you don't have a router and fixed IPs");
	strcat(HTML_String, "<table>");
	set_colgroup(150, 50, 50, 50, 50);
	strcat(HTML_String, "<tr><td>IP address destination</td><td>xxx</td><td>xxx</td><td>xxx<td><input type = \"number\"  onchange=\"sendVal('/?WiFiIPDest='+this.value)\" name = \"WiFiIPDest\" min = \"0\" max = \"255\" step = \"1\" style= \"width:40px\" value = \"");
	strcati(HTML_String, Set.WiFi_ipDest_ending);
	strcat(HTML_String, "\"></td></table><br><hr>");

	//---------------------------------------------------------------------------------------------  
	// Ethernet settings 
	strcat(HTML_String, "<h2>Ethernet settings</h2>");
	strcat(HTML_String, "<form>");
	strcat(HTML_String, "<table>");
	set_colgroup(150, 400, 150, 0, 0);

	//use DHCP/static IP radio button
	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td></td><td><input type = \"radio\" onclick=\"sendVal('/?EthStatIP=0')\" name=\"EthStatIP\" id=\"JZ\" value=\"0\"");
	if (Set.Eth_static_IP == false)strcat(HTML_String, " CHECKED");
	strcat(HTML_String, "><label for=\"JZ\">use DHCP (default)</label></td>");
	strcat(HTML_String, "<td><input type= \"button\" onclick= \"sendVal('/?Save=true')\" style= \"width:120px\" value=\"Save\"></button></td>");
	strcat(HTML_String, "</tr>");

	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td></td><td><input type = \"radio\" onclick=\"sendVal('/?EthStatIP=1')\" name=\"EthStatIP\" id=\"JZ\" value=\"1\"");
	if (Set.Eth_static_IP == true)strcat(HTML_String, " CHECKED");
	strcat(HTML_String, "><label for=\"JZ\">use fixed IP from below</label></td></tr>");

	strcat(HTML_String, "</table><br>");

	//IP
	strcat(HTML_String, "<b>IP address for Ethernet</b><br>When using DHCP the last number is set as IP from here, the first 3 numbers are set by DHCP.<br>");
	strcat(HTML_String, "<b>Default for last number is 72.</b>");
	strcat(HTML_String, "<table>");
	set_colgroup(150, 50, 50, 50, 50);
	strcat(HTML_String, "<tr><td>IP address</td><td><input type = \"number\"  onchange=\"sendVal('/?EthIP0='+this.value)\" name = \"EthIP\" min = \"0\" max = \"255\" step = \"1\" style= \"width:40px\" value = \"");
	strcati(HTML_String, Set.Eth_myip[0]);
	strcat(HTML_String, "\"></td>");
	strcat(HTML_String, "<td><input type = \"number\"  onchange=\"sendVal('/?EthIP1='+this.value)\" name = \"EthIP\" min = \"0\" max = \"255\" step = \"1\" style= \"width:40px\" value = \"");
	strcati(HTML_String, Set.Eth_myip[1]);
	strcat(HTML_String, "\"></td>");
	strcat(HTML_String, "<td><input type = \"number\"  onchange=\"sendVal('/?EthIP2='+this.value)\" name = \"EthIP\" min = \"0\" max = \"255\" step = \"1\" style= \"width:40px\" value = \"");
	strcati(HTML_String, Set.Eth_myip[2]);
	strcat(HTML_String, "\"></td>");
	strcat(HTML_String, "<td><input type = \"number\"  onchange=\"sendVal('/?EthIP3='+this.value)\" name = \"EthIP\" min = \"0\" max = \"255\" step = \"1\" style= \"width:40px\" value = \"");
	strcati(HTML_String, Set.Eth_myip[3]);
	strcat(HTML_String, "\"></td></table><br>");

	//IP destination
	strcat(HTML_String, "<table>");
	set_colgroup(250, 300, 150, 0, 0);
	strcat(HTML_String, "<tr><td colspan=\"2\"><b>IP address of destination</b></td>");
	strcat(HTML_String, "<td><input type= \"button\" onclick= \"sendVal('/?Save=true')\" style= \"width:120px\" value=\"Save\"></button></td>");
	strcat(HTML_String, "</tr></table><table>");
	strcat(HTML_String, "Destination's IP address, the first 3 numbers are set by DHCP, or as above.<br>");
	strcat(HTML_String, "<b>Use 255 to send to every device in network (default).</b> Use IP of your Computer, if you don't have a router and fixed IPs");
	strcat(HTML_String, "<table>");
	set_colgroup(150, 50, 50, 50, 50);
	strcat(HTML_String, "<tr><td>IP address destination</td><td>xxx</td><td>xxx</td><td>xxx<td><input type = \"number\"  onchange=\"sendVal('/?EthIPDest='+this.value)\" name = \"EthIPDest\" min = \"0\" max = \"255\" step = \"1\" style= \"width:40px\" value = \"");
	strcati(HTML_String, Set.Eth_ipDest_ending);
	strcat(HTML_String, "\"></td></table><br>");

	//mac
	strcat(HTML_String, "<b>mac address of Ethernet hardware</b><br>Type in the mac address of you Ethernet shield.<br>");
	strcat(HTML_String, "<table>");
	set_colgroup(150, 50, 50, 50, 50, 50, 50);
	strcat(HTML_String, "<tr><td>mac address</td><td><input type = \"number\"  onchange=\"sendVal('/?EthMac0='+this.value)\" name = \"EthMac\" min = \"0\" max = \"255\" step = \"1\" style= \"width:40px\" value = \"");
	strcati(HTML_String, Set.Eth_mac[0]);
	strcat(HTML_String, "\"></td>");
	strcat(HTML_String, "<td><input type = \"number\"  onchange=\"sendVal('/?EthMac1='+this.value)\" name = \"EthMac\" min = \"0\" max = \"255\" step = \"1\" style= \"width:40px\" value = \"");
	strcati(HTML_String, Set.Eth_mac[1]);
	strcat(HTML_String, "\"></td>");
	strcat(HTML_String, "<td><input type = \"number\"  onchange=\"sendVal('/?EthMac2='+this.value)\" name = \"EthMac\" min = \"0\" max = \"255\" step = \"1\" style= \"width:40px\" value = \"");
	strcati(HTML_String, Set.Eth_mac[2]);
	strcat(HTML_String, "\"></td>");
	strcat(HTML_String, "<td><input type = \"number\"  onchange=\"sendVal('/?EthMac3='+this.value)\" name = \"EthMac\" min = \"0\" max = \"255\" step = \"1\" style= \"width:40px\" value = \"");
	strcati(HTML_String, Set.Eth_mac[3]);
	strcat(HTML_String, "\"></td>");
	strcat(HTML_String, "<td><input type = \"number\"  onchange=\"sendVal('/?EthMac4='+this.value)\" name = \"EthMac\" min = \"0\" max = \"255\" step = \"1\" style= \"width:40px\" value = \"");
	strcati(HTML_String, Set.Eth_mac[4]);
	strcat(HTML_String, "\"></td>");
	strcat(HTML_String, "<td><input type = \"number\"  onchange=\"sendVal('/?EthMac5='+this.value)\" name = \"EthMac\" min = \"0\" max = \"255\" step = \"1\" style= \"width:40px\" value = \"");
	strcati(HTML_String, Set.Eth_mac[5]);
	strcat(HTML_String, "\"></td></table>");

	strcat(HTML_String, "</form><br><hr>");

	//-------------------------------------------------------------
	// Checkboxes debugmode
	strcat(HTML_String, "<h2>Debugmode</h2>");
	strcat(HTML_String, "<form>");
	strcat(HTML_String, "<table>");
	set_colgroup(300, 250, 150, 0, 0);

	strcat(HTML_String, "<tr> <td colspan=\"2\">debugmode sends messages to USB serial</td>");
	strcat(HTML_String, "<td><input type= \"button\" onclick= \"sendVal('/?Save=true')\" style= \"width:120px\" value=\"Save\"></button></td>");

	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td colspan=\"2\"><input type=\"checkbox\" onclick=\"sendVal('/?debugmode='+this.checked)\" name=\"debugmode\" id = \"Part\" value = \"1\" ");
	if (Set.debugmode == 1) strcat(HTML_String, "checked ");
	strcat(HTML_String, "> ");
	strcat(HTML_String, "<label for =\"Part\"> general debugmode on</label>");
	strcat(HTML_String, "</td></tr>");

	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td colspan=\"3\"><input type=\"checkbox\" onclick=\"sendVal('/?debugmSW='+this.checked)\" name=\"debugmSW\" id = \"Part\" value = \"1\" ");
	if (Set.debugmodeSwitches == 1) strcat(HTML_String, "checked ");
	strcat(HTML_String, "> ");
	strcat(HTML_String, "<label for =\"Part\"> debugmode switches on (display switch status)</label>");
	strcat(HTML_String, "</td></tr>");

	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td colspan=\"3\"><input type=\"checkbox\" onclick=\"sendVal('/?debugmRel='+this.checked)\" name=\"debugmRel\" id = \"Part\" value = \"1\" ");
	if (Set.debugmodeRelay == 1) strcat(HTML_String, "checked ");
	strcat(HTML_String, "> ");
	strcat(HTML_String, "<label for =\"Part\"> debugmode relais on</label>");
	strcat(HTML_String, "</td></tr>");

	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td colspan=\"3\"><input type=\"checkbox\" onclick=\"sendVal('/?debugmDatFromAOG='+this.checked)\" name=\"debugmDatFromAOG\" id = \"Part\" value = \"1\" ");
	if (Set.debugmodeDataFromAOG == 1) strcat(HTML_String, "checked ");
	strcat(HTML_String, "> ");
	strcat(HTML_String, "<label for =\"Part\"> debugmode data from AgOpenGPS on</label>");
	strcat(HTML_String, "</td></tr>");

	strcat(HTML_String, "<tr>");
	strcat(HTML_String, "<td colspan=\"3\"><input type=\"checkbox\" onclick=\"sendVal('/?debugmDatToAOG='+this.checked)\" name=\"debugmDatToAOG\" id = \"Part\" value = \"1\" ");
	if (Set.debugmodeDataToAOG == 1) strcat(HTML_String, "checked ");
	strcat(HTML_String, "> ");
	strcat(HTML_String, "<label for =\"Part\"> debugmode data to AgOpenGPS on</label>");
	strcat(HTML_String, "</td></tr>");

	strcat(HTML_String, "</table></form><br><hr>");

	//-------------------------------------------------------------
	// firmware update

	strcat(HTML_String, "<h2>Firmware Update for ESP32</h2>");
	strcat(HTML_String, "<form>");
	strcat(HTML_String, "<table>");
	set_colgroup(300, 250, 150, 0, 0);

	strcat(HTML_String, "<tr> <td colspan=\"3\">build a new firmware with Arduino IDE selecting</td> </tr>");
	strcat(HTML_String, "<tr> <td colspan=\"3\">Sketch -> Export compiled Binary</td> </tr>");
	strcat(HTML_String, "<tr> <td colspan=\"3\">upload this file via WiFi/Ethernet connection</td> </tr>");

	strcat(HTML_String, "<tr> <td colspan=\"3\">&nbsp;</td> </tr>");
	strcat(HTML_String, "<tr><td></td>");
	//button
	strcat(HTML_String, "<td><input type='submit' onclick='openUpload(this.form)' value='Open Firmware uploader'></td></tr>");

	strcat(HTML_String, "<script>");
	strcat(HTML_String, "function openUpload(form)");
	strcat(HTML_String, "{");
	strcat(HTML_String, "window.open('/serverIndex')");
	strcat(HTML_String, "}");
	strcat(HTML_String, "</script>");

	strcat(HTML_String, "</table></form><br><hr>");

	//-------------------------------------------------------------
	strcat(HTML_String, "</font>");
	strcat(HTML_String, "</body>");
	strcat(HTML_String, "</html>");

	//script to send values from webpage to ESP for process request
	strcat(HTML_String, "<script>");
	strcat(HTML_String, "function sendVal(ArgStr)");
	strcat(HTML_String, "{");
	strcat(HTML_String, "  var xhttp = new XMLHttpRequest();");
	strcat(HTML_String, "  xhttp.open(\"GET\",ArgStr, true);");
	strcat(HTML_String, "  xhttp.send();");
	strcat(HTML_String, " if (ArgStr == '/?ACTION=");
	strcati(HTML_String, ACTION_LoadDefaultVal);
	strcat(HTML_String, "') { window.setTimeout('location.reload()',400); }");
	strcat(HTML_String, "}");
	strcat(HTML_String, "</script>");

}



//-------------------------------------------------------------------------------------------------

void handleNotFound() {
	const char* notFound =
		"<!doctype html>"
		"<html lang = \"en\">"
		"<head>"""
		"<meta charset = \"utf - 8\">"
		"<meta http - equiv = \"x - ua - compatible\" content = \"ie = edge\">"
		"<meta name = \"viewport\" content = \"width = device - width, initial - scale = 1.0\">"
		"<title>Redirecting</title>"
		"</head>"
		"<body onload = \"redirect()\">"
		"<h1 style = \"text - align: center; padding - top: 50px; display: block; \"><br>404 not found<br><br>Redirecting to settings page in 3 secs ...</h1>"
		"<script>"
		"function redirect() {"
		"setTimeout(function() {"
		"    window.location.replace(\"/root\");"//new landing page
		"}"
		", 3000);"
		"}"
		"</script>"
		"</body>"
		"</html>";

	WiFi_Server.sendHeader("Connection", "close");
	WiFi_Server.send(200, "text/html", notFound);
	if (Set.debugmode) { Serial.println("redirecting from 404 not found to Webpage root"); }
}

//-------------------------------------------------------------------------------------------------
void set_colgroup(int w1, int w2, int w3, int w4, int w5) {
	strcat(HTML_String, "<colgroup>");
	set_colgroup1(w1);
	set_colgroup1(w2);
	set_colgroup1(w3);
	set_colgroup1(w4);
	set_colgroup1(w5);
	strcat(HTML_String, "</colgroup>");
}

void set_colgroup(int w1, int w2, int w3, int w4, int w5, int w6) {
	strcat(HTML_String, "<colgroup>");
	set_colgroup1(w1);
	set_colgroup1(w2);
	set_colgroup1(w3);
	set_colgroup1(w4);
	set_colgroup1(w5);
	set_colgroup1(w6);
	strcat(HTML_String, "</colgroup>");
}
void set_colgroup(int w1, int w2, int w3, int w4, int w5, int w6, int w7) {
	strcat(HTML_String, "<colgroup>");
	set_colgroup1(w1);
	set_colgroup1(w2);
	set_colgroup1(w3);
	set_colgroup1(w4);
	set_colgroup1(w5);
	set_colgroup1(w6);
	set_colgroup1(w7);
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
	dtostrf(f, leng, dezim, tmp);//f,6,2,tmp
	strcat(tx, tmp);
}
//---------------------------------------------------------------------
void strcati(char* tx, int i) {
	char tmp[8];

	itoa(i, tmp, 10);
	strcat(tx, tmp);
}


