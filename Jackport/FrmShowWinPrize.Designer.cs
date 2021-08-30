namespace Jackport
{
    partial class FrmShowWinPrize
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
            this.lblWin = new System.Windows.Forms.Label();
            this.lblWinNumber = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblDrawtime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWin
            // 
            this.lblWin.AutoSize = true;
            this.lblWin.Location = new System.Drawing.Point(598, 212);
            this.lblWin.Name = "lblWin";
            this.lblWin.Size = new System.Drawing.Size(19, 13);
            this.lblWin.TabIndex = 0;
            this.lblWin.Text = "00";
            // 
            // lblWinNumber
            // 
            this.lblWinNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWinNumber.AutoSize = true;
            this.lblWinNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblWinNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinNumber.ForeColor = System.Drawing.Color.White;
            this.lblWinNumber.Location = new System.Drawing.Point(592, 259);
            this.lblWinNumber.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWinNumber.Name = "lblWinNumber";
            this.lblWinNumber.Size = new System.Drawing.Size(153, 108);
            this.lblWinNumber.TabIndex = 2;
            this.lblWinNumber.Text = "00";
            this.lblWinNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(46)))), ((int)(((byte)(81)))));
            this.groupBox3.Controls.Add(this.lblDrawtime);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lblWinNumber);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(1366, 768);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // lblDrawtime
            // 
            this.lblDrawtime.AutoSize = true;
            this.lblDrawtime.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrawtime.ForeColor = System.Drawing.Color.White;
            this.lblDrawtime.Location = new System.Drawing.Point(696, 50);
            this.lblDrawtime.Name = "lblDrawtime";
            this.lblDrawtime.Size = new System.Drawing.Size(175, 34);
            this.lblDrawtime.TabIndex = 4;
            this.lblDrawtime.Text = "Draw Time ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(477, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "Draw Time  : ";
            // 
            // FrmShowWinPrize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblWin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmShowWinPrize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmShowWinPrize_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWin;
        private System.Windows.Forms.Label lblWinNumber;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblDrawtime;
        private System.Windows.Forms.Label label1;
    }
}