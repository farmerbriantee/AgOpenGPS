//Please, if you use this, share the improvements

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormABLine : Form
    {
        //access to the main GPS form and all its variables
        private FormGPS mainForm = null;

        private double upDnHeading = 0;

        public FormABLine(Form callingForm)
        {
            //get copy of the calling main form
            mainForm = callingForm as FormGPS;

            InitializeComponent();
        }

        private void FormABLine_Load(object sender, EventArgs e)
        {
            //different start based on AB line already set or not
            if (mainForm.ABLine.isABLineSet)
            {
                //AB line is on screen and set
                btnAPoint.Enabled = false;
                btnBPoint.Enabled = true;
                btnABLineOk.Enabled = true;
                btnDeleteAB.Enabled = true;
                btnUpABHeading.Enabled = true;
                btnDnABHeading.Enabled = true;
                btnUpABHeadingBy1.Enabled = true;
                btnDnABHeadingBy1.Enabled = true;
                upDnHeading = Math.Round((glm.degrees(mainForm.ABLine.abHeading)), 1);
            }

            else
            {
                //no AB line
                btnAPoint.Enabled = true;
                btnBPoint.Enabled = false;
                btnDeleteAB.Enabled = true;
                btnABLineOk.Enabled = false;
                btnUpABHeading.Enabled = false;
                btnDnABHeading.Enabled = false;
                btnUpABHeadingBy1.Enabled = false;
                btnDnABHeadingBy1.Enabled = false;
                upDnHeading = Math.Round((glm.degrees(mainForm.fixHeading)), 1);
            }
        }

        private void btnAPoint_Click(object sender, EventArgs e)
        {
            mainForm.ABLine.refPoint1.x = mainForm.prevEasting[0];
            mainForm.ABLine.refPoint1.y = 0.0;
            mainForm.ABLine.refPoint1.z = mainForm.prevNorthing[0];
            Console.WriteLine(mainForm.ABLine.refPoint1.x);
            Console.WriteLine(mainForm.ABLine.refPoint1.z);
            btnAPoint.Enabled = false;
            btnBPoint.Enabled = true;
            btnUpABHeading.Enabled = true;
            btnDnABHeading.Enabled = true;
            btnUpABHeadingBy1.Enabled = true;
            btnDnABHeadingBy1.Enabled = true;
            upDnHeading = Math.Round(glm.degrees(mainForm.fixHeading), 1);
        }

       private void btnBPoint_Click(object sender, EventArgs e)
        {
            mainForm.ABLine.SetABLineByBPoint();
            btnABLineOk.Enabled = true;
            btnDeleteAB.Enabled = true;
            upDnHeading = Math.Round(glm.degrees(mainForm.fixHeading), 1);
        }

        private void btnUpABHeading_Click(object sender, EventArgs e)
        {
            if ((upDnHeading += 0.1) > 359.9) upDnHeading = 0;
            mainForm.ABLine.abHeading = glm.radians(upDnHeading);
            mainForm.ABLine.SetABLineByHeading();
            btnABLineOk.Enabled = true;
        }

        private void btnDownABHeading_Click(object sender, EventArgs e)
        {
            if ((upDnHeading -= 0.1) < 0) upDnHeading = 359.9;
            mainForm.ABLine.abHeading = glm.radians(upDnHeading);
            mainForm.ABLine.SetABLineByHeading();
            btnABLineOk.Enabled = true;
        }

        private void btnUpABHeadingBy1_Click(object sender, EventArgs e)
        {
            if ((upDnHeading += 1) > 359.9) upDnHeading -= 360;
            mainForm.ABLine.abHeading = glm.radians(upDnHeading);
            mainForm.ABLine.SetABLineByHeading();
            btnABLineOk.Enabled = true;

        }

        private void btnDnABHeadingBy1_Click(object sender, EventArgs e)
        {
            if ((upDnHeading -= 1) < 0 ) upDnHeading += 360.0;
            mainForm.ABLine.abHeading = glm.radians(upDnHeading);
            mainForm.ABLine.SetABLineByHeading();
            btnABLineOk.Enabled = true;
        }

 
 
        private void btnABLineOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDeleteAB_Click(object sender, EventArgs e)
        {
            mainForm.ABLine.DeleteAB();
            btnAPoint.Enabled = true;
            btnBPoint.Enabled = false;
            btnDeleteAB.Enabled = false;
            btnABLineOk.Enabled = false;
  
            this.DialogResult = DialogResult.Cancel;
            this.Close();
         }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblFixHeading.Text = Convert.ToString( Math.Round(glm.degrees(mainForm.fixHeading), 1)) + "°";
            this.lblABHeading.Text = Convert.ToString(upDnHeading) + "°";

        }

 

 
 
 
 
 
     }
}
