using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormBoundary : Form
    {
        private readonly FormGPS mf = null;

        private bool Selectedreset = true;
        private int position = 0;

        public FormBoundary(Form callingForm)
        {
            mf = callingForm as FormGPS;

            //winform initialization
            InitializeComponent();

            this.Text = gStr.gsStartDeleteABoundary;

            //Column Header
            Boundary.Text = gStr.gsBounds;
            Thru.Text = gStr.gsDriveThru;
            Area.Text = gStr.gsArea;
            Around.Text = gStr.gsAround;

            //Bouton
            //btnDelete.Text = gStr.gsDelete;
            //btnSerialCancel.Text = gStr.gsSaveAndReturn;
            //btnDeleteAll.Text = gStr.gsDeleteAll;
            btnGo.Text = gStr.gsGo;
        }

        private void UpdateChart()
        {
            int field = 1;
            int inner = 1;

            for (int i = 0; i < mf.bnd.bndArr.Count + 1 && i < position + 9; i++)
            {
                if (i < position && i < mf.bnd.bndArr.Count)
                {
                    if (i==0)
                    {
                        field += 1;
                    }
                    else
                    {
                        inner += 1;
                    }
                }
                else
                {
                    Control aa = tableLayoutPanel1.GetControlFromPosition(0, i - position);
                    if (aa == null)
                    {
                        var a = new Button
                        {
                            Margin = new Padding(0),
                            Size = new Size(280, 40),
                            Name = string.Format("{0}", i - position),
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        a.Click += B_Click;
                        a.FlatStyle = FlatStyle.Flat;
                        a.FlatAppearance.BorderColor = BackColor;
                        a.FlatAppearance.MouseOverBackColor = BackColor;
                        a.FlatAppearance.MouseDownBackColor = BackColor;

                        aa = a;

                        var d = new Button
                        {
                            Margin = new Padding(0),
                            Size = new System.Drawing.Size(80, 40),
                            Name = string.Format("{0}", i - position),
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        d.Click += DriveThru_Click;

                        var e = new Button
                        {
                            Margin = new Padding(0),
                            Size = new System.Drawing.Size(80, 40),
                            Name = string.Format("{0}", i - position),
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        e.Click += DriveAround_Click;
                        tableLayoutPanel1.Controls.Add(a, 0, i - position);
                        tableLayoutPanel1.Controls.Add(d, 3-1, i - position);
                        tableLayoutPanel1.Controls.Add(e, 4-1, i - position);
                    }

                    if (i < mf.bnd.bndArr.Count && mf.bnd.bndArr[i].isSet)
                    {
                        tableLayoutPanel1.SetColumnSpan(aa, 1);

                        Control bb = tableLayoutPanel1.GetControlFromPosition(1, i - position);
                        if (bb == null)
                        {
                            var b = new Button
                            {
                                Margin = new Padding(0),
                                Size = new System.Drawing.Size(150, 40),
                                Name = string.Format("{0}", i - position),
                                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                            };
                            b.Click += B_Click;
                            b.FlatStyle = FlatStyle.Flat;
                            b.FlatAppearance.BorderColor = BackColor;
                            b.FlatAppearance.MouseOverBackColor = BackColor;
                            b.FlatAppearance.MouseDownBackColor = BackColor;
                            tableLayoutPanel1.Controls.Add(b, 1, i - position);
                            bb = b;
                        }
                        Control dd = tableLayoutPanel1.GetControlFromPosition(3-1, i - position);
                        dd.Visible = true;
                        Control ee = tableLayoutPanel1.GetControlFromPosition(4-1, i - position);
                        ee.Visible = true;

                        Font backupfont = new Font(aa.Font.FontFamily, 18F, FontStyle.Bold);

                        if (i == 0)
                        {
                            //cc.Text = "Field";
                            aa.Text = string.Format(gStr.gsOuter );
                            field += 1;
                            aa.Font = backupfont;
                            dd.Enabled = false;
                            ee.Enabled = false;
                            mf.bnd.bndArr[i].isDriveThru = false;
                            mf.bnd.bndArr[i].isDriveAround = false;
                            dd.Text = mf.bnd.bndArr[i].isDriveThru ? "--" : "--";
                            dd.Anchor = System.Windows.Forms.AnchorStyles.None;
                            ee.Text = mf.bnd.bndArr[i].isDriveAround ? "--" : "--";
                            ee.Anchor = System.Windows.Forms.AnchorStyles.None;
                            dd.BackColor = Color.Azure;
                            ee.BackColor = Color.Azure;

                        }
                        else
                        {
                            //cc.Text = "Inner";
                            aa.Text = string.Format(gStr.gsInner + " {0}", inner);
                            aa.Font = backupfont;
                            inner += 1;
                            dd.Enabled = true;
                            ee.Enabled = true;
                            dd.Text = mf.bnd.bndArr[i].isDriveThru ? "Yes" : "No";
                            dd.Anchor = System.Windows.Forms.AnchorStyles.None;
                            ee.Text = mf.bnd.bndArr[i].isDriveAround ? "Yes" : "No";
                            ee.Anchor = System.Windows.Forms.AnchorStyles.None;

                        }

                        if (mf.isMetric)
                        {
                            bb.Text = Math.Round(mf.bnd.bndArr[i].area * 0.0001, 2) + " Ha";
                        }
                        else
                        {
                            bb.Text = Math.Round(mf.bnd.bndArr[i].area * 0.000247105, 2) + " Ac";
                        }

                        if (Selectedreset == false && i == mf.bnd.boundarySelected)
                        {
                            aa.ForeColor = Color.Red;
                            bb.ForeColor = Color.Red;
                        }
                        else
                        {
                            aa.ForeColor = default;
                            bb.ForeColor = default;
                        }
                    }
                    else
                    {
                        Control bb = tableLayoutPanel1.GetControlFromPosition(1, i - position);
                        if (!(bb == null || bb == aa))
                        {
                            bb.Dispose();
                        }

                        tableLayoutPanel1.SetColumnSpan(aa, 2);
                        aa.Text = string.Format(gStr.gsCreateNewBoundary, i - position + 1);

                        aa.BackColor = Color.Bisque;
                        aa.Anchor = System.Windows.Forms.AnchorStyles.None;

                        Control dd = tableLayoutPanel1.GetControlFromPosition(3-1, i - position);
                        dd.Visible = false;
                        Control ee = tableLayoutPanel1.GetControlFromPosition(4-1, i - position);
                        ee.Visible = false;

                        //delete rest of buttons
                        while (true)
                        {
                            Control ff = tableLayoutPanel1.GetNextControl(ee, true);
                            if (ff == null)
                            {
                                break;
                            }
                            else
                            {
                                ff.Dispose();
                            }

                        }

                        if (Selectedreset == false && i == mf.bnd.boundarySelected)
                        {
                            aa.ForeColor = Color.DarkBlue;
                        }
                        else
                        {
                            aa.ForeColor = default;
                        }
                        break;
                    }
                }
            }
        }

        private void FormBoundary_Load(object sender, EventArgs e)
        {
            btnLeftRight.Image = mf.bnd.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
            btnLeftRight.Enabled = false;
            btnGo.Enabled = false;
            btnDelete.Enabled = false;

            //update the list view with real data
            UpdateChart();
        }

        void DriveThru_Click(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                mf.bnd.bndArr[Convert.ToInt32(b.Name) + position].isDriveThru = !mf.bnd.bndArr[Convert.ToInt32(b.Name) + position].isDriveThru;
                UpdateChart();
            }
        }

        void DriveAround_Click(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                mf.bnd.bndArr[Convert.ToInt32(b.Name) + position].isDriveAround = !mf.bnd.bndArr[Convert.ToInt32(b.Name) + position].isDriveAround;
                UpdateChart();
            }
        }

        void B_Click(object sender, EventArgs e)
        {
            if (sender is Button b)
            {

                mf.bnd.boundarySelected = Convert.ToInt32(b.Name) + position;

                Selectedreset = false;

                if (mf.bnd.bndArr.Count > mf.bnd.boundarySelected && mf.bnd.bndArr[mf.bnd.boundarySelected].isSet)
                {
                    btnGo.Enabled = false;
                    btnDelete.Enabled = true;
                    btnLeftRight.Enabled = false;
                }
                else
                {
                    btnGo.Enabled = true;
                    btnDelete.Enabled = false;
                    btnLeftRight.Enabled = true;
                    btnDeleteAll.Enabled = false;
                }
            }
            UpdateChart();
        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            mf.bnd.isOkToAddPoints = false;
            mf.turn.BuildTurnLines();
            mf.gf.BuildGeoFenceLines();
            mf.mazeGrid.BuildMazeGridArray();
        }

        private void btnLeftRight_Click(object sender, EventArgs e)
        {
            mf.bnd.isDrawRightSide = !mf.bnd.isDrawRightSide;
            btnLeftRight.Image = mf.bnd.isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnLeftRight.Enabled = false;
            btnGo.Enabled = false;
            btnDelete.Enabled = false;

            if (mf.bnd.bndArr.Count > mf.bnd.boundarySelected)
            {
                mf.bnd.bndArr.RemoveAt(mf.bnd.boundarySelected);
                mf.turn.turnArr.RemoveAt(mf.bnd.boundarySelected);
                mf.gf.geoFenceArr.RemoveAt(mf.bnd.boundarySelected);
            }

            mf.FileSaveBoundary();
            mf.bnd.boundarySelected = -1;
            Selectedreset = true;
            UpdateChart();
        }

        private void ResetAllBoundary()
        {
            position = 0;

            mf.bnd.bndArr.Clear();
            mf.turn.turnArr.Clear();
            mf.gf.geoFenceArr.Clear();

            mf.FileSaveBoundary();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            UpdateChart();

            btnLeftRight.Enabled = false;
            btnGo.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            ResetAllBoundary();

            mf.bnd.boundarySelected = -1;
            Selectedreset = true;

            mf.bnd.isOkToAddPoints = false;
            mf.turn.BuildTurnLines();
            mf.gf.BuildGeoFenceLines();
            mf.mazeGrid.BuildMazeGridArray();
        }
    }
}
