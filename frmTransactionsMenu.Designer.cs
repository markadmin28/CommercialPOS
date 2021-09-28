namespace POS
{
    partial class frmTransactionsMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransactionsMenu));
            this.btnBilling = new System.Windows.Forms.Button();
            this.btnCI = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBilling
            // 
            this.btnBilling.BackColor = System.Drawing.SystemColors.Control;
            this.btnBilling.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBilling.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBilling.Image = ((System.Drawing.Image)(resources.GetObject("btnBilling.Image")));
            this.btnBilling.Location = new System.Drawing.Point(12, 12);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(118, 77);
            this.btnBilling.TabIndex = 1;
            this.btnBilling.Text = "Billing";
            this.btnBilling.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBilling.UseVisualStyleBackColor = false;
            this.btnBilling.Click += new System.EventHandler(this.btnCusReg_Click);
            // 
            // btnCI
            // 
            this.btnCI.BackColor = System.Drawing.SystemColors.Control;
            this.btnCI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCI.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCI.Image = ((System.Drawing.Image)(resources.GetObject("btnCI.Image")));
            this.btnCI.Location = new System.Drawing.Point(149, 12);
            this.btnCI.Name = "btnCI";
            this.btnCI.Size = new System.Drawing.Size(118, 77);
            this.btnCI.TabIndex = 2;
            this.btnCI.Text = "Temp\r\nCharge Invoice";
            this.btnCI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCI.UseVisualStyleBackColor = false;
            this.btnCI.Click += new System.EventHandler(this.btnCI_Click);
            // 
            // frmTransactionsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(486, 101);
            this.Controls.Add(this.btnCI);
            this.Controls.Add(this.btnBilling);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmTransactionsMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transactions Menu";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnBilling;
        public System.Windows.Forms.Button btnCI;
    }
}