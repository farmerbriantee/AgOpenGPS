//User config: ***********************************************************************************

//the following lines should be configed by the user to fit the programm to the sprayer/Arduino

//PINs of the Arduino (current setting is for the layout shown as example WIKI)
// if only 1 flowrate is used, use left
#define FlowDirLeft_PIN    12  //PB4  Rate-Control Valve/Motor Direktion; if used or not change in line 35ff RateControlEquiped and select in line 35ff if Motor or PWM: RateControlPWM = ...
#define FlowPWMLeft_PIN    11  //PB3  Rate-Control Valve PWM/Motor ON/OFF; if used or not change in line 35ff RateControlEquiped
#define FlowDirRight_PIN    0  //0  = unused Rate-Control Valve Direktion; if used or not change in line 35ff RateControlEquiped
#define FlowPWMRight_PIN    0  //0  = unused Rate-Control Valve PWM; if used or not change in line 35ff RateControlEquiped
#define FlowEncALeft_PIN    2  //int0 D2 pin 2 Flowmeter left/1 if used or not change in line 35ff RateControlEquiped
#define FlowEncARight_PIN   0  //int1 D3 pin 3 Flowmeter right/2 if used or not change in line 35ff RateControlEquiped
int Relay_PIN[] = { 13,10,9,8,7,6,5 }; //sections of sprayer, when changed also change in Relays code (other Tab) 1=D13/PB5;2=D10/PB2;3=D9/PB1;4=D8/PB0;5=D7/PB7;6=D6/PD6;7=D5/PD5
#define SectSW_PIN0  A0      //section switches to arduino
#define SectSW_PIN1  A1
#define SectSW_PIN2  A2
#define SectSW_PIN3  A3
#define SectSW_PIN4  A4
#define SectSW_PIN5  A5
#define SectSW_PIN6  3
#define SectSW_PIN7  0       // 0 = not in use
#define SectSW_PIN8  0       // 0 = not in use
#define SectSW_PIN9  0       // 0 = not in use
#define SectSW_PIN10  0      // 0 = not in use
#define SectSW_PIN11  0      // 0 = not in use
#define SectSW_PIN12  0      // 0 = not in use
#define SectSW_PIN13  0      // 0 = not in use
#define SectSW_PIN14  0      // 0 = not in use
#define SectSW_PIN15  0      // 0 = not in use
#define SectAutoManSW_PIN 4  // D4/PD4 Main Auto/Manual switch
#define SectMainSW_PIN A7    //arduino to AOG Main auto toggle switch
#define RateSWLeft_PIN A6        //Rate +/- switch
#define RateSWRight_PIN A6        //Rate +/- switch

//sprayer config settings
#define SectNum 7                 // number of sections equiped max 16, depends on hardware, change the lines 10 to 20 in tab ReadSwitches_buildBytes of void SectSWRead to fit to the input switches
boolean SectSWequiped = true;      //true if section input switches are equiped, else: false
//Example1: motor valve is controled only by Switch not by AOG, no Flowmeter, : RateControl..Equiped = false; RateSW..Equiped = true; RateControlPRM = false;
//Example2: PWM valve, with flowmeter all controled by AOG:   RateControl..Equiped = true; RateSW..Equiped = true; RateControlPRM = true;
boolean RateControlLeftEquiped = true;  //true if Rate control is there, else: false
boolean RateSWLeftEquiped = true;     //true if Rate control Pressure switch is there, else: false
boolean RateControlRightEquiped = false;  //true if Rate control is there, else: false
boolean RateSWRightEquiped = false;     //true if Rate control Pressure switch is there, else: false
boolean RateControlPWM = false;    // true if PWM valve, false if Motor drive for pressure changing
#define BaudRate 38400             // Baudrate = speed of serial port. AOG uses 38400. If useing bluetooth module, you need to configure it to this Baudrate

// END of user config ****************************************************************************

//ToDo: - Right side Rate caluclation / output / Motordrive
//      - Manual mode for Rate Control

  //values to decide position of section switch
#define SectSWOFF 300 // analog in is lower than .. for off
#define SectSWAUTOMin 350 // analog in is higher than .. for auto
#define SectSWAUTOMax 700 // analog in is lower than .. for auto
#define SectSWON 750 // analog in is higher than .. for on

int SectSWVal[] = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }; //value of analogRead or digitalRead
int SWVal[] = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }; //value of analogRead or digitalRead

//loop time variables in microseconds
const unsigned long LOOP_TIME = 550; //in msec; 1000 = 1 Hz
const unsigned long SectSWDelayTime = 1400; //time the arduino waits after manual Switch is used before acception command from AOG in msec
unsigned long lastTime = LOOP_TIME;
unsigned long currentTime = LOOP_TIME;
unsigned long RelayFromAOGTime = LOOP_TIME;
unsigned long SectAutoSWTime = LOOP_TIME;
unsigned long SectAutoSWlastTime = LOOP_TIME;
unsigned long SectMainSWlastTime = LOOP_TIME;
unsigned long RateSWlastTimeLeft = LOOP_TIME;
unsigned long RateSWDelayTime = 250; //time to pass before a new toggle of switch is accepted = if hold down, time between steps
unsigned long RateSWlastTimeRight = LOOP_TIME;
unsigned long SectSWcurrentTime = LOOP_TIME;
unsigned int dT = 100;
byte watchdogTimer = 0;

//Kalman variables Left
float rateKLeft = 0;
float PcLeft = 0.0;
float GLeft = 0.0;
float PLeft = 1.0;
float XpLeft = 0.0;
float ZpLeft = 0.0;
float XeRateLeft = 0; //the filtered flowrate
const float varRateLeft = 100; // variance, smaller, more filtering
const float varProcessLeft = 10;

//Kalman variables Right
float rateKRight = 0;
float PcRight = 0.0;
float GRight = 0.0;
float PRight = 1.0;
float XpRight = 0.0;
float ZpRight = 0.0;
float XeRateRight = 0; //the filtered flowrate
const float varRateRight = 100; // variance, smaller, more filtering
const float varProcessRight = 10;

//program flow
bool isDataFound = false, isSettingFound = false;
int header = 0, tempHeader = 0;

//bit 0 on byte[0] is section 1
byte RelayFromAOG[] = { 0,0,0,0,0,0,0,0 };
byte RelayToAOG[] = { 0,0,0,0,0,0,0,0 };
byte RelayToAOGOld[] = { 0,0,0,0,0,0,0,0 };
byte RelayOUT[] = { 0,0,0,0,0,0,0,0 };
byte RelayOUTOld[] = { 0,0,0,0,0,0,0,0 };
byte SectSWOffToAOG[] = { 0,0,0,0,0,0,0,0 };
byte SectSWOffToAOGOld[] = { 0,0,0,0,0,0,0,0 };
byte SectMainToAOG = 0;
byte SectMainFromAOG = 0;
byte uTurnRelay = 0;
//  byte flowRateSW1 = 0;
boolean SectMainSWpressed = false;
boolean SectSWpressed = false;
boolean SectSWpressedLoop = false;
boolean SectAuto = true;
boolean SectAutoOld = true;
boolean SectAutoSWpressed = false;
boolean RateAuto = false;
boolean RateManUpLeft = false;
boolean RateManUpRight = false;
boolean RateManDownLeft = false;
boolean RateManDownRight = false;

boolean SectMainOn = false;
boolean BitVal = false;

float groundSpeed = 0; //speed from AgOpenGPS is multiplied by 4
float rateSetPointLeft = 0.0;
float countsThisLoopLeft = 0;
float rateErrorLeft = 0; //for PID
int rateAppliedLPMLeft = 0;
float rateSetPointRight = 0.0;
float countsThisLoopRight = 0;
float rateErrorRight = 0; //for PID
int rateAppliedLPMRight = 0;

unsigned long accumulatedCountsLeft = 0;
float flowmeterCalFactorLeft = 50;
unsigned long accumulatedCountsRight = 0;
float flowmeterCalFactorRight = 50;
unsigned long accumulatedCountsDual = 0;

float pulseAverageLeft = 0;
float pulseAverageRight = 0;

//the ISR counter
volatile unsigned long pulseCountLeft = 0, pulseDurationLeft;
volatile unsigned long pulseCountRight = 0, pulseDurationRight;
bool state = false;

void setup()
{
	if (SectSWequiped) pinMode(SectAutoManSW_PIN, INPUT_PULLUP);
	if (SectSWequiped) pinMode(SectMainSW_PIN, INPUT_PULLUP);
	if (SectSWequiped)pinMode(SectSW_PIN0, INPUT_PULLUP);
	if (SectNum >= 2 && SectSWequiped && !SectSW_PIN1 == 0) pinMode(SectSW_PIN1, INPUT_PULLUP);
	if (SectNum >= 3 && SectSWequiped && !SectSW_PIN2 == 0) pinMode(SectSW_PIN2, INPUT_PULLUP);
	if (SectNum >= 4 && SectSWequiped && !SectSW_PIN3 == 0) pinMode(SectSW_PIN3, INPUT_PULLUP);
	if (SectNum >= 5 && SectSWequiped && !SectSW_PIN4 == 0) pinMode(SectSW_PIN4, INPUT_PULLUP);
	if (SectNum >= 6 && SectSWequiped && !SectSW_PIN5 == 0) pinMode(SectSW_PIN5, INPUT_PULLUP);
	if (SectNum >= 7 && SectSWequiped && !SectSW_PIN6 == 0) pinMode(SectSW_PIN6, INPUT_PULLUP);
	if (SectNum >= 8 && SectSWequiped && !SectSW_PIN7 == 0) pinMode(SectSW_PIN7, INPUT_PULLUP);
	if (SectNum >= 9 && SectSWequiped && !SectSW_PIN8 == 0) pinMode(SectSW_PIN8, INPUT_PULLUP);
	if (SectNum >= 10 && SectSWequiped && !SectSW_PIN9 == 0) pinMode(SectSW_PIN9, INPUT_PULLUP);
	if (SectNum >= 11 && SectSWequiped && !SectSW_PIN10 == 0) pinMode(SectSW_PIN10, INPUT_PULLUP);
	if (SectNum >= 12 && SectSWequiped && !SectSW_PIN11 == 0) pinMode(SectSW_PIN11, INPUT_PULLUP);
	if (SectNum >= 13 && SectSWequiped && !SectSW_PIN12 == 0) pinMode(SectSW_PIN12, INPUT_PULLUP);
	if (SectNum >= 14 && SectSWequiped && !SectSW_PIN13 == 0) pinMode(SectSW_PIN13, INPUT_PULLUP);
	if (SectNum >= 15 && SectSWequiped && !SectSW_PIN14 == 0) pinMode(SectSW_PIN14, INPUT_PULLUP);
	if (SectNum >= 16 && SectSWequiped && !SectSW_PIN15 == 0) pinMode(SectSW_PIN15, INPUT_PULLUP);
	if (RateSWLeftEquiped && !RateSWLeft_PIN == 0) pinMode(RateSWLeft_PIN, INPUT_PULLUP);
	if (RateSWRightEquiped && !RateSWRight_PIN == 0) pinMode(RateSWRight_PIN, INPUT_PULLUP);

	if (RateControlLeftEquiped && (FlowDirLeft_PIN == 0 | FlowPWMLeft_PIN == 0)) { RateControlLeftEquiped = false; }
	if (RateControlRightEquiped && (FlowDirRight_PIN == 0 | FlowPWMRight_PIN == 0)) { RateControlRightEquiped = false; }

	//Pull all values up = auto
	for (int i = 0; i < 16; i++) { SWVal[i] = 1000; }
	for (int i = 0; i < 16; i++) { SectSWVal[i] = 1000; }
	//Main Section off
	SWVal[0] = 500;
	SectMainOn = false;
	SectMainSWpressed = false;
	//Auto / Manual SW
	SWVal[1] = 1000;
	SectAuto = true;
	// pressure SW
	SWVal[2] = 500;

	for (int i = 0; i < SectNum; i++) {
		pinMode(Relay_PIN[i], OUTPUT);
	}
	if (!FlowDirLeft_PIN == 0) { pinMode(FlowDirLeft_PIN, OUTPUT); }
	if (!FlowPWMLeft_PIN == 0) { pinMode(FlowPWMLeft_PIN, OUTPUT); }
	if (!FlowDirRight_PIN == 0) { pinMode(FlowDirRight_PIN, OUTPUT); }
	if (!FlowPWMRight_PIN == 0) { pinMode(FlowPWMRight_PIN, OUTPUT); }

	RelayOUT[0] = 0;
	RelayOUT[1] = 0;
	SetRelays;

	//check if MainSw and RateSw are realy in use, because if not the INPUT_PULLUP would deliver always ON or Rate +
	if (SectSWequiped)
	{
		byte no = 0;      //5 times check if pulled up
		for (byte i = 0;i < 5; i++) {
			SWVal[0] = analogRead(SectMainSW_PIN); delay(10);
			if (SWVal[0] > SectSWON) { delay(500); no++; }
		}//for
		if (no > 4) { SectSWequiped = false; SWVal[0] = 500; }
	}
	if (RateSWLeftEquiped)
	{
		byte no = 0;      //5 times check if pulled up
		for (byte i = 0;i < 5; i++) {
			SWVal[2] = analogRead(RateSWLeft_PIN); delay(10);
			if (SWVal[2] > SectSWON) { delay(500); no++; }
		}//for
		if (no > 4) { RateSWLeftEquiped = false; SWVal[2] = 500; }
	}
	if (RateSWRightEquiped)
	{
		byte no = 0;      //5 times check if pulled up
		for (byte i = 0;i < 5; i++) {
			SWVal[3] = analogRead(RateSWRight_PIN); delay(10);
			if (SWVal[3] > SectSWON) { delay(500); no++; }
		}//for
		if (no > 4) { RateSWRightEquiped = false; SWVal[3] = 500; }
	}
	//set up communication
	Serial.begin(BaudRate);

	//attachInterrupt(0, ISR, mode); //below is preferred method - most compatible
	if (RateControlLeftEquiped && !FlowEncALeft_PIN == 0) { RateAuto = true; attachInterrupt(digitalPinToInterrupt(FlowEncALeft_PIN), pinLeftChangeISR, CHANGE); }
	//attachInterrupt(0, ISR, mode); //below is preferred method - most compatible
	if (RateControlRightEquiped && !FlowEncARight_PIN == 0) { RateAuto = true; attachInterrupt(digitalPinToInterrupt(FlowEncARight_PIN), pinRightChangeISR, CHANGE); }

	Serial.flush();   // flush out buffer
	//PWM rate settings Adjust to desired PWM Rate
	//TCCR1B = TCCR1B & B11111000 | B00000010;    // set timer 1 divisor to     8 for PWM frequency of  3921.16 Hz
	TCCR1B = TCCR1B & B11111000 | B00000011;    // set timer 1 divisor to    64 for PWM frequency of   490.20 Hz (The DEFAULT)
} //end of setup

//------------------------------------------------------------------------------------------------------------------------------

void loop()
{
	currentTime = millis();
	unsigned int time = currentTime;

	//timed loop
	if ((currentTime - lastTime >= LOOP_TIME) || SectSWpressed)
	{
		dT = currentTime - lastTime;
		lastTime = currentTime;

		//reset ISR Left Side
		countsThisLoopLeft = pulseCountLeft;
		pulseCountLeft = 0;

		if (countsThisLoopLeft)
		{
			//total pulse time over counts in microseconds
			pulseAverageLeft = pulseDurationLeft / countsThisLoopLeft;
			pulseDurationLeft = 0;
		}

		//Right Side
		countsThisLoopRight = pulseCountRight;
		pulseCountRight = 0;

		if (countsThisLoopRight)
		{
			//total pulse time over counts in microseconds
			pulseAverageRight = pulseDurationRight / countsThisLoopRight;
			pulseDurationRight = 0;
		}

		//increase the watchdog - reset in data recv.
		watchdogTimer++;

		//clean out serial buffer
		if (watchdogTimer > 10)
		{
			while (Serial.available() > 0) char t = Serial.read();
			watchdogTimer = 0;
		}

		//accumulated counts from this cycle
		accumulatedCountsLeft += countsThisLoopLeft;
		accumulatedCountsRight += countsThisLoopRight;

		//only if section(s) are on and there is flow
		if (countsThisLoopLeft) {    //what is current flowrate from meter
			rateKLeft = (float)pulseAverageLeft * 0.001;
			if (rateKLeft < .001) rateKLeft = 0.1;//prevent divide by zero      //
			else rateKLeft = ((1.0 / rateKLeft) * 60) / flowmeterCalFactorLeft;

			//Kalman filter
			PcLeft = PLeft + varProcessLeft;
			GLeft = PcLeft / (PcLeft + varRateLeft);
			PLeft = (1 - GLeft) * PcLeft; XpLeft = XeRateLeft; ZpLeft = XpLeft;
			XeRateLeft = GLeft * (rateKLeft - ZpLeft) + XpLeft;

			rateAppliedLPMLeft = XeRateLeft * 100; //fill in formatted rateApplied
		}
		else {
			rateKLeft = 0.1;
			rateAppliedLPMLeft = 0;
		}

		//only if section(s) are on and there is flow
		if (countsThisLoopRight) {      //what is current flowrate from meter
			rateKRight = (float)pulseAverageRight * 0.001;
			if (rateKRight < .001) rateKRight = 0.1;//prevent divide by zero    //
			else rateKRight = ((1.0 / rateKRight) * 60) / flowmeterCalFactorRight;

			//Kalman filter
			PcRight = PRight + varProcessRight;
			GRight = PcRight / (PcRight + varRateRight);
			PRight = (1 - GRight) * PcRight; XpRight = XeRateRight; ZpRight = XpRight;
			XeRateRight = GRight * (rateKRight - ZpRight) + XpRight;

			rateAppliedLPMRight = XeRateRight * 100; //fill in formatted rateApplied
		}
		else {
			rateKRight = 0.1;
			rateAppliedLPMRight = 0;
		}

		//Do the PID - this placed in code depending on valve style
		rateErrorLeft = rateSetPointLeft - rateKLeft;
		rateErrorRight = rateSetPointRight - rateKRight;

		calcRatePID();
		if (RateAuto) { motorDrive(); }

		//Also needs right side TODO
		//calcRatePIDRight();
		//motorDriveRight();

		//Send to agopenGPS, once per second
		Serial.print(rateAppliedLPMLeft); //100 x actual!
		Serial.print(",");
		Serial.print(rateAppliedLPMRight); //100 x actual!
		Serial.print(",");
		Serial.print((int)((float)accumulatedCountsLeft / flowmeterCalFactorLeft)
			+ (int)((float)accumulatedCountsRight / flowmeterCalFactorRight));
		Serial.print(",");
		Serial.print(RelayToAOG[1]);
		Serial.print(",");
		Serial.print(RelayToAOG[0]);
		Serial.print(",");
		Serial.print(SectSWOffToAOG[1]);
		Serial.print(",");
		Serial.print(SectSWOffToAOG[0]);
		Serial.print(",");
		Serial.println(SectMainToAOG);

		//Serial.println( rateSetPoint );
		Serial.flush();   // flush out buffer
	} //end of timed loop

  //****************************************************************************************
	  //This runs continuously, outside of the timed loop, keeps checking UART for new data
	  // header high/low, relay byte, speed byte, rateSetPoint hi/lo

	if (SectSWequiped) { SectSWRead(); }
	else { RelayOUT[0] = RelayFromAOG[0]; RelayOUT[1] = RelayFromAOG[1]; } //checks if section switch is toggled
	if (RateSWLeftEquiped | RateSWRightEquiped) { RateSWRead(); }
	SetRelays();
	if (!RateAuto) { motorDrive(); } //if Manual do everytime, not only in timed loop

	if (Serial.available() > 0 && !isDataFound && !isSettingFound) //find the header,
	{
		int temp = Serial.read();
		header = tempHeader << 8 | temp;               //high,low bytes to make int
		tempHeader = temp;                             //save for next time
		if (header == 32762) isDataFound = true;     //Do we have a match?
		if (header == 32760) isSettingFound = true;     //Do we have a match?
	}

	//DATA Header has been found, so the next 8 bytes are the data -- 127H + 250L = 32762
	//32 Byte Data sentence
	if (Serial.available() == 8 && isDataFound)
	{
		isDataFound = false;
		RelayFromAOG[1] = Serial.read();   // read relay control from AgOpenGPS
		RelayFromAOG[0] = Serial.read();
		groundSpeed = Serial.read() >> 2;  //actual speed times 4, single byte
		rateSetPointLeft = (float)(Serial.read() << 8 | Serial.read());   rateSetPointLeft *= 0.01; //high,low bytes; sent as 100 times value in liters per minute
		rateSetPointRight = (float)(Serial.read() << 8 | Serial.read()); rateSetPointRight *= 0.01; //high,low bytes
		uTurnRelay = Serial.read();

		//reset watchdog as we just heard from AgOpenGPS
		watchdogTimer = 0;
		RelayFromAOGTime = millis();
	}

	//SETTINGS Header has been found, 6 bytes are the settings -- 127H + 248L = 32760
	if (Serial.available() == 6 && isSettingFound)
	{
		isSettingFound = false;  //reset the flag

		//accumulated volume, 0 it if this is 32700 sent
		float tempf = (float)(Serial.read() << 8 | Serial.read());   //high,low bytes
		if (tempf == 32700) accumulatedCountsDual = 0;

		//flow meter cal factor in counts per Liter
		flowmeterCalFactorLeft = ((float)(Serial.read() << 8 | Serial.read()));   //high,low bytes
		flowmeterCalFactorRight = ((float)(Serial.read() << 8 | Serial.read()));   //high,low bytes
	}
}//end of main

//------------------------------------------------------------------------------------------------------------------------------

 //ISR
void pinLeftChangeISR() {
	static unsigned long pulseStart = 0;
	pulseCountLeft++;

	state = !state;
	if (state)
	{
		// interrupt pin has risen, a pulse has started
		pulseStart = micros(); // store the current microseconds
	}
	else
	{    //risen again
		pulseDurationLeft = micros() - pulseStart; // get the pulse length
		pulseStart = 0;
	}
}

void pinRightChangeISR() {
	static unsigned long pulseStart = 0;
	pulseCountRight++;

	state = !state;
	if (state)
	{
		// interrupt pin has risen, a pulse has started
		pulseStart = micros(); // store the current microseconds
	}
	else
	{    //risen again
		pulseDurationRight = micros() - pulseStart; // get the pulse length
		pulseStart = 0;
	}
}