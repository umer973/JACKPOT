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

        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtQty_TextChanged(object sender, EventArgs e)
        {
            if (TxtQty.Text != "")
                TxtQty.BackColor = Color.Green;
            else
                TxtQty.BackColor = Color.White;
        }

        private void TxtQty_KeyUp(object sender, KeyEventArgs e)
        {

            GetTotalCount();
        }

        private void GetTotalCount()
        {

            try
            {
                int quantity = 0;
                int total = 0;
                foreach (UserInputControl ctr in _frm.flowLayoutPanel2.Controls)
                {

                    if (!string.IsNullOrEmpty(ctr.TickeQty) && Convert.ToInt32(ctr.TickeQty) > 0)
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
                MessageBox.Show(ex.Message);
            }
        }
    }
}