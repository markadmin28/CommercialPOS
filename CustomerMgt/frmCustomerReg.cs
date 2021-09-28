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
    public partial class frmCustomerReg : Form
    {
        connString cs = new connString();       
        decimal discID = 0;
        int isActive = 0;
        public frmCustomerReg()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmCustomerReg_Load(object sender, EventArgs e)
        {
            rbtnInactive.Checked = true;
            grpDiscount.Enabled = false;
            displayDiscList();
        }

        private void chckDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chckDiscount.Checked == true)
            {
                grpDiscount.Enabled = true;

            }
            else
            {
                grpDiscount.Enabled = false;
                cmbDisc.Text = "";
                txtDiscID.Text = "";
                txtRemarks.Text = "";
            }
        }
        private void displayDiscList()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("customer_discount_discDisplay");
            cs.disconMy();            
            if (cs.dbSearchData.Rows.Count > 0)
            {
                cmbDisc.Items.Clear();
                for (int i =0; i <= cs.dbSearchData.Rows.Count -1; i++)
                {
                    cmbDisc.Items.Add(cs.dbSearchData.Rows[i][1].ToString());
                }
            }
            else
            {
                cmbDisc.Items.Clear();
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            customerMasterCommand();
        }
        private void customerMasterCommand()
        {  
            if (txtCusID.Text == "")
            {
                MessageBox.Show("Check customer id", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (rbtnActive.Checked == true && rbtnInactive.Checked == false)
                {
                    isActive = 1;
                }
                else if (rbtnActive.Checked == false && rbtnInactive.Checked == true)
                {
                    isActive = 0;
                }

                if (chckDiscount.Checked == true) // if customer has discount
                {
                    cs.connDB();
                    cs.dbSearchData = cs.DISPLAY("select discountID from tbl_customer_discount where discountDesc = '" + cmbDisc.Text + "'");
                    cs.disconMy();
                    if (cs.dbSearchData.Rows.Count > 0)
                    {
                        discID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0].ToString());
                        customerMaster();
                    }
                    else
                    {
                        discID = 0;
                        MessageBox.Show("Select Discount type properly", "Discount validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else // if customer has no discount
                {
                    customerMaster();
                }
            }                          
        }
        private void customerMaster()
        {
            cs.connDB();//save customer data
            cs.insertData = "customer_master @customerID = '" + txtCusID.Text + "' ,@cusFirstName = '" + txtFn.Text + "' ,@cusMI = '" + txtMi.Text + "' ,@cusLastName = '" + txtLn.Text + "' ,@cusAge = '" + txtAge.Text + "' ,@cusHomeAddress = '" + txtHm.Text + "' ,@cusDiscType = '" + discID + "' ,@cusDiscID = '" + txtDiscID.Text + "' ,@cusDiscRemarks = '" + txtRemarks.Text + "' ,@addedBy = '" + addedByUser.addedBy + "' ,@dateAdded = '" + DateTime.Now + "',@isActive = '" + isActive + "'";
            cs.IUD(cs.insertData);
            cs.disconMy();
            btnClear.PerformClick();
            MessageBox.Show("Saved!", "Database message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            return;
        }
        private void loadCustomerMaster()
        {
            if (txtCusID.Text == "")
            {
                txtCusID.Focus();
                return;
            }
            else
            {
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("customer_master_displayByID @customerID = '" + txtCusID.Text + "'");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    txtCusID.ReadOnly = true;
                    txtFn.Text = cs.dbSearchData.Rows[0][1].ToString();
                    txtMi.Text = cs.dbSearchData.Rows[0][2].ToString();
                    txtLn.Text = cs.dbSearchData.Rows[0][3].ToString();
                    txtAge.Text = cs.dbSearchData.Rows[0][4].ToString();
                    txtHm.Text = cs.dbSearchData.Rows[0][5].ToString();
                    cmbDisc.Text = cs.dbSearchData.Rows[0][6].ToString();
                    txtDiscID.Text = cs.dbSearchData.Rows[0][7].ToString();
                    txtRemarks.Text = cs.dbSearchData.Rows[0][8].ToString();
                    isActive = Convert.ToInt32(cs.dbSearchData.Rows[0][9]);
                }
                else
                {
                    txtCusID.ReadOnly = false;
                    txtFn.Text = "";
                    txtMi.Text = "";
                    txtLn.Text = "";
                    txtAge.Text = "";
                    txtHm.Text = "";
                    cmbDisc.Text = "";
                    txtDiscID.Text = "";
                    txtRemarks.Text = "";
                    isActive = 0;
                }
                if (isActive == 0)
                {
                    rbtnInactive.Checked = true;
                }
                else
                {
                    rbtnActive.Checked = true;
                }
                if (cmbDisc.Text != "")
                {
                    chckDiscount.Checked = true;
                    grpDiscount.Enabled = true;
                }
                else
                {
                    chckDiscount.Checked = false;
                    grpDiscount.Enabled = false;
                }
            }            
        }

        private void txtCusID_Leave(object sender, EventArgs e)
        {
            loadCustomerMaster();
        }
        private void clearFields()
        {
            foreach (Control ctrl in this.groupBox2.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ctrl.Text = "";
                }
            }
            txtCusID.ReadOnly = false;
            chckDiscount.Checked = false;
            grpDiscount.Enabled = false;
            rbtnInactive.Checked = true;
            cmbDisc.Text = "";
            txtDiscID.Text = "";
            txtRemarks.Text = "";
            txtCusID.Focus();
            discID = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void txtCusID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCusID.Text == "")
                {
                    frmCustomerList fcl = new frmCustomerList(this);
                    fcl.ShowDialog();
                }
                else
                {
                    txtFn.Focus();
                }
            }
        }

        private void txtFn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMi.Focus();
            }
        }

        private void txtMi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLn.Focus();
            }
        }

        private void txtLn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAge.Focus();
            }
        }

        private void txtAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHm.Focus();
            }
        }
    }
}
