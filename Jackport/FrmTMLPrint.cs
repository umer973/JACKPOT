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
            panel1.Visible = false;

        }

        private void LoadReport()
        {
            ReportSummary report = new ReportSummary();
            report = clsService.GetReportSummary(dtfrom.Value, dtTo.Value);

            lblAgentID.Text = UserAgent.AgentCode;
            lblDate.Text = DateTime.Now.ToString();
            lblGrosssaleAmt.Text = report.gross_sales_amount;
            lblnetsalesamt.Text = report.gross_sales_amount;
            payoutamt.Text = report.payout_amount;
            netpay.Text = report.net_to_pay;
            lblcancelledamt.Text = report.cancelled_sales_amount;
            profitamt.Text = report.total_profit;
            retailerdis.Text = report.retailer_discount;
            operatorbal.Text = report.operator_balance;
            salesincentive.Text = report.sale_incentive;
            payoutincentive.Text = report.PayoutIncentive;
            lblfrom.Text = dtfrom.Text;
            lblto.Text = dtTo.Text;
            panel1.Visible = true;



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
