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


            if (!string.IsNullOrEmpty(TxtUser.Text) && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                var isValid = clsService.LoginAsync(TxtUser.Text.Trim(), TxtPassword.Text.Trim());
                if (isValid)
                    this.Hide();
            }
            else
            {
                MessageBox.Show("Please enter credentials");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TxtUser_MouseEnter(object sender, EventArgs e)
        {

        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void TxtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TxtPassword.Focus();
            }
        }
    }
}
