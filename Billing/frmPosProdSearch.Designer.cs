namespace POS.Billing
{
    partial class frmPosProdSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPosProdSearch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.txtItems = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.catID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.de = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.AllowUserToResizeColumns = false;
            this.dgw.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            this.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgw.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgw.BackgroundColor = System.Drawing.Color.White;
            this.dgw.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgw.ColumnHeadersHeight = 25;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.catID,
            this.catDesc,
            this.de,
            this.pde});
            this.dgw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgw.Location = new System.Drawing.Point(3, 42);
            this.dgw.Margin = new System.Windows.Forms.Padding(2);
            this.dgw.MultiSelect = false;
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgw.RowHeadersVisible = false;
            this.dgw.RowHeadersWidth = 30;
            this.dgw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(579, 516);
            this.dgw.TabIndex = 2;
            this.dgw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgw_KeyDown);
            this.dgw.Leave += new System.EventHandler(this.dgw_Leave);
            // 
            // txtItems
            // 
            this.txtItems.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtItems.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItems.Location = new System.Drawing.Point(3, 8);
            this.txtItems.Name = "txtItems";
            this.txtItems.Size = new System.Drawing.Size(413, 29);
            this.txtItems.TabIndex = 0;
            this.txtItems.TextChanged += new System.EventHandler(this.txtUomDesc_TextChanged);
            this.txtItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUomDesc_KeyDown);
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblRows});
            this.statusStrip.Location = new System.Drawing.Point(0, 558);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(586, 24);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(48, 19);
            this.toolStripStatusLabel1.Text = "Rows :";
            // 
            // lblRows
            // 
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(17, 19);
            this.lblRows.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(415, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // catID
            // 
            this.catID.HeaderText = "Product ID";
            this.catID.Name = "catID";
            this.catID.ReadOnly = true;
            // 
            // catDesc
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.catDesc.DefaultCellStyle = dataGridViewCellStyle2;
            this.catDesc.HeaderText = "Product Descrition";
            this.catDesc.Name = "catDesc";
            this.catDesc.ReadOnly = true;
            this.catDesc.Width = 348;
            // 
            // de
            // 
            this.de.HeaderText = "Date expired";
            this.de.Name = "de";
            this.de.ReadOnly = true;
            this.de.Width = 113;
            // 
            // pde
            // 
            this.pde.HeaderText = "PDE";
            this.pde.Name = "pde";
            this.pde.ReadOnly = true;
            this.pde.Visible = false;
            // 
            // frmPosProdSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 582);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.txtItems);
            this.Controls.Add(this.dgw);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPosProdSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search product";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPosProdSearch_FormClosed);
            this.Load += new System.EventHandler(this.frmPosProdSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.TextBox txtItems;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRows;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn catID;
        private System.Windows.Forms.DataGridViewTextBoxColumn catDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn de;
        private System.Windows.Forms.DataGridViewTextBoxColumn pde;
    }
}