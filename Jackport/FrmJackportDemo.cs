using Jackport.DataModel;
using Jackport.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
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
        public int currentSlot = 1;

        List<Bid> bidList = new List<Bid>();
        List<PurchaseTicket> plist = new List<PurchaseTicket>();
        //  private int count = 360;
        // int segundo = 360;
        private int count = 360;
        int segundo = 360;
        DateTime dt = new DateTime();
        List<TimeSlot> timeSlots = new List<TimeSlot>();
        List<TimeSlot> overSlots = new List<TimeSlot>();
        Root data;
        private static TimeZoneInfo timezone;

        DateTime dateTime = DateTime.Now;
        SYSTEMTIME updatedTime = new SYSTEMTIME();

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }

        public FrmJackportDemo(Root _data)
        {

            data = _data;
            FrmLogin objLogin = new FrmLogin();
            objLogin.Hide();
            clsService = new ClsService();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            InitializeComponent();



            SetSystemDate();



        }

        private void SetSystemDate()
        {
            dateTime = data.data.ApplicationDetails.app_time;

            updatedTime.wYear = (short)dateTime.Year;
            updatedTime.wMonth = (short)dateTime.Month;
            updatedTime.wDay = (short)dateTime.Day;
            updatedTime.wHour = (short)dateTime.Hour;
            updatedTime.wMinute = (short)dateTime.Minute;
            updatedTime.wSecond = (short)dateTime.Second;
            SetSystemTime(ref updatedTime);

        }

        public void FrmJackport_Load(object sender, EventArgs e)
        {

           
            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

            dateTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, tz);

            LblDate.Text = dateTime.ToString();

            LblTime.Text = dateTime.TimeOfDay.ToString();

            SetData(data);


            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
            LoadProduct();


            var list = data.data.TimeSlots.Where(x => x.slot_over == "0").ToList();

            var over = data.data.TimeSlots.Where(x => x.slot_over == "1").ToList();

            overSlots = over.Select(x => new TimeSlot
            {
                slot_id = x.slot_id,
                slot_over = x.slot_over

            }).ToList();


            timeSlots = list.Select(x => new TimeSlot
            {
                slot_id = x.slot_id,
                slot_over = x.slot_over,
                time_end = x.time_end


            }).ToList();

            cmbSlot.Text = "Current";

            GetCurrentSlot(list);
            //ScrollDown();

           
        }

        private void GetCurrentSlot(List<TimeSlot> Slotlist)
        {
            var list = data.data.TimeSlots.Where(x => x.slot_over == "0").ToList();

            var time = list.Select(x => x.time_end).FirstOrDefault();

            TimeSpan counter = Convert.ToDateTime(CommonHelper.GetdateFormat(time)) - dateTime;

            lblSlotTime.Text = CommonHelper.GetdateFormat(time);

        }

        private void ScrollDown()
        {
            int flag = 0;
            int winflag = 0;
            foreach (ListValueControl ctr in flowLayoutPanel1.Controls)
            {
                flag++;

                if (ctr.Tag.ToString() == "1")
                {
                    if (flag == 5)
                    {
                        Point current = flowLayoutPanel1.AutoScrollPosition;
                        Point scrolled = new Point(current.X, -current.Y + 100);
                        flowLayoutPanel1.AutoScrollPosition = scrolled;
                        flag = 0;
                    }
                }

                if (ctr.Tag.ToString() == "0" && winflag == 0)
                {
                    winflag = 1;
                    ctr.Color = Color.Green;
                    // ctr.ForeColor
                }


            }


        }

        private void LoadProduct()
        {
            for (int i = 00; i < 100; i++)
            {
                UserInputControl p1 = new UserInputControl();
                string num = Convert.ToString(i);
                if (i == 0)
                {
                    num = "00";
                }
                if (i == 1)
                {
                    num = "01";
                }
                if (i == 2)
                {
                    num = "02";
                }
                if (i == 3)
                {
                    num = "03";
                }
                if (i == 4)
                {
                    num = "04";
                }
                if (i == 5)
                {
                    num = "05";
                }
                if (i == 6)
                {
                    num = "06";
                }
                if (i == 7)
                {
                    num = "07";
                }
                if (i == 8)
                {
                    num = "08";
                }
                if (i == 9)
                {
                    num = "09";
                }


                p1.Tag = i;
                //p1.TickeName = Convert.ToString(i);
                p1.TickeName = Convert.ToString(num);
                flowLayoutPanel2.Controls.Add(p1);

            }






        }

        private void SetData(Root _root)
        {
            try
            {
                LblAgentId.Text = _root.data.AgentData.agent_code;
                LblBalance.Text = _root.data.AgentData.balance;
                LblCompanyName.Text = _root.data.ApplicationDetails.app_name;
                agentToken = _root.data.AgentData.token;

                UserAgent.AgenToken = agentToken;
                UserAgent.AgentCode = _root.data.AgentData.agent_code;
                lblWinRs.Text = _root.data.ApplicationDetails.agent_ticket_win_customer_share_amount;
                lblticketprice.Text = _root.data.ApplicationDetails.agent_ticket_price;
                lblprice.Text = _root.data.ApplicationDetails.agent_ticket_price_format;
                /// lblWinRs.Text=_root.data.
                this.Text = _root.data.ApplicationDetails.app_name + "  " + " Licence Expiry  " + _root.data.LicenseData.license_end_date;

                var request = WebRequest.Create(_root.data.ApplicationDetails.app_logo);


                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pictureBox1.Image = Bitmap.FromStream(stream);
                }
                loadWinPrizes(_root.data.TimeSlots);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadWinPrizes(List<TimeSlot> timeSlotList)
        {

            foreach (ListValueControl item in flowLayoutPanel1.Controls)
            {
                //flowLayoutPanel1.Controls.Remove(item);
                flowLayoutPanel1.Controls.Clear();
            }

            var _timeSlot = timeSlotList.Select(x => new ListValueControl()
            {
                ControlName = x.win_number,
                Time = CommonHelper.GetdateFormat(x.time_end).ToString(),

                Color = x.slot_over.ToString().Trim() == "1" ? Color.Red : Color.White,
                ForeColor = Color.White,

                Tag = x.slot_over
            });

            foreach (ListValueControl item in _timeSlot)
            {
                flowLayoutPanel1.Controls.Add(item);
            }
            ScrollDown();
        }



        private void button7_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {

            BuyTickets();

        }

        private void BuyTickets()
        {
            int flag = 0;
            GetSlots();
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {

                if (!string.IsNullOrEmpty(ctr.TickeQty) && Convert.ToInt32(ctr.TickeQty) > 0)
                {
                    flag = 1;
                    var bids = new Bid
                    {
                        quantity = Convert.ToInt16(ctr.TickeQty),
                        number = Convert.ToInt32(ctr.TickeName)

                    };
                    bidList.Add(bids);
                }
            }

            if (flag == 1)
            {
                var result = clsService.PurchaseSingleTicketAsync(agentToken, bidList, plist);
                LblBalance.Text = result.ToString();
                ClearBoard();
                Print(result);
            }
            else
            {
                MessageBox.Show("Please select ticket first");
            }
        }

        private void Print(object result)
        {
            //throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearBoard();
        }

        public void ClearBoard()
        {
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                ctr.TickeQty = "";


            }
            TxtE0.Text = TxtE1.Text = TxtE2.Text = TxtE3.Text = TxtE4.Text = TxtE5.Text = TxtE7.Text = TxtE8.Text = TxtE9.Text =
                textBox6.Text = "";
            textBox5.Text = Txt0009.Text = Txt1019.Text = Txt2029.Text = Txt3031.Text = Txt4049.Text = Txt5051.Text = Txt7079.Text =
                Txt8089.Text = Txt9099.Text = "";

            TxtE0.BackColor = TxtE1.BackColor = TxtE2.BackColor = TxtE3.BackColor = TxtE4.BackColor = TxtE5.BackColor = TxtE7.BackColor = TxtE8.BackColor = TxtE9.BackColor =
               textBox6.BackColor = Color.Magenta;

            textBox5.BackColor = Txt0009.BackColor = Txt1019.BackColor = Txt2029.BackColor = Txt3031.BackColor = Txt4049.BackColor = Txt5051.BackColor = Txt7079.BackColor =
               Txt8089.BackColor = Txt9099.BackColor = Color.AliceBlue;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowWinNumber();

        }

        private void ShowWinNumber()
        {
            slotdId = timeSlots.Select(x => x.slot_id).FirstOrDefault();
            var endtime = timeSlots.Select(x => x.time_end).FirstOrDefault();
            // var datediff = Convert.ToDateTime(endtime) - (dateTime);
            count--;
            TimeSpan datediff = Convert.ToDateTime(endtime).Subtract(DateTime.UtcNow);


            //var datediff = Convert.ToInt64(GetTimeSpan(Convert.ToDateTime(endtime))) - Convert.ToInt64(GetTimeSpan(dateTime));
            //DateTime d1 = new DateTime(1970, 1, 1);
            //TimeSpan left = new TimeSpan(Convert.ToInt64(datediff));



            if (datediff.Seconds.ToString().PadLeft(2, '0') == "0")
            {
                ClsService clsService = new ClsService();
                var result = clsService.GetWinTickets(Convert.ToInt16(slotdId));

                FrmWinPrice ObjWinPrice = new FrmWinPrice(result);
                ObjWinPrice.Show();
                RefreshSlots();
                count = 360;
                segundo = 360;
            }
            //timer1.Stop();
            //LblCountDown1.Text = counter.ToString();
            string leftTime = string.Format("{0}:{1}:{2}", datediff.Hours.ToString().PadLeft(2, '0'), datediff.Minutes.ToString().PadLeft(2, '0'), datediff.Seconds.ToString().PadLeft(2, '0'));
            //string leftTime = Convert.ToDateTime(GetTimeSpan( left));
            //string leftTime = Convert.ToString(left.TotalMinutes+':'+left.TotalSeconds);
            LblCountDown1.Text = leftTime.ToString();
            //label1.Text = count / 60 + ":" + ((count % 60) >= 10 ? (count % 60).ToString() : "0" + (count % 60));
            int LeftTime1 = count;
            int LeftTime2 = segundo - LeftTime1;
            int LeftTime = segundo - LeftTime2;
            LblCountDown2.Text = leftTime.ToString();
        }

        private string GetTimeSpan(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        private void RefreshSlots()
        {


            timeSlots = clsService.GetUpdatedSlots();

            GetCurrentSlot(timeSlots);
            loadWinPrizes(timeSlots);



        }

        private void button1_Click(object sender, EventArgs e)
        {

            PurchaseTickets();

        }

        private void PurchaseTickets()
        {
            List<PurchasedTickets> purchasetikcet = new List<PurchasedTickets>();
            purchasetikcet = clsService.GetTodaysPurchasedTickets(agentToken);

            FrmBarcode ObjFrmBarcode = new FrmBarcode(purchasetikcet);
            ObjFrmBarcode.Show();
        }

        private void TxtE0_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtE1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtE2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtE3_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtE4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtE5_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtE7_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtE8_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtE9_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtE0_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtE0.Text != "")
            {
                TxtE0.BackColor = Color.YellowGreen;
            }
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "0")
                {
                    ctr.TickeQty = TxtE0.Text;
                }
                else if (Data == "10")
                {
                    ctr.TickeQty = TxtE0.Text;
                }
                else if (Data == "20")
                {
                    ctr.TickeQty = TxtE0.Text;
                }
                else if (Data == "30")
                {
                    ctr.TickeQty = TxtE0.Text;
                }
                else if (Data == "40")
                {
                    ctr.TickeQty = TxtE0.Text;
                }
                else if (Data == "50")
                {
                    ctr.TickeQty = TxtE0.Text;
                }
                else if (Data == "60")
                {
                    ctr.TickeQty = TxtE0.Text;
                }
                else if (Data == "70")
                {
                    ctr.TickeQty = TxtE0.Text;
                }
                else if (Data == "80")
                {
                    ctr.TickeQty = TxtE0.Text;
                }
                else if (Data == "90")
                {
                    ctr.TickeQty = TxtE0.Text;
                }
              



            }
        }

        private void TxtE1_KeyUp(object sender, KeyEventArgs e)
        {
            TxtE1.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "1")
                {
                    ctr.TickeQty = TxtE1.Text;
                }
                else if (Data == "11")
                {
                    ctr.TickeQty = TxtE1.Text;
                }
                else if (Data == "21")
                {
                    ctr.TickeQty = TxtE1.Text;
                }
                else if (Data == "31")
                {
                    ctr.TickeQty = TxtE1.Text;
                }
                else if (Data == "41")
                {
                    ctr.TickeQty = TxtE1.Text;
                }
                else if (Data == "51")
                {
                    ctr.TickeQty = TxtE1.Text;
                }
                else if (Data == "61")
                {
                    ctr.TickeQty = TxtE1.Text;
                }
                else if (Data == "71")
                {
                    ctr.TickeQty = TxtE1.Text;
                }
                else if (Data == "81")
                {
                    ctr.TickeQty = TxtE1.Text;
                }
                else if (Data == "91")
                {
                    ctr.TickeQty = TxtE1.Text;
                }
               


            }
        }

        private void TxtE2_KeyUp(object sender, KeyEventArgs e)
        {
            TxtE2.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "2")
                {
                    ctr.TickeQty = TxtE2.Text;
                }
                else if (Data == "12")
                {
                    ctr.TickeQty = TxtE2.Text;
                }
                else if (Data == "22")
                {
                    ctr.TickeQty = TxtE2.Text;
                }
                else if (Data == "32")
                {
                    ctr.TickeQty = TxtE2.Text;
                }
                else if (Data == "42")
                {
                    ctr.TickeQty = TxtE2.Text;
                }
                else if (Data == "52")
                {
                    ctr.TickeQty = TxtE2.Text;
                }
                else if (Data == "62")
                {
                    ctr.TickeQty = TxtE2.Text;
                }
                else if (Data == "72")
                {
                    ctr.TickeQty = TxtE2.Text;
                }
                else if (Data == "82")
                {
                    ctr.TickeQty = TxtE2.Text;
                }
                else if (Data == "92")
                {
                    ctr.TickeQty = TxtE2.Text;
                }
             



            }
        }

        private void TxtE3_KeyUp(object sender, KeyEventArgs e)
        {
            TxtE3.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "3")
                {
                    ctr.TickeQty = TxtE3.Text;
                }
                else if (Data == "13")
                {
                    ctr.TickeQty = TxtE3.Text;
                }
                else if (Data == "23")
                {
                    ctr.TickeQty = TxtE3.Text;
                }
                else if (Data == "33")
                {
                    ctr.TickeQty = TxtE3.Text;
                }
                else if (Data == "43")
                {
                    ctr.TickeQty = TxtE3.Text;
                }
                else if (Data == "53")
                {
                    ctr.TickeQty = TxtE3.Text;
                }
                else if (Data == "63")
                {
                    ctr.TickeQty = TxtE3.Text;
                }
                else if (Data == "73")
                {
                    ctr.TickeQty = TxtE3.Text;
                }
                else if (Data == "83")
                {
                    ctr.TickeQty = TxtE3.Text;
                }
                else if (Data == "93")
                {
                    ctr.TickeQty = TxtE3.Text;
                }
              



            }
        }

        private void TxtE4_KeyUp(object sender, KeyEventArgs e)
        {
            TxtE4.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "4")
                {
                    ctr.TickeQty = TxtE4.Text;
                }
                else if (Data == "14")
                {
                    ctr.TickeQty = TxtE4.Text;
                }
                else if (Data == "24")
                {
                    ctr.TickeQty = TxtE4.Text;
                }
                else if (Data == "34")
                {
                    ctr.TickeQty = TxtE4.Text;
                }
                else if (Data == "44")
                {
                    ctr.TickeQty = TxtE4.Text;
                }
                else if (Data == "54")
                {
                    ctr.TickeQty = TxtE4.Text;
                }
                else if (Data == "64")
                {
                    ctr.TickeQty = TxtE4.Text;
                }
                else if (Data == "74")
                {
                    ctr.TickeQty = TxtE4.Text;
                }
                else if (Data == "84")
                {
                    ctr.TickeQty = TxtE4.Text;
                }
                else if (Data == "94")
                {
                    ctr.TickeQty = TxtE4.Text;
                }
             



            }
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            textBox6.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "5")
                {
                    ctr.TickeQty = textBox6.Text;
                }
                else if (Data == "15")
                {
                    ctr.TickeQty = textBox6.Text;
                }
                else if (Data == "25")
                {
                    ctr.TickeQty = textBox6.Text;
                }
                else if (Data == "35")
                {
                    ctr.TickeQty = textBox6.Text;
                }
                else if (Data == "45")
                {
                    ctr.TickeQty = textBox6.Text;
                }
                else if (Data == "55")
                {
                    ctr.TickeQty = textBox6.Text;
                }
                else if (Data == "65")
                {
                    ctr.TickeQty = textBox6.Text;
                }
                else if (Data == "75")
                {
                    ctr.TickeQty = textBox6.Text;
                }
                else if (Data == "85")
                {
                    ctr.TickeQty = textBox6.Text;
                }
                else if (Data == "95")
                {
                    ctr.TickeQty = textBox6.Text;
                }
              



            }
        }

        private void TxtE5_KeyUp(object sender, KeyEventArgs e)
        {

            TxtE5.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "6")
                {
                    ctr.TickeQty = TxtE5.Text;
                }
                else if (Data == "16")
                {
                    ctr.TickeQty = TxtE5.Text;
                }
                else if (Data == "26")
                {
                    ctr.TickeQty = TxtE5.Text;
                }
                else if (Data == "36")
                {
                    ctr.TickeQty = TxtE5.Text;
                }
                else if (Data == "46")
                {
                    ctr.TickeQty = TxtE5.Text;
                }
                else if (Data == "56")
                {
                    ctr.TickeQty = TxtE5.Text;
                }
                else if (Data == "66")
                {
                    ctr.TickeQty = TxtE5.Text;
                }
                else if (Data == "76")
                {
                    ctr.TickeQty = TxtE5.Text;
                }
                else if (Data == "86")
                {
                    ctr.TickeQty = TxtE5.Text;
                }
                else if (Data == "96")
                {
                    ctr.TickeQty = TxtE5.Text;
                }
             


            }
        }

        private void TxtE7_KeyUp(object sender, KeyEventArgs e)
        {
            TxtE7.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "7")
                {
                    ctr.TickeQty = TxtE7.Text;
                }
                else if (Data == "17")
                {
                    ctr.TickeQty = TxtE7.Text;
                }
                else if (Data == "27")
                {
                    ctr.TickeQty = TxtE7.Text;
                }
                else if (Data == "37")
                {
                    ctr.TickeQty = TxtE7.Text;
                }
                else if (Data == "47")
                {
                    ctr.TickeQty = TxtE7.Text;
                }
                else if (Data == "57")
                {
                    ctr.TickeQty = TxtE7.Text;
                }
                else if (Data == "67")
                {
                    ctr.TickeQty = TxtE7.Text;
                }
                else if (Data == "77")
                {
                    ctr.TickeQty = TxtE7.Text;
                }
                else if (Data == "87")
                {
                    ctr.TickeQty = TxtE7.Text;
                }
                else if (Data == "97")
                {
                    ctr.TickeQty = TxtE7.Text;
                }
            



            }
        }

        private void TxtE8_KeyUp(object sender, KeyEventArgs e)
        {
            TxtE8.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "8")
                {
                    ctr.TickeQty = TxtE8.Text;
                }
                else if (Data == "18")
                {
                    ctr.TickeQty = TxtE8.Text;
                }
                else if (Data == "28")
                {
                    ctr.TickeQty = TxtE8.Text;
                }
                else if (Data == "38")
                {
                    ctr.TickeQty = TxtE8.Text;
                }
                else if (Data == "48")
                {
                    ctr.TickeQty = TxtE8.Text;
                }
                else if (Data == "58")
                {
                    ctr.TickeQty = TxtE8.Text;
                }
                else if (Data == "68")
                {
                    ctr.TickeQty = TxtE8.Text;
                }
                else if (Data == "78")
                {
                    ctr.TickeQty = TxtE8.Text;
                }
                else if (Data == "88")
                {
                    ctr.TickeQty = TxtE7.Text;
                }
                else if (Data == "98")
                {
                    ctr.TickeQty = TxtE8.Text;
                }
              


            }
        }

        private void TxtE9_KeyUp(object sender, KeyEventArgs e)
        {
            TxtE9.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "9")
                {
                    ctr.TickeQty = TxtE9.Text;
                }
                else if (Data == "19")
                {
                    ctr.TickeQty = TxtE9.Text;
                }
                else if (Data == "29")
                {
                    ctr.TickeQty = TxtE9.Text;
                }
                else if (Data == "39")
                {
                    ctr.TickeQty = TxtE9.Text;
                }
                else if (Data == "49")
                {
                    ctr.TickeQty = TxtE9.Text;
                }
                else if (Data == "59")
                {
                    ctr.TickeQty = TxtE9.Text;
                }
                else if (Data == "69")
                {
                    ctr.TickeQty = TxtE9.Text;
                }
                else if (Data == "79")
                {
                    ctr.TickeQty = TxtE9.Text;
                }
                else if (Data == "89")
                {
                    ctr.TickeQty = TxtE9.Text;
                }
                else if (Data == "99")
                {
                    ctr.TickeQty = TxtE9.Text;
                }
             



            }
        }

        private void Txt0009_KeyUp(object sender, KeyEventArgs e)
        {
            Txt0009.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "0")
                {
                    ctr.TickeQty = Txt0009.Text;
                }
                else if (Data == "1")
                {
                    ctr.TickeQty = Txt0009.Text;
                }
                else if (Data == "2")
                {
                    ctr.TickeQty = Txt0009.Text;
                }
                else if (Data == "3")
                {
                    ctr.TickeQty = Txt0009.Text;
                }
                else if (Data == "4")
                {
                    ctr.TickeQty = Txt0009.Text;
                }
                else if (Data == "5")
                {
                    ctr.TickeQty = Txt0009.Text;
                }
                else if (Data == "6")
                {
                    ctr.TickeQty = Txt0009.Text;
                }
                else if (Data == "7")
                {
                    ctr.TickeQty = Txt0009.Text;
                }
                else if (Data == "8")
                {
                    ctr.TickeQty = Txt0009.Text;
                }
                else if (Data == "9")
                {
                    ctr.TickeQty = Txt0009.Text;
                }
             



            }
        }

        private void Txt1019_KeyUp(object sender, KeyEventArgs e)
        {
            Txt1019.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "10")
                {
                    ctr.TickeQty = Txt1019.Text;
                }
                else if (Data == "11")
                {
                    ctr.TickeQty = Txt1019.Text;
                }
                else if (Data == "12")
                {
                    ctr.TickeQty = Txt1019.Text;
                }
                else if (Data == "13")
                {
                    ctr.TickeQty = Txt1019.Text;
                }
                else if (Data == "14")
                {
                    ctr.TickeQty = Txt1019.Text;
                }
                else if (Data == "15")
                {
                    ctr.TickeQty = Txt1019.Text;
                }
                else if (Data == "16")
                {
                    ctr.TickeQty = Txt1019.Text;
                }
                else if (Data == "17")
                {
                    ctr.TickeQty = Txt1019.Text;
                }
                else if (Data == "18")
                {
                    ctr.TickeQty = Txt1019.Text;
                }
                else if (Data == "19")
                {
                    ctr.TickeQty = Txt1019.Text;
                }
             



            }
        }

        private void Txt2029_KeyUp(object sender, KeyEventArgs e)
        {
            Txt2029.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "20")
                {
                    ctr.TickeQty = Txt2029.Text;
                }
                else if (Data == "21")
                {
                    ctr.TickeQty = Txt2029.Text;
                }
                else if (Data == "22")
                {
                    ctr.TickeQty = Txt2029.Text;
                }
                else if (Data == "23")
                {
                    ctr.TickeQty = Txt2029.Text;
                }
                else if (Data == "24")
                {
                    ctr.TickeQty = Txt2029.Text;
                }
                else if (Data == "25")
                {
                    ctr.TickeQty = Txt2029.Text;
                }
                else if (Data == "26")
                {
                    ctr.TickeQty = Txt2029.Text;
                }
                else if (Data == "27")
                {
                    ctr.TickeQty = Txt2029.Text;
                }
                else if (Data == "28")
                {
                    ctr.TickeQty = Txt2029.Text;
                }
                else if (Data == "29")
                {
                    ctr.TickeQty = Txt2029.Text;
                }
             

            }
        }

        private void Txt3031_KeyUp(object sender, KeyEventArgs e)
        {
            Txt3031.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "30")
                {
                    ctr.TickeQty = Txt3031.Text;
                }
                else if (Data == "31")
                {
                    ctr.TickeQty = Txt3031.Text;
                }
                else if (Data == "32")
                {
                    ctr.TickeQty = Txt3031.Text;
                }
                else if (Data == "33")
                {
                    ctr.TickeQty = Txt3031.Text;
                }
                else if (Data == "34")
                {
                    ctr.TickeQty = Txt3031.Text;
                }
                else if (Data == "35")
                {
                    ctr.TickeQty = Txt3031.Text;
                }
                else if (Data == "36")
                {
                    ctr.TickeQty = Txt3031.Text;
                }
                else if (Data == "37")
                {
                    ctr.TickeQty = Txt2029.Text;
                }
                else if (Data == "38")
                {
                    ctr.TickeQty = Txt3031.Text;
                }
                else if (Data == "39")
                {
                    ctr.TickeQty = Txt3031.Text;
                }
             



            }
        }

        private void Txt4049_KeyUp(object sender, KeyEventArgs e)
        {
            Txt4049.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "40")
                {
                    ctr.TickeQty = Txt4049.Text;
                }
                else if (Data == "41")
                {
                    ctr.TickeQty = Txt4049.Text;
                }
                else if (Data == "42")
                {
                    ctr.TickeQty = Txt4049.Text;
                }
                else if (Data == "43")
                {
                    ctr.TickeQty = Txt3031.Text;
                }
                else if (Data == "44")
                {
                    ctr.TickeQty = Txt4049.Text;
                }
                else if (Data == "45")
                {
                    ctr.TickeQty = Txt4049.Text;
                }
                else if (Data == "46")
                {
                    ctr.TickeQty = Txt4049.Text;
                }
                else if (Data == "47")
                {
                    ctr.TickeQty = Txt4049.Text;
                }
                else if (Data == "48")
                {
                    ctr.TickeQty = Txt4049.Text;
                }
                else if (Data == "49")
                {
                    ctr.TickeQty = Txt4049.Text;
                }
          


            }
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            textBox5.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "50")
                {
                    ctr.TickeQty = textBox5.Text;
                }
                else if (Data == "51")
                {
                    ctr.TickeQty = textBox5.Text;
                }
                else if (Data == "52")
                {
                    ctr.TickeQty = textBox5.Text;
                }
                else if (Data == "53")
                {
                    ctr.TickeQty = textBox5.Text;
                }
                else if (Data == "54")
                {
                    ctr.TickeQty = textBox5.Text;
                }
                else if (Data == "55")
                {
                    ctr.TickeQty = textBox5.Text;
                }
                else if (Data == "56")
                {
                    ctr.TickeQty = textBox5.Text;
                }
                else if (Data == "57")
                {
                    ctr.TickeQty = textBox5.Text;
                }
                else if (Data == "58")
                {
                    ctr.TickeQty = textBox5.Text;
                }
                else if (Data == "59")
                {
                    ctr.TickeQty = textBox5.Text;
                }
            



            }
        }

        private void Txt5051_KeyUp(object sender, KeyEventArgs e)
        {
            Txt5051.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "60")
                {
                    ctr.TickeQty = Txt5051.Text;
                }
                else if (Data == "61")
                {
                    ctr.TickeQty = Txt5051.Text;
                }
                else if (Data == "62")
                {
                    ctr.TickeQty = Txt5051.Text;
                }
                else if (Data == "63")
                {
                    ctr.TickeQty = Txt5051.Text;
                }
                else if (Data == "64")
                {
                    ctr.TickeQty = Txt5051.Text;
                }
                else if (Data == "65")
                {
                    ctr.TickeQty = Txt5051.Text;
                }
                else if (Data == "66")
                {
                    ctr.TickeQty = Txt5051.Text;
                }
                else if (Data == "67")
                {
                    ctr.TickeQty = Txt5051.Text;
                }
                else if (Data == "68")
                {
                    ctr.TickeQty = Txt5051.Text;
                }
                else if (Data == "69")
                {
                    ctr.TickeQty = Txt5051.Text;
                }
           


            }
        }

        private void Txt7079_KeyUp(object sender, KeyEventArgs e)
        {
            Txt7079.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "70")
                {
                    ctr.TickeQty = Txt7079.Text;
                }
                else if (Data == "71")
                {
                    ctr.TickeQty = Txt7079.Text;
                }
                else if (Data == "72")
                {
                    ctr.TickeQty = Txt7079.Text;
                }
                else if (Data == "73")
                {
                    ctr.TickeQty = Txt7079.Text;
                }
                else if (Data == "74")
                {
                    ctr.TickeQty = Txt7079.Text;
                }
                else if (Data == "75")
                {
                    ctr.TickeQty = Txt7079.Text;
                }
                else if (Data == "76")
                {
                    ctr.TickeQty = Txt7079.Text;
                }
                else if (Data == "77")
                {
                    ctr.TickeQty = Txt7079.Text;
                }
                else if (Data == "78")
                {
                    ctr.TickeQty = Txt7079.Text;
                }
                else if (Data == "79")
                {
                    ctr.TickeQty = Txt7079.Text;
                }
            


            }
        }

        private void Txt8089_KeyUp(object sender, KeyEventArgs e)
        {
            Txt8089.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "80")
                {
                    ctr.TickeQty = Txt8089.Text;
                }
                else if (Data == "81")
                {
                    ctr.TickeQty = Txt8089.Text;
                }
                else if (Data == "82")
                {
                    ctr.TickeQty = Txt8089.Text;
                }
                else if (Data == "83")
                {
                    ctr.TickeQty = Txt8089.Text;
                }
                else if (Data == "84")
                {
                    ctr.TickeQty = Txt8089.Text;
                }
                else if (Data == "85")
                {
                    ctr.TickeQty = Txt8089.Text;
                }
                else if (Data == "86")
                {
                    ctr.TickeQty = Txt8089.Text;
                }
                else if (Data == "87")
                {
                    ctr.TickeQty = Txt8089.Text;
                }
                else if (Data == "88")
                {
                    ctr.TickeQty = Txt8089.Text;
                }
                else if (Data == "89")
                {
                    ctr.TickeQty = Txt8089.Text;
                }
               



            }
        }

        private void Txt9099_KeyUp(object sender, KeyEventArgs e)
        {
            Txt9099.BackColor = Color.YellowGreen;
            foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
            {
                string Data = Convert.ToString(ctr.Tag);
                if (Data == "90")
                {
                    ctr.TickeQty = Txt9099.Text;
                }
                else if (Data == "91")
                {
                    ctr.TickeQty = Txt9099.Text;
                }
                else if (Data == "92")
                {
                    ctr.TickeQty = Txt9099.Text;
                }
                else if (Data == "93")
                {
                    ctr.TickeQty = Txt9099.Text;
                }
                else if (Data == "94")
                {
                    ctr.TickeQty = Txt9099.Text;
                }
                else if (Data == "95")
                {
                    ctr.TickeQty = Txt9099.Text;
                }
                else if (Data == "96")
                {
                    ctr.TickeQty = Txt9099.Text;
                }
                else if (Data == "97")
                {
                    ctr.TickeQty = Txt9099.Text;
                }
                else if (Data == "98")
                {
                    ctr.TickeQty = Txt9099.Text;
                }
                else if (Data == "99")
                {
                    ctr.TickeQty = Txt9099.Text;
                }
              


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetReportSummary();

        }

        private void GetReportSummary()
        {

            FrmTMLPrint objReport = new FrmTMLPrint();
            objReport.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void cmbSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSlots();
        }

        private void GetSlots()
        {


            if (cmbSlot.Text.Trim() == "Current")
            {
                currentSlot = 1;
            }
            else if (cmbSlot.Text.Trim() == "NEXT 5")
            {
                currentSlot = 5;
            }
            else if (cmbSlot.Text.Trim() == "NEXT 15")
            {
                currentSlot = 15;
            }
            else if (cmbSlot.Text.Trim() == "NEXT 20")
            {
                currentSlot = 20;
            }
            else if (cmbSlot.Text.Trim() == "ALL DRAW")
            {
                currentSlot = timeSlots.Count;
            }

            var slot = timeSlots.Select(x => new PurchaseTicket
            {
                slot_id = Convert.ToInt16(x.slot_id)
            }).ToList();

            for (int i = 0; i < currentSlot; i++)
            {
                var sl = new PurchaseTicket
                {
                    slot_id = slot[i].slot_id
                };
                plist.Add(sl);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            GenerateRondomTicketNumber();

        }

        private void GenerateRondomTicketNumber()
        {
            Random rnd = new Random();
            int n = Convert.ToInt32(TxtLpNo.Text);
            int[] intArr = new int[n];
            int i = 0;
            for (i = 0; i < intArr.Length; i++)
            {
                int num = rnd.Next(0, 99);
                intArr[i] = num;
                //Console.WriteLine(num);

            }

            for (int j = 0; j < intArr.Length; j++)
            {
                foreach (UserInputControl ctr in flowLayoutPanel2.Controls)
                {
                    string Data = Convert.ToString(ctr.Tag);
                    int c = intArr[j];
                    if (Data == Convert.ToString(intArr[j]))
                    {
                        ctr.TickeQty = "1";
                    }

                }

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            GenerateRondomTicketNumber();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AllData();
        }

        private void AllData()
        {
            List<WinTicketData> Wintikcet = new List<WinTicketData>();
            Wintikcet = clsService.GetWinData();

            FrmAllData ObjFrmBarcode = new FrmAllData(Wintikcet);
            ObjFrmBarcode.Show();
        }
    }
}
