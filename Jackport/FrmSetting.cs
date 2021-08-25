using Jackport.DataModel;
using Jackport.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Jackport
{
    public partial class FrmSetting : Form
    {


        public FrmSetting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintJobSettings.PrinterName = cmbPrinter.SelectedItem.ToString().Trim();
            PrintJobSettings.IsDirectPrint = chkdirectprint.Checked;
            PrintJobSettings.Height = Convert.ToInt16(txtheight.Text);
            PrintJobSettings.Width = Convert.ToInt16(txtwidth.Text);
            PrintJobSettings.PaperSize = txtpapersize.Text;
            PrintJobSettings.ControlHeight = Convert.ToInt16(txtxtrheight.Text);
            PrintJobSettings.ControlWidth = Convert.ToInt16(txtctrwidth.Text);
            PrintJobSettings.ToolHeight = Convert.ToInt16(txttoolheight.Text);
            PrintJobSettings.ToolWidth = Convert.ToInt16(txttoolwidth.Text);


            var result = CommonHelper.InsertDataIntoXML();
            if (result)
                MessageBox.Show("Setting saved...");


        }


        private void FrmSetting_Load(object sender, EventArgs e)
        {
            LoadAllConnectedPrinters();
            LoadPinterSettings();
        }

        private void LoadPinterSettings()
        {
            try
            {
                CommonHelper.ReadXMlData();
                cmbPrinter.SelectedItem = PrintJobSettings.PrinterName;
                txtwidth.Text = PrintJobSettings.Width.ToString();
                txtheight.Text = PrintJobSettings.Height.ToString();
                chkdirectprint.Checked = PrintJobSettings.IsDirectPrint;
                txtpapersize.Text = PrintJobSettings.PaperSize;
                txtctrwidth.Text = PrintJobSettings.ControlWidth.ToString();
                txtxtrheight.Text = PrintJobSettings.ControlHeight.ToString();
                txttoolheight.Text = PrintJobSettings.ToolHeight.ToString();
                txttoolwidth.Text = PrintJobSettings.ToolWidth.ToString();
            }
            catch { }
        }

        private void LoadAllConnectedPrinters()
        {
            foreach (string printname in PrinterSettings.InstalledPrinters)
            {
                cmbPrinter.Items.Add(printname);
            }


        }
    }
}
