using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormSource : Form
    {
        private List<string> dataList = new List<string>();

        public FormSource(List<string> _dataList)
        {
            InitializeComponent();
            dataList = _dataList;
        }

        private void FormSource_Load(object sender, EventArgs e)
        {
            ListViewItem itm;
            if (dataList.Count > 0)
            {
                for (int i = 0; i < dataList.Count; i++)
                {
                    string[] data = dataList[i].Split(',');

                    string[] fieldNames = { data[0].Trim(), data[1].Trim(), data[2].Trim() };
                    itm = new ListViewItem(fieldNames);
                    lvLines.Items.Add(itm);
                }
            }
            this.chName.Width = 350;
        }
    }
}
