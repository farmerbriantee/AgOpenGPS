void SetRelays(byte HiByte, byte LoByte)
{
#if(UseMCP23017 == 1)
	if (bitRead(LoByte, 0)) mcp.digitalWrite(Relay1, HIGH); else mcp.digitalWrite(Relay1, LOW);
	if (bitRead(LoByte, 1)) mcp.digitalWrite(Relay2, HIGH); else mcp.digitalWrite(Relay2, LOW);
	if (bitRead(LoByte, 2)) mcp.digitalWrite(Relay3, HIGH); else mcp.digitalWrite(Relay3, LOW);
	if (bitRead(LoByte, 3)) mcp.digitalWrite(Relay4, HIGH); else mcp.digitalWrite(Relay4, LOW);
	if (bitRead(LoByte, 4)) mcp.digitalWrite(Relay5, HIGH); else mcp.digitalWrite(Relay5, LOW);
	if (bitRead(LoByte, 5)) mcp.digitalWrite(Relay6, HIGH); else mcp.digitalWrite(Relay6, LOW);
	if (bitRead(LoByte, 6)) mcp.digitalWrite(Relay7, HIGH); else mcp.digitalWrite(Relay7, LOW);

#if(UseSwitchedPowerPin == 0)
	if (bitRead(LoByte, 7)) mcp.digitalWrite(Relay8, HIGH); else mcp.digitalWrite(Relay8, LOW);
#endif

	if (bitRead(HiByte, 0)) mcp.digitalWrite(Relay9, HIGH); else mcp.digitalWrite(Relay9, LOW);
	if (bitRead(HiByte, 1)) mcp.digitalWrite(Relay10, HIGH); else mcp.digitalWrite(Relay10, LOW);
	if (bitRead(HiByte, 2)) mcp.digitalWrite(Relay11, HIGH); else mcp.digitalWrite(Relay11, LOW);
	if (bitRead(HiByte, 3)) mcp.digitalWrite(Relay12, HIGH); else mcp.digitalWrite(Relay12, LOW);
	if (bitRead(HiByte, 4)) mcp.digitalWrite(Relay13, HIGH); else mcp.digitalWrite(Relay13, LOW);
	if (bitRead(HiByte, 5)) mcp.digitalWrite(Relay14, HIGH); else mcp.digitalWrite(Relay14, LOW);
	if (bitRead(HiByte, 6)) mcp.digitalWrite(Relay15, HIGH); else mcp.digitalWrite(Relay15, LOW);
	if (bitRead(HiByte, 7)) mcp.digitalWrite(Relay16, HIGH); else mcp.digitalWrite(Relay16, LOW);

#else
	// use Nano pins
	if (bitRead(LoByte, 0)) digitalWrite(Relay1, HIGH); else digitalWrite(Relay1, LOW);
	if (bitRead(LoByte, 1)) digitalWrite(Relay2, HIGH); else digitalWrite(Relay2, LOW);
	if (bitRead(LoByte, 2)) digitalWrite(Relay3, HIGH); else digitalWrite(Relay3, LOW);

#if(UseSwitchedPowerPin == 0)
	if (bitRead(LoByte, 3)) digitalWrite(Relay4, HIGH); else digitalWrite(Relay4, LOW);
#endif

	//if (bitRead(LoByte, 4)) digitalWrite(Relay5, HIGH); else digitalWrite(Relay5, LOW);
	//if (bitRead(LoByte, 5)) digitalWrite(Relay6, HIGH); else digitalWrite(Relay6, LOW);
	//if (bitRead(LoByte, 6)) digitalWrite(Relay7, HIGH); else digitalWrite(Relay7, LOW);
	//if (bitRead(LoByte, 7)) digitalWrite(Relay8, HIGH); else digitalWrite(Relay8, LOW);
#endif
}
