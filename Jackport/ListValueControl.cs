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
    public partial class ListValueControl : UserControl
    {
        public ListValueControl()
        {
            InitializeComponent();
        }

        private void ListValueControl_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public string ControlName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }
        //set and get value to lblprice
        public string Time
        {
            get { return LblTime.Text; }
            set { LblTime.Text = value; }
        }
        //set and get background color to lblcolor

        public Color Color
        {
            get { return lblName.BackColor; }
            set { lblName.BackColor = value; }


          
        }

        public Color ForeColor
        {
            get { return lblName.ForeColor; }
            set { lblName.ForeColor = value; }



        }



    }
}
