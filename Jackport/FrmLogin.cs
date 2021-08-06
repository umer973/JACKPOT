using System;YBGS
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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClsService clsService = new ClsService();
            var isValid = clsService.LoginAsync(TxtUser.Text.Trim(), TxtPassword.Text.Trim());
            if (isValid)
                this.Hide();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
