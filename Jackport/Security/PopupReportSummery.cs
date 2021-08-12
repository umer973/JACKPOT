using CrystalDecisions.CrystalReports.Engine;
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

namespace Jackport.Security
{
    public partial class PopupReportSummery : Form
    {
        public PopupReportSummery(ReportSummary report, DateTime dt1, DateTime dt2)
        {
            InitializeComponent();
            Print(report, dt1, dt2);
        }
        private void Print(ReportSummary report, DateTime dt1, DateTime dt2)
        {
            //List<TimeSlotList> list = new List<TimeSlotList>();
            //throw new NotImplementedException();
            ReportDocument cRep = new ReportDocument();

            cRep.Load(Application.StartupPath + "/Report/DsReportSummery/CryReportSummery.rpt");
            //cRep.Load("E:/Live Project/JackPot-master/Jackport/Jackport/Report/DsReportSummery/CryReportSummery.rpt");
            // CRPT.Wholesale.Challan.DsChallan.DsChallan ObjDsPo = new CRPT.Wholesale.Challan.DsChallan.DsChallan();
            Report.DsPurchase.DsPurchase ObjDsPo = new Report.DsPurchase.DsPurchase();
            DataTable dt = new DataTable();


            // report = clsService.GetReportSummary(dt1.ToString("yyyy-MM-dd"), (dt2.ToString("yyyy-MM-dd")));


            string AgentCode = UserAgent.AgentCode;
            string Date = DateTime.Now.ToString();
            string gross_sales_amount = report.gross_sales_amount;
            string grosssales_amount = report.gross_sales_amount;
            string payout_amount = report.payout_amount;
            string net_to_pay = report.net_to_pay;
            string cancelled_sales_amount = report.cancelled_sales_amount;
            string total_profit = report.total_profit;
            string retailer_discount = report.retailer_discount;
            string operator_balance = report.operator_balance;
            string sale_incentive = report.sale_incentive;
            string saleincentive = report.sale_incentive;
           string PayoutIncentive = report.PayoutIncentive;
            string fromdate = dt1.ToString();
            string todat = dt2.ToString();
            List<ReportSummary> list1 = new List<ReportSummary>();

            dt.Columns.Add("AgentCode");
            dt.Columns.Add("Date");
            dt.Columns.Add("gross_sales_amount");
            dt.Columns.Add("grosssales_amount");
            dt.Columns.Add("payout_amount");
            dt.Columns.Add("net_to_pay");
            dt.Columns.Add("cancelled_sales_amount");
            dt.Columns.Add("total_profit");
            dt.Columns.Add("retailer_discount");
            dt.Columns.Add("operator_balance");
            dt.Columns.Add("sale_incentive");
           
            dt.Columns.Add("fromdate");
            dt.Columns.Add("todat");
            dt.Columns.Add("PayoutIncentive");

            dt.Rows.Add(AgentCode, Date, gross_sales_amount, grosssales_amount, payout_amount,
                net_to_pay, cancelled_sales_amount, total_profit, retailer_discount,
                operator_balance, sale_incentive, fromdate, todat, PayoutIncentive);

            ObjDsPo.Tables.Add(dt);
            DataSet ds = ObjDsPo;
            cRep.SetDataSource(ds.Tables[1]);
            crystalReportViewer1.ReportSource = cRep;

        }
    }
}
