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
            this.BtnSubmit = new System.Windows.Forms.Button();
            this.LblTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSubmit.ForeColor = System.Drawing.Color.Black;
            this.BtnSubmit.Location = new System.Drawing.Point(1, 0);
            this.BtnSubmit.Margin = new System.Windows.Forms.Padding(0);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(77, 52);
            this.BtnSubmit.TabIndex = 2;
            this.BtnSubmit.Text = "72";
            this.BtnSubmit.UseVisualStyleBackColor = true;
            // 
            // LblTime
            // 
            this.LblTime.BackColor = System.Drawing.Color.Black;
            this.LblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTime.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTime.ForeColor = System.Drawing.Color.White;
            this.LblTime.Location = new System.Drawing.Point(1, 53);
            this.LblTime.Margin = new System.Windows.Forms.Padding(0);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(77, 21);
            this.LblTime.TabIndex = 1;
            this.LblTime.Text = "00:00:00";
            this.LblTime.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // ListValueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.BtnSubmit);
            this.Controls.Add(this.LblTime);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ListValueControl";
            this.Size = new System.Drawing.Size(80, 74);
            this.Load += new System.EventHandler(this.ListValueControl_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnSubmit;
        private System.Windows.Forms.Label LblTime;
    }
}
