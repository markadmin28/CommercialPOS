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
    public partial class frmSetDiscount : Form
    {
        connString cs = new connString();
        decimal discID = 0;
        public frmSetDiscount()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmSetDiscount_Load(object sender, EventArgs e)
        {
            displayDiscount();
        }
        private void displayDiscount()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("customer_discount_discDisplay");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i =0; i <= cs.dbSearchData.Rows.Count -1; i++)
                {
                    dgw.Rows.Add((cs.dbSearchData.Rows[i][0]), cs.dbSearchData.Rows[i][1], cs.dbSearchData.Rows[i][2], cs.dbSearchData.Rows[i][3]);

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

        private void dgw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnClear.PerformClick();
            }
            
            if (e.KeyCode == Keys.Tab)
            {
                txtDisc.Focus();
            }
        }

        private void dgw_Leave(object sender, EventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                dgw.CurrentRow.Selected = false;
            }
            else

            {
                //no action
            }
        }

        private void dgw_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                txtDiscName.Text = dgw.CurrentRow.Cells[1].Value.ToString();
                txtDisc.Text = dgw.CurrentRow.Cells[2].Value.ToString();
                discID = Convert.ToDecimal(dgw.CurrentRow.Cells[3].Value.ToString());
            }
            else
            {
                txtDiscName.Text = "";
                txtDisc.Text = "";
                discID = 0;
            }
        }
        private void clearFields()
        {
            discID = 0;
            txtDiscName.Focus();
            txtDiscName.Text = "";
            txtDisc.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void txtDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar)&&(Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtDisc_Leave(object sender, EventArgs e)
        {
            txtDisc.SelectAll();
        }

        private void txtDiscName_Enter(object sender, EventArgs e)
        {
            txtDisc.Focus();
        }

        private void txtDisc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            discountCommand();
        }
        private void discountCommand()
        {
            if (discID == 0)
            {
                MessageBox.Show("Select Type of discount", "System message",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (txtDisc.Text == "")
                {
                    txtDisc.Text = "0";
                }
                if (Convert.ToDecimal(txtDisc.Text) > 100)
                {
                    MessageBox.Show("Maximum of 100% discount exceed", "Discount validation",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    cs.connDB();
                    cs.updateData = "update tbl_customer_discount set discount = '" + Convert.ToDecimal(txtDisc.Text) + "' where discountID = '" + discID + "'";
                    cs.IUD(cs.updateData);
                    cs.disconMy();
                    displayDiscount();
                    btnClear.PerformClick();
                }
                
            }
            
        }
    }
}
