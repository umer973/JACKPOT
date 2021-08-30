using Jackport.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jackport
{
    public partial class FrmJackport : Form
    {


        public ClsService clsService;
        public string agentToken;
        public string slotdId;
        public string ticketNo;
        public int qty;
        public int currentSlot = 1;

        List<Bid> bidList = new List<Bid>();
        List<PurchaseTicket> plist = new List<PurchaseTicket>();

        public FrmJackport()
        {



        }

        private void GetSlot()
        {
            var slot = new PurchaseTicket
            {
                slot_id = Convert.ToInt16(slotdId)
            };

            plist.Add(slot);
        }

        private void SetData(Root _root)
        {
            try
            {
                LblAgentId.Text = _root.data.AgentData.agent_code;
                LblBalance.Text = _root.data.AgentData.balance;
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

        private void listValueControl2_Load(object sender, EventArgs e)
        {

        }








        private void TxtE0_KeyUp(object sender, KeyEventArgs e)
        {


            if (TxtE0.Text != null)
            {

                if (TxtE0.Text != "")
                {
                    TextBox a = (TextBox)sender;
                    a.BackColor = Color.GreenYellow;
                    Txt0.Text = Txt10.Text = Txt20.Text = Txt30.Text = Txt40.Text = Txt50.Text = Txt60.Text =
                    Txt70.Text = Txt80.Text = Txt90.Text = TxtE0.Text;
                }
                else
                {
                    TextBox a = (TextBox)sender;
                    a.BackColor = Color.Magenta;
                    Txt0.Text = Txt10.Text = Txt20.Text = Txt30.Text = Txt40.Text = Txt50.Text = Txt60.Text =
                    Txt70.Text = Txt80.Text = Txt90.Text = TxtE0.Text;
                }
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.Magenta;
            }
        }

        private void TxtE1_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtE1.Text != "")
            {

                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt1.Text = Txt11.Text = Txt21.Text = Txt31.Text = Txt41.Text = Txt51.Text = Txt61.Text =
                 Txt71.Text = Txt81.Text = Txt91.Text = TxtE1.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.Magenta;
                Txt1.Text = Txt11.Text = Txt21.Text = Txt31.Text = Txt41.Text = Txt51.Text = Txt61.Text =
              Txt71.Text = Txt81.Text = Txt91.Text = TxtE1.Text;
            }

        }

        private void TxtE2_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtE2.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt2.Text = Txt12.Text = Txt22.Text = Txt32.Text = Txt42.Text = Txt52.Text = Txt62.Text =
                    Txt72.Text = Txt82.Text = Txt92.Text = TxtE2.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.Magenta;
                Txt2.Text = Txt12.Text = Txt22.Text = Txt32.Text = Txt42.Text = Txt52.Text = Txt62.Text =
                Txt72.Text = Txt82.Text = Txt92.Text = TxtE2.Text;
            }
        }

        private void TxtE3_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtE3.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt3.Text = Txt13.Text = Txt23.Text = Txt33.Text = Txt43.Text = Txt53.Text = Txt63.Text =
                    Txt73.Text = Txt83.Text = Txt93.Text = TxtE3.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.Magenta;
                Txt3.Text = Txt13.Text = Txt23.Text = Txt33.Text = Txt43.Text = Txt53.Text = Txt63.Text =
                  Txt73.Text = Txt83.Text = Txt93.Text = TxtE3.Text;
            }
        }

        private void TxtE4_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtE4.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt4.Text = Txt14.Text = Txt24.Text = Txt34.Text = Txt44.Text = Txt54.Text = Txt64.Text =
                    Txt74.Text = Txt84.Text = Txt94.Text = TxtE4.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.Magenta;
                Txt4.Text = Txt14.Text = Txt24.Text = Txt34.Text = Txt44.Text = Txt54.Text = Txt64.Text =
                   Txt74.Text = Txt84.Text = Txt94.Text = TxtE4.Text;
            }
        }

        private void TxtE5_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtE5.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt5.Text = Txt15.Text = Txt25.Text = Txt35.Text = Txt45.Text = Txt55.Text = Txt65.Text =
                    Txt75.Text = Txt85.Text = Txt95.Text = TxtE5.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.Magenta;
                Txt5.Text = Txt15.Text = Txt25.Text = Txt35.Text = Txt45.Text = Txt55.Text = Txt65.Text =
    Txt75.Text = Txt85.Text = Txt95.Text = TxtE5.Text;
            }
        }

        private void TxtE6_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtE6.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt6.Text = Txt16.Text = Txt26.Text = Txt36.Text = Txt46.Text = Txt56.Text = Txt66.Text =
                    Txt76.Text = Txt86.Text = Txt96.Text = TxtE6.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.Magenta;
                Txt6.Text = Txt16.Text = Txt26.Text = Txt36.Text = Txt46.Text = Txt56.Text = Txt66.Text =
                  Txt76.Text = Txt86.Text = Txt96.Text = TxtE6.Text;
            }
        }

        private void TxtE7_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtE6.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt7.Text = Txt17.Text = Txt27.Text = Txt37.Text = Txt47.Text = Txt57.Text = Txt67.Text =
                    Txt77.Text = Txt87.Text = Txt97.Text = TxtE7.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.Magenta;
                Txt7.Text = Txt17.Text = Txt27.Text = Txt37.Text = Txt47.Text = Txt57.Text = Txt67.Text =
                  Txt77.Text = Txt87.Text = Txt97.Text = TxtE7.Text;
            }
        }

        private void TxtE8_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtE8.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt8.Text = Txt18.Text = Txt28.Text = Txt38.Text = Txt48.Text = Txt58.Text = Txt68.Text =
                    Txt78.Text = Txt88.Text = Txt98.Text = TxtE8.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.Magenta;
                Txt8.Text = Txt18.Text = Txt28.Text = Txt38.Text = Txt48.Text = Txt58.Text = Txt68.Text =
                   Txt78.Text = Txt88.Text = Txt98.Text = TxtE8.Text;
            }
        }

        private void TxtE9_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtE9.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt9.Text = Txt19.Text = Txt29.Text = Txt39.Text = Txt49.Text = Txt59.Text = Txt69.Text =
                    Txt79.Text = Txt89.Text = Txt99.Text = TxtE9.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.Magenta;
                Txt9.Text = Txt19.Text = Txt29.Text = Txt39.Text = Txt49.Text = Txt59.Text = Txt69.Text =
                   Txt79.Text = Txt89.Text = Txt99.Text = TxtE9.Text;
            }
        }

        private void Txt0009_KeyUp(object sender, KeyEventArgs e)
        {
            if (Txt0009.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt0.Text = Txt1.Text = Txt2.Text = Txt3.Text = Txt4.Text = Txt5.Text = Txt6.Text =
                    Txt7.Text = Txt8.Text = Txt9.Text = Txt0009.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.AliceBlue;
                Txt0.Text = Txt1.Text = Txt2.Text = Txt3.Text = Txt4.Text = Txt5.Text = Txt6.Text =
                    Txt7.Text = Txt8.Text = Txt9.Text = Txt0009.Text;
            }
        }

        private void Txt1019_KeyUp(object sender, KeyEventArgs e)
        {
            if (Txt1019.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt10.Text = Txt11.Text = Txt12.Text = Txt13.Text = Txt14.Text = Txt15.Text = Txt16.Text =
                    Txt17.Text = Txt18.Text = Txt19.Text = Txt1019.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.AliceBlue;
                Txt10.Text = Txt11.Text = Txt12.Text = Txt13.Text = Txt14.Text = Txt15.Text = Txt16.Text =
                    Txt17.Text = Txt18.Text = Txt19.Text = Txt1019.Text;
            }
        }

        private void Txt2029_KeyUp(object sender, KeyEventArgs e)
        {
            if (Txt2029.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt20.Text = Txt21.Text = Txt22.Text = Txt23.Text = Txt24.Text = Txt25.Text = Txt26.Text =
                    Txt27.Text = Txt28.Text = Txt29.Text = Txt2029.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.AliceBlue;
                Txt20.Text = Txt21.Text = Txt22.Text = Txt23.Text = Txt24.Text = Txt25.Text = Txt26.Text =
    Txt27.Text = Txt28.Text = Txt29.Text = Txt2029.Text;
            }
        }

        private void Txt3031_KeyUp(object sender, KeyEventArgs e)
        {
            if (Txt3031.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt30.Text = Txt31.Text = Txt32.Text = Txt33.Text = Txt34.Text = Txt35.Text = Txt36.Text =
                    Txt37.Text = Txt38.Text = Txt39.Text = Txt3031.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.AliceBlue;
                Txt30.Text = Txt31.Text = Txt32.Text = Txt33.Text = Txt34.Text = Txt35.Text = Txt36.Text =
                  Txt37.Text = Txt38.Text = Txt39.Text = Txt3031.Text;
            }
        }

        private void Txt4049_KeyUp(object sender, KeyEventArgs e)
        {
            if (Txt4049.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt40.Text = Txt41.Text = Txt42.Text = Txt43.Text = Txt44.Text = Txt45.Text = Txt46.Text =
                    Txt47.Text = Txt48.Text = Txt49.Text = Txt4049.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.AliceBlue;
                Txt40.Text = Txt41.Text = Txt42.Text = Txt43.Text = Txt44.Text = Txt45.Text = Txt46.Text =
              Txt47.Text = Txt48.Text = Txt49.Text = Txt4049.Text;
            }
        }

        private void Txt5051_KeyUp(object sender, KeyEventArgs e)
        {
            if (Txt5051.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt50.Text = Txt51.Text = Txt52.Text = Txt53.Text = Txt54.Text = Txt55.Text = Txt56.Text =
                    Txt57.Text = Txt58.Text = Txt59.Text = Txt5051.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.AliceBlue;
                Txt50.Text = Txt51.Text = Txt52.Text = Txt53.Text = Txt54.Text = Txt55.Text = Txt56.Text =
                 Txt57.Text = Txt58.Text = Txt59.Text = Txt5051.Text;
            }
        }

        private void Txt6069_KeyUp(object sender, KeyEventArgs e)
        {
            if (Txt6069.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt60.Text = Txt61.Text = Txt62.Text = Txt63.Text = Txt64.Text = Txt65.Text = Txt66.Text =
                    Txt67.Text = Txt68.Text = Txt69.Text = Txt6069.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.AliceBlue;
                Txt60.Text = Txt61.Text = Txt62.Text = Txt63.Text = Txt64.Text = Txt65.Text = Txt66.Text =
                   Txt67.Text = Txt68.Text = Txt69.Text = Txt6069.Text;
            }
        }

        private void Txt7079_KeyUp(object sender, KeyEventArgs e)
        {
            if (Txt7079.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt70.Text = Txt71.Text = Txt72.Text = Txt73.Text = Txt74.Text = Txt75.Text = Txt76.Text =
                    Txt77.Text = Txt78.Text = Txt79.Text = Txt7079.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.AliceBlue;
                Txt70.Text = Txt71.Text = Txt72.Text = Txt73.Text = Txt74.Text = Txt75.Text = Txt76.Text =
                Txt77.Text = Txt78.Text = Txt79.Text = Txt7079.Text;
            }
        }

        private void Txt8089_KeyUp(object sender, KeyEventArgs e)
        {
            if (Txt8089.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt80.Text = Txt81.Text = Txt82.Text = Txt83.Text = Txt84.Text = Txt85.Text = Txt86.Text =
                    Txt87.Text = Txt88.Text = Txt89.Text = Txt8089.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.AliceBlue;
                Txt80.Text = Txt81.Text = Txt82.Text = Txt83.Text = Txt84.Text = Txt85.Text = Txt86.Text =
                   Txt87.Text = Txt88.Text = Txt89.Text = Txt8089.Text;
            }
        }

        private void Txt9099_KeyUp(object sender, KeyEventArgs e)
        {
            if (Txt9099.Text != "")
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.GreenYellow;
                Txt90.Text = Txt91.Text = Txt92.Text = Txt93.Text = Txt94.Text = Txt95.Text = Txt96.Text =
                    Txt97.Text = Txt98.Text = Txt99.Text = Txt9099.Text;
            }
            else
            {
                TextBox a = (TextBox)sender;
                a.BackColor = Color.AliceBlue;
                Txt90.Text = Txt91.Text = Txt92.Text = Txt93.Text = Txt94.Text = Txt95.Text = Txt96.Text =
                   Txt97.Text = Txt98.Text = Txt99.Text = Txt9099.Text;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var txt = new TextBox();
            for (int i = 0; i < 100; i++)
            {
                MessageBox.Show(txt.Text + "" + i.ToString());
            }
            var bids = new Bid
            {
                quantity = Convert.ToInt16(Txt6.Text),
                number = 6

            };

            bidList.Add(bids);

            clsService.PurchaseSingleTicketAsync(agentToken, bidList, plist);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Txt6_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show(Txt6.Text);

        }

        private void Txt0_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
