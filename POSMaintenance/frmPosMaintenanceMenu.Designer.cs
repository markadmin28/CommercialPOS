namespace POS.POSMaintenance
{
    partial class frmPosMaintenanceMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPosMaintenanceMenu));
            this.btnInInv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInInv
            // 
            this.btnInInv.BackColor = System.Drawing.SystemColors.Control;
            this.btnInInv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInInv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInInv.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInInv.Image = ((System.Drawing.Image)(resources.GetObject("btnInInv.Image")));
            this.btnInInv.Location = new System.Drawing.Point(12, 12);
            this.btnInInv.Name = "btnInInv";
            this.btnInInv.Size = new System.Drawing.Size(153, 88);
            this.btnInInv.TabIndex = 0;
            this.btnInInv.Text = "Initialize Product\r\nInventory && Sales Info";
            this.btnInInv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnInInv.UseVisualStyleBackColor = false;
            this.btnInInv.Click += new System.EventHandler(this.btnInInv_Click);
            // 
            // frmPosMaintenanceMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(473, 112);
            this.Controls.Add(this.btnInInv);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmPosMaintenanceMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POS Maintenance";
            this.Load += new System.EventHandler(this.frmPosMaintenanceMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnInInv;
    }
}