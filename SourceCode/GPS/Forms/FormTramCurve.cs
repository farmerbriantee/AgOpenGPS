using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormTramCurve : Form
    {
        //access to the main GPS form and all its variables
        private readonly FormGPS mf = null;

        private double maxFieldX, maxFieldY, minFieldX, minFieldY, fieldCenterX, fieldCenterY, maxFieldDistance;

        //list of coordinates of boundary line
        public List<vec3> turnLine = new List<vec3>();

        private vec3[] arr;
        //private Point fixPt;

        //private bool isA = true;
        public vec3 pint = new vec3(0.0, 1.0, 0.0);

        private double snapAdj = 0;

        public FormTramCurve(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;

            InitializeComponent();

            this.Text = gStr.gsTramLines;               

            nudWheelSpacing.Controls[0].Enabled = false;
            nudSnapAdj.Controls[0].Enabled = false;
            nudEqWidth.Controls[0].Enabled = false;
            nudPasses.Controls[0].Enabled = false;
            nudOffset.Controls[0].Enabled = false;
        }

        private void FormTram_Load(object sender, EventArgs e)
        {
            int cnt = mf.bnd.bndArr[0].bndLine.Count;
            arr = new vec3[cnt];

            for (int i = 0; i < cnt; i++)
            {
                arr[i].easting = mf.bnd.bndArr[0].bndLine[i].easting;
                arr[i].northing = mf.bnd.bndArr[0].bndLine[i].northing;
                arr[i].heading = mf.bnd.bndArr[0].bndLine[i].northing;
            }


            mf.ABLine.tramWidth = Properties.Settings.Default.setTram_eqWidth;
            mf.ABLine.tramWheelSpacing = Properties.Settings.Default.setTram_wheelSpacing;
            mf.ABLine.tramPasses = Properties.Settings.Default.setTram_passes;
            mf.ABLine.tramOffset = Properties.Settings.Default.setTram_offset;

            nudSnapAdj.Value = (decimal)((mf.vehicle.toolWidth - mf.vehicle.toolOffset)/2.0);
            nudEqWidth.Value = (decimal)Properties.Settings.Default.setTram_eqWidth;
            nudWheelSpacing.Value = (decimal)Properties.Settings.Default.setTram_wheelSpacing;
            nudPasses.Value = Properties.Settings.Default.setTram_passes;
            nudOffset.Value = (decimal)Properties.Settings.Default.setTram_offset;

            mf.ABLine.BuildTram();
            cboxTramPassEvery.SelectedIndexChanged -= cboxTramPassEvery_SelectedIndexChanged;
            cboxTramPassEvery.Text = Properties.Vehicle.Default.setTram_Skips.ToString();
            cboxTramPassEvery.SelectedIndexChanged += cboxTramPassEvery_SelectedIndexChanged;
            mf.ABLine.tramPassEvery = Properties.Vehicle.Default.setTram_Skips;

            cboxTramBasedOn.SelectedIndexChanged -= cboxTramBasedOn_SelectedIndexChanged;
            cboxTramBasedOn.Text = Properties.Vehicle.Default.setTram_BasedOn.ToString();
            cboxTramBasedOn.SelectedIndexChanged += cboxTramBasedOn_SelectedIndexChanged;
            mf.ABLine.tramBasedOn = Properties.Vehicle.Default.setTram_BasedOn;

            mf.ABLine.isEditing = true;
            mf.layoutPanelRight.Enabled = false;

            this.Left = mf.Width - 430;
            this.Top = 100;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            int idx = mf.ABLine.numABLineSelected - 1;

            if (idx >= 0)
            {

                mf.ABLine.lineArr[idx].heading = mf.ABLine.abHeading;
                //calculate the new points for the reference line and points
                mf.ABLine.lineArr[idx].origin.easting = mf.ABLine.refPoint1.easting;
                mf.ABLine.lineArr[idx].origin.northing = mf.ABLine.refPoint1.northing;

                //sin x cos z for endpoints, opposite for additional lines
                mf.ABLine.lineArr[idx].ref1.easting = mf.ABLine.lineArr[idx].origin.easting - (Math.Sin(mf.ABLine.lineArr[idx].heading) * 2000.0);
                mf.ABLine.lineArr[idx].ref1.northing = mf.ABLine.lineArr[idx].origin.northing - (Math.Cos(mf.ABLine.lineArr[idx].heading) * 2000.0);
                mf.ABLine.lineArr[idx].ref2.easting = mf.ABLine.lineArr[idx].origin.easting + (Math.Sin(mf.ABLine.lineArr[idx].heading) * 2000.0);
                mf.ABLine.lineArr[idx].ref2.northing = mf.ABLine.lineArr[idx].origin.northing + (Math.Cos(mf.ABLine.lineArr[idx].heading) * 2000.0);
            }

            mf.FileSaveABLines();

            mf.ABLine.moveDistance = 0;
            mf.ABLine.isEditing = false;
            mf.layoutPanelRight.Enabled = true;

            mf.offX = 0;
            mf.offY = 0;

            Close();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            double dist = 0.1;
            mf.ABLine.MoveABLine(-dist);
            mf.ABLine.BuildTram();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            double dist = 0.1;
            mf.ABLine.MoveABLine(dist);
            mf.ABLine.BuildTram();
        }

        private void btnLeftFullWidth_Click(object sender, EventArgs e)
        {
            double dist = mf.vehicle.toolWidth - mf.vehicle.toolOverlap;

            mf.ABLine.MoveABLine(-dist);
            mf.ABLine.BuildTram();

        }

        private void btnRightFullWidth_Click(object sender, EventArgs e)
        {
            double dist = mf.vehicle.toolWidth - mf.vehicle.toolOverlap;

            mf.ABLine.MoveABLine(dist);
            mf.ABLine.BuildTram();
        }

        private void btnAdjLeft_Click(object sender, EventArgs e)
        {
            mf.ABLine.MoveABLine(-snapAdj);
            mf.ABLine.BuildTram();
        }

        private void btnAdjRight_Click(object sender, EventArgs e)
        {
            mf.ABLine.BuildTram();
            mf.ABLine.MoveABLine(snapAdj);
        }


        //determine mins maxs of patches and whole field.
        private void nudSnapAdj_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void nudPasses_ValueChanged(object sender, EventArgs e)
        {
            mf.ABLine.tramPasses = (int)nudPasses.Value;
            Properties.Settings.Default.setTram_passes = mf.ABLine.tramPasses;
            Properties.Settings.Default.Save();
            mf.ABLine.BuildTram();
        }

        private void nudPasses_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
            mf.ABLine.BuildTram();
        }

        private void btnCreateTramLines_Click(object sender, EventArgs e)
        {
            mf.ABLine.BuildTram();
        }

        private void nudOffset_ValueChanged(object sender, EventArgs e)
        {
            mf.ABLine.tramOffset = (double)nudOffset.Value;
            Properties.Settings.Default.setTram_offset = mf.ABLine.tramOffset;
            Properties.Settings.Default.Save();
            mf.ABLine.BuildTram();
        }

        private void nudOffset_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void btnSwapAB_Click(object sender, EventArgs e)
        {
            mf.ABLine.abHeading += Math.PI;
            if (mf.ABLine.abHeading > glm.twoPI) mf.ABLine.abHeading -= glm.twoPI;

            mf.ABLine.refABLineP1.easting = mf.ABLine.refPoint1.easting - (Math.Sin(mf.ABLine.abHeading) * 4000.0);
            mf.ABLine.refABLineP1.northing = mf.ABLine.refPoint1.northing - (Math.Cos(mf.ABLine.abHeading) * 4000.0);

            mf.ABLine.refABLineP2.easting = mf.ABLine.refPoint1.easting + (Math.Sin(mf.ABLine.abHeading) * 4000.0);
            mf.ABLine.refABLineP2.northing = mf.ABLine.refPoint1.northing + (Math.Cos(mf.ABLine.abHeading) * 4000.0);

            mf.ABLine.refPoint2.easting = mf.ABLine.refABLineP2.easting;
            mf.ABLine.refPoint2.northing = mf.ABLine.refABLineP2.northing;

            mf.ABLine.BuildTram();
        }

        private void btnTriggerDistanceUp_MouseDown(object sender, MouseEventArgs e)
        {
            nudPasses.UpButton();
            mf.ABLine.BuildTram();
        }

        private void btnTriggerDistanceDn_MouseDown(object sender, MouseEventArgs e)
        {
            nudPasses.DownButton();
            mf.ABLine.BuildTram();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mf.ABLine.tramArr?.Clear();
            mf.ABLine.tramPassEvery = 0;
            mf.ABLine.tramBasedOn = 0;
            mf.ABLine.isEditing = false;
            mf.layoutPanelRight.Enabled = true;
            mf.offX = 0;
            mf.offY = 0;
            Close();
        }

        private void btnZoomOut_MouseDown(object sender, MouseEventArgs e)
        {
            if (mf.camera.zoomValue <= 20)
            { if ((mf.camera.zoomValue -= mf.camera.zoomValue * 0.1) < 6.0) mf.camera.zoomValue = 6.0; }
            else { if ((mf.camera.zoomValue -= mf.camera.zoomValue * 0.05) < 6.0) mf.camera.zoomValue = 6.0; }
            mf.camera.camSetDistance = mf.camera.zoomValue * mf.camera.zoomValue * -1;
            mf.SetZoom();
        }

        private void btnZoomIn_MouseDown(object sender, MouseEventArgs e)
        {
            if (mf.camera.zoomValue <= 20) mf.camera.zoomValue += mf.camera.zoomValue * 0.1;
            else mf.camera.zoomValue += mf.camera.zoomValue * 0.05;
            if (mf.camera.zoomValue > 220) mf.camera.zoomValue = 220;
            mf.camera.camSetDistance = mf.camera.zoomValue * mf.camera.zoomValue * -1;
           mf.SetZoom();

        }

        private void btnMoveDown_MouseDown(object sender, MouseEventArgs e)
        {
            mf.offX += (Math.Sin(mf.fixHeading) * 10);
            mf.offY += (Math.Cos(mf.fixHeading) * 10);
        }

        private void btnMoveUp_MouseDown(object sender, MouseEventArgs e)
        {
            mf.offX -= (Math.Sin(mf.fixHeading) * 10);
            mf.offY -= (Math.Cos(mf.fixHeading) * 10);
        }

        private void btnMoveLeft_MouseDown(object sender, MouseEventArgs e)
        {
            mf.offY += (Math.Sin(-mf.fixHeading) * 10);
            mf.offX += (Math.Cos(-mf.fixHeading) * 10);
        }

        private void btnMoveRight_MouseDown(object sender, MouseEventArgs e)
        {
            mf.offY -= (Math.Sin(-mf.fixHeading) * 10);
            mf.offX -= (Math.Cos(-mf.fixHeading) * 10);
        }

        private void btnResetDrag_Click(object sender, EventArgs e)
        {
            mf.offX = 0;
            mf.offY = 0;
        }

        private void cboxTramBasedOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.ABLine.tramBasedOn = cboxTramBasedOn.SelectedIndex;
            Properties.Vehicle.Default.setTram_BasedOn = mf.ABLine.tramBasedOn;
            Properties.Vehicle.Default.Save();
        }

        private void cboxTramPassEvery_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxTramPassEvery.SelectedIndex > 0)
                mf.ABLine.tramPassEvery = cboxTramPassEvery.SelectedIndex;
            else mf.ABLine.tramPassEvery = 0;
            Properties.Vehicle.Default.setTram_Skips = cboxTramPassEvery.SelectedIndex;
            Properties.Vehicle.Default.Save();
        }

        private void nudSnapAdj_ValueChanged(object sender, EventArgs e)
        {
            snapAdj = (double)nudSnapAdj.Value;
            Properties.Settings.Default.setTram_snapAdj = snapAdj;
            Properties.Settings.Default.Save();
            mf.ABLine.BuildTram();
        }

        private void nudEqWidth_ValueChanged(object sender, EventArgs e)
        {
            mf.ABLine.tramWidth  = (double)nudEqWidth.Value;
            Properties.Settings.Default.setTram_eqWidth = mf.ABLine.tramWidth;
            Properties.Settings.Default.Save();
            mf.ABLine.BuildTram();

        }

        private void nudEqWidth_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();
        }

        private void nudWheelSpacing_ValueChanged(object sender, EventArgs e)
        {
            mf.ABLine.tramWheelSpacing = (double)nudWheelSpacing.Value;
            Properties.Settings.Default.setTram_wheelSpacing = mf.ABLine.tramWheelSpacing;
            Properties.Settings.Default.Save();
            mf.ABLine.BuildTram();

        }

        private void nudWheelSpacing_Enter(object sender, EventArgs e)
        {
            mf.KeypadToNUD((NumericUpDown)sender);
            btnCancel.Focus();        
        }
        private void CalculateMinMax()
        {
            minFieldX = 9999999; minFieldY = 9999999;
            maxFieldX = -9999999; maxFieldY = -9999999;

                //min max of the boundary
                if (mf.bnd.bndArr[0].isSet)
                {
                    int bndCnt = mf.bnd.bndArr[0].bndLine.Count;
                    for (int i = 0; i < bndCnt; i++)
                    {
                        double x = mf.bnd.bndArr[0].bndLine[i].easting;
                        double y = mf.bnd.bndArr[0].bndLine[i].northing;

                        //also tally the max/min of field x and z
                        if (minFieldX > x) minFieldX = x;
                        if (maxFieldX < x) maxFieldX = x;
                        if (minFieldY > y) minFieldY = y;
                        if (maxFieldY < y) maxFieldY = y;
                    }
                }

                if (maxFieldX == -9999999 || minFieldX == 9999999 || maxFieldY == -9999999 || minFieldY == 9999999)
                {
                    maxFieldX = 0; minFieldX = 0; maxFieldY = 0; minFieldY = 0;
                }
                else
                {
                    //the largest distancew across field
                    double dist = Math.Abs(minFieldX - maxFieldX);
                    double dist2 = Math.Abs(minFieldY - maxFieldY);

                    if (dist > dist2) maxFieldDistance = dist;
                    else maxFieldDistance = dist2;

                    if (maxFieldDistance < 100) maxFieldDistance = 100;
                    if (maxFieldDistance > 19900) maxFieldDistance = 19900;
                    //lblMax.Text = ((int)maxFieldDistance).ToString();

                    fieldCenterX = (maxFieldX + minFieldX) / 2.0;
                    fieldCenterY = (maxFieldY + minFieldY) / 2.0;
                }

                //if (isMetric)
                //{
                //    lblFieldWidthEastWest.Text = Math.Abs((maxFieldX - minFieldX)).ToString("N0") + " m";
                //    lblFieldWidthNorthSouth.Text = Math.Abs((maxFieldY - minFieldY)).ToString("N0") + " m";
                //}
                //else
                //{
                //    lblFieldWidthEastWest.Text = Math.Abs((maxFieldX - minFieldX) * glm.m2ft).ToString("N0") + " ft";
                //    lblFieldWidthNorthSouth.Text = Math.Abs((maxFieldY - minFieldY) * glm.m2ft).ToString("N0") + " ft";
                //}
            
        }
    }
}