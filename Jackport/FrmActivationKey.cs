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
            bool result = ObjService.ActivateLicenceAsync(TxtLicence.Text.Trim());

            if (result)
            {
                FrmRegister obj = new FrmRegister();

                obj.Show();
                this.Hide();
            }


            //MessageBox.Show(message.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
