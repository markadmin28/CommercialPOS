namespace POS.SysMaintenance
{
    partial class frmSysMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysMaintenance));
            this.btnDbConfig = new System.Windows.Forms.Button();
            this.btnRestoreDb = new System.Windows.Forms.Button();
            this.btnBackupDb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDbConfig
            // 
            this.btnDbConfig.BackColor = System.Drawing.SystemColors.Control;
            this.btnDbConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDbConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDbConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnDbConfig.Image")));
            this.btnDbConfig.Location = new System.Drawing.Point(12, 12);
            this.btnDbConfig.Name = "btnDbConfig";
            this.btnDbConfig.Size = new System.Drawing.Size(118, 74);
            this.btnDbConfig.TabIndex = 5;
            this.btnDbConfig.Text = "Database configuration";
            this.btnDbConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDbConfig.UseVisualStyleBackColor = false;
            this.btnDbConfig.Click += new System.EventHandler(this.btnInventoryReport_Click);
            // 
            // btnRestoreDb
            // 
            this.btnRestoreDb.BackColor = System.Drawing.SystemColors.Control;
            this.btnRestoreDb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestoreDb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRestoreDb.Image = ((System.Drawing.Image)(resources.GetObject("btnRestoreDb.Image")));
            this.btnRestoreDb.Location = new System.Drawing.Point(156, 12);
            this.btnRestoreDb.Name = "btnRestoreDb";
            this.btnRestoreDb.Size = new System.Drawing.Size(118, 74);
            this.btnRestoreDb.TabIndex = 6;
            this.btnRestoreDb.Text = "Restore Database";
            this.btnRestoreDb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRestoreDb.UseVisualStyleBackColor = false;
            this.btnRestoreDb.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBackupDb
            // 
            this.btnBackupDb.BackColor = System.Drawing.SystemColors.Control;
            this.btnBackupDb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackupDb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBackupDb.Image = ((System.Drawing.Image)(resources.GetObject("btnBackupDb.Image")));
            this.btnBackupDb.Location = new System.Drawing.Point(298, 12);
            this.btnBackupDb.Name = "btnBackupDb";
            this.btnBackupDb.Size = new System.Drawing.Size(118, 74);
            this.btnBackupDb.TabIndex = 7;
            this.btnBackupDb.Text = "Backup\r\nDatabase";
            this.btnBackupDb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBackupDb.UseVisualStyleBackColor = false;
            this.btnBackupDb.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmSysMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(429, 101);
            this.Controls.Add(this.btnBackupDb);
            this.Controls.Add(this.btnRestoreDb);
            this.Controls.Add(this.btnDbConfig);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmSysMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Maintenance Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSysMaintenance_FormClosed);
            this.Load += new System.EventHandler(this.frmSysMaintenance_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnDbConfig;
        public System.Windows.Forms.Button btnRestoreDb;
        public System.Windows.Forms.Button btnBackupDb;
    }
}