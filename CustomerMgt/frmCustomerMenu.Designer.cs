namespace POS.CustomerMgt
{
    partial class frmCustomerMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerMenu));
            this.btnCusReg = new System.Windows.Forms.Button();
            this.btnDiscList = new System.Windows.Forms.Button();
            this.btnSetDisc = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCusReg
            // 
            this.btnCusReg.BackColor = System.Drawing.SystemColors.Control;
            this.btnCusReg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCusReg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCusReg.Image = ((System.Drawing.Image)(resources.GetObject("btnCusReg.Image")));
            this.btnCusReg.Location = new System.Drawing.Point(16, 13);
            this.btnCusReg.Name = "btnCusReg";
            this.btnCusReg.Size = new System.Drawing.Size(118, 70);
            this.btnCusReg.TabIndex = 0;
            this.btnCusReg.Text = "Customer reg";
            this.btnCusReg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCusReg.UseVisualStyleBackColor = false;
            this.btnCusReg.Click += new System.EventHandler(this.btnTransactionList_Click);
            this.btnCusReg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCusReg_KeyDown);
            // 
            // btnDiscList
            // 
            this.btnDiscList.BackColor = System.Drawing.SystemColors.Control;
            this.btnDiscList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiscList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDiscList.Image = ((System.Drawing.Image)(resources.GetObject("btnDiscList.Image")));
            this.btnDiscList.Location = new System.Drawing.Point(286, 12);
            this.btnDiscList.Name = "btnDiscList";
            this.btnDiscList.Size = new System.Drawing.Size(118, 70);
            this.btnDiscList.TabIndex = 2;
            this.btnDiscList.Text = "Discount List";
            this.btnDiscList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDiscList.UseVisualStyleBackColor = false;
            this.btnDiscList.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSetDisc
            // 
            this.btnSetDisc.BackColor = System.Drawing.SystemColors.Control;
            this.btnSetDisc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetDisc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSetDisc.Image = ((System.Drawing.Image)(resources.GetObject("btnSetDisc.Image")));
            this.btnSetDisc.Location = new System.Drawing.Point(422, 12);
            this.btnSetDisc.Name = "btnSetDisc";
            this.btnSetDisc.Size = new System.Drawing.Size(118, 70);
            this.btnSetDisc.TabIndex = 3;
            this.btnSetDisc.Text = "Set discounts";
            this.btnSetDisc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSetDisc.UseVisualStyleBackColor = false;
            this.btnSetDisc.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(152, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 70);
            this.button1.TabIndex = 1;
            this.button1.Text = "Charge Invoice";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // frmCustomerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(556, 101);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSetDisc);
            this.Controls.Add(this.btnDiscList);
            this.Controls.Add(this.btnCusReg);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCustomerMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer management menu";
            this.Load += new System.EventHandler(this.frmCustomerMenu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCustomerMenu_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnCusReg;
        public System.Windows.Forms.Button btnDiscList;
        public System.Windows.Forms.Button btnSetDisc;
        public System.Windows.Forms.Button button1;
    }
}