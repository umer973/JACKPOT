using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jackport
{
    public partial class BidControl : UserControl
    {
        FrmJackportDemo frm;
        public BidControl(FrmJackportDemo _frm)
        {
            InitializeComponent();
            frm = _frm;
        }


        public string TickeName
        {
            get { return label1.Text; }
            set { label1.Text = value; }


        }
        public string TickeQty
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            GetValues();
            GetTotalCount();
        }

        private void GetValues()
        {
            string val = "";
            foreach (BidControl ctr in frm.tblbidsControl.Controls)
            {

            }

            foreach (UserInputControl ctr in frm.tblBids.Controls)
            {
                string num = Convert.ToString(ctr.Tag);
                if (num == "00")
                    ctr.TickeQty = textBox1.Text;
                if (num == "10")
                    ctr.TickeQty = textBox1.Text;
                if (num == "20")
                    ctr.TickeQty = textBox1.Text;
                if (num == "30")
                    ctr.TickeQty = textBox1.Text;
                if (num == "40")
                    ctr.TickeQty = textBox1.Text;
                if (num == "50")
                    ctr.TickeQty = textBox1.Text;
                if (num == "60")
                    ctr.TickeQty = textBox1.Text;
                if (num == "70")
                    ctr.TickeQty = textBox1.Text;
                if (num == "80")
                    ctr.TickeQty = textBox1.Text;
                if (num == "90")
                    ctr.TickeQty = textBox1.Text;
            }
        }

        private void GetTotalCount()
        {

            try
            {
                int quantity = 0;
                int total = 0;
                foreach (UserInputControl ctr in frm.tblBids.Controls)
                {

                    if (!string.IsNullOrEmpty(ctr.TickeQty) && Convert.ToInt32(ctr.TickeQty) > 0)
                    {

                        quantity = quantity + Convert.ToInt16(ctr.TickeQty);

                    }
                }

                total = 2 * quantity;
                frm.txttickektsqty.Text = quantity.ToString();
                frm.txttotalvalue.Text = total.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
