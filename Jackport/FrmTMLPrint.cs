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
        ClsService clsService = new ClsService();
        public FrmTMLPrint()
        {
            InitializeComponent();
           
        }

        private void LoadReport()
        {
            ReportSummary report = new ReportSummary();
            report = clsService.GetReportSummary(DateTime.Now, DateTime.Now);

            lblAgentID.Text = UserAgent.AgentCode;
            lblDate.Text = DateTime.Now.ToString();
            lblGrosssaleAmt.Text = report.gross_sales_amount;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnTmlClaim_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
