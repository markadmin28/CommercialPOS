namespace POS.Inquiry
{
    partial class frmTransListDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransListDetails));
            this.dgw = new System.Windows.Forms.DataGridView();
            this.rn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vatExSale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.v = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtRecript = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.txtTransID = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.txtCashier = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.txtPosID = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.txtTotalCash = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.txtGrossSales = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.txtVAT = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.txtTotalSale = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.txtVatExSale = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.txtVatSale = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.txtTotalChange = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnVoid = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lblVoid = new System.Windows.Forms.PictureBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtGrossPayable = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVoid)).BeginInit();
            this.SuspendLayout();
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.AllowUserToResizeColumns = false;
            this.dgw.AllowUserToResizeRows = false;
            this.dgw.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgw.BackgroundColor = System.Drawing.Color.White;
            this.dgw.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rn,
            this.orNo,
            this.vs,
            this.vatExSale,
            this.ts,
            this.v,
            this.gs});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgw.Location = new System.Drawing.Point(10, 161);
            this.dgw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgw.MultiSelect = false;
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowHeadersVisible = false;
            this.dgw.RowHeadersWidth = 5;
            this.dgw.RowTemplate.Height = 21;
            this.dgw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(837, 356);
            this.dgw.TabIndex = 24;
            this.dgw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgw_KeyDown);
            // 
            // rn
            // 
            this.rn.HeaderText = "#";
            this.rn.Name = "rn";
            this.rn.ReadOnly = true;
            this.rn.Width = 35;
            // 
            // orNo
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.orNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.orNo.HeaderText = "Product description";
            this.orNo.Name = "orNo";
            this.orNo.ReadOnly = true;
            this.orNo.Width = 250;
            // 
            // vs
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "n2";
            this.vs.DefaultCellStyle = dataGridViewCellStyle3;
            this.vs.HeaderText = "Quantity";
            this.vs.Name = "vs";
            this.vs.ReadOnly = true;
            // 
            // vatExSale
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.vatExSale.DefaultCellStyle = dataGridViewCellStyle4;
            this.vatExSale.HeaderText = "Unit";
            this.vatExSale.Name = "vatExSale";
            this.vatExSale.ReadOnly = true;
            this.vatExSale.Width = 80;
            // 
            // ts
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "n2";
            this.ts.DefaultCellStyle = dataGridViewCellStyle5;
            this.ts.HeaderText = "Selling Price";
            this.ts.Name = "ts";
            this.ts.ReadOnly = true;
            this.ts.Width = 120;
            // 
            // v
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "n2";
            this.v.DefaultCellStyle = dataGridViewCellStyle6;
            this.v.HeaderText = "Discount /Item";
            this.v.Name = "v";
            this.v.ReadOnly = true;
            this.v.Width = 120;
            // 
            // gs
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "n2";
            this.gs.DefaultCellStyle = dataGridViewCellStyle7;
            this.gs.HeaderText = "Total";
            this.gs.Name = "gs";
            this.gs.ReadOnly = true;
            this.gs.Width = 130;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(10, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 25;
            this.textBox1.Text = "Date";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.Color.White;
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(109, 11);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(173, 23);
            this.txtDate.TabIndex = 26;
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.Color.White;
            this.txtTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(109, 33);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(173, 23);
            this.txtTime.TabIndex = 28;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Info;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(10, 33);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 23);
            this.textBox4.TabIndex = 27;
            this.textBox4.Text = "Time";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRecript
            // 
            this.txtRecript.BackColor = System.Drawing.Color.White;
            this.txtRecript.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecript.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecript.Location = new System.Drawing.Point(109, 55);
            this.txtRecript.Name = "txtRecript";
            this.txtRecript.ReadOnly = true;
            this.txtRecript.Size = new System.Drawing.Size(173, 23);
            this.txtRecript.TabIndex = 30;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Info;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(10, 55);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(100, 23);
            this.textBox6.TabIndex = 29;
            this.textBox6.Text = "Recript #";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTransID
            // 
            this.txtTransID.BackColor = System.Drawing.Color.White;
            this.txtTransID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransID.Location = new System.Drawing.Point(109, 121);
            this.txtTransID.Name = "txtTransID";
            this.txtTransID.ReadOnly = true;
            this.txtTransID.Size = new System.Drawing.Size(173, 23);
            this.txtTransID.TabIndex = 36;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Info;
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(10, 121);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(100, 23);
            this.textBox8.TabIndex = 35;
            this.textBox8.Text = "Transaction ID";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCashier
            // 
            this.txtCashier.BackColor = System.Drawing.Color.White;
            this.txtCashier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCashier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashier.Location = new System.Drawing.Point(109, 99);
            this.txtCashier.Name = "txtCashier";
            this.txtCashier.ReadOnly = true;
            this.txtCashier.Size = new System.Drawing.Size(173, 23);
            this.txtCashier.TabIndex = 34;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.SystemColors.Info;
            this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(10, 99);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(100, 23);
            this.textBox10.TabIndex = 33;
            this.textBox10.Text = "Cashier";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPosID
            // 
            this.txtPosID.BackColor = System.Drawing.Color.White;
            this.txtPosID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPosID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosID.Location = new System.Drawing.Point(109, 77);
            this.txtPosID.Name = "txtPosID";
            this.txtPosID.ReadOnly = true;
            this.txtPosID.Size = new System.Drawing.Size(173, 23);
            this.txtPosID.TabIndex = 32;
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.SystemColors.Info;
            this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(10, 77);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(100, 23);
            this.textBox12.TabIndex = 31;
            this.textBox12.Text = "POS ID";
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalCash
            // 
            this.txtTotalCash.BackColor = System.Drawing.Color.White;
            this.txtTotalCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalCash.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCash.Location = new System.Drawing.Point(674, 84);
            this.txtTotalCash.Name = "txtTotalCash";
            this.txtTotalCash.ReadOnly = true;
            this.txtTotalCash.Size = new System.Drawing.Size(173, 23);
            this.txtTotalCash.TabIndex = 48;
            // 
            // textBox14
            // 
            this.textBox14.BackColor = System.Drawing.SystemColors.Info;
            this.textBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.Location = new System.Drawing.Point(575, 84);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(100, 23);
            this.textBox14.TabIndex = 47;
            this.textBox14.Text = "Total Cash";
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtGrossSales
            // 
            this.txtGrossSales.BackColor = System.Drawing.Color.White;
            this.txtGrossSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGrossSales.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrossSales.Location = new System.Drawing.Point(674, 62);
            this.txtGrossSales.Name = "txtGrossSales";
            this.txtGrossSales.ReadOnly = true;
            this.txtGrossSales.Size = new System.Drawing.Size(173, 23);
            this.txtGrossSales.TabIndex = 46;
            // 
            // textBox16
            // 
            this.textBox16.BackColor = System.Drawing.SystemColors.Info;
            this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.Location = new System.Drawing.Point(575, 62);
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(100, 23);
            this.textBox16.TabIndex = 45;
            this.textBox16.Text = "Gross Sales";
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVAT
            // 
            this.txtVAT.BackColor = System.Drawing.Color.White;
            this.txtVAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVAT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVAT.Location = new System.Drawing.Point(391, 77);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.ReadOnly = true;
            this.txtVAT.Size = new System.Drawing.Size(173, 23);
            this.txtVAT.TabIndex = 44;
            // 
            // textBox18
            // 
            this.textBox18.BackColor = System.Drawing.SystemColors.Info;
            this.textBox18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox18.Location = new System.Drawing.Point(292, 77);
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(100, 23);
            this.textBox18.TabIndex = 43;
            this.textBox18.Text = "VAT";
            this.textBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalSale
            // 
            this.txtTotalSale.BackColor = System.Drawing.Color.White;
            this.txtTotalSale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalSale.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSale.Location = new System.Drawing.Point(391, 55);
            this.txtTotalSale.Name = "txtTotalSale";
            this.txtTotalSale.ReadOnly = true;
            this.txtTotalSale.Size = new System.Drawing.Size(173, 23);
            this.txtTotalSale.TabIndex = 42;
            // 
            // textBox20
            // 
            this.textBox20.BackColor = System.Drawing.SystemColors.Info;
            this.textBox20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox20.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox20.Location = new System.Drawing.Point(292, 55);
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new System.Drawing.Size(100, 23);
            this.textBox20.TabIndex = 41;
            this.textBox20.Text = "Total Sale";
            this.textBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVatExSale
            // 
            this.txtVatExSale.BackColor = System.Drawing.Color.White;
            this.txtVatExSale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVatExSale.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVatExSale.Location = new System.Drawing.Point(391, 33);
            this.txtVatExSale.Name = "txtVatExSale";
            this.txtVatExSale.ReadOnly = true;
            this.txtVatExSale.Size = new System.Drawing.Size(173, 23);
            this.txtVatExSale.TabIndex = 40;
            // 
            // textBox22
            // 
            this.textBox22.BackColor = System.Drawing.SystemColors.Info;
            this.textBox22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox22.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox22.Location = new System.Drawing.Point(292, 33);
            this.textBox22.Name = "textBox22";
            this.textBox22.ReadOnly = true;
            this.textBox22.Size = new System.Drawing.Size(100, 23);
            this.textBox22.TabIndex = 39;
            this.textBox22.Text = "Vat Exempt Sale";
            this.textBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVatSale
            // 
            this.txtVatSale.BackColor = System.Drawing.Color.White;
            this.txtVatSale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVatSale.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVatSale.Location = new System.Drawing.Point(391, 11);
            this.txtVatSale.Name = "txtVatSale";
            this.txtVatSale.ReadOnly = true;
            this.txtVatSale.Size = new System.Drawing.Size(173, 23);
            this.txtVatSale.TabIndex = 38;
            // 
            // textBox24
            // 
            this.textBox24.BackColor = System.Drawing.SystemColors.Info;
            this.textBox24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox24.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox24.Location = new System.Drawing.Point(292, 11);
            this.textBox24.Name = "textBox24";
            this.textBox24.ReadOnly = true;
            this.textBox24.Size = new System.Drawing.Size(100, 23);
            this.textBox24.TabIndex = 37;
            this.textBox24.Text = "Vat Sale";
            this.textBox24.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalChange
            // 
            this.txtTotalChange.BackColor = System.Drawing.Color.White;
            this.txtTotalChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalChange.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalChange.Location = new System.Drawing.Point(674, 121);
            this.txtTotalChange.Name = "txtTotalChange";
            this.txtTotalChange.ReadOnly = true;
            this.txtTotalChange.Size = new System.Drawing.Size(173, 23);
            this.txtTotalChange.TabIndex = 50;
            // 
            // textBox26
            // 
            this.textBox26.BackColor = System.Drawing.SystemColors.Info;
            this.textBox26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox26.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox26.Location = new System.Drawing.Point(575, 121);
            this.textBox26.Name = "textBox26";
            this.textBox26.ReadOnly = true;
            this.textBox26.Size = new System.Drawing.Size(100, 23);
            this.textBox26.TabIndex = 49;
            this.textBox26.Text = "Total Change";
            this.textBox26.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(757, 522);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 31);
            this.button1.TabIndex = 51;
            this.button1.Text = "&Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnVoid
            // 
            this.btnVoid.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVoid.Image = ((System.Drawing.Image)(resources.GetObject("btnVoid.Image")));
            this.btnVoid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoid.Location = new System.Drawing.Point(661, 522);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(90, 31);
            this.btnVoid.TabIndex = 52;
            this.btnVoid.Text = "Voi&d";
            this.btnVoid.UseVisualStyleBackColor = true;
            this.btnVoid.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(565, 522);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 31);
            this.button3.TabIndex = 53;
            this.button3.Text = "&Print";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblVoid
            // 
            this.lblVoid.BackColor = System.Drawing.Color.White;
            this.lblVoid.Image = ((System.Drawing.Image)(resources.GetObject("lblVoid.Image")));
            this.lblVoid.Location = new System.Drawing.Point(229, 241);
            this.lblVoid.Name = "lblVoid";
            this.lblVoid.Size = new System.Drawing.Size(410, 210);
            this.lblVoid.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lblVoid.TabIndex = 55;
            this.lblVoid.TabStop = false;
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackColor = System.Drawing.Color.White;
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(391, 121);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(173, 23);
            this.txtDiscount.TabIndex = 59;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Info;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(292, 121);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 23);
            this.textBox3.TabIndex = 58;
            this.textBox3.Text = "Discount";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtGrossPayable
            // 
            this.txtGrossPayable.BackColor = System.Drawing.Color.White;
            this.txtGrossPayable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGrossPayable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrossPayable.Location = new System.Drawing.Point(391, 99);
            this.txtGrossPayable.Name = "txtGrossPayable";
            this.txtGrossPayable.ReadOnly = true;
            this.txtGrossPayable.Size = new System.Drawing.Size(173, 23);
            this.txtGrossPayable.TabIndex = 57;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Info;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(292, 99);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(100, 23);
            this.textBox7.TabIndex = 56;
            this.textBox7.Text = "Gross Payable";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmTransListDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 563);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txtGrossPayable);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.lblVoid);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnVoid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTotalChange);
            this.Controls.Add(this.textBox26);
            this.Controls.Add(this.txtTotalCash);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.txtGrossSales);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.txtVAT);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.txtTotalSale);
            this.Controls.Add(this.textBox20);
            this.Controls.Add(this.txtVatExSale);
            this.Controls.Add(this.textBox22);
            this.Controls.Add(this.txtVatSale);
            this.Controls.Add(this.textBox24);
            this.Controls.Add(this.txtTransID);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.txtCashier);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.txtPosID);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.txtRecript);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgw);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmTransListDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction details";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTransListDetails_FormClosed);
            this.Load += new System.EventHandler(this.frmTransListDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVoid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.TextBox textBox26;
        public System.Windows.Forms.TextBox txtDate;
        public System.Windows.Forms.TextBox txtTime;
        public System.Windows.Forms.TextBox txtRecript;
        public System.Windows.Forms.TextBox txtTransID;
        public System.Windows.Forms.TextBox txtCashier;
        public System.Windows.Forms.TextBox txtPosID;
        public System.Windows.Forms.TextBox txtTotalCash;
        public System.Windows.Forms.TextBox txtGrossSales;
        public System.Windows.Forms.TextBox txtVAT;
        public System.Windows.Forms.TextBox txtTotalSale;
        public System.Windows.Forms.TextBox txtVatExSale;
        public System.Windows.Forms.TextBox txtVatSale;
        public System.Windows.Forms.TextBox txtTotalChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn rn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn vs;
        private System.Windows.Forms.DataGridViewTextBoxColumn vatExSale;
        private System.Windows.Forms.DataGridViewTextBoxColumn ts;
        private System.Windows.Forms.DataGridViewTextBoxColumn v;
        private System.Windows.Forms.DataGridViewTextBoxColumn gs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnVoid;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox lblVoid;
        public System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox txtGrossPayable;
        private System.Windows.Forms.TextBox textBox7;
    }
}