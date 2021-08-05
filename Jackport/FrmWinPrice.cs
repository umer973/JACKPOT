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
        public string  winPrize;
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
           
            lblWinNumber.Text = winPrize;
        }
    }
}
