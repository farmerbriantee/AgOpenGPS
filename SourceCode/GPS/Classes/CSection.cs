//Please, if you use this, share the improvements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgOpenGPS
{
    //each section is composed of a patchlist and triangle list
    //the triangle list makes up the individual triangles that make the block or patch of applied (green spot)
    //the patch list is a list of the list of triangles

    public class CSection
    {
        //copy of the mainform address
        private FormGPS mf;

        //list of patch data individual triangles
        public List<vec2> triangleList = new List<vec2>();

        //list of the list of patch data individual triangles for that entire section activity
        public List<List<vec2>> patchList = new List<List<vec2>>();

        //is this section on or off
        public bool isSectionOn = false;
        public bool isAllowedOn = false;
        public bool isSectionRequiredOn = false;

        public bool sectionOnRequest = false;
        public bool sectionOffRequest = false;
        public bool sectionOnOffCycle = false;

        public int sectionOnTimer = 0;
        public int sectionOffTimer = 0;

        //the left side is always negative, right side is positive
        //so a section on the left side only would be -8, -4
        //in the center -4,4  on the right side only 4,8
        //reads from left to right
        //   ------========---------||----------========---------
        //        -8      -4      -1  1         4      8
        // in (meters)

        public double positionLeft = -4;
        public double positionRight = 4;
        public double sectionWidth = 0;

        //used by readpixel to determine color in pixel array
        public int rpSectionWidth = 0;
        public int rpSectionPosition = 0;

        public vec2 leftPoint;
        public vec2 rightPoint;
 
        public vec2 lastLeftPoint;
        public vec2 lastRightPoint;

        public double sectionLookAhead = 6;

        public double squareMetersSection = 0;

        public int numTriangles = 0;

        //used to determine state of Manual section button - Off Auto On
        public AgOpenGPS.FormGPS.manBtn manBtnState = AgOpenGPS.FormGPS.manBtn.Off;

        //simple constructor, position is set in GPSWinForm_Load in FormGPS when creating new object
        public CSection(FormGPS f)
        {
            //constructor
            this.mf = f;
        }

        public void TurnSectionOn()
        {
            numTriangles = 0;

            //do not tally square meters on inital point, that would be silly
            if (!isSectionOn)
            {
                //set the section bool to on
                isSectionOn = true;

                //starting a new patch chunk so create a new triangle list
                //and add the previous triangle list to the list of paths
                triangleList = new List<vec2>();
                patchList.Add(triangleList);

                //left side of triangle
                vec2 point = new vec2(mf.cosHeading * positionLeft + mf.toolEasting,
                        mf.sinHeading * positionLeft + mf.toolNorthing);
                triangleList.Add(point);

                //Right side of triangle
                point = new vec2(mf.cosHeading * positionRight + mf.toolEasting,
                    mf.sinHeading * positionRight + mf.toolNorthing);
                triangleList.Add(point);
            }
        }

        public void TurnSectionOff()
        {
            AddPathPoint(mf.toolNorthing, mf.toolEasting, mf.cosHeading, mf.sinHeading);
            isSectionOn = false;
            numTriangles = 0;
        }


        //every time a new fix, a new patch point from last point to this point
        //only need prev point on the first points of triangle strip that makes a box (2 triangles)

        public void AddPathPoint(double northing, double easting, double cosHeading, double sinHeading)
        {
   
            //add two triangles for next step.
            //left side
            vec2 point = new vec2(cosHeading * (positionLeft) + easting,
                sinHeading * (positionLeft) + northing);

            //add the point to List
            triangleList.Add(point);

            //Right side
            vec2 point2 = new vec2(cosHeading * (positionRight) + easting,
                sinHeading * (positionRight) + northing);

            //add the point to the list
            triangleList.Add(point2);

            //count the triangle pairs
            numTriangles++;

            //quick count
            int c = triangleList.Count-1;

            //when closing a job the triangle patches all are emptied but the section delay keeps going. 
            //Prevented by quick check.
            if (c > 3)
            {
                //acres calculated from last right point to previous right side
                double lastDistance = mf.pn.Distance(triangleList[c].x, triangleList[c].z, triangleList[c - 2].x, triangleList[c - 2].z);

                //tally sq meters for this section and add to total of all sections    
                double temp = (lastDistance * sectionWidth);
                mf.totalSquareMeters += temp;
                squareMetersSection += temp;
            }

            if (numTriangles > 36)
            {
                numTriangles = 0;

                triangleList = new List<vec2>();
                patchList.Add(triangleList);

                //add the points to List, yes its more points, but breaks up patches for culling
                triangleList.Add(point);
                triangleList.Add(point2);

            }
        }
        
    }
}
