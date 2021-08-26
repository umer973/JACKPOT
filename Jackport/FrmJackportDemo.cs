

namespace Jackport
{

    using CrystalDecisions.CrystalReports.Engine;
    using Jackport.DataModel;
    using Jackport.Helper;
    using Jackport.Security;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class FrmJackportDemo : Form
    {

        ClsService clsService;
        public string agentToken;
        public string slotdId;
        public string ticketNo;
        public int qty;
        public int currentSlot = 1;
        public string endtime;
        List<Bid> bidList = new List<Bid>();
        List<PurchaseTicket> plist = new List<PurchaseTicket>();
        List<TimeSlot> timeSlots = new List<TimeSlot>();
        List<TimeSlot> overSlots = new List<TimeSlot>();
        LoginData data = new LoginData();
        DateTime appTime;
        DateTime slotitme;
        DateTime dateTime = DateTime.Now;
        int ticketPrice = 0;
        bool IsSloverOver = false;
        bool IsFullScreen = false;

        //BusyIndicator busyIndicator = new BusyIndicator();
        //ObservableCollection<int> sampleData = new ObservableCollection<int>();

        public FrmJackportDemo(LoginData _data)
        {


            InitializeComponent();


            FrmLogin objLogin = new FrmLogin();
            objLogin.Hide();
            clsService = new ClsService();

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            CommonHelper.ReadXMlData();

            LoadTickets();

            //LoadEvents();

            LoadData(_data);

            ;

            this.Show();

            //  SetLayout();




        }

        //private void LoadEvents()
        //{
        //    TxtE0.KeyPress += ValidateKeyPress;
        //    TxtE2.KeyPress += ValidateKeyPress;
        //    TxtE1.KeyPress += ValidateKeyPress;
        //    TxtE3.KeyPress += ValidateKeyPress;
        //    TxtE4.KeyPress += ValidateKeyPress;
        //    TxtE5.KeyPress += ValidateKeyPress;
        //    TxtE7.KeyPress += ValidateKeyPress;
        //    TxtE8.KeyPress += ValidateKeyPress;
        //    TxtE9.KeyPress += ValidateKeyPress;
        //    Txt0009.KeyPress += ValidateKeyPress;
        //    Txt1019.KeyPress += ValidateKeyPress;
        //    Txt2029.KeyPress += ValidateKeyPress;
        //    Txt3031.KeyPress += ValidateKeyPress;
        //    Txt4049.KeyPress += ValidateKeyPress;
        //    Txt5051.KeyPress += ValidateKeyPress;
        //    Txt5051.KeyPress += ValidateKeyPress;
        //    Txt7079.KeyPress += ValidateKeyPress;
        //    Txt8089.KeyPress += ValidateKeyPress;
        //    TxtLpNo.KeyPress += ValidateKeyPress;
        //    txttotalvalue.KeyPress += ValidateKeyPress;
        //    textBox6.KeyPress += ValidateKeyPress;
        //    textBox5.KeyPress += ValidateKeyPress;
        //    Txt9099.KeyPress += ValidateKeyPress;
        //    txttickektsqty.KeyPress += ValidateKeyPress;
        //    TxtE0.KeyUp += OnKeyUp;
        //    TxtE0.KeyUp += OnKeyUp;
        //    TxtE2.KeyUp += OnKeyUp;
        //    TxtE1.KeyUp += OnKeyUp;
        //    TxtE3.KeyUp += OnKeyUp;
        //    TxtE4.KeyUp += OnKeyUp;
        //    TxtE5.KeyUp += OnKeyUp;
        //    TxtE7.KeyUp += OnKeyUp;
        //    TxtE8.KeyUp += OnKeyUp;
        //    TxtE9.KeyUp += OnKeyUp;
        //    Txt0009.KeyUp += OnKeyUp;
        //    Txt1019.KeyUp += OnKeyUp;
        //    Txt2029.KeyUp += OnKeyUp;
        //    Txt3031.KeyUp += OnKeyUp;
        //    Txt4049.KeyUp += OnKeyUp;
        //    Txt5051.KeyUp += OnKeyUp;
        //    Txt5051.KeyUp += OnKeyUp;
        //    Txt7079.KeyUp += OnKeyUp;
        //    Txt8089.KeyUp += OnKeyUp;
        //    textBox6.KeyUp += OnKeyUp;
        //    textBox5.KeyUp += OnKeyUp;
        //    Txt9099.KeyUp += OnKeyUp;

        //}



        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }

        public void FrmJackport_Load(object sender, EventArgs e)
        {

            // await LoadData();


        }



        private void SetLayout()
        {
            int height = PrintJobSettings.ToolHeight > 0 ? PrintJobSettings.ToolHeight : 40;
            int width = PrintJobSettings.ToolWidth > 0 ? PrintJobSettings.ToolWidth : 50;

            //TxtE0.Width = width; TxtE0.Height = height;
            //TxtE2.Width = width;
            //TxtE1.Width = width;
            //TxtE3.Width = width;
            //TxtE4.Width = width;
            //TxtE5.Width = width;
            //TxtE7.Width = width;
            //TxtE8.Width = width;
            //TxtE9.Width = width;
            //TxtE2.Height = height;
            //TxtE1.Height = height;
            //TxtE3.Height = height;
            //TxtE4.Height = height;
            //TxtE5.Height = height;
            //TxtE7.Height = height;
            //TxtE8.Height = height;
            //TxtE9.Height = height;
            //Txt0009.Width = width;
            //Txt1019.Width = width;
            //Txt2029.Width = width;
            //Txt3031.Width = width;
            //Txt4049.Width = width;
            //Txt5051.Width = width;
            //Txt5051.Width = width;
            //Txt7079.Width = width;
            //Txt8089.Width = width;
            //TxtLpNo.Width = width;
            //Txt0009.Height = height;
            //Txt1019.Height = height;
            //Txt2029.Height = height;
            //Txt3031.Height = height;
            //Txt4049.Height = height;
            //Txt5051.Height = height;
            //Txt5051.Height = height;
            //Txt7079.Height = height;
            //Txt8089.Height = height;
            //TxtLpNo.Height = height;
            //textBox6.Width = width;
            //textBox5.Width = width;
            //Txt9099.Width = width;
            //textBox6.Height = height;
            //textBox5.Height = height;
            //Txt9099.Height = height;
            //button7.Height = height;
            //button7.Width = width;
        }

        private void OnKeyUp(object sender, EventArgs e)
        {
            ShowTicketQty();
        }

        private void ValidateKeyPress(object sender, KeyPressEventArgs e)
        {
            // sender is the textbox the keypress happened in
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
         (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }



        }

        private void ShowTicketQty()
        {
            try
            {
                int quantity = 0;
                int total = 0;
                foreach (UserInputControl ctr in tblBids.Controls)
                {

                    if (!string.IsNullOrEmpty(ctr.TickeQty) && Convert.ToInt32(ctr.TickeQty) > 0)
                    {

                        quantity = quantity + Convert.ToInt16(ctr.TickeQty);

                    }
                }

                total = 2 * quantity;
                txttickektsqty.Text = quantity.ToString();
                txttotalvalue.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void LoadData(LoginData _data)
        {


            data = _data;
            SetLoading(true);



            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    SetAppLicationData(data);
                }));
            }
            else
            {
                SetAppLicationData(data);
            }

            SetCurrentSlot(data.TimeSlots);

            IsSloverOver = IsSlotAvailable(data.TimeSlots);

            loadWinPrizes(timeSlots);

            RunTimer();

            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    SetLoading(false);
                }));
            }
            else
            {
                SetLoading(false);
            }


        }



        private bool IsSlotAvailable(List<TimeSlot> timeSlots)
        {
            var slots = timeSlots.Where(x => x.slot_over == "0").ToList();
            if (slots.Count == 0)
            {
                return true;
            }
            else
                return false;

        }

        private void RunTimer()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();
        }


        private void SetLoading(bool displayLoader)
        {
            Loader loader = new Loader();
            if (displayLoader)
            {

                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                headerpanel.Visible = true;
                pnlFooter.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                tblLayout.Visible = true;


            }
            else
            {

                headerpanel.Visible = true;
                pnlFooter.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                tblLayout.Visible = true;

                this.Cursor = System.Windows.Forms.Cursors.Default;



            }
        }


        private void SetCurrentSlot(List<TimeSlot> Slotlist)
        {

            int flag = 0;
            try
            {
                var l = Slotlist.OrderByDescending(x => x.time_end).ToList();
                for (int i = l.Count - 1; i >= 0; i--)
                {
                    if (l[i].slot_over == "1")
                    {
                        slotdId = Convert.ToInt32(l[i - 1].slot_id).ToString();
                        endtime = l[i - 1].time_end;
                        flag = 1;

                    }


                }

                if (flag == 0)
                {
                    var ls = Slotlist.Where(x => x.slot_over == "0").ToList();
                    endtime = ls.Select(x => x.time_end).FirstOrDefault();
                    slotdId = ls.Select(x => x.slot_id).FirstOrDefault();
                }

                lblSlotTime.Text = CommonHelper.SetTimeFormat(endtime);

                var list = Slotlist.OrderByDescending(x => x.slot_id).ToList();

                list = list.Where(x => x.slot_over == "0").ToList();


                list = Slotlist.OrderBy(x => x.slot_id).ToList();

                timeSlots = null;

                timeSlots = Slotlist.Select(x => new TimeSlot
                {
                    slot_id = x.slot_id,
                    slot_over = x.slot_over,
                    time_end = x.time_end,
                    win_number = x.win_number


                }).ToList();




            }
            catch (Exception ex)
            {

            }


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
                    if (flag == 8)
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
                    break;
                }


            }



        }

        private void LoadTickets()
        {
            tblBids.Controls.Clear();

            tblBids.Visible = false;


            for (int i = 0; i < 10; i++)
            {

                for (int c = 0; c < 10; c++)
                {
                    UserInputControl p1 = new UserInputControl(this);
                    p1.Tag = i + "" + c;
                    p1.TickeName = Convert.ToString(i + "" + c);
                    p1.Dock = DockStyle.Fill;
                    p1.Margin = new Padding(3, 3, 3, 3);
                    tblBids.Controls.Add(p1, c, i);
                }


            }

            int val = 0;
            int val2 = 0;
            int tag = 0;
            for (int i = 0; i < 10; i++)
            {

                for (int c = 0; c < 2; c++)
                {
                    BidControl p1 = new BidControl(this);
                    p1.Tag = tag;
                    tag++;
                    if (c % 2 == 0)
                        p1.TickeName = Convert.ToString("E" + (c + i));

                    else
                    {
                        val = val + 9;

                        p1.TickeName = Convert.ToString(val2 + "-" + val);
                        val++;

                        val2 = val2 + 10;
                    }

                    p1.Dock = DockStyle.Fill;
                    p1.Margin = new Padding(3, 1, 3, 1);
                    p1.Tag = p1.TickeName;
                    tblbidsControl.Controls.Add(p1, c, i);
                }
            }



            tblBids.Visible = true;




        }

        void p1_OnChanged(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void SetAppLicationData(LoginData _root)
        {
            try
            {

                LblAgentId.Text = data.AgentData.agent_code;
                LblCompanyName.Text = data.ApplicationDetails.app_name;
                agentToken = data.AgentData.token;

                UserAgent.AgenToken = agentToken;
                UserAgent.AgentCode = data.AgentData.agent_code;
                lblWinRs.Text = _root.ApplicationDetails.agent_ticket_win_customer_share_amount;
                lblticketprice.Text = _root.ApplicationDetails.agent_ticket_price;
                lblprice.Text = _root.ApplicationDetails.agent_ticket_price_format;
                ticketPrice = Convert.ToInt16(_root.ApplicationDetails.agent_ticket_price);

                this.Text = _root.ApplicationDetails.app_name + "  " + " Licence Expiry  " + data.LicenseData.license_end_date;

                appTime = Convert.ToDateTime(_root.ApplicationDetails.app_time.ToString());
                LblDate.Text = CommonHelper.SetDateFormat(_root.ApplicationDetails.app_date.ToString());
                UserAgent.AppName = data.ApplicationDetails.app_name;
                UserAgent.ShowBalance = Convert.ToInt64(data.AgentData.balance);
                UserAgent.Logo = _root.ApplicationDetails.app_logo;
                UserAgent.AppSignature = _root.ApplicationDetails.app_company_signature;
                UserAgent.RS = _root.ApplicationDetails.agent_ticket_price;
                UserAgent.CompanyName = _root.ApplicationDetails.app_company_name;
                UserAgent.PrinFooter = _root.ApplicationDetails.app_company_name_footer;

                var request = WebRequest.Create(_root.ApplicationDetails.app_logo);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pictureBox1.Image = Bitmap.FromStream(stream);

                }

                cmbSlot.SelectedIndex = 0;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task loadWinPrizes(List<TimeSlot> timeSlotList)
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
                Time = CommonHelper.SetTimeFormat(x.time_end).ToString(),

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

        private async Task BuyTickets()
        {
            try

            {
                bidList.Clear();
                int flag = 0;
                GetSlots();
                foreach (UserInputControl ctr in tblBids.Controls)
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
                    List<TimeSlotList> tickets = new List<TimeSlotList>();

                    tickets = clsService.PurchaseSingleTicketAsync(agentToken, bidList, plist);

                    ClearBoard();

                    foreach (TimeSlotList ticket in tickets)
                    {

                        await PrintJobHelper.Print(ticket);


                    }


                    cmbSlot.SelectedIndex = 0;

                }
                else
                {
                    MessageBox.Show("Please select ticket first");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            foreach (UserInputControl ctr in tblBids.Controls)
            {
                ctr.TickeQty = "";


            }
            foreach (BidControl ctr in tblbidsControl.Controls)
            {
                ctr.TickeQty = "";


            }

            txttickektsqty.Text = txttotalvalue.Text = "0";

        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
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

                var remainintime = DateTime.Compare(Convert.ToDateTime(endtime), appTime);

                if (IsSloverOver == false)
                {

                    if (remainintime == -1)
                    {
                        LblCountDown1.Text = "00:00:00";
                        LblCountDown1.Text = "00:00:00";

                        List<TimeSlot> timeSlot = await RefreshSlots();

                        IsSloverOver = IsSlotAvailable(timeSlot);

                        SetCurrentSlot(timeSlot);

                        await loadWinPrizes(timeSlot);
                    }
                    else
                    {
                        LblCountDown1.Text = leftTime.ToString();
                    }

                    if (remainintime == 0)
                    {
                        var winticket = new WinTicket();
                        ClsService clsService = new ClsService();
                        winticket = clsService.GetWinTickets(Convert.ToInt16(slotdId));

                        List<TimeSlot> timeSlot = await RefreshSlots();

                        IsSloverOver = IsSlotAvailable(timeSlot);

                        SetCurrentSlot(timeSlot);

                        await loadWinPrizes(timeSlot);

                        FrmWinPrice ObjWinPrice = new FrmWinPrice(winticket.win_number, winticket.time_end);
                        ObjWinPrice.ShowDialog();



                    }
                }
                else
                {
                    LblCountDown1.Text = "00:00:00";

                    List<TimeSlot> timeSlot = await RefreshSlots();

                    IsSloverOver = IsSlotAvailable(timeSlot);



                    SetCurrentSlot(timeSlot);

                    if (IsSloverOver == false)
                        await loadWinPrizes(timeSlot);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


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






        private async Task<List<TimeSlot>> RefreshSlots()
        {


            List<TimeSlot> timeSlots = await clsService.GetUpdatedSlots();

            return timeSlots;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            PurchaseTickets();
            LblBalance.Text = UserAgent.ShowBalance.ToString();

        }

        private void PurchaseTickets()
        {
            List<PurchasedTickets> purchasetikcet = new List<PurchasedTickets>();
            purchasetikcet = clsService.GetTodaysPurchasedTickets(agentToken);
            if (purchasetikcet != null && purchasetikcet.Count > 0)
            {
                FrmBarcode ObjFrmBarcode = new FrmBarcode(purchasetikcet);
                ObjFrmBarcode.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Data");
            }
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


            if (cmbSlot.Text.Trim() == "CURRENT")
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
            // GenerateRondomTicketNumber();



        }



        private void GenerateRondomTicketNumber()
        {
            try
            {

                if (TxtLpNo.Text != "")
                {
                    Random rnd = new Random();
                    int n = Convert.ToInt32(TxtLpNo.Text);
                    string[] intArr = new string[n];
                    int i = 0;
                    for (i = 0; i < intArr.Length; i++)
                    {
                        int num = rnd.Next(0, 100);
                        string number = "";
                        if (num.ToString().Length == 1)
                        {
                            number = "0" + num;

                            intArr[i] = number;
                        }
                        else
                        {
                            intArr[i] = num.ToString();
                        }


                    }

                    Array.Sort(intArr);
                    for (int j = 0; j < intArr.Length; j++)
                    {
                        foreach (UserInputControl ctr in tblBids.Controls)
                        {
                            string Data = Convert.ToString(ctr.Tag);


                            if (Data == Convert.ToString(intArr[j]))
                            {
                                int qty = !string.IsNullOrEmpty(ctr.TickeQty) ? Convert.ToInt16(ctr.TickeQty) + 1 : 1;
                                if (qty <= 99)
                                    ctr.TickeQty = qty.ToString();
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
            //GenerateLpNumber();
            ShowTicketQty();
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
            //if (e.KeyCode == Keys.M)
            //{
            //    ClearBoard();
            //}
            //if (e.KeyCode == Keys.T)
            //{
            //    PurchaseTickets();
            //}
            if (e.KeyCode == Keys.F12)
            {
                BuyTickets();
            }

            if (e.KeyCode == Keys.F11)
            {
                if (!IsFullScreen)
                {

                    this.WindowState = FormWindowState.Normal;
                    // this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    IsFullScreen = true;
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                    // this.FormBorderStyle = FormBorderStyle.Fixed3D;
                    this.WindowState = FormWindowState.Maximized;
                    IsFullScreen = false;
                }

            }
            if (e.KeyCode == Keys.Escape)
            {

                if (ShowDialog())
                {
                    timer1.Stop();
                    this.Hide();
                }

            }
            //if (e.KeyCode == Keys.R)
            //{
            //    AllData();
            //}
            //if (e.KeyCode == Keys.S)
            //{
            //    GetReportSummary();
            //}


        }
        public bool ShowDialog()
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Do you want to exit",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = "Do yo want to exit" };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? true : false;
        }

        private void flowLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {


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
            TicketDetail ticket = new TicketDetail();
            ticket = clsservice.ClaimTicket(UserAgent.AgenToken, barcode);
            if (ticket != null)
            {
                this.Hide();
                MessageBox.Show("Ticket Claim Successfully");
                PrintJobHelper.PrintClaimedTicket(ticket);
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



        private void linkbalance_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //FrmAgentBalance obj = new FrmAgentBalance(UserAgent.ShowBalance.ToString());
            LblBalance.Text = UserAgent.ShowBalance.ToString();
            if (LblBalance.Visible)
            {
                LblBalance.Visible = false;
                linkbalance.Text = "Show Balance";
            }
            else
            {
                LblBalance.Visible = true;
                linkbalance.Text = "Hide Balance";
            }
            //  obj.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Txt0009_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            GameBoardV1 obj = new GameBoardV1();
            this.Hide();
            obj.Show();

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void LblCountDown1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {

        }

        private void button4_Click_3(object sender, EventArgs e)
        {
            FrmSetting setting = new FrmSetting();
            setting.ShowDialog();
        }

        private void FrmJackportDemo_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();

        }

        private void FrmJackportDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CommonHelper.ReadXMlData();

            LoadTickets();

            SetLayout();


        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tblControls_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlFooter_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
