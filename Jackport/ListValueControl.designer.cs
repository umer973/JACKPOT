namespace Jackport
{
    partial class ListValueControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblTime = new System.Windows.Forms.Label();
            this.BtnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblTime
            // 
            this.LblTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.LblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblTime.Location = new System.Drawing.Point(0, 70);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(91, 27);
            this.LblTime.TabIndex = 1;
            this.LblTime.Text = "00:00:10";
            this.LblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSubmit.Location = new System.Drawing.Point(-2, -2);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(93, 72);
            this.BtnSubmit.TabIndex = 2;
            this.BtnSubmit.Text = "72";
            this.BtnSubmit.UseVisualStyleBackColor = true;
            // 
            // ListValueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.BtnSubmit);
            this.Controls.Add(this.LblTime);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ListValueControl";
            this.Size = new System.Drawing.Size(89, 96);
            this.Load += new System.EventHandler(this.ListValueControl_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.Button BtnSubmit;
    }
}
