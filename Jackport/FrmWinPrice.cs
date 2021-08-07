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
        public string winPrize;
        int count = 5;
        public FrmWinPrice(string _winPrize)
        {
            InitializeComponent();
            winPrize = _winPrize;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmWinPrice_Load(object sender, EventArgs e)
        {

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
            lblWinNumber.Text = winPrize;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count--;
            if (count == 0)
                this.Hide();
        }
    }
}
