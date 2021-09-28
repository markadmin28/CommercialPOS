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
using System.Diagnostics;
  
namespace POS.Receipt
{
    public partial class frmRptReceipt : Form
    {
        string searchData;
        connString cs = new connString();
        SqlCommand COMM = new SqlCommand();
        SqlDataAdapter SQLDA = new SqlDataAdapter();
        
        decimal totalPayable = 0;
        decimal totalCash = 0;
        decimal totalChange = 0;

        decimal vatSale = 0;
        decimal vatExSale = 0;
        decimal totalSale = 0;
        decimal vat12 = 0;

        string machineNo = "";
        string orNo = "";
        string addedBy = "";
        DateTime dTime;
        string posDesc = "";
        string serialNo = "";
        string min = "";
        string cusName = "";
        decimal discount = 0;
        string transactionType = "";

        public int cusRcptType = 0;
        public decimal transID = 0;

        public string voidStatus = "";
        

        public frmRptReceipt()
        {
            InitializeComponent();
        }

        private void frmRptReceipt_Load(object sender, EventArgs e)
        {
          
            displayCustomerReceipt();
            rcptParameterData();
            this.reportViewer1.RefreshReport();
        }
        public void autoPrint_CusReceipt()
        {
            AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
            autoprintme.Print();
            this.Dispose();
        }
                       
        public void displayCustomerReceipt()
        {
            
           if (cusRcptType == 1)
            {
                searchData = "inquiry_customerReceipt @transID = '" + transID + "'";
                CR_DataConnector();
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("inquiry_customerReceiptAmt @transID = '" + transID + "'");
                cs.disconMy();
            }
           else
            {
                searchData = "customerReceipt @machineName = '" + cs.machineName + "' , @dateNow = '" + DateTime.Now + "', @transactionTypeID = '" + s_transactionType.transactionType + "'";
                CR_DataConnector();
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("customerReceiptAmt @machineName = '" + cs.machineName + "', @dateNow = '" + DateTime.Now + "', @transactionTypeID = '" + s_transactionType.transactionType + "'");
                cs.disconMy();
            }
             
            if (cs.dbSearchData.Rows.Count > 0)
            { 
                totalPayable = Convert.ToDecimal(cs.dbSearchData.Rows[0][5].ToString());
                totalCash = Convert.ToDecimal(cs.dbSearchData.Rows[0][6].ToString());
                totalChange = Convert.ToDecimal(cs.dbSearchData.Rows[0][7].ToString());

                vatSale = Convert.ToDecimal(cs.dbSearchData.Rows[0][1].ToString());
                vatExSale = Convert.ToDecimal(cs.dbSearchData.Rows[0][2].ToString());
                totalSale = Convert.ToDecimal(cs.dbSearchData.Rows[0][3].ToString());
                vat12 = Convert.ToDecimal(cs.dbSearchData.Rows[0][4].ToString());
                machineNo = cs.dbSearchData.Rows[0][10].ToString();
                orNo = cs.dbSearchData.Rows[0][11].ToString();
                addedBy = cs.dbSearchData.Rows[0][12].ToString();
                dTime = Convert.ToDateTime(cs.dbSearchData.Rows[0][13]);
                posDesc = cs.dbSearchData.Rows[0][14].ToString();
                serialNo = cs.dbSearchData.Rows[0][15].ToString();
                min = cs.dbSearchData.Rows[0][16].ToString();
                cusName = cs.dbSearchData.Rows[0][17].ToString();
                discount = Convert.ToDecimal(cs.dbSearchData.Rows[0][18]);
                transactionType = cs.dbSearchData.Rows[0][19].ToString();
            }
            else
            {
                totalPayable = 0;
                totalCash = 0;
                totalChange = 0;
                vatSale = 0;
                vatExSale = 0;
                totalSale = 0;
                vat12 = 0;
                machineNo = "";
                orNo = "";
                addedBy = "";
                posDesc = "Not set";
                serialNo = "Not set";
                min = "Not set";
                cusName = "";
                discount = 0;
                transactionType = "";
            }
        }
        
        private void CR_DataConnector()
        {
            cs.connDB();
            COMM = new SqlCommand(searchData, cs.cn);
            SQLDA = new SqlDataAdapter(COMM);
            posDBDataSet.customerReceipt.Clear();
            SQLDA.Fill(posDBDataSet.customerReceipt);
            this.reportViewer1.RefreshReport();
            cs.disconMy();
            
        }
        public void rcptParameterData()
        {
           

            ReportParameter prop = new ReportParameter("prop", posCompProp.compProp);
            ReportParameter compName = new ReportParameter("company", posCompName.compName);
            ReportParameter tin = new ReportParameter("TIN", posTIN.tin);

            ReportParameter _min = new ReportParameter("MIN",  min);

            ReportParameter address = new ReportParameter("address", posAddress.address);

            ReportParameter _posDesc = new ReportParameter("posDesc", posDesc);
            ReportParameter _serialNo = new ReportParameter("serialNo",  serialNo);

            
            ReportParameter dt = new ReportParameter("date", dTime.ToString("MM/dd/yyy" + " ( " + "ddd" + ")" + " hh:mm tt"));

            ReportParameter ttlPayable = new ReportParameter("total", totalPayable.ToString("n2"));
            ReportParameter ttlCash = new ReportParameter("cash", totalCash.ToString("n2"));
            ReportParameter ttlChange = new ReportParameter("change", totalChange.ToString("n2"));

            ReportParameter ttlVatSale = new ReportParameter("vatSale", vatSale.ToString("n2"));
            ReportParameter ttlVatExSale = new ReportParameter("vatExSale", vatExSale.ToString("n2"));
            ReportParameter ttlTotalSale = new ReportParameter("totalSale", totalSale.ToString("n2"));
            ReportParameter ttlVat12 = new ReportParameter("vat12", vat12.ToString("n2"));
            ReportParameter ttlTotalPayable = new ReportParameter("totalAmountPayable", totalPayable.ToString("n2"));

            ReportParameter _addedBy = new ReportParameter("addedBy", addedBy.ToString());

            ReportParameter _machineNo = new ReportParameter("machineNo", machineNo.ToString());
            ReportParameter orNumber = new ReportParameter("orNo", orNo.ToString());
            ReportParameter _voidStatus = new ReportParameter("voidStatus", voidStatus.ToString());
            ReportParameter _cusName = new ReportParameter("cusName", cusName.ToString());
            ReportParameter _discount = new ReportParameter("discount", discount.ToString());
            ReportParameter transType = new ReportParameter("transType", transactionType);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { prop ,compName,tin,_min,address,_posDesc,_serialNo,dt,ttlPayable,ttlCash,ttlChange,ttlVatSale,ttlVatExSale,ttlTotalSale,ttlVat12,ttlTotalPayable,_addedBy,_machineNo,orNumber, _voidStatus, _cusName , _discount , transType});
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

        private void frmRptReceipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

    }
}
