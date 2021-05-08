
// https://www.k-state.edu/precisionag/variable-rate/automatic-section-control/index.html
// https://talk.newagtalk.com/forums/thread-view.asp?tid=82927&mid=594748#M594748
// http://ravenprecision.force.com/knowledgebase/articles/Tech_Tip/Valve-Cal-Number-Explained/?q=valve+cal&l=en_US&fs=Search&pn=1

// VCN - valve cal number
// four digit number can be represented by A B C D
// A is Backlash (1-9). It is a pulse of electricity to account for slack
//   in the adjustment components when changing direction. 1 is a short
//   pulse and 9 is a long pulse.
// 
// B is Speed (0-9). It is the speed of adjustment. 0 (fast) 12V, 9 (slow) 
//   1.2V.
//
// C is Brake Point (0-9). It is the % away from the target rate where
//   the speed of adjustment changes to a preset low rate. 0 - 5%, 1 - 10%
//   9 - 90%
//
// D is Deadband (1-9). It is the allowable error % where no adjustment
//   is made.
//
// Example: VCN (0)743
//	0 - backlash not used
//	7 - ajustment speed, about 3.6V
//  4 - brake point, at 40% away from target rate speed is reduced
//  3 - deadband 3%

long OldVCN;
byte VCNbacklash;	// A
byte VCNspeed;		// B
byte VCNbrake;		// C
byte VCNdeadband;	// D

int NewPWM;
unsigned long SendStart[SensorCount];
unsigned long WaitStart[SensorCount];

byte AdjustmentState[] = {0,0};		// 0 waiting, 1 sending pwm
bool LastDirectionPositive[SensorCount];		// adjustment direction
bool UseBacklashAdjustment[SensorCount];

int PartsTemp;

int VCNpwm(float cError, float cSetPoint, byte MinPWM, byte MaxPWM, long cVCN,
	float cFlowRate, long cSendTime, long cWaitTime, byte cSlowSpeed, byte cControlType, byte SensorID)
{
	NewPWM = 0;
	if (FlowEnabled[SensorID])
	{
		VCNparts(cVCN);

		// deadband
		float DB = (float)(VCNdeadband / 100.0) * cSetPoint;

		if (abs(cError) > DB)
		{
			// backlash
			if (!UseBacklashAdjustment[SensorID] && VCNbacklash > 0)
			{
				if ((cError >= 0 && !LastDirectionPositive[SensorID]) || (cError < 0 && LastDirectionPositive[SensorID]))
				{
					// direction changed, use backlash adjustment
					UseBacklashAdjustment[SensorID] = true;
					SendStart[SensorID] = millis();
				}
				LastDirectionPositive[SensorID] = (cError >= 0);
			}

			if (UseBacklashAdjustment[SensorID])
			{
				// backlash adjustment
				if (millis() - SendStart[SensorID] > (VCNbacklash * 10))
				{
					// backlash adjustment finished
					UseBacklashAdjustment[SensorID] = false;
					LastDirectionPositive[SensorID] = (cError >= 0);
					SendStart[SensorID] = millis();
				}
				else
				{
					NewPWM = MaxPWM - ((MaxPWM - MinPWM) * cSlowSpeed / 9);
					if (cError < 0) NewPWM *= -1;
				}
			}
			else
			{
				// regular adjustment
				if (AdjustmentState[SensorID] == 0)
				{
					// waiting
					if (millis() - WaitStart[SensorID] > cWaitTime)
					{
						// waiting finished
						AdjustmentState[SensorID] = 1;
						SendStart[SensorID] = millis();
					}
				}

				if (AdjustmentState[SensorID] == 1)
				{
					// sending pwm
					if (millis() - SendStart[SensorID] > cSendTime)
					{
						// sending finished
						AdjustmentState[SensorID] = 0;
						WaitStart[SensorID] = millis();
						NewPWM = 0;
					}
					else
					{
						// get new pwm value to send
						if (cFlowRate == 0 && cControlType == 1)
						{
							// open Raven 'fast close' valve
							NewPWM = MaxPWM;
						}
						else
						{
							if (cSetPoint > 0)
							{
								float ErrorPercent = cError / cSetPoint;
								if (ErrorPercent < VCNbrake / 100.0)
								{
									NewPWM = ErrorPercent * MaxPWM * (10 - cSlowSpeed) * 2.0;
								}
								else
								{
									NewPWM = ErrorPercent * MaxPWM * (10 - VCNspeed) * 2.0;
								}
							}
							int dir = 1;
							if (NewPWM < 0)dir = -1;
							NewPWM = abs(NewPWM);
							if (NewPWM < MinPWM)NewPWM = MinPWM;
							if (NewPWM > MaxPWM)NewPWM = MaxPWM;
							NewPWM *= dir;
						}
					}
				}
			}
		}
	}
	return NewPWM;
}

void VCNparts(long NewVCN)
{
	if ((NewVCN != OldVCN) && (NewVCN <= 9999) && (NewVCN >= 0))
	{
		VCNbacklash = NewVCN / 1000;
		PartsTemp = NewVCN - VCNbacklash * 1000;

		VCNspeed = PartsTemp / 100;
		PartsTemp = PartsTemp - VCNspeed * 100;

		VCNbrake = PartsTemp / 10;

		VCNdeadband = PartsTemp - VCNbrake * 10;

		VCNbrake *= 10;
		if (VCNbrake == 0) VCNbrake = 5;

		OldVCN = NewVCN;
	}
}
