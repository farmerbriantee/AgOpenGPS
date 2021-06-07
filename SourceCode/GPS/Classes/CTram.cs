using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{

    public class CTram
    {
        private readonly FormGPS mf;

        //the list of constants and multiples of the boundary
        public List<vec2> calcList = new List<vec2>();

        //the triangle strip of the outer tram highlight
        public List<vec2> tramBndOuterArr = new List<vec2>();
        public List<vec2> tramBndInnerArr = new List<vec2>();

        //tram settings
        //public double wheelTrack;
        public double tramWidth;
        public double halfWheelTrack;
        public int passes;
        public bool isOuter;

        //tramlines
        public List<vec2> tramArr = new List<vec2>();
        public List<List<vec2>> tramList = new List<List<vec2>>();


        // 0 off, 1 All, 2, Lines, 3 Outer
        public int displayMode;
        internal int controlByte;

        public CTram(FormGPS _f)
        {
            //constructor
            mf = _f;

            tramWidth = Properties.Settings.Default.setTram_tramWidth;
            //halfTramWidth = (Math.Round((Properties.Settings.Default.setTram_tramWidth) / 2.0, 3));

            halfWheelTrack = Properties.Vehicle.Default.setVehicle_trackWidth * 0.5;

            passes = Properties.Settings.Default.setTram_passes;
            displayMode = 0;
            isOuter = Properties.Settings.Default.setTool_isTramOuter;
        }

        public void DrawTram()
        {
            if (mf.camera.camSetDistance > -250) GL.LineWidth(4);
            else GL.LineWidth(2);

            GL.Color4(0.30f, 0.93692f, 0.7520f, 0.3);

            if (mf.tram.displayMode == 1 || mf.tram.displayMode == 2)
            {
                if (tramList.Count > 0)
                {
                    for (int i = 0; i < tramList.Count; i++)
                    {
                        GL.Begin(PrimitiveType.LineStrip);
                        for (int h = 0; h < tramList[i].Count; h++)
                            GL.Vertex3(tramList[i][h].easting, tramList[i][h].northing, 0);
                        GL.End();
                    }
                }
            }

            if (mf.tram.displayMode == 1 || mf.tram.displayMode == 3)
            {
                if (tramBndOuterArr.Count > 0)
                {
                    GL.Begin(PrimitiveType.LineStrip);
                    for (int h = 0; h < tramBndOuterArr.Count; h++) GL.Vertex3(tramBndOuterArr[h].easting, tramBndOuterArr[h].northing, 0);
                    GL.End();
                    GL.Begin(PrimitiveType.LineStrip);
                    for (int h = 0; h < tramBndInnerArr.Count; h++) GL.Vertex3(tramBndInnerArr[h].easting, tramBndInnerArr[h].northing, 0);
                    GL.End();
                }
            }
        }

        public void BuildTramBnd()
        {
            bool isBndExist = mf.bnd.bndArr.Count != 0;

            if (isBndExist)
            {
                CreateBndOuterTramTrack();
                CreateBndInnerTramTrack();
            }
            else
            {
                tramBndOuterArr?.Clear();
                tramBndInnerArr?.Clear();
            }
        }

        private void CreateBndInnerTramTrack()
        {
            //count the points from the boundary
            int ptCount = mf.bnd.bndArr[0].bndLine.Count;
            tramBndInnerArr?.Clear();

            //outside point
            vec2 pt3 = new vec2();

            double distSq = ((tramWidth * 0.5) + halfWheelTrack) * ((tramWidth * 0.5) + halfWheelTrack) * 0.999;

            //make the boundary tram outer array
            for (int i = 0; i < ptCount; i++)
            {
                //calculate the point inside the boundary
                pt3.easting = mf.bnd.bndArr[0].bndLine[i].easting -
                    (Math.Sin(glm.PIBy2 + mf.bnd.bndArr[0].bndLine[i].heading) * (tramWidth * 0.5 + halfWheelTrack));

                pt3.northing = mf.bnd.bndArr[0].bndLine[i].northing -
                    (Math.Cos(glm.PIBy2 + mf.bnd.bndArr[0].bndLine[i].heading) * (tramWidth * 0.5 + halfWheelTrack));

                bool Add = true;

                for (int j = 0; j < ptCount; j++)
                {
                    double check = glm.DistanceSquared(pt3.northing, pt3.easting,
                                        mf.bnd.bndArr[0].bndLine[j].northing, mf.bnd.bndArr[0].bndLine[j].easting);
                    if (check < distSq)
                    {
                        Add = false;
                        break;
                    }
                }

                if (Add)
                {
                    if (tramBndInnerArr.Count > 0)
                    {
                        double dist = ((pt3.easting - tramBndInnerArr[tramBndInnerArr.Count - 1].easting) * (pt3.easting - tramBndInnerArr[tramBndInnerArr.Count - 1].easting))
                            + ((pt3.northing - tramBndInnerArr[tramBndInnerArr.Count - 1].northing) * (pt3.northing - tramBndInnerArr[tramBndInnerArr.Count - 1].northing));
                        if (dist > 1)
                            tramBndInnerArr.Add(pt3);
                    }
                    else tramBndInnerArr.Add(pt3);
                }
            }
        }

        public void CreateBndOuterTramTrack()
        {
            //count the points from the boundary
            int ptCount = mf.bnd.bndArr[0].bndLine.Count;
            tramBndOuterArr?.Clear();

            //outside point
            vec2 pt3 = new vec2();

            double distSq = ((tramWidth * 0.5) - halfWheelTrack) * ((tramWidth * 0.5) - halfWheelTrack) * 0.999;

            //make the boundary tram outer array
            for (int i = 0; i < ptCount; i++)
            {
                //calculate the point inside the boundary
                pt3.easting = mf.bnd.bndArr[0].bndLine[i].easting -
                    (Math.Sin(glm.PIBy2 + mf.bnd.bndArr[0].bndLine[i].heading) * (tramWidth * 0.5 - halfWheelTrack));

                pt3.northing = mf.bnd.bndArr[0].bndLine[i].northing -
                    (Math.Cos(glm.PIBy2 + mf.bnd.bndArr[0].bndLine[i].heading) * (tramWidth * 0.5 - halfWheelTrack));

                bool Add = true;

                for (int j = 0; j < ptCount; j++)
                {
                    double check = glm.DistanceSquared(pt3.northing, pt3.easting,
                                        mf.bnd.bndArr[0].bndLine[j].northing, mf.bnd.bndArr[0].bndLine[j].easting);
                    if (check < distSq)
                    {
                        Add = false;
                        break;
                    }
                }

                if (Add)
                {
                    if (tramBndOuterArr.Count > 0)
                    {
                        double dist = ((pt3.easting - tramBndOuterArr[tramBndOuterArr.Count - 1].easting) * (pt3.easting - tramBndOuterArr[tramBndOuterArr.Count - 1].easting))
                            + ((pt3.northing - tramBndOuterArr[tramBndOuterArr.Count - 1].northing) * (pt3.northing - tramBndOuterArr[tramBndOuterArr.Count - 1].northing));
                        if (dist > 1)
                            tramBndOuterArr.Add(pt3);
                    }
                    else tramBndOuterArr.Add(pt3);
                }
            }
        }

        //public void CreateBndTramTrack()
        //{
        //    //build the outer boundary
        //    tramBndOuterArr?.Clear();
        //    tramBndInnerArr?.Clear();

        //    int cnt = mf.tram.outArr.Count;

        //    if (cnt > 0)
        //    {
        //        vec2 pt = new vec2();
        //        vec2 pt2 = new vec2();

        //        for (int i = 0; i < cnt; i++)
        //        {
        //            pt.easting = mf.tram.outArr[i].easting;
        //            pt.northing = mf.tram.outArr[i].northing;
        //            tramBndOuterArr.Add(pt);

        //            pt2.easting = mf.tram.outArr[i].easting -
        //                (Math.Sin(glm.PIBy2 + mf.tram.outArr[i].heading) * mf.vehicle.trackWidth);

        //            pt2.northing = mf.tram.outArr[i].northing -
        //                (Math.Cos(glm.PIBy2 + mf.tram.outArr[i].heading) * mf.vehicle.trackWidth);
        //            tramBndOuterArr.Add(pt2);
        //        }
        //    }
        //}

        //public bool IsPointInTramBndArea(vec2 testPointv2)
        //{
        //    if (calcList.Count < 3) return false;
        //    int j = outArr.Count - 1;
        //    bool oddNodes = false;

        //    //test against the constant and multiples list the test point
        //    for (int i = 0; i < outArr.Count; j = i++)
        //    {
        //        if ((outArr[i].northing < testPointv2.northing && outArr[j].northing >= testPointv2.northing)
        //        ||  (outArr[j].northing < testPointv2.northing && outArr[i].northing >= testPointv2.northing))
        //        {
        //            oddNodes ^= ((testPointv2.northing * calcList[i].northing) + calcList[i].easting < testPointv2.easting);
        //        }
        //    }
        //    return oddNodes; //true means inside.
        //}

        //public void PreCalcTurnLines()
        //{
        //    int j = outArr.Count - 1;
        //    //clear the list, constant is easting, multiple is northing
        //    calcList.Clear();
        //    vec2 constantMultiple = new vec2(0, 0);

        //    for (int i = 0; i < outArr.Count; j = i++)
        //    {
        //        //check for divide by zero
        //        if (Math.Abs(outArr[i].northing - outArr[j].northing) < double.Epsilon)
        //        {
        //            constantMultiple.easting = outArr[i].easting;
        //            constantMultiple.northing = 0;
        //            calcList.Add(constantMultiple);
        //        }
        //        else
        //        {
        //            //determine constant and multiple and add to list
        //            constantMultiple.easting = outArr[i].easting - ((outArr[i].northing * outArr[j].easting)
        //                            / (outArr[j].northing - outArr[i].northing)) + ((outArr[i].northing * outArr[i].easting)
        //                                / (outArr[j].northing - outArr[i].northing));
        //            constantMultiple.northing = (outArr[j].easting - outArr[i].easting) / (outArr[j].northing - outArr[i].northing);
        //            calcList.Add(constantMultiple);
        //        }
        //    }
        //}
    }
}