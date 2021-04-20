void RateSWRead()
{
	SectSWcurrentTime = millis();
	RateSWLeftVal = analogRead(Set.RateSWLeft_PIN);

	//left pressed to low
	if (RateSWLeftVal < SWOFF)
	{
		if (Set.RateControlLeftInst == 1)
		{
			if (SectSWcurrentTime > RateSWlastTimeLeft + RateSWDelayTime) 
			{
				//time passed, so new Data to AOG: set Bits[3+2]: 00 -> 01 -> 10 -> 11
				if (bitRead(SectMainToAOG, 2)) 
				{
					if (!bitRead(SectMainToAOG, 3)) { bitSet(SectMainToAOG, 3);bitClear(SectMainToAOG, 2); }
				}
				else bitSet(SectMainToAOG, 2);

				//LOWER: Bit[5] = 0
				bitClear(SectMainToAOG, 5);
				RateSWlastTimeLeft = SectSWcurrentTime;
			}
		}
		else 
		{ //Manual Rate
			RateManDownLeft = true; RateManUpLeft = false;
		}
	}

	//pressed to high
	if (RateSWLeftVal > SWON)
		{
		if (Set.RateControlLeftInst == 1)
			{
				if (SectSWcurrentTime > RateSWlastTimeLeft + RateSWDelayTime) 
				{
					//time passed, so new Data to AOG: set Bits[3+2]: 00 -> 01 -> 10 -> 11
					if (bitRead(SectMainToAOG, 2)) 
					{
						if (!bitRead(SectMainToAOG, 3)) { bitSet(SectMainToAOG, 3);bitClear(SectMainToAOG, 2); }
					}
					else  bitSet(SectMainToAOG, 2);

					//higher: Bit[5] = 1
					bitSet(SectMainToAOG, 5);
					RateSWlastTimeLeft = SectSWcurrentTime;
				}
			}
			else 
			{ //Manual Rate
				RateManDownLeft = false; RateManUpLeft = true;
			}
		}

		//not pressed = middle
		if ((RateSWLeftVal < SWON) && (RateSWLeftVal> SWOFF))
		{
			RateManDownLeft = false; RateManUpLeft = false;


/*			rate control not processed in AOG
			
			//hold signal for Delay Time to make AOG see it
			if (SectSWcurrentTime > RateSWlastTimeLeft + SectSWDelayTime)
			{
				bitClear(SectMainToAOG, 2);
				bitClear(SectMainToAOG, 3);
				bitClear(SectMainToAOG, 4);
				bitClear(SectMainToAOG, 5);
			}*/
		}
	// not send imideately to bundle long press or a cupple of presses to the Bit[2+3], so SectSWpressed not used
} //end of RateSWRead
