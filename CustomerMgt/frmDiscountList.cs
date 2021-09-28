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
    public partial class frmDiscountList : Form
    {
        connString cs = new connString();
        decimal discID = 0;
        string action = "";
      
        public frmDiscountList()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmDiscountList_Load(object sender, EventArgs e)
        {
            DeletionAccess();
            displayDiscountList();
        }
        private void DeletionAccess()
        {
            if (s_allowDeletion.allowDeletion ==1)
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void btnSave_Click(object sender, EventArgs e)
        {          
            if (discID == 0)
            {
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("select discountId from tbl_customer_discount where discountDesc = '" + txtDisc.Text + "'");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    MessageBox.Show("Discount description already existed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    action = "Insert";
                    genDiscID();
                    CustomerDiscountListCommand(action);
                }
            }
            else
            {               
                    action = "Insert";
                    CustomerDiscountListCommand(action);                                
            }
            
        }
        private void CustomerDiscountListCommand(string act)
        {
            cs.connDB();
            cs.insertData = "customer_discount @action = '" + act + "',@discountID = '" + discID + "',@discountDesc = '" + txtDisc.Text + "',@dateAdded = '" + DateTime.Now + "',@addedBy = '" + addedByUser.addedBy + "'";
            cs.IUD(cs.insertData);
            cs.disconMy();
            clearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (discID == 0 || txtDisc.Text == "")
            {
                MessageBox.Show("Select Discount to remove!", "System message",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                action = "Delete";
                CustomerDiscountListCommand(action);                                
                return;
            }
           
        }
        private void genDiscID()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(max(discountID),1000) + 1 from tbl_customer_discount");
            cs.disconMy();
            discID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0].ToString());
        }
        private void clearFields()
        {
            txtDisc.Focus();
            txtDisc.Text = "";
            discID = 0;
        }
        private void displayDiscountList()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("customer_discount_display @discDesc = '" + txtDisc.Text + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i = 0; i <= cs.dbSearchData.Rows.Count - 1; i++)
                {
                    dgw.Rows.Add((cs.dbSearchData.Rows[i][0]), cs.dbSearchData.Rows[i][2].ToString(), cs.dbSearchData.Rows[i][1].ToString());
                }
                if (dgw.Rows.Count > 0)
                {
                    dgw.CurrentRow.Selected = false;
                }
                else
                {
                    //no action
                }

            }
            else
            {
                dgw.Rows.Clear();
            }
        }

        private void txtDisc_TextChanged(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            if (txt.Text.StartsWith(" "))
            {
                txt.Text = "";
            }
            displayDiscountList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
             
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            clearFields();
        }

        private void txtDisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDisc.Text == "")
                {
                    MessageBox.Show("Enter discount description", "Ssytem message",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    btnSave.PerformClick();
                }
            }
        }

        private void dgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                txtDisc.Text = dgw.CurrentRow.Cells[1].Value.ToString();
              
            }
            else
            {
                txtDisc.Text = "";
               
            }
            
        }

        private void dgw_Leave(object sender, EventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                dgw.CurrentRow.Selected = false;
            }
        }

        private void dgw_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                discID = Convert.ToDecimal(dgw.CurrentRow.Cells[2].Value.ToString());
            }
            else
            {
                discID = 0;
            }            
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
