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
    public partial class frmChangeFund : Form
    {
        //private Font verdana10Font;
        //private StreamReader reader;


        connString cs = new connString();
        Product_Menu.sharedData sd = new Product_Menu.sharedData();
        Product_Menu.frmPos fp = null;

        decimal cashInOutID = 0;
        string typeDesc = "Change Fund";
        int inout = 3;
        string memo = "Change Fund";
        public frmChangeFund(Product_Menu.frmPos _fp)
            
        {
            InitializeComponent();
            fp = _fp;
        }
        
        private void frmChangeFund_Load(object sender, EventArgs e)
        {
            txtCashier.Text = posUserName.userName.ToString();
            txtPosID.Text = posMachineNo.machineNo.ToString();
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            txtCF.Focus();
        }
        private void saveChangeFund()
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("select cashInOutID from tbl_CashInOut where datediff(day,dateAdded,'" + DateTime.Now + "') =0 and machineNo = '" + posMachineNo.machineNo + "' and inOut = 3 and machineName = '" + cs.machineName + "'");
                cs.disconMy(); 
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    //no action
                }
                else
                {
                    genCashInOUt();
                    cs.connDB();
                    cs.insertData = "insert into tbl_CashInOut (cashInOutID,typeDesc,inOut,amount,memo,machineName,machineNo,addedBy,dateAdded) values" +
                                    "('" + cashInOutID + "', '" + typeDesc + "','" + inout + "','" + Convert.ToDouble(txtCF.Text) + "','" + memo + "','" + cs.machineName + "','" + posMachineNo.machineNo + "','" + addedByUser.addedBy + "','" + DateTime.Now + "' )";
                    cs.IUD(cs.insertData);
                    cs.disconMy();
                }
                if (receipt_settings.receiptSettings ==1) // cheking if drawer is set to automatic open or not based on print automatic
                {
                    fp.OpenDrawer();
                    fp.OpenDrawer();
                }                              
            else
                {
                    //no action
                }
                MessageBox.Show("Change Fund Saved!", "Database message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }            
            else
            {
                txtCF.Focus();
                txtCF.SelectAll();
                return;
            }
        }
        private void genCashInOUt()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(max(cashInOutID),1000000000) + 1 from tbl_CashInOut");
            cs.disconMy();
            cashInOutID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
        }

        private void txtCF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                    try
                { 
                    saveChangeFund();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
                
            }
        }

        private void txtCF_Leave(object sender, EventArgs e)
        {
            txtCF.Focus();
        }

        private void frmChangeFund_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
        private void openDrawer()
        {


            string s = " ";

            PrintDocument p = new PrintDocument();
            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString(s, new Font("Times New Roman", 12), new SolidBrush(Color.Black), new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

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

        private void txtCF_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
