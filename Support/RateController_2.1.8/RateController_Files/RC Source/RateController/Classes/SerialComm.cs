using System;
using System.IO.Ports;

namespace RateController
{
    public class SerialComm
    {
        public SerialPort ArduinoPort = new SerialPort("RCport", 38400, Parity.None, 8, StopBits.One);
        public int RCportBaud = 38400;
        public string RCportName;
        private readonly FormStart mf;
        private int cPortNumber;

        private byte HiByte;
        private byte LoByte;
        private bool SerialActive = false;  // prevents UI lock-up by only sending serial data after verfying connection
        String ID;

        public SerialComm(FormStart CallingForm, int PortNumber)
        {
            mf = CallingForm;
            cPortNumber = PortNumber;
            RCportName = "RCport" + cPortNumber.ToString();
            ID = "_" + PortNumber.ToString() + "_";
        }

        // new data event
        public delegate void NewDataDelegate(string Sentence);

        public void CloseRCport()
        {
            try
            {
                if (ArduinoPort.IsOpen)
                {
                    ArduinoPort.DataReceived -= RCport_DataReceived;
                    try
                    {
                        ArduinoPort.Close();
                    }
                    catch (Exception e)
                    {
                        mf.Tls.TimedMessageBox("Could not close serial port.", e.Message, 3000, true);
                    }

                    mf.Tls.SaveProperty("RCportSuccessful"+ID + cPortNumber.ToString(), "false");

                    ArduinoPort.Dispose();
                }
            }
            catch (Exception ex)
            {
                mf.Tls.WriteErrorLog("SerialComm/CloseRCport: " + ex.Message);
            }
        }

        public void OpenRCport()
        {
            try
            {
                if (SerialPortExists(RCportName))
                {
                    if (!ArduinoPort.IsOpen)
                    {
                        ArduinoPort.PortName = RCportName;
                        ArduinoPort.BaudRate = RCportBaud;
                        ArduinoPort.DataReceived += RCport_DataReceived;
                        ArduinoPort.DtrEnable = true;
                        ArduinoPort.RtsEnable = true;

                        try
                        {
                            ArduinoPort.Open();
                        }
                        catch (Exception e)
                        {
                            mf.Tls.TimedMessageBox("Could not open serial port.", e.Message, 3000, true);

                            mf.Tls.SaveProperty("RCportSuccessful"+ID + cPortNumber.ToString(), "false");
                        }
                    }

                    if (ArduinoPort.IsOpen)
                    {
                        ArduinoPort.DiscardOutBuffer();
                        ArduinoPort.DiscardInBuffer();

                        mf.Tls.SaveProperty("RCportName"+ID + cPortNumber.ToString(), RCportName);
                        mf.Tls.SaveProperty("RCportSuccessful"+ID + cPortNumber.ToString(), "true");
                        mf.Tls.SaveProperty("RCportBaud"+ID + cPortNumber.ToString(), RCportBaud.ToString());
                    }
                }
                else
                {
                    mf.Tls.TimedMessageBox("Could not open serial port.", "", 3000, true);

                    mf.Tls.SaveProperty("RCportSuccessful"+ID + cPortNumber.ToString(), "false");
                }
            }
            catch (Exception ex)
            {
                mf.Tls.WriteErrorLog("SerialComm/OpenRCport: " + ex.Message);
            }
        }

        public void SendData(byte[] Data)
        {
            // send to arduino rate controller
            if (ArduinoPort.IsOpen & SerialActive)
            {
                try
                {
                    ArduinoPort.Write(Data, 0, Data.Length);
                }
                catch (Exception ex)
                {
                    mf.Tls.WriteErrorLog("SerialComm/SendData: " + ex.Message);
                }
            }
        }

        private void ReceiveData(string sentence)
        {
            try
            {
                // look for ',' and '\r'. Return if not found
                int end = sentence.IndexOf(",", StringComparison.Ordinal);
                if (end == -1) return;

                end = sentence.IndexOf("\r");
                if (end == -1) return;

                sentence = sentence.Substring(0, end);
                string[] words = sentence.Split(',');

                if (words.Length > 1)
                {
                    if (byte.TryParse(words[0], out HiByte))
                    {
                        if (byte.TryParse(words[1], out LoByte))
                        {
                            int PGN = HiByte << 8 | LoByte;

                            switch (PGN)
                            {
                                case 32618:
                                    if (mf.SwitchBox.ParseStringData(words)) SerialActive = true;
                                    break;

                                case 32613:
                                    foreach (clsProduct Prod in mf.Products.Items)
                                    {
                                        if (Prod.SerialFromAruduino(words)) SerialActive = true;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mf.Tls.WriteErrorLog("SerialComm/ReceiveData: " + ex.Message);
            }
        }

        private void RCport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (ArduinoPort.IsOpen)
            {
                try
                {
                    string sentence = ArduinoPort.ReadLine();
                    mf.BeginInvoke(new NewDataDelegate(ReceiveData), sentence);
                    if (ArduinoPort.BytesToRead > 32) ArduinoPort.DiscardInBuffer();
                }
                catch (Exception ex)
                {
                    mf.Tls.WriteErrorLog("SerialComm/RCport_DataReceived: " + ex.Message);
                }
            }
        }

        private bool SerialPortExists(string PortName)
        {
            bool Result = false;
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
            {
                if (s == PortName)
                {
                    Result = true;
                    break;
                }
            }
            return Result;
        }
    }
}