﻿using Jackport.DataModel;
using Jackport.Helper;
using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace Jackport
{
    public partial class FrmAllData : Form
    {
        List<WinTicketData> tikcet = new List<WinTicketData>();

        public FrmAllData()
        {
            InitializeComponent();
          
        }

        private void LoadData()
        {
           
            DateTime dtf = dtfrom.Value;
            DateTime dtt = dtTo.Value;
            try
            {
                ClsService service = new ClsService();

                tikcet = service.GetWinData(dtf.ToString("yyyy-MM-dd"), dtt.ToString("yyyy-MM-dd"));
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                // dataGridView1.DataSource = tikcet;
                for (int i = 0; i < tikcet.Count; i++)
                {
                    var index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = tikcet[i].date_slot;
                    dataGridView1.Rows[index].Cells[1].Value =CommonHelper.GetdateFormat(tikcet[i].time_start);
                    dataGridView1.Rows[index].Cells[2].Value = CommonHelper.GetdateFormat(tikcet[i].time_end);

                    dataGridView1.Rows[index].Cells[3].Value = tikcet[i].win_number;
                   // dataGridView1.Rows[index].Cells[4].Value = "NA";
                    //dataGridView1.Rows[index].Cells[5].Value = tikcet[i].ticket_total_amount;
                    //dataGridView1.Rows[index].Cells[6].Value = tikcet[i].ticket_status;
                    //dataGridView1.Rows[index].Cells[7].Value = "NA";
                }
            }
            catch 
            {

            }


        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnTmlClaim_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnTmlClaim_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
