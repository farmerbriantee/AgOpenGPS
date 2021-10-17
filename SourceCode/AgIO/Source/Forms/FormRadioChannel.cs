using AgIO.Classes;
using System;
using System.Windows.Forms;

namespace AgIO.Forms
{
    public partial class FormRadioChannel : Form
    {
        private readonly FormLoop mf;

        public CRadioChannel Channel { get; set; } = new CRadioChannel();

        public FormRadioChannel(FormLoop mainForm)
        {
            mf = mainForm;
            InitializeComponent();
        }

        private void FormRadioChannel_Load(object sender, EventArgs e)
        {
            tbId.Text = Channel.Id.ToString();
            tbName.Text = Channel.Name;
            tbFrequency.Text = Channel.Frequency;
            tbLocation.Text = Channel.Location;
        }

        private void btnSerialOK_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(tbId.Text, out int channelId))
            {
                mf.TimedMessageBox(2000, "Invalid Id", $"Id '{tbId.Text}' is not a valid number");
                DialogResult = DialogResult.None;
                return;
            }

            if (string.IsNullOrEmpty(tbName.Text))
            {
                mf.TimedMessageBox(2000, "Invalid Name", $"Name is not filled in");
                DialogResult = DialogResult.None;
                return;
            }

            if (string.IsNullOrEmpty(tbFrequency.Text))
            {
                mf.TimedMessageBox(2000, "Invalid Frequency", $"Frequency is not filled in");
                DialogResult = DialogResult.None;
                return;
            }

            Channel.Id = channelId;
            Channel.Name = tbName.Text;
            Channel.Frequency = tbFrequency.Text;
            Channel.Location = tbLocation.Text;
        }

        private void tbox_Click(object sender, EventArgs e)
        {
            if (mf.isKeyboardOn)
            {
                mf.KeyboardToText((TextBox)sender, this);
            }
        }
    }
}
