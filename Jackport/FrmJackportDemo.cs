using CrystalDecisions.CrystalReports.Engine;
using Jackport.DataModel;
using Jackport.Helper;
using Jackport.Security;
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
using System.Threading;
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
        public string endtime;
        List<Bid> bidList = new List<Bid>();
        List<PurchaseTicket> plist = new List<PurchaseTicket>();
        //  private int count = 360;
        // int segundo = 360;
        private int count = 360;
        int segundo = 360;
        DateTime dt = new DateTime();
        List<TimeSlot> timeSlots = new List<TimeSlot>();
        List<TimeSlot> overSlots = new List<TimeSlot>();
        LoginData data;
        private static TimeZoneInfo timezone;

        DateTime appTime;
        DateTime slotitme;
        DateTime dateTime = DateTime.Now;

        int ticketPrice = 0;


        public FrmJackportDemo(LoginData _data)
        {

            data = _data;
            FrmLogin objLogin = new FrmLogin();
            objLogin.Hide();
            clsService = new ClsService();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            InitializeComponent();

        }

        private void SetSystemDate()
        {
            appTime = Convert.ToDateTime(data.ApplicationDetails.app_time);

            // Get time in local time zone 
            DateTime thisTime = DateTime.Now;
            Console.WriteLine("Time in {0} zone: {1}", TimeZoneInfo.Local.IsDaylightSavingTime(thisTime) ?
                               TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName, thisTime);
            Console.WriteLine("   UTC Time: {0}", TimeZoneInfo.ConvertTimeToUtc(thisTime, TimeZoneInfo.Local));


            TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

            DateTime tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst);
            //  LblDate.Text = tst.IsDaylightSavingTime(tstTime) ? tst.DaylightName : tst.StandardName, tstTime;
            Console.WriteLine("   UTC Time: {0}", TimeZoneInfo.ConvertTimeToUtc(tstTime, tst));


        }

        public void FrmJackport_Load(object sender, EventArgs e)
        {


            DisplayData();


            SetSystemDate();



        }

        private void DisplayData()
        {
            SetLoading(true);

            SetData(data);



            LoadProduct();


            //   var list = data.TimeSlots.Where(x => x.slot_over == "0").ToList();

            var over = data.TimeSlots.Where(x => x.slot_over == "1");

            var last_end = over.LastOrDefault();


            overSlots = over.Select(x => new TimeSlot
            {
                slot_id = x.slot_id,
                slot_over = x.slot_over

            }).ToList();


            timeSlots = data.TimeSlots.Select(x => new TimeSlot
            {
                slot_id = x.slot_id,
                slot_over = x.slot_over,
                time_end = x.time_end


            }).ToList();

            cmbSlot.Text = "Current";

            GetCurrentSlot(data.TimeSlots);



            //ScrollDown();

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();

            SetLoading(false);

            // RunCounter();
        }

        private void SetLoading(bool displayLoader)
        {
            Loader loader = new Loader();
            if (displayLoader)
            {

                //this.Visible = false;
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;


            }
            else
            {
                grpfooter.Visible = true;

                grpslots.Visible = true;
                grptickets.Visible = true;
                headerpanel.Visible = true;

                //this.Visible = true;
                this.Cursor = System.Windows.Forms.Cursors.Default;
                ScrollDown();

            }
        }

        //private int GetOverSlot()
        //{

        //}
        private bool GetCurrentSlot(List<TimeSlot> Slotlist)
        {
            bool flag = true;
            try
            {
                var l = Slotlist.OrderByDescending(x => x.time_end).ToList();
                for (int i = l.Count - 1; i >= 0; i--)
                {
                    if (l[i].slot_over == "1")
                    {
                        slotdId = Convert.ToInt32(l[i - 1].slot_id).ToString();
                        endtime = l[i - 1].time_end;

                    }


                }
                lblSlotTime.Text = CommonHelper.GetdateFormat(endtime);

                var list = Slotlist.OrderByDescending(x => x.slot_id).ToList();

                list = list.Where(x => x.slot_over == "0").ToList();


                list = Slotlist.OrderBy(x => x.slot_id).ToList();



                // lblSlotTime.Text = CommonHelper.GetdateFormat(endtime);
                //SetSlotTime(CommonHelper.GetdateFormat(endtime));

                timeSlots = null;

                timeSlots = Slotlist.Select(x => new TimeSlot
                {
                    slot_id = x.slot_id,
                    slot_over = x.slot_over,
                    time_end = x.time_end,
                    win_number = x.win_number


                }).ToList();

                if (timeSlots == null)
                {
                    flag = false;
                }

                loadWinPrizes(timeSlots);
            }
            catch (Exception ex)
            {

            }
            return flag;

        }



        private void SetSlotTime(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (lblSlotTime.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                lblSlotTime.Text = text;
            }
        }

        private void ScrollDown()
        {
            int flag = 0;
            int winflag = 0;
            foreach (ListValueControl ctr in flowLayoutPanel1.Controls)
            {
                flag++;

                if (ctr.Tag.ToString() != slotdId)
                {
                    if (flag == 6)
                    {
                        Point current = flowLayoutPanel1.AutoScrollPosition;
                        Point scrolled = new Point(current.X, -current.Y + 80);
                        flowLayoutPanel1.AutoScrollPosition = scrolled;
                        flag = 0;
                    }
                }

                if (ctr.Tag.ToString() == slotdId && winflag == 0)
                {
                    winflag = 1;
                    ctr.Color = Color.Green;
                    // ctr.ForeColor
                }

                Application.DoEvents();
            }



        }

        private void LoadProduct()
        {
            for (int i = 0; i < 100; i++)
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

        private void SetData(LoginData _root)
        {
            try
            {
                LblAgentId.Text = data.AgentData.agent_code;
                LblBalance.Text = data.AgentData.balance;
                LblCompanyName.Text = data.ApplicationDetails.app_name;
                agentToken = data.AgentData.token;

                UserAgent.AgenToken = agentToken;
                UserAgent.AgentCode = data.AgentData.agent_code;
                lblWinRs.Text = _root.ApplicationDetails.agent_ticket_win_customer_share_amount;
                lblticketprice.Text = _root.ApplicationDetails.agent_ticket_price;
                lblprice.Text = _root.ApplicationDetails.agent_ticket_price_format;
                ticketPrice = Convert.ToInt16(_root.ApplicationDetails.agent_ticket_price);
                /// lblWinRs.Text=_root.data.
                this.Text = _root.ApplicationDetails.app_name + "  " + " Licence Expiry  " + data.LicenseData.license_end_date;

                appTime = Convert.ToDateTime(_root.ApplicationDetails.app_time.ToString());
                LblDate.Text = _root.ApplicationDetails.app_date.ToString();
                //LblDate.Text=_root.ApplicationDetails.

                var request = WebRequest.Create(_root.ApplicationDetails.app_logo);


                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pictureBox1.Image = Bitmap.FromStream(stream);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadWinPrizes(List<TimeSlot> timeSlotList)
        {
            int i = 0;

            foreach (ListValueControl item in flowLayoutPanel1.Controls)
            {
                //flowLayoutPanel1.Controls.Remove(item);
                flowLayoutPanel1.Controls.Clear();
            }



            var _timeSlot = timeSlotList.Select(x => new ListValueControl()
            {
                ControlName = x.win_number,
                Time = CommonHelper.GetdateFormat(x.time_end).ToString(),

                Color = Color.White,

                ForeColor = Convert.ToInt16(x.slot_id) % 2 == 0 ? Color.Blue : Color.Red,

                Tag = x.slot_id
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
            try

            {
                bidList.Clear();
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
                    List<TimeSlotList> slots = new List<TimeSlotList>();
                    slots = clsService.PurchaseSingleTicketAsync(agentToken, bidList, plist);
                    /// LblBalance.Text = result.ToString();

                    ClearBoard();
                    // Print(slots);
                    Popup objpop = new Popup(slots);
                    objpop.Show();
                }
                else
                {
                    MessageBox.Show("Please select ticket first");
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Print(List<TimeSlotList> list)
        {
            //throw new NotImplementedException();
            ReportDocument cRep = new ReportDocument();

            //cRep.Load(Application.StartupPath + "/Report/DsPurchase/CryPurchaseTicket.rpt");
            cRep.Load("E:/Live Project/JackPot-master/Jackport/Jackport/Report/DsPurchase/CryPurchaseTicket.rpt");
            // CRPT.Wholesale.Challan.DsChallan.DsChallan ObjDsPo = new CRPT.Wholesale.Challan.DsChallan.DsChallan();
            Report.DsPurchase.DsPurchase ObjDsPo = new Report.DsPurchase.DsPurchase();
            DataTable dt = new DataTable();

            dt.Columns.Add("date_slot");
            dt.Columns.Add("time_start");
            dt.Columns.Add("time_end");
            dt.Columns.Add("win_number");
            foreach (var item in list)
            {
                dt.Rows.Add(item.date_slot, item.time_start, item.time_end, item.slot_id);
            }
            cRep.SetDataSource(dt);
            // crptViwerprintInvoice.ReportSource = cRep;
            //try
            //{
            //    Popup objpop;
            //    PnlPrintInvoice.Visible = true;
            //    objpop = new Popup("Purchase Ticket");
            //    objpop.StartPosition = FormStartPosition.CenterScreen;
            //    objpop.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //    objpop.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
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

            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

            dateTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, tz);

            appTime = appTime.AddSeconds(1);

            int hh = appTime.Hour;
            int mm = appTime.Minute;
            int ss = appTime.Second;


            string time = "";

            //padding leading zero
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            //appTime = appTime - Convert.ToDate(time);


            LblTime.Text = CommonHelper.GetdateFormat(time);

            slotitme = Convert.ToDateTime(time);

            TimeSpan datediff = Convert.ToDateTime(CommonHelper.GetdateFormat(endtime)).Subtract(slotitme);


            string leftTime = string.Format("{0}:{1}:{2}", datediff.Hours.ToString().PadLeft(2, '0'), datediff.Minutes.ToString().PadLeft(2, '0'), datediff.Seconds.ToString().PadLeft(2, '0'));
            LblCountDown1.Text = leftTime.ToString();
            var remainintime = DateTime.Compare(Convert.ToDateTime(endtime), appTime);

            if (remainintime == 0)
            {
                timer1.Stop();
                ClsService clsService = new ClsService();
                var result = clsService.GetWinTickets(Convert.ToInt16(slotdId));

                FrmWinPrice ObjWinPrice = new FrmWinPrice(result);
                ObjWinPrice.ShowDialog();
                RefreshSlots();
                timer1.Start();
            }
        }

        //public void SetAppTime()
        //{
        //    while (true)
        //    {
        //        apptime = apptime + 1; 
        //    }
        //}

        //public async Task RunCounter()
        //{
        //    ClsService service = new ClsService();
        //    await Task.Run(() =>
        //    {

        //        bool flag = true;
        //        while (flag)
        //        {
        //            TimeSpan datediff = Convert.ToDateTime(CommonHelper.GetdateFormat(endtime)).Subtract(slotitme);

        //            //TimeSpan datediff = DateTimeOffset.Parse(endtime).UtcDateTime.Subtract(DateTime.Parse(DateTime.UtcNoww));
        //            // int datediff1 = Convert.ToInt32(GetTimeSpan(Convert.ToDateTime(endtime))) - Convert.ToInt32(GetTimeSpan((Convert.ToDateTime(appTime))));

        //            string leftTime = string.Format("{0}:{1}:{2}", datediff.Hours.ToString().PadLeft(2, '0'), datediff.Minutes.ToString().PadLeft(2, '0'), datediff.Seconds.ToString().PadLeft(2, '0'));
        //            SetText(leftTime);
        //            // appTime = service.GetUpdatedTime();
        //            //LblTime.Text = CommonHelper.GetdateFormat(appTime);
        //            if (datediff.Minutes < 0 && datediff.Seconds < 0 && datediff.Hours <= 0)
        //            {
        //                SetText("00:00:00");
        //                flag = false;
        //            }


        //            if (datediff.Hours == 0 && datediff.Minutes == 0 && datediff.Seconds == 0 && datediff.Minutes >= 0 && datediff.Seconds >= 0 && datediff.Hours >= 0)
        //            {
        //                flag = false;

        //            }
        //        }




        //    });

        //    ClsService clsService = new ClsService();
        //    var result = clsService.GetWinTickets(Convert.ToInt16(slotdId));

        //    FrmWinPrice ObjWinPrice = new FrmWinPrice(result);
        //    ObjWinPrice.ShowDialog();
        //    RefreshSlots();



        //}

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (LblCountDown1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                LblCountDown1.Text = text;
            }


            //LblTime.Text = appTime.tos;
        }

        private void ShowWinNumber()
        {
            // slotdId = timeSlots.Select(x => x.slot_id).FirstOrDefault();

            // var slot = timeSlots.Where(x => x.slot_over == "0").FirstOrDefault();
            // var endtime = (x => x.time_end).FirstOrDefault();
            // var datediff = Convert.ToDateTime(endtime) - (dateTime);
            count--;
            TimeSpan datediff = Convert.ToDateTime(endtime) - (DateTime.Now);


            //var datediff = Convert.ToInt64(GetTimeSpan(Convert.ToDateTime(endtime))) - Convert.ToInt64(GetTimeSpan(dateTime));
            //DateTime d1 = new DateTime(1970, 1, 1);
            //TimeSpan left = new TimeSpan(Convert.ToInt64(datediff));



            if (datediff.Hours == 0 && datediff.Minutes == 0 && datediff.Seconds == 0)
            {
                ClsService clsService = new ClsService();
                var result = clsService.GetWinTickets(Convert.ToInt16(slotdId));

                FrmWinPrice ObjWinPrice = new FrmWinPrice(result);
                ObjWinPrice.ShowDialog();
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
            // LblCountDown2.Text = leftTime.ToString();
        }

        private string GetTimeSpan(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        private void RefreshSlots()
        {
            try
            {

                List<TimeSlot> timeSlot = clsService.GetUpdatedSlots();

                var result = GetCurrentSlot(timeSlot);

                //else
                //    timer1_Tick.stop

            }
            catch (Exception ex)
            {

            }



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
            ObjFrmBarcode.ShowDialog();
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
            objReport.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void cmbSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///GetSlots();
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
                currentSlot = timeSlots.Count - 1;
            }

            plist.Clear();

            var list = timeSlots.Where(x => x.slot_over == "0").ToList();

            //string[] slots = new string[count];

            //int position = 0;

            //var l = timeSlots.OrderByDescending(x => x.time_end).ToList();

            //for (int i = l.Count - 1; i >= 0; i--)
            //{
            //    if (l[i].slot_over == "1")
            //    {
            //        position = i;



            //    }
            //}

            /// int j = 0;
            /// 

            list = list.Where(x => Convert.ToInt32(x.slot_id) >= Convert.ToInt32(slotdId)).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                if (i != currentSlot)
                {
                    var sl = new PurchaseTicket
                    {
                        slot_id = Convert.ToInt32(list[i].slot_id)
                    };
                    plist.Add(sl);
                }
                else
                    break;


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
            try
            {
                if (TxtLpNo.Text != "")
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
            }
            catch (Exception ex)
            {

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


            FrmAllData ObjFrmBarcode = new FrmAllData();
            ObjFrmBarcode.ShowDialog();
        }

        private void FrmJackportDemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
            {
                ClearBoard();
            }
            if (e.KeyCode == Keys.T)
            {
                PurchaseTickets();
            }
            if (e.KeyCode == Keys.F12)
            {
                BuyTickets();
            }
            if (e.KeyCode == Keys.R)
            {
                AllData();
            }
            if (e.KeyCode == Keys.S)
            {
                GetReportSummary();
            }


        }

        private void flowLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            Application.DoEvents();
            flowLayoutPanel2.HorizontalScroll.Value = 0;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTSN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtTSN.Text.Trim()))
                {
                    ClaimTicket(txtTSN.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Please eneter ticket barcode..");
                }
            }
        }


        private void ClaimTicket(string barcode)
        {
            ClsService clsservice = new ClsService();

            bool result = clsservice.ClaimTicket(UserAgent.AgenToken, barcode);
            if (result)
            {
                this.Hide();
                MessageBox.Show("Ticket Claim Successfully");

            }




        }

        private void txttickektsqty_TextChanged(object sender, EventArgs e)
        {
            int qty = 0;
            int amount = 0;
            try
            {
                if (!string.IsNullOrEmpty(txttickektsqty.Text.Trim()))
                {
                    qty = Convert.ToInt16(txttickektsqty.Text.Trim());
                    amount = qty * ticketPrice;
                    txttotalvalue.Text = amount.ToString();
                }
            }
            catch
            {
                txttotalvalue.Text = "0.00";
            }
        }

        private void grptickets_Enter(object sender, EventArgs e)
        {

        }

        private void label5_MouseClick(object sender, MouseEventArgs e)
        {

            if (label5.Text == "Show Balance")
            {
                LblBalance.Visible = true;
                label5.Text = "Hide Balance";
            }
            else
            {
                LblBalance.Visible = false;
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (label5.Text == "Show Balance")
            {
                LblBalance.Visible = true;
                label5.Text = "Hide Balance";
            }
            else
            {
                LblBalance.Visible = false;
                label5.Text = "Show Balance";
            }

        }
    }
}
