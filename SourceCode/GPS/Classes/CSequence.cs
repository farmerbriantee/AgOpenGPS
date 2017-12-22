using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AgOpenGPS
{
    public class CSequence
    {
        private readonly FormGPS mf;

        //an array of events to take place
        public SeqEvent[] seqEnter;
        public SeqEvent[] seqExit;

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
            string[] words = sentence.Split(',');
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
    }
}
