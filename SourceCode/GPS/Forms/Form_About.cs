using System;
using System.Globalization;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class Form_About : Form
    {
        public Form_About()
        {
            InitializeComponent();
        }

        private void linkLabelGit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void linkLabelCombineForum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void Form_About_Load(object sender, EventArgs e)
        {
            //Set language 
            Set_Language();
            lblVersion.Text = gStr.gsVersion + Application.ProductVersion.ToString(CultureInfo.InvariantCulture);

            // Add a link to the LinkLabel.
            LinkLabel.Link link = new LinkLabel.Link { LinkData = "https://github.com/farmerbriantee/AgOpenGPS" };
            linkLabelGit.Links.Add(link);

            // Add a link to the LinkLabel.
            LinkLabel.Link linkCf = new LinkLabel.Link
            {
                LinkData = "http://www.thecombineforum.com/forums/31-technology/278810-AgOpenGPS.html"
            };
            linkLabelCombineForum.Links.Add(linkCf);
        }
        //Set language 
        private void Set_Language()
        {
            label6.Text = gStr.About_AgOpenGPS1;
            label4.Text = gStr.About_AgOpenGPS2;
            label3.Text = gStr.About_AgOpenGPS3;
            label7.Text = gStr.About_AgOpenGPS4;
            label10.Text = gStr.About_AgOpenGPS5;
            label8.Text = gStr.About_AgOpenGPS6;
            label12.Text = gStr.About_AgOpenGPS7;
            label13.Text = gStr.About_AgOpenGPS8;
            label9.Text = gStr.About_AgOpenGPS9;
            label11.Text = gStr.About_AgOpenGPS10 +
    "";
            this.Text = gStr.gsAbout_AgOpenGPS;
        }
        }
}