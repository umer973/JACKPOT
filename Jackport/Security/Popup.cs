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
    public partial class Popup : Form
    {
        public Popup(List<TimeSlotList> slots)
        {
            InitializeComponent();
            Print(slots);
        }

        private void Print(List<TimeSlotList> list)
        {
            //List<TimeSlotList> list = new List<TimeSlotList>();
            //throw new NotImplementedException();
            ReportDocument cRep = new ReportDocument();

            cRep.Load(Application.StartupPath + "/Report/DsPurchase/CryPurchaseTicket.rpt");
            //cRep.Load("E:/Live Project/JackPot-master/Jackport/Jackport/Report/DsPurchase/CryPurchaseTicket.rpt");
            // CRPT.Wholesale.Challan.DsChallan.DsChallan ObjDsPo = new CRPT.Wholesale.Challan.DsChallan.DsChallan();
            Report.DsPurchase.DsPurchase ObjDsPo = new Report.DsPurchase.DsPurchase();
            DataTable dt = new DataTable();

            dt.Columns.Add("date_slot");
            dt.Columns.Add("time_start");
            dt.Columns.Add("time_end");
            dt.Columns.Add("win_number");
            dt.Columns.Add("agent_code");
            dt.Columns.Add("ticket_barcode");
            dt.Columns.Add("total_amount");
            dt.Columns.Add("total_quantity");
            dt.Columns.Add("purchase_time");
            foreach (var item in list)
            {
                dt.Rows.Add(item.date_slot, item.time_start, item.time_end, item.slot_id, item.agent_code,
                    item.ticket_barcode, item.total_amount, item.total_quantity, item.purchase_time);
            }
            ObjDsPo.Tables.Add(dt);
            DataSet ds = ObjDsPo;
            cRep.SetDataSource(ds.Tables[1]);
            crystalReportViewer1.ReportSource = cRep;
            //try
            //{
            //    Popup objpop;
            //    PnlPrintInvoice.Visible = true;
            //    objpop = new Popup("Purchase Ticket");
            //    objpop.StartPosition = FormStartPosition.CenterScreen;
            //    objpop.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //    objpop.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }
    }
}
