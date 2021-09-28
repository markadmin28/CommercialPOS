namespace POS
{
    partial class frmTempChargeInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTempChargeInvoice));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSc = new System.Windows.Forms.TextBox();
            this.txtBusiness = new System.Windows.Forms.TextBox();
            this.txtOsca = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtTerms = new System.Windows.Forms.TextBox();
            this.txtTin = new System.Windows.Forms.TextBox();
            this.txtChargeTo = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtGtotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiscAmt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDisc = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uomid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgw
            // 
            this.dgw.AllowUserToResizeColumns = false;
            this.dgw.AllowUserToResizeRows = false;
            this.dgw.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgw.BackgroundColor = System.Drawing.Color.White;
            this.dgw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgw.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qty,
            this.unit,
            this.item,
            this.unitprice,
            this.discount,
            this.total,
            this.prodID,
            this.taxM,
            this.POID,
            this.uomid});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Green;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgw.Location = new System.Drawing.Point(8, 186);
            this.dgw.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgw.MultiSelect = false;
            this.dgw.Name = "dgw";
            this.dgw.RowHeadersVisible = false;
            this.dgw.RowHeadersWidth = 5;
            this.dgw.RowTemplate.Height = 50;
            this.dgw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(974, 375);
            this.dgw.TabIndex = 9;
            this.dgw.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellContentClick);
            this.dgw.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellLeave);
            this.dgw.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellValueChanged);
            this.dgw.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgw_RowsAdded);
            this.dgw.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgw_RowsRemoved);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtSc);
            this.panel1.Controls.Add(this.txtBusiness);
            this.panel1.Controls.Add(this.txtOsca);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.txtTerms);
            this.panel1.Controls.Add(this.txtTin);
            this.panel1.Controls.Add(this.txtChargeTo);
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 167);
            this.panel1.TabIndex = 0;
            // 
            // txtSc
            // 
            this.txtSc.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSc.ForeColor = System.Drawing.Color.Navy;
            this.txtSc.Location = new System.Drawing.Point(506, 96);
            this.txtSc.Margin = new System.Windows.Forms.Padding(4);
            this.txtSc.Name = "txtSc";
            this.txtSc.Size = new System.Drawing.Size(197, 29);
            this.txtSc.TabIndex = 6;
            this.txtSc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSc_KeyDown);
            // 
            // txtBusiness
            // 
            this.txtBusiness.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusiness.ForeColor = System.Drawing.Color.Navy;
            this.txtBusiness.Location = new System.Drawing.Point(147, 125);
            this.txtBusiness.Margin = new System.Windows.Forms.Padding(4);
            this.txtBusiness.Name = "txtBusiness";
            this.txtBusiness.Size = new System.Drawing.Size(556, 29);
            this.txtBusiness.TabIndex = 7;
            this.txtBusiness.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusiness_KeyDown);
            // 
            // txtOsca
            // 
            this.txtOsca.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOsca.ForeColor = System.Drawing.Color.Navy;
            this.txtOsca.Location = new System.Drawing.Point(147, 96);
            this.txtOsca.Margin = new System.Windows.Forms.Padding(4);
            this.txtOsca.Name = "txtOsca";
            this.txtOsca.Size = new System.Drawing.Size(233, 29);
            this.txtOsca.TabIndex = 5;
            this.txtOsca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOsca_KeyDown);
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.ForeColor = System.Drawing.Color.Navy;
            this.txtAddress.Location = new System.Drawing.Point(147, 67);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(556, 29);
            this.txtAddress.TabIndex = 4;
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            // 
            // txtTerms
            // 
            this.txtTerms.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTerms.ForeColor = System.Drawing.Color.Navy;
            this.txtTerms.Location = new System.Drawing.Point(456, 38);
            this.txtTerms.Margin = new System.Windows.Forms.Padding(4);
            this.txtTerms.Name = "txtTerms";
            this.txtTerms.Size = new System.Drawing.Size(247, 29);
            this.txtTerms.TabIndex = 3;
            this.txtTerms.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTerms_KeyDown);
            // 
            // txtTin
            // 
            this.txtTin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTin.ForeColor = System.Drawing.Color.Navy;
            this.txtTin.Location = new System.Drawing.Point(147, 38);
            this.txtTin.Margin = new System.Windows.Forms.Padding(4);
            this.txtTin.Name = "txtTin";
            this.txtTin.Size = new System.Drawing.Size(233, 29);
            this.txtTin.TabIndex = 2;
            this.txtTin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTin_KeyDown);
            // 
            // txtChargeTo
            // 
            this.txtChargeTo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChargeTo.ForeColor = System.Drawing.Color.Navy;
            this.txtChargeTo.Location = new System.Drawing.Point(147, 9);
            this.txtChargeTo.Margin = new System.Windows.Forms.Padding(4);
            this.txtChargeTo.Name = "txtChargeTo";
            this.txtChargeTo.Size = new System.Drawing.Size(556, 29);
            this.txtChargeTo.TabIndex = 1;
            this.txtChargeTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChargeTo_KeyDown);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Info;
            this.textBox7.Location = new System.Drawing.Point(381, 96);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(125, 29);
            this.textBox7.TabIndex = 15;
            this.textBox7.Text = "SC/PWD Sig. :";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox7.Enter += new System.EventHandler(this.textBox7_Enter);
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Info;
            this.textBox6.Location = new System.Drawing.Point(10, 125);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(138, 29);
            this.textBox6.TabIndex = 16;
            this.textBox6.Text = "Business Style :";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox6.Enter += new System.EventHandler(this.textBox6_Enter);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Info;
            this.textBox5.Location = new System.Drawing.Point(10, 96);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(138, 29);
            this.textBox5.TabIndex = 14;
            this.textBox5.Text = "OSCA/PWD ID# :";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox5.Enter += new System.EventHandler(this.textBox5_Enter);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Info;
            this.textBox4.Location = new System.Drawing.Point(10, 67);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(138, 29);
            this.textBox4.TabIndex = 13;
            this.textBox4.Text = "Address :";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox4.Enter += new System.EventHandler(this.textBox4_Enter);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Info;
            this.textBox3.Location = new System.Drawing.Point(381, 38);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(75, 29);
            this.textBox3.TabIndex = 12;
            this.textBox3.Text = "Terms :";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox3.Enter += new System.EventHandler(this.textBox3_Enter);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Info;
            this.textBox2.Location = new System.Drawing.Point(10, 38);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(138, 29);
            this.textBox2.TabIndex = 11;
            this.textBox2.Text = "TIN :";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Location = new System.Drawing.Point(10, 9);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(138, 29);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Charge to :";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.pictureBox1.Location = new System.Drawing.Point(8, 182);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(974, 50);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(888, 581);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 31);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "&Cancel";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(714, 581);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(81, 31);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clea&r";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(801, 581);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 31);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "&Print";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtGtotal);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtDiscAmt);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(730, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 122);
            this.panel2.TabIndex = 26;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txtGtotal
            // 
            this.txtGtotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGtotal.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGtotal.ForeColor = System.Drawing.Color.Navy;
            this.txtGtotal.Location = new System.Drawing.Point(106, 72);
            this.txtGtotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtGtotal.Name = "txtGtotal";
            this.txtGtotal.Size = new System.Drawing.Size(131, 22);
            this.txtGtotal.TabIndex = 31;
            this.txtGtotal.Text = "0.00";
            this.txtGtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 21);
            this.label3.TabIndex = 30;
            this.label3.Text = "Grnd Total :";
            // 
            // txtDiscAmt
            // 
            this.txtDiscAmt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiscAmt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscAmt.ForeColor = System.Drawing.Color.Navy;
            this.txtDiscAmt.Location = new System.Drawing.Point(106, 32);
            this.txtDiscAmt.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiscAmt.Name = "txtDiscAmt";
            this.txtDiscAmt.Size = new System.Drawing.Size(131, 18);
            this.txtDiscAmt.TabIndex = 29;
            this.txtDiscAmt.Text = "0.00";
            this.txtDiscAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Discount :";
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.Navy;
            this.txtTotal.Location = new System.Drawing.Point(57, 12);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(180, 18);
            this.txtTotal.TabIndex = 27;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total :";
            // 
            // txtDisc
            // 
            this.txtDisc.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisc.ForeColor = System.Drawing.Color.Navy;
            this.txtDisc.Location = new System.Drawing.Point(840, 17);
            this.txtDisc.Margin = new System.Windows.Forms.Padding(4);
            this.txtDisc.Name = "txtDisc";
            this.txtDisc.Size = new System.Drawing.Size(142, 29);
            this.txtDisc.TabIndex = 8;
            this.txtDisc.Text = "0";
            this.txtDisc.TextChanged += new System.EventHandler(this.txtDisc_TextChanged);
            this.txtDisc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDisc_KeyPress);
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Info;
            this.textBox9.Location = new System.Drawing.Point(730, 17);
            this.textBox9.Margin = new System.Windows.Forms.Padding(4);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(111, 29);
            this.textBox9.TabIndex = 18;
            this.textBox9.Text = "Discount (%) :";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox9.Enter += new System.EventHandler(this.textBox9_Enter);
            // 
            // qty
            // 
            this.qty.HeaderText = "QTY";
            this.qty.Name = "qty";
            this.qty.Width = 80;
            // 
            // unit
            // 
            this.unit.HeaderText = "UNIT";
            this.unit.Name = "unit";
            this.unit.Width = 90;
            // 
            // item
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.item.DefaultCellStyle = dataGridViewCellStyle2;
            this.item.HeaderText = "ITEM(s)";
            this.item.Name = "item";
            this.item.Width = 350;
            // 
            // unitprice
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.unitprice.DefaultCellStyle = dataGridViewCellStyle3;
            this.unitprice.HeaderText = "PRICE";
            this.unitprice.Name = "unitprice";
            this.unitprice.Width = 120;
            // 
            // discount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.discount.DefaultCellStyle = dataGridViewCellStyle4;
            this.discount.HeaderText = "DISCOUNT/ UNT";
            this.discount.Name = "discount";
            this.discount.Width = 155;
            // 
            // total
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.total.DefaultCellStyle = dataGridViewCellStyle5;
            this.total.HeaderText = "TOTAL";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 165;
            // 
            // prodID
            // 
            this.prodID.HeaderText = "product ID";
            this.prodID.Name = "prodID";
            this.prodID.Visible = false;
            this.prodID.Width = 150;
            // 
            // taxM
            // 
            this.taxM.HeaderText = "Tax Method";
            this.taxM.Name = "taxM";
            this.taxM.Visible = false;
            this.taxM.Width = 150;
            // 
            // POID
            // 
            this.POID.HeaderText = "POID";
            this.POID.Name = "POID";
            this.POID.Visible = false;
            // 
            // uomid
            // 
            this.uomid.HeaderText = "UOMID";
            this.uomid.Name = "uomid";
            this.uomid.Visible = false;
            // 
            // frmTempChargeInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 638);
            this.Controls.Add(this.txtDisc);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgw);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmTempChargeInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temp Charge Invoice";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTempChargeInvoice_FormClosed);
            this.Load += new System.EventHandler(this.frmTempChargeInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtSc;
        public System.Windows.Forms.TextBox txtBusiness;
        public System.Windows.Forms.TextBox txtOsca;
        public System.Windows.Forms.TextBox txtAddress;
        public System.Windows.Forms.TextBox txtTerms;
        public System.Windows.Forms.TextBox txtTin;
        public System.Windows.Forms.TextBox txtChargeTo;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox txtDisc;
        private System.Windows.Forms.TextBox textBox9;
        public System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtGtotal;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtDiscAmt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodID;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxM;
        private System.Windows.Forms.DataGridViewTextBoxColumn POID;
        private System.Windows.Forms.DataGridViewTextBoxColumn uomid;
    }
}