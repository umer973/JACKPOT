using Jackport.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jackport
{
    public partial class FrmJackportDemo : Form
    {
        List<ListValueControl> products;
        List<UserInputControl> InputBox;
        ClsService clsService;
        public string agentToken;
        public string slotdId;
        public string ticketNo;
        public int qty;


        public FrmJackportDemo(Root data)
        {
            FrmLogin objLogin = new FrmLogin();
            objLogin.Hide();
            clsService = new ClsService();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            InitializeComponent();
             LoadProduct();
            LblDate.Text = DateTime.UtcNow.ToString("dd-MMM-yyyy");

            LblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            SetData(data);

        }



        private void LoadProduct()
        {
            for (decimal i = 00; i < 100; i++)
            {
                UserInputControl p1 = new UserInputControl();

                p1.Tag = i;
                p1.TickeName = Convert.ToString(i);
                flowLayoutPanel2.Controls.Add(p1);

            }



            //    new UserInputControl()
            //    {
            //        Name="14"

            //    },
            //     new UserInputControl()
            //    {
            //        Name="15"

            //    },
            //    new UserInputControl()
            //    {
            //        Name="16"


            //    },
            //    new UserInputControl()
            //    {
            //        Name="17"

            //    },
            //    new UserInputControl()
            //    {
            //        Name="18"

            //    },
            //    new UserInputControl()
            //    {
            //        Name="19"

            //    }
            //};

            //foreach (UserInputControl item in InputBox)
            //{
            //    flowLayoutPanel2.Controls.Add(item);
            //}


        }

        private void SetData(Root _root)
        {
            try
            {
                LblAgentId.Text = _root.data.AgentData.agent_code;
                LblBalance.Text= _root.data.AgentData.balance;
                LblCompanyName.Text = _root.data.ApplicationDetails.app_name;
                agentToken = _root.data.AgentData.token;


                loadWinPrizes(_root.data.TimeSlots);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadWinPrizes(List<TimeSlot> timeSlotList)
        {

            var _timeSlot = timeSlotList.Select(x => new ListValueControl()
            {
                Name = x.win_number,
                Time = x.time_end,
                Color = Color.Red
            });

            foreach (ListValueControl item in _timeSlot)
            {
                flowLayoutPanel1.Controls.Add(item);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void FrmJackport_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach(UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                var c = ctr.TickeName;
                var q = ctr.TickeQty;
            }
        }
    }
}
