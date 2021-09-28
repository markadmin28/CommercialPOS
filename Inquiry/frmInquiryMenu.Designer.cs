namespace POS.Inquiry
{
    partial class frmInquiryMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInquiryMenu));
            this.btnTransactionList = new System.Windows.Forms.Button();
            this.btnTransSumRep = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTransactionList
            // 
            this.btnTransactionList.BackColor = System.Drawing.SystemColors.Control;
            this.btnTransactionList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransactionList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTransactionList.Image = ((System.Drawing.Image)(resources.GetObject("btnTransactionList.Image")));
            this.btnTransactionList.Location = new System.Drawing.Point(12, 12);
            this.btnTransactionList.Name = "btnTransactionList";
            this.btnTransactionList.Size = new System.Drawing.Size(118, 77);
            this.btnTransactionList.TabIndex = 4;
            this.btnTransactionList.Text = "Transaction List";
            this.btnTransactionList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTransactionList.UseVisualStyleBackColor = false;
            this.btnTransactionList.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnTransSumRep
            // 
            this.btnTransSumRep.BackColor = System.Drawing.SystemColors.Control;
            this.btnTransSumRep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransSumRep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTransSumRep.Image = ((System.Drawing.Image)(resources.GetObject("btnTransSumRep.Image")));
            this.btnTransSumRep.Location = new System.Drawing.Point(288, 12);
            this.btnTransSumRep.Name = "btnTransSumRep";
            this.btnTransSumRep.Size = new System.Drawing.Size(118, 77);
            this.btnTransSumRep.TabIndex = 6;
            this.btnTransSumRep.Text = "Transaction Summary";
            this.btnTransSumRep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTransSumRep.UseVisualStyleBackColor = false;
            this.btnTransSumRep.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(422, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 77);
            this.button1.TabIndex = 7;
            this.button1.Text = "Clerk Report";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(149, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 77);
            this.button2.TabIndex = 5;
            this.button2.Text = "Product Transaction";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // frmInquiryMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(553, 101);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTransSumRep);
            this.Controls.Add(this.btnTransactionList);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmInquiryMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inquiry menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInquiryMenu_FormClosed);
            this.Load += new System.EventHandler(this.frmInquiryMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnTransactionList;
        public System.Windows.Forms.Button btnTransSumRep;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
    }
}