using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.CustomerMgt
{
    public partial class frmCustomerChargeInvoice : Form
    {
        connString cs = new connString();
        string cusChrgInvc = "";
        public decimal ciid = 0;        
        DateTime da = DateTime.Now;

        public frmCustomerChargeInvoice()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void CustomerChargeInvoice()
        {
            string cn = txtChargeTo.Text;
            string tin = txtTin.Text;
            string trms = txtTerms.Text;
            string add = txtAddress.Text;
            string osca = txtOsca.Text;
            string sc = txtSc.Text;
            string bs = txtBusiness.Text;
            decimal ab = addedByUser.addedBy;
            string msg = "";

            if (cn == "")
            {
                MessageBox.Show("Customer name cannot be empty!", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtChargeTo.Focus();
                return;
            }
            else
            {
                if (ciid == 0)
                {
                    CusChargeInvoiceGenId();// generate customer charge invoice id
                    msg = "added";
                }
                else
                {
                    //update data
                    msg = "updated";
                }                
                cs.connDB();
                cusChrgInvc = "sp_CustomerChargeInvoice @chargeInvoiceId = '" + ciid + "',@customerName = '" + cn + "',@tin = '" + tin + "',@terms = '" + trms + "',@address = '" + add + "',@osca = '" + osca + "',@sc = '" + sc + "',@busStyle = '" + bs + "',@addedBy = '" + ab + "',@dateAdded = '" + da + "'";
                cs.IUD(cusChrgInvc);
                cs.disconMy();
                MessageBox.Show("Charge Invoice Information successfully " + msg, "Success message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }

            
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
            ciid = 0;
        }
        private void CusChargeInvoiceGenId()
        {
            DataTable dt = new DataTable();
            cs.connDB();
            dt = cs.DISPLAY("sp_CustomerChargeInvoiceGenId");
            cs.disconMy();
            ciid = Convert.ToDecimal(dt.Rows[0][0]);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CustomerChargeInvoice();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtChargeTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTin.Focus();
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

        private void frmCustomerChargeInvoice_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmCustomerChargeInvoiceList fcl = new frmCustomerChargeInvoiceList();
            fcl.Owner = this;
            fcl.ciViewType = 2;
            fcl.ShowDialog();
        }
    }
}
