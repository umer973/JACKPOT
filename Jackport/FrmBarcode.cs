using Jackport.DataModel;
using Jackport.Helper;
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
        public FrmBarcode(List<PurchasedTickets> tikcet)
        {
            InitializeComponent();

            LoadData(tikcet);
        }

        private void LoadData(List<PurchasedTickets> tikcet)
        {
            // dataGridView1.DataSource = tikcet;
            try
            {
                for (int i = 0; i < tikcet.Count; i++)
                {
                    var index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = tikcet[i].slot_id;
                    dataGridView1.Rows[index].Cells[1].Value = tikcet[i].Barcode;
                    dataGridView1.Rows[index].Cells[2].Value = tikcet[i].ticket_taken_time;
                    dataGridView1.Rows[index].Cells[3].Value = "2.00";
                    dataGridView1.Rows[index].Cells[4].Value = tikcet[i].ticket_total_quantity;
                    dataGridView1.Rows[index].Cells[5].Value = tikcet[i].ticket_total_amount;
                    dataGridView1.Rows[index].Cells[6].Value = tikcet[i].ticket_status;
                    //dataGridView1.Rows[index].Cells[7].Value = "NA";
                }
            }
            catch (Exception ex)
            {

            }


        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnTmlCancel_Click(object sender, EventArgs e)
        {
            CancelTicket();
        }

        private void CancelTicket()
        {
            ClsService clsservice = new ClsService();
            var result = new CancelledTicket();

            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                string barccode = row.Cells[1].Value.ToString().Trim();
                result = clsservice.CancelTicket(UserAgent.AgenToken, barccode);
                if (result != null)
                {
                    this.Hide();
                    MessageBox.Show("Ticket Cancelled Successfully");
                    PrintJobHelper.PrintCancelledTicket(result);
                    UserAgent.ShowBalance = result.agent_balance;




                }


            }
            else
            {
                MessageBox.Show("Please Select Barcode");
            }

        }

        private void BtnTmlClaim_Click(object sender, EventArgs e)
        {
            ClaimTicket();
        }

        private void ClaimTicket()
        {
            ClsService clsservice = new ClsService();
            TicketDetail ticket = new TicketDetail();

            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                string barccode = row.Cells[1].Value.ToString().Trim();
                ticket = clsservice.ClaimTicket(UserAgent.AgenToken, barccode);
                if (ticket != null)
                {
                    this.Hide();
                    MessageBox.Show("Ticket Claim Successfully");
                    PrintJobHelper.PrintClaimedTicket(ticket);


                }


            }
            else
            {
                MessageBox.Show("Please Select Barcode");
            }

        }

        private void BtnReprint_Click(object sender, EventArgs e)
        {
            Reprint();
        }

        private void Reprint()
        {
            ClsService clsservice = new ClsService();
            BidDetail bids = new BidDetail();
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                string barccode = row.Cells[1].Value.ToString().Trim();
                bids = clsservice.GetSingleTickeDetail(barccode);
                if (bids != null)
                {
                    this.Hide();

                    PrintJobHelper.ReprintPrint(bids);
                }


            }
            else
            {
                MessageBox.Show("Please Select Barcode");
            }
        }
    }
}
