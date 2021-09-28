using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class frmTransactionsMenu : Form
    {
        connString cs = new connString();
        Product_Menu.sharedData sd = new Product_Menu.sharedData();
        
        public frmTransactionsMenu()
        {
            InitializeComponent();
        }

        private void btnCusReg_Click(object sender, EventArgs e)
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select transactionTypeID from tbl_transactionType ");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 1)
            {
                Product_Menu.frmPos fp = new Product_Menu.frmPos();
                Company.frmTansTypeList ft = new Company.frmTansTypeList(fp);
                ft.posTransactionAccessType = 1;
                ft.ShowDialog();
            }

            else
            {
                //checking if there is default transaction type in database
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("select transactionTypeID from tbl_transactionType");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    sd.loadDefaultTransactionType();
                    Product_Menu.frmPos fp = new Product_Menu.frmPos();
                    fp.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Create default transaction type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private void btnCI_Click(object sender, EventArgs e)
        {
            frmTempChargeInvoice ft = new frmTempChargeInvoice();
            ft.ShowDialog();
        }
    }
}
