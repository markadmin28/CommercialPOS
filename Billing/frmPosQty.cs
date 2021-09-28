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
    public partial class frmPosQty : Form
    {
        connString cs = new connString();
        Product_Menu.frmPos fp = null;
        public int isDiscount = 0;
        decimal DiscAmt = 0;
        int isSuspended = 0;
        string actionType = "";

        decimal prodQtyStat = 0;
        public int prodRecNo =0;

        public frmPosQty(Product_Menu.frmPos _fp)
        {
            InitializeComponent();
            fp = _fp;
        }

        private void frmPosQty_Load(object sender, EventArgs e)
        {
             
            //isDiscount :1 = discount with amount || isDiscount :2 = discount with percent
            if (isDiscount ==1)
            {
                changeProperty();
                this.Text = "Discount Per Unit";
            }
            else if (isDiscount ==2)
            {
                changeProperty();
                this.Text = "Discount Per Unit in %";
                this.label4.Text = "Discount &%";
                this.txtDiscount.Text = "";                               
            }
            else
            {
                //no action
            }

            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("getProdMasterData @prodID = '" + txtItemCode.Text + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                prodQtyStat = Convert.ToDecimal(cs.dbSearchData.Rows[0][9]);
            }

        }
        private void changeProperty()
        {
            txtDiscount.ReadOnly = false;
            txtQuantity.ReadOnly = true;
            txtQuantity.Font = new Font("segoe ui", 10, FontStyle.Bold);
            txtQuantity.ForeColor = Color.Black;
            txtDiscount.ForeColor = Color.Blue;
            txtDiscount.Font = new Font("segoe ui", 12, FontStyle.Bold);
            txtDiscount.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            txtQuantity.BackColor = System.Drawing.Color.White;
            txtDiscount.TabIndex = 0;               
            txtQuantity.TabIndex = 1;
        }
        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
            if (e.KeyCode == Keys.Enter)
            {         
                if (txtQuantity.Text == "" || txtQuantity.Text == "0")
                {
                    MessageBox.Show("Enter Quantity!", "Quantity validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    if (s_prodQuantityStatus.prodQuantityStat == 1)
                    {
                        if (prodQtyStat < Convert.ToDecimal(txtQuantity.Text))
                        {
                            MessageBox.Show("Your desired quantity is more than what we have!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }                                                       
                    actionType = "Quantity";
                    changeDiscQtyCommand(actionType, txtItemCode.Text.Trim(), Convert.ToDecimal(txtQuantity.Text), DiscAmt,  prodRecNo);
                }
              
            }
        }
        
        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            txtQuantity.Focus();
            txtQuantity.SelectAll();
        }

        private void txtItemPrice_TextChanged(object sender, EventArgs e)
        {
            decimal s = Convert.ToDecimal(txtItemPrice.Text);
            txtItemPrice.Text = s.ToString("n2");
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar)&&(Keys)e.KeyChar!= Keys.Back && e.KeyChar != '.')
              
                {
                e.Handled = true;
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!char.IsNumber(e.KeyChar)&&(Keys)e.KeyChar!=Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
            if (e.KeyCode == Keys.Enter)
            {
                string txtRecNo = "";
                if (txtDiscount.Text == "")
                {
                    txtDiscount.Text = "0";
                }
                else
                {
                    //no action
                }
               //changes trigger to recno
                if (isDiscount ==1)
                {
                    actionType = "Discount";                    
                    changeDiscQtyCommand(actionType, txtItemCode.Text.Trim(), 1, Convert.ToDecimal(txtDiscount.Text.Trim()), prodRecNo);
                }
                else if (isDiscount ==2)
                {
                    DiscAmt = (Convert.ToDecimal(txtItemPrice.Text.Trim()) * (Convert.ToDecimal(txtDiscount.Text.Trim()) / 100));                    
                    actionType = "Discount";
                  
                    changeDiscQtyCommand(actionType, txtItemCode.Text.Trim(), 1, DiscAmt , prodRecNo);
                }
                 
            }
        }        

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            txtDiscount.SelectAll();
            txtDiscount.Focus();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

        }
        private void changeDiscQtyCommand(string accType,string prodID, decimal qty, decimal discnt , int pRecno )
        {           
            cs.connDB();
            cs.updateData = "changeQtyDiscount @actionType = '" + accType + "', @discount = '" + discnt + "',@quantity = '" + qty + "', @prodID = '" + prodID + "', @machineName = '" + cs.machineName + "',@isSuspended = '" + isSuspended + "' , @recNo = '" + pRecno + "' ";
            cs.IUD(cs.updateData);
            cs.disconMy();
            fp.showTempBillingItemsList();
            fp.displayLastItemInfo(prodID); //display last item
            fp.cursorTimer.Start();
            this.Dispose();
        }

        private void frmPosQty_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void label5_Click(object sender, EventArgs e)
        {
                        
        }
    }
}
