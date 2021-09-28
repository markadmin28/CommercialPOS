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
    public partial class frmProdTrans : Form
    {
        connString cs = new connString();
        PosPrinter m_Printer = null;
        public string productId = "";
         
        public frmProdTrans()
        {
            InitializeComponent();
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select POS ID", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                comboBox1.Focus();
                return;
            }
            else
            {
                if (cmbTransType.Text == "")
                {
                    MessageBox.Show("Select Trans Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbTransType.Focus();
                    return;
                }
                else
                {
                    if (txtProdId.Text == "")
                    {
                        MessageBox.Show("Press 'Enter' to Select Product", "Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        txtProdId.Focus();
                        return;
                    }
                    else
                    {
                        int rowNo = 0;
                        string machineId = comboBox1.Text;
                        cs.connDB();

                        cs.dbSearchData = cs.DISPLAY("sp_productTransList @start = '" + dateTimePicker1.Value.ToString() + "', @cutOff = '" + dateTimePicker2.Value.ToString() + "' ,@machineId = '" + machineId + "' , @transactionType = '" + cmbTransType.Text + "',@prodId = '" + productId + "'");
                        cs.disconMy();
                        dgw.Rows.Clear();
                        if (cs.dbSearchData.Rows.Count > 0)
                        {

                            for (int i = 0; i <= cs.dbSearchData.Rows.Count - 1; i++)
                            {
                                rowNo += 1;
                                dgw.Rows.Add((rowNo), cs.dbSearchData.Rows[i][0], cs.dbSearchData.Rows[i][1], cs.dbSearchData.Rows[i][2], cs.dbSearchData.Rows[i][3], cs.dbSearchData.Rows[i][4], cs.dbSearchData.Rows[i][5], cs.dbSearchData.Rows[i][6], cs.dbSearchData.Rows[i][7], cs.dbSearchData.Rows[i][8], cs.dbSearchData.Rows[i][9], cs.dbSearchData.Rows[i][11]);
                            }
                            dgw.CurrentRow.Selected = false;

                        }
                        else
                        {
                            dgw.Rows.Clear();
                            MessageBox.Show("No Data found!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    
                }
            }
     
            if (dgw.Rows.Count > 0)
            {
                txtUnit.Text = dgw.CurrentRow.Cells[11].Value.ToString();
            }
            else
            {
                txtUnit.Text = "-";
            }

        }
        
        private void transactionTypeDisplay()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select * from tbl_transactionType");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                cmbTransType.Items.Clear();
                for (int i = 0; i <= cs.dbSearchData.Rows.Count - 1; i++)
                {
                    cmbTransType.Items.Add(cs.dbSearchData.Rows[i][2]);
                }
            }
            else
            {
                cmbTransType.Items.Clear();
                productId = "";
            }
        }

        private void frmProdTrans_Load(object sender, EventArgs e)
        {
            transactionTypeDisplay();
            backgroundWorker1.RunWorkerAsync(2000);
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            loadPosID();
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

        private void dgw_Leave(object sender, EventArgs e)
        {
             
            
        }

        private void txtProdId_KeyPress(object sender, KeyPressEventArgs e)
        {
            Product_Menu.frmProdSearch frm = new Product_Menu.frmProdSearch();
            frm.Owner = this;          
            if (e.KeyChar == (char)Keys.Enter)
            {                                                 
                    frm.isProdTrans = 1;
                    frm.ShowDialog();                
            }
        }

        private void txtProdId_Enter(object sender, EventArgs e)
        {
            txtProdId.SelectAll();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            dateTimePicker1.Select();
            dateTimePicker1.Focus();
        }

        private void dgw_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calcRows();
        }
        private void calcRows()
        {
            decimal totalSalesAmt = 0;
            decimal totalQty = 0;
            lblRows.Text = dgw.Rows.Count.ToString();

            for (int i =0; i <= dgw.Rows.Count -1; i++)
            {
                totalSalesAmt += Convert.ToDecimal(dgw.Rows[i].Cells[8].Value.ToString() );
                totalQty += Convert.ToDecimal(dgw.Rows[i].Cells[5].Value.ToString());
            }
            textBox5.Text = totalSalesAmt.ToString("n2");
            textBox7.Text = totalQty.ToString("n2");
             
        }

        private void dgw_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            calcRows();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                prodTransListReport();
            }
            else
            {
                MessageBox.Show("No data to print!", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
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
        private void PrintReceiptHeader()
        {
            
            string compProp;
            string compName;
            string compTIN;
            string compMIN;
            string compAddress;
            string compPosDesc;
            string compSerialNo;
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
        private void prodTransListReport()
        {
            DateTime dt = DateTime.Now;
            string dtTime = "";
            string strHolder = "";
            double ttl = 0;
            double subTotal = 0;
            decimal qty = 0;
            decimal sellPrice = 0;
            string discnt = "";
            string machineId = comboBox1.Text;
            try
            {


                PrintReceiptHeader();

                int[] RecLineChars = new int[MAX_LINE_WIDTHS] { 0, 0 };
                long lRecLineCharsCount;
                lRecLineCharsCount = GetRecLineChars(ref RecLineChars);
                m_Printer.RecLineChars = RecLineChars[1];

                strHolder = MakePrintString(m_Printer.RecLineChars, DateTime.Now.ToString("MMM dd, yyy (ddd) hh:mm tt"), posUserName.userName);
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|10uF" + strHolder + "\n" + "\u001b|10uF");
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "-----PRODUCT TRANSACTION REPORT-----" + "\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "TRANSACTION TYPE: " + cmbTransType.Text + "\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "PERIOD: " + dateTimePicker1.Value.ToString() + " - " + dateTimePicker2.Value.ToString() + "\n\n");

                m_Printer.PrintNormal(PrinterStation.Receipt,txtProdId.Text + "\n\n");

                cs.connDB();
            cs.dbSearchData = cs.DISPLAY("sp_productTransList @start = '" + dateTimePicker1.Value.ToString() + "', @cutOff = '" + dateTimePicker2.Value.ToString() + "' ,@machineId = '" + machineId + "' , @transactionType = '" + cmbTransType.Text + "',@prodId = '" + productId + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                for (int i = 0; i <= cs.dbSearchData.Rows.Count - 1; i++)
                {
                    
                    dtTime = cs.dbSearchData.Rows[i][1].ToString();
                    ttl = Convert.ToDouble(cs.dbSearchData.Rows[i][7].ToString());
                    qty = Convert.ToDecimal(cs.dbSearchData.Rows[i][4].ToString());
                    sellPrice = Convert.ToDecimal(cs.dbSearchData.Rows[i][5].ToString());
                    discnt = cs.dbSearchData.Rows[i][6].ToString();
                    subTotal += ttl;
                    strHolder = MakePrintString(m_Printer.RecLineChars, dtTime.ToString() + "  " + qty + "  " + sellPrice + " (" + discnt + ")", ttl.ToString("n2"));
                    m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                }
            }
            strHolder = MakePrintString(m_Printer.RecLineChars, "TOTAL SALES AMT", subTotal.ToString("n2"));
            m_Printer.PrintNormal(PrinterStation.Receipt, "\n" + strHolder + "\n");

            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|fP");
            m_Printer.RecLineChars = RecLineChars[0];
        }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Printer message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
 
            }

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
        private int BackgroundProcessLogicMethod(BackgroundWorker bw, int a)
        {
            int result = 0;
            Thread.Sleep(0);
            LoadPrinter();
            return result;
        }
        public void LoadPrinter()
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

        private void frmProdTrans_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReleasingPrinter();
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
    }
}
