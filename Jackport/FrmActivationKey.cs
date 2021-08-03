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
    public partial class FrmActivationKey : Form
    {
        public FrmActivationKey()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            ClsService ObjService = new ClsService();
             ObjService.ActivateLicenceAsync(TxtLicence.Text.Trim());

            //MessageBox.Show(message.ToString());
        }
    }
}
