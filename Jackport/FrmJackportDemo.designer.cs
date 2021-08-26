namespace Jackport
{
    partial class FrmJackportDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmJackportDemo));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tblBids = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtLpNo = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.tblbidsControl = new System.Windows.Forms.TableLayoutPanel();
            this.label82 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txttotalvalue = new System.Windows.Forms.TextBox();
            this.label145 = new System.Windows.Forms.Label();
            this.txttickektsqty = new System.Windows.Forms.TextBox();
            this.label146 = new System.Windows.Forms.Label();
            this.lbltsnprice = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtTSN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.headerpanel = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.LblTime = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.linkbalance = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblprice = new System.Windows.Forms.Label();
            this.lblWinRs = new System.Windows.Forms.Label();
            this.label144 = new System.Windows.Forms.Label();
            this.cmbSlot = new System.Windows.Forms.ComboBox();
            this.LblAgentId = new System.Windows.Forms.Label();
            this.lblSlotTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label140 = new System.Windows.Forms.Label();
            this.lblticketprice = new System.Windows.Forms.Label();
            this.lblpriceformat = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LblCountDown1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.LblCompanyName = new System.Windows.Forms.Label();
            this.LblBalance = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.tblLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.headerpanel.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tblLayout);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 133);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1241, 551);
            this.panel4.TabIndex = 551;
            // 
            // tblLayout
            // 
            this.tblLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblLayout.BackColor = System.Drawing.Color.Navy;
            this.tblLayout.BackgroundImage = global::Jackport.Properties.Resources.gameboard1;
            this.tblLayout.ColumnCount = 4;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.39185F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.77221F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.633292F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 384F));
            this.tblLayout.Controls.Add(this.tblBids, 0, 0);
            this.tblLayout.Controls.Add(this.flowLayoutPanel1, 3, 0);
            this.tblLayout.Controls.Add(this.tableLayoutPanel1, 2, 0);
            this.tblLayout.Controls.Add(this.tblbidsControl, 1, 0);
            this.tblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayout.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tblLayout.Location = new System.Drawing.Point(0, 0);
            this.tblLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 1;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.Size = new System.Drawing.Size(1241, 551);
            this.tblLayout.TabIndex = 550;
            this.tblLayout.Visible = false;
            // 
            // tblBids
            // 
            this.tblBids.ColumnCount = 10;
            this.tblBids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblBids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblBids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblBids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblBids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblBids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblBids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblBids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblBids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblBids.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblBids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBids.Location = new System.Drawing.Point(0, 0);
            this.tblBids.Margin = new System.Windows.Forms.Padding(0);
            this.tblBids.Name = "tblBids";
            this.tblBids.RowCount = 10;
            this.tblBids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.02571F));
            this.tblBids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.915339F));
            this.tblBids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.915339F));
            this.tblBids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.02571F));
            this.tblBids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.02571F));
            this.tblBids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.02571F));
            this.tblBids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.607218F));
            this.tblBids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.40782F));
            this.tblBids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.02571F));
            this.tblBids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.02571F));
            this.tblBids.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblBids.Size = new System.Drawing.Size(647, 551);
            this.tblBids.TabIndex = 549;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(858, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(380, 545);
            this.flowLayoutPanel1.TabIndex = 251;
            this.flowLayoutPanel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.flowLayoutPanel1_Scroll);
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.TxtLpNo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button7, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(802, 459);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.5618F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.4382F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(50, 89);
            this.tableLayoutPanel1.TabIndex = 550;
            // 
            // TxtLpNo
            // 
            this.TxtLpNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TxtLpNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtLpNo.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLpNo.Location = new System.Drawing.Point(3, 3);
            this.TxtLpNo.MaxLength = 2;
            this.TxtLpNo.Multiline = true;
            this.TxtLpNo.Name = "TxtLpNo";
            this.TxtLpNo.Size = new System.Drawing.Size(44, 39);
            this.TxtLpNo.TabIndex = 254;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(3, 48);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(44, 38);
            this.button7.TabIndex = 547;
            this.button7.Text = "&LP";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // tblbidsControl
            // 
            this.tblbidsControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblbidsControl.ColumnCount = 2;
            this.tblbidsControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblbidsControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblbidsControl.ForeColor = System.Drawing.Color.White;
            this.tblbidsControl.Location = new System.Drawing.Point(650, 3);
            this.tblbidsControl.Name = "tblbidsControl";
            this.tblbidsControl.RowCount = 10;
            this.tblbidsControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.541285F));
            this.tblbidsControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.908257F));
            this.tblbidsControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.27523F));
            this.tblbidsControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.724771F));
            this.tblbidsControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.908257F));
            this.tblbidsControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.45872F));
            this.tblbidsControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.541285F));
            this.tblbidsControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.45872F));
            this.tblbidsControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.908257F));
            this.tblbidsControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.908257F));
            this.tblbidsControl.Size = new System.Drawing.Size(146, 545);
            this.tblbidsControl.TabIndex = 551;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.ForeColor = System.Drawing.Color.White;
            this.label82.Location = new System.Drawing.Point(647, 3);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(54, 19);
            this.label82.TabIndex = 529;
            this.label82.Text = "60-69";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.ForeColor = System.Drawing.Color.White;
            this.label83.Location = new System.Drawing.Point(567, 34);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(27, 19);
            this.label83.TabIndex = 528;
            this.label83.Text = "E6";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(396, 9);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(131, 42);
            this.flowLayoutPanel2.TabIndex = 507;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.BackgroundImage = global::Jackport.Properties.Resources.footer;
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFooter.Controls.Add(this.panel8);
            this.pnlFooter.Controls.Add(this.panel7);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 684);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1241, 57);
            this.pnlFooter.TabIndex = 549;
            this.pnlFooter.Visible = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Controls.Add(this.txttotalvalue);
            this.panel8.Controls.Add(this.label145);
            this.panel8.Controls.Add(this.txttickektsqty);
            this.panel8.Controls.Add(this.label146);
            this.panel8.Controls.Add(this.lbltsnprice);
            this.panel8.Location = new System.Drawing.Point(810, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(427, 53);
            this.panel8.TabIndex = 508;
            // 
            // txttotalvalue
            // 
            this.txttotalvalue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txttotalvalue.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotalvalue.Location = new System.Drawing.Point(278, 11);
            this.txttotalvalue.Multiline = true;
            this.txttotalvalue.Name = "txttotalvalue";
            this.txttotalvalue.ReadOnly = true;
            this.txttotalvalue.Size = new System.Drawing.Size(139, 25);
            this.txttotalvalue.TabIndex = 506;
            this.txttotalvalue.Text = "0.00";
            this.txttotalvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttotalvalue.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label145
            // 
            this.label145.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label145.AutoSize = true;
            this.label145.BackColor = System.Drawing.Color.Transparent;
            this.label145.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label145.ForeColor = System.Drawing.Color.White;
            this.label145.Location = new System.Drawing.Point(165, 15);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(15, 16);
            this.label145.TabIndex = 503;
            this.label145.Text = "x";
            // 
            // txttickektsqty
            // 
            this.txttickektsqty.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txttickektsqty.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttickektsqty.Location = new System.Drawing.Point(186, 11);
            this.txttickektsqty.Multiline = true;
            this.txttickektsqty.Name = "txttickektsqty";
            this.txttickektsqty.Size = new System.Drawing.Size(66, 25);
            this.txttickektsqty.TabIndex = 504;
            this.txttickektsqty.Text = "0.00";
            this.txttickektsqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttickektsqty.TextChanged += new System.EventHandler(this.txttickektsqty_TextChanged);
            // 
            // label146
            // 
            this.label146.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label146.AutoSize = true;
            this.label146.BackColor = System.Drawing.Color.Transparent;
            this.label146.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label146.ForeColor = System.Drawing.Color.White;
            this.label146.Location = new System.Drawing.Point(256, 14);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(18, 19);
            this.label146.TabIndex = 505;
            this.label146.Text = "=";
            // 
            // lbltsnprice
            // 
            this.lbltsnprice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltsnprice.AutoSize = true;
            this.lbltsnprice.BackColor = System.Drawing.Color.Transparent;
            this.lbltsnprice.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltsnprice.ForeColor = System.Drawing.Color.White;
            this.lbltsnprice.Location = new System.Drawing.Point(108, 14);
            this.lbltsnprice.Name = "lbltsnprice";
            this.lbltsnprice.Size = new System.Drawing.Size(45, 19);
            this.lbltsnprice.TabIndex = 502;
            this.lbltsnprice.Text = "2.00";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.txtTSN);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(299, 53);
            this.panel7.TabIndex = 507;
            // 
            // txtTSN
            // 
            this.txtTSN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTSN.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTSN.Location = new System.Drawing.Point(55, 8);
            this.txtTSN.Multiline = true;
            this.txtTSN.Name = "txtTSN";
            this.txtTSN.Size = new System.Drawing.Size(222, 25);
            this.txtTSN.TabIndex = 257;
            this.txtTSN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTSN_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 19);
            this.label1.TabIndex = 501;
            this.label1.Text = "TSN";
            // 
            // headerpanel
            // 
            this.headerpanel.BackColor = System.Drawing.Color.White;
            this.headerpanel.BackgroundImage = global::Jackport.Properties.Resources.header;
            this.headerpanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.headerpanel.Controls.Add(this.panel6);
            this.headerpanel.Controls.Add(this.linkbalance);
            this.headerpanel.Controls.Add(this.flowLayoutPanel2);
            this.headerpanel.Controls.Add(this.pictureBox1);
            this.headerpanel.Controls.Add(this.panel3);
            this.headerpanel.Controls.Add(this.panel2);
            this.headerpanel.Controls.Add(this.LblCompanyName);
            this.headerpanel.Controls.Add(this.label82);
            this.headerpanel.Controls.Add(this.LblBalance);
            this.headerpanel.Controls.Add(this.label83);
            this.headerpanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerpanel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerpanel.Location = new System.Drawing.Point(0, 0);
            this.headerpanel.Name = "headerpanel";
            this.headerpanel.Size = new System.Drawing.Size(1241, 133);
            this.headerpanel.TabIndex = 0;
            this.headerpanel.Visible = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.LblTime);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.LblDate);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Location = new System.Drawing.Point(972, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(265, 58);
            this.panel6.TabIndex = 258;
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTime.ForeColor = System.Drawing.Color.White;
            this.LblTime.Location = new System.Drawing.Point(138, 32);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(45, 19);
            this.LblTime.TabIndex = 9;
            this.LblTime.Text = "Time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(5, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 19);
            this.label8.TabIndex = 255;
            this.label8.Text = "Current Time :";
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDate.ForeColor = System.Drawing.Color.White;
            this.LblDate.Location = new System.Drawing.Point(138, 5);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(45, 19);
            this.LblDate.TabIndex = 8;
            this.LblDate.Text = "Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(4, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 19);
            this.label7.TabIndex = 254;
            this.label7.Text = "Current Date : ";
            // 
            // linkbalance
            // 
            this.linkbalance.ActiveLinkColor = System.Drawing.Color.White;
            this.linkbalance.AutoSize = true;
            this.linkbalance.BackColor = System.Drawing.Color.Transparent;
            this.linkbalance.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkbalance.ForeColor = System.Drawing.Color.White;
            this.linkbalance.LinkColor = System.Drawing.Color.White;
            this.linkbalance.Location = new System.Drawing.Point(4, 9);
            this.linkbalance.Name = "linkbalance";
            this.linkbalance.Size = new System.Drawing.Size(117, 19);
            this.linkbalance.TabIndex = 256;
            this.linkbalance.TabStop = true;
            this.linkbalance.Text = "Show Balance";
            this.linkbalance.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkbalance_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(202, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 253;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel3.BackgroundImage = global::Jackport.Properties.Resources.navbar22;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.linkLabel1);
            this.panel3.Controls.Add(this.lblprice);
            this.panel3.Controls.Add(this.lblWinRs);
            this.panel3.Controls.Add(this.label144);
            this.panel3.Controls.Add(this.cmbSlot);
            this.panel3.Controls.Add(this.LblAgentId);
            this.panel3.Controls.Add(this.lblSlotTime);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label140);
            this.panel3.Controls.Add(this.lblticketprice);
            this.panel3.Controls.Add(this.lblpriceformat);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(0, 58);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1237, 29);
            this.panel3.TabIndex = 252;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.White;
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(803, 3);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(126, 19);
            this.linkLabel1.TabIndex = 259;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Refresh Board";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblprice
            // 
            this.lblprice.BackColor = System.Drawing.Color.Transparent;
            this.lblprice.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprice.Location = new System.Drawing.Point(121, 4);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(36, 18);
            this.lblprice.TabIndex = 18;
            this.lblprice.Text = "RS:";
            // 
            // lblWinRs
            // 
            this.lblWinRs.AutoSize = true;
            this.lblWinRs.BackColor = System.Drawing.Color.Transparent;
            this.lblWinRs.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinRs.Location = new System.Drawing.Point(480, 4);
            this.lblWinRs.Name = "lblWinRs";
            this.lblWinRs.Size = new System.Drawing.Size(63, 18);
            this.lblWinRs.TabIndex = 17;
            this.lblWinRs.Text = "160.00";
            // 
            // label144
            // 
            this.label144.AutoSize = true;
            this.label144.BackColor = System.Drawing.Color.Transparent;
            this.label144.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label144.Location = new System.Drawing.Point(398, 4);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(85, 18);
            this.label144.TabIndex = 16;
            this.label144.Text = "WIN :  RS.";
            // 
            // cmbSlot
            // 
            this.cmbSlot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSlot.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSlot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.cmbSlot.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbSlot.DropDownHeight = 120;
            this.cmbSlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSlot.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSlot.ForeColor = System.Drawing.Color.White;
            this.cmbSlot.FormattingEnabled = true;
            this.cmbSlot.IntegralHeight = false;
            this.cmbSlot.Items.AddRange(new object[] {
            "CURRENT",
            "NEXT 5",
            "NEXT 10",
            "NEXT 15",
            "NEXT 20",
            "ALL DRAW"});
            this.cmbSlot.Location = new System.Drawing.Point(1050, 0);
            this.cmbSlot.Name = "cmbSlot";
            this.cmbSlot.Size = new System.Drawing.Size(185, 30);
            this.cmbSlot.TabIndex = 10;
            this.cmbSlot.SelectedIndexChanged += new System.EventHandler(this.cmbSlot_SelectedIndexChanged);
            // 
            // LblAgentId
            // 
            this.LblAgentId.AutoSize = true;
            this.LblAgentId.BackColor = System.Drawing.Color.Transparent;
            this.LblAgentId.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAgentId.Location = new System.Drawing.Point(697, 6);
            this.LblAgentId.Name = "LblAgentId";
            this.LblAgentId.Size = new System.Drawing.Size(58, 18);
            this.LblAgentId.TabIndex = 6;
            this.LblAgentId.Text = "12345";
            // 
            // lblSlotTime
            // 
            this.lblSlotTime.AutoSize = true;
            this.lblSlotTime.BackColor = System.Drawing.Color.Transparent;
            this.lblSlotTime.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlotTime.Location = new System.Drawing.Point(277, 5);
            this.lblSlotTime.Name = "lblSlotTime";
            this.lblSlotTime.Size = new System.Drawing.Size(81, 18);
            this.lblSlotTime.TabIndex = 13;
            this.lblSlotTime.Text = "12:06 PM";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(600, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "AGENT ID :";
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.BackColor = System.Drawing.Color.Transparent;
            this.label140.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label140.Location = new System.Drawing.Point(209, 4);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(71, 18);
            this.label140.TabIndex = 12;
            this.label140.Text = "PICK3 - ";
            // 
            // lblticketprice
            // 
            this.lblticketprice.AutoSize = true;
            this.lblticketprice.BackColor = System.Drawing.Color.Transparent;
            this.lblticketprice.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblticketprice.Location = new System.Drawing.Point(153, 4);
            this.lblticketprice.Name = "lblticketprice";
            this.lblticketprice.Size = new System.Drawing.Size(18, 18);
            this.lblticketprice.TabIndex = 11;
            this.lblticketprice.Text = "2";
            // 
            // lblpriceformat
            // 
            this.lblpriceformat.AutoSize = true;
            this.lblpriceformat.BackColor = System.Drawing.Color.Transparent;
            this.lblpriceformat.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpriceformat.Location = new System.Drawing.Point(3, 4);
            this.lblpriceformat.Name = "lblpriceformat";
            this.lblpriceformat.Size = new System.Drawing.Size(98, 18);
            this.lblpriceformat.TabIndex = 10;
            this.lblpriceformat.Text = "STARDIGIT";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.BackgroundImage = global::Jackport.Properties.Resources.navbar3;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1237, 42);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.Location = new System.Drawing.Point(809, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(159, 36);
            this.button4.TabIndex = 8;
            this.button4.Text = "Settin&gs ";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_3);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.LblCountDown1);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(1016, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(219, 40);
            this.panel5.TabIndex = 7;
            // 
            // LblCountDown1
            // 
            this.LblCountDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LblCountDown1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCountDown1.ForeColor = System.Drawing.Color.White;
            this.LblCountDown1.Location = new System.Drawing.Point(116, 3);
            this.LblCountDown1.Name = "LblCountDown1";
            this.LblCountDown1.Size = new System.Drawing.Size(101, 34);
            this.LblCountDown1.TabIndex = 2;
            this.LblCountDown1.Text = "00:00:00";
            this.LblCountDown1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(-1, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Time Left :";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button6.Location = new System.Drawing.Point(486, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(156, 36);
            this.button6.TabIndex = 5;
            this.button6.Text = "Result - &R";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button5.Location = new System.Drawing.Point(646, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(159, 36);
            this.button5.TabIndex = 4;
            this.button5.Text = "Report - &S";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.Location = new System.Drawing.Point(330, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 36);
            this.button3.TabIndex = 2;
            this.button3.Text = "&Print - F12";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(173, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "Clear - &M";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Bet Details -&T";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LblCompanyName
            // 
            this.LblCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCompanyName.BackColor = System.Drawing.Color.Transparent;
            this.LblCompanyName.Font = new System.Drawing.Font("Consolas", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompanyName.ForeColor = System.Drawing.Color.White;
            this.LblCompanyName.Location = new System.Drawing.Point(666, 1);
            this.LblCompanyName.Name = "LblCompanyName";
            this.LblCompanyName.Size = new System.Drawing.Size(266, 53);
            this.LblCompanyName.TabIndex = 4;
            this.LblCompanyName.Text = "JACKPOT";
            this.LblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblBalance
            // 
            this.LblBalance.AutoSize = true;
            this.LblBalance.BackColor = System.Drawing.Color.Transparent;
            this.LblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBalance.ForeColor = System.Drawing.Color.White;
            this.LblBalance.Location = new System.Drawing.Point(7, 36);
            this.LblBalance.Name = "LblBalance";
            this.LblBalance.Size = new System.Drawing.Size(123, 20);
            this.LblBalance.TabIndex = 0;
            this.LblBalance.Text = "Show Balance";
            this.LblBalance.Visible = false;
            // 
            // FrmJackportDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1241, 741);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.headerpanel);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmJackportDemo";
            this.Text = "JACKPORT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmJackportDemo_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmJackportDemo_FormClosed);
            this.Load += new System.EventHandler(this.FrmJackport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmJackportDemo_KeyDown);
            this.panel4.ResumeLayout(false);
            this.tblLayout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.headerpanel.ResumeLayout(false);
            this.headerpanel.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtTSN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbltsnprice;
        private System.Windows.Forms.Label label145;
        private System.Windows.Forms.Label label146;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.TableLayoutPanel tblLayout;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label LblBalance;
        private System.Windows.Forms.Label LblCompanyName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblprice;
        private System.Windows.Forms.Label lblWinRs;
        private System.Windows.Forms.Label label144;
        private System.Windows.Forms.ComboBox cmbSlot;
        private System.Windows.Forms.Label LblAgentId;
        private System.Windows.Forms.Label lblSlotTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label140;
        private System.Windows.Forms.Label lblticketprice;
        private System.Windows.Forms.Label lblpriceformat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkbalance;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel headerpanel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label LblCountDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        public System.Windows.Forms.TextBox txttickektsqty;
        public System.Windows.Forms.TextBox txttotalvalue;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox TxtLpNo;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label83;
        public System.Windows.Forms.TableLayoutPanel tblBids;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.TableLayoutPanel tblbidsControl;
    }
}