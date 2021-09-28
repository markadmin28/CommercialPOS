using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

using System.IO;
using System.Globalization;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections.Specialized;

namespace POS.Billing.ChargeInvoice
{
    public partial class frmRptChargeInvoice : Form
    {
        connString cs = new connString();
        frmChrgeInvoice fc = null;
        string searchData = "";
        decimal totalPayable = 0;
        decimal discount = 0;

        public frmRptChargeInvoice(frmChrgeInvoice _fc)
        {
            InitializeComponent();
          fc = _fc;
        }

        private void frmRptChargeInvoice_Load(object sender, EventArgs e)
        {
            
            
            LoadCharInvoiceItems();
            ParamData();
            this.reportViewer1.RefreshReport();
        }
        public void autoPrint_chargeInvoiceReceipt()
        {
            AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
            autoprintme.Print();
            this.Dispose();
        }
        #region printClass

        private List<Stream> m_pages = new List<Stream>();

        class AutoPrintCls : PrintDocument
        {
            private PageSettings m_pageSettings;
            private int m_currentPage;
            private List<Stream> m_pages = new List<Stream>();

            public AutoPrintCls(ServerReport serverReport)
                : this((Report)serverReport)
            {
                RenderAllServerReportPages(serverReport);
            }

            public AutoPrintCls(LocalReport localReport)
                : this((Report)localReport)
            {
                RenderAllLocalReportPages(localReport);
            }

            private AutoPrintCls(Report report)
            {
                // Set the page settings to the default defined in the report
                ReportPageSettings reportPageSettings = report.GetDefaultPageSettings();

                // The page settings object will use the default printer unless
                // PageSettings.PrinterSettings is changed.  This assumes there
                // is a default printer.
                m_pageSettings = new PageSettings();
                m_pageSettings.PaperSize = reportPageSettings.PaperSize;
                m_pageSettings.Margins = reportPageSettings.Margins;
            }

            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);

                if (disposing)
                {
                    foreach (Stream s in m_pages)
                    {
                        s.Dispose();
                    }

                    m_pages.Clear();
                }
            }

            protected override void OnBeginPrint(PrintEventArgs e)
            {
                base.OnBeginPrint(e);

                m_currentPage = 0;
            }

            protected override void OnPrintPage(PrintPageEventArgs e)
            {
                base.OnPrintPage(e);

                Stream pageToPrint = m_pages[m_currentPage];
                pageToPrint.Position = 0;

                // Load each page into a Metafile to draw it.
                using (Metafile pageMetaFile = new Metafile(pageToPrint))
                {
                    Rectangle adjustedRect = new Rectangle(
                            e.PageBounds.Left - (int)e.PageSettings.HardMarginX,
                            e.PageBounds.Top - (int)e.PageSettings.HardMarginY,
                            e.PageBounds.Width,
                            e.PageBounds.Height);

                    // Draw a white background for the report
                    e.Graphics.FillRectangle(Brushes.White, adjustedRect);

                    // Draw the report content
                    e.Graphics.DrawImage(pageMetaFile, adjustedRect);

                    // Prepare for next page.  Make sure we haven't hit the end.
                    m_currentPage++;
                    e.HasMorePages = m_currentPage < m_pages.Count;
                }
            }

            protected override void OnQueryPageSettings(QueryPageSettingsEventArgs e)
            {
                e.PageSettings = (PageSettings)m_pageSettings.Clone();
            }

            private void RenderAllServerReportPages(ServerReport serverReport)
            {
                try
                {
                    string deviceInfo = CreateEMFDeviceInfo();

                    // Generating Image renderer pages one at a time can be expensive.  In order
                    // to generate page 2, the server would need to recalculate page 1 and throw it
                    // away.  Using PersistStreams causes the server to generate all the pages in
                    // the background but return as soon as page 1 is complete.
                    NameValueCollection firstPageParameters = new NameValueCollection();
                    firstPageParameters.Add("rs:PersistStreams", "True");

                    // GetNextStream returns the next page in the sequence from the background process
                    // started by PersistStreams.
                    NameValueCollection nonFirstPageParameters = new NameValueCollection();
                    nonFirstPageParameters.Add("rs:GetNextStream", "True");

                    string mimeType;
                    string fileExtension;


                    Stream pageStream = serverReport.Render("IMAGE", deviceInfo, firstPageParameters, out mimeType, out fileExtension);



                    // The server returns an empty stream when moving beyond the last page.
                    while (pageStream.Length > 0)
                    {
                        m_pages.Add(pageStream);

                        pageStream = serverReport.Render("IMAGE", deviceInfo, nonFirstPageParameters, out mimeType, out fileExtension);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("possible missing information ::  " + e);
                }
            }

            private void RenderAllLocalReportPages(LocalReport localReport)
            {
                try
                {
                    string deviceInfo = CreateEMFDeviceInfo();

                    Warning[] warnings;

                    localReport.Render("IMAGE", deviceInfo, LocalReportCreateStreamCallback, out warnings);
                }
                catch (Exception e)
                {
                    MessageBox.Show("error :: " + e);
                }
            }

            private Stream LocalReportCreateStreamCallback(
                string name,
                string extension,
                Encoding encoding,
                string mimeType,
                bool willSeek)
            {
                MemoryStream stream = new MemoryStream();
                m_pages.Add(stream);

                return stream;
            }

            private string CreateEMFDeviceInfo()
            {
                PaperSize paperSize = m_pageSettings.PaperSize;
                Margins margins = m_pageSettings.Margins;

                // The device info string defines the page range to print as well as the size of the page.
                // A start and end page of 0 means generate all pages.
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "<DeviceInfo><OutputFormat>emf</OutputFormat><StartPage>0</StartPage><EndPage>0</EndPage><MarginTop>{0}</MarginTop><MarginLeft>{1}</MarginLeft><MarginRight>{2}</MarginRight><MarginBottom>{3}</MarginBottom><PageHeight>{4}</PageHeight><PageWidth>{5}</PageWidth></DeviceInfo>",
                    ToInches(margins.Top),
                    ToInches(margins.Left),
                    ToInches(margins.Right),
                    ToInches(margins.Bottom),
                    ToInches(paperSize.Height),
                    ToInches(paperSize.Width));
            }

            private static string ToInches(int hundrethsOfInch)
            {
                double inches = hundrethsOfInch / 100.0;
                return inches.ToString(CultureInfo.InvariantCulture) + "in";
            }
        }
        #endregion
        public void ParamData()
        {
            
            string chargeTo =  fc.txtChargeTo.Text;
            string tin = fc.txtTin.Text;
            string terms = fc.txtTerms.Text;
            string add = fc.txtAddress.Text;
            string osca = fc.txtOsca.Text;
            string scpwd = fc.txtSc.Text;
            string bstyle = fc.txtBusiness.Text;
             
            ReportParameter yr = new ReportParameter("year",DateTime.Now.ToString("yy"));
            ReportParameter dt = new ReportParameter("date", DateTime.Now.ToString("MMM dd, "));
            ReportParameter ct  = new ReportParameter("chargeTo", chargeTo);
            ReportParameter tn = new ReportParameter("tin", tin);
            ReportParameter trms = new ReportParameter("terms", terms);
            ReportParameter address = new ReportParameter("address", add);
            ReportParameter osc = new ReportParameter("osca", osca);
            ReportParameter sc = new ReportParameter("sc", scpwd);
            ReportParameter bs = new ReportParameter("businessStyle", bstyle);
            ReportParameter ttlPayable = new ReportParameter("total", totalPayable.ToString("n2"));
            ReportParameter disc = new ReportParameter("discount", discount.ToString("n2"));

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] {yr,dt , ct,tn,trms,address,osc,sc,bs , ttlPayable, disc });
        }
        public void LoadCharInvoiceItems()
        {
            
            searchData = "customerReceipt @machineName = '" + cs.machineName + "' , @dateNow = '" + DateTime.Now + "', @transactionTypeID = '" + s_transactionType.transactionType + "'";
            DataConnector();
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("customerReceiptAmt @machineName = '" + cs.machineName + "', @dateNow = '" + DateTime.Now + "', @transactionTypeID = '" + s_transactionType.transactionType + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                totalPayable = Convert.ToDecimal(cs.dbSearchData.Rows[0][5].ToString());                
                discount = Convert.ToDecimal(cs.dbSearchData.Rows[0][18]);                 
            }
            else
            {
                totalPayable = 0;              
                discount = 0;
                 
            }
        }
        private void DataConnector()
        {
            cs.connDB();
            SqlCommand comm = new SqlCommand(searchData , cs.cn);
            SqlDataAdapter sqlda = new SqlDataAdapter(comm);
            posDBDataSet.customerReceipt.Clear();
            sqlda.Fill(posDBDataSet.customerReceipt);
            this.reportViewer1.RefreshReport();
            cs.disconMy();
             
        }
    }
}
