namespace POS
{
    partial class frmRptProdExp
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
            this.sp_prodExpiredProductsDisplayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.posDBDataSet = new POS.posDBDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_prodExpiredProductsDisplayTableAdapter = new POS.posDBDataSetTableAdapters.sp_prodExpiredProductsDisplayTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sp_prodExpiredProductsDisplayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_prodExpiredProductsDisplayBindingSource
            // 
            this.sp_prodExpiredProductsDisplayBindingSource.DataMember = "sp_prodExpiredProductsDisplay";
            this.sp_prodExpiredProductsDisplayBindingSource.DataSource = this.posDBDataSet;
            // 
            // posDBDataSet
            // 
            this.posDBDataSet.DataSetName = "posDBDataSet";
            this.posDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "propExpDS";
            reportDataSource1.Value = this.sp_prodExpiredProductsDisplayBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS.rptProdExp.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(649, 284);
            this.reportViewer1.TabIndex = 0;
            // 
            // sp_prodExpiredProductsDisplayTableAdapter
            // 
            this.sp_prodExpiredProductsDisplayTableAdapter.ClearBeforeFill = true;
            // 
            // frmRptProdExp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 284);
            this.Controls.Add(this.reportViewer1);
            this.DoubleBuffered = true;
            this.Name = "frmRptProdExp";
            this.Text = "Product Expiration Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRptProdExp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_prodExpiredProductsDisplayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_prodExpiredProductsDisplayBindingSource;
        private posDBDataSet posDBDataSet;
        private posDBDataSetTableAdapters.sp_prodExpiredProductsDisplayTableAdapter sp_prodExpiredProductsDisplayTableAdapter;
    }
}