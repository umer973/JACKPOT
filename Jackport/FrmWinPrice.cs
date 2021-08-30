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
    public partial class FrmWinPrice : Form
    {
        public string winPrize;
        int count = 60;
       
        public bool flag = false;
        string win = "00";
        public FrmWinPrice(string _winPrize, string drawtime)
        {
            InitializeComponent();
            winPrize = _winPrize;
            lblDrawtime.Text =CommonHelper.SetTimeFormat(drawtime);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmWinPrice_Load(object sender, EventArgs e)
        {

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 80; // 1 second
            timer1.Start();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count--;
            
            if (count >= 30)
            {
                win = SpinNumbers();
                lblWinNumber.Text = win;
            }
            else

            {
                lblWinNumber.Text = winPrize;
               
            }


            if (count == 0)
            {

                timer1.Stop();
               
                this.Hide();
            }




        }

        private string SpinNumbers()
        {
            Random rnd = new Random();

            string num = rnd.Next(0, 99).ToString();

            return num;

        }

        private void lbltime_Click(object sender, EventArgs e)
        {

        }
    }
}
