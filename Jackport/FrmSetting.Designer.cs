namespace Jackport
{
    partial class FrmSetting
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtheight = new System.Windows.Forms.TextBox();
            this.txtwidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkdirectprint = new System.Windows.Forms.CheckBox();
            this.txtpapersize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPrinter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtxtrheight = new System.Windows.Forms.TextBox();
            this.txtctrwidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(554, 473);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.txtheight);
            this.tabPage1.Controls.Add(this.txtwidth);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.chkdirectprint);
            this.tabPage1.Controls.Add(this.txtpapersize);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cmbPrinter);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(546, 441);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Print Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtheight
            // 
            this.txtheight.Location = new System.Drawing.Point(163, 179);
            this.txtheight.Name = "txtheight";
            this.txtheight.Size = new System.Drawing.Size(129, 26);
            this.txtheight.TabIndex = 9;
            this.txtheight.Text = "200";
            // 
            // txtwidth
            // 
            this.txtwidth.Location = new System.Drawing.Point(163, 138);
            this.txtwidth.Name = "txtwidth";
            this.txtwidth.Size = new System.Drawing.Size(129, 26);
            this.txtwidth.TabIndex = 8;
            this.txtwidth.Text = "200";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Height";
            // 
            // chkdirectprint
            // 
            this.chkdirectprint.AutoSize = true;
            this.chkdirectprint.Checked = true;
            this.chkdirectprint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkdirectprint.Location = new System.Drawing.Point(163, 231);
            this.chkdirectprint.Name = "chkdirectprint";
            this.chkdirectprint.Size = new System.Drawing.Size(136, 23);
            this.chkdirectprint.TabIndex = 5;
            this.chkdirectprint.Text = "Direct Print";
            this.chkdirectprint.UseVisualStyleBackColor = true;
            // 
            // txtpapersize
            // 
            this.txtpapersize.Location = new System.Drawing.Point(163, 101);
            this.txtpapersize.Name = "txtpapersize";
            this.txtpapersize.Size = new System.Drawing.Size(287, 26);
            this.txtpapersize.TabIndex = 3;
            this.txtpapersize.Text = "custom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Paper Size";
            // 
            // cmbPrinter
            // 
            this.cmbPrinter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPrinter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPrinter.FormattingEnabled = true;
            this.cmbPrinter.Location = new System.Drawing.Point(163, 52);
            this.cmbPrinter.Name = "cmbPrinter";
            this.cmbPrinter.Size = new System.Drawing.Size(287, 27);
            this.cmbPrinter.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Printer";
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.txtxtrheight);
            this.tabPage2.Controls.Add(this.txtctrwidth);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(546, 441);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Board Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 414);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 59);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtxtrheight
            // 
            this.txtxtrheight.Location = new System.Drawing.Point(157, 56);
            this.txtxtrheight.Name = "txtxtrheight";
            this.txtxtrheight.Size = new System.Drawing.Size(50, 26);
            this.txtxtrheight.TabIndex = 13;
            this.txtxtrheight.Text = "40";
            // 
            // txtctrwidth
            // 
            this.txtctrwidth.Location = new System.Drawing.Point(157, 19);
            this.txtctrwidth.Name = "txtctrwidth";
            this.txtctrwidth.Size = new System.Drawing.Size(50, 26);
            this.txtctrwidth.TabIndex = 12;
            this.txtctrwidth.Text = "60";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ticket Height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ticket Width";
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 473);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FrmSetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbPrinter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkdirectprint;
        private System.Windows.Forms.TextBox txtpapersize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtheight;
        private System.Windows.Forms.TextBox txtwidth;
        private System.Windows.Forms.TextBox txtxtrheight;
        private System.Windows.Forms.TextBox txtctrwidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}