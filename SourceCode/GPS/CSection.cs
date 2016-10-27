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
        private FormGPS mainForm;

        //list of patch data individual triangles
        public List<vec3> triangleList = new List<vec3>();

        //list of the list of patch data individual triangles for that entire section activity
        public List<List<vec3>> patchList = new List<List<vec3>>();

        //is this section on or off
        public bool isSectionOn = false;

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

        //simple constructor, position is set in GPSWinForm_Load in FormGPS when creating new object
        public CSection(FormGPS f)
        {
            //constructor
            this.mainForm = f;
        }

        public void TurnSectionOn()
        {
            if (mainForm.isMasterSectionOn && !isSectionOn)
            {
                //set the section bool to on
                isSectionOn = true;

                double north = mainForm.pn.northing + mainForm.vehicle.toolForeAft * mainForm.cosHeading;
                double east = mainForm.pn.easting + mainForm.vehicle.toolForeAft * -mainForm.sinHeading;

                //set the start of section to prev.
                mainForm.prevSectionNorthing = north;
                mainForm.prevSectionEasting = east;
 
                //starting a new patch chunk so create a new triangle list
                //and add the previous triangle list to the list of paths
                triangleList = new List<vec3>();
                patchList.Add(triangleList);

                //left side of triangle
                vec3 point = new vec3(mainForm.cosHeading * positionLeft + east,
                        0, mainForm.sinHeading * positionLeft + north);
                triangleList.Add(point);

                //Right side of triangle
                point = new vec3(mainForm.cosHeading * positionRight + east,
                    0, mainForm.sinHeading * positionRight + north);
                triangleList.Add(point);

                //left side of triangle
                point = new vec3(mainForm.cosHeading * positionLeft + east,
                        0, mainForm.sinHeading * positionLeft + north);
                triangleList.Add(point);

                //Right side of triangle
                point = new vec3(mainForm.cosHeading * positionRight + east,
                    0, mainForm.sinHeading * positionRight + north);
                triangleList.Add(point);

                

            }            
           
        }

        public void TurnSectionOff()
        {
            double north = mainForm.pn.northing + mainForm.vehicle.toolForeAft * mainForm.cosHeading;
            double east = mainForm.pn.easting + mainForm.vehicle.toolForeAft * -mainForm.sinHeading;

            AddPathPoint(north, east, mainForm.cosHeading, mainForm.sinHeading);

            double tempAcres = mainForm.pn.Distance(north, east, mainForm.prevSectionNorthing, mainForm.prevSectionEasting);
            mainForm.totalSquareMeters += tempAcres * sectionWidth;

            isSectionOn = false;
            
        }




        //every time a new fix, a new patch point from last point to this point
        //only need prev point on the first points of triangle strip that makes a box (2 triangles)
        public void AddPathPoint(double northing, double easting, double cosHeading, double sinHeading)
        {
   
            //add two triangles for next step.
                //left side
                vec3 point = new vec3(cosHeading * (positionLeft) + easting,
                        0, sinHeading * (positionLeft) + northing);
                triangleList.Add(point);

                //Right side
                point = new vec3(cosHeading * (positionRight) + easting,
                    0, sinHeading * (positionRight) + northing);
                triangleList.Add(point);                        
             }

    }


}
