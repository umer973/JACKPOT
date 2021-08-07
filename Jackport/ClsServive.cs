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
           // deviceId = getMachineId().ToString().Trim();
           deviceId = "-hcaFK5rNlk8rFKhI2e-kStz04MpLGoCAqEIJAA7G30";
        }
        public bool ActivateLicenceAsync(string licenceKey)
        {
            var client = new RestClient("https://api.welcomejk.com/v1/logins/activation");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("APP-KEY", "e76d8c85-979c-411a-89f6-f1dfe0dfa041");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("license_key", licenceKey);
            request.AddParameter("machine_id", deviceId);
            IRestResponse response = client.Execute(request);
            //JavaScriptSerializer js =  new
            var result = JsonConvert.DeserializeObject<ApiResponse>(response.Content);

            if (result.success)
            {
                MessageBox.Show(result.message);
                return true;
            }
            else
            {
                MessageBox.Show(result.message);
                return false;
            }

        }


        public bool LoginAsync(string userName, string password)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("An error occured please try again or contact service provider!");
            }
            return false;

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

        public string GetWinTickets(int slotId)
        {
            List<WinTicket> WinTicketDetails = new List<DataModel.WinTicket>();
            var client = new RestClient("https://api.welcomejk.com/v1/tickets/get-win?slot_id=" + slotId);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("APP-KEY", "e76d8c85-979c-411a-89f6-f1dfe0dfa041");
            request.AddHeader("AGENT-TOKEN", UserAgent.AgenToken);
            request.AddHeader("MACHINE-ID", deviceId);
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<WinTicketResponse>(response.Content);
            if (result.success)
            {
                return result.data.win_number;

            }
            else
            {

                return result.message;

            }

        }



        public ReportSummary GetReportSummary(string startDate, string endDate)
        {

            // var client = new RestClient("https://api.welcomejk.com/v1/reports/get-report?start_date=" + endDate + "&end_date=" + endDate);
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

                return result.data;
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

        public bool ClaimTicket(string token, string barcode)
        {
            var client = new RestClient("https://api.welcomejk.com/v1/tickets/claim");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("APP-KEY", "e76d8c85-979c-411a-89f6-f1dfe0dfa041");
            request.AddHeader("AGENT-TOKEN", "5OX9e4L8P3KW_i0Vk4rHY-RI5v7LHIc4RSXcSic-dX3fNtNAJyV55o8Imi0eFd_dE4xtwV1s_0IMpetC2fbFTR5ttprIzPOGZ8nKWcWEtEvH9NtuBqjKMfUKB0hEoO3KNKgHZyGTnqCwkrmTwJpRm5wQpYco1ScZeR0XBaF8wU4RajEWApKdMUFaAUHDY62RZV98IVwTAY7sQ8d9BpFS9SScTgCSWhVQXs5bmFbfviu3cuD8Lq1gDDltojmw77K");
            request.AddHeader("MACHINE-ID", "dd97c9da-f21f-11eb-9a03-0242ac130003");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("ticket_barcode", "359");
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


        public List<TimeSlot> GetUpdatedSlots()
        {

            var client = new RestClient("https://api.welcomejk.com/v1/tickets/refresh-slots");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("APP-KEY", "e76d8c85-979c-411a-89f6-f1dfe0dfa041");
            request.AddHeader("AGENT-TOKEN", UserAgent.AgenToken);
            request.AddHeader("MACHINE-ID", deviceId);
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<UpdatedSlots>(response.Content);
            if (result.success)
            {
                return result.data.Select(x => new TimeSlot
                {
                    date_slot = x.date_slot,
                    time_end = x.time_end,
                    slot_over = x.slot_over,
                    slot_id = x.slot_id,
                    win_number = x.win_number != null ? x.win_number.ToString() : ""



                }).ToList();
            }
            else
            {
                return null;
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

        public List<WinTicketData> GetWinData()
        {
            var client = new RestClient("https://api.welcomejk.com/v1/reports/get-win-report?start_date=2021-08-05&end_date=2021-08-05");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("APP-KEY", "e76d8c85-979c-411a-89f6-f1dfe0dfa041");
            request.AddHeader("AGENT-TOKEN", "Ocz-8IkZ57UOMMwRyvvwegn0pSBJ2Jea8_3tGeVZ71i2GLL3zQDjS4k4gcEEljdfYnHl045vqiVtS7CmByGGQYAqOE4CIcJPPF3scmX3HA2XbEDmlbNuUfFeYba8Wku6yYocH1_jTQii4-iocA0mIDg3HL6taC9QD-1TJ_s2oH3KLVqICFJSDyuKhjY4jyN43wI0E1qD8dhf9iZ4gJBIKoaa8P8_a27coOkvv6khWw_XgNA6NoTwlG2I5_HqtCw");
            request.AddHeader("MACHINE-ID", "dd97c9da-f21f-11eb-9a03-0242ac130003");
            IRestResponse response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<WinTicketDetails>(response.Content);
            if (result.success)
            {
                return result.data.Select(x => new WinTicketData
                {
                    date_slot = x.date_slot,
                    time_start = x.time_start,
                    time_end = x.time_end,
                    win_number = x.win_number != null ? x.win_number.ToString() : ""



                }).ToList();
            }
            else
            {
                return null;
            }

        }
    }
}
