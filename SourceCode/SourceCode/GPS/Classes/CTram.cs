using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace AgOpenGPS
{

    public class CTram
    {
        private readonly FormGPS mf;

        //the list of constants and multiples of the boundary
        public List<vec2> calcList = new List<vec2>();

        //the outer ring of boundary tram - also used for clipping
        public List<vec3> outArr = new List<vec3>();

        //the triangle strip of the outer tram highlight
        public List<vec2> tramBndArr = new List<vec2>();

        //tram settings
        public double wheelTrack;
        public double tramWidth, abOffset;
        public double halfWheelTrack;
        public int passes;

        // 0 off, 1 All, 2, Lines, 3 Outer
        public int displayMode;

        public CTram(FormGPS _f)
        {
            //constructor
            mf = _f;

            tramWidth = Properties.Settings.Default.setTram_eqWidth;
            wheelTrack = Properties.Settings.Default.setTram_wheelSpacing;
            halfWheelTrack = wheelTrack * 0.5;

            passes = Properties.Settings.Default.setTram_passes;
            abOffset = (Math.Round((mf.tool.toolWidth - mf.tool.toolOverlap) / 2.0, 3));
            displayMode = 0;
        }

        public void DrawTramBnd()
        {
            if (tramBndArr.Count > 0)
            {
                GL.Color4(0.8630f, 0.73692f, 0.60f, 0.25);
                GL.Begin(PrimitiveType.TriangleStrip);
                for (int h = 0; h < tramBndArr.Count; h++) GL.Vertex3(tramBndArr[h].easting, tramBndArr[h].northing, 0);
                GL.End();
            }
        }

        public void BuildTramBnd()
        {
            //abOffset = (Math.Round((mf.tool.toolWidth - mf.tool.toolOverlap) / 2.0, 3));

            bool isBndExist = mf.bnd.bndArr.Count != 0;

            if (isBndExist)
            {
                CreateBndTramRef();
                CreateOuterTram();
                PreCalcTurnLines();
            }
            else
            {
                outArr?.Clear();
                tramBndArr?.Clear();
            }
        }

        public void CreateBndTramRef()
        {
            //count the points from the boundary
            int ptCount = mf.bnd.bndArr[0].bndLine.Count;
            outArr?.Clear();

            //outside point
            vec3 pt3 = new vec3();

            double distSq = ((tramWidth * 0.5) - halfWheelTrack) * ((tramWidth * 0.5) - halfWheelTrack) * 0.97;
            bool fail = false;

            //make the boundary tram outer array
            for (int i = 0; i < ptCount; i++)
            {
                //calculate the point inside the boundary
                pt3.easting = mf.bnd.bndArr[0].bndLine[i].easting -
                    (Math.Sin(glm.PIBy2 + mf.bnd.bndArr[0].bndLine[i].heading) * (tramWidth * 0.5 - halfWheelTrack));

                pt3.northing = mf.bnd.bndArr[0].bndLine[i].northing -
                    (Math.Cos(glm.PIBy2 + mf.bnd.bndArr[0].bndLine[i].heading) * (tramWidth * 0.5 - halfWheelTrack));

                for (int j = 0; j < ptCount; j++)
                {
                    double check = glm.DistanceSquared(pt3.northing, pt3.easting,
                                        mf.bnd.bndArr[0].bndLine[j].northing, mf.bnd.bndArr[0].bndLine[j].easting);
                    if (check < distSq)
                    {
                        fail = true;
                        break;
                    }
                }

                if (!fail)
                {
                    pt3.heading = mf.bnd.bndArr[0].bndLine[i].heading;
                    outArr.Add(pt3);
                }
                fail = false;
            }

            int cnt = outArr.Count;
            if (cnt < 6) return;

            const double spacing = 2.0;
            double distance;
            for (int i = 0; i < cnt - 1; i++)
            {
                distance = glm.Distance(outArr[i], outArr[i + 1]);
                if (distance < spacing)
                {
                    outArr.RemoveAt(i + 1);
                    cnt = outArr.Count;
                    i--;
                }
            }
        }

        public void CreateOuterTram()
        {
            //build the outer boundary
            tramBndArr?.Clear();

            int cnt = mf.tram.outArr.Count;

            if (cnt > 0)
            {
                vec2 pt = new vec2();
                vec2 pt2 = new vec2();

                for (int i = 0; i < cnt; i++)
                {
                    pt.easting = mf.tram.outArr[i].easting;
                    pt.northing = mf.tram.outArr[i].northing;
                    tramBndArr.Add(pt);

                    pt2.easting = mf.tram.outArr[i].easting -
                        (Math.Sin(glm.PIBy2 + mf.tram.outArr[i].heading) * mf.tram.wheelTrack);

                    pt2.northing = mf.tram.outArr[i].northing -
                        (Math.Cos(glm.PIBy2 + mf.tram.outArr[i].heading) * mf.tram.wheelTrack);
                    tramBndArr.Add(pt2);
                }
            }
        }

        public bool IsPointInTramBndArea(vec2 testPointv2)
        {
            if (calcList.Count < 3) return false;
            int j = outArr.Count - 1;
            bool oddNodes = false;

            //test against the constant and multiples list the test point
            for (int i = 0; i < outArr.Count; j = i++)
            {
                if ((outArr[i].northing < testPointv2.northing && outArr[j].northing >= testPointv2.northing)
                ||  (outArr[j].northing < testPointv2.northing && outArr[i].northing >= testPointv2.northing))
                {
                    oddNodes ^= ((testPointv2.northing * calcList[i].northing) + calcList[i].easting < testPointv2.easting);
                }
            }
            return oddNodes; //true means inside.
        }

        public void PreCalcTurnLines()
        {
            int j = outArr.Count - 1;
            //clear the list, constant is easting, multiple is northing
            calcList.Clear();
            vec2 constantMultiple = new vec2(0, 0);

            for (int i = 0; i < outArr.Count; j = i++)
            {
                //check for divide by zero
                if (Math.Abs(outArr[i].northing - outArr[j].northing) < double.Epsilon)
                {
                    constantMultiple.easting = outArr[i].easting;
                    constantMultiple.northing = 0;
                    calcList.Add(constantMultiple);
                }
                else
                {
                    //determine constant and multiple and add to list
                    constantMultiple.easting = outArr[i].easting - ((outArr[i].northing * outArr[j].easting)
                                    / (outArr[j].northing - outArr[i].northing)) + ((outArr[i].northing * outArr[i].easting)
                                        / (outArr[j].northing - outArr[i].northing));
                    constantMultiple.northing = (outArr[j].easting - outArr[i].easting) / (outArr[j].northing - outArr[i].northing);
                    calcList.Add(constantMultiple);
                }
            }
        }
    }
}
