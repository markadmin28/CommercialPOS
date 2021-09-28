using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.PointOfService;

namespace POS.Billing
{
    public partial class frmPosPayment : Form
    {
        connString cs = new connString();
        Product_Menu.frmPos fp = null;      

        public frmPosPayment(Product_Menu.frmPos _fp)
        {
            InitializeComponent();
            fp = _fp;
          
        }

        private void txtCash_Leave(object sender, EventArgs e)
        {
                        
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            txtCash.Focus();
        }

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            double dueAmt = 0;
            double cashamt = 0;
            double chnge = 0;
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCash.Text == "")
                {
                    txtCash.Text = txtDueAmt.Text;
                }
                else
                {    
                    try
                    {                                                       
                        dueAmt = Convert.ToDouble(txtDueAmt.Text.ToString());
                        cashamt = Convert.ToDouble(txtCash.Text.ToString());                
                        chnge  = cashamt - dueAmt;
                        txtCash.Text = cashamt.ToString("n2");
                        txtChange.Text = chnge.ToString("n2");
                      
                        if (chnge < 0)
                        {
                            MessageBox.Show("Insufficient cash!", "Cash validaton", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtChange.Text = "";
                            return;
                        }
                        else
                        {                     
                            btnSave.Focus();
                        }
                    }
                    catch (Exception msg)
                    {
                        MessageBox.Show(msg.Message,"Input validation",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        return;
                    }

                }

            }
            else
            {
                //no action
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (txtCash.Text == "")
                {
                    this.Dispose();
                    fp.txtItemCode.Text = "";
                }
                else
                {
                    txtCash.Text = "";
                }
            }
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            txtChange.Text = "";
        }

        private void txtChange_Enter(object sender, EventArgs e)
        {
            txtCash.Focus();
        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtCash.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            DialogResult res;
            res = MessageBox.Show("Are you sure you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                 
                fp.saveDailySales(Convert.ToDouble(txtCash.Text),Convert.ToDouble(txtChange.Text));              
                fp.customerName = "";
                fp.lbNote.Items.Clear();              
                this.Dispose();
            }
            else
            {
                txtCash.Focus();
                return;
            }
        }
        

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar)&&(Keys)e.KeyChar!= Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void frmPosPayment_Load(object sender, EventArgs e)
        {
           
        }

        private void frmPosPayment_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
      

        private void frmPosPayment_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
