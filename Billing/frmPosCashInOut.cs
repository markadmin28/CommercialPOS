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
    public partial class frmPosCashInOut : Form
    {
        connString cs = new connString();
        decimal cashInOutID = 0;
        string typeDescription = "Cash ";
        int inOut = 0;
        Product_Menu.frmPos fp = null;

        public frmPosCashInOut(Product_Menu.frmPos _fp)
        {
            InitializeComponent();
            fp = _fp;
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            cmbInOut.Focus();
        }

        private void txtAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMemo.Focus();
            }

        }

        private void txtMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk.Focus();
            }

        }

        private void cmbInOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAmt.Focus();
            }
        }

        private void txtPosID_Enter(object sender, EventArgs e)
        {
            btnOk.Focus();
        }

        private void txtAmt_Leave(object sender, EventArgs e)
        {
            if (txtAmt.Text == "")
            {
            }
            else 
            {
                double amt = 0;
                amt = Convert.ToDouble(txtAmt.Text);
                txtAmt.Text = amt.ToString("n2");
            }
           
        }

        private void frmPosCashInOut_Load(object sender, EventArgs e)
        {
            txtPosID.Text = posMachineNo.machineNo;
            txtCashier.Text = posUserName.userName;
        }
        public void cashInOutCommand()
        {
            if (txtAmt.Text == "")
            {
                MessageBox.Show("Invalid Amount!", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
            
            if (inOut == 1)
            {
                typeDescription = "Cash in";
            }
            else
            {
                typeDescription = "Cash out";
            }
            
            genCashInOutID();
            cs.connDB();
            cs.insertData = "cashInOut @cashInOutID = '" + cashInOutID + "',@typeDesc = '" + typeDescription + "' ,@inOut = '" + inOut + "',@amount = '" + Convert.ToDecimal(txtAmt.Text) + "',@memo = '" + txtMemo.Text + "',@machineName = '" + cs.machineName + "',@machineNo = '" + posMachineNo.machineNo + "',@addedBy = '" + addedByUser.addedBy + "',@dateAdded = '" + DateTime.Now + "'";
            cs.IUD(cs.insertData);
            cs.disconMy();

            MessageBox.Show(typeDescription.ToString() + " Successfully saved!", "Database message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (receipt_settings.receiptSettings == 1)
            {                   
                    try
                    {
                        fp.printCashInOutReceipt(cmbInOut.Text, Convert.ToDouble(txtAmt.Text), txtMemo.Text);
                    }
                   catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
            }
            else
            {
                Billing.CashInOutRecipt.frmCashInOutRcpt fcio = new CashInOutRecipt.frmCashInOutRcpt(this);
                fcio.ShowDialog();
            }                       
            this.Dispose();
            return;
            }
        }
        private void printCommand()
        {
            Billing.CashInOutRecipt.frmCashInOutRcpt fcio = new CashInOutRecipt.frmCashInOutRcpt(this);
            fcio.autoPrint_CashInOutReceipt();
        }
        private void cashInOutClearFields()
        {
            cmbInOut.Text = null;
            txtAmt.Text = "";
            txtMemo.Text = "";
            cashInOutID = 0;
            cmbInOut.Focus();
        }
        private void genCashInOutID()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(max(cashInOUtID),1000000000) + 1 as cashInOUtID from tbl_cashInOut");
            cs.disconMy();            
                cashInOutID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0].ToString());
            
        }
         

        private void cmbInOut_Leave(object sender, EventArgs e)
        {
            if (cmbInOut.Text == "")
            { }
            else
            {                
                    if (cmbInOut.SelectedIndex == 0)
                    {
                        inOut = 1;
                    }
                    else
                    {
                        inOut = 2;
                    }                 
            }
         
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (AccType.userAccType == "Administrator")
            {
                cashInOutCommand();
            }
            else
            {
                frmPosCashInOutAuthorization fpca = new frmPosCashInOutAuthorization(this);
                fpca.ShowDialog();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmPosCashInOut_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
