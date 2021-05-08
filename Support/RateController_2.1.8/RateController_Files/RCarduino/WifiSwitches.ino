
void TranslateSwitchBytes()
{
    // Switch IDs from Rate Controller
    // byte 0, bits 0,1 = Switch 0 ID, bits 2,3 = Switch 1 ID
    // byte 0, bits 4,5 = Switch 2 ID, bits 6,7 = Switch 3 ID
    // bytes 1-3 for switches 4-15

    for (int i = 0; i < 16; i++)
    {
        byte Count = i / 4;
        byte Mask = 3 << (2 * (i - 4 * Count));
        SwitchID[i] = SwitchBytes[Count] & Mask;
        SwitchID[i] = SwitchID[i] >> (2 * (i - 4 * Count));
    }
}

void SetRelaysWifi()
{
    if (WifiSwitches[4])
    {
        // master on
        byte HiByte = 0;
        byte LoByte = 0;
        bool PinState;

        for (int i = 0; i < 16; i++)
        {
            switch (SwitchID[i])
            {
            case 0:
                PinState = WifiSwitches[0];
                break;
            case 1:
                PinState = WifiSwitches[1];
                break;
            case 2:
                PinState = WifiSwitches[2];
                break;
            case 3:
                PinState = WifiSwitches[3];
                break;
            default:
                PinState = false;
                break;
            }
            if (i < 8)
            {
                // LoByte
                if (PinState) bitSet(LoByte, i);
            }
            else
            {
                // HiByte
                if (PinState) bitSet(HiByte, i - 8);
            }
        }

        SetRelays(HiByte, LoByte);
    }
    else
    {
        // master off
        SetRelays(0, 0);
        WifiSwitchesEnabled = false;
    }
}


