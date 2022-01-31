void SectSWRead()
{
	SectSWcurrentTime = millis();

	SectSWOffToAOG[0] = 0;
	SectSWOffToAOG[1] = 0;

	//read all switches
	if (Set.debugmodeSwitches) Serial.println("reading Section switches:");
	for (int i = 0; i < Set.SectNum; i++)
	{
		if (Set.SectSW_PIN[i] < 255) { 
			SectSWVal[i] = digitalRead(Set.SectSW_PIN[i]); 
			//invert?
			if (!Set.SectSWAutoOrOn) { SectSWVal[i] = !SectSWVal[i]; }
		}
		else { SectSWVal[i] = HIGH; }//set auto if switch is missing
		if (Set.debugmodeSwitches) {
			Serial.print("  #"); Serial.print(i + 1); Serial.print(" "); Serial.print(SectSWVal[i]);
		}

	}
	if (Set.debugmodeSwitches) Serial.println();


	if (Set.SectMainSWType != 0) { MainSWVal = analogRead(Set.SectMainSW_PIN); }
	if (Set.debugmodeSwitches) { Serial.print("Main Switch value: "); Serial.println(MainSWVal); }

	AutoSWVal = digitalRead(Set.SectAutoManSW_PIN);
	if (Set.debugmodeSwitches) { Serial.print("Auto/Manual switch: "); Serial.println(AutoSWVal); }



	//AUTO / MAN SW
	if (AutoSWVal == LOW)  SectAuto = false; //pullup = auto if open or not connected
	else SectAuto = true;
	if (SectAuto != SectAutoOld)
	{
		if (!SectAutoSWpressed) { SectAutoSWTime = SectSWcurrentTime; } //catch time, first time switch is moved, delay to debounce
		SectAutoSWpressed = true;
		if (SectSWcurrentTime > SectAutoSWTime + SectSWDelayTime) { SectAutoSWpressed = false; SectAutoOld = SectAuto; }
	}

//Main ON/OFF	
	//checking MainSWType an "level" hitch level input to "normal" toggle switch values
	// 0 = not equiped 1 = (ON)-OFF-(ON) toggle switch or push buttons 2 = connected to hitch level sensor 3 = inverted hitch level sensor
	if (Set.SectMainSWType== 2)  
	{
		//using hitch sensor low value = hitch down = working -> so invert signal
		if (MainSWVal < Set.HitchLevelVal) { MainSWVal = SWON + 100; }
		else { MainSWVal = SWOFF - 100; }
		if (MainSWVal == MainSWValOld) { MainSWVal = ((SWOFF + SWON) / 2); }//set "switch" to middle, when same status as last time
		else { MainSWValOld = MainSWVal; } //first time when changed
	}
	if (Set.SectMainSWType == 3)  //3 = inverted hitch level sensor
	{
		//using hitch sensor high value = hitch down = working -> so fit signal level to standard
		if (MainSWVal > Set.HitchLevelVal) { MainSWVal = SWON + 100; }
		else { MainSWVal = SWOFF - 100; }
		if (MainSWVal == MainSWValOld) { MainSWVal = ((SWOFF + SWON) / 2); }//set "switch" to middle, when same status as last time
		else { MainSWValOld = MainSWVal; } //first time when changed
	}
	
	//if Main toggle switch pressed, use it for delay time and signal to AGO stays for SectSWDelayTime
	if (MainSWVal > SWON) { SectMainOn = true; SectMainSWpressed = true; SectMainSWlastTime = SectSWcurrentTime; }
	if (MainSWVal < SWOFF) { SectMainOn = false; SectMainSWpressed = true; SectMainSWlastTime = SectSWcurrentTime; }
	if (SectSWcurrentTime > SectMainSWlastTime + SectSWDelayTime) { SectMainSWpressed = false; }

	//if any section is spraying by AOG, and MainSW is not used set MainOn = ON, else OFF
	if (!SectMainSWpressed && SectAuto) {
		if ((SectGrFromAOG[0] > 0) || (SectGrFromAOG[1] > 0)) { SectMainOn = true; }
		else SectMainOn = false;
	}
	
	//Documentation only = set to manual, Main = ON so every section is on, or off by sections switch
	if (Set.DocOnly == 1) {
		SectAuto = false;
		SectMainOn = true;
	}

	//set relay bytes -----------------------
	//SectSWOffToAOGOld[0] = SectSWOffToAOG[0]; SectSWOffToAOGOld[1] = SectSWOffToAOG[1];
	SectSWOffToAOG[0] = 0; SectSWOffToAOG[1] = 0;
	byte a = 0;
	byte SectNumLoop = 0;
	boolean allDone = false;
	if (Set.SectNum > 8) { SectNumLoop = Set.SectNum - 8; a = 1; }
	else { SectNumLoop = Set.SectNum; a = 0; }
	do
	{
		for (int i = 0;i < SectNumLoop;i++) {
			if (SectSWVal[i + a * 8] == HIGH) {
				//ON or Open = pullup
				if (SectAuto) {
					//if auto then do what AOG says
					if (bitRead(SectGrFromAOG[a], i) == HIGH) { bitSet(RelayOUT[a], i); }
					else bitClear(RelayOUT[a], i);
				}
				else {
					//Manu
					if (SectMainOn) { bitSet(RelayOUT[a], i); }
					else bitClear(RelayOUT[a], i);
				} //else
			}//if on
			if (SectSWVal[i + a * 8] == LOW) {
				//switch OFF: Relays off, tell AOG: OFF
				bitClear(RelayOUT[a], i);
				bitSet(SectSWOffToAOG[a], i);
			}//if
		}//for 
		if (a > 0)//if more than 8 sections: run for loop again for byte [1]
		{a = 0; SectNumLoop = 8;}
		else { allDone = true; }
	}//while
	while (!allDone);

	//Set Bytes for AGO communication-------------------

	 //send Relais to AGO  !! x High/low Byte
	if (Set.aogVersion == 17) {
		if (!SectAuto) { SCToAOG[6] = RelayOUT[0]; SCToAOG[5] = RelayOUT[1]; }
		else { SCToAOG[6] = 0; SCToAOG[5] = 0; }
	}
	else {
		if (!SectAuto) { SCToAOG[9] = RelayOUT[0]; SCToAOG[11] = RelayOUT[1]; }
		else { SCToAOG[9] = 0; SCToAOG[11] = 0; }
	}

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
		if (Set.SectNum > 8)
		{
			for (byte k = 0; k < 8; k++) { bitSet(SectSWOffToAOG[0], k); }
			for (byte k = 7; k < Set.SectNum;k++) { bitSet(SectSWOffToAOG[1], k - 7); }
		}
		else for (byte k = 0; k < Set.SectNum;k++) { bitSet(SectSWOffToAOG[0], k); }
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
}//end of SectSWRead
