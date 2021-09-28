namespace POS.POSMaintenance
{
    partial class frmInitializeDecision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInitializeDecision));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnIn = new System.Windows.Forms.RadioButton();
            this.rbtnOut = new System.Windows.Forms.RadioButton();
            this.rbtnInOut = new System.Windows.Forms.RadioButton();
            this.rbtnSales = new System.Windows.Forms.RadioButton();
            this.rbtnSalesInventory = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnSalesInventory);
            this.groupBox1.Controls.Add(this.rbtnSales);
            this.groupBox1.Controls.Add(this.rbtnInOut);
            this.groupBox1.Controls.Add(this.rbtnOut);
            this.groupBox1.Controls.Add(this.rbtnIn);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Specific data to initialize";
            // 
            // rbtnIn
            // 
            this.rbtnIn.AutoSize = true;
            this.rbtnIn.Location = new System.Drawing.Point(20, 32);
            this.rbtnIn.Name = "rbtnIn";
            this.rbtnIn.Size = new System.Drawing.Size(153, 21);
            this.rbtnIn.TabIndex = 0;
            this.rbtnIn.TabStop = true;
            this.rbtnIn.Text = "Product Inventory (IN)";
            this.rbtnIn.UseVisualStyleBackColor = true;
            // 
            // rbtnOut
            // 
            this.rbtnOut.AutoSize = true;
            this.rbtnOut.Location = new System.Drawing.Point(20, 59);
            this.rbtnOut.Name = "rbtnOut";
            this.rbtnOut.Size = new System.Drawing.Size(166, 21);
            this.rbtnOut.TabIndex = 1;
            this.rbtnOut.TabStop = true;
            this.rbtnOut.Text = "Product Inventory (OUT)";
            this.rbtnOut.UseVisualStyleBackColor = true;
            // 
            // rbtnInOut
            // 
            this.rbtnInOut.AutoSize = true;
            this.rbtnInOut.Location = new System.Drawing.Point(20, 86);
            this.rbtnInOut.Name = "rbtnInOut";
            this.rbtnInOut.Size = new System.Drawing.Size(197, 21);
            this.rbtnInOut.TabIndex = 2;
            this.rbtnInOut.TabStop = true;
            this.rbtnInOut.Text = "Product Inventory (IN && OUT)";
            this.rbtnInOut.UseVisualStyleBackColor = true;
            // 
            // rbtnSales
            // 
            this.rbtnSales.AutoSize = true;
            this.rbtnSales.Location = new System.Drawing.Point(20, 113);
            this.rbtnSales.Name = "rbtnSales";
            this.rbtnSales.Size = new System.Drawing.Size(105, 21);
            this.rbtnSales.TabIndex = 3;
            this.rbtnSales.TabStop = true;
            this.rbtnSales.Text = "Product Sales";
            this.rbtnSales.UseVisualStyleBackColor = true;
            // 
            // rbtnSalesInventory
            // 
            this.rbtnSalesInventory.AutoSize = true;
            this.rbtnSalesInventory.Location = new System.Drawing.Point(20, 140);
            this.rbtnSalesInventory.Name = "rbtnSalesInventory";
            this.rbtnSalesInventory.Size = new System.Drawing.Size(176, 21);
            this.rbtnSalesInventory.TabIndex = 4;
            this.rbtnSalesInventory.TabStop = true;
            this.rbtnSalesInventory.Text = "Product Sales && Inventory";
            this.rbtnSalesInventory.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(256, 200);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 31);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Initialize";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(351, 200);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 31);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "&Close";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmInitializeDecision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 239);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmInitializeDecision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Initialize product inventory & sales information";
            this.Load += new System.EventHandler(this.frmInitializeDecision_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnSalesInventory;
        private System.Windows.Forms.RadioButton rbtnSales;
        private System.Windows.Forms.RadioButton rbtnInOut;
        private System.Windows.Forms.RadioButton rbtnOut;
        private System.Windows.Forms.RadioButton rbtnIn;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnSave;
    }
}