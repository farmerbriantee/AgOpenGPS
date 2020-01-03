using System.Collections.Generic;

namespace AgOpenGPS
{
    internal class CMazePath
    {
        /// <summary>
        /// Class attributes/members
        /// </summary>
        readonly private int[] mazeGrid;

        readonly private int numCols;
        readonly private int numMax;

        /// <summary>
        /// Constructor 2: initializes the dimensions of maze,
        /// later, indexers may be used to set individual elements' values
        /// </summary>
        public CMazePath(int iRows, int iCols, int[] _iMaze)
        {
            numMax = iRows * iCols;
            mazeGrid = _iMaze;
            numCols = iCols;
        }

        /// <summary>
        /// Internal function for that finds the shortest path using a technique
        /// similar to breadth-first search.
        /// It assigns a node no. to each node(2D array element) and applies the algorithm
        /// </summary>
        private enum Status
        { Ready, Waiting, Processed }

        public List<vec3> Search(int iFromY, int iFromX, int iToY, int iToX)
        {
            List<vec3> mazeList = new List<vec3>();

            int iStart = (int)((iFromY * numCols) + iFromX);
            int iStop = (int)((iToY * numCols) + iToX);

            const int empty = 0;

            int[] Queue = new int[numMax];
            int[] Origin = new int[numMax];
            int iFront = 0, iRear = 0;

            //check if starting and ending points are valid (open)
            if (mazeGrid[iStart] != empty || mazeGrid[iStop] != empty)
            {
                return null;
            }

            //create dummy array for storing status
            int[] iMazeStatus = new int[numMax];
            //initially all nodes are ready
            for (int i = 0; i < numMax; i++)
                iMazeStatus[i] = (int)Status.Ready;

            //add starting node to Q
            Queue[iRear] = iStart;
            Origin[iRear] = -1;
            iRear++;
            int iCurrent, iLeft, iRight, iUp, iDown, iRightUp, iRightDown, iLeftUp, iLeftDown;
            while (iFront != iRear) // while Q not empty
            {
                if (Queue[iFront] == iStop)     // maze is solved
                    break;

                iCurrent = Queue[iFront];

                iLeft = iCurrent - 1;
                if (iLeft >= 0 && iLeft / numCols == iCurrent / numCols)    //if left node exists
                {
                    if (mazeGrid[iLeft] == empty)   //if left node is open(a path exists)
                    {
                        if (iMazeStatus[iLeft] == (int)Status.Ready)   //if left node is ready
                        {
                            Queue[iRear] = iLeft; //add to Q
                            Origin[iRear] = iCurrent;
                            iMazeStatus[iLeft] = (int)Status.Waiting; //change status to waiting
                            iRear++;
                        }
                    }
                }

                iRight = iCurrent + 1;
                if (iRight < numMax && iRight / numCols == iCurrent / numCols)    //if right node exists
                {
                    if (mazeGrid[iRight] == empty)  //if right node is open(a path exists)
                    {
                        if (iMazeStatus[iRight] == (int)Status.Ready)  //if right node is ready
                        {
                            Queue[iRear] = iRight; //add to Q
                            Origin[iRear] = iCurrent;
                            iMazeStatus[iRight] = (int)Status.Waiting; //change status to waiting
                            iRear++;
                        }
                    }
                }

                iUp = iCurrent + numCols;
                if (iUp < numMax)  //if top node exists
                {
                    if (mazeGrid[iUp] == empty)    //if top node is open(a path exists)
                    {
                        if (iMazeStatus[iUp] == (int)Status.Ready)    //if top node is ready
                        {
                            Queue[iRear] = iUp; //add to Q
                            Origin[iRear] = iCurrent;
                            iMazeStatus[iUp] = (int)Status.Waiting; //change status to waiting
                            iRear++;
                        }
                    }
                }

                iDown = iCurrent - numCols;
                if (iDown >= 0)   //if bottom node exists
                {
                    if (mazeGrid[iDown] == empty)   //if bottom node is open(a path exists)
                    {
                        if (iMazeStatus[iDown] == (int)Status.Ready)   //if bottom node is ready
                        {
                            Queue[iRear] = iDown; //add to Q
                            Origin[iRear] = iCurrent;
                            iMazeStatus[iDown] = (int)Status.Waiting; //change status to waiting
                            iRear++;
                        }
                    }
                }
                //if (diagonal == true)
                {
                    iRightDown = iCurrent - numCols + 1;
                    if (iRightDown < numMax && iRightDown >= 0 && iRightDown / numCols == (iCurrent / numCols) - 1)     //if bottom-right node exists
                    {
                        if (mazeGrid[iRightDown] == empty)  //if this node is open(a path exists)
                        {
                            if (iMazeStatus[iRightDown] == (int)Status.Ready)  //if this node is ready
                            {
                                Queue[iRear] = iRightDown; //add to Q
                                Origin[iRear] = iCurrent;
                                iMazeStatus[iRightDown] = (int)Status.Waiting; //change status to waiting
                                iRear++;
                            }
                        }
                    }

                    iRightUp = iCurrent + numCols + 1;
                    if (iRightUp >= 0 && iRightUp < numMax && iRightUp / numCols == (iCurrent / numCols) + 1)   //if upper-right node exists
                    {
                        if (mazeGrid[iRightUp] == empty)    //if this node is open(a path exists)
                        {
                            if (iMazeStatus[iRightUp] == (int)Status.Ready)    //if this node is ready
                            {
                                Queue[iRear] = iRightUp; //add to Q
                                Origin[iRear] = iCurrent;
                                iMazeStatus[iRightUp] = (int)Status.Waiting; //change status to waiting
                                iRear++;
                            }
                        }
                    }

                    iLeftDown = iCurrent - numCols - 1;
                    if (iLeftDown < numMax && iLeftDown >= 0 && iLeftDown / numCols == (iCurrent / numCols) - 1)    //if bottom-left node exists
                    {
                        if (mazeGrid[iLeftDown] == empty)   //if this node is open(a path exists)
                        {
                            if (iMazeStatus[iLeftDown] == (int)Status.Ready)   //if this node is ready
                            {
                                Queue[iRear] = iLeftDown; //add to Q
                                Origin[iRear] = iCurrent;
                                iMazeStatus[iLeftDown] = (int)Status.Waiting; //change status to waiting
                                iRear++;
                            }
                        }
                    }

                    iLeftUp = iCurrent + numCols - 1;
                    if (iLeftUp >= 0 && iLeftUp < numMax && iLeftUp / numCols == (iCurrent / numCols) + 1)  //if upper-left node exists
                    {
                        if (mazeGrid[iLeftUp] == empty)     //if this node is open(a path exists)
                        {
                            if (iMazeStatus[iLeftUp] == (int)Status.Ready) //if this node is ready
                            {
                                Queue[iRear] = iLeftUp; //add to Q
                                Origin[iRear] = iCurrent;
                                iMazeStatus[iLeftUp] = (int)Status.Waiting; //change status to waiting
                                iRear++;
                            }
                        }
                    }
                }

                //change status of current node to processed
                iMazeStatus[iCurrent] = (int)Status.Processed;
                iFront++;
            }

            vec3 ptt = new vec3();

            iCurrent = iStop;
            //Y
            ptt.northing = iCurrent / numCols;
            //X
            ptt.easting = iCurrent - (iCurrent / numCols * numCols);

            mazeList?.Clear();
            mazeList.Add(ptt);

            for (int i = iFront; i >= 0; i--)
            {
                if (Queue[i] == iCurrent)
                {
                    iCurrent = Origin[i];
                    if (iCurrent == -1)     // maze is solved
                        return mazeList;
                    //add point
                    ptt.northing = iCurrent / numCols; //Y
                    ptt.easting = iCurrent - (iCurrent / numCols * numCols); //X
                    mazeList.Add(ptt);
                }
            }

            //no path exists
            return null;
        }
    }
}

/// <summary>
/// The function is used to get the contents of a given node in a given maze,
///  specified by its node no.
/// </summary>
//private int GetNodeContents(int[,] iMaze, int iNodeNo)
//{
//    int iCols = iMaze.GetLength(1);
//    return iMaze[iNodeNo / iCols, iNodeNo - iNodeNo / iCols * iCols];
//}

///// <summary>
///// The function is used to change the contents of a given node in a given maze,
/////  specified by its node no.
///// </summary>
//private void ChangeNodeContents(int[,] iMaze, int iNodeNo, int iNewValue)
//{
//    int iCols = iMaze.GetLength(1);
//    iMaze[iNodeNo / iCols, iNodeNo - iNodeNo / iCols * iCols] = iNewValue;
//}