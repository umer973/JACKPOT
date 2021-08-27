using Jackport.DataModel;
using Jackport.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;

using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jackport.Helper
{
    public static class PrintJobHelper
    {
        private static TimeSlotList _ticket;
        private static BidDetail _bids;
        private static CancelledTicket cticket;
        private static ReportSummary _report;
        private static PrintDocument printDocument;
        private static TicketDetail _claimedticket;
        private static Graphics graphics;
        private static Image Logo;
        private static PrintPreviewDialog p = new PrintPreviewDialog();


        private static int InitialHeight = 360;

        //static PrintJobHelper()
        //{
        //    CommonHelper.ReadXMlData();
        //    AdjustHeight();
        //    //printDocument = new PrintDocument();
        //    printDocument.PrinterSettings.PrinterName = PrintJobSettings.PrinterName;


        //}


        #region :: Print Formating

        public static void DrawAtStart(string text, int Offset)
        {
            int startX = 10;
            int startY = 5;
            System.Drawing.Font minifont = new Font("Arial", 5);

            graphics.DrawString(text, minifont,
                     new SolidBrush(Color.Black), startX + 5, startY + Offset);
        }
        public static void InsertItem(string key, string value, int Offset)
        {
            Font minifont = new Font("Arial", 5);
            int startX = 10;
            int startY = 5;

            graphics.DrawString(key, minifont,
                         new SolidBrush(Color.Black), startX + 5, startY + Offset);

            graphics.DrawString(value, minifont,
                     new SolidBrush(Color.Black), startX + 130, startY + Offset);
        }
        public static void InsertHeaderStyleItem(string key, string value, int Offset)
        {
            int startX = 10;
            int startY = 5;
            Font itemfont = new Font("Arial", 6, FontStyle.Bold);

            graphics.DrawString(key, itemfont,
                         new SolidBrush(Color.Black), startX + 5, startY + Offset);

            graphics.DrawString(value, itemfont,
                     new SolidBrush(Color.Black), startX + 130, startY + Offset);
        }
        public static void DrawLine(string text, Font font, int Offset, int xOffset)
        {
            int startX = 10;
            int startY = 5;
            graphics.DrawString(text, font,
                     new SolidBrush(Color.Black), startX + xOffset, startY + Offset);
        }
        public static void DrawSimpleString(string text, Font font, int Offset, int xOffset)
        {
            int startX = 10;
            int startY = 5;
            graphics.DrawString(text, font,
                     new SolidBrush(Color.Black), startX + xOffset, startY + Offset);
        }

        #endregion

        #region :: Public Methods

        private static void AdjustHeight()
        {
            //var capacity = 5 * order.ItemTransactions.Capacity;
            //InitialHeight += capacity;

            //capacity = 5 * order.DealTransactions.Capacity;
            //InitialHeight += capacity;
        }

        public async static Task Print(TimeSlotList ticket)
        {
            printDocument = new PrintDocument();
            CommonHelper.ReadXMlData();
            printDocument.PrinterSettings.PrinterName = PrintJobSettings.PrinterName;
            _ticket = ticket;

            printDocument.PrintPage += new PrintPageEventHandler(PrintTicket);
            printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize(PrintJobSettings.PaperSize, PrintJobSettings.Width, PrintJobSettings.Height);
            p.Document = printDocument;


            if (PrintJobSettings.IsDirectPrint)
            {
                printDocument.Print();
            }
            else

            {
                p.ShowDialog();
            }

        }

        public async static Task ReprintPrint(BidDetail ticket)
        {
            printDocument = new PrintDocument();
            CommonHelper.ReadXMlData();
            printDocument.PrinterSettings.PrinterName = PrintJobSettings.PrinterName;
            _bids = ticket;

            printDocument.PrintPage += new PrintPageEventHandler(RePrintTicket);
            printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize(PrintJobSettings.PaperSize, PrintJobSettings.Width, PrintJobSettings.Height);
            p.Document = printDocument;

            if (PrintJobSettings.IsDirectPrint)
            {
                printDocument.Print();
            }
            else

            {
                p.ShowDialog();
            }


            printDocument.Dispose();

        }

        public async static Task PrintCancelledTicket(CancelledTicket ticket)
        {
            printDocument = new PrintDocument();
            CommonHelper.ReadXMlData();
            printDocument.PrinterSettings.PrinterName = PrintJobSettings.PrinterName;

            cticket = ticket;
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintCancelledTicket);
            PrintPreviewDialog p = new PrintPreviewDialog();
            printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize(PrintJobSettings.PaperSize, PrintJobSettings.Width, PrintJobSettings.Height);

            p.Document = printDocument;


            if (PrintJobSettings.IsDirectPrint)
            {
                printDocument.Print();
            }
            else

            {
                p.ShowDialog();
            }




        }

        public async static Task PrintClaimedTicket(TicketDetail ticket)
        {

            printDocument = new PrintDocument();
            CommonHelper.ReadXMlData();
            printDocument.PrinterSettings.PrinterName = PrintJobSettings.PrinterName;
            _claimedticket = ticket;

            printDocument.PrintPage += new PrintPageEventHandler(PrintClaimedTicket);
            PrintPreviewDialog p = new PrintPreviewDialog();
            printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize(PrintJobSettings.PaperSize, PrintJobSettings.Width, PrintJobSettings.Height);

            p.Document = printDocument;


            if (PrintJobSettings.IsDirectPrint)
            {
                printDocument.Print();
            }
            else

            {
                p.ShowDialog();
            }




        }

        public static void PrintReportSummary(ReportSummary report)
        {
            printDocument = new PrintDocument();
            CommonHelper.ReadXMlData();
            printDocument.PrinterSettings.PrinterName = PrintJobSettings.PrinterName;
            _report = report;

            printDocument.PrintPage += new PrintPageEventHandler(PrintReportSummary);
            PrintPreviewDialog p = new PrintPreviewDialog();
            printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize(PrintJobSettings.PaperSize, PrintJobSettings.Width, PrintJobSettings.Height);

            p.Document = printDocument;


            if (PrintJobSettings.IsDirectPrint)
            {
                printDocument.Print();
            }
            else

            {
                p.ShowDialog();
            }




        }

        #endregion

        #region :: Private Methods



        private static void PrintTicket(object sender, PrintPageEventArgs e)
        {
            graphics = e.Graphics;
            Font minifont = new Font("Arial", 5);
            Font itemfont = new Font("Arial", 6);
            Font smallfont = new Font("Arial", 8);
            Font mediumfont = new Font("Arial", 10);
            Font largefont = new Font("Arial", 12);
            int Offset = 10;
            int smallinc = 10, mediuminc = 12, largeinc = 15;



            Offset = Offset + largeinc + 10;

            String underLine = "-------------------------------------";
            //DrawLine(underLine, largefont, Offset, 0);

            //Offset = Offset + mediuminc;
            InsertHeaderStyleItem(_ticket.agent_code + "   " + _ticket.ticket_barcode, "", Offset);

            //InsertItem("BARCODE     :  " + _ticket.ticket_barcode, "", Offset);

            Offset = Offset + mediuminc + 10;

            Image image = GetImage();
            e.Graphics.DrawImage(image, 5, 5 + Offset, 50, 30);
            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("                      " + UserAgent.CompanyName, "", Offset);
            Offset = Offset + largeinc + 10;
            InsertHeaderStyleItem("JACKPOT STARTDIGIT Rs." + UserAgent.RS, "", Offset);

            Offset = Offset + mediuminc + 5;
            InsertHeaderStyleItem("Date : " + SetDDMMYYFormat(_ticket.date_slot) + "  Time :  " + CommonHelper.SetTimeFormat(_ticket.time_end).ToString(), "", Offset);

            int total = 0;
            string bids = string.Empty;
            int count = _ticket.bids.Count;

            Offset = Offset + 5;

            for (int i = 0; i < _ticket.bids.Count;)
            {
                if (count >= 5)
                {
                    bids = string.Empty;
                    for (int j = 0; j <= 4; j++)
                    {
                        string space = "";

                        if (_ticket.bids[i].number.ToString().Length == 1 && _ticket.bids[i].quantity.ToString().Length == 1)
                        {
                            bids = bids + "  " + _ticket.bids[i].number.ToString() + " - " + _ticket.bids[i].quantity.ToString() + "     ";
                        }

                        else if (_ticket.bids[i].number.ToString().Length == 1 && _ticket.bids[i].quantity.ToString().Length != 1)
                        {
                            bids = bids + "  " + _ticket.bids[i].number.ToString() + " - " + _ticket.bids[i].quantity.ToString() + "   ";

                        }
                        else if (_ticket.bids[i].number.ToString().Length != 1 && _ticket.bids[i].quantity.ToString().Length == 1)
                        {
                            bids = bids + _ticket.bids[i].number.ToString() + " - " + _ticket.bids[i].quantity.ToString() + "     ";
                        }
                        else if (_ticket.bids[i].number.ToString().Length != 1 && _ticket.bids[i].quantity.ToString().Length != 1)
                        {
                            bids = bids + _ticket.bids[i].number.ToString() + " - " + _ticket.bids[i].quantity.ToString() + "   ";
                        }


                        bids = bids + space;




                        total = total + Convert.ToInt16(_ticket.bids[i].quantity);
                        i++;
                        count--;
                    }

                }
                else if (count >= 4)
                {
                    bids = "";
                    for (int j = 0; j <= 3; j++)
                    {


                        string space = "";

                        if (_ticket.bids[i].number.ToString().Length == 1 && _ticket.bids[i].quantity.ToString().Length == 1)
                        {
                            bids = bids + "  " + _ticket.bids[i].number.ToString() + " - " + _ticket.bids[i].quantity.ToString() + "     ";
                        }

                        else if (_ticket.bids[i].number.ToString().Length == 1 && _ticket.bids[i].quantity.ToString().Length != 1)
                        {
                            bids = bids + "  " + _ticket.bids[i].number.ToString() + " - " + _ticket.bids[i].quantity.ToString() + "   ";

                        }
                        else if (_ticket.bids[i].number.ToString().Length != 1 && _ticket.bids[i].quantity.ToString().Length == 1)
                        {
                            bids = bids + _ticket.bids[i].number.ToString() + " - " + _ticket.bids[i].quantity.ToString() + "     ";
                        }
                        else if (_ticket.bids[i].number.ToString().Length != 1 && _ticket.bids[i].quantity.ToString().Length != 1)
                        {
                            bids = bids + _ticket.bids[i].number.ToString() + " - " + _ticket.bids[i].quantity.ToString() + "   ";
                        }

                        bids = bids + space;

                        total = total + Convert.ToInt16(_ticket.bids[i].quantity);
                        i++;
                        count--;

                    }

                }
                else if (count >= 3)
                {
                    bids = "";
                    for (int j = 0; j <= 2; j++)
                    {

                        string space = "";

                        if (_ticket.bids[i].number.ToString().Length == 1 && _ticket.bids[i].quantity.ToString().Length == 1)
                        {
                            bids = bids + "  " + _ticket.bids[i].number.ToString() + " - " + _ticket.bids[i].quantity.ToString() + "     ";
                        }

                        else if (_ticket.bids[i].number.ToString().Length == 1 && _ticket.bids[i].quantity.ToString().Length != 1)
                        {
                            bids = bids + "  " + _ticket.bids[i].number.ToString() + " - " + _ticket.bids[i].quantity.ToString() + "   ";

                        }
                        else if (_ticket.bids[i].number.ToString().Length != 1 && _ticket.bids[i].quantity.ToString().Length == 1)
                        {
                            bids = bids + _ticket.bids[i].number.ToString() + " - " + _ticket.bids[i].quantity.ToString() + "     ";
                        }
                        else if (_ticket.bids[i].number.ToString().Length != 1 && _ticket.bids[i].quantity.ToString().Length != 1)
                        {
                            bids = bids + _ticket.bids[i].number.ToString() + " - " + _ticket.bids[i].quantity.ToString() + "   ";
                        }

                        bids = bids + space;

                        total = total + Convert.ToInt16(_ticket.bids[i].quantity);
                        i++;
                        count--;
                    }

                }


                else if (count >= 2)
                {
                    bids = "";
                    for (int j = 0; j <= 1; j++)
                    {

                        string space = "";

                        if (_ticket.bids[i].number.ToString().Length == 1 && _ticket.bids[i].quantity.ToString().Length == 1)
                        {
                            bids = bids + "  " + _ticket.bids[i].number.ToString() + " - " + _ticket.bids[i].quantity.ToString() + "     ";
                        }

                        else if (_ticket.bids[i].number.ToString().Length == 1 && _ticket.bids[i].quantity.ToString().Length != 1)
                        {
                            bids = bids + "  " + _ticket.bids[i].number.ToString() + " - " + _ticket.bids[i].quantity.ToString() + "   ";

                        }
                        else if (_ticket.bids[i].number.ToString().Length != 1 && _ticket.bids[i].quantity.ToString().Length == 1)
                        {
                            bids = bids + _ticket.bids[i].number.ToString() + " - " + _ticket.bids[i].quantity.ToString() + "     ";
                        }
                        else if (_ticket.bids[i].number.ToString().Length != 1 && _ticket.bids[i].quantity.ToString().Length != 1)
                        {
                            bids = bids + _ticket.bids[i].number.ToString() + " - " + _ticket.bids[i].quantity.ToString() + "   ";
                        }

                        bids = bids + space;

                        total = total + Convert.ToInt16(_ticket.bids[i].quantity);
                        i++;
                        count--;
                    }

                }
                else if (count >= 1)
                {

                    bids = "";
                    bids = bids + _ticket.bids[i].number.ToString() + " - " + _ticket.bids[i].quantity.ToString() + " ";

                    total = total + Convert.ToInt16(_ticket.bids[i].quantity);
                    i++;
                    count--;


                }


                Offset = Offset + mediuminc;
                InsertHeaderStyleItem(bids, "", Offset);
                //DrawAtStart(bids, Offset);
            }

            Offset = Offset + mediuminc + 5;

            InsertHeaderStyleItem("Qty: " + total + " Rs." + total * 2 + "  " + CommonHelper.SetTimeFormat(_ticket.time_end).ToString(), "", Offset);

            Offset = Offset + mediuminc + 10;

            Image image1 = GetSignImage();
            e.Graphics.DrawImage(image1, 12, Offset, 40, 30);

            Offset = Offset + 5;

            InsertHeaderStyleItem("                       " + UserAgent.PrinFooter, "", Offset);

        }

        private static Image GetSignImage()
        {
            var request = WebRequest.Create(UserAgent.AppSignature);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                return Bitmap.FromStream(stream);

            }
        }

        private static Image GetImage()
        {
            var request = WebRequest.Create(UserAgent.Logo);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                return Bitmap.FromStream(stream);

            }
        }
        private static void RePrintTicket(object sender, PrintPageEventArgs e)
        {
            try
            {
                graphics = e.Graphics;
                Font minifont = new Font("Arial", 5);
                Font itemfont = new Font("Arial", 6);
                Font smallfont = new Font("Arial", 8);
                Font mediumfont = new Font("Arial", 10);
                Font largefont = new Font("Arial", 12);
                int Offset = 10;
                int smallinc = 10, mediuminc = 12, largeinc = 15;



                Offset = Offset + mediuminc;

                String underLine = "-------------------------------------";
                //DrawLine(underLine, largefont, Offset, 0);

                //Offset = Offset + mediuminc;
                InsertHeaderStyleItem(_bids.agent_code + "   " + _bids.ticket_barcode, "", Offset);

                Offset = Offset + mediuminc + 10;
                //InsertItem("BARCODE     :  " + _ticket.ticket_barcode, "", Offset);

                Image image = GetImage();
                e.Graphics.DrawImage(image, 5, 5 + Offset, 50, 30);
                Offset = Offset + mediuminc;
                InsertHeaderStyleItem("                   " + UserAgent.CompanyName, "", Offset);
                Offset = Offset + largeinc + 10;
                //InsertItem("JACKPOT", "", Offset);
                InsertHeaderStyleItem("JACKPOT STARTDIGIT Rs." + UserAgent.RS, "", Offset);


                // DrawSimpleString("JACKPOT", minifont, Offset, 15);

                Offset = Offset + mediuminc + 5;

                string exactdate = SetDDMMYYFormat(_bids.ticket_taken_time);

                InsertHeaderStyleItem("Date : " + exactdate + "  Time :  " + CommonHelper.GetdateFormat(_bids.ticket_end_time).ToString(), "", Offset);

                Offset = Offset + 5;


                int total = 0;
                string bids = string.Empty;
                int count = _bids.bids.Count;

                for (int i = 0; i < _bids.bids.Count;)
                {
                    if (count >= 5)
                    {
                        bids = "";
                        for (int j = 0; j <= 4; j++)
                        {




                            string space = "";
                            bool single = false;


                            if (_bids.bids[i].bid_number.ToString().Length == 1 && _bids.bids[i].bid_quantity.ToString().Length == 1)
                            {
                                bids = bids + "  " + _bids.bids[i].bid_number.ToString() + " - " + _bids.bids[i].bid_quantity.ToString() + "     ";
                            }

                            else if (_bids.bids[i].bid_number.ToString().Length == 1 && _bids.bids[i].bid_quantity.ToString().Length != 1)
                            {
                                bids = bids + "  " + _bids.bids[i].bid_number.ToString() + " - " + _bids.bids[i].bid_quantity.ToString() + "   ";

                            }
                            else if (_bids.bids[i].bid_number.ToString().Length != 1 && _bids.bids[i].bid_quantity.ToString().Length == 1)
                            {
                                bids = bids + _bids.bids[i].bid_number.ToString() + " - " + _bids.bids[i].bid_quantity.ToString() + "     ";
                            }
                            else if (_bids.bids[i].bid_number.ToString().Length != 1 && _bids.bids[i].bid_quantity.ToString().Length != 1)
                            {
                                bids = bids + _bids.bids[i].bid_number.ToString() + " - " + _bids.bids[i].bid_quantity.ToString() + "   ";
                            }


                            bids = bids + space;

                            total = total + Convert.ToInt16(_bids.bids[i].bid_quantity);
                            i++;
                            count--;
                        }

                    }
                    else if (count >= 4)
                    {
                        bids = "";
                        for (int j = 0; j <= 3; j++)
                        {


                            bids = bids + _bids.bids[i].bid_number.ToString() + " - " + _bids.bids[i].bid_quantity.ToString() + "  ";

                            total = total + Convert.ToInt16(_bids.bids[i].bid_quantity);
                            i++;
                            count--;
                        }

                    }
                    else if (count >= 3)
                    {
                        bids = "";
                        for (int j = 0; j <= 2; j++)
                        {


                            bids = bids + _bids.bids[i].bid_number.ToString() + " - " + _bids.bids[i].bid_quantity.ToString() + "  ";

                            total = total + Convert.ToInt16(_bids.bids[i].bid_quantity);
                            i++;
                            count--;
                        }

                    }
                    else if (count >= 2)
                    {
                        bids = "";
                        for (int j = 0; j <= 1; j++)
                        {


                            bids = bids + _bids.bids[i].bid_number.ToString() + " - " + _bids.bids[i].bid_quantity.ToString() + "  ";

                            total = total + Convert.ToInt16(_bids.bids[i].bid_quantity);
                            i++;
                            count--;
                        }

                    }

                    else if (count >= 1)
                    {
                        bids = "";
                        bids = _bids.bids[i].bid_number.ToString() + " - " + _bids.bids[i].bid_quantity.ToString() + "  ";

                        total = total + Convert.ToInt16(_bids.bids[i].bid_quantity);
                        i++;
                        count--;

                    }


                    Offset = Offset + mediuminc;
                    InsertHeaderStyleItem(bids, "", Offset);




                }

                Offset = Offset + largeinc;

                InsertHeaderStyleItem("Qty: " + total + " Rs." + total * 2 + "  " + CommonHelper.GetdateFormat(_bids.ticket_end_time).ToString(), "", Offset);

                Offset = Offset + mediuminc + 10;

                Image image1 = GetSignImage();
                e.Graphics.DrawImage(image1, 12, Offset, 40, 30);

                Offset = Offset + 5;

                InsertHeaderStyleItem("                       " + UserAgent.PrinFooter, "", Offset);

                //graphics.DrawString("Welcome to HOT AND CRISPY", smallfont,
                //new SolidBrush(Color.Black), startX + 22, startY + Offset);


                //  Offset = Offset + mediuminc;



                //  DrawAtStart("Date: " + "11-09-21", Offset);

                // DrawAtStart("Time: " + "9:00 PM", Offset);

                /// Offset = Offset + mediuminc;

                //DrawAtStart("Qty : " + "10", Offset);

                // DrawAtStart("Rs: " + "2", Offset);


                //  DrawAtStart("Time: " + "9:00 PM", Offset);


                Offset = Offset + mediuminc;
                // underLine = "-------------------------";
                //  DrawLine(underLine, largefont, Offset, 30);

                // Offset = Offset + largeinc;

                // InsertHeaderStyleItem("Name. ", "Price. ", Offset);

                //Offset = Offset + largeinc;
                //foreach (var itran in order.ItemTransactions)
                //{
                //    InsertItem(itran.Item.Name + " x " + itran.Quantity, itran.Total.CValue, Offset);
                //    Offset = Offset + smallinc;
                //}
                //foreach (var dtran in order.DealTransactions)
                //{
                //    InsertItem(dtran.Deal.Name, dtran.Total.CValue, Offset);
                //    Offset = Offset + smallinc;

                //    foreach (var di in dtran.Deal.DealItems)
                //    {
                //        InsertItem(di.Item.Name + " x " + (dtran.Quantity * di.Quantity), "", Offset);
                //        Offset = Offset + smallinc;
                //    }
                //}

                //underLine = "-------------------------";
                //DrawLine(underLine, largefont, Offset, 30);

                //Offset = Offset + largeinc;
                //InsertItem(" Net. Total: ", order.Total.CValue, Offset);

                //if (!order.Cash.Discount.IsZero())
                //{
                //    Offset = Offset + smallinc;
                //    InsertItem(" Discount: ", order.Cash.Discount.CValue, Offset);
                //}

                //Offset = Offset + smallinc;
                //InsertHeaderStyleItem(" Amount Payable: ", order.GrossTotal.CValue, Offset);

                //Offset = Offset + largeinc;
                //String address = shop.Address;
                //DrawSimpleString("Address: " + address, minifont, Offset, 15);

                //Offset = Offset + smallinc;
                //String number = "Tel: " + shop.Phone1 + " - OR - " + shop.Phone2;
                //DrawSimpleString(number, minifont, Offset, 35);

                //Offset = Offset + 7;
                //underLine = "-------------------------------------";
                //DrawLine(underLine, largefont, Offset, 0);

                //Offset = Offset + mediuminc;
                //String greetings = "Thanks for visiting us.";
                //DrawSimpleString(greetings, mediumfont, Offset, 28);

                //Offset = Offset + mediuminc;
                //underLine = "-------------------------------------";
                //DrawLine(underLine, largefont, Offset, 0);

                //Offset += (2 * mediuminc);
                //string tip = "TIP: -----------------------------";
                //InsertItem(tip, "", Offset);

                //Offset = Offset + largeinc;
                //string DrawnBy = "Meganos Softwares: 0312-0459491 - OR - 0321-6228321";
                //DrawSimpleString(DrawnBy, minifont, Offset, 15);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static string SetDDMMYYFormat(string datetime)
        {
            var date = datetime.Split(' ');
            var dateformat = date[0].Split('-');
            return dateformat[2] + "-" + dateformat[1] + "-" + dateformat[0];
        }

        private static void PrintCancelledTicket(object sender, PrintPageEventArgs e)
        {
            graphics = e.Graphics;
            Font minifont = new Font("Arial", 5);
            Font itemfont = new Font("Arial", 6);
            Font smallfont = new Font("Arial", 8);
            Font mediumfont = new Font("Arial", 10);
            Font largefont = new Font("Arial", 12);
            int Offset = 10;
            int smallinc = 10, mediuminc = 12, largeinc = 15;

            String underLine = "--------------------------------------------";
            DrawLine(underLine, mediumfont, Offset, 0);

            Offset = Offset + largeinc;

            InsertHeaderStyleItem("Terminal ID:", cticket.agent_code, Offset);

            Offset = Offset + mediuminc;

            InsertHeaderStyleItem("Barcode No:", cticket.ticket_barcode, Offset);

            Offset = Offset + mediuminc;

            InsertHeaderStyleItem("Cancelled Amt:", cticket.ticket_total_amount, Offset);


            Offset = Offset + mediuminc;

            InsertHeaderStyleItem("Cancelled At:", SetDDMMYYFormat(cticket.ticket_cancel_time) + " " + CommonHelper.SetTimeFormat(cticket.ticket_cancel_time.Split(' ')[1]), Offset);


            //graphics.DrawString("Welcome to HOT AND CRISPY", smallfont,
            //new SolidBrush(Color.Black), startX + 22, startY + Offset);


            //  Offset = Offset + mediuminc;

            //  DrawAtStart("Date: " + "11-09-21", Offset);

            // DrawAtStart("Time: " + "9:00 PM", Offset);

            /// Offset = Offset + mediuminc;

            //DrawAtStart("Qty : " + "10", Offset);

            // DrawAtStart("Rs: " + "2", Offset);


            //  DrawAtStart("Time: " + "9:00 PM", Offset);


            Offset = Offset + mediuminc;
            // underLine = "-------------------------";
            //  DrawLine(underLine, largefont, Offset, 30);

            // Offset = Offset + largeinc;

            // InsertHeaderStyleItem("Name. ", "Price. ", Offset);

            //Offset = Offset + largeinc;
            //foreach (var itran in order.ItemTransactions)
            //{
            //    InsertItem(itran.Item.Name + " x " + itran.Quantity, itran.Total.CValue, Offset);
            //    Offset = Offset + smallinc;
            //}
            //foreach (var dtran in order.DealTransactions)
            //{
            //    InsertItem(dtran.Deal.Name, dtran.Total.CValue, Offset);
            //    Offset = Offset + smallinc;

            //    foreach (var di in dtran.Deal.DealItems)
            //    {
            //        InsertItem(di.Item.Name + " x " + (dtran.Quantity * di.Quantity), "", Offset);
            //        Offset = Offset + smallinc;
            //    }
            //}

            //underLine = "-------------------------";
            //DrawLine(underLine, largefont, Offset, 30);

            //Offset = Offset + largeinc;
            //InsertItem(" Net. Total: ", order.Total.CValue, Offset);

            //if (!order.Cash.Discount.IsZero())
            //{
            //    Offset = Offset + smallinc;
            //    InsertItem(" Discount: ", order.Cash.Discount.CValue, Offset);
            //}

            //Offset = Offset + smallinc;
            //InsertHeaderStyleItem(" Amount Payable: ", order.GrossTotal.CValue, Offset);

            //Offset = Offset + largeinc;
            //String address = shop.Address;
            //DrawSimpleString("Address: " + address, minifont, Offset, 15);

            //Offset = Offset + smallinc;
            //String number = "Tel: " + shop.Phone1 + " - OR - " + shop.Phone2;
            //DrawSimpleString(number, minifont, Offset, 35);

            //Offset = Offset + 7;
            //underLine = "-------------------------------------";
            //DrawLine(underLine, largefont, Offset, 0);

            //Offset = Offset + mediuminc;
            //String greetings = "Thanks for visiting us.";
            //DrawSimpleString(greetings, mediumfont, Offset, 28);

            //Offset = Offset + mediuminc;
            //underLine = "-------------------------------------";
            //DrawLine(underLine, largefont, Offset, 0);

            //Offset += (2 * mediuminc);
            //string tip = "TIP: -----------------------------";
            //InsertItem(tip, "", Offset);

            //Offset = Offset + largeinc;
            //string DrawnBy = "Meganos Softwares: 0312-0459491 - OR - 0321-6228321";
            //DrawSimpleString(DrawnBy, minifont, Offset, 15);
        }

        private static void PrintClaimedTicket(object sender, PrintPageEventArgs e)
        {
            graphics = e.Graphics;
            Font minifont = new Font("Arial", 5);
            Font itemfont = new Font("Arial", 6);
            Font smallfont = new Font("Arial", 8);
            Font mediumfont = new Font("Arial", 10);
            Font largefont = new Font("Arial", 12);
            int Offset = 10;
            int smallinc = 10, mediuminc = 12, largeinc = 15;

            String underLine = "---------------------------------------------------";
            DrawLine(underLine, mediumfont, Offset, 0);

            Offset = Offset + largeinc;

            InsertHeaderStyleItem("Terminal ID:", _claimedticket.ticket_agent_code, Offset);

            Offset = Offset + mediuminc;

            InsertHeaderStyleItem("Barcode No:", _claimedticket.ticket_barcode, Offset);

            Offset = Offset + mediuminc;

            InsertHeaderStyleItem("Claimed Amt:", _claimedticket.ticket_win_customer.ToString(), Offset);

            string date = SetDDMMYYFormat(_claimedticket.ticket_purchase_time);
            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("Claimed Time:", date, Offset);

            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("Win No:", _claimedticket.ticket_bid_number, Offset);

            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("Qty:", _claimedticket.ticket_purchase_quantity, Offset);


            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("Price:", _claimedticket.ticket_purchase_price, Offset);

            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("Total:", _claimedticket.ticket_purchase_amount, Offset);

            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("Result End Time:", CommonHelper.SetTimeFormat(_claimedticket.ticket_slot_end_time), Offset);

            Offset = Offset + largeinc;
            DrawLine(underLine, mediumfont, Offset, 0);



            Offset = Offset + largeinc;


            DrawSimpleString("JACKPOT", largefont, Offset, 28);

            //graphics.DrawString("Welcome to HOT AND CRISPY", smallfont,
            //new SolidBrush(Color.Black), startX + 22, startY + Offset);


            //  Offset = Offset + mediuminc;

            //  DrawAtStart("Date: " + "11-09-21", Offset);

            // DrawAtStart("Time: " + "9:00 PM", Offset);

            /// Offset = Offset + mediuminc;

            //DrawAtStart("Qty : " + "10", Offset);

            // DrawAtStart("Rs: " + "2", Offset);


            //  DrawAtStart("Time: " + "9:00 PM", Offset);


            Offset = Offset + mediuminc;
            // underLine = "-------------------------";
            //  DrawLine(underLine, largefont, Offset, 30);

            // Offset = Offset + largeinc;

            // InsertHeaderStyleItem("Name. ", "Price. ", Offset);

            //Offset = Offset + largeinc;
            //foreach (var itran in order.ItemTransactions)
            //{
            //    InsertItem(itran.Item.Name + " x " + itran.Quantity, itran.Total.CValue, Offset);
            //    Offset = Offset + smallinc;
            //}
            //foreach (var dtran in order.DealTransactions)
            //{
            //    InsertItem(dtran.Deal.Name, dtran.Total.CValue, Offset);
            //    Offset = Offset + smallinc;

            //    foreach (var di in dtran.Deal.DealItems)
            //    {
            //        InsertItem(di.Item.Name + " x " + (dtran.Quantity * di.Quantity), "", Offset);
            //        Offset = Offset + smallinc;
            //    }
            //}

            //underLine = "-------------------------";
            //DrawLine(underLine, largefont, Offset, 30);

            //Offset = Offset + largeinc;
            //InsertItem(" Net. Total: ", order.Total.CValue, Offset);

            //if (!order.Cash.Discount.IsZero())
            //{
            //    Offset = Offset + smallinc;
            //    InsertItem(" Discount: ", order.Cash.Discount.CValue, Offset);
            //}

            //Offset = Offset + smallinc;
            //InsertHeaderStyleItem(" Amount Payable: ", order.GrossTotal.CValue, Offset);

            //Offset = Offset + largeinc;
            //String address = shop.Address;
            //DrawSimpleString("Address: " + address, minifont, Offset, 15);

            //Offset = Offset + smallinc;
            //String number = "Tel: " + shop.Phone1 + " - OR - " + shop.Phone2;
            //DrawSimpleString(number, minifont, Offset, 35);

            //Offset = Offset + 7;
            //underLine = "-------------------------------------";
            //DrawLine(underLine, largefont, Offset, 0);

            //Offset = Offset + mediuminc;
            //String greetings = "Thanks for visiting us.";
            //DrawSimpleString(greetings, mediumfont, Offset, 28);

            //Offset = Offset + mediuminc;
            //underLine = "-------------------------------------";
            //DrawLine(underLine, largefont, Offset, 0);

            //Offset += (2 * mediuminc);
            //string tip = "TIP: -----------------------------";
            //InsertItem(tip, "", Offset);

            //Offset = Offset + largeinc;
            //string DrawnBy = "Meganos Softwares: 0312-0459491 - OR - 0321-6228321";
            //DrawSimpleString(DrawnBy, minifont, Offset, 15);
        }

        private static void PrintReportSummary(object sender, PrintPageEventArgs e)
        {
            graphics = e.Graphics;
            Font minifont = new Font("Arial", 5);
            Font itemfont = new Font("Arial", 6);
            Font smallfont = new Font("Arial", 8);
            Font mediumfont = new Font("Arial", 10);
            Font largefont = new Font("Arial", 12);
            int Offset = 10;
            int smallinc = 10, mediuminc = 12, largeinc = 15;

            String underLine = "-------------------------------------------------------";

            InsertHeaderStyleItem(UserAgent.CompanyName, "", Offset);

            Offset = Offset + largeinc;

            InsertHeaderStyleItem("JACKPOT", "", Offset);

            Offset = Offset + largeinc;
            InsertHeaderStyleItem("Agent   " + UserAgent.AgentCode, "", Offset);


            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("Date    " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year, "", Offset);

            Offset = Offset + largeinc;
            InsertHeaderStyleItem("Report   ", "", Offset);


            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("From :- " + _report.start_date + " To :-  " + _report.end_date, "", Offset);

            Offset = Offset + mediuminc;
            DrawLine(underLine, mediumfont, Offset, 0);


            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("Gross Sales Amount      ", _report.gross_sales_amount, Offset);


            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("Cancelled Amount        ", _report.cancelled_sales_amount, Offset);

            Offset = Offset + mediuminc;
            DrawLine(underLine, mediumfont, Offset, 0);

            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("Net Sales Amount       ", _report.net_sales_amount, Offset);

            Offset = Offset + mediuminc;

            InsertHeaderStyleItem("Payout Amount           ", _report.payout_amount, Offset);

            Offset = Offset + mediuminc;
            DrawLine(underLine, mediumfont, Offset, 0);


            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("Operator Balance        ", _report.operator_balance, Offset);

            Offset = Offset + mediuminc;
            DrawLine(underLine, mediumfont, Offset, 0);


            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("Retailer Discount       ", _report.retailer_discount, Offset);

            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("Sale Incentive          ", _report.sale_incentive, Offset);

            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("Payout Incentive        ", _report.PayoutIncentive, Offset);

            Offset = Offset + mediuminc;
            DrawLine(underLine, mediumfont, Offset, 0);

            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("Total Profit            ", _report.total_profit, Offset);

            Offset = Offset + mediuminc;
            DrawLine(underLine, mediumfont, Offset, 0);

            Offset = Offset + mediuminc;
            InsertHeaderStyleItem("Net To Pay              ", _report.net_to_pay, Offset);



            //graphics.DrawString("Welcome to HOT AND CRISPY", smallfont,
            //new SolidBrush(Color.Black), startX + 22, startY + Offset);


            //  Offset = Offset + mediuminc;

            //  DrawAtStart("Date: " + "11-09-21", Offset);

            // DrawAtStart("Time: " + "9:00 PM", Offset);

            /// Offset = Offset + mediuminc;

            //DrawAtStart("Qty : " + "10", Offset);

            // DrawAtStart("Rs: " + "2", Offset);


            //  DrawAtStart("Time: " + "9:00 PM", Offset);


            Offset = Offset + mediuminc;
            // underLine = "-------------------------";
            //  DrawLine(underLine, largefont, Offset, 30);

            // Offset = Offset + largeinc;

            // InsertHeaderStyleItem("Name. ", "Price. ", Offset);

            //Offset = Offset + largeinc;
            //foreach (var itran in order.ItemTransactions)
            //{
            //    InsertItem(itran.Item.Name + " x " + itran.Quantity, itran.Total.CValue, Offset);
            //    Offset = Offset + smallinc;
            //}
            //foreach (var dtran in order.DealTransactions)
            //{
            //    InsertItem(dtran.Deal.Name, dtran.Total.CValue, Offset);
            //    Offset = Offset + smallinc;

            //    foreach (var di in dtran.Deal.DealItems)
            //    {
            //        InsertItem(di.Item.Name + " x " + (dtran.Quantity * di.Quantity), "", Offset);
            //        Offset = Offset + smallinc;
            //    }
            //}

            //underLine = "-------------------------";
            //DrawLine(underLine, largefont, Offset, 30);

            //Offset = Offset + largeinc;
            //InsertItem(" Net. Total: ", order.Total.CValue, Offset);

            //if (!order.Cash.Discount.IsZero())
            //{
            //    Offset = Offset + smallinc;
            //    InsertItem(" Discount: ", order.Cash.Discount.CValue, Offset);
            //}

            //Offset = Offset + smallinc;
            //InsertHeaderStyleItem(" Amount Payable: ", order.GrossTotal.CValue, Offset);

            //Offset = Offset + largeinc;
            //String address = shop.Address;
            //DrawSimpleString("Address: " + address, minifont, Offset, 15);

            //Offset = Offset + smallinc;
            //String number = "Tel: " + shop.Phone1 + " - OR - " + shop.Phone2;
            //DrawSimpleString(number, minifont, Offset, 35);

            //Offset = Offset + 7;
            //underLine = "-------------------------------------";
            //DrawLine(underLine, largefont, Offset, 0);

            //Offset = Offset + mediuminc;
            //String greetings = "Thanks for visiting us.";
            //DrawSimpleString(greetings, mediumfont, Offset, 28);

            //Offset = Offset + mediuminc;
            //underLine = "-------------------------------------";
            //DrawLine(underLine, largefont, Offset, 0);

            //Offset += (2 * mediuminc);
            //string tip = "TIP: -----------------------------";
            //InsertItem(tip, "", Offset);

            //Offset = Offset + largeinc;
            //string DrawnBy = "Meganos Softwares: 0312-0459491 - OR - 0321-6228321";
            //DrawSimpleString(DrawnBy, minifont, Offset, 15);
        }

        #endregion
    }
}
