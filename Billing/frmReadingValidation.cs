using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace POS.Billing
{
    public partial class frmReadingValidation : Form
    {
        connString cs = new connString();
        public int isReadingOthersCommand = 0; //0 = not others / 1 = others reading command
        public decimal transTypeID;
        public string transactionListDescription = "";
        string userFullName = "";
        decimal readBy = 0;
        Product_Menu.frmPos fp = null;

        public frmReadingValidation(Product_Menu.frmPos _fp)
        {
            InitializeComponent();
            fp = _fp;
          
        }

        private void frmReadingValidation_Load(object sender, EventArgs e)
        {
           
        }
        private void validateAccount(string un, string up)
        {
            DailyReading.frmReadingRpt frr = new DailyReading.frmReadingRpt();
           
            string cashier = "Cashier";
            if (s_transactionTypeDesc.transactionTypeDesc != "SALES")
            {
                MessageBox.Show("You are in " + s_transactionTypeDesc.transactionTypeDesc + " Mode", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("select userID,userFullName from tbl_user where userName = '" + un + "' and userPassword = '" + up + "' and userType <> '" + cashier + "'  ");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    userFullName = cs.dbSearchData.Rows[0][1].ToString();
                   if (isReadingOthersCommand == 0)
                    {
                        if (receipt_settings.receiptSettings == 1)
                        {

                            readBy = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);                          
                            fp.DailyReadingPrintData(readBy);
                           
                        }
                        else
                        {
                            frr.readBy = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
                            frr.ShowDialog();
                        }                       
                    }                        
                   else
                    {
                         fp.printOthersReadingSummaryCommand(transactionListDescription, transTypeID, userFullName);
                       
                    }
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Unauthorized account!", "System message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    userFullName = "";
                    txtUn.Focus();
                    txtUn.SelectAll();
                    return;
                }
            }           
        }
        
        private void txtUn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtP.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void frmReadingValidation_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            txtUn.Focus();
        }

        private void txtP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               try
                {
                    validateAccount(txtUn.Text.Trim(), txtP.Text.Trim());
                }
                    catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
              
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
        private void printOtherReading(string transTypeDesc, decimal transTypeID)
        {
            double vatSale = 0;
            double vatExSale = 0;
            double totalSale = 0;
            double vat12 = 0;
            double grossPayable = 0;
            double discountAmt = 0;
            double totalPayable = 0;

            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("sp_ReadingOthers @machineName = '" + cs.machineName + "', @machineNo = '" + posMachineNo.machineNo + "', @transactionTypeID = '" + transTypeID + "', @dateNow = '" + DateTime.Now + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                vatSale = Convert.ToDouble(cs.dbSearchData.Rows[0][0]);
                vatExSale = Convert.ToDouble(cs.dbSearchData.Rows[0][1]);
                totalSale = Convert.ToDouble(cs.dbSearchData.Rows[0][2]);
                vat12 = Convert.ToDouble(cs.dbSearchData.Rows[0][3]);
                grossPayable = Convert.ToDouble(cs.dbSearchData.Rows[0][4]);
                discountAmt = Convert.ToDouble(cs.dbSearchData.Rows[0][5]);
                totalPayable = Convert.ToDouble(cs.dbSearchData.Rows[0][6]);
            }


            string s = posCompProp.compProp + Environment.NewLine + posCompName.compName + Environment.NewLine +
                "VAT Registered: " + posTIN.tin + Environment.NewLine + "MIN: " + posMIN.min + Environment.NewLine + posAddress.address +
                 Environment.NewLine + posPosDesc.posDesc + " S/N: " + posSerialNo.serialNo + Environment.NewLine + Environment.NewLine + "--------------------" +
                 Environment.NewLine + Environment.NewLine +
                 "Transaction type: " + transTypeDesc + Environment.NewLine + Environment.NewLine +
                 "VAT Sale: " + vatSale.ToString("n2") + Environment.NewLine +
                 "VAT Exempt Sale: " + vatExSale.ToString("n2") + Environment.NewLine +
                 "Total Sale: " + totalSale.ToString("n2") + Environment.NewLine +
                 "Total TAX: " + vat12.ToString("n2") + Environment.NewLine +
                 "Total Gross Payable: " + grossPayable.ToString("n2") + Environment.NewLine +
                 "Total Discount Amt: " + discountAmt.ToString("n2") + Environment.NewLine + Environment.NewLine +
                 "Total Gross Sales: " + totalPayable.ToString("n2") + Environment.NewLine + Environment.NewLine+
                 "--------------------" + Environment.NewLine + 
                 "Cashier: " + posUserName.userName + Environment.NewLine +
                 "Printed by: " + userFullName + Environment.NewLine +
                 "Date: " + DateTime.Now.ToString("MMM, dd, yyy hh:mm:ss tt")
                 ;


            PrintDocument p = new PrintDocument();
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString(s, new Font("Times New Roman", 10), new SolidBrush(Color.Black), new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

            };
            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
