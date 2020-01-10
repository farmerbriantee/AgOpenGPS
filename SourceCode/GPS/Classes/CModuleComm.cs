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
        public string serialRecvRelayStr;

        public List<byte[]> pgn = new List<byte[]>();
        public static int pgnSentenceLength = 10;

        //RateRelay ---------------------------------------------------------------------------------------------

        public int azSteerData = 0, azSteerSettings = 1, azRelayData = 2, azRelaySettings = 3, azMachineControl = 4;

        //AutoSteer ------------------------------------------------------------------------------------------------

        // PGN - 32766 - 127.254 0x7FFD
        public byte[] autoSteerData = new byte[pgnSentenceLength];

        public int sdHeaderHi, sdHeaderLo = 1, sdRelayLo = 2, sdSpeed = 3, sdDistanceHi = 4, sdDistanceLo = 5,
                    sdSteerAngleHi = 6, sdSteerAngleLo = 7, sdYouTurnByte = 8, sd8 = 9;

        // PGN - 32764 - 127.252 0x7FFC
        public byte[] autoSteerSettings = new byte[pgnSentenceLength];

        public int ssHeaderHi, ssHeaderLo = 1, ssKp = 2, ssKi = 3, ssKd = 4, ssKo = 5,
                    ssSteerOffset = 6, ssMinPWM = 7, ssMaxIntegral = 8, ssCountsPerDegree = 9;

        // PGN - 32762 - 127.250 0x7FFA

        public byte[] relayData = new byte[pgnSentenceLength];

        public int rdHeaderHi, rdHeaderLo = 1, rdSectionControlByteHi = 2, rdSectionControlByteLo = 3,
            rdSpeedXFour = 4, rdTramLine = 5, rdTree = 6, rdUTurn = 7, rdHydLift = 8, rd9 = 9;

        ////PGN - 32760 - 127.248 0x7FF9
        //public byte[] relayRateSettings = new byte[pgnSentenceLength];
        //public int rsHeaderHi, rsHeaderLo = 1, rsDualAccumulatedVolumeHi = 2, rsDualAccumulatedVolumeLo = 3,
        //    rsFlowCalFactorLeftHi = 4, rsFlowCalFactorLeftLo = 5, rsFlowCalFactorRightHi = 6, rsFlowCalFactorRightLo = 7;


        // ----  Machine Control ----------------------===================================================================
        //PGN 32758 - 127.246 0x7FF6
        public byte[] machineControlData = new byte[pgnSentenceLength];
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

            autoSteerData[sdHeaderHi] = 127; // PGN - 32766
            autoSteerData[sdHeaderLo] = 254;
            autoSteerData[sdRelayLo] = 0;
            autoSteerData[sdSpeed] = 0;
            autoSteerData[sdDistanceHi] = 125; // PGN - 32020
            autoSteerData[sdDistanceLo] = 20;
            autoSteerData[sdSteerAngleHi] = 125; // PGN - 32020
            autoSteerData[sdSteerAngleLo] = 20;
            autoSteerData[sdYouTurnByte] = 0;
            pgn.Add(autoSteerData);

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
            pgn.Add(autoSteerSettings);

            relayData[rdHeaderHi] = 127; // PGN - 32762
            relayData[rdHeaderLo] = 250;
            relayData[rdSectionControlByteHi] = 0;
            relayData[rdSectionControlByteLo] = 0;
            relayData[rdSpeedXFour] = 0;
            relayData[rdTramLine] = 0;
            relayData[rdTree] = 0;
            relayData[rdUTurn] = 0;
            relayData[rdHydLift] = 0;
            relayData[rd9] = 0;
            pgn.Add(relayData);

            machineControlData[cnHeaderHi] = 127; // PGN - 32758
            machineControlData[cnHeaderLo] = 246;
            machineControlData[cnPedalControl] = 0;
            machineControlData[cnSpeed] = 0;
            machineControlData[cnRelayLo] = 0;
            machineControlData[cnYouTurn] = 0;
            machineControlData[6] = 0;
            machineControlData[7] = 0;
            machineControlData[8] = 0;
            machineControlData[9] = 0;
            pgn.Add(machineControlData);
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
            relayData[rdHydLift] = 0;
            relayData[rd9] = 0;

            mf.RelayOutToPort(relayData, pgnSentenceLength);

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
            machineControlData[9] = 0;
        }
    }

}