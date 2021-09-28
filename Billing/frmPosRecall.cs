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
    public partial class frmPosRecall : Form
    {
        connString cs = new connString();
        Product_Menu.frmPos fp = null;
     

        public frmPosRecall(Product_Menu.frmPos _fp)
        {
            InitializeComponent();
            fp = _fp;
        }
         
        private void tabPage1_Enter(object sender, EventArgs e)
        {
            txtSuspendID.Focus();
        }
        private void showTransRecall()
        {
            cs.connDB();            
            cs.dbSearchData = cs.DISPLAY("declare @machineName nvarchar(100) = '" + cs.machineName + "'   select distinct tt.suspendNo ,(select top 1 format(prodDateAdded,'hh:mm tt') from tbl_tempBilling where tt.suspendNo = suspendNo and machineID = @machineName  and transactionTypeID = '" + s_transactionType.transactionType + "'  and datediff(day,prodDateAdded,'" + DateTime.Now + "') =0 ) as time from tbl_tempBilling tt where isSuspended  =1   and machineID = @machineName  and transactionTypeID = '" + s_transactionType.transactionType + "' and datediff(day,prodDateAdded,'" + DateTime.Now + "') =0");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i =0; i<= cs.dbSearchData.Rows.Count -1; i++)
                {
                    dgw.Rows.Add((cs.dbSearchData.Rows[i][0].ToString()), cs.dbSearchData.Rows[i][1].ToString());
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

        private void frmPosRecall_Load(object sender, EventArgs e)
        {
            showTransRecall();
        }

        private void txtSuspendID_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSuspendID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (dgw.Rows.Count > 0)
                {
                    if (dgw.Rows.Count == 1)
                    {
                        dgw.CurrentRow.Selected = true;
                        dgw.Focus();
                    }
                    else
                    {                        
                        dgw.CurrentCell = dgw.Rows[dgw.Rows.Count - 1].Cells[0];
                        dgw.Focus();
                    }
                }
                else
                {
                    //no action
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (txtSuspendID.Text == "")
                {
                    this.Dispose();
                }
                else
                {
                    txtSuspendID.Text = "";
                }
            }
            if (e.KeyCode == Keys.Enter)
            {                
                validateSuspendNo();
            }
        }
        private void validateSuspendNo()
        {
            if (fp.dgw.Rows.Count > 0)
            {
                MessageBox.Show("Invalid action!", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (txtSuspendID.Text == "")
                {
                    MessageBox.Show("Select Suspend transaction!", "Suspend validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    cs.connDB();
                    cs.dbSearchData = cs.DISPLAY("select machineID from tbl_tempBilling where suspendNo = '" + txtSuspendID.Text.Trim() + "' and machineID = '" + cs.machineName + "'");
                    cs.disconMy();
                    if (cs.dbSearchData.Rows.Count > 0)
                    {
                        cs.connDB();
                        cs.updateData = "update tbl_tempBilling set isSuspended = '" + cs.isSuspended + "'  where suspendNo = '" + txtSuspendID.Text.Trim() + "' and machineID = '" + cs.machineName + "' and datediff(day,prodDateAdded,'" + DateTime.Now + "') =0";
                        cs.IUD(cs.updateData);
                        cs.disconMy();
                        fp.showTempBillingItemsList();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Suspend No.", "Suspend No validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            
        }

        private void dgw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                txtSuspendID.Focus();
                dgw.CurrentRow.Selected = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                
                txtSuspendID.Text = dgw.CurrentRow.Cells[0].Value.ToString();
                fp.suspendNo = Convert.ToInt32(txtSuspendID.Text.ToString());
                txtSuspendID.Focus();
                dgw.CurrentRow.Selected = false;
            }
        }

        private void txtSuspendID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar)&&(Keys)e.KeyChar!= Keys.Back )
            {
                e.Handled = true;
            }
        }

        private void frmPosRecall_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
