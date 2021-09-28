namespace POS.Receipt
{
    partial class frmRptReceipt
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptReceipt));
            this.customerReceiptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.posDBDataSet = new POS.posDBDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.customerReceiptTableAdapter = new POS.posDBDataSetTableAdapters.customerReceiptTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.customerReceiptBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // customerReceiptBindingSource
            // 
            this.customerReceiptBindingSource.DataMember = "customerReceipt";
            this.customerReceiptBindingSource.DataSource = this.posDBDataSet;
            // 
            // posDBDataSet
            // 
            this.posDBDataSet.DataSetName = "posDBDataSet";
            this.posDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "customerReceiptDs";
            reportDataSource1.Value = this.customerReceiptBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS.Receipt.rptReceipt.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(525, 334);
            this.reportViewer1.TabIndex = 0;
            // 
            // customerReceiptTableAdapter
            // 
            this.customerReceiptTableAdapter.ClearBeforeFill = true;
            // 
            // frmRptReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 334);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptReceipt";
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRptReceipt_FormClosed);
            this.Load += new System.EventHandler(this.frmRptReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerReceiptBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource customerReceiptBindingSource;
        private posDBDataSet posDBDataSet;
        private posDBDataSetTableAdapters.customerReceiptTableAdapter customerReceiptTableAdapter;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}