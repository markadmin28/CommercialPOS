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


namespace POS.Billing.DailyReading
{
    public partial class frmReadingRpt : Form
    {
        connString cs = new connString();

        string noOfTrans = "";
        double grossSales = 0;
        double netSales = 0;
        double NOT = 0;
        double totalTax = 0;
        double totalCashSales = 0;
        double avgSales = 0;
        double totalVatSales = 0;
        double totalNonVatSales = 0;
        int totalVatItems = 0;
        int totalNonVatItems = 0;
        double totalQty = 0;

        int noVoidedTrans = 0;
        double voidedAmt = 0;

        //for cash fund
        double cfAmt = 0;
        DateTime cfDt;

        double mediaReportAmt = 0;
        double prevNrgt = 0;
        double NRGT = 0;

        decimal NRGTID = 0;
        string actn = "";
        string readingType = "";

        public decimal readBy = 0;

        public frmReadingRpt()
        {
            InitializeComponent();
        }

        private void frmReadingRpt_Load(object sender, EventArgs e)
        {
            ReadingCommand();
        }
        private void ReadingCommand()
        {
            readingCommand();
            readingCashInOutData();
            mediaReport();

            NRGT = (mediaReportAmt + prevNrgt + totalCashSales);

            //change reading type
            readingStatusType();

            paramReadingData();
            NRGTCommand();
            this.reportViewer1.RefreshReport();
        }
        private void paramReadingData()
        {
           
            ReportParameter prop = new ReportParameter("prop", posCompProp.compProp);
            ReportParameter company = new ReportParameter("company", posCompName.compName);
            ReportParameter tin = new ReportParameter("TIN", posTIN.tin);
            ReportParameter min = new ReportParameter("MIN", posMIN.min);
            ReportParameter add = new ReportParameter("address", posAddress.address);
            ReportParameter posDesc = new ReportParameter("posDesc", posPosDesc.posDesc);
            ReportParameter serialNo = new ReportParameter("serialNo", posSerialNo.serialNo);

            ReportParameter addedBy = new ReportParameter("addedBy", posUserName.userName.ToString());
            ReportParameter date = new ReportParameter("date", DateTime.Now.ToString("MMM dd, yyy (ddd) hh:mm tt"));
            ReportParameter noOfT = new ReportParameter("noOfTrans", noOfTrans.ToString());
            ReportParameter POSID = new ReportParameter("machineNo", posMachineNo.machineNo.ToString());

            ReportParameter gSales = new ReportParameter("grossSales", grossSales.ToString("n2"));
            ReportParameter nSales = new ReportParameter("netSales", netSales.ToString("n2"));
            ReportParameter not = new ReportParameter("NOT", NOT.ToString("n0"));
            ReportParameter ttlTax = new ReportParameter("totalTax", totalTax.ToString("n2"));
            ReportParameter ttlCashSales = new ReportParameter("totalCashSales", totalCashSales.ToString("n2"));
            ReportParameter ttlAvgsales = new ReportParameter("avgSales", avgSales.ToString("n2"));

            ReportParameter ttlVatSales = new ReportParameter("totalVatableSales", totalVatSales.ToString("n2"));
            ReportParameter ttlNonVatSales = new ReportParameter("totalNonVatableSales", totalNonVatSales.ToString("n2"));
            ReportParameter ttlVatItems = new ReportParameter("noVatableItems", totalVatItems.ToString("n2"));
            ReportParameter ttlNonVatItems = new ReportParameter("noNonVatableItems", totalNonVatItems.ToString("n2"));
            ReportParameter ttlQty = new ReportParameter("totalQty", totalQty.ToString("n2"));

            ReportParameter cfDate = new ReportParameter("cfTime", cfDt.ToString("hh:mm tt"));
            ReportParameter cfAmount = new ReportParameter("cfAmt", cfAmt.ToString("n2"));

            ReportParameter timeRead = new ReportParameter("timeRead", DateTime.Now.ToString("hh:mm tt"));
            ReportParameter MRamt = new ReportParameter("MRTotalCash", mediaReportAmt.ToString("n2"));

            ReportParameter pNRGT = new ReportParameter("prevNRGT", prevNrgt.ToString("n2"));
            ReportParameter nrgt = new ReportParameter("nrgt", NRGT.ToString("n2"));
            ReportParameter readType = new ReportParameter("readingType", readingType.ToString());
            ReportParameter _voidedAmt = new ReportParameter("voidedAmount", voidedAmt.ToString("n2"));
            ReportParameter _noVoidedTrans = new ReportParameter("noVoided", noVoidedTrans.ToString());

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { prop, company, tin, min, add, posDesc, serialNo, addedBy, date, noOfT, POSID,gSales,nSales,not, ttlTax, ttlCashSales, ttlAvgsales, ttlVatSales,ttlNonVatSales,ttlVatItems,ttlNonVatItems, ttlQty, cfDate, cfAmount , timeRead , MRamt, pNRGT, nrgt , readType, _voidedAmt, _noVoidedTrans });
            reportViewer1.RefreshReport();
        }
        private void readingCommand()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("ReadingCommand @start = '" + DateTime.Now + "',@machineName = '" + cs.machineName + "', @machineNo = '" + posMachineNo.machineNo + "', @dateNow = '" + DateTime.Now + "', @transactionTypeID = '" + s_transactionType.transactionType + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                noOfTrans = cs.dbSearchData.Rows[0][1].ToString();
                grossSales = Convert.ToDouble(cs.dbSearchData.Rows[0][6]);
                netSales = Convert.ToDouble(cs.dbSearchData.Rows[0][4]);
                NOT = Convert.ToDouble(cs.dbSearchData.Rows[0][0]);
                totalTax = Convert.ToDouble(cs.dbSearchData.Rows[0][5]);
                totalCashSales = Convert.ToDouble(cs.dbSearchData.Rows[0][9]);
                avgSales = Convert.ToDouble(cs.dbSearchData.Rows[0][10]);
                totalVatSales = Convert.ToDouble(cs.dbSearchData.Rows[0][11]);
                totalNonVatSales = Convert.ToDouble(cs.dbSearchData.Rows[0][12]);
                totalVatItems = Convert.ToInt32(cs.dbSearchData.Rows[0][13]);
                totalNonVatItems = Convert.ToInt32(cs.dbSearchData.Rows[0][14]);
                totalQty = Convert.ToDouble(cs.dbSearchData.Rows[0][15]);

                noVoidedTrans = Convert.ToInt32(cs.dbSearchData.Rows[0][17]);
                voidedAmt = Convert.ToDouble(cs.dbSearchData.Rows[0][16]);
            }
            //for cash fund data
            cashFundData();
        }
        private void cashFundData()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select dateAdded,amount from tbl_CashInOut where machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "' and datediff(day,dateAdded,'" + DateTime.Now + "')=0 and inOut = 3");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                cfDt = Convert.ToDateTime(cs.dbSearchData.Rows[0][0]);
                cfAmt = Convert.ToDouble(cs.dbSearchData.Rows[0][1]);
            }
        }
        private void readingCashInOutData()
        {
            string searchData;
            searchData = "readingCashInOut @machineName = '" + cs.machineName + "', @machineNo = '" + posMachineNo.machineNo + "' , @dateNow = '" + DateTime.Now + "'";


            SqlCommand COMM = new SqlCommand();
            SqlDataAdapter SQLDA = new SqlDataAdapter();
            cs.connDB();
            COMM = new SqlCommand(searchData, cs.cn);
            SQLDA = new SqlDataAdapter(COMM);
            this.posDBDataSet.readingCashInOut.Clear();
            SQLDA.Fill(posDBDataSet.readingCashInOut);
            this.reportViewer1.RefreshReport();
            cs.disconMy();
        }
        private void mediaReport()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("MediaReport @machineName = '" + cs.machineName + "', @machineNo = '" + posMachineNo.machineNo + "' ,@dateNow = '" + DateTime.Now + "'");
            cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
            {
                mediaReportAmt = Convert.ToDouble(cs.dbSearchData.Rows[0][0]);
                prevNrgt = Convert.ToDouble(cs.dbSearchData.Rows[0][2]);
            }
        }
        private void saveNRGTCommand()
        {        
            cs.connDB();
            cs.insertData = "NRGTCommand @action = '" + actn + "',@nrgtid = '" + NRGTID + "',@prevNrgt = '" + prevNrgt + "',@nrgt = '" + NRGT + "',@addedBy = '" + addedByUser.addedBy + "',@dateAdded = '" + DateTime.Now + "',@machineName = '" + cs.machineName + "',@machineNo = '" + posMachineNo.machineNo + "'";
            cs.IUD(cs.insertData);
            cs.disconMy();
        }
        private void NRGTCommand()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select NRGTID from tbl_NRGT where machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "' and datediff(day,dateAdded,'" + DateTime.Now + "') =0");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                NRGTID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
                actn = "Update";
                saveNRGTCommand();                
            }
            else
            {
                genNRGTID();
                actn = "Insert";
                saveNRGTCommand();
            }
            //update daily reading status
            dailyReadingStatusUpdate();
        }
        private void genNRGTID()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(max(NRGTID),1000000000000) + 1 from tbl_NRGT");
            cs.disconMy();
            NRGTID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
        }
        private void dailyReadingStatusUpdate()
        {
            cs.connDB();
            cs.insertData = "dailyReadingStatusUpdate @machineName = '" + cs.machineName + "' ,@machineNo = '" + posMachineNo.machineNo + "' , @readBy = '" + readBy + "',@dateNow = '" + DateTime.Now + "'";
            cs.IUD(cs.insertData);
            cs.disconMy();
        }
        private void readingStatusType()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select readingID from tbl_dailyReadingStatus where datediff(day,dateAdded,'" + DateTime.Now + "')=0 and machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "' and z =0 and x =0");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                readingType = "Z";
            }
            else
            {
                readingType = "X";
            }
        }

        private void frmReadingRpt_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            this.Dispose();
        }
        public void autoPrint_DailyReading()
        {
            ReadingCommand();
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
    }
}
