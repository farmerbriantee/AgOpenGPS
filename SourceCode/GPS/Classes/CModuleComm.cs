namespace AgOpenGPS
{
    public class CModuleComm
    {
        //copy of the mainform address
        private readonly FormGPS mf = null;

        //Critical Safety Properties
        public bool isOutOfBounds = true;

        //RateRelay ---------------------------------------------------------------------------------------------
        public string serialRecvRelayStr;

        // PGN - 32762 - 127.250 0x7FFA
        public static int numRelayDataItems = 10;

        public byte[] relayData = new byte[numRelayDataItems];

        public int rdHeaderHi, rdHeaderLo = 1, rdSectionControlByteHi = 2, rdSectionControlByteLo = 3,
            rdSpeedXFour = 4, rdTramLine = 5, rdTree = 6, rdUTurn = 7, rd8 = 8, rd9 = 9;

        // PGN - 32760 - 127.248 0x7FF9
        //public static int numRelayRateSettingsItems = 10;
        //public byte[] relayRateSettings = new byte[numRelayRateSettingsItems];
        //public int rsHeaderHi, rsHeaderLo = 1, rsDualAccumulatedVolumeHi = 2, rsDualAccumulatedVolumeLo = 3,
        //    rsFlowCalFactorLeftHi = 4, rsFlowCalFactorLeftLo = 5, rsFlowCalFactorRightHi = 6, rsFlowCalFactorRightLo = 7;

        //AutoSteer ------------------------------------------------------------------------------------------------
        public string serialRecvAutoSteerStr;

        // PGN - 32766 - 127.254 0x7FFD
        public static int numSteerDataItems = 10;

        public byte[] autoSteerData = new byte[numSteerDataItems];

        public int sdHeaderHi, sdHeaderLo = 1, sdRelayLo = 2, sdSpeed = 3, sdDistanceHi = 4, sdDistanceLo = 5,
                    sdSteerAngleHi = 6, sdSteerAngleLo = 7, sdYouTurnByte = 8;

        // PGN - 32764 - 127.252 0x7FFC
        public static int numSteerSettingItems = 10;

        public byte[] autoSteerSettings = new byte[numSteerSettingItems];

        public int ssHeaderHi, ssHeaderLo = 1, ssKp = 2, ssKi = 3, ssKd = 4, ssKo = 5,
                    ssSteerOffset = 6, ssMinPWM = 7, ssMaxIntegral = 8, ssCountsPerDegree = 9;

        //PGN 32758 - 127.246 0x7FF6
        public static int numMachineControlItems = 10;

        public byte[] machineControlData = new byte[numMachineControlItems];
        public int cnHeaderHi, cnHeaderLo = 1, cnPedalControl = 2, cnSpeed = 3, cnRelayLo = 4, cnYouTurn = 5;

        //LIDAR
        //UDP sentence just rec'd
        public string recvUDPSentence = "Inital UDP";

        public int lidarDistance;

        //for the workswitch
        public bool isWorkSwitchActiveLow, isWorkSwitchEnabled, isWorkSwitchManual;

        public int workSwitchValue, steerSwitchValue = 1;

        //constructor
        public CModuleComm(FormGPS _f)
        {
            mf = _f;
            serialRecvAutoSteerStr = "Oops NC";
            serialRecvRelayStr = "Oops NC";

            //WorkSwitch logic
            isWorkSwitchEnabled = false;

            //does a low, grounded out, mean on
            isWorkSwitchActiveLow = true;
        }

        //Reset all the byte arrays from modules
        public void ResetAllModuleCommValues()
        {
            relayData[rdHeaderHi] = 127; // PGN - 32762
            relayData[rdHeaderLo] = 250;
            relayData[rdSectionControlByteHi] = 0;
            relayData[rdSectionControlByteLo] = 0;
            relayData[rdSpeedXFour] = 0;
            relayData[rdTramLine] = 0;
            relayData[rdTree] = 0;
            relayData[rdUTurn] = 0;
            relayData[rd8] = 0;
            relayData[rd9] = 0;

            mf.RelayOutToPort(relayData, numRelayDataItems);

            autoSteerData[sdHeaderHi] = 127; // PGN - 32766
            autoSteerData[sdHeaderLo] = 254;
            autoSteerData[sdRelayLo] = 0;
            autoSteerData[sdSpeed] = 0;
            autoSteerData[sdDistanceHi] = 125; // PGN - 32020
            autoSteerData[sdDistanceLo] = 20;
            autoSteerData[sdSteerAngleHi] = 125; // PGN - 32020
            autoSteerData[sdSteerAngleLo] = 20;
            autoSteerData[sdYouTurnByte] = 0;
            mf.AutoSteerDataOutToPort();

            autoSteerSettings[ssHeaderHi] = 127;// PGN - 32764 as header
            autoSteerSettings[ssHeaderLo] = 252;
            autoSteerSettings[ssKp] = Properties.Settings.Default.setAS_Kp;
            autoSteerSettings[ssKi] = Properties.Settings.Default.setAS_Ki;
            autoSteerSettings[ssKd] = Properties.Settings.Default.setAS_Kd;
            autoSteerSettings[ssKo] = Properties.Settings.Default.setAS_Ko;
            autoSteerSettings[ssSteerOffset] = Properties.Settings.Default.setAS_steerAngleOffset;
            autoSteerSettings[ssMinPWM] = Properties.Settings.Default.setAS_minSteerPWM;
            autoSteerSettings[ssMaxIntegral] = Properties.Settings.Default.setAS_maxIntegral;
            autoSteerSettings[ssCountsPerDegree] = Properties.Settings.Default.setAS_countsPerDegree;
            mf.AutoSteerSettingsOutToPort();

            machineControlData[cnHeaderHi] = 127; // PGN - 32758
            machineControlData[cnHeaderLo] = 246;
            machineControlData[cnPedalControl] = 0;
            machineControlData[cnSpeed] = 0;
            machineControlData[cnRelayLo] = 0;
            machineControlData[cnYouTurn] = 0;
            machineControlData[6] = 0;
            machineControlData[7] = 0;
            machineControlData[8] = 0;
        }
    }
}