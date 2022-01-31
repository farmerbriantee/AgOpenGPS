void SetRelays(void)
{
	if (Set.SectNum > 8) {
		for (byte i = 0; i < 8; i++)
		{
			if (bitRead(RelayOUT[0], i) == LOW) {
				digitalWrite(Set.Relay_PIN[i], !Set.SectRelaysON);
			}
			else {
				digitalWrite(Set.Relay_PIN[i], Set.SectRelaysON);
			}
		}
		for (byte i = 8; i < Set.SectNum; i++)
		{
			if (bitRead(RelayOUT[1], (i - 8)) == LOW) {
				digitalWrite(Set.Relay_PIN[i], !Set.SectRelaysON);
			}
			else {
				digitalWrite(Set.Relay_PIN[i], Set.SectRelaysON);
			}
		}
		if (Set.debugmodeRelay) {
			Serial.print("numbSect: "); Serial.print(Set.SectNum);
			Serial.print("  byte Relays 16-8: "); Serial.print(RelayOUT[1]);
			Serial.print("  byte Relays 8-1: "); Serial.println(RelayOUT[0]);
		}
	}
	else
	{
		for (byte i = 0; i < Set.SectNum; i++)
		{
			if (bitRead(RelayOUT[0], i) == LOW) {
				digitalWrite(Set.Relay_PIN[i], !Set.SectRelaysON);
			}
			else {
				digitalWrite(Set.Relay_PIN[i], Set.SectRelaysON);
			}
		}
		//Serial.println(RelayOUT[0]);
	}
	if (Set.Relais_MainValve_PIN != 255) {//main valve
		if ((RelayOUT[0] > 0) || (RelayOUT[1] > 0)) { digitalWrite(Set.Relais_MainValve_PIN, Set.SectRelaysON); }
		else { digitalWrite(Set.Relais_MainValve_PIN, !Set.SectRelaysON); }
	}
}
