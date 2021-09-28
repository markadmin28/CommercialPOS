using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Billing.OtherDiscounts
{
    public partial class frmDiscountList : Form
    {
        connString cs = new connString();
        Product_Menu.frmPos fp = null;
        string action = "Insert";
        string msg = "Discount added";
        string nNoteType = "CustomerDiscount";
        decimal discountID = 0;

        public frmDiscountList(Product_Menu.frmPos _fp)
        {
            InitializeComponent();
            fp = _fp;
        }

        private void frmDiscountList_Load(object sender, EventArgs e)
        {
            loadDiscountType();
            loadCusDiscData();
        }
        private void loadDiscountType()
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

        private void cmbDisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbDisc.Text == "")
                {
                    MessageBox.Show("Select discount type", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    txtDiscID.Focus();
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                string cusName = cmbDisc.Text;
                action = "Delete";
                msg = "Discount removed";
                fp.CustomerNameCommand(action, msg, cusName, nNoteType, txtDiscID.Text, txtCusName.Text, txtRemarks.Text, txtHomeAdd.Text,discountID);
                clearFields();
                this.Dispose();
            }
        }
        private void clearFields()
        {
            txtDiscID.Text = "";
            txtCusName.Text = "";
            txtHomeAdd.Text = "";
            txtRemarks.Text = "";
        }

        private void txtDiscID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (txtDiscID.Text != "")
                {
                    clearFields();  
                }
                else
                {
                    cmbDisc.Focus();
                    clearFields();
                }               
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDiscID.Text != "" && txtCusName.Text != "")
                {
                    DialogResult res;
                    res = MessageBox.Show("Do you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        string cusName = cmbDisc.Text;
                        
                        cs.connDB();
                        cs.dbSearchData = cs.DISPLAY("select discountID from tbl_customer_discount where discountDesc = '" + cmbDisc.Text + "'");
                        cs.disconMy();
                        if (cs.dbSearchData.Rows.Count > 0)
                        {
                            discountID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0].ToString());
                        }
                        else
                        {
                            discountID = 0;
                        }


                        fp.CustomerNameCommand(action, msg, cusName, nNoteType , txtDiscID.Text, txtCusName.Text, txtRemarks.Text, txtHomeAdd.Text,discountID);


                        this.Dispose();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    customerDisplayByDiscID();
                }              
            }                        
        }
        private void customerDisplayByDiscID()
        {
            if (txtDiscID.Text == "")
            {
                frmCustomerDiscountList fcd = new frmCustomerDiscountList();
                fcd.Owner = this;
                fcd.ShowDialog();
            }
            else
            {
                int isActive = 0;
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("customer_master_displayByDiscID @discountDesc = '" + cmbDisc.Text + "', @cusDiscID = '" + txtDiscID.Text + "'");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    isActive = Convert.ToInt32(cs.dbSearchData.Rows[0][7].ToString());
                    if (isActive == 1)
                    {
                        txtCusName.Text = cs.dbSearchData.Rows[0][2].ToString();
                        txtRemarks.Text = cs.dbSearchData.Rows[0][5].ToString();
                        txtHomeAdd.Text = cs.dbSearchData.Rows[0][3].ToString();
                    }
                    else
                    {
                        clearFields();
                        MessageBox.Show("Customer is inactive, contact administrator", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    clearFields();
                    MessageBox.Show("ID not registered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }            
        }

        private void txtCusName_Enter(object sender, EventArgs e)
        {
            txtDiscID.Focus();
        }
        private void loadCusDiscData()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select Note,discID,discCusName,discRemarks,discHomeAdd from tbl_tempBilling_note where machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "' and datediff(day,dateAdded,'" + DateTime.Now + "') =0 and noteType = '" + nNoteType + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0 )
            {
                cmbDisc.Text = cs.dbSearchData.Rows[0][0].ToString();
                txtDiscID.Text = cs.dbSearchData.Rows[0][1].ToString();
                txtCusName.Text = cs.dbSearchData.Rows[0][2].ToString();
                txtRemarks.Text = cs.dbSearchData.Rows[0][3].ToString();
                txtHomeAdd.Text = cs.dbSearchData.Rows[0][4].ToString();
            }
            else
            {
                cmbDisc.Text = "";
                clearFields();
            }
        }

        private void cmbDisc_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearFields();
        }

        private void cmbDisc_TextChanged(object sender, EventArgs e)
        {
            
        }
        
    }
}
