//Please, if you use this, share the improvements

using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    //each section is composed of a patchlist and triangle list
    //the triangle list makes up the individual triangles that make the block or patch of applied (green spot)
    //the patch list is a list of the list of triangles

    public class CSection
    {
        //copy of the mainform address
        private readonly FormGPS mf;

        //list of patch data individual triangles
        public List<vec3> triangleList = new List<vec3>();

        //list of the list of patch data individual triangles for that entire section activity
        public List<List<vec3>> patchList = new List<List<vec3>>();

        //is this section on or off
        public bool isSectionOn = false;

        public bool isAllowedOn = false;
        public bool isSectionRequiredOn = false;

        public bool sectionOnRequest = false;
        public bool sectionOffRequest = false;
        public bool sectionOnOffCycle = false;

        public int sectionOnTimer = 0;
        public int sectionOffTimer = 0;

        //mapping
        public bool isMappingOn = false;

        public bool isMappingAllowedOn = false;
        public bool isMappingRequiredOn = false;

        public bool mappingOnRequest = false;
        public bool mappingOffRequest = false;
        public bool mappingOnOffCycle = false;
        public int mappingOnTimer = 0;
        public int mappingOffTimer = 0;

        public double speedPixels = 0;


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

        public double foreDistance = 0;

        //used by readpixel to determine color in pixel array
        public int rpSectionWidth = 0;
        public int rpSectionPosition = 0;

        //points in world space that start and end of section are in
        public vec2 leftPoint;
        public vec2 rightPoint;

        //used to determine left and right speed of section
        public vec2 lastLeftPoint;
        public vec2 lastRightPoint;

        //whether or not this section is in boundary, headland
        public bool isInBoundary = true, isHydLiftInWorkArea = true;
        public bool isInHeadlandArea = true;
        public bool isLookOnInHeadland = true;
        public int numTriangles = 0;

        //used to determine state of Manual section button - Off Auto On
        public FormGPS.manBtn manBtnState = FormGPS.manBtn.Off;

        //simple constructor, position is set in GPSWinForm_Load in FormGPS when creating new object
        public CSection(FormGPS _f)
        {
            //constructor
            mf = _f;
            patchList.Capacity = 2048;
            //triangleList.Capacity = 
        }

        public void TurnMappingOn(int j)
        {
            numTriangles = 0;

            //do not tally square meters on inital point, that would be silly
            if (!isMappingOn)
            {
                //set the section bool to on
                isMappingOn = true;

                //starting a new patch chunk so create a new triangle list
                triangleList = new List<vec3>(32);

                patchList.Add(triangleList);

                if (!mf.tool.isMultiColoredSections)
                {
                    vec3 colur = new vec3(mf.sectionColorDay.R, mf.sectionColorDay.G, mf.sectionColorDay.B);
                    triangleList.Add(colur);
                }

                else
                {
                    vec3 collor = new vec3(mf.tool.secColors[j].R, mf.tool.secColors[j].G, mf.tool.secColors[j].B);
                    triangleList.Add(collor);
                }

                //left side of triangle
                vec3 point = new vec3(leftPoint.easting, leftPoint.northing, 0);
                triangleList.Add(point);

                //Right side of triangle
                point = new vec3(rightPoint.easting, rightPoint.northing, 0);
                triangleList.Add(point);
            }
        }

        public void TurnMappingOff()
        {
            AddMappingPoint(0);

            isMappingOn = false;
            numTriangles = 0;

            if (triangleList.Count > 4)
            {
                //save the triangle list in a patch list to add to saving file
                mf.patchSaveList.Add(triangleList);
            }
            else
            {
                triangleList.Clear();
                if (patchList.Count > 0) patchList.RemoveAt(patchList.Count - 1);
            }
        }

        //every time a new fix, a new patch point from last point to this point
        //only need prev point on the first points of triangle strip that makes a box (2 triangles)

        public void AddMappingPoint(int j)
        {
            //add two triangles for next step.
            //left side
            vec3 point = new vec3(leftPoint.easting, leftPoint.northing, 0);

            //add the point to List
            triangleList.Add(point);

            //Right side
            vec3 point2 = new vec3(rightPoint.easting, rightPoint.northing, 0);

            //add the point to the list
            triangleList.Add(point2);

            //count the triangle pairs
            numTriangles++;

            //quick count
            int c = triangleList.Count - 1;

            //when closing a job the triangle patches all are emptied but the section delay keeps going.
            //Prevented by quick check. 4 points plus colour
            if (c >= 5)
            {
                //calculate area of these 2 new triangles - AbsoluteValue of (Ax(By-Cy) + Bx(Cy-Ay) + Cx(Ay-By)/2)
                {
                    double temp = (triangleList[c].easting * (triangleList[c - 1].northing - triangleList[c - 2].northing))
                              + (triangleList[c - 1].easting * (triangleList[c - 2].northing - triangleList[c].northing))
                                  + (triangleList[c - 2].easting * (triangleList[c].northing - triangleList[c - 1].northing));

                    temp = Math.Abs(temp / 2.0);
                    mf.fd.workedAreaTotal += temp;
                    mf.fd.workedAreaTotalUser += temp;

                    //temp = 0;
                    temp = (triangleList[c - 1].easting * (triangleList[c - 2].northing - triangleList[c - 3].northing))
                              + (triangleList[c - 2].easting * (triangleList[c - 3].northing - triangleList[c - 1].northing))
                                  + (triangleList[c - 3].easting * (triangleList[c - 1].northing - triangleList[c - 2].northing));

                    temp = Math.Abs(temp / 2.0);
                    mf.fd.workedAreaTotal += temp;
                    mf.fd.workedAreaTotalUser += temp;
                }
            }

            if (numTriangles > 61)
            {
                numTriangles = 0;

                //save the cutoff patch to be saved later
                mf.patchSaveList.Add(triangleList);

                triangleList = new List<vec3>(32);

                patchList.Add(triangleList);

                //Add Patch colour
                if (!mf.tool.isMultiColoredSections)
                    triangleList.Add(new vec3(mf.sectionColorDay.R, mf.sectionColorDay.G, mf.sectionColorDay.B));
                else
                    triangleList.Add(new vec3(mf.tool.secColors[j].R, mf.tool.secColors[j].G, mf.tool.secColors[j].B));

                //add the points to List, yes its more points, but breaks up patches for culling
                triangleList.Add(point);
                triangleList.Add(point2);
            }
        }
    }
}