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
    public partial class GameBoardV1 : Form
    {
        public GameBoardV1()
        {
            InitializeComponent();
            AddControls();
        }

        private void AddControls()
        {
            
            for (int row = 0; row <= 9; row++)
            {
                

                for (int column = 0; column <= 9; column++)
                {
                   // BidControl ctr = new BidControl(this);

                  //  ctr.Dock = DockStyle.Fill;
                    // ctr.TickeName = row + "" + column;

                    //tblBids.Controls.Add(ctr, column, row);
                }

            }

        }
    }
}
