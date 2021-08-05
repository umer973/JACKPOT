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
    public partial class FrmWinPrice : Form
    {
        public string ticketNo;
        public FrmWinPrice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmWinPrice_Load(object sender, EventArgs e)
        {
            ClsService clsService = new ClsService();
            clsService.GetWinTickets(ticketNo);
        }
    }
}
