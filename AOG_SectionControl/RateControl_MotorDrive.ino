void motorDrive(void)
{
	if (RateAuto) {
		if (pwmDrive > 0) bitSet(PORTB, 4);  //set the correct direction
		analogWrite(FlowPWMLeft_PIN, pwmDrive);
	}
	else {
		if (!RateControlPWM) {
			if (RateManUpLeft) { digitalWrite(FlowDirLeft_PIN, HIGH); digitalWrite(FlowPWMLeft_PIN, HIGH); }
			if (RateManDownLeft) { digitalWrite(FlowDirLeft_PIN, LOW); digitalWrite(FlowPWMLeft_PIN, HIGH); }
			if (RateManUpRight) { digitalWrite(FlowDirRight_PIN, HIGH); digitalWrite(FlowPWMRight_PIN, HIGH); }
			if (RateManDownRight) { digitalWrite(FlowDirRight_PIN, LOW); digitalWrite(FlowPWMRight_PIN, HIGH); }
			if (!(RateManUpLeft | RateManDownLeft | RateManUpRight | RateManDownRight))
			{
				digitalWrite(FlowDirRight_PIN, LOW); digitalWrite(FlowPWMRight_PIN, LOW); digitalWrite(FlowDirLeft_PIN, LOW); digitalWrite(FlowPWMLeft_PIN, LOW);
			}
		}
	}
}