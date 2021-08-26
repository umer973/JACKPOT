namespace Jackport
{
    partial class UserInputControl
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
            this.LabelName = new System.Windows.Forms.Label();
            this.TxtQty = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LabelName
            // 
            this.LabelName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelName.AutoSize = true;
            this.LabelName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelName.ForeColor = System.Drawing.Color.White;
            this.LabelName.Location = new System.Drawing.Point(14, -4);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(27, 19);
            this.LabelName.TabIndex = 265;
            this.LabelName.Text = "00";
            this.LabelName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TxtQty
            // 
            this.TxtQty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtQty.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQty.ForeColor = System.Drawing.Color.White;
            this.TxtQty.Location = new System.Drawing.Point(0, 18);
            this.TxtQty.MaxLength = 2;
            this.TxtQty.Multiline = true;
            this.TxtQty.Name = "TxtQty";
            this.TxtQty.Size = new System.Drawing.Size(61, 32);
            this.TxtQty.TabIndex = 264;
            this.TxtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtQty.TextChanged += new System.EventHandler(this.TxtQty_TextChanged);
            this.TxtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtQty_KeyPress);
            this.TxtQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtQty_KeyUp);
            // 
            // UserInputControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.TxtQty);
            this.Name = "UserInputControl";
            this.Size = new System.Drawing.Size(60, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.TextBox TxtQty;
    }
}
