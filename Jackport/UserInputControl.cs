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


        public UserInputControl()
        {
            InitializeComponent();

            ParentChanged += OnChanged;
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
    }
}
