namespace Jackport
{
    partial class FrmBarcode
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SlotID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarcodeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrawTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mrp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cancelled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Claimed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnTmlClaim = new System.Windows.Forms.Button();
            this.BtnReprint = new System.Windows.Forms.Button();
            this.BtnTmlCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LawnGreen;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-1, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 539);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(13, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(744, 511);
            this.panel2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SlotID,
            this.BarcodeNo,
            this.DrawTime,
            this.Mrp,
            this.Qty,
            this.Amount,
            this.Cancelled,
            this.Claimed});
            this.dataGridView1.Location = new System.Drawing.Point(-2, -2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(743, 511);
            this.dataGridView1.TabIndex = 0;
            // 
            // SlotID
            // 
            this.SlotID.HeaderText = "SlotID";
            this.SlotID.Name = "SlotID";
            // 
            // BarcodeNo
            // 
            this.BarcodeNo.HeaderText = "Barcode No";
            this.BarcodeNo.Name = "BarcodeNo";
            this.BarcodeNo.ReadOnly = true;
            // 
            // DrawTime
            // 
            this.DrawTime.HeaderText = "Draw Time";
            this.DrawTime.Name = "DrawTime";
            this.DrawTime.ReadOnly = true;
            // 
            // Mrp
            // 
            this.Mrp.HeaderText = "Mrp";
            this.Mrp.Name = "Mrp";
            this.Mrp.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Cancelled
            // 
            this.Cancelled.HeaderText = "Status";
            this.Cancelled.Name = "Cancelled";
            this.Cancelled.ReadOnly = true;
            // 
            // Claimed
            // 
            this.Claimed.HeaderText = "Claimed";
            this.Claimed.Name = "Claimed";
            this.Claimed.ReadOnly = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnCancel.Location = new System.Drawing.Point(598, 542);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(166, 36);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Close";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnTmlClaim
            // 
            this.BtnTmlClaim.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnTmlClaim.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTmlClaim.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnTmlClaim.Location = new System.Drawing.Point(206, 542);
            this.BtnTmlClaim.Name = "BtnTmlClaim";
            this.BtnTmlClaim.Size = new System.Drawing.Size(166, 36);
            this.BtnTmlClaim.TabIndex = 2;
            this.BtnTmlClaim.Text = "TML Claim";
            this.BtnTmlClaim.UseVisualStyleBackColor = false;
            this.BtnTmlClaim.Click += new System.EventHandler(this.BtnTmlClaim_Click);
            // 
            // BtnReprint
            // 
            this.BtnReprint.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnReprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReprint.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnReprint.Location = new System.Drawing.Point(12, 542);
            this.BtnReprint.Name = "BtnReprint";
            this.BtnReprint.Size = new System.Drawing.Size(166, 36);
            this.BtnReprint.TabIndex = 3;
            this.BtnReprint.Text = "Re-Print";
            this.BtnReprint.UseVisualStyleBackColor = false;
            // 
            // BtnTmlCancel
            // 
            this.BtnTmlCancel.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnTmlCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTmlCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnTmlCancel.Location = new System.Drawing.Point(403, 542);
            this.BtnTmlCancel.Name = "BtnTmlCancel";
            this.BtnTmlCancel.Size = new System.Drawing.Size(166, 36);
            this.BtnTmlCancel.TabIndex = 4;
            this.BtnTmlCancel.Text = "TML Cancel";
            this.BtnTmlCancel.UseVisualStyleBackColor = false;
            this.BtnTmlCancel.Click += new System.EventHandler(this.BtnTmlCancel_Click);
            // 
            // FrmBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 592);
            this.Controls.Add(this.BtnTmlCancel);
            this.Controls.Add(this.BtnReprint);
            this.Controls.Add(this.BtnTmlClaim);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBarcode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBarcode";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnTmlClaim;
        private System.Windows.Forms.Button BtnReprint;
        private System.Windows.Forms.Button BtnTmlCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlotID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarcodeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrawTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mrp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cancelled;
        private System.Windows.Forms.DataGridViewTextBoxColumn Claimed;
    }
}