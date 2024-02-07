using System;
using System.Management;

//Class written and inspired by Andy
public class CWindowsSettingsBrightnessController
{
    public bool isWmiMonitor;

    public CWindowsSettingsBrightnessController(bool isOn)
    {
        if (isOn)
        {
            if (Get() == -1)
                isWmiMonitor = false;
            else isWmiMonitor = true;
        }
        else
            isWmiMonitor = false;
    }

    private int Get()
    {
        try // this will fail if not a device with controllable brightness (eg, a desktop)
        {
            var mclass = new ManagementClass("WmiMonitorBrightness")
            {
                Scope = new ManagementScope(@"\\.\root\wmi")
            };
            var instances = mclass.GetInstances();
            foreach (ManagementObject instance in instances)
            {
                return (byte)instance.GetPropertyValue("CurrentBrightness");
            }
            return 0;
        }
        catch
        {
            return -1; // check this and disable the buttons if not available
        }
    }

    private void Set(int brightness)
    {
        try // and so will this
        {
            var mclass = new ManagementClass("WmiMonitorBrightnessMethods")
            {
                Scope = new ManagementScope(@"\\.\root\wmi")
            };
            var instances = mclass.GetInstances();
            var args = new object[] { 1, brightness };
            foreach (ManagementObject instance in instances)
            {
                instance.InvokeMethod("WmiSetBrightness", args);
            }
        }
        catch
        {
            // meh, don't care
        }
    }

    public void BrightnessIncrease()
    {
        if (isWmiMonitor) Set(Math.Min(100, Get() + 10));
    }

    public void BrightnessDecrease()
    {
        if (isWmiMonitor) Set(Math.Max(10, Get() - 10));
    }

    public int GetBrightness()
    {
        if (isWmiMonitor) return Get();
        else return -1;
    }

    public void SetBrightness(int bright)
    {
        if (isWmiMonitor) Set(bright);
    }
}