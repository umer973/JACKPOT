﻿namespace Jackport
{
    partial class FrmTMLPrint
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnTmlClaim = new System.Windows.Forms.Button();
            this.BtnReprint = new System.Windows.Forms.Button();
            this.BtnTmlCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 539);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date";
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
            // 
            // FrmTMLPrint
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
            this.Name = "FrmTMLPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBarcode";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnTmlClaim;
        private System.Windows.Forms.Button BtnReprint;
        private System.Windows.Forms.Button BtnTmlCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}