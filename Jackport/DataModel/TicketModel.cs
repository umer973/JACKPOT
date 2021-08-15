using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jackport.DataModel
{


    public class TicketDetail
    {
        public string ticket_barcode { get; set; }
        public string ticket_bid_number { get; set; }
        public string ticket_purchase_date { get; set; }
        public string ticket_purchase_price { get; set; }
        public string ticket_purchase_quantity { get; set; }
        public string ticket_purchase_amount { get; set; }
        public int ticket_win_amount { get; set; }
        public int ticket_win_agent { get; set; }
        public int ticket_win_customer { get; set; }
        public string ticket_purchase_time { get; set; }
        public string ticket_slot_start_time { get; set; }
        public string ticket_slot_end_time { get; set; }
        public string ticket_agent_code { get; set; }
        public string ticket_status { get; set; }
    }

    public class AgentDetails
    {
        public long old_balance { get; set; }
        public long new_balance { get; set; }
    }

    public class ClaimedTicketDetail
    {
        public bool success { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public TicketDetail ticket_detail { get; set; }
        public AgentDetails agent_details { get; set; }
    }



    public class Bids
    {
        public string ticket_barcode { get; set; }
        public string bid_number { get; set; }
        public string bid_quantity { get; set; }
        public string bid_price { get; set; }
        public string bid_amount { get; set; }
    }

    public class BidDetail
    {
        public string id { get; set; }
        public string slot_id { get; set; }
        public string ticket_barcode { get; set; }
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
        public List<Bids> bids { get; set; }
    }


    public class TicketResult
    {

        public bool success { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public BidDetail data { get; set; }
    }


}
