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

namespace POS.Company
{
    public partial class frmTansTypeList : Form
    {
        connString cs = new connString();
        public int posTransactionAccessType = 0; // 1 = adminsitrator | 0 = cashier
        public int isOtherReadingCommand = 0;
        decimal transTypeID = 0;
        Product_Menu.frmPos fp = null;
        //decimal transTypeID;
        public frmTansTypeList(Product_Menu.frmPos _fp)
        {
            InitializeComponent();
            fp = _fp;
        }
        private void loadTransactionType()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select transactionType from tbl_transactionType");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                cmbTransList.Items.Clear();
                for (int i =0; i <= cs.dbSearchData.Rows.Count -1; i++)
                {
                    cmbTransList.Items.Add(cs.dbSearchData.Rows[i][0]);
                }
            }
            else
            {
                cmbTransList.Items.Clear();
            }
        }

        private void frmTansTypeList_Load(object sender, EventArgs e)
        {
            loadTransactionType();
        }

        private void cmbTransList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbTransList.Text == "")
                {
                    MessageBox.Show("Select transaction type", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    if (isOtherReadingCommand == 1) // if reading then print automatically
                    {
                        
                        cs.connDB();
                        cs.dbSearchData = cs.DISPLAY("select transactionTypeID,transactionType from tbl_transactionType where transactionType = '" + cmbTransList.Text + "'");
                        cs.disconMy();
                        if (cs.dbSearchData.Rows.Count > 0)
                        { 
                            transTypeID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0].ToString());
                        }
                     
                        Billing.frmReadingValidation frv = new Billing.frmReadingValidation(fp);
                        frv.isReadingOthersCommand = 1;
                        frv.transactionListDescription = cmbTransList.Text;
                        frv.transTypeID = transTypeID;
                        frv.ShowDialog();
                    }
                    else // if is not reading then proceed to POS
                    {
                        Product_Menu.frmPos fpos = new Product_Menu.frmPos();
                        cs.connDB();
                        cs.dbSearchData = cs.DISPLAY("select transactionTypeID,transactionType from tbl_transactionType where transactionType = '" + cmbTransList.Text + "'");
                        cs.disconMy();
                        if (cs.dbSearchData.Rows.Count > 0)
                        {
                            s_transactionType.transactionType = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
                            s_transactionTypeDesc.transactionTypeDesc = cs.dbSearchData.Rows[0][1].ToString();
                        }
                        else
                        {
                            s_transactionType.transactionType = 0;
                            s_transactionTypeDesc.transactionTypeDesc = "";
                        }
                        this.Dispose();
                        fpos.ShowDialog();
                    }                     
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (posTransactionAccessType == 0)
                {
                    frmLogin fl = new frmLogin();
                    this.Dispose();
                    fl.Show();
                }
                else
                {
                    this.Dispose();
                }
              
            }
        }
         
    }
}
