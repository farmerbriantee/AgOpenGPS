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
        public List<vec3> triangleList = new List<vec3>();

        //list of the list of patch data individual triangles for that entire section activity
        public List<List<vec3>> patchList = new List<List<vec3>>();

        //is this section on or off
        public bool isSectionOn = false;
        public bool isAllowedOn = false;

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

        public double sectionLookAhead = 0;

        private vec3 leftPoint;
        private vec3 rightPoint;
        private vec3 lastLeftPoint;
        private vec3 lastRightPoint;


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
            //if (mf.isMasterSectionOn && !isSectionOn)
            if (!isSectionOn )
            {
                //set the section bool to on
                isSectionOn = true;

                //set the start of section to prev.
                mf.prevSectionNorthing = mf.toolNorthing;
                mf.prevSectionEasting = mf.toolEasting;
 
                //starting a new patch chunk so create a new triangle list
                //and add the previous triangle list to the list of paths
                triangleList = new List<vec3>();
                patchList.Add(triangleList);

                //left side of triangle
                vec3 point = new vec3(mf.cosHeading * positionLeft + mf.toolEasting,
                        0, mf.sinHeading * positionLeft + mf.toolNorthing);
                triangleList.Add(point);

                //Right side of triangle
                point = new vec3(mf.cosHeading * positionRight + mf.toolEasting,
                    0, mf.sinHeading * positionRight + mf.toolNorthing);
                triangleList.Add(point);

                //left side of triangle
                point = new vec3(mf.cosHeading * positionLeft + mf.toolEasting,
                        0, mf.sinHeading * positionLeft + mf.toolNorthing);
                triangleList.Add(point);

                //Right side of triangle
                point = new vec3(mf.cosHeading * positionRight + mf.toolEasting,
                    0, mf.sinHeading * positionRight + mf.toolNorthing);
                triangleList.Add(point);
            }          
        }

        public void TurnSectionOff()
        {
            AddPathPoint(mf.toolNorthing, mf.toolEasting, mf.cosHeading, mf.sinHeading);

            double tempAcres = mf.pn.Distance(mf.toolNorthing, mf.toolEasting, mf.prevSectionNorthing, mf.prevSectionEasting);
            mf.totalSquareMeters += tempAcres * sectionWidth;

            isSectionOn = false;            
        }

        //every time a new fix, a new patch point from last point to this point
        //only need prev point on the first points of triangle strip that makes a box (2 triangles)
        public void AddPathPoint(double northing, double easting, double cosHeading, double sinHeading)
        {
   
            //save points so we can calculate speed.
            lastLeftPoint = leftPoint;
            lastRightPoint = rightPoint;
            //add two triangles for next step.
            //left side
            leftPoint = new vec3(cosHeading * (positionLeft) + easting,
                                 0, sinHeading * (positionLeft) + northing);

            //Right side
            rightPoint = new vec3(cosHeading * (positionRight) + easting,
                                  0, sinHeading * (positionRight) + northing);
            if (isSectionOn) {
                //if the distance traveled to these new points is not greater
                //than a certain distance, just overwrite those points...
                int c = triangleList.Count;

                if (c > 2 &&
                    ((triangleList[c-2] - leftPoint).Magnitude2() < 0.01 &&
                     (triangleList[c-1] - rightPoint).Magnitude2() < 0.01)) {
                    triangleList[c-2] = leftPoint;
                    triangleList[c-1] = rightPoint;
                    System.Console.WriteLine("condensing triangle.");
                } else {
                    triangleList.Add(leftPoint);
                    triangleList.Add(rightPoint);                        
                }
            }
        }

        //update the last path point rather than create a new one.  Saves
        //on triangles, but lets our display stay right with the machine.
        //As well this will ensure we get continual section speeds as we go.
        public void UpdatePathPoint(double northing, double easting, double cosHeading, double sinHeading)
        {
   
            //save points so we can calculate speed.
            lastLeftPoint = leftPoint;
            lastRightPoint = rightPoint;
            //add two triangles for next step.
            //left side
            leftPoint = new vec3(cosHeading * (positionLeft) + easting,
                                 0, sinHeading * (positionLeft) + northing);

            //Right side
            rightPoint = new vec3(cosHeading * (positionRight) + easting,
                                  0, sinHeading * (positionRight) + northing);
            if (isSectionOn) {
                //if the distance traveled to these new points is not greater
                //than a certain distance, just overwrite those points...
                int c = triangleList.Count;

                if (c > 2) {
                    triangleList[c-2] = leftPoint;
                    triangleList[c-1] = rightPoint;
                } else {
                    triangleList.Add(leftPoint);
                    triangleList.Add(rightPoint);                        
                }
            }
        }



        public void CalculateSpeed(double toolHeading, double elapsedTime, double lookAhead) {
            if (elapsedTime > 0) {
                vec3 left = leftPoint - lastLeftPoint;
                vec3 right = rightPoint - lastRightPoint;

                double leftSpeed = left.Magnitude() / elapsedTime;
                double rightSpeed = right.Magnitude() / elapsedTime;

                if (leftSpeed > rightSpeed) {
                    sectionLookAhead = leftSpeed * lookAhead;
                } else {
                    sectionLookAhead = rightSpeed * lookAhead;
                }

                // EXPERIMENTAL, determine if entire section is going backwards
                if (Math.PI - Math.Abs(Math.Abs(left.HeadingXZ() - toolHeading) - Math.PI) > 1.8 &&
                    Math.PI - Math.Abs(Math.Abs(right.HeadingXZ() - toolHeading) - Math.PI) > 1.8) {
                    sectionLookAhead = -sectionLookAhead;
                }
            }
        }
    }
}
