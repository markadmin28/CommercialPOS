namespace POS
{
    partial class frmRptExpiredProducts
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.posDBDataSet = new POS.posDBDataSet();
            this.sp_prodExpiredProductsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_prodExpiredProductsTableAdapter = new POS.posDBDataSetTableAdapters.sp_prodExpiredProductsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.posDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_prodExpiredProductsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "expiredProducftsDS";
            reportDataSource2.Value = this.sp_prodExpiredProductsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS.rptExpiredProducts.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(594, 322);
            this.reportViewer1.TabIndex = 0;
            // 
            // posDBDataSet
            // 
            this.posDBDataSet.DataSetName = "posDBDataSet";
            this.posDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_prodExpiredProductsBindingSource
            // 
            this.sp_prodExpiredProductsBindingSource.DataMember = "sp_prodExpiredProducts";
            this.sp_prodExpiredProductsBindingSource.DataSource = this.posDBDataSet;
            // 
            // sp_prodExpiredProductsTableAdapter
            // 
            this.sp_prodExpiredProductsTableAdapter.ClearBeforeFill = true;
            // 
            // frmRptExpiredProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 322);
            this.Controls.Add(this.reportViewer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRptExpiredProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expired Products Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRptExpiredProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.posDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_prodExpiredProductsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_prodExpiredProductsBindingSource;
        private posDBDataSet posDBDataSet;
        private posDBDataSetTableAdapters.sp_prodExpiredProductsTableAdapter sp_prodExpiredProductsTableAdapter;
    }
}