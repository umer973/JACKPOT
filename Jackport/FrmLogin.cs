using Jackport.DataModel;
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
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            TxtUser.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
           

        }

        private void Login()
        {
            Cursor.Current = Cursors.WaitCursor;
            ClsService clsService = new ClsService();
            LoginData data = new LoginData();
            FrmJackportDemo obj;
            if (!string.IsNullOrEmpty(TxtUser.Text) && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                data = clsService.LoginAsync(TxtUser.Text.Trim(), TxtPassword.Text.Trim());
                if (data != null)
                {
                    obj = new FrmJackportDemo(data);
                    this.Hide();
                    obj.Show();

                }
            }
            else
            {
                MessageBox.Show("Please enter credentials");
            }

            Cursor.Current = Cursors.Default;
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
                Login();

            }
            // { if (e.KeyCode == Keys.Enter) { SendKeys.Send("{TAB}"); } }
        }

        private void TxtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TxtPassword.Focus();

            }


        }

        private void TxtUser_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TxtPassword.Focus();

            }
        }
    }
}
