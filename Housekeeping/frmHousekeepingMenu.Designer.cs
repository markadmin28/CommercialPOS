namespace POS.Housekeeping
{
    partial class frmHousekeepingMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHousekeepingMenu));
            this.btnChangeFund = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChangeFund
            // 
            this.btnChangeFund.BackColor = System.Drawing.SystemColors.Control;
            this.btnChangeFund.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeFund.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChangeFund.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeFund.Image")));
            this.btnChangeFund.Location = new System.Drawing.Point(17, 15);
            this.btnChangeFund.Name = "btnChangeFund";
            this.btnChangeFund.Size = new System.Drawing.Size(118, 70);
            this.btnChangeFund.TabIndex = 8;
            this.btnChangeFund.Text = "Daily change funds";
            this.btnChangeFund.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnChangeFund.UseVisualStyleBackColor = false;
            this.btnChangeFund.Click += new System.EventHandler(this.btnCashFund_Click);
            // 
            // frmHousekeepingMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(422, 101);
            this.Controls.Add(this.btnChangeFund);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmHousekeepingMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Housekeeping Menu";
            this.Load += new System.EventHandler(this.frmHousekeepingMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnChangeFund;
    }
}