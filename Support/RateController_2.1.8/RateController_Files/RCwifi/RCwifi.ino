// Wemos D1 mini Pro,  board: LOLIN(Wemos) D1 R2 & mini

#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <ESP8266WebServer.h>
#include <ESP8266mDNS.h>
#include <SoftwareSerial.h>

unsigned long BlinkTime;
bool BlinkState;

bool SW0wifi;
bool SW1wifi;
bool SW2wifi;
bool SW3wifi;
bool MasterOnWifi;

unsigned long LoopTime;

SoftwareSerial swSer1;

ESP8266WebServer server(80);

String tmp;

void setup()
{
	Serial.begin(38400);
	delay(2000);
	Serial.println("RCwifi   :   13-Mar-2021");

	pinMode(BUILTIN_LED, OUTPUT);

	swSer1.begin(38400, SWSERIAL_8N1, 12, 12, false, 256);
	// high speed half duplex, turn off interrupts during tx
	swSer1.enableIntTx(false);

	WiFi.disconnect();
	WiFi.softAP("Switches");

	IPAddress myIP = WiFi.softAPIP();
	Serial.print("AP IP address: ");
	Serial.println(myIP);
	server.on("/", handleRoot);
	server.on("/SW1pressed", SW1Pressed);
	server.on("/SW2pressed", SW2Pressed);
	server.on("/SW3pressed", SW3Pressed);
	server.on("/SW4pressed", SW4Pressed);
	server.on("/Masterpressed", MasterPressed);

	server.begin();
	Serial.println("HTTP server started");
	Serial.println("Finished Setup");
}

void loop()
{
	server.handleClient();
	Blink();
}

void Blink()
{
	if (millis() - BlinkTime > 1000)
	{
		BlinkTime = millis();
		BlinkState = !BlinkState;
		digitalWrite(BUILTIN_LED, BlinkState);
	}
}

void Send()
{
	// 0    127
// 1    107
// 2    SW0
// 3    SW1
// 4    SW2
// 5    SW3
// 6    MasterOn

	yield();

	swSer1.enableTx(true);

	swSer1.write(127);
	swSer1.write(107);
	swSer1.write(SW0wifi);
	swSer1.write(SW1wifi);

	yield();

	swSer1.write(SW2wifi);
	swSer1.write(SW3wifi);
	swSer1.write(MasterOnWifi);

	swSer1.enableTx(false);

	Serial.println("Sending");
	Serial.println("");
	yield();
}

void handleRoot()
{
	server.send(200, "text/html", GetPage1());
}

void SW1Pressed()
{
	Serial.println("SW1");
	SW0wifi = !SW0wifi;
	Send();
	handleRoot();
}

void SW2Pressed()
{
	Serial.println("SW2");
	SW1wifi = !SW1wifi;
	Send();
	handleRoot();
}

void SW3Pressed()
{
	Serial.println("SW3");
	SW2wifi = !SW2wifi;
	Send();
	handleRoot();
}

void SW4Pressed()
{
	Serial.println("SW4");
	SW3wifi = !SW3wifi;
	Send();
	handleRoot();
}

void MasterPressed()
{
	Serial.println("Master");
	MasterOnWifi = !MasterOnWifi;
	Send();
	handleRoot();
}

String GetPage1()
{
	String st = "<HTML>";
	st += "";
	st += "  <head>";
	st += "    <META content='text/html; charset=utf-8' http-equiv=Content-Type>";
	st += "    <meta name=vs_targetSchema content='HTML 4.0'>";
	st += "    <meta name='viewport' content='width=device-width, initial-scale=1.0'>";
	st += "    <title>Temp Monitor</title>";
	st += "    <style>";
	st += "      html {";
	st += "        font-family: Helvetica;";
	st += "        display: inline-block;";
	st += "        margin: 0px auto;";
	st += "        text-align: center;";
	st += "";
	st += "      }";
	st += "";
	st += "      h1 {";
	st += "        color: #444444;";
	st += "        margin: 50px auto 30px;";
	st += "      }";
	st += "";
	st += "      table.center {";
	st += "        margin-left: auto;";
	st += "        margin-right: auto;";
	st += "      }";
	st += "";
	st += "      .buttonOn {";
	st += "        background-color: #00ff00;";
	st += "        border: none;";
	st += "        color: white;";
	st += "        padding: 15px 32px;";
	st += "        text-align: center;";
	st += "        text-decoration: none;";
	st += "        display: inline-block;";
	st += "        margin: 4px 2px;";
	st += "        cursor: pointer;";
	st += "        font-size: 15px;";
	st += "        width: 30%;";
	st += "      }";
	st += "";
	st += "      .buttonOff {";
	st += "        background-color: #ff0000;";
	st += "        border: none;";
	st += "        color: white;";
	st += "        padding: 15px 32px;";
	st += "        text-align: center;";
	st += "        text-decoration: none;";
	st += "        display: inline-block;";
	st += "        margin: 4px 2px;";
	st += "        cursor: pointer;";
	st += "        font-size: 15px;";
	st += "        width: 30%;";
	st += "      }";
	st += "";
	st += "    </style>";
	st += "  </head>";
	st += "";
	st += "  <BODY>";
	st += "    <style>";
	st += "      body {";
	st += "        margin-top: 50px;";
	st += "        background-color: DeepSkyBlue";
	st += "      }";
	st += "";
	st += "      font-family: Arial,";
	st += "      Helvetica,";
	st += "      Sans-Serif;";
	st += "";
	st += "    </style>";
	st += "";
	st += "    <h1 align=center>RateController Switches</h1>";
	st += "    <form id=FORM1 method=post action='/'>&nbsp;";
	st += "";
	st += "";

	if (SW0wifi) tmp = "buttonOn"; else tmp = "buttonOff";
	st += "      <p> <input class='" + tmp + "' id=Submit1 type=submit formaction='/SW1pressed' value='Switch 1'> </p>";

	if (SW1wifi) tmp = "buttonOn"; else tmp = "buttonOff";
	st += "      <p> <input class='" + tmp + "' id=Submit2 type=submit formaction='/SW2pressed' value='Switch 2'> </p>";

	if (SW2wifi) tmp = "buttonOn"; else tmp = "buttonOff";
	st += "      <p> <input class='" + tmp + "' id=Submit3 type=submit formaction='/SW3pressed' value='Switch 3'> </p>";

	if (SW3wifi) tmp = "buttonOn"; else tmp = "buttonOff";
	st += "      <p> <input class='" + tmp + "' id=Submit4 type=submit formaction='/SW4pressed' value='Switch 4'> </p>";

	if (MasterOnWifi) tmp = "buttonOn"; else tmp = "buttonOff";
	st += "      <p> <input class='" + tmp + "' id=Submit5 type=submit formaction='/Masterpressed' value='Master'> </p>";

	st += "    </form>";
	st += "";
	st += "</HTML>";

	return st;
}

