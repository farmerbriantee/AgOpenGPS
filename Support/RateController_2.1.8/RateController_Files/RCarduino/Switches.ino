#if(UseLocalSwitches)

void ReadSwitches()
{
	// SwitchPGN[2]
	Pins[0] = !digitalRead(SW0pin);			// 1
	Pins[1] = !digitalRead(SW1pin);			// 2
	Pins[2] = !digitalRead(SW2pin);			// 4
	Pins[3] = !digitalRead(SW3pin);			// 8

	// SwitchPGN[3]
	Pins[4] = !digitalRead(AutoPin);			// 1
	Pins[5] = !digitalRead(MasterOnPin);		// 2
	Pins[6] = !digitalRead(MasterOffPin);		// 4
	Pins[7] = !digitalRead(RateUpPin);			// 8
	Pins[8] = !digitalRead(RateDownPin);		// 16

	// build data
	SwitchPGN[2] = 0;
	SwitchPGN[3] = 0;

	for (int i = 0; i < 4; i++)
	{
		if (Pins[i]) SwitchPGN[2] = SwitchPGN[2] | (1 << i);
	}

	for (int i = 0; i < 5; i++)
	{
		if (Pins[i + 4]) SwitchPGN[3] = SwitchPGN[3] | (1 << i);
	}

	// PGN 32618
#if(CommType==1)
	// send UDP
	ether.sendUdp(SwitchPGN, sizeof(SwitchPGN), SourcePort, DestinationIP, DestinationPort);
#endif

	// send serial
	for (int i = 0; i < 4; i++)
	{
		Serial.print(SwitchPGN[i]);
		if (i < 3) Serial.print(",");
	}
	Serial.println();
	Serial.flush();
}

#endif
