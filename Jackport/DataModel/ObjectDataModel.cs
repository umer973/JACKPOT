using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jackport.DataModel
{
    public class ObjectDataModel
    {
    }

    public class ApiResponse
    {
        public bool success { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public object data { get; set; }

    }

    public class ApplicationDetails
    {
        public string app_name { get; set; }
        public string app_logo { get; set; }
        public string app_time_zone { get; set; }
        public string agent_ticket_price { get; set; }
        public string agent_ticket_price_format { get; set; }
    }

    public class AgentData
    {
        public string username { get; set; }
        public string token { get; set; }
        public string agent_code { get; set; }
        public string balance { get; set; }
        public string agent_status { get; set; }
        public string last_login { get; set; }
    }

    public class LicenseData
    {
        public string license_code { get; set; }
        public string license_end_date { get; set; }
        public string license_status { get; set; }
    }

    public class TimeSlot
    {
        public string date_slot { get; set; }
        public string time_start { get; set; }
        public string time_start_stamp { get; set; }
        public string time_end { get; set; }
        public string time_end_stamp { get; set; }
        public string slot_over { get; set; }
        public string win_number { get; set; }
        public string slot_id { get; set; }
    }

    public class Data
    {
        [JsonProperty("application-details")]
        public ApplicationDetails ApplicationDetails { get; set; }

        [JsonProperty("agent-data")]
        public AgentData AgentData { get; set; }

        [JsonProperty("license-data")]
        public LicenseData LicenseData { get; set; }

        [JsonProperty("time-slots")]
        public List<TimeSlot> TimeSlots { get; set; }
    }

    public class Root
    {
        public bool success { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }



    public class Bid
    {
        public int number { get; set; }
        public int quantity { get; set; }
    }

    public class PurchaseTicket
    {
        public int slot_id { get; set; }
        public List<Bid> bids { get; set; }
    }

    public class Ticket
    {
        public List<PurchaseTicket> purchase_tickets { get; set; }
    }

    
    public class BidList
    {
        public int number { get; set; }
        public int quantity { get; set; }
        public string price { get; set; }
        public int amount { get; set; }
    }

    public class TimeSlotList
    {
        public int slot_id { get; set; }
        public string date_slot { get; set; }
        public string agent_code { get; set; }
        public string ticket_barcode { get; set; }
        public int total_amount { get; set; }
        public int total_quantity { get; set; }
        public string purchase_time { get; set; }
        public string time_start { get; set; }
        public string time_end { get; set; }
        public List<BidList> bids { get; set; }
    }

    public class PurchaseTicketData
    {
        public List<TimeSlotList> time_slots { get; set; }
        public long agent_balance { get; set; }
    }

    public class PurchaseResponse
    {
        public bool success { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public PurchaseTicketData data { get; set; }
    }

    public class PurvchasedTicketDetails
    {
        public bool success { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public List<PurchasedTickets> data { get; set; }
    }
    public class PurchasedTickets
    {
        public string id { get; set; }
        public string slot_id { get; set; }
        [JsonProperty("ticket_barcode")]
        public string Barcode { get; set; }
        public string ticket_taken_time { get; set; }
        public string ticket_start_time { get; set; }
        public string ticket_end_time { get; set; }
        public string ticket_total_quantity { get; set; }
        public string ticket_total_amount { get; set; }
        public string agent_id { get; set; }
        public string agent_code { get; set; }
        public string ticket_status { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public List<PurchasedBids> bids { get; set; }
    }

    public class PurchasedBids
    {
        public string ticket_barcode { get; set; }
        public string bid_number { get; set; }
        public string bid_quantity { get; set; }
        public string bid_price { get; set; }
        public string bid_amount { get; set; }
    }
    public class WinTicket
    {
        public string slot_id { get; set; }
        public string win_number { get; set; }
        public string date_slot { get; set; }
        public string time_start { get; set; }
        public string time_end { get; set; }
    }

    public class WinTicketResponse
    {
        public bool success { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public WinTicket data { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class ReportSummary
    {
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string gross_sales_amount { get; set; }
        public string cancelled_sales_amount { get; set; }
        public string net_sales_amount { get; set; }
        public string payout_amount { get; set; }
        public string operator_balance { get; set; }
        public string retailer_discount { get; set; }
        public string sale_incentive { get; set; }

        [JsonProperty("payout incentive")]
        public string PayoutIncentive { get; set; }
        public string total_profit { get; set; }
        public string net_to_pay { get; set; }
    }

    public class ReportData
    {
        public bool success { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public ReportSummary data { get; set; }
    }


    public static class Slots
    {
        public static int SlotId { get; set; }

        public static string SlotNames { get; set; }
    }


    public class SlotList
    {
        public string date_slot { get; set; }
        public string time_start { get; set; }
        public string time_end { get; set; }
        public string slot_over { get; set; }
        public object win_number { get; set; }
        public string slot_id { get; set; }
    }

    public class UpdatedSlots
    {
        public bool success { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public List<SlotList> data { get; set; }
    }




}
