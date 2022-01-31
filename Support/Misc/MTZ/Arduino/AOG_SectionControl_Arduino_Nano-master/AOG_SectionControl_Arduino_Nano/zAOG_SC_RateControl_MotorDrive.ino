void motorDrive(void)
{
	if (Set.RateControlLeftInst == 1) {
	//if (pwmDrive > 0) bitSet(PORTB, 4);  //set the correct direction
	//analogWrite(Set.FlowPWMLeft_PIN, pwmDrive);
	}
	else 
	//manual motor drive
	{
		if (Set.RateControlPWM == 0)
		{	//if rate switch is toggled -> set Output high
			if (RateManUpLeft) { 
				digitalWrite(Set.FlowDirLeft_PIN, HIGH); digitalWrite(Set.FlowPWMLeft_PIN, HIGH); 
				if (Set.debugmode || Set.debugmodeRelay) { Serial.println("Rate left manual up"); }
				}
			if (RateManDownLeft) {
				digitalWrite(Set.FlowDirLeft_PIN, LOW); digitalWrite(Set.FlowPWMLeft_PIN, HIGH);
				if (Set.debugmode || Set.debugmodeRelay) { Serial.println("Rate left manual down"); }
			}
			if (RateManUpRight) { digitalWrite(Set.FlowDirRight_PIN, HIGH); digitalWrite(Set.FlowPWMRight_PIN, HIGH); }
			if (RateManDownRight) { digitalWrite(Set.FlowDirRight_PIN, LOW); digitalWrite(Set.FlowPWMRight_PIN, HIGH); }
			//toggle switch not pressed = set all low
			if (!(RateManUpLeft || RateManDownLeft || RateManUpRight || RateManDownRight))
				{ digitalWrite(Set.FlowDirRight_PIN, LOW); digitalWrite(Set.FlowPWMRight_PIN, LOW); digitalWrite(Set.FlowDirLeft_PIN, LOW); digitalWrite(Set.FlowPWMLeft_PIN, LOW);
				}
			
		}
	}
}
