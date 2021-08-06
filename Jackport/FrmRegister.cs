using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using DeviceId;
using Intersoft.Crosslight.RestClient;

namespace Jackport
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
           

        }

        



        private void button1_Click(object sender, EventArgs e)
        {
            // testApiAsync();

            /// ObjService.ActivateLicenceAsync();
            /// 
            //Hide();
            FrmActivationKey obj = new FrmActivationKey();
            obj.Show();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frmlogin = new FrmLogin();
            frmlogin.Show();

        }
    }

   



}

