using CrystalDecisions.CrystalReports.Engine;
using Jackport.DataModel;
using Jackport.Security;
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
            try
            {
                ReportSummary report = new ReportSummary();

                DateTime dt1 = dtfrom.Value;
                DateTime dt2 = dtTo.Value;
                report = clsService.GetReportSummary(dt1.ToString("yyyy-MM-dd"), (dt2.ToString("yyyy-MM-dd")));
                
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
                // Print(ds);
                //Print();
            }
            catch { }



        }


       


        private void Print()
        {

            
                try
                {
                    ReportSummary report = new ReportSummary();

                    DateTime dt1 = dtfrom.Value;
                    DateTime dt2 = dtTo.Value;
                    report = clsService.GetReportSummary(dt1.ToString("yyyy-MM-dd"), (dt2.ToString("yyyy-MM-dd")));
                    PopupReportSummery ObjPopup = new PopupReportSummery(report, dt1, dt2);
                    ObjPopup.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            
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

        private void BtnReprint_Click(object sender, EventArgs e)
        {
            Print();
        }
    }
}
