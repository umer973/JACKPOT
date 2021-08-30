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
    public partial class FrmShowWinPrize : Form
    {
        public string winprize = "";
        Timer timer1 = new Timer();
        int count = 60;
       
        public bool flag = false;
        string win = "00";
        public FrmShowWinPrize(string win, string drawtime)
        {

            InitializeComponent();

            winprize = win;
            lblWinNumber.Text = winprize;
            lblDrawtime.Text = lblDrawtime.Text = CommonHelper.SetTimeFormat(drawtime);


        }

        private void FrmShowWinPrize_Load(object sender, EventArgs e)
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
                lblWinNumber.Text = winprize;

            }


            if (count == 0)
            {

                timer1.Stop();
                this.Dispose();
                this.Hide();
            }




        }

        private string SpinNumbers()
        {
            Random rnd = new Random();

            string num = rnd.Next(0, 99).ToString();

            return num;

        }
    }
}
