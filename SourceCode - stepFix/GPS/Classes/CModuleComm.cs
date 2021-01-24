using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CModuleComm
    {
        //copy of the mainform address
        private readonly FormGPS mf = null;

        //Critical Safety Properties
        public bool isOutOfBounds = true;

        //receive strings
        public string serialRecvAutoSteerStr;
        public string serialRecvMachineStr;

        public static int pgnSentenceLength = 10;

        public bool isMachineDataSentToAutoSteer;

        //AutoSteer --------------------------------------------------------------------------------------------
        // PGN - 32766 - 127.254 0x7FFE
        public byte[] autoSteerData = new byte[pgnSentenceLength];
        public int sdHeaderHi, sdHeaderLo = 1, sd2 = 2, sdSpeed = 3, sdDistanceHi = 4, sdDistanceLo = 5,
                    sdSteerAngleHi = 6, sdSteerAngleLo = 7, sd8 = 8, sd9 = 9;

        //Auto Steer Basic setting -------------------------------------------------------------------------------
        // PGN - 32764 - 127.252 0x7FFC
        public byte[] autoSteerSettings = new byte[pgnSentenceLength];
        public int ssHeaderHi, ssHeaderLo = 1, ssKp = 2, ssLowPWM = 3, ssKd = 4, ssKo = 5,
                    ssSteerOffset = 6, ssMinPWM = 7, ssHighPWM = 8, ssCountsPerDegree = 9;

        // ----  Arduino Steer Config ----------------------------------------------------------------------------
        //PGN 32763 - 127.251 0x7FFB
        public byte[] ardSteerConfig = new byte[pgnSentenceLength];
        public int arHeaderHi, arHeaderLo = 1, arSet0 = 2, arSet1 = 3, arMaxSpd = 4, arMinSpd = 5, arIncMaxPulse = 6,
            arAckermanFix = 7, arSet2 = 8, ar9 = 9;

        //Machine Module Data ------------------------------------------------------------------------------------
        // PGN - 32762 - 127.250 0x7FFA
        public byte[] machineData = new byte[pgnSentenceLength];
        public int mdHeaderHi, mdHeaderLo = 1, mdSectionControlByteHi = 2, mdSectionControlByteLo = 3,
            mdSpeedXFour = 4, mdUTurn = 5, mdTree = 6, mdHydLift = 7, md8 = 8, md9 = 9;

        // ---- Arduino configuration on machine module  ---------------------------------------------------------
        //PGN - 32760 - 127.248 0x7FF9
        public byte[] ardMachineConfig = new byte[pgnSentenceLength];
        public int amHeaderHi, amHeaderLo = 1, amRaiseTime = 2, amLowerTime = 3, amEnableHyd = 4,
             amSet0 = 5, am6 = 6, am7 = 7, am8 = 8, am9 = 9;

        // ---- Section control switches to AOG  ---------------------------------------------------------
        //PGN - 32736 - 127.249 0x7FE9
        public byte[] ss = new byte[pgnSentenceLength];
        public byte[] ssP = new byte[pgnSentenceLength];
        public int swHeaderHi, swHeaderLo = 1, sw2 = 2, sw3 = 3, sw4 = 4,
             swONHi = 5, swONLo = 6, swOFFHi = 7, swOFFLo = 8, swMain = 9;

        //LIDAR
        //UDP sentence just rec'd
        public string recvUDPSentence = "Inital UDP";

        public int lidarDistance;

        //for the workswitch
        public bool isWorkSwitchActiveLow, isWorkSwitchEnabled, isWorkSwitchManual;

        public int workSwitchValue, steerSwitchValue = 1, pwmDisplay = 0;

        //constructor
        public CModuleComm(FormGPS _f)
        {
            mf = _f;
            serialRecvAutoSteerStr = " ** Steer Module Not Connected";
            serialRecvMachineStr = " ** Machine Module Not Connected";

            //WorkSwitch logic
            isWorkSwitchEnabled = false;

            //does a low, grounded out, mean on
            isWorkSwitchActiveLow = true;

            isMachineDataSentToAutoSteer = Properties.Vehicle.Default.setVehicle_isMachineControlToAutoSteer;

            //autosteer constant data
            autoSteerData[sdHeaderHi] = 127; // PGN - 32766
            autoSteerData[sdHeaderLo] = 254;
            autoSteerData[sd2] = 0;
            autoSteerData[sdSpeed] = 0;
            autoSteerData[sdDistanceHi] = 125; // PGN - 32020
            autoSteerData[sdDistanceLo] = 20;
            autoSteerData[sdSteerAngleHi] = 125; // PGN - 32020
            autoSteerData[sdSteerAngleLo] = 20;
            autoSteerData[sd8] = 0;
            autoSteerData[sd9] = 0;

            //autosteer steer settings
            autoSteerSettings[ssHeaderHi] = 127;// PGN - 32764 as header
            autoSteerSettings[ssHeaderLo] = 252;
            autoSteerSettings[ssKp] = Properties.Settings.Default.setAS_Kp;
            autoSteerSettings[ssLowPWM] = Properties.Settings.Default.setAS_lowSteerPWM;
            autoSteerSettings[ssKd] = Properties.Settings.Default.setAS_Kd;
            autoSteerSettings[ssKo] = Properties.Settings.Default.setAS_Ko;
            autoSteerSettings[ssSteerOffset] = Properties.Settings.Default.setAS_steerAngleOffset;
            autoSteerSettings[ssMinPWM] = Properties.Settings.Default.setAS_minSteerPWM;
            autoSteerSettings[ssHighPWM] = Properties.Settings.Default.setAS_highSteerPWM;
            autoSteerSettings[ssCountsPerDegree] = Properties.Settings.Default.setAS_countsPerDegree;

            //arduino basic steer settings
            ardSteerConfig[arHeaderHi] = 127; //PGN - 32763
            ardSteerConfig[arHeaderLo] = 251;
            ardSteerConfig[arSet0] = Properties.Vehicle.Default.setArdSteer_setting0;
            ardSteerConfig[arSet1] = Properties.Vehicle.Default.setArdSteer_setting1;
            ardSteerConfig[arMaxSpd] = Properties.Vehicle.Default.setArdSteer_maxSpeed;
            ardSteerConfig[arMinSpd] = Properties.Vehicle.Default.setArdSteer_minSpeed;
            byte inc = (byte)(Properties.Vehicle.Default.setArdSteer_inclinometer << 6);
            ardSteerConfig[arIncMaxPulse] = (byte)(inc + (byte)Properties.Vehicle.Default.setArdSteer_maxPulseCounts);
            ardSteerConfig[arAckermanFix] = Properties.Vehicle.Default.setArdSteer_ackermanFix;
            ardSteerConfig[arSet2] = Properties.Vehicle.Default.setArdSteer_setting2;
            ardSteerConfig[ar9] = 0;

            //machine, sections data array
            machineData[mdHeaderHi] = 127; // PGN - 32762
            machineData[mdHeaderLo] = 250;
            machineData[mdSectionControlByteHi] = 0;
            machineData[mdSectionControlByteLo] = 0;
            machineData[mdSpeedXFour] = 0;
            machineData[mdUTurn] = 0;
            machineData[mdTree] = 0;
            machineData[mdHydLift] = 0;
            machineData[md8] = 0;
            machineData[md9] = 0;

            //arduino machine configuration
            ardMachineConfig[amHeaderHi] = 127; //PGN - 32760
            ardMachineConfig[amHeaderLo] = 248;
            ardMachineConfig[amRaiseTime] = Properties.Vehicle.Default.setArdMac_hydRaiseTime;
            ardMachineConfig[amLowerTime] = Properties.Vehicle.Default.setArdMac_hydLowerTime;
            ardMachineConfig[amEnableHyd] = Properties.Vehicle.Default.setArdMac_isHydEnabled;
            ardMachineConfig[amSet0] = Properties.Vehicle.Default.setArdMac_setting0;
            ardMachineConfig[am6] = 0;
            ardMachineConfig[am7] = 0;
            ardMachineConfig[am8] = 0;
            ardMachineConfig[am9] = 0;

            //Section control: switches
            ss[swHeaderHi] = 0;  //PGN - 32609
            ss[swHeaderLo] = 0;  //0xE0
            ss[sw2] = 0;
            ss[sw3] = 0;
            ss[sw4] = 0;
            ss[swONHi] = 0;
            ss[swONLo] = 0;
            ss[swOFFHi] = 0;
            ss[swOFFLo] = 0;
            ss[swMain] = 0;

            ssP[swHeaderHi] = 0;  //PGN - 32609
            ssP[swHeaderLo] = 0;  //0xE0
            ssP[sw2] = 0;
            ssP[sw3] = 0;
            ssP[sw4] = 0;
            ssP[swONHi] = 0;
            ssP[swONLo] = 0;
            ssP[swOFFHi] = 0;
            ssP[swOFFLo] = 0;
            ssP[swMain] = 0;
        }

        //Reset all the byte arrays from modules
        public void ResetAllModuleCommValues()
        {
            machineData[mdHeaderHi] = 127; // PGN - 32762
            machineData[mdHeaderLo] = 250;
            machineData[mdSectionControlByteHi] = 0;
            machineData[mdSectionControlByteLo] = 0;
            machineData[mdSpeedXFour] = 0;
            machineData[mdUTurn] = 0;
            machineData[mdTree] = 0;
            machineData[mdHydLift] = 0;
            machineData[md8] = 0;
            machineData[md9] = 0;
            mf.SendOutUSBMachinePort(machineData, pgnSentenceLength);

            autoSteerData[sdHeaderHi] = 127; // PGN - 32766
            autoSteerData[sdHeaderLo] = 254;
            autoSteerData[sd2] = 0;
            autoSteerData[sdSpeed] = 0;
            autoSteerData[sdDistanceHi] = 125; // PGN - 32020
            autoSteerData[sdDistanceLo] = 20;
            autoSteerData[sdSteerAngleHi] = 125; // PGN - 32020
            autoSteerData[sdSteerAngleLo] = 20;
            autoSteerData[sd8] = 0;
            autoSteerData[sd9] = 0;
            mf.SendOutUSBAutoSteerPort(autoSteerData, pgnSentenceLength);

            autoSteerSettings[ssHeaderHi] = 127;// PGN - 32764 as header
            autoSteerSettings[ssHeaderLo] = 252;
            autoSteerSettings[ssKp] = Properties.Settings.Default.setAS_Kp;
            autoSteerSettings[ssLowPWM] = Properties.Settings.Default.setAS_lowSteerPWM;
            autoSteerSettings[ssKd] = Properties.Settings.Default.setAS_Kd;
            autoSteerSettings[ssKo] = Properties.Settings.Default.setAS_Ko;
            autoSteerSettings[ssSteerOffset] = Properties.Settings.Default.setAS_steerAngleOffset;
            autoSteerSettings[ssMinPWM] = Properties.Settings.Default.setAS_minSteerPWM;
            autoSteerSettings[ssHighPWM] = Properties.Settings.Default.setAS_highSteerPWM;
            autoSteerSettings[ssCountsPerDegree] = Properties.Settings.Default.setAS_countsPerDegree;
            //mf.SendSteerSettingsOutAutoSteerPort();

            ardSteerConfig[arHeaderHi] = 127; //PGN - 32763
            ardSteerConfig[arHeaderLo] = 251;
            ardSteerConfig[arSet0] = Properties.Vehicle.Default.setArdSteer_setting0;
            ardSteerConfig[arSet1] = Properties.Vehicle.Default.setArdSteer_setting1;
            ardSteerConfig[arMaxSpd] = Properties.Vehicle.Default.setArdSteer_maxSpeed;
            ardSteerConfig[arMinSpd] = Properties.Vehicle.Default.setArdSteer_minSpeed;
                byte inc = (byte)(Properties.Vehicle.Default.setArdSteer_inclinometer << 6);
            ardSteerConfig[arIncMaxPulse] = (byte)(inc + (byte)Properties.Vehicle.Default.setArdSteer_maxPulseCounts);
            ardSteerConfig[arAckermanFix] = Properties.Vehicle.Default.setArdSteer_ackermanFix;
            ardSteerConfig[arSet2] = Properties.Vehicle.Default.setArdSteer_setting2;
            ardSteerConfig[ar9] = 0;

            //arduino machine configuration
            ardMachineConfig[amHeaderHi] = 127; //PGN - 32760
            ardMachineConfig[amHeaderLo] = 248;
            ardMachineConfig[amRaiseTime] = Properties.Vehicle.Default.setArdMac_hydRaiseTime;
            ardMachineConfig[amLowerTime] = Properties.Vehicle.Default.setArdMac_hydLowerTime;
            ardMachineConfig[amEnableHyd] = Properties.Vehicle.Default.setArdMac_isHydEnabled;
            ardMachineConfig[amSet0] = Properties.Vehicle.Default.setArdMac_setting0;
            ardMachineConfig[am6] = 0;
            ardMachineConfig[am7] = 0;
            ardMachineConfig[am8] = 0;
            ardMachineConfig[am9] = 0;
        }
    }

}