using AgOpenGPS;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RateController
{
    public partial class frmSections : Form
    {
        private bool Initializing;
        private double LastValue;
        private FormStart mf;
        private byte SecCount;
        private bool UseInches;

        public frmSections(FormStart CalledFrom)
        {
            InitializeComponent();

            #region // language

            DGV.Columns[0].HeaderText = Lang.lgSection;
            DGV.Columns[1].HeaderText = Lang.lgWidth;
            DGV.Columns[2].HeaderText = Lang.lgSwitch;
            label25.Text = Lang.lgNumSections;
            lbWidth.Text = Lang.lgWidth;
            rbInches.Text = Lang.lgInches;
            btnEqual.Text = Lang.lgEqual;
            btnCancel.Text = Lang.lgCancel;
            bntOK.Text = Lang.lgClose;

            #endregion // language

            mf = CalledFrom;
            Initializing = true;
            SetDayMode();
            UseInches = mf.UseInches;
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            try
            {
                Button ButtonClicked = (Button)sender;
                if (ButtonClicked.Text == Lang.lgClose)
                {
                    this.Close();
                }
                else
                {
                    // save changes
                    SetSectionCount();
                    SaveSectionData();
                    mf.Sections.CheckSwitchDefinitions();

                    UpdateForm();
                    SetButtons(false);
                    UseInches = mf.UseInches;
                }
            }
            catch (Exception ex)
            {
                mf.Tls.TimedMessageBox(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mf.UseInches = UseInches;
            UpdateForm();
            SetButtons(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string val = DGV.Rows[0].Cells[1].EditedFormattedValue.ToString();

                for (int i = 0; i < DGV.Rows.Count; i++)
                {
                    DGV.Rows[i].Cells[1].Value = Convert.ToDouble(val);
                }
            }
            catch (Exception ex)
            {
                mf.Tls.TimedMessageBox(ex.Message);
            }
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double tempD;
                string val = DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                switch (e.ColumnIndex)
                {
                    case 1:
                        // width
                        double.TryParse(val, out tempD);
                        if (tempD == 0) tempD = LastValue;
                        using (var form = new FormNumeric(0, 10000, tempD))
                        {
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = form.ReturnValue;
                                LastValue = form.ReturnValue;
                            }
                        }
                        break;

                    case 2:
                        // switch
                        double.TryParse(val, out tempD);
                        using (var form = new FormNumeric(1, 4, tempD))
                        {
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                DGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = form.ReturnValue;
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                if (e.Value.ToString() == "0")
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
        }

        private void DGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!Initializing) SetButtons(true);
        }

        private void frmSections_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                mf.Tls.SaveFormData(this);
            }
        }

        private void frmSections_Load(object sender, EventArgs e)
        {
            mf.Tls.LoadFormData(this);

            DGV.BackgroundColor = DGV.DefaultCellStyle.BackColor;
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            UpdateForm();
        }

        private void LoadSectionData()
        {
            try
            {
                dataSet1.Clear();
                foreach (clsSection Sec in mf.Sections.Items)
                {
                    if (Sec.Enabled)
                    {
                        DataRow Rw = dataSet1.Tables[0].NewRow();
                        Rw[0] = Sec.ID + 1;

                        if (mf.UseInches)
                        {
                            Rw[1] = Sec.Width_inches;
                        }
                        else
                        {
                            Rw[1] = Sec.Width_cm;
                        }

                        Rw[2] = Sec.SwitchID + 1;

                        dataSet1.Tables[0].Rows.Add(Rw);
                    }
                }
            }
            catch (Exception ex)
            {
                mf.Tls.WriteErrorLog("FormSections/LoadSectionData: " + ex.Message);
            }
        }

        private void rbInches_CheckedChanged(object sender, EventArgs e)
        {
            mf.UseInches = rbInches.Checked;
            mf.Tls.SaveProperty("UseInches", rbInches.Checked.ToString());
            LoadSectionData();
            UpdateTotalWidth();
            lbFeet.Visible = rbInches.Checked;
        }

        private void SaveSectionData()
        {
            try
            {
                for (int i = 0; i < DGV.Rows.Count; i++)
                {
                    for (int j = 1; j < 3; j++)
                    {
                        string val = DGV.Rows[i].Cells[j].EditedFormattedValue.ToString();
                        if (val == "") val = "0";
                        switch (j)
                        {
                            case 1:
                                // width
                                if (mf.UseInches)
                                {
                                    mf.Sections.Item(i).Width_inches = (float)Convert.ToDouble(val);
                                }
                                else
                                {
                                    mf.Sections.Item(i).Width_cm = (float)Convert.ToDouble(val);
                                }
                                break;

                            case 2:
                                // switch
                                mf.Sections.Item(i).SwitchID = Convert.ToInt32(val) - 1;    // displayed as 1-4, saved as 0-3
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mf.Tls.TimedMessageBox(ex.Message);
                LoadSectionData();
            }
            mf.Sections.Save();
            UpdateTotalWidth();
        }

        private void SetButtons(bool Edited)
        {
            if (!Initializing)
            {
                if (Edited)
                {
                    btnCancel.Enabled = true;
                    this.bntOK.Text = Lang.lgSave;
                    btnEqual.Enabled = false;
                }
                else
                {
                    btnCancel.Enabled = false;
                    this.bntOK.Text = Lang.lgClose;
                    btnEqual.Enabled = true;
                }
            }
        }

        private void SetDayMode()
        {
            if (Properties.Settings.Default.IsDay)
            {
                this.BackColor = Properties.Settings.Default.DayColour;

                foreach (Control c in this.Controls)
                {
                    c.ForeColor = Color.Black;
                }
            }
            else
            {
                this.BackColor = Properties.Settings.Default.NightColour;

                foreach (Control c in this.Controls)
                {
                    c.ForeColor = Color.White;
                }
            }
        }

        private void SetSectionCount()
        {
            int tmp = 0;
            if (int.TryParse(tbSectionCount.Text, out tmp)) mf.Sections.Count = tmp;
            for (int i = tmp; i < DGV.Rows.Count; i++)
            {
                DGV.Rows[i].Cells[1].Value = 0;
            }
        }

        private void tbSectionCount_Enter(object sender, EventArgs e)
        {
            double tempD;
            double.TryParse(tbSectionCount.Text, out tempD);
            using (var form = new FormNumeric(1, 16, tempD))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tbSectionCount.Text = form.ReturnValue.ToString();
                }
            }
        }

        private void tbSectionCount_TextChanged(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void tbSectionCount_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                double tempD;
                double.TryParse(tbSectionCount.Text, out tempD);
                if (tempD < 1 || tempD > 16)
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                mf.Tls.TimedMessageBox(ex.Message);
            }
        }

        private void UpdateForm()
        {
            Initializing = true;
            LoadSectionData();
            SecCount = (byte)mf.Sections.Count;
            tbSectionCount.Text = SecCount.ToString("N0");

            if (mf.UseInches)
            {
                rbInches.Checked = true;
            }
            else
            {
                rbCM.Checked = true;
            }
            Initializing = false;
            UpdateTotalWidth();
        }

        private void UpdateTotalWidth()
        {
            if (mf.UseInches)
            {
                lbWidth.Text = Lang.lgWidth + ":  " + (mf.Sections.TotalWidth()).ToString("N0");
                lbFeet.Text = (mf.Sections.TotalWidth() / 12).ToString("N1") + "  FT";
            }
            else
            {
                lbWidth.Text = Lang.lgWidth + ":  " + mf.Sections.TotalWidth(false).ToString("N0");
            }
        }
    }
}