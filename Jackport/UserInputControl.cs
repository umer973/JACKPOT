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



    }
}
