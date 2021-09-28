using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.PointOfService;
using System.Threading;


namespace POS.Inquiry
{
    public partial class frmTransList : Form
    {
        PosPrinter m_Printer = null;
        connString cs = new connString();
        string actn = "";

        string compProp;
        string compName;
        string compTIN;
        string compMIN;
        string compAddress;
        string compPosDesc;
        string compSerialNo;

        decimal transTypeID = 0;
        string machName = "";


        public frmTransList()
        {
            InitializeComponent();
        }

        private void frmTransList_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(2000);
            transactionTypeDisplay();
        }
        private void transactionTypeDisplay()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("sp_transactionType_display @transactionType = ''");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                cmbTransType.Items.Clear();
                for (int i =0; i <= cs.dbSearchData.Rows.Count -1; i++)
                {
                    cmbTransType.Items.Add(cs.dbSearchData.Rows[i][2]);
                }
            }
            else
            {
                cmbTransType.Items.Clear();
            }
        }
        private void loadTransList(string actions)
        {
            double vatSale = 0;
            double vatExSale = 0;
            double totalSale = 0;
            double vat = 0;
            double grossPayable = 0;
            double grossSales = 0;
            double totalCash = 0;
            double totalChange = 0;
            double totalCostSales = 0;

            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("inquiry_transactionList @action = '" + actions + "',@start = '" + dateTimePicker1.Value.ToString() + "',@cutOff = '" + dateTimePicker2.Value.ToString() + "',@machineNo = '" + comboBox1.Text + "', @transactionTypeID = '" + s_transactionType.transactionType + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i =0; i <= cs.dbSearchData.Rows.Count -1; i++)
                {    
                    dgw.Rows.Add((cs.dbSearchData.Rows[i][0]), cs.dbSearchData.Rows[i][1], cs.dbSearchData.Rows[i][2], cs.dbSearchData.Rows[i][3], cs.dbSearchData.Rows[i][4], cs.dbSearchData.Rows[i][5], cs.dbSearchData.Rows[i][6], cs.dbSearchData.Rows[i][7], cs.dbSearchData.Rows[i][8], cs.dbSearchData.Rows[i][9],cs.dbSearchData.Rows[i][16],cs.dbSearchData.Rows[i][17], cs.dbSearchData.Rows[i][10], cs.dbSearchData.Rows[i][11], cs.dbSearchData.Rows[i][12], cs.dbSearchData.Rows[i][13], cs.dbSearchData.Rows[i][14], cs.dbSearchData.Rows[i][15],cs.dbSearchData.Rows[i][18] , cs.dbSearchData.Rows[i][19]);
                    if (dgw.Rows[i].Cells[17].Value.ToString() == "1")
                    {
                        dgw.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    }                   
                   //-------------------
                   if (dgw.Rows[i].Cells[17].Value.ToString() == "0")
                    {
                        vatSale += Convert.ToDouble(dgw.Rows[i].Cells[6].Value);
                        vatExSale += Convert.ToDouble(dgw.Rows[i].Cells[7].Value);
                        totalSale += Convert.ToDouble(dgw.Rows[i].Cells[8].Value);
                        vat += Convert.ToDouble(dgw.Rows[i].Cells[9].Value);
                        grossPayable += Convert.ToDouble(dgw.Rows[i].Cells[10].Value);
                        grossSales += Convert.ToDouble(dgw.Rows[i].Cells[12].Value);
                        totalCash += Convert.ToDouble(dgw.Rows[i].Cells[13].Value);
                        totalChange += Convert.ToDouble(dgw.Rows[i].Cells[14].Value);
                        totalCostSales += Convert.ToDouble(dgw.Rows[i].Cells[19].Value);
                    }                       
                }
                if (dgw.Rows.Count > 0)
                {
                    dgw.CurrentRow.Selected = false;
                }
                else
                {
                    //no action
                }
            }
            else
            {
                dgw.Rows.Clear();
                MessageBox.Show("No Data found!", "Database message",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtTransactionType.Text = "_____";
                txtVatSale.Text = "0";
                txtVatExSale.Text = "0";
                txtTotalSale.Text = "0";
                txtVat.Text = "0";
                txtGrossPayable.Text = "0";
                txtGrossSales.Text = "0";
                txtTotalCash.Text = "0";
                txtTotalChange.Text = "0";
                ttlCostSales.Text = "0" ;
                return;
            }
            txtVatSale.Text = vatSale.ToString("n2");
            txtVatExSale.Text = vatExSale.ToString("n2");
            txtTotalSale.Text = totalSale.ToString("n2");
            txtVat.Text = vat.ToString("n2");
            txtGrossPayable.Text = grossPayable.ToString("n2");
            txtGrossSales.Text = grossSales.ToString("n2");
            txtTotalCash.Text = totalCash.ToString("n2");
            txtTotalChange.Text = totalChange.ToString("n2");
            ttlCostSales.Text = totalCostSales.ToString("n2"); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbTransType.Text == "")
            {
                actn = "All";
            }
            else
            {
                actn = "Detailed";
            }
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select transactionTypeID from tbl_transactionType where transactionType = '" + cmbTransType.Text + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                s_transactionType.transactionType = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
            }
            else
            {
                s_transactionType.transactionType = 0;
            }
            if (cmbTransType.Text == "")
            {
                txtTransactionType.Text = "All";
            }
            else
            {
                txtTransactionType.Text = cmbTransType.Text;
            }

            loadTransList(actn);
             

            
        }

        private void dgw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (dgw.Rows.Count > 0)
                {
                    dgw.CurrentRow.Selected = false;
                    dateTimePicker1.Focus();
                }
                else
                {
                    //no action
                }
            }
        }
        private void loadPosID()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select machineNo from tbl_posReg order by machineNo");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                comboBox1.Items.Clear();
                for (int i = 0; i <= cs.dbSearchData.Rows.Count - 1; i++)
                {
                    comboBox1.Items.Add(cs.dbSearchData.Rows[i][0]);
                }
            }
            else
            {
                comboBox1.Items.Clear();
            }
        }                        
        private void comboBox1_Enter(object sender, EventArgs e)
        {
            loadPosID();
        }

        private void dgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            detailsPassValue();
        }
        private void detailsPassValue()
        {
            if (dgw.Rows.Count > 0)
            {
                if (dgw.CurrentRow.Selected == false)
                {
                    MessageBox.Show("Select transaction", "System message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    frmTransListDetails fld = new frmTransListDetails(this);
                    fld.transListDetails(Convert.ToDecimal(dgw.CurrentRow.Cells[16].Value));

                    fld.txtDate.Text = dgw.CurrentRow.Cells[1].Value.ToString();
                    fld.txtTime.Text = dgw.CurrentRow.Cells[2].Value.ToString();
                    fld.txtRecript.Text = dgw.CurrentRow.Cells[3].Value.ToString();
                    fld.txtPosID.Text = dgw.CurrentRow.Cells[4].Value.ToString();
                    fld.txtCashier.Text = dgw.CurrentRow.Cells[5].Value.ToString();
                    fld.txtTransID.Text = dgw.CurrentRow.Cells[16].Value.ToString();

                    fld.txtVatSale.Text = Convert.ToDouble(dgw.CurrentRow.Cells[6].Value.ToString()).ToString("n2");
                    fld.txtVatExSale.Text = Convert.ToDouble(dgw.CurrentRow.Cells[7].Value.ToString()).ToString("n2");
                    fld.txtTotalSale.Text = Convert.ToDouble(dgw.CurrentRow.Cells[8].Value.ToString()).ToString("n2");
                    fld.txtVAT.Text = Convert.ToDouble(dgw.CurrentRow.Cells[9].Value.ToString()).ToString("n2");
                    fld.txtGrossPayable.Text = Convert.ToDouble(dgw.CurrentRow.Cells[10].Value.ToString()).ToString("n2");
                    fld.txtDiscount.Text = dgw.CurrentRow.Cells[11].Value.ToString();
                    fld.txtGrossSales.Text = Convert.ToDouble(dgw.CurrentRow.Cells[12].Value.ToString()).ToString("n2");
                    fld.txtTotalCash.Text = Convert.ToDouble(dgw.CurrentRow.Cells[13].Value.ToString()).ToString("n2");
                    fld.txtTotalChange.Text = Convert.ToDouble(dgw.CurrentRow.Cells[14].Value.ToString()).ToString("n2");
                    fld.voidStat = Convert.ToInt32(dgw.CurrentRow.Cells[17].Value.ToString());
                    fld.ShowDialog();
                }
               
            }
            else
            {
                //no action
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmTransList_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void frmTransList_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            detailsPassValue();
        }

        private void btnCancel_Leave(object sender, EventArgs e)
        {

            btnPrint.Focus();
        }

        private void dgw_Leave(object sender, EventArgs e)
        {
            dateTimePicker1.Focus();            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker helperBW = sender as BackgroundWorker;
            int arg = (int)e.Argument;
            e.Result = BackgroundProcessLogicMethod(helperBW, arg);
            if (helperBW.CancellationPending)
            {
                e.Cancel = true;
            }
        }
        private int BackgroundProcessLogicMethod(BackgroundWorker bw , int a)
        {
            int result = 0;
            Thread.Sleep(2000);
            LoadPrinter();
            return result;
        }
        #region Print Receipt

        private void LoadPrinter()
        {
            //-------------
            //<<<step1>>>--Start
            //Use a Logical Device Name which has been set on the SetupPOS.
            string strLogicalName = "PosPrinter";

            try
            {
                //Create PosExplorer
                PosExplorer posExplorer = new PosExplorer();

                DeviceInfo deviceInfo = null;

                try
                {
                    deviceInfo = posExplorer.GetDevice(DeviceType.PosPrinter, strLogicalName);
                    m_Printer = (PosPrinter)posExplorer.CreateInstance(deviceInfo);

                }
                catch (Exception)
                {
                    return;
                }
                //Open the device
                m_Printer.Open();

                //Get the exclusive control right for the opened device.
                //Then the device is disable from other application.
                m_Printer.Claim(1000);

                //Enable the device.
                m_Printer.DeviceEnabled = true;

            }
            catch (PosControlException)
            {
            }
            //<<<step1>>>--End

        }
        private void ReleasingPrinter()
        {

            if (m_Printer != null)
            {
                try
                {
                    //Cancel the device
                    m_Printer.DeviceEnabled = false;

                    //Release the device exclusive control right.
                    m_Printer.Release();

                }
                catch (PosControlException)
                {
                }
                finally
                {
                    //Finish using the device.
                    m_Printer.Close();
                }
            }

        }
        const int MAX_LINE_WIDTHS = 2;
        private long GetRecLineChars(ref int[] RecLineChars)
        {
            long lRecLineChars = 0;
            long lCount;
            int i;

            // Calculate the element count.
            lCount = m_Printer.RecLineCharsList.GetLength(0);

            if (lCount == 0)
            {
                lRecLineChars = 0;
            }
            else
            {
                if (lCount > MAX_LINE_WIDTHS)
                {
                    lCount = MAX_LINE_WIDTHS;
                }

                for (i = 0; i < lCount; i++)
                {
                    RecLineChars[i] = m_Printer.RecLineCharsList[i];
                }

                lRecLineChars = lCount;
            }

            return lRecLineChars;
        }
        public String MakePrintString(int iLineChars, String strBuf, String strPrice)
        {
            int iSpaces = 0;
            String tab = "";
            try
            {
                iSpaces = iLineChars - (strBuf.Length + strPrice.Length);
                for (int j = 0; j < iSpaces; j++)
                {
                    tab += " ";
                }
            }
            catch (Exception)
            {
            }
            return strBuf + tab + strPrice;
        }
        public void CustomerReceiptPrintData(decimal transID,string voidLabel)
        {
            DataTable dtProdDetails = new DataTable();
            DateTime pDate;
            compName = posCompName.compName;
            string pTransactionType;
            string pOrNo;
            string pMachineNo;
            double pSubTotal = 0;
            double pDiscPerItem = 0;
            double pTotalPayable = 0;
            double pTotalCash = 0;
            double pTotalChange = 0;
            double pTotalDiscount = 0;
            double pTotalItems = 0;
            double vatSale = 0;
            double vatExSale = 0;
            double tax = 0;
            //Product variables
            string strHolder = "";
            double pQuantity;
            string pUom;
            string pOperator = " X ";
            double pPrice;
            double pTotal;
            string pProductDesc;
            string prodSoldData = "";
            string itemVolume;
            string cashier = "";
            string cusName = "";
            //header
            PrintReceiptHeader();
            int[] RecLineChars = new int[MAX_LINE_WIDTHS] { 0, 0 };
            long lRecLineCharsCount;
            lRecLineCharsCount = GetRecLineChars(ref RecLineChars);
            m_Printer.RecLineChars = RecLineChars[1];
          
            if (voidLabel == "")
            {
                //no action
            }
            else
            {
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "\u001b|bC" + "\u001b|2C" + voidLabel + "\n");
            }
            //get buying details

            cs.connDB();
            dtProdDetails = cs.DISPLAY("inquiry_customerReceiptAmt @transID = '" + transID + "'");
            cs.disconMy();
            if (dtProdDetails.Rows.Count > 0)
            {
                pDate = Convert.ToDateTime(dtProdDetails.Rows[0][13]);
                pTransactionType = dtProdDetails.Rows[0][19].ToString();
                pMachineNo = dtProdDetails.Rows[0][10].ToString();
                pOrNo = dtProdDetails.Rows[0][11].ToString();
                pTotalPayable = Convert.ToDouble(dtProdDetails.Rows[0][5]);
                pTotalCash = Convert.ToDouble(dtProdDetails.Rows[0][6]);
                pTotalChange = Convert.ToDouble(dtProdDetails.Rows[0][7]);
                pTotalDiscount = Convert.ToDouble(dtProdDetails.Rows[0][18]);
                cashier = dtProdDetails.Rows[0][12].ToString();
                cusName = dtProdDetails.Rows[0][17].ToString();
                vatSale = Convert.ToDouble(dtProdDetails.Rows[0][1]);
                vatExSale = Convert.ToDouble(dtProdDetails.Rows[0][2]);
                tax = Convert.ToDouble(dtProdDetails.Rows[0][4]);

                strHolder = MakePrintString(m_Printer.RecLineChars, pDate.ToString("MM/dd/yyy" + " (" + "ddd" + ")" + " hh:mm tt"), pTransactionType);
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|uC" + strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "OR No. " + pMachineNo + "-" + pOrNo, " ");
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|uC" + strHolder);
                //gives margin
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|30uF");
                strHolder = MakePrintString(m_Printer.RecLineChars, "ITEM(s)", "TOTAL");
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|bC" + strHolder);
                //gives margin
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|28uF");
            }
            //Get Buying items data
            cs.connDB();
            cs.dbSearchData=cs.DISPLAY( "inquiry_customerReceipt @transID = '" + transID + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                for (int i = 0; i <= cs.dbSearchData.Rows.Count - 1; i++)
                {
                    pQuantity = Convert.ToDouble(cs.dbSearchData.Rows[i][2]);
                    pUom = cs.dbSearchData.Rows[i][7].ToString();
                    pPrice = Convert.ToDouble(cs.dbSearchData.Rows[i][4]);
                    pDiscPerItem = Convert.ToDouble(cs.dbSearchData.Rows[i][5]);
                    pTotal = Convert.ToDouble(cs.dbSearchData.Rows[i][6]);
                    pProductDesc = cs.dbSearchData.Rows[i][3].ToString();
                    pSubTotal += pTotal;
                    pTotalItems += pQuantity;
                    if (pDiscPerItem != 0)
                    {
                        itemVolume = " " + pQuantity + " " + pUom + pOperator + pPrice.ToString("n2") + " (" + pDiscPerItem.ToString("n2") + ")";
                    }
                    else
                    {
                        itemVolume = " " + pQuantity + " " + pUom + pOperator + pPrice.ToString("n2");
                    }

                    prodSoldData = MakePrintString(m_Printer.RecLineChars, itemVolume, pTotal.ToString("n2"));
                    m_Printer.PrintNormal(PrinterStation.Receipt, prodSoldData + "\u001b|20uF");

                    var words = pProductDesc.Split();
                    var lines = new List<string> { words[0] };
                    var lineNum = 0;
                    for (int x = 1; x < words.Length; x++)
                    {
                        if (lines[lineNum].Length + words[x].Length + 1 <= 35)
                            lines[lineNum] += " " + words[x];
                        else
                        {
                            lines.Add(words[x]);
                            lineNum++;
                        }
                    }
                    foreach (var line in lines)
                    {
                        m_Printer.PrintNormal(PrinterStation.Receipt, line + "\u001b|20uF");
                    }

                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|15uF");
                }
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|10uF");
            }
            //Footer
            strHolder = MakePrintString(m_Printer.RecLineChars, "SUBTOTAL", pSubTotal.ToString("n2"));
            m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
            strHolder = MakePrintString(m_Printer.RecLineChars, "DISCOUNT", pTotalDiscount.ToString("n2") + "%");
            m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
            strHolder = MakePrintString(m_Printer.RecLineChars / 2, "G'TOTAL", pTotalPayable.ToString("n2"));
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|bC" + "\u001b|2C" + strHolder + "\n");
            strHolder = MakePrintString(m_Printer.RecLineChars, "CASH", pTotalCash.ToString("n2"));
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|bC" + strHolder + "\n");
            strHolder = MakePrintString(m_Printer.RecLineChars, "CHANGE", pTotalChange.ToString("n2"));
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|uC" + strHolder + "\u001b|30uF");

            strHolder = MakePrintString(m_Printer.RecLineChars, "VAT SALE", vatSale.ToString("n2"));
            m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
            strHolder = MakePrintString(m_Printer.RecLineChars, "VAT-EXEMPT SALE", vatExSale.ToString("n2"));
            m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
            strHolder = MakePrintString(m_Printer.RecLineChars, "12% VAT", tax.ToString("n2"));
            m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\u001b|30uF");

            strHolder = MakePrintString(m_Printer.RecLineChars, "CASHIER: " + cashier, pTotalItems.ToString() + " Item(s)");
            m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
            strHolder = MakePrintString(m_Printer.RecLineChars, "SOLD TO: " + cusName.ToString(), "");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|uC" + strHolder + "\u001b|30uF");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "INFORMATION SYSTEMS" + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "---SERVERS AS YOUR OFFICIAL RECEIPT---" + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "Items mentioned above must be accompanied with this sales receipt when returned." + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "   Shop @" + "\u001b|20uF");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "\u001b|bC" + "\u001b|2C" + compName);
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|30uF");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "THANK YOU COME AGAIN!" + "\n");

            //   \u001b|#fP = Line Feed and Paper cut	
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|fP");

            m_Printer.RecLineChars = RecLineChars[0];
        }
        private void transactionListReport()
        {
            DateTime dt = DateTime.Now;

            string orNo = "";
            double amt = 0;
            string strHolder = "";
            double subTotal = 0;          
            PrintReceiptHeader();
            int[] RecLineChars = new int[MAX_LINE_WIDTHS] { 0, 0 };
            long lRecLineCharsCount;
            lRecLineCharsCount = GetRecLineChars(ref RecLineChars);
            m_Printer.RecLineChars = RecLineChars[1];

            strHolder = MakePrintString(m_Printer.RecLineChars, DateTime.Now.ToString("MMM dd, yyy (ddd) hh:mm tt"), posUserName.userName);
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|10uF" + strHolder + "\n" +"\u001b|10uF");
            m_Printer.PrintNormal(PrinterStation.Receipt, "TRANSACTION LIST REPORT" + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "TRANSACTION TYPE: "+ cmbTransType.Text + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "PERIOD: " + dateTimePicker1.Value.ToString() + " - " + dateTimePicker2.Value.ToString() + "\n\n");

            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("sp_transactionListReport @machineNo = '" + comboBox1.Text + "', @machineName = '" + machName + "', @transactionTypeID = '" + transTypeID + "', @start = '" + dateTimePicker1.Value.ToString() + "', @cutOff = '" + dateTimePicker2.Value.ToString() + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                for ( int i =0; i <= cs.dbSearchData.Rows.Count -1; i++)
                {
                    dt = Convert.ToDateTime(cs.dbSearchData.Rows[i][0]);
                    orNo = cs.dbSearchData.Rows[i][2].ToString();
                    amt = Convert.ToDouble(cs.dbSearchData.Rows[i][3]);
                    subTotal += amt;
                    strHolder = MakePrintString(m_Printer.RecLineChars, dt.ToString("MM/dd") + "  " + dt.ToString("hh:mm tt") + "  #" + orNo, amt.ToString("n2"));
                    m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                }
            }
            strHolder = MakePrintString(m_Printer.RecLineChars, "TOTAL", subTotal.ToString("n2"));
            m_Printer.PrintNormal(PrinterStation.Receipt, "\n" + strHolder + "\n");       
                 
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|fP");
            m_Printer.RecLineChars = RecLineChars[0];
        }
        private void PrintReceiptHeader()
        {
            compProp = posCompProp.compProp;
            compName = posCompName.compName;
            compTIN = posTIN.tin;
            compMIN = posMIN.min;
            compAddress = posAddress.address;
            compPosDesc = posPosDesc.posDesc;
            compSerialNo = posSerialNo.serialNo;
            int[] RecLineChars = new int[MAX_LINE_WIDTHS] { 0, 0 };
            long lRecLineCharsCount;
            lRecLineCharsCount = GetRecLineChars(ref RecLineChars);
            m_Printer.RecLineChars = RecLineChars[1];
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + compProp + " - Prop." + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + compName + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "VAT Registered TIN: " + compTIN + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "MIN: " + compMIN + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + compAddress + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + compPosDesc + " S/N: " + compSerialNo + "\n");
            m_Printer.RecLineChars = RecLineChars[0];
        }
        private void GetTransTypeID()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select transactionTypeID from tbl_transactionType where transactionType = '" + cmbTransType.Text + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                transTypeID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
            }
            else
            {
                transTypeID = 0;                
            }
        }
        private void GetMachineName()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select machineName from tbl_posReg where machineNo = '" + comboBox1.Text + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                machName = cs.dbSearchData.Rows[0][0].ToString();
            }
            else
            {
                machName = "";
            }
        }
        #endregion

        private void frmTransList_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReleasingPrinter();
        }

        private void btnPrint_Leave(object sender, EventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                dgw.CurrentRow.Selected = true;
                dgw.Focus();
            }
            else
            {
                //no action
            }
           
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            GetTransTypeID();// get transaction type id
            GetMachineName();// get current machine name
            if (dgw.Rows.Count > 0)
            {
                if (transTypeID == 0)
                {
                    MessageBox.Show("If you print transaction list report you need to specify transaction type. \n Thank you.", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    DialogResult res;
                    res = MessageBox.Show("Do you want to print transaction list ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        try
                        {
                            transactionListReport();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    else
                    {
                        return;
                    }
                }               
            }
            else
            {
                MessageBox.Show("No transaction(s) found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }                      
        }

        private void cmbTransType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}

