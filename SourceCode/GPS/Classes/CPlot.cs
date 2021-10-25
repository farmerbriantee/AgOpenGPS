using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public partial class CPlot
    {
        //copy of the mainform address
        private readonly FormGPS mf;

        /// <summary>
        /// array of boundaries
        /// </summary>
        /// 
        public List<CPlots> plots = new List<CPlots>();

        private readonly double scanWidth, boxLength;

        public bool isDrawRightSide = true, isOkToAddPoints = false;
        //constructor
        public CPlot(FormGPS _f)
        {
            mf = _f;
            boundarySelected = 0;
            scanWidth = 1.0;
            boxLength = 2000;

            turnSelected = 0;

            isOn = false;
            isToolUp = true;
        }
    }
}