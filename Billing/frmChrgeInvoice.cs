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
    public partial class frmChrgeInvoice : Form
    {
        public double totalCash = 0;
        public double totalChange = 0;
        Product_Menu.frmPos fp = null;

        public frmChrgeInvoice(Product_Menu.frmPos _fp)
        {
            InitializeComponent();
            fp = _fp;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmChrgeInvoice_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            fp.txtItemCode.Text = "";
            this.Dispose();
        }
        private void ClearFields()
        {
            txtChargeTo.Text = "";
            txtTin.Text = "";
            txtTerms.Text = "";
            txtAddress.Text = "";
            txtOsca.Text = "";
            txtSc.Text = "";
            txtBusiness.Text = "";
            txtChargeTo.Focus();
        }
       
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtChargeTo.Text == "")
            {
                MessageBox.Show("Check your entry!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChargeTo.Focus();
                return;
            }
            else
            {
                DialogResult res = MessageBox.Show("Do you want to settle this transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    fp.saveDailySales(totalCash, totalChange);
                    Billing.ChargeInvoice.frmRptChargeInvoice fci = new Billing.ChargeInvoice.frmRptChargeInvoice(this);                    
                    if (s_chargeInvoicePrinting.chargeInvoice == 1)
                    {                        
                        fci.ShowDialog();
                    }
                    else if (s_chargeInvoicePrinting.chargeInvoice ==2)
                    {                       
                        fci.LoadCharInvoiceItems();
                        fci.ParamData();
                        fci.autoPrint_chargeInvoiceReceipt();
                      
                    }
                    else if (s_chargeInvoicePrinting.chargeInvoice == 3)
                    {
                        //.....................
                    }
                   
                    this.Dispose();
                }
                else
                {
                    return;
                }

            }
        }

        private void txtChargeTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtChargeTo.Text == "")
                {
                    CustomerMgt.frmCustomerChargeInvoiceList fcc = new CustomerMgt.frmCustomerChargeInvoiceList();
                    fcc.Owner = this;
                    fcc.ciViewType = 1;
                    fcc.ShowDialog();
                }
                else
                {
                    txtTin.Focus();
                }
              
            }
        }

        private void txtTin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTerms.Focus();
            }
        }

        private void txtTerms_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress.Focus();
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOsca.Focus();
            }
        }

        private void txtOsca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSc.Focus();
            }
        }

        private void txtSc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBusiness.Focus();
            }
        }

        private void txtBusiness_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtChargeTo.Focus();
            }
        }

        private void txtChargeTo_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtTin_Enter(object sender, EventArgs e)
        {
            if (txtChargeTo.Text == "")
            {
                txtChargeTo.Focus();
                MessageBox.Show("Enter Customer name or press [Enter] to Search Customers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                //no action
            }
        }
    }
}
