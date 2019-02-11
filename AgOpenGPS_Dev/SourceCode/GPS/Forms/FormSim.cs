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
    public partial class FormSim : Form
    {
        private readonly FormGPS mf = null;

        //Form stuff
        public FormSim(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }
    }
}
