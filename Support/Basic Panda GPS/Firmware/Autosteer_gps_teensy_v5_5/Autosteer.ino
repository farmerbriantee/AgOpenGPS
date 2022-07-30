/*
   UDP Autosteer code for Teensy 4.1
   For AgOpenGPS
   01 Feb 2022
   Like all Arduino code - copied from somewhere else :)
   So don't claim it as your own
*/

////////////////// User Settings /////////////////////////

//How many degrees before decreasing Max PWM
#define LOW_HIGH_DEGREES 5.0

/*  PWM Frequency ->
     490hz (default) = 0
     122hz = 1
     3921hz = 2
*/
#define PWM_Frequency 0

/////////////////////////////////////////////

// if not in eeprom, overwrite
#define EEP_Ident 5100

// Address of CMPS14 shifted right one bit for arduino wire library
#define CMPS14_ADDRESS 0x60

// BNO08x definitions
#define REPORT_INTERVAL 90 //Report interval in ms (same as the delay at the bottom)

//   ***********  Motor drive connections  **************888
//Connect ground only for cytron, Connect Ground and +5v for IBT2

//Dir1 for Cytron Dir, Both L and R enable for IBT2
#define DIR1_RL_ENABLE  4

//PWM1 for Cytron PWM, Left PWM for IBT2
#define PWM1_LPWM  2

//Not Connected for Cytron, Right PWM for IBT2
#define PWM2_RPWM  3

//--------------------------- Switch Input Pins ------------------------
#define STEERSW_PIN 32
#define WORKSW_PIN 34
#define REMOTE_PIN 37

//Define sensor pin for current or pressure sensor
#define CURRENT_SENSOR_PIN A17
#define PRESSURE_SENSOR_PIN A10

#define CONST_180_DIVIDED_BY_PI 57.2957795130823

#include <Wire.h>
#include <EEPROM.h>
#include "zADS1115.h"
ADS1115_lite adc(ADS1115_DEFAULT_ADDRESS);     // Use this for the 16-bit version ADS1115

#include <IPAddress.h>
#include "BNO08x_AOG.h"

#ifdef ARDUINO_TEENSY41
// ethernet
#include <NativeEthernet.h>
#include <NativeEthernetUdp.h>
#endif

IPAddress ipDestination(192, 168, 5, 255);

#ifdef ARDUINO_TEENSY41
//uint8_t Ethernet::buffer[200]; // udp send and receive buffer
uint8_t autoSteerUdpData[UDP_TX_PACKET_MAX_SIZE];  // Buffer For Receiving UDP Data
#endif

//loop time variables in microseconds
const uint16_t LOOP_TIME = 25;  //40Hz
uint32_t autsteerLastTime = LOOP_TIME;
uint32_t currentTime = LOOP_TIME;

const uint16_t WATCHDOG_THRESHOLD = 100;
const uint16_t WATCHDOG_FORCE_VALUE = WATCHDOG_THRESHOLD + 2; // Should be greater than WATCHDOG_THRESHOLD
uint8_t watchdogTimer = WATCHDOG_FORCE_VALUE;

//Heart beat hello AgIO
uint8_t helloFromAutoSteer[] = { 0x80, 0x81, 126, 126, 5, 0, 0, 0, 0, 0, 71 };
int16_t helloSteerPosition = 0;

//fromAutoSteerData FD 253 - ActualSteerAngle*100 -5,6, SwitchByte-7, pwmDisplay-8
uint8_t PGN_253[] = {0x80,0x81, 0x7D, 0xFD, 8, 0, 0, 0, 0, 0,0,0,0, 0xCC };
int8_t PGN_253_Size = sizeof(PGN_253) - 1;

//fromAutoSteerData FD 250 - sensor values etc
uint8_t PGN_250[] = { 0x80,0x81, 0x7B, 0xFA, 8, 0, 0, 0, 0, 0,0,0,0, 0xCC };
int8_t PGN_250_Size = sizeof(PGN_250) - 1;
uint8_t aog2Count = 0;
float sensorReading;
float sensorSample;

//EEPROM
int16_t EEread = 0;

//Relays
bool isRelayActiveHigh = true;
uint8_t relay = 0, relayHi = 0, uTurn = 0;
uint8_t tram = 0;

//Switches
uint8_t remoteSwitch = 0, workSwitch = 0, steerSwitch = 1, switchByte = 0;

//On Off
uint8_t guidanceStatus = 0;
uint8_t prevGuidanceStatus = 0;
bool guidanceStatusChanged = false;

//speed sent as *10
float gpsSpeed = 0;

//steering variables
float steerAngleActual = 0;
float steerAngleSetPoint = 0; //the desired angle from AgOpen
int16_t steeringPosition = 0; //from steering sensor
float steerAngleError = 0; //setpoint - actual

//pwm variables
int16_t pwmDrive = 0, pwmDisplay = 0;
float pValue = 0;
float errorAbs = 0;
float highLowPerDeg = 0;

//Steer switch button  ***********************************************************************************************************
uint8_t currentState = 1, reading, previous = 0;
uint8_t pulseCount = 0; // Steering Wheel Encoder
bool encEnable = false; //debounce flag
uint8_t thisEnc = 0, lastEnc = 0;

//Variables for settings
struct Storage {
  uint8_t Kp = 40;              // proportional gain
  uint8_t lowPWM = 10;          // band of no action
  int16_t wasOffset = 0;
  uint8_t minPWM = 9;
  uint8_t highPWM = 60;         // max PWM value
  float steerSensorCounts = 30;
  float AckermanFix = 1;        // sent as percent
};  Storage steerSettings;      // 11 bytes

//Variables for settings - 0 is false
struct Setup {
  uint8_t InvertWAS = 0;
  uint8_t IsRelayActiveHigh = 0;    // if zero, active low (default)
  uint8_t MotorDriveDirection = 0;
  uint8_t SingleInputWAS = 1;
  uint8_t CytronDriver = 1;
  uint8_t SteerSwitch = 0;          // 1 if switch selected
  uint8_t SteerButton = 0;          // 1 if button selected
  uint8_t ShaftEncoder = 0;
  uint8_t PressureSensor = 0;
  uint8_t CurrentSensor = 0;
  uint8_t PulseCountMax = 5;
  uint8_t IsDanfoss = 0;
}; Setup steerConfig;               // 9 bytes

void steerConfigInit()
{
  if (steerConfig.CytronDriver) 
  {
    pinMode(PWM2_RPWM, OUTPUT);
  }
}

void steerSettingsInit()
{
  // for PWM High to Low interpolator
  highLowPerDeg = ((float)(steerSettings.highPWM - steerSettings.lowPWM)) / LOW_HIGH_DEGREES;
}

void autosteerSetup()
{
  //PWM rate settings. Set them both the same!!!!
  /*  PWM Frequency ->
       490hz (default) = 0
       122hz = 1
       3921hz = 2
  */
  if (PWM_Frequency == 0)
  {
    analogWriteFrequency(PWM1_LPWM, 490);
    analogWriteFrequency(PWM2_RPWM, 490);
  }
  else if (PWM_Frequency == 1)
  {
    analogWriteFrequency(PWM1_LPWM, 122);
    analogWriteFrequency(PWM2_RPWM, 122);
  }
  else if (PWM_Frequency == 2)
  {
    analogWriteFrequency(PWM1_LPWM, 3921);
    analogWriteFrequency(PWM2_RPWM, 3921);
  }

  //keep pulled high and drag low to activate, noise free safe
  pinMode(WORKSW_PIN, INPUT_PULLUP);
  pinMode(STEERSW_PIN, INPUT_PULLUP);
  pinMode(REMOTE_PIN, INPUT_PULLUP);
  pinMode(DIR1_RL_ENABLE, OUTPUT);

  //set up communication
  Wire1.begin();
    
  // Check ADC 
  if(adc.testConnection())
  {
    Serial.println("ADC Connecton OK");
  }
  else
  {
    Serial.println("ADC Connecton FAILED!");
    Autosteer_running = false;
  }

  //50Khz I2C
  //TWBR = 144;   //Is this needed?

  EEPROM.get(0, EEread);              // read identifier

  if (EEread != EEP_Ident)            // check on first start and write EEPROM
  {
    EEPROM.put(0, EEP_Ident);
    EEPROM.put(10, steerSettings);
    EEPROM.put(40, steerConfig);
  }
  else
  {
    EEPROM.get(10, steerSettings);     // read the Settings
    EEPROM.get(40, steerConfig);
  }

  steerSettingsInit();
  steerConfigInit();

  if (Autosteer_running && Ethernet_running) 
  {
    Serial.println("Autosteer running, waiting for AgOpenGPS via UDP/Ethernet");
  }
  else
  {
    Autosteer_running = false;  //Turn off auto steer if no ethernet (Maybe running T4.0)
    if(!Ethernet_running)Serial.println("Ethernet not available");
    Serial.println("Autosteer disabled, GPS only mode");
    return;
  }

  adc.setSampleRate(ADS1115_REG_CONFIG_DR_128SPS); //128 samples per second
  adc.setGain(ADS1115_REG_CONFIG_PGA_6_144V);

}// End of Setup

void autosteerLoop()
{
#ifdef ARDUINO_TEENSY41
  ReceiveUdp();
#endif
  //Serial.println("AutoSteer loop");

  // Loop triggers every 100 msec and sends back gyro heading, and roll, steer angle etc
  currentTime = systick_millis_count;

  if (currentTime - autsteerLastTime >= LOOP_TIME)
  {
    autsteerLastTime = currentTime;

    //reset debounce
    encEnable = true;

    //If connection lost to AgOpenGPS, the watchdog will count up and turn off steering
    if (watchdogTimer++ > 250) watchdogTimer = WATCHDOG_FORCE_VALUE;

    //read all the switches
    workSwitch = digitalRead(WORKSW_PIN);  // read work switch

    if (steerConfig.SteerSwitch == 1)         //steer switch on - off
    {
      steerSwitch = digitalRead(STEERSW_PIN); //read auto steer enable switch open = 0n closed = Off
    }
    else if (steerConfig.SteerButton == 1)    //steer Button momentary
    {
      reading = digitalRead(STEERSW_PIN);
      if (reading == LOW && previous == HIGH)
      {
        if (currentState == 1)
        {
          currentState = 0;
          steerSwitch = 0;
        }
        else
        {
          currentState = 1;
          steerSwitch = 1;
        }
      }
      previous = reading;
    }
    else                                      // No steer switch and no steer button
    {
      // So set the correct value. When guidanceStatus = 1,
      // it should be on because the button is pressed in the GUI
      // But the guidancestatus should have set it off first
      if (guidanceStatusChanged && guidanceStatus == 1 && steerSwitch == 1 && previous == 0)
      {
        steerSwitch = 0;
        previous = 1;
      }

      // This will set steerswitch off and make the above check wait until the guidanceStatus has gone to 0
      if (guidanceStatusChanged && guidanceStatus == 0 && steerSwitch == 0 && previous == 1)
      {
        steerSwitch = 1;
        previous = 0;
      }
    }

    if (steerConfig.ShaftEncoder && pulseCount >= steerConfig.PulseCountMax)
    {
      steerSwitch = 1; // reset values like it turned off
      currentState = 1;
      previous = 0;
    }

    // Pressure sensor?
    if (steerConfig.PressureSensor)
    {
      sensorSample = (float)analogRead(PRESSURE_SENSOR_PIN);
      sensorSample *= 0.25;
      sensorReading = sensorReading * 0.6 + sensorSample * 0.4;
      if (sensorReading >= steerConfig.PulseCountMax)
      {
          steerSwitch = 1; // reset values like it turned off
          currentState = 1;
          previous = 0;
      }
    }

    // Current sensor?
    if (steerConfig.CurrentSensor)
    {
      sensorSample = (float)analogRead(CURRENT_SENSOR_PIN);
      sensorSample = (abs(512 - sensorSample)) * 0.5;
      sensorReading = sensorReading * 0.7 + sensorSample * 0.3;
      if (sensorReading >= steerConfig.PulseCountMax)
      {
          steerSwitch = 1; // reset values like it turned off
          currentState = 1;
          previous = 0;
      }
    }

    remoteSwitch = digitalRead(REMOTE_PIN); //read auto steer enable switch open = 0n closed = Off
    switchByte = 0;
    switchByte |= (remoteSwitch << 2); //put remote in bit 2
    switchByte |= (steerSwitch << 1);   //put steerswitch status in bit 1 position
    switchByte |= workSwitch;

    /*
      #if Relay_Type == 1
        SetRelays();       //turn on off section relays
      #elif Relay_Type == 2
        SetuTurnRelays();  //turn on off uTurn relays
      #endif
    */

    //get steering position
    if (steerConfig.SingleInputWAS)   //Single Input ADS
    {
      adc.setMux(ADS1115_REG_CONFIG_MUX_SINGLE_0);
      steeringPosition = adc.getConversion();
      adc.triggerConversion();//ADS1115 Single Mode

      steeringPosition = (steeringPosition >> 1); //bit shift by 2  0 to 13610 is 0 to 5v
      helloSteerPosition = steeringPosition - 6800;
    }
    else    //ADS1115 Differential Mode
    {
      adc.setMux(ADS1115_REG_CONFIG_MUX_DIFF_0_1);
      steeringPosition = adc.getConversion();
      adc.triggerConversion();

      steeringPosition = (steeringPosition >> 1); //bit shift by 2  0 to 13610 is 0 to 5v
      helloSteerPosition = steeringPosition - 6800;
    }

    //DETERMINE ACTUAL STEERING POSITION

    //convert position to steer angle. 32 counts per degree of steer pot position in my case
    //  ***** make sure that negative steer angle makes a left turn and positive value is a right turn *****
    if (steerConfig.InvertWAS)
    {
      steeringPosition = (steeringPosition - 6805  - steerSettings.wasOffset);   // 1/2 of full scale
      steerAngleActual = (float)(steeringPosition) / -steerSettings.steerSensorCounts;
    }
    else
    {
      steeringPosition = (steeringPosition - 6805  + steerSettings.wasOffset);   // 1/2 of full scale
      steerAngleActual = (float)(steeringPosition) / steerSettings.steerSensorCounts;
    }

    //Ackerman fix
    if (steerAngleActual < 0) steerAngleActual = (steerAngleActual * steerSettings.AckermanFix);

    if (watchdogTimer < WATCHDOG_THRESHOLD)
    {
      //Enable H Bridge for IBT2, hyd aux, etc for cytron
      if (steerConfig.CytronDriver)
      {
        if (steerConfig.IsRelayActiveHigh)
        {
          digitalWrite(PWM2_RPWM, 0);
        }
        else
        {
          digitalWrite(PWM2_RPWM, 1);
        }
      }
      else digitalWrite(DIR1_RL_ENABLE, 1);

      steerAngleError = steerAngleActual - steerAngleSetPoint;   //calculate the steering error
      //if (abs(steerAngleError)< steerSettings.lowPWM) steerAngleError = 0;

      calcSteeringPID();  //do the pid
      motorDrive();       //out to motors the pwm value
    }
    else
    {
      //we've lost the comm to AgOpenGPS, or just stop request
      //Disable H Bridge for IBT2, hyd aux, etc for cytron
      if (steerConfig.CytronDriver)
      {
        if (steerConfig.IsRelayActiveHigh)
        {
          digitalWrite(PWM2_RPWM, 1);
        }
        else
        {
          digitalWrite(PWM2_RPWM, 0);
        }
      }
      else digitalWrite(DIR1_RL_ENABLE, 0); //IBT2

      pwmDrive = 0; //turn off steering motor
      motorDrive(); //out to motors the pwm value
      pulseCount = 0;
    }
  } //end of timed loop

  //This runs continuously, outside of the timed loop, keeps checking for new udpData, turn sense
  //delay(1);

  // Speed pulse
  if (millis() - prev_PWM_Millis > 100)
  {
    prev_PWM_Millis = millis();
    //130 pp meter, 3.6 kmh = 1 m/sec or gpsSpeed * 130/3.6 or gpsSpeed * 36.1111
    //gpsSpeed is 10x actual speed so 3.61111
    //float speedPulse = gpsSpeed * 3.61111;
    //speedPulse = speedPulse * pulseCorrection;
    //tone(speedPulse_Pin,speedPulse);

    // gpsSpeed is in 10x km/h 
    // speedPulse in 10x mph?
    float speedPulse = gpsSpeed * 0.621371192 * 10;
    tone(velocityPWM_Pin, speedPulse);
  }

  if (encEnable)
  {
    thisEnc = digitalRead(REMOTE_PIN);
    if (thisEnc != lastEnc)
    {
      lastEnc = thisEnc;
      if ( lastEnc) EncoderFunc();
    }
  }

} // end of main loop

int currentRoll = 0;
int rollLeft = 0;
int steerLeft = 0;

#ifdef ARDUINO_TEENSY41
// UDP Receive
void ReceiveUdp()
{
    // When ethernet is not running, return directly. parsePacket() will block when we don't
    if (!Ethernet_running)
    {
        return;
    }

    uint16_t len = Eth_udpAutoSteer.parsePacket();

    // if (len > 0)
    // {
    //  Serial.print("ReceiveUdp: ");
    //  Serial.println(len);
    // }

    // Check for len > 4, because we check byte 0, 1, 3 and 3
    if (len > 4)
    {
        Eth_udpAutoSteer.read(autoSteerUdpData, UDP_TX_PACKET_MAX_SIZE);

        if (autoSteerUdpData[0] == 0x80 && autoSteerUdpData[1] == 0x81 && autoSteerUdpData[2] == 0x7F) //Data
        {
            if (autoSteerUdpData[3] == 0xFE)  //254
            {
                gpsSpeed = ((float)(autoSteerUdpData[5] | autoSteerUdpData[6] << 8)) * 0.1;

                prevGuidanceStatus = guidanceStatus;

                guidanceStatus = autoSteerUdpData[7];
                guidanceStatusChanged = (guidanceStatus != prevGuidanceStatus);

                //Bit 8,9    set point steer angle * 100 is sent
                steerAngleSetPoint = ((float)(autoSteerUdpData[8] | ((int8_t)autoSteerUdpData[9]) << 8)) * 0.01; //high low bytes

                //Serial.print("steerAngleSetPoint: ");
                //Serial.println(steerAngleSetPoint);

                //Serial.println(gpsSpeed);

                if ((bitRead(guidanceStatus, 0) == 0) || (gpsSpeed < 0.1) || (steerSwitch == 1))
                {
                    watchdogTimer = WATCHDOG_FORCE_VALUE; //turn off steering motor
                }
                else          //valid conditions to turn on autosteer
                {
                    watchdogTimer = 0;  //reset watchdog
                }

                //Bit 10 Tram
                tram = autoSteerUdpData[10];

                //Bit 11
                relay = autoSteerUdpData[11];

                //Bit 12
                relayHi = autoSteerUdpData[12];

                //----------------------------------------------------------------------------
                //Serial Send to agopenGPS

                int16_t sa = (int16_t)(steerAngleActual * 100);

                PGN_253[5] = (uint8_t)sa;
                PGN_253[6] = sa >> 8;

                // heading
                PGN_253[7] = (uint8_t)9999;
                PGN_253[8] = 9999 >> 8;

                // roll
                PGN_253[9] = (uint8_t)8888;
                PGN_253[10] = 8888 >> 8;

                PGN_253[11] = switchByte;
                PGN_253[12] = (uint8_t)pwmDisplay;

                //checksum
                int16_t CK_A = 0;
                for (uint8_t i = 2; i < PGN_253_Size; i++)
                    CK_A = (CK_A + PGN_253[i]);

                PGN_253[PGN_253_Size] = CK_A;

                //off to AOG
                SendUdp(PGN_253, sizeof(PGN_253), ipDestination, portDestination);

                //Steer Data 2 -------------------------------------------------
                if (steerConfig.PressureSensor || steerConfig.CurrentSensor)
                {
                    if (aog2Count++ > 2)
                    {
                        //Send fromAutosteer2
                        PGN_250[5] = (byte)sensorReading;

                        //add the checksum for AOG2
                        CK_A = 0;

                        for (uint8_t i = 2; i < PGN_250_Size; i++)
                        {
                            CK_A = (CK_A + PGN_250[i]);
                        }

                        PGN_250[PGN_250_Size] = CK_A;

                        //off to AOG
                        SendUdp(PGN_250, sizeof(PGN_250), ipDestination, portDestination);
                        aog2Count = 0;
                    }
                }

                //Serial.println(steerAngleActual);
                //--------------------------------------------------------------------------
            }

            //steer settings
            else if (autoSteerUdpData[3] == 0xFC)  //252
            {
                //PID values
                steerSettings.Kp = ((float)autoSteerUdpData[5]);   // read Kp from AgOpenGPS

                steerSettings.highPWM = autoSteerUdpData[6]; // read high pwm

                steerSettings.lowPWM = (float)autoSteerUdpData[7];   // read lowPWM from AgOpenGPS

                steerSettings.minPWM = autoSteerUdpData[8]; //read the minimum amount of PWM for instant on

                steerSettings.steerSensorCounts = autoSteerUdpData[9]; //sent as setting displayed in AOG

                steerSettings.wasOffset = (autoSteerUdpData[10]);  //read was zero offset Lo

                steerSettings.wasOffset |= (autoSteerUdpData[11] << 8);  //read was zero offset Hi

                steerSettings.AckermanFix = (float)autoSteerUdpData[12] * 0.01;

                //crc
                //autoSteerUdpData[13];

                //store in EEPROM
                EEPROM.put(10, steerSettings);

                // Re-Init steer settings
                steerSettingsInit();
            }

            else if (autoSteerUdpData[3] == 0xFB)  //251 FB - SteerConfig
            {
                uint8_t sett = autoSteerUdpData[5]; //setting0

                if (bitRead(sett, 0)) steerConfig.InvertWAS = 1; else steerConfig.InvertWAS = 0;
                if (bitRead(sett, 1)) steerConfig.IsRelayActiveHigh = 1; else steerConfig.IsRelayActiveHigh = 0;
                if (bitRead(sett, 2)) steerConfig.MotorDriveDirection = 1; else steerConfig.MotorDriveDirection = 0;
                if (bitRead(sett, 3)) steerConfig.SingleInputWAS = 1; else steerConfig.SingleInputWAS = 0;
                if (bitRead(sett, 4)) steerConfig.CytronDriver = 1; else steerConfig.CytronDriver = 0;
                if (bitRead(sett, 5)) steerConfig.SteerSwitch = 1; else steerConfig.SteerSwitch = 0;
                if (bitRead(sett, 6)) steerConfig.SteerButton = 1; else steerConfig.SteerButton = 0;
                if (bitRead(sett, 7)) steerConfig.ShaftEncoder = 1; else steerConfig.ShaftEncoder = 0;

                steerConfig.PulseCountMax = autoSteerUdpData[6];

                //was speed
                //autoSteerUdpData[7];

                sett = autoSteerUdpData[8]; //setting1 - Danfoss valve etc

                if (bitRead(sett, 0)) steerConfig.IsDanfoss = 1; else steerConfig.IsDanfoss = 0;
                if (bitRead(sett, 1)) steerConfig.PressureSensor = 1; else steerConfig.PressureSensor = 0;
                if (bitRead(sett, 2)) steerConfig.CurrentSensor = 1; else steerConfig.CurrentSensor = 0;

                //crc
                //autoSteerUdpData[13];

                EEPROM.put(40, steerConfig);

                // Re-Init
                steerConfigInit();

            }//end FB
            else if (autoSteerUdpData[3] == 200 && Autosteer_running) // Hello from AgIO
            {
                int16_t sa = (int16_t)(steerAngleActual * 100);

                helloFromAutoSteer[5] = (uint8_t)sa;
                helloFromAutoSteer[6] = sa >> 8;

                helloFromAutoSteer[7] = (uint8_t)helloSteerPosition;
                helloFromAutoSteer[8] = helloSteerPosition >> 8;
                helloFromAutoSteer[9] = switchByte;

                SendUdp(helloFromAutoSteer, sizeof(helloFromAutoSteer), ipDestination, portDestination);
            }

            //whoami
            else if (autoSteerUdpData[3] == 202)
            {
                //make really sure this is the reply pgn
                if (autoSteerUdpData[4] == 3 && autoSteerUdpData[5] == 202 && autoSteerUdpData[6] == 202)
                {
                    //hello from AgIO
                    uint8_t scanReply[] = { 128, 129, 120, 203, 4,
                        Eth_myip[0], Eth_myip[1], Eth_myip[2], 120, 23 };

                    //checksum
                    int16_t CK_A = 0;
                    for (uint8_t i = 2; i < sizeof(scanReply) - 1; i++)
                    {
                        CK_A = (CK_A + scanReply[i]);
                    }
                    scanReply[sizeof(scanReply)-1] = CK_A;

                    static uint8_t ipDest[] = { 255,255,255,255 };
                    uint16_t portDest = 9999; //AOG port that listens

                    //off to AOG
                    SendUdp(scanReply, sizeof(scanReply), ipDest, portDest);
                }
            }
        } //end if 80 81 7F
    }
}
#endif

#ifdef ARDUINO_TEENSY41
void SendUdp(uint8_t *data, uint8_t datalen, IPAddress dip, uint16_t dport)
{
  Eth_udpAutoSteer.beginPacket(dip, dport);
  Eth_udpAutoSteer.write(data, datalen);
  Eth_udpAutoSteer.endPacket();
}
#endif

//ISR Steering Wheel Encoder
void EncoderFunc()
{
  if (encEnable)
  {
    pulseCount++;
    encEnable = false;
  }
}
