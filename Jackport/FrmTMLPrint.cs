using Jackport.DataModel;
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
    public partial class FrmTMLPrint : Form
    {
        public FrmTMLPrint(ReportSummary result)
        {
            InitializeComponent();
            loaddata(result);
        }

        private void loaddata(ReportSummary result)
        {
            dataGridView1.DataSource = result;
            
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
