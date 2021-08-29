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
            if (CheckTimeZone())

                Login();
            else
                MessageBox.Show("Please set Indian Standard Time Zone");


        }

        private bool CheckTimeZone()
        {
            TimeZone curTimeZone = TimeZone.CurrentTimeZone;
            if (curTimeZone.StandardName == "India Standard Time")
                return true;
            return false;

        }

        private void Login()
        {


            Cursor.Current = Cursors.WaitCursor;
            ClsService clsService = new ClsService();
            LoginData data = new LoginData();

            if (!string.IsNullOrEmpty(TxtUser.Text) && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                data = clsService.LoginAsync(TxtUser.Text.Trim(), TxtPassword.Text.Trim());



                if (data != null)
                {
                    if (CheckServerDate(data.ApplicationDetails.app_date, data.ApplicationDetails.app_time))
                    {
                        FrmJackportDemo obj = new FrmJackportDemo(data);
                    }
                    else
                        MessageBox.Show("Set System Date Time First");


                    // obj.Show();


                }
            }
            else
            {
                MessageBox.Show("Please enter credentials");
            }

            Cursor.Current = Cursors.Default;
            this.Hide();

        }

        private bool CheckServerDate(string appdate, string apptime)
        {
            DateTime systemDate = DateTime.Now;

            var differ = DateTime.Compare(Convert.ToDateTime(appdate), systemDate.Date);

            string systime = systemDate.Hour.ToString();
            string sysmin = systemDate.Minute.ToString();
            string apphour = Convert.ToDateTime(apptime).Hour.ToString();
            string appMin = Convert.ToDateTime(apptime).Minute.ToString();

            var time = Convert.ToInt16(systime) - Convert.ToInt16(apphour);

            var mins = Convert.ToInt16(sysmin) - Convert.ToInt16(appMin);

            if (differ == 0 && time == 0 && mins < 2)
                return true;
            return false;



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

        private void TxtUser_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
