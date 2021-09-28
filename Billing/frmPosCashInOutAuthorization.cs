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
    public partial class frmPosCashInOutAuthorization : Form
    {
        frmPosCashInOut fpc = null;
        connString cs = new connString();
        public frmPosCashInOutAuthorization(frmPosCashInOut _fpc)
        {
            InitializeComponent();
            fpc = _fpc;
        }

        private void frmPosCashInOutAuthorization_FormClosed(object sender, FormClosedEventArgs e)
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

        private void txtUn_MouseLeave(object sender, EventArgs e)
        {
            
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

        private void frmPosCashInOutAuthorization_Load(object sender, EventArgs e)
        {

        }
        private void validateAccount(string un, string up)
        {

            string UT = "Cashier";
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select userID from tbl_user where userName = '" + un + "' and userPassword = '" + up + "' and userType <> '" + UT + "'  ");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                fpc.cashInOutCommand();
                this.Dispose();

            }
            else
            {
                MessageBox.Show("Unauthorized account!", "System message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUn.Focus();
                txtUn.SelectAll();
                return;
            }
        }
    }
}
