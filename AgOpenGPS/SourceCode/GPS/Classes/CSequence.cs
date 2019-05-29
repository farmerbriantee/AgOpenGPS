using System.Globalization;

namespace AgOpenGPS
{
    public class CSequence
    {
        private readonly FormGPS mf;

        //an array of events to take place
        public SeqEvent[] seqEnter;

        public SeqEvent[] seqExit;

        public string pos1 = "Manual Button";
        public string pos2 = "Auto Button";
        public string pos3 = "";
        public string pos4 = "";
        public string pos5 = "";
        public string pos6 = "";
        public string pos7 = "";
        public string pos8 = "";

        /// <summary> /// 0=Not in youturn, 1=Entering headland, 2=Exiting headland /// </summary>
        public int whereAmI = 0;

        public bool isSequenceTriggered, isEntering;

        public struct SeqEvent
        {
            public int function; //event name
            public int action; //where in the turn procedure
            public bool isTrig;
            public double distance; //trigger distance to turn on

            public SeqEvent(int function, int action, bool isTrig, double distance)
            {
                this.function = function;
                this.action = action;
                this.isTrig = isTrig;
                this.distance = distance;
            }
        }

        //constructor
        public CSequence(FormGPS _f)
        {
            mf = _f;

            //Fill in the strings for comboboxes - editable
            string line = Properties.Vehicle.Default.seq_FunctionList;
            string[] words = line.Split(',');

            pos3 = words[0];
            pos4 = words[1];
            pos5 = words[2];
            pos6 = words[3];
            pos7 = words[4];
            pos8 = words[5];

            string sentence;

            seqEnter = new SeqEvent[FormGPS.MAXFUNCTIONS];
            for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
            {
                seqEnter[i].function = 0;
                seqEnter[i].action = 0;
                seqEnter[i].isTrig = true;
                seqEnter[i].distance = 0;
            }

            sentence = Properties.Vehicle.Default.seq_FunctionEnter;
            words = sentence.Split(',');
            for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++) int.TryParse(words[i], out seqEnter[i].function);

            sentence = Properties.Vehicle.Default.seq_ActionEnter;
            words = sentence.Split(',');
            for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++) int.TryParse(words[i], out seqEnter[i].action);

            sentence = Properties.Vehicle.Default.seq_DistanceEnter;
            words = sentence.Split(',');
            for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
                double.TryParse(words[i], NumberStyles.Float, CultureInfo.InvariantCulture, out seqEnter[i].distance);

            seqExit = new SeqEvent[FormGPS.MAXFUNCTIONS];
            for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
            {
                seqExit[i].function = 0;
                seqExit[i].action = 0;
                seqExit[i].isTrig = true;
                seqExit[i].distance = 0;
            }

            sentence = Properties.Vehicle.Default.seq_FunctionExit;
            words = sentence.Split(',');
            for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++) int.TryParse(words[i], out seqExit[i].function);

            sentence = Properties.Vehicle.Default.seq_ActionExit;
            words = sentence.Split(',');
            for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++) int.TryParse(words[i], out seqExit[i].action);

            sentence = Properties.Vehicle.Default.seq_DistanceExit;
            words = sentence.Split(',');
            for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
                double.TryParse(words[i], NumberStyles.Float, CultureInfo.InvariantCulture, out seqExit[i].distance);
        }

        public void DisableSeqEvent(int index, bool isEnter)
        {
            if (isEnter)
            {
                seqEnter[index].function = 0;
                seqEnter[index].action = 0;
                seqEnter[index].isTrig = true;
                seqEnter[index].distance = 0;
            }
            else
            {
                seqExit[index].function = 0;
                seqExit[index].action = 0;
                seqExit[index].isTrig = true;
                seqExit[index].distance = 0;
            }
        }

        public void ResetAllSequences()
        {
            for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
            {
                seqEnter[i].function = 0;
                seqEnter[i].action = 0;
                seqEnter[i].isTrig = true;
                seqEnter[i].distance = 0;
            }
            for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
            {
                seqExit[i].function = 0;
                seqExit[i].action = 0;
                seqExit[i].isTrig = true;
                seqExit[i].distance = 0;
            }
        }

        //reset trig flag to false on all array elements with a function
        public void ResetSequenceEventTriggers()
        {
            for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
            {
                if (mf.seq.seqEnter[i].function != 0) mf.seq.seqEnter[i].isTrig = false;
                if (mf.seq.seqExit[i].function != 0) mf.seq.seqExit[i].isTrig = false;
            }
        }

        //figure out where we are
        //yt.isInBoundz = boundz.IsPointInsideBoundary(toolPos);
        //yt.isInWorkArea = hlArr[0].IsPointInsideHeadland(toolPos);

        //Are we in the outside headland?
        //if (!yt.isInWorkArea)
        //{
        //    yt.isInHeadland = true;
        //}
        //else
        //{
        //    yt.isInHeadland = false;
        //    bool isInInnerHeadland = false;
        //    for (int i = 1; i < FormGPS.MAXHEADS; i++)
        //    {
        //        isInInnerHeadland = hlArr[i].IsPointInsideHeadland(toolPos);
        //        if (isInInnerHeadland)
        //        {
        //            yt.isInHeadland = true;
        //            break;
        //        }
        //    }
        //}

        //determine when if and how functions are triggered for drive thru
        //public void DoDriveThruSequenceEvent()
        //{
        //    //determine if Section is entry or exit based on trigger point direction
        //    //bool isToolHeadingSameAsABHeading;

        //    ////Subtract the two headings, if > 1.57 its going the opposite heading as refAB
        //    //double headAB;
        //    //if (mf.ABLine.isABLineSet)
        //    //{
        //    //    double abFixHeadingDelta = (Math.Abs(mf.toolPos.heading - mf.ABLine.abHeading));
        //    //    if (abFixHeadingDelta >= Math.PI) abFixHeadingDelta = Math.Abs(abFixHeadingDelta - glm.twoPI);
        //    //    isToolHeadingSameAsABHeading = (abFixHeadingDelta <= glm.PIBy2);
        //    //    headAB = mf.ABLine.abHeading;
        //    //}
        //    //else  //AB Curve
        //    //{
        //    //    //Subtract the two headings, if > 1.57 its going the opposite heading as refAB
        //    //    double abFixHeadingDelta = (Math.Abs(mf.toolPos.heading - mf.curve.refHeading));
        //    //    if (abFixHeadingDelta >= Math.PI) abFixHeadingDelta = Math.Abs(abFixHeadingDelta - glm.twoPI);
        //    //    isToolHeadingSameAsABHeading = (abFixHeadingDelta <= glm.PIBy2);
        //    //    headAB = mf.curve.refHeading;
        //    //}

        //    //if (!isToolHeadingSameAsABHeading) headAB += Math.PI;

        //    //#pragma warning disable CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception

        //    //            mf.hl.FindClosestHeadlandPoint(mf.toolPos, mf.toolPos.heading);
        //    //            if ((int)mf.hl.closestHeadlandPt.easting != -20000)
        //    //            {
        //    //                mf.distTool = glm.Distance(mf.toolPos, mf.hl.closestHeadlandPt);
        //    //            }
        //    //            else //we've lost the headland
        //    //            {
        //    //                isEnteringDriveThru = false;
        //    //                isExitingDriveThru = false;
        //    //                ResetSequenceEventTriggers();
        //    //                mf.distTool = -3333;
        //    //                return;
        //    //            }
        //    //#pragma warning restore CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception

        //    //            //make distance sign correct
        //    //            if (isInHeadland) mf.distTool *= -1;
        //    //            mf.distTool += (mf.headlandDistanceDelta * 0.5);

        //    //            //we are entering
        //    //            if (isEnteringDriveThru) whereAmI = 1;

        //    //            //we are exiting
        //    //            else whereAmI = 2;

        //    //            //did we do all the events?
        //    //            int c = 0;
        //    //            for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
        //    //            {
        //    //                //checked for any not triggered yet (false) - if there is, not done yet
        //    //                if (!mf.seq.seqEnter[i].isTrig) c++;
        //    //                if (!mf.seq.seqExit[i].isTrig) c++;
        //    //            }

        //    //            if (c == 0)
        //    //            {
        //    //                //sequences all done so reset everything
        //    //                isEnteringDriveThru = false;
        //    //                isExitingDriveThru = false;
        //    //                whereAmI = 0;
        //    //                ResetSequenceEventTriggers();
        //    //                mf.distTool = -2222;
        //    //            }

        //    //            switch (whereAmI)
        //    //            {
        //    //                case 0: //not in you turn
        //    //                    break;

        //    //                case 1: //Entering the headland

        //    //                    for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
        //    //                    {
        //    //                        //have we gone past the distance and still haven't done it
        //    //                        if (mf.distTool < mf.seq.seqEnter[i].distance && !mf.seq.seqEnter[i].isTrig)
        //    //                        {
        //    //                            //it shall only run once
        //    //                            mf.seq.seqEnter[i].isTrig = true;

        //    //                            //send the function and action to perform
        //    //                            mf.DoYouTurnSequenceEvent(mf.seq.seqEnter[i].function, mf.seq.seqEnter[i].action);
        //    //                        }
        //    //                    }
        //    //                    break;

        //    //                case 2: //Exiting the headland

        //    //                    for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
        //    //                    {
        //    //                        //have we gone past the distance and still haven't done it
        //    //                        if (mf.distTool > mf.seq.seqExit[i].distance && !mf.seq.seqExit[i].isTrig)
        //    //                        {
        //    //                            //it shall only run once
        //    //                            mf.seq.seqExit[i].isTrig = true;

        //    //                            //send the function and action to perform
        //    //                            mf.DoYouTurnSequenceEvent(mf.seq.seqExit[i].function, mf.seq.seqExit[i].action);
        //    //                        }
        //    //                    }
        //    //                    break;
        //    //            }
        //}

        //determine when if and how functions are triggered
        public void DoSequenceEvent()
        {
            if (isSequenceTriggered)
            {
                //determine if Section is entry or exit based on trigger point direction
                //bool isToolHeadingSameAsABHeading;

#pragma warning disable CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception

                if (mf.yt.onA <= 0)
                {
                    whereAmI = 1;
                    mf.yt.onA = -mf.yt.onA;
                }
                else
                {
                    whereAmI = 2;
                }

                int c = 0;
                for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
                {
                    //checked for any not triggered yet (false) - if there is, not done yet
                    if (!mf.seq.seqEnter[i].isTrig) c++;
                    if (!mf.seq.seqExit[i].isTrig) c++;
                }

                if (c == 0)
                {
                    //sequences all done so reset everything and leave
                    isSequenceTriggered = false;
                    whereAmI = 0;
                    ResetSequenceEventTriggers();
                    mf.distanceToolToTurnLine = -2222;
                    isSequenceTriggered = false;
                    return;
                }

                switch (whereAmI)
                {
                    case 0: //not in you turn
                        break;

                    case 1: //Entering the headland

                        for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
                        {
                            //have we gone past the distance and still haven't done it
                            if (mf.yt.onA >= mf.seq.seqEnter[i].distance && !mf.seq.seqEnter[i].isTrig)
                            {
                                //it shall only run once
                                mf.seq.seqEnter[i].isTrig = true;

                                //send the function and action to perform
                                mf.DoYouTurnSequenceEvent(mf.seq.seqEnter[i].function, mf.seq.seqEnter[i].action);
                            }
                        }
                        break;

                    case 2: //Exiting the headland

                        for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
                        {
                            //have we gone past the distance and still haven't done it
                            if (mf.yt.onA <= mf.seq.seqExit[i].distance && !mf.seq.seqExit[i].isTrig)
                            {
                                //it shall only run once
                                mf.seq.seqExit[i].isTrig = true;

                                //send the function and action to perform
                                mf.DoYouTurnSequenceEvent(mf.seq.seqExit[i].function, mf.seq.seqExit[i].action);
                            }
                        }
                        break;
                }
            }
        }

        public void DoManualEntrySequence()
        {
            for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
            {
                //have we gone past the distance and still haven't done it
                if (!mf.seq.seqEnter[i].isTrig)
                {
                    //it shall only run once
                    mf.seq.seqEnter[i].isTrig = true;

                    //send the function and action to perform
                    mf.DoYouTurnSequenceEvent(mf.seq.seqEnter[i].function, mf.seq.seqEnter[i].action);
                }
            }
            mf.seq.ResetSequenceEventTriggers();
        }

        public void DoManualExitSequence()
        {
            for (int i = 0; i < FormGPS.MAXFUNCTIONS; i++)
            {
                //have we gone past the distance and still haven't done it
                if (!mf.seq.seqExit[i].isTrig)
                {
                    //it shall only run once
                    mf.seq.seqExit[i].isTrig = true;

                    //send the function and action to perform
                    mf.DoYouTurnSequenceEvent(mf.seq.seqExit[i].function, mf.seq.seqExit[i].action);
                }
            }
            mf.seq.ResetSequenceEventTriggers();
        }
    }
}