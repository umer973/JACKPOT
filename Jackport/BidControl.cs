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


            string tag = label1.Text;


            foreach (UserInputControl ctr in frm.tblBids.Controls)
            {
                string num = Convert.ToString(ctr.Tag);

                if (tag == "E0")
                {
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

                if (tag == "E1")
                {
                    if (num == "01")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "11")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "21")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "31")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "41")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "51")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "61")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "71")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "81")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "91")
                        ctr.TickeQty = textBox1.Text;
                }

                if (tag == "E2")
                {
                    if (num == "02")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "12")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "22")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "32")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "42")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "52")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "62")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "72")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "82")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "92")
                        ctr.TickeQty = textBox1.Text;
                }
                if (tag == "E3")
                {
                    if (num == "03")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "13")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "23")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "33")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "43")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "53")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "63")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "73")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "83")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "93")
                        ctr.TickeQty = textBox1.Text;
                }
                if (tag == "E4")
                {
                    if (num == "04")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "14")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "24")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "34")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "44")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "54")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "64")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "74")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "84")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "94")
                        ctr.TickeQty = textBox1.Text;
                }
                if (tag == "E5")
                {
                    if (num == "05")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "15")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "25")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "35")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "45")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "55")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "65")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "75")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "85")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "95")
                        ctr.TickeQty = textBox1.Text;
                }
                if (tag == "E6")
                {
                    if (num == "06")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "16")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "26")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "36")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "46")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "56")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "66")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "76")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "86")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "96")
                        ctr.TickeQty = textBox1.Text;
                }
                if (tag == "E7")
                {
                    if (num == "07")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "17")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "27")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "37")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "47")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "57")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "67")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "77")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "87")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "97")
                        ctr.TickeQty = textBox1.Text;
                }
                if (tag == "E8")
                {
                    if (num == "08")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "18")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "28")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "38")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "48")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "58")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "68")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "78")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "88")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "98")
                        ctr.TickeQty = textBox1.Text;
                }
                if (tag == "E9")
                {
                    if (num == "09")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "19")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "29")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "39")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "49")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "59")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "69")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "79")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "89")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "99")
                        ctr.TickeQty = textBox1.Text;
                }

                if (tag == "0-9")
                {
                    if (num == "00")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "01")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "02")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "03")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "04")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "05")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "06")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "07")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "08")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "09")
                        ctr.TickeQty = textBox1.Text;
                }
                if (tag == "10-19")
                {
                    if (num == "10")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "11")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "12")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "13")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "14")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "15")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "16")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "17")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "18")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "19")
                        ctr.TickeQty = textBox1.Text;
                }
                if (tag == "20-29")
                {
                    if (num == "20")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "21")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "22")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "23")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "24")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "25")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "26")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "27")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "28")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "29")
                        ctr.TickeQty = textBox1.Text;
                }

                if (tag == "30-39")
                {
                    if (num == "30")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "31")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "32")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "33")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "34")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "35")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "36")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "37")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "38")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "39")
                        ctr.TickeQty = textBox1.Text;
                }
                if (tag == "40-49")
                {
                    if (num == "40")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "41")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "42")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "43")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "44")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "45")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "46")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "47")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "48")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "49")
                        ctr.TickeQty = textBox1.Text;
                }
                if (tag == "50-59")
                {
                    if (num == "50")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "51")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "52")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "53")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "54")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "55")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "56")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "57")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "58")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "59")
                        ctr.TickeQty = textBox1.Text;
                }
                if (tag == "60-69")
                {
                    if (num == "60")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "61")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "62")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "63")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "64")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "65")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "66")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "67")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "68")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "69")
                        ctr.TickeQty = textBox1.Text;
                }
                if (tag == "70-79")
                {
                    if (num == "70")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "71")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "72")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "73")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "74")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "75")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "76")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "77")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "78")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "79")
                        ctr.TickeQty = textBox1.Text;
                }
                if (tag == "80-89")
                {
                    if (num == "80")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "81")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "82")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "83")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "84")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "85")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "86")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "87")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "88")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "89")
                        ctr.TickeQty = textBox1.Text;
                }
                if (tag == "90-99")
                {
                    if (num == "90")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "91")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "92")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "93")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "94")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "95")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "96")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "97")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "98")
                        ctr.TickeQty = textBox1.Text;
                    if (num == "99")
                        ctr.TickeQty = textBox1.Text;
                }
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
