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
    public partial class FrmAllData : Form
    {
        List<WinTicketData> Wintikcet = new List<WinTicketData>();

        public FrmAllData(List<WinTicketData> Windata)
        {
            InitializeComponent();
            Wintikcet = Windata;
        }

        private void LoadData(List<WinTicketData> tikcet)
        {

            try
            {
                dataGridView1.DataSource = null;

                // dataGridView1.DataSource = tikcet;
                for (int i = 0; i < tikcet.Count; i++)
                {
                    var index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = tikcet[i].date_slot;
                    dataGridView1.Rows[index].Cells[1].Value = tikcet[i].time_end;
                    dataGridView1.Rows[index].Cells[2].Value = tikcet[i].time_start;

                    dataGridView1.Rows[index].Cells[3].Value = tikcet[i].win_number;
                    dataGridView1.Rows[index].Cells[4].Value = "NA";
                    //dataGridView1.Rows[index].Cells[5].Value = tikcet[i].ticket_total_amount;
                    //dataGridView1.Rows[index].Cells[6].Value = tikcet[i].ticket_status;
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

        private void BtnTmlClaim_Click(object sender, EventArgs e)
        {
            LoadData(Wintikcet);
        }
    }
}
