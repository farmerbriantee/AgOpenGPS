/*
// these voids are called when an interrupt is triggerd, the Interrups are defined in PIN alignment
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
*/