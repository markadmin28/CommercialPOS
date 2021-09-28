using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Billing
{
    public partial class frmPosSuspendValidation : Form
    {
        Product_Menu.frmPos fp = null;
        connString cs = new connString();
        public int isDrawerRequest = 0;

        public frmPosSuspendValidation(Product_Menu.frmPos _fp)
        {
            InitializeComponent();
            fp = _fp;
        }

        private void frmPosSuspendValidation_Load(object sender, EventArgs e)
        {

        }

        private void frmPosSuspendValidation_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
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

        private void txtP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validateAccount(txtUn.Text.Trim(), txtP.Text.Trim());
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void txtP_Leave(object sender, EventArgs e)
        {
            txtUn.Focus();
        }

        private void txtUn_Leave(object sender, EventArgs e)
        {
            txtP.Focus();
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            txtUn.Focus();
        }
        private void validateAccount(string un, string up)
        {

            string UT = "Cashier";
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select userID from tbl_user where userName = '" + un + "' and userPassword = '" + up + "' and userType <> '" + UT + "'  ");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                if (isDrawerRequest == 1)
                {
                    try
                    {
                        fp.OpenDrawer();
                    }
                   catch (Exception)
                    {
                        MessageBox.Show("Cash drawer not found!", "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;                            
                    }
                }
                else
                {
                    fp.suspendCommand();
                }                
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Invalid account!", "System message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUn.Focus();
                txtUn.SelectAll();
                return;
            }
        }
    }
}
