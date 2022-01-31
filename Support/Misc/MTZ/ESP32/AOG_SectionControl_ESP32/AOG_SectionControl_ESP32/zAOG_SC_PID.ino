/*
contains rate control, not included in AOG actually

void Core1code(void * pvParameters) {
	for (;;)

		// MAIN LOOP FOR THIS CORE
	{
		//delay(0); //do WIFI stuff
		now = millis();
		unsigned int time = now;

		//timed loop
		if ((now - lastTime >= LOOP_TIME) || SectSWpressed)
		{
			dT = now - lastTime;
			lastTime = now;

			//reset ISR Left Side
			countsThisLoopLeft = pulseCountLeft;
			pulseCountLeft = 0;

			if (countsThisLoopLeft)
			{
				//total pulse time over counts in microseconds
				pulseAverageLeft = pulseDurationLeft / countsThisLoopLeft;
				pulseDurationLeft = 0;
			}

			//Right Side
			countsThisLoopRight = pulseCountRight;
			pulseCountRight = 0;

			if (countsThisLoopRight)
			{
				//total pulse time over counts in microseconds
				pulseAverageRight = pulseDurationRight / countsThisLoopRight;
				pulseDurationRight = 0;
			}

			//increase the watchdog - reset in data recv.
			watchdogTimer++;

			//clean out serial buffer
			if (watchdogTimer > 12)
			{
				while (Serial.available() > 0) char t = Serial.read();
				watchdogTimer = 0;
			}


			//accumulated counts from this cycle
			accumulatedCountsLeft += countsThisLoopLeft;
			accumulatedCountsRight += countsThisLoopRight;

			//only if section(s) are on and there is flow
			if (countsThisLoopLeft) {    //what is current flowrate from meter
				rateKLeft = (float)pulseAverageLeft * 0.001;
				if (rateKLeft < .001) rateKLeft = 0.1;//prevent divide by zero      //
				else rateKLeft = ((1.0 / rateKLeft) * 60) / flowmeterCalFactorLeft;

				//Kalman filter
				PcLeft = PLeft + varProcessLeft;
				GLeft = PcLeft / (PcLeft + varRateLeft);
				PLeft = (1 - GLeft) * PcLeft; XpLeft = XeRateLeft; ZpLeft = XpLeft;
				XeRateLeft = GLeft * (rateKLeft - ZpLeft) + XpLeft;

				rateAppliedLPMLeft = XeRateLeft * 100; //fill in formatted rateApplied
			}
			else {
				rateKLeft = 0.1;
				rateAppliedLPMLeft = 0;
			}

			//only if section(s) are on and there is flow
			if (countsThisLoopRight) {      //what is current flowrate from meter
				rateKRight = (float)pulseAverageRight * 0.001;
				if (rateKRight < .001) rateKRight = 0.1;//prevent divide by zero    //
				else rateKRight = ((1.0 / rateKRight) * 60) / flowmeterCalFactorRight;

				//Kalman filter
				PcRight = PRight + varProcessRight;
				GRight = PcRight / (PcRight + varRateRight);
				PRight = (1 - GRight) * PcRight; XpRight = XeRateRight; ZpRight = XpRight;
				XeRateRight = GRight * (rateKRight - ZpRight) + XpRight;

				rateAppliedLPMRight = XeRateRight * 100; //fill in formatted rateApplied
			}
			else {
				rateKRight = 0.1;
				rateAppliedLPMRight = 0;
			}

			//Do the PID - this placed in code depending on valve style
			rateErrorLeft = rateSetPointLeft - rateKLeft;
			rateErrorRight = rateSetPointRight - rateKRight;

			calcRatePID();
			if (Set. RateControlLeftInst) { motorDrive(); }

			//Also needs right side TODO
			//calcRatePIDRight();
			//motorDriveRight();

			SCToAOG[2] = rateAppliedLPMLeft; //100 x actual!;
			SCToAOG[3] = rateAppliedLPMRight; //100 x actual!
			SCToAOG[4] = (int)((float)accumulatedCountsLeft / flowmeterCalFactorLeft)
				+ (int)((float)accumulatedCountsRight / flowmeterCalFactorRight);



			//print for debug
			Serial.print("Bytes to AOG: ");
			for (byte i = 0; i < 10; i++) {
				Serial.print(SCToAOG[i]);
				Serial.print(",");
			}
			Serial.println();
			Serial.flush();   // flush out buffer

		} //end of timed loop

		//****************************************************************************************
		//This runs continuously, outside of the timed loop, keeps checking UART for new data
		// header high/low, relay byte, speed byte, rateSetPoint hi/lo



	}//end of main
}
*/





//-------------------------------------------------------------------------------------------------






/*

removed: actually no rate control in AOG


//pwm variables
int pwmDrive = 0, pwmDisplay = 0;
float pValue = 0, iValue = 0, dValue = 0, drive = 0, sumSpeed = 0;
byte minPWMValue = 10;

//PID variables
float Ko = 1.0f;  //overall gain
float Kp = 1.0f;  //proportional gain
float Ki = 0.0f;//integral gain
float Kd = 0.0f;  //derivative gain

				  //integral values - **** change as required *****
int   maxIntErr = 200; //anti windup max
int maxIntegralValue = 20; //max PWM value for integral PID component

						   //error values
float lastError = 0, lastLastError = 0, integrated_error = 0, dError = 0;

void calcRatePID(void) {
	//Proportional
	pValue = 0.35 * rateErrorLeft;// *Ko;
								  /*
								  //Integral
								  integrated_error = integrated_error + rateError;
								  if (integrated_error > maxIntErr) integrated_error = maxIntErr;
								  if (integrated_error < -maxIntErr) integrated_error = -maxIntErr;

								  //once it passes near center zero out the integrator error
								  if (steerAngleError > 0) steerCurrentSign = 1;
								  else steerCurrentSign = 0;

								  //did we cross zero?
								  if (steerCurrentSign - steerPrevSign) integrated_error = 0; //zero out the integrator
								  steerPrevSign = steerCurrentSign;  //save a copy for next time

								  iValue = Ki * integrated_error;
								  if (iValue > maxIntegralValue) iValue = maxIntegralValue;
								  if (iValue < -maxIntegralValue) iValue = -maxIntegralValue;

								  //Derivative
								  dError = steerAngleError - lastLastError;
								  dValue = Kd * (dError) * Ko;

								  //save history of errors
								  lastLastError = lastError;
								  lastError = steerAngleError;
								  */
/*
	drive = pValue + dValue + iValue;

	sumSpeed += drive;
	sumSpeed = (constrain(sumSpeed, 0, 70));

	pwmDrive = int(sumSpeed);
	pwmDisplay = pwmDrive;
}

*/