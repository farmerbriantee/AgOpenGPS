void SetRelays(void)
{
	if (bitRead(RelayOUT[0], 0)) bitSet(PORTB, 5); //Digital Pin 13
	else bitClear(PORTB, 5);
	if (bitRead(RelayOUT[0], 1)) bitSet(PORTB, 2); //Digital Pin 10
	else bitClear(PORTB, 2);
	if (bitRead(RelayOUT[0], 2)) bitSet(PORTB, 1); //Digital Pin 9
	else bitClear(PORTB, 1);
	if (bitRead(RelayOUT[0], 3)) bitSet(PORTB, 0); //Digital Pin 8
	else bitClear(PORTB, 0);
	if (bitRead(RelayOUT[0], 4)) bitSet(PORTD, 7); //Digital Pin 7
	else bitClear(PORTD, 7);
	if (bitRead(RelayOUT[0], 5)) bitSet(PORTD, 6); //Digital Pin 6
	else bitClear(PORTD, 6);
	if (bitRead(RelayOUT[0], 6)) bitSet(PORTD, 5); //Digital Pin 5
	else bitClear(PORTD, 5);
}