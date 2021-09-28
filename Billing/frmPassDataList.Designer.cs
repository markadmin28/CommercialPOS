namespace POS.Billing
{
    partial class frmPassDataList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvOl = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.t = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passDataId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cusN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOl
            // 
            this.dgvOl.AllowUserToAddRows = false;
            this.dgvOl.AllowUserToDeleteRows = false;
            this.dgvOl.AllowUserToResizeColumns = false;
            this.dgvOl.AllowUserToResizeRows = false;
            this.dgvOl.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOl.BackgroundColor = System.Drawing.Color.White;
            this.dgvOl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOl.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOl.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cn,
            this.c,
            this.t,
            this.passDataId,
            this.cusN});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Green;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOl.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOl.Location = new System.Drawing.Point(6, 13);
            this.dgvOl.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgvOl.MultiSelect = false;
            this.dgvOl.Name = "dgvOl";
            this.dgvOl.ReadOnly = true;
            this.dgvOl.RowHeadersVisible = false;
            this.dgvOl.RowHeadersWidth = 5;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Green;
            this.dgvOl.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOl.RowTemplate.Height = 50;
            this.dgvOl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvOl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOl.Size = new System.Drawing.Size(649, 456);
            this.dgvOl.TabIndex = 4;
            this.dgvOl.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOl_CellContentClick);
            this.dgvOl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvOl_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.pictureBox1.Location = new System.Drawing.Point(6, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(649, 50);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 474);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(649, 35);
            this.button1.TabIndex = 23;
            this.button1.Text = "&Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cn
            // 
            this.cn.HeaderText = "Customer No.";
            this.cn.Name = "cn";
            this.cn.ReadOnly = true;
            this.cn.Width = 130;
            // 
            // c
            // 
            this.c.HeaderText = "Clerk name";
            this.c.Name = "c";
            this.c.ReadOnly = true;
            this.c.Width = 200;
            // 
            // t
            // 
            this.t.HeaderText = "Time";
            this.t.Name = "t";
            this.t.ReadOnly = true;
            this.t.Width = 120;
            // 
            // passDataId
            // 
            this.passDataId.HeaderText = "PassDataId";
            this.passDataId.Name = "passDataId";
            this.passDataId.ReadOnly = true;
            this.passDataId.Visible = false;
            // 
            // cusN
            // 
            this.cusN.HeaderText = "Customer name";
            this.cusN.Name = "cusN";
            this.cusN.ReadOnly = true;
            this.cusN.Width = 200;
            // 
            // frmPassDataList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(661, 515);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvOl);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmPassDataList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order list";
            this.Activated += new System.EventHandler(this.frmPassDataList_Activated);
            this.Load += new System.EventHandler(this.frmPassDataList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvOl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cn;
        private System.Windows.Forms.DataGridViewTextBoxColumn c;
        private System.Windows.Forms.DataGridViewTextBoxColumn t;
        private System.Windows.Forms.DataGridViewTextBoxColumn passDataId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cusN;
    }
}