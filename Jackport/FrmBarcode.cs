using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jackport
{
    public partial class FrmBarcode : Form
    {
        public FrmBarcode(object data)
        {
            InitializeComponent();

            LoadData(data);
        }

        private void LoadData(object data)
        {
            dataGridView1.DataSource = data;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
