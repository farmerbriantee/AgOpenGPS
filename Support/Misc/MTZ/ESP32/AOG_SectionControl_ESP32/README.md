# AOG_Section_control

<b>Section Control running on ESP32 for AgOpenGPS PC Software.<br><br>
Multi version code: supports V 4.3.10 (=version code 17) and V5.x.20 (=version code 20)<br>
          
For existing Nano boards, the Upgrade to Nano33iot, to get WiFi is a good solution. Use code for Nano33IoT in other repository.
          
Supports: <br>- Section control, 16 sections
          <br>- hardware input switches (Main ON/OFF, OFF/Auto/ON for each section, +/- pressure (only motor driven, no rate control in V4 so far))
          <br>- documentation only (e.g. for machinery with hydraulic gates)
   <br>and most combinations of it</b>

Settings can be changed via webinterface. The IP adress is x.x.x.71 in your WiFi network. If the log to your networks fails, you wait until an accesspoint is created. Connenct your computer to it and use your browser to get to webinterface at 192.168.1.1

The settings done directly in the code are the default values, that can be reloaded. The pin assigment must be done in the code, most other things can be changed in webinterface.

Make sure, that the SSID and password fits to your tractor's WIFI.

Works with the circuit (by WEder) based on Arduino nano, see PDF.

<b>!!!The ESP32 and the Nano33 iot use 3.3V for any in-/outputs !!!</b>

A suggestion for ESP32 pinout is in the PDF. Don't use pins GPIO 0, 6-12. The pins 33-39 are input only, and don't have pullup resistors.

<b>Further remarks on the ESP32 pinout:</b><br>
The circuit could be mostly the same as in WEder's schematic.

All switches use internal pullup, so switch to GND.

GPIO 39 has no internal pullup, so external resistor 10k to 3.3V and switch to GND.

Pressure(Flowrate) and Main Switch are (ON)-OFF-(ON) switches or push buttons: 3.3V - 1.15V - GND to get 1.15V use 10k to 3.3 and 10k to GND. So only 1 input for 2 functions is needed.

For the outputs use a driver like UDN2981(relais have common GND and UDN does +) or ULN2803 (relais have common + and ULN does GND) 


Remark on non booting ESP32: they don't like raising input voltage when powering your step down 3,3V power source. To keep them in reset, put a 10uF electrolytic capacitor to reset - GND and another one EN - GND. So the enable and the reset pin will be LOW until power is stable. With this they will boot.

NO rate control in this code at the moment (not supported by AOG)

Suggestion for documentation only: https://agopengps.discourse.group/t/section-control-documentation-for-ferilizer-spreader/1360

Suggestion for upgrading Mueller spray controller: https://agopengps.discourse.group/t/muller-spray-controll-with-motor-valves/1303

Video how to use switches: https://youtu.be/kI321iBwe4U
