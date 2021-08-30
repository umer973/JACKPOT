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
    public partial class UserInputControl : UserControl
    {
        FrmJackportDemo _frm;
        Control ctr;

        public UserInputControl(FrmJackportDemo frm)
        {
            InitializeComponent();

            ParentChanged += OnChanged;
            _frm = frm;
            // this.Size = new Size(150, 150);
        }

        private void OnChanged(object sender, EventArgs e)
        {

            // More events or
            // Do Something...
        }


        public string TickeName
        {
            get { return LabelName.Text; }
            set { LabelName.Text = value; }


        }
        public string TickeQty
        {
            get { return TxtQty.Text; }
            set { TxtQty.Text = value; }


        }

        public Size TicketSize
        {
            get { return TxtQty.Size; }
            set { TxtQty.Size = value; }


        }

        public int Tab
        {
            get { return TxtQty.TabIndex; }
            set { TxtQty.TabIndex = value; }


        }

        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtQty.Text.Contains(".") || TxtQty.Text == "0")
            {
                TxtQty.Text = "";
                return;
            }

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

        private void TxtQty_TextChanged(object sender, EventArgs e)
        {
            if (TxtQty.Text != "" && TxtQty.Text != "\r\n")
                TxtQty.BackColor = Color.Green;
            else
            {
                TxtQty.BackColor = Color.White;
                TxtQty.Text = "";
            }
        }

        private void TxtQty_KeyUp(object sender, KeyEventArgs e)
        {

            if (TxtQty.Text.Contains(".") || TxtQty.Text == "0")
            {
                TxtQty.Text = "";
                return;
            }

            if (TxtQty.Text != "" && TxtQty.Text != "\r\n")
                TxtQty.BackColor = Color.Green;
            else
                TxtQty.BackColor = Color.White;

            int tab = Convert.ToInt16(LabelName.Text) + 1;
            int[] up = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //int[] left  = { 1, 11, 21, 31, 41, 51, 61, 71, 81, 91 };
            //int[] right  = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            int[] down = { 91, 32, 93, 94, 95, 96, 97, 98, 99, 100 };


            if (e.KeyCode == Keys.Right)
            {
                //if (!right.Contains(tab))
                if (tab != 100)
                    SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == Keys.Left)
            {
                //int c = Convert.ToInt16(LabelName.Text) - 1;
                //int pos = c - 1;
                //TxtQty.TabIndex = pos;
                //TxtQty.Text = "1";
                //TxtQty.Focus();
                //if (!left.Contains(tab)) 
                if (tab != 1)
                    SendKeys.Send("+{TAB}");
            }
            if (e.KeyCode == Keys.Up)
            {
                if (!up.Contains(tab))
                    for (int i = 0; i < 10; i++)
                    {
                        if (tab != 1)
                            SendKeys.Send("+{TAB}");
                    }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (!down.Contains(tab))
                    for (int i = 0; i < 10; i++)
                    {
                        if (tab != 99)
                            SendKeys.Send("{TAB}");
                    }
            }
            if (e.KeyCode != Keys.Enter)
                GetTotalCount();
        }

        private void GetTotalCount()
        {

            try
            {
                int quantity = 0;
                int total = 0;
                foreach (UserInputControl ctr in _frm.tblBids.Controls)
                {

                    if (!string.IsNullOrEmpty(ctr.TickeQty) && ctr.TickeQty != "\r\n" && Convert.ToInt32(ctr.TickeQty) > 0)
                    {

                        quantity = quantity + Convert.ToInt16(ctr.TickeQty);

                    }
                }

                total = 2 * quantity;
                _frm.txttickektsqty.Text = quantity.ToString();
                _frm.txttotalvalue.Text = total.ToString();

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }
    }
}