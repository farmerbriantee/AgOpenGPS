void motorDrive()
{
    for (int i = 0; i < SensorCount; i++)
    {
        switch (ControlType[i])
        {
        case 1:
            // fast close valve, used for flow control and on/off
            if (FlowEnabled[i])
            {
                if (pwmSetting[i] >= 0)
                {
                    //increase
                    digitalWrite(FlowDir[i], FlowOn[i]);
                    analogWrite(FlowPWM[i], pwmSetting[i]);
                }
                else
                {
                    //decrease
                    digitalWrite(FlowDir[i], !FlowOn[i]);
                    analogWrite(FlowPWM[i], -pwmSetting[i]);	// offsets the negative pwm value
                }
            }
            else
            {
                // stop flow
                analogWrite(FlowPWM[i], 255);
                digitalWrite(FlowDir[i], !FlowOn);
            }
            break;
        case 2:
            // motor control
            if (FlowEnabled[i])
            {
                if (pwmSetting[i] >= 0)
                {
                    //increase
                    digitalWrite(FlowDir[i], FlowOn[i]);
                    analogWrite(FlowPWM[i], pwmSetting[i]);
                }
                else
                {
                    //decrease
                    digitalWrite(FlowDir[i], !FlowOn[i]);
                    analogWrite(FlowPWM[i], -pwmSetting[i]);	// offsets the negative pwm value
                }
            }
            else
            {
                // stop motor
                analogWrite(FlowPWM[i], 0);
            }
            break;
        default:
            // standard valve, flow control only
            if (pwmSetting[i] >= 0)
            {
                //increase
                digitalWrite(FlowDir[i], FlowOn[i]);
                analogWrite(FlowPWM[i], pwmSetting[i]);
            }
            else
            {
                //decrease
                digitalWrite(FlowDir[i], !FlowOn[i]);
                analogWrite(FlowPWM[i], -pwmSetting[i]);	// offsets the negative pwm value
            }
            break;
        }
    }
}
