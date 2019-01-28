void SectSWRead()
{
	SectSWcurrentTime = millis();

	SectSWOffToAOG[0] = 0;
	SectSWOffToAOG[1] = 0;
	//  for (int i=0 ; i<16; i++){SWVal[i] = 1000;}

	  //read switches, if switches are at digital input simulate analog by setting higher values ------------
	SectSWVal[0] = analogRead(SectSW_PIN0);
	SectSWVal[1] = analogRead(SectSW_PIN1);
	SectSWVal[2] = analogRead(SectSW_PIN2);
	SectSWVal[3] = analogRead(SectSW_PIN3);
	SectSWVal[4] = analogRead(SectSW_PIN4);
	SectSWVal[5] = analogRead(SectSW_PIN5);
	SectSWVal[6] = digitalRead(SectSW_PIN6);
	if (SectSWVal[6] == HIGH) { SectSWVal[6] = 1000; }
	else SectSWVal[6] = 1;
	SWVal[0] = analogRead(SectMainSW_PIN);
	SWVal[1] = digitalRead(SectAutoManSW_PIN);
	if (SWVal[1] == HIGH) { SWVal[1] = 1000; }
	else SWVal[1] = 1;
	SWVal[2] = analogRead(RateSWLeft_PIN);

	//AUTO / MAN SW
	if (SWVal[1] > SectSWON) { SectAuto = true; }
	if (SWVal[1] < SectSWOFF) { SectAuto = false; }
	if (SectAuto != SectAutoOld)
	{
		if (!SectAutoSWpressed) { SectAutoSWTime = SectSWcurrentTime; delay(5); } //catch time, first time switch is moved, delay to debounce
		SectAutoSWpressed = true;
		if (SectSWcurrentTime > SectAutoSWTime + SectSWDelayTime) { SectAutoSWpressed = false; SectAutoOld = SectAuto; }
	}

	//Main ON/OFF
	//if any section is spraying by AOG, and MainSW is not used set MainOn = ON, else OFF
	if (!SectMainSWpressed && SectAuto) {
		if ((RelayFromAOG[0] > 0) || (RelayFromAOG[1] > 0)) { SectMainOn = true; }
		else SectMainOn = false;
	}

	//if Main toggle switch pressed, use it for delay time and signal to AGO stays for SectSWDelayTime
	if (SWVal[0] > SectSWON) { SectMainOn = true; SectMainSWpressed = true; SectMainSWlastTime = SectSWcurrentTime; }
	if (SWVal[0] < SectSWOFF) { SectMainOn = false; SectMainSWpressed = true; SectMainSWlastTime = SectSWcurrentTime; }
	if (SectSWcurrentTime > SectMainSWlastTime + SectSWDelayTime) { SectMainSWpressed = false; }

	//set relay bytes -----------------------
	SectSWOffToAOGOld[0] = SectSWOffToAOG[0]; SectSWOffToAOGOld[1] = SectSWOffToAOG[1];
	SectSWOffToAOG[0] = 0;
	byte a = 0;
	byte SectNumLoop = 0;
	boolean allDone = false;
	if (SectNum > 8) { SectNumLoop = SectNum - 8; a = 1; }
	else { SectNumLoop = SectNum; a = 0; }
	do
	{
		for (int i = 0;i < SectNumLoop;i++) {
			if (SectSWVal[i + a * 8] > SectSWON) {
				//ON or Open = pullup
				if (SectAuto) {
					//if auto then do what AOG says
					if (bitRead(RelayFromAOG[a], i) == HIGH) { bitSet(RelayOUT[a], i); }
					else bitClear(RelayOUT[a], i);
				}
				else {
					//Manu
					if (SectMainOn) { bitSet(RelayOUT[a], i); }
					else bitClear(RelayOUT[a], i);
				} //else
			}//if on
			if (SectSWVal[i + a * 8] < SectSWOFF) {
				//switch OFF: Relays off, tell AOG: OFF
				bitClear(RelayOUT[a], i);
				bitSet(SectSWOffToAOG[a], i);
			}//if
		}//for
		if (a > 0)
		{
			a = 0; SectNumLoop = 8;
		}
		else { allDone = true; }
	}//while
	while (!allDone);

	//Set Bytes for AGO communication-------------------

	 //send Relais to AGO
	if (!SectAuto) { RelayToAOG[0] = RelayOUT[0]; RelayToAOG[1] = RelayOUT[1]; }
	else { RelayToAOG[0] = 0; RelayToAOG[1] = 0; }

	//Set Main SW Bits
	bitClear(SectMainToAOG, 0);
	bitClear(SectMainToAOG, 1);
	//if Main sw moved send to AOG
	if (SectMainSWpressed) {
		if (SectMainOn && SectAuto) { bitSet(SectMainToAOG, 0); }
		if (!SectMainOn) { bitSet(SectMainToAOG, 1); }
	}

	//MAN and all sections OFF by MAIN then send SW OFF to AOG
	if (!SectAuto && !SectMainOn) {
		if (SectNum > 8)
		{
			for (byte k = 0; k < 8; k++) { bitSet(SectSWOffToAOG[0], k); } for (byte k = 7; k < SectNum;k++) { bitSet(SectSWOffToAOG[1], k - 7); }
		}
		else for (byte k = 0; k < SectNum;k++) { bitSet(SectSWOffToAOG[0], k); }
	}

	//if AUTO/Man SW moved to Auto and Main on, send Main on to AOG to turn all auto and wait for new RelayByte
	if (SectAutoSWpressed && SectAuto && SectMainOn)
	{
		bitSet(SectMainToAOG, 0); RelayOUT[0] = RelayOUTOld[0];RelayOUT[1] = RelayOUTOld[1];
	}
	//if AUTO/Man SW moved to Manu and Main on, keep spraying same sections for delaytime then
	if (SectAutoSWpressed && !SectAuto && SectMainOn)
	{
		RelayOUT[0] = RelayOUTOld[0];RelayOUT[1] = RelayOUTOld[1];
	}
	if (!SectAutoSWpressed) { RelayOUTOld[0] = RelayOUT[0];RelayOUTOld[1] = RelayOUT[1]; }

	//if AUTO/Man SW moved to MAN, send Main on to AOG to turn all off
	if (SectAutoSWpressed && !SectAuto && !SectMainOn)
	{
		bitClear(SectMainToAOG, 0); bitSet(SectMainToAOG, 1); RelayOUT[0] = 0;RelayOUT[1] = 0;
	}

	/*
	 *  good idea, but didn't work// check if anything changed to speed up communication (in timed loop, void loop)
	 if ((RelayToAOG[0] != RelayToAOGOld[0]) ||(RelayToAOG[1] != RelayToAOGOld[1])
		   || (SectSWOffToAOG[0] != SectSWOffToAOGOld[0]) || (SectSWOffToAOG[1] != SectSWOffToAOGOld[1])
		   || SectMainSWpressed)
		  { if (SectSWpressedLoop) {SectSWpressed = false;}
			if (!SectSWpressed && !SectSWpressedLoop) {SectSWpressed = true; SectSWpressedLoop = true;}
		  }
		  else SectSWpressedLoop = false;
   */
}//end of SectSWRead