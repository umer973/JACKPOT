using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using DeviceId;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Jackport.DataModel;
using RestSharp;

namespace Jackport
{


    public class ClsService
    {
        public static string apiBaseUrl = "";
        public string deviceId;
        public ClsService()
        {
            //deviceId = getMachineId().ToString().Trim();
            deviceId = "-hcaFK5rNlk8rFKhI2e-kStz04MpLGoCAqEIJAA7G30";
        }
        public async void ActivateLicenceAsync(string licenceKey)
        {
            var client = new RestClient("https://api.welcomejk.com/v1/logins/activation");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("APP-KEY", "e76d8c85-979c-411a-89f6-f1dfe0dfa041");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("license_key", licenceKey);
            request.AddParameter("machine_id", deviceId);
            IRestResponse response = await client.ExecuteAsync(request);
            //JavaScriptSerializer js =  new
            var result = JsonConvert.DeserializeObject<ApiResponse>(response.Content);


            //return result.message;

            MessageBox.Show(result.message);

            FrmRegister obj = new FrmRegister();
            FrmActivationKey objActivation = new FrmActivationKey();
            objActivation.Visible = false;
            obj.Show();


            //return true;
        }


        public bool LoginAsync(string userName, string password)
        {
            var client = new RestClient("https://api.welcomejk.com/v1/logins/do");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("APP-KEY", "e76d8c85-979c-411a-89f6-f1dfe0dfa041");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("username", userName);
            request.AddParameter("password", password);
            // request.AddParameter("machine_id", getMachineId().ToString().Trim());
            request.AddParameter("machine_id", deviceId);
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<Root>(response.Content);
            FrmLogin Login = new FrmLogin();
            if (result.success && result.code == 200)
            {
                FrmJackportDemo frmJackport = new FrmJackportDemo(result);
                //FrmLogin.Visible = false;
                Login.Hide();

                frmJackport.Show();
                Login.Hide();
                return true;

            }
            else
            {
                MessageBox.Show(result.message);
                return false;

            }


        }

        private string getMachineId()
        {
            string deviceId = new DeviceIdBuilder()
               .AddSystemUUID()
               .ToString();
            return deviceId;
        }

        public object PurchaseSingleTicketAsync(string token, List<Bid> bidList, List<PurchaseTicket> ticketList)
        {
            var client = new RestClient("https://api.welcomejk.com/v1/tickets/buy-all");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("APP-KEY", "e76d8c85-979c-411a-89f6-f1dfe0dfa041");
            request.AddHeader("AGENT-TOKEN", token);
            request.AddHeader("MACHINE-ID", deviceId);

            var body = new Ticket
            {
                purchase_tickets = getdata(ticketList, bidList)
            };
            var jsondata = JsonConvert.SerializeObject(body);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", jsondata, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            var result = JsonConvert.DeserializeObject<PurchaseResponse>(response.Content);

            if (result.success)
            {
                MessageBox.Show(result.message);
                return result.data.agent_balance;

            }
            else
            {
                MessageBox.Show(result.message);
                return null;
            }

        }

        private static List<PurchaseTicket> getdata(List<PurchaseTicket> ticList, List<Bid> bidList)
        {
            List<PurchaseTicket> PurchaseList = new List<PurchaseTicket>();

            return ticList.Select(x => new PurchaseTicket
            {
                slot_id = x.slot_id,
                bids = GetBids(bidList)
            }).ToList();




            //return PurchaseList;
        }

        private static List<Bid> GetBids(List<Bid> bids)
        {
            List<Bid> BidList = new List<Bid>();

            return bids = bids.Select(x => new Bid
            {
                number = x.number,
                quantity = x.quantity
            }).ToList();



        }

        public List<PurchasedTickets> GetTodaysPurchasedTickets(string token)
        {
            List<PurvchasedTicketDetails> purvchasedTicketDetails = new List<DataModel.PurvchasedTicketDetails>();
            var client = new RestClient("https://api.welcomejk.com/v1/tickets/get-today");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("APP-KEY", "e76d8c85-979c-411a-89f6-f1dfe0dfa041");
            request.AddHeader("AGENT-TOKEN", token);
            request.AddHeader("MACHINE-ID", deviceId);
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<PurvchasedTicketDetails>(response.Content);
            if (result.success)
            {
                return result.data.Select(x => new PurchasedTickets
                {
                    Barcode = x.Barcode,
                    agent_code = x.agent_code,
                    ticket_total_amount = x.ticket_total_amount,
                    ticket_status = x.ticket_status,
                    ticket_taken_time = x.ticket_taken_time,
                    agent_id = x.agent_id,
                    ticket_total_quantity = x.ticket_total_quantity,
                    slot_id = x.slot_id


                }).ToList();

            }
            else
            {
                MessageBox.Show(result.message);
                return null;
            }

        }

        public List<WinTicket> GetWinTickets(string TicketNo)
        {
            List<WinTicket> WinTicketDetails = new List<DataModel.WinTicket>();
            var client = new RestClient("https://api.welcomejk.com/v1/tickets/get-win?slot_id=1");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("APP-KEY", "e76d8c85-979c-411a-89f6-f1dfe0dfa041");
            request.AddHeader("AGENT-TOKEN", "n_w6-x_dzIVTfL0DS_X7fYLXzpesiYNpalAw18axphvEIPZBs_2mKMVK8J3dneh5f4ykK2qVWaPN2qQMmXk54QW853-v_gQkIPDNZ6W0lRfyjqPdrDJG6MK9HigiufNcIoR8bOb2vRYHRxbfe5FEY8WMZk-kXLqjEGQETBUrF0RvjKilsUQjZWII0WYdxlpfEQJguEysaAyQmT7sujG5BXcS0I7fVj7sGc42SKEjOETZKx5SfDOLWOeFDYDG5Qs");
            request.AddHeader("MACHINE-ID", "dd97c9da-f21f-11eb-9a03-0242ac130003");
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<WinTicketDetails>(response.Content);
            if (result.success)
            {
                return result.data.Select(x => new WinTicket
                {
                    ticket_barcode = x.ticket_barcode,
                    Agent_code = x.Agent_code,
                    Time_Slot=x.Time_Slot
                    
                    


                }).ToList();

            }
            else
            {
                MessageBox.Show(result.message);
                return null;
            }

        }



        public ReportSummary GetReportSummary(DateTime startTime, DateTime endDate)
        {

            //var client = new RestClient("https://api.welcomejk.com/v1/reports/get-report?start_date=" + startTime + "&end_date=" + endDate);
            var client = new RestClient("https://api.welcomejk.com/v1/reports/get-report?start_date=2021-08-02&end_date=2021-11-19");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("APP-KEY", "e76d8c85-979c-411a-89f6-f1dfe0dfa041");
            request.AddHeader("AGENT-TOKEN", UserAgent.AgenToken);
            // request.AddHeader("MACHINE-ID", getMachineId().ToString().Trim());
            request.AddHeader("MACHINE-ID", deviceId);
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<ReportData>(response.Content);
            if (result.success)
            {
                var report = new ReportSummary
                {
                    sale_incentive = result.data.sale_incentive,
                    net_sales_amount = result.data.net_sales_amount,
                    gross_sales_amount = result.data.gross_sales_amount
                };
                return report;
            }
            else
            {
                MessageBox.Show(result.message);
                return null;
            }
        }


        public bool CancelTicket(string token, string barcode)
        {
            var client = new RestClient("https://api.welcomejk.com/v1/tickets/cancel/" + barcode);
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("APP-KEY", "e76d8c85-979c-411a-89f6-f1dfe0dfa041");
            request.AddHeader("AGENT-TOKEN", token);
            request.AddHeader("MACHINE-ID", deviceId);
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<ApiResponse>(response.Content);
            if (result.success)
            {

                return true;
            }
            else
            {
                MessageBox.Show(result.message);
                return false;
            }
        }

        public void BinddataSet()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add();
            DataRow dr = dt.NewRow();
            dr[0] = "sads";
            ds.Tables.Add(dt);
        }
    }
}
