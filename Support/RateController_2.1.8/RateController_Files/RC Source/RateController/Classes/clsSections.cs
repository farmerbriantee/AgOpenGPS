using System;
using System.Collections.Generic;
using System.Timers;
using System.Diagnostics;

namespace RateController
{
    public class clsSections
    {
        public IList<clsSection> Items;
        private List<clsSection> cSections = new List<clsSection>();
        private float[] cProdWorkedArea_ha = new float[16];

        private float cWorkingWidth_cm;

        private FormStart mf;

        //public PGN32618 SwitchBox;
        // switches
        // 0    switch 0
        // 1    switch 1
        // 2    switch 2
        // 3    switch 3
        // 4    Auto
        // 5    Master on
        // 6    Master off
        // 7    Rate up
        // 8    Rate down

        bool[] SwON = new bool[9];

        private DateTime SWreadTime;
        private DateTime RateLastTime;
        private int EraseDelay = 250;
        private int StepDelay = 1000;   // ms between adjustments

        // sent back to AOG
        byte OutCommand;
        byte OutLast;
        byte[] SectionOnFromAOG = new byte[2];
        byte[] SectionOnToAOG = new byte[2];
        byte[] SectionOffToAOG = new byte[2];
        byte[] SectionOnToAOGlast = new byte[2];
        byte[] SectionOffToAOGlast = new byte[2];

        // used by RateController
        byte[] SectionControlByte = new byte[2];
        byte[] SectionControlLast = new byte[2];

        bool PinState;

        bool MasterOn;
        bool MasterLast;
        bool MasterChanged;
        DateTime MasterTime;

        bool AutoLast;
        bool AutoChanged;
        DateTime AutoTime;

        private PGN234 ToAOG;
        private float RateCalcFactor = 0.05F;   // rate change amount for each step.  ex: 0.10 means 10% for each step

        int Tmp;
        bool AOGmasterOn;
        bool AOGmasterOff;

        public class MasterChangedArgs : EventArgs
        {
            public bool MasterOn { get; set; }
        }

        public event EventHandler<MasterChangedArgs> MasterSwitchChanged;

        public clsSections(FormStart CallingForm)
        {
            mf = CallingForm;
            Items = cSections.AsReadOnly(); // to use ForEach

            mf.AutoSteerPGN.RelaysChanged += AOGnew_RelaysChanged;

            mf.SwitchBox.SwitchPGNreceived += SwitchBox_SwitchPGNreceived;

            ToAOG = new PGN234(mf);

            SwON[(int)Switches.Auto] = true;
        }

        private void SwitchBox_SwitchPGNreceived(object sender, PGN32618.SwitchPGNargs e)
        {
            SwON = e.Switches;
            SendStatusUpdate();
        }

        public int Count
        {
            get
            {
                int tmp = 0;
                for (int i = 0; i < 16; i++)
                {
                    if (cSections[i].Enabled) tmp++;
                }
                return tmp;
            }
            set
            {
                if (value < 0 | value > 16)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    for (int i = 0; i < 16; i++)
                    {
                        Tmp = ListID(i);
                        if (i < value)
                        {
                            cSections[Tmp].Enabled = true;
                        }
                        else
                        {
                            cSections[Tmp].Enabled = false;
                            cSections[Tmp].Width_inches = 0;
                        }
                        cSections[Tmp].Save();
                    }
                }
            }
        }

        public clsSection Item(int SectionID)
        {
            int IDX = ListID(SectionID);
            if (IDX == -1) throw new IndexOutOfRangeException();
            return cSections[IDX];
        }

        public void Load()
        {
            cSections.Clear();
            for (int i = 0; i < 16; i++)
            {
                clsSection Sec = new clsSection(mf, i);
                Sec.Load();
                cSections.Add(Sec);
            }
            UpdateSectionsOn();
        }

        public void Save()
        {
            for (int i = 0; i < 16; i++)
            {
                cSections[i].Save();
            }
        }

        public float TotalWidth(bool UseInches = true)
        {
            float Result = 0;
            for (int i = 0; i < 16; i++)
            {
                if (cSections[i].Enabled)
                {
                    if (UseInches)
                    {
                        Result += cSections[i].Width_inches;
                    }
                    else
                    {
                        Result += cSections[i].Width_cm;
                    }
                }
            }
            return Result;
        }

        public bool UpdateSectionsOn()
        {
            // returns true if section on status has changed for any section
            bool Result = false;
            bool tmp = false;
            try
            {
                cWorkingWidth_cm = 0;
                for (int i = 0; i < 16; i++)
                {
                    tmp = cSections[i].SectionOn;

                    if (i < 8)
                    {
                        cSections[i].SectionOn = mf.Tls.BitRead(SectionControlByte[0], i);
                    }
                    else
                    {
                        cSections[i].SectionOn = mf.Tls.BitRead(SectionControlByte[1], i - 8);
                    }

                    if (cSections[i].SectionOn != tmp) Result = true;

                    if (cSections[i].SectionOn) cWorkingWidth_cm += cSections[i].Width_cm;
                }
            }
            catch (Exception ex)
            {
                mf.Tls.WriteErrorLog("clsSections/UpdateSectionsOn: " + ex.Message);
                mf.Tls.TimedMessageBox(ex.Message);
            }
            return Result;
        }

        private void AOGnew_RelaysChanged(object sender, PGN254.RelaysChangedArgs e)
        {
            SectionOnFromAOG[0] = e.RelayLo;
            SectionOnFromAOG[1] = e.RelayHi;

            if (SectionOnFromAOG[0] == 0 && SectionOnFromAOG[1] == 0)
            {
                AOGmasterOff = true;
            }
            else
            {
                AOGmasterOn = true;
            }
            SendStatusUpdate(true);
        }

        private int ListID(int SectionID)
        {
            for (int i = 0; i < cSections.Count; i++)
            {
                if (cSections[i].ID == SectionID) return i;
            }
            return -1;
        }

        public void CheckSwitchDefinitions()
        {
            bool Changed = false;
            for (int i = 0; i < 16; i++)
            {
                if (cSections[i].SwitchChanged) Changed = true;
                cSections[i].SwitchChanged = false;
            }
            if (Changed)
            {
                SendStatusUpdate();
                mf.SwitchIDs.Send();
            }
        }

        public void SendStatusUpdate(bool SourceAOG = false)
        {
            bool SectionSwitchesChanged = false;
            if (mf.SwitchBox.Connected())
            {
                ReadRateSwitches();
                SectionSwitchesChanged = ReadSectionSwitches();
            }
            else
            {
                SectionControlByte[0] = SectionOnFromAOG[0];
                SectionControlByte[1] = SectionOnFromAOG[1];

                AOGmasterOn = false;
                AOGmasterOff = false;
            }

            bool RelaysChanged = UpdateSectionsOn();

            if (!SourceAOG & (RelaysChanged | SectionSwitchesChanged))
            {
                // send to AOG 
                ToAOG.OnHi = SectionOnToAOG[1];
                ToAOG.OnLo = SectionOnToAOG[0];
                ToAOG.OffHi = SectionOffToAOG[1];
                ToAOG.OffLo = SectionOffToAOG[0];
                ToAOG.Command = OutCommand;
                ToAOG.Send();
            }
        }

        public bool SwitchOn(Switches ID)
        {
            return SwON[(int)ID];
        }

        private bool ReadSectionSwitches()
        {
            for (int i = 0; i < 2; i++)
            {
                SectionOnToAOG[i] = 0;
                SectionOffToAOG[i] = 0;
            }

            SWreadTime = DateTime.Now;

            // Master switch
            if (SwON[(int)Switches.MasterOff]) MasterOn = false;
            if (SwON[(int)Switches.MasterOn]) MasterOn = true;

            if(AOGmasterOff)
            {
                MasterOn = false;
                AOGmasterOff = false;
            }

            if(AOGmasterOn)
            {
                MasterOn = true;
                AOGmasterOn = false;
            }

            if ((MasterOn != MasterLast) & !MasterChanged)
            {
                // create AOG master notification
                MasterTime = SWreadTime;
                MasterChanged = true;

                MasterChangedArgs args = new MasterChangedArgs();
                args.MasterOn = MasterOn;
                MasterSwitchChanged?.Invoke(this, args);
            }

            if (SWreadTime > MasterTime.AddMilliseconds(EraseDelay))
            {
                // delay over, cancel AOG master notification
                MasterChanged = false;
                MasterLast = MasterOn;
            }

            // set state of AOG master switch (btnSectionOffAutoOn)
            OutCommand = mf.Tls.BitClear(OutCommand, 0);
            OutCommand = mf.Tls.BitClear(OutCommand, 1);
            if (MasterChanged)
            {
                if (MasterOn) OutCommand = mf.Tls.BitSet(OutCommand, 0);    // request AOG master switch on, section buttons to auto 
                if (!MasterOn) OutCommand = mf.Tls.BitSet(OutCommand, 1);   // request AOG master switch off, section buttons to off
            }


            // auto state
            if ((SwON[(int)Switches.Auto] != AutoLast) & !AutoChanged)
            {
                // create AOG auto notification
                AutoTime = SWreadTime;
                AutoChanged = true;
            }

            if (SWreadTime > AutoTime.AddMilliseconds(EraseDelay))
            {
                // cancel AOG auto notification
                AutoChanged = false;
                AutoLast = SwON[(int)Switches.Auto];
            }


            // Relays
            if (MasterOn)
            {
                for (int SwByte = 0; SwByte < 2; SwByte++)
                {
                    for (int SwBit = 0; SwBit < 8; SwBit++)
                    {
                        switch (mf.Sections.Item(SwBit + SwByte * 8).SwitchID)
                        {
                            case 0:
                                PinState = SwON[(int)Switches.sw0];
                                break;
                            case 1:
                                PinState = SwON[(int)Switches.sw1];
                                break;
                            case 2:
                                PinState = SwON[(int)Switches.sw2];
                                break;
                            case 3:
                                PinState = SwON[(int)Switches.sw3];
                                break;
                            default:
                                PinState = false;
                                break;
                        }

                        if (SwON[(int)Switches.Auto])
                        {
                            // master on, auto on
                            if (PinState)
                            {
                                // switch on, AOG in control
                                if (mf.Tls.BitRead(SectionOnFromAOG[SwByte], SwBit))
                                {
                                    SectionControlByte[SwByte] = mf.Tls.BitSet(SectionControlByte[SwByte], SwBit);
                                }
                                else
                                {
                                    SectionControlByte[SwByte] = mf.Tls.BitClear(SectionControlByte[SwByte], SwBit);
                                }
                            }
                            else
                            {
                                // switch off
                                SectionControlByte[SwByte] = mf.Tls.BitClear(SectionControlByte[SwByte], SwBit);    // turn off section
                                SectionOffToAOG[SwByte] = mf.Tls.BitSet(SectionOffToAOG[SwByte], SwBit);    // set AOG section button to off
                            }

                            //// update On byte to AOG, set to 0 for no change
                            //SectionOnFromAOG[SwByte] = 0;

                            if (AutoChanged)
                            {
                                // change section buttons to auto state by resending master on
                                OutCommand = mf.Tls.BitSet(OutCommand, 0);

                                // continue application for delay time of auto changed
                                SectionControlByte[SwByte] = SectionControlLast[SwByte];
                            }
                        }
                        else
                        {
                            // master on, auto off
                            if (PinState)
                            {
                                // manual on
                                if (!mf.Tls.BitRead(SectionOnFromAOG[SwByte], SwBit))
                                {
                                    SectionControlByte[SwByte] = mf.Tls.BitClear(SectionControlByte[SwByte], SwBit);
                                }
                                else
                                {
                                     SectionControlByte[SwByte] = mf.Tls.BitSet(SectionControlByte[SwByte], SwBit);
                               }
                                //SectionControlByte[SwByte] = mf.Tls.BitSet(SectionControlByte[SwByte], SwBit);  // turn section on
                                // AOG section button will also be set to on
                            }
                            else
                            {
                                // switch off
                                SectionControlByte[SwByte] = mf.Tls.BitClear(SectionControlByte[SwByte], SwBit);    // turn off section
                                SectionOffToAOG[SwByte] = mf.Tls.BitSet(SectionOffToAOG[SwByte], SwBit);    // set AOG section button to off
                            }

                            // update On byte to AOG
                            SectionOnToAOG[SwByte] = SectionControlByte[SwByte];

                            if (AutoChanged)
                            {
                                // continue application for delay time of auto changed
                                SectionControlByte[SwByte] = SectionControlLast[SwByte];
                            }
                        }
                    }
                }
            }
            else
            {
                // master off
                // turn relays off
                for (int i = 0; i < 2; i++)
                {
                    SectionControlByte[i] = 0;

                    SectionOnToAOG[i] = 0;
                    SectionOffToAOG[i] = 255;

                }
            }

            // record relay states
            if (!AutoChanged)
            {
                for (int i = 0; i < 2; i++)
                {
                    SectionControlLast[i] = SectionControlByte[i];
                }
            }

            bool Result = MasterChanged | (OutCommand != OutLast);

            OutLast = OutCommand;

            for (int i = 0; i < 2; i++)
            {
                //check if control bytes changed
                if (SectionOnToAOG[i] != SectionOnToAOGlast[i]) Result = true;
                if (SectionOffToAOG[i] != SectionOffToAOGlast[i]) Result = true;

                SectionOnToAOGlast[i] = SectionOnToAOG[i];
                SectionOffToAOGlast[i] = SectionOffToAOG[i];
            }

            return Result;
        }

        void ReadRateSwitches()
        {
            if (SwON[(int)Switches.RateUp] || SwON[(int)Switches.RateDown])
            {
                SWreadTime = DateTime.Now;

                if ((SWreadTime - RateLastTime).TotalMilliseconds > StepDelay)
                {
                    RateLastTime = DateTime.Now;
                    if (SwON[(int)Switches.RateUp])
                    {
                        if (mf.Tls.BitRead(OutCommand, 2))
                        {
                            if (!mf.Tls.BitRead(OutCommand, 3))
                            {
                                OutCommand = mf.Tls.BitSet(OutCommand, 3);
                                OutCommand = mf.Tls.BitClear(OutCommand, 2);
                            }
                        }
                        else
                        {
                            OutCommand = mf.Tls.BitSet(OutCommand, 2);
                        }
                        OutCommand = mf.Tls.BitClear(OutCommand, 4); // left
                        OutCommand = mf.Tls.BitSet(OutCommand, 5);   // rate up
                    }

                    if (SwON[(int)Switches.RateDown])
                    {
                        if (mf.Tls.BitRead(OutCommand, 2))
                        {
                            if (!mf.Tls.BitRead(OutCommand, 3))
                            {
                                OutCommand = mf.Tls.BitSet(OutCommand, 3);
                                OutCommand = mf.Tls.BitClear(OutCommand, 2);
                            }
                        }
                        else
                        {
                            OutCommand = mf.Tls.BitSet(OutCommand, 2);
                        }
                        OutCommand = mf.Tls.BitClear(OutCommand, 4); // left
                        OutCommand = mf.Tls.BitClear(OutCommand, 5); // rate down
                    }
                }
                NewRate();
            }
            else
            {
                // rate switch not pressed

                if ((SWreadTime - RateLastTime).TotalMilliseconds > EraseDelay)
                {
                    // clear rate values after delay
                    OutCommand = mf.Tls.BitClear(OutCommand, 2);
                    OutCommand = mf.Tls.BitClear(OutCommand, 3);
                    OutCommand = mf.Tls.BitClear(OutCommand, 4);
                    OutCommand = mf.Tls.BitClear(OutCommand, 5);
                    mf.Products.Item(mf.CurrentProduct() - 1).ManualRateFactor = 1;
                }

            }
        }

        public byte SectionHi()
        {
            return SectionControlByte[1];
        }

        public byte SectionLo()
        {
            return SectionControlByte[0];
        }

        public bool IsSectionOn(int SecID)
        {
            bool Result = false;
            if (SecID < 16)
            {
                if (SecID < 8)
                {
                    Result = mf.Tls.BitRead(SectionControlByte[0], SecID);
                }
                else
                {
                    Result = mf.Tls.BitRead(SectionControlByte[1], SecID - 8);
                }
            }
            return Result;
        }

        private void NewRate()
        {
            // update rate for currently displayed product
            // rate change amount
            int RateSteps = 0;
            if ((OutCommand & 4) == 4) RateSteps = 1;
            if ((OutCommand & 8) == 8) RateSteps += 2;

            if (RateSteps > 0)
            {
                // rate direction
                bool RateUp = false;
                RateUp = (OutCommand & 32) == 32;

                // change rate
                float ChangeAmount = 1;
                for (byte a = 1; a <= RateSteps; a++)
                {
                    if (RateUp)
                    {
                        ChangeAmount *= (1 + RateCalcFactor);
                    }
                    else
                    {
                        ChangeAmount *= (1 - RateCalcFactor);
                    }
                }
                clsProduct Prd = mf.Products.Item(mf.CurrentProduct() - 1);
                Prd.ManualRateFactor = ChangeAmount;

                if (SwON[(int)Switches.Auto])
                {
                    double CurrentRate = Prd.RateSet;
                    if (RateUp & CurrentRate == 0) CurrentRate = 1; // provide a starting point
                    CurrentRate = Math.Round(CurrentRate * ChangeAmount, 1);
                    Prd.RateSet = CurrentRate;
                }
            }
        }
    }
}

