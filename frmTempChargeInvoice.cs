using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class frmTempChargeInvoice : Form
    {
        connString cs = new connString();
        decimal cit = 0;

        public frmTempChargeInvoice()
        {
            InitializeComponent();
        }

        private void frmTempChargeInvoice_Load(object sender, EventArgs e)
        {
            txtDisc.Text = "0";
        }
        private void calcTotal()
        {
            decimal qty = 0;
            decimal price = 0;
            decimal discount = 0;
            decimal disc = 5;
            decimal discAmt = 0;
            decimal total = 0;
            decimal ttl = 0;
            decimal gTotal = 0;
           

            try
            {
                 
                for (int i = 0; i <= dgw.Rows.Count - 1; i++)
                {
                    if (txtDisc.Text == "")
                    {
                        disc = 0;
                    }
                    else
                    {
                        disc = Convert.ToDecimal(txtDisc.Text);
                    }
                   

                    qty = Convert.ToDecimal(dgw.Rows[i].Cells[0].Value);
                    price = Convert.ToDecimal(dgw.Rows[i].Cells[3].Value);
                    discount = Convert.ToDecimal(dgw.Rows[i].Cells[4].Value);
                    

                    total = ((price - discount) * qty);
                    dgw.Rows[i].Cells[5].Value = total;
                    ttl += total;
                    discAmt = ttl *(disc / 100);
                    gTotal = ttl -(ttl * (disc / 100));
                   
                    
                    
                }
                txtTotal.Text = ttl.ToString("n2");
                txtGtotal.Text = gTotal.ToString("n2");
                txtDiscAmt.Text = discAmt.ToString("n2");

            }
            catch (Exception)
            {
                MessageBox.Show("Check entry!", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);               
                return;               
            }
          

        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgw_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            calcTotal();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            dgw.Focus();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDisc_TextChanged(object sender, EventArgs e)
        {
            if (txtDisc.Text == "")
            {
                MessageBox.Show("Enter Discount", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtDisc.Focus();
                return;
            }
            else
            {
                calcTotal();
            }
        }

        private void txtDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar)&&(Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Dispose();
            }
            else
            {
                return;
            }
        }

        private void frmTempChargeInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to clear all fields?", "Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                ClearFields();
            }
            else
            {
                return;
            }
        }
        private void ClearFields()
        {
            dgw.Rows.Clear();
            txtChargeTo.Text = "";
            txtTin.Text = "";
            txtTerms.Text = "";
            txtAddress.Text = "";
            txtOsca.Text = "";
            txtSc.Text = "";
            txtBusiness.Text = "";
            txtDisc.Text = "0";
            txtTotal.Text = "0.00";
            txtDiscAmt.Text = "0.00";
            txtGtotal.Text = "0.00";
            cit = 0;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            txtTin.Focus();
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            txtAddress.Focus();
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            txtOsca.Focus();
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            txtBusiness.Focus();
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            txtTerms.Focus();
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            txtSc.Focus();
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            txtDiscAmt.Focus();
        }
        private void ChargeInvoiceDetails()
        {
            //try
            //{

                string chargeDetails = "";
                decimal qty = 0;
                string unt = "";
                string prod = "";
                decimal discPerItem = 0;
                decimal ttl = 0;
                decimal price = 0;

                for (int i =0; i <= dgw.Rows.Count -2; i++)
                {
                 
                        qty = Convert.ToDecimal(dgw.Rows[i].Cells[0].Value);                  
                if (dgw.Rows[i].Cells[1].Value == null)
                {
                    unt = "-";
                }
                else
                {
                    unt = dgw.Rows[i].Cells[1].Value.ToString();
                }
                if ( dgw.Rows[i].Cells[2].Value == null)
                {
                    prod = "-";
                }
                else
                {
                    prod = dgw.Rows[i].Cells[2].Value.ToString();
                }
                                 
                                                       
                        discPerItem = Convert.ToDecimal(dgw.Rows[i].Cells[4].Value);                                          
                        ttl = Convert.ToDecimal(dgw.Rows[i].Cells[5].Value);                                                            
                    price = Convert.ToDecimal(dgw.Rows[i].Cells[3].Value);
                    cs.connDB();
                    chargeDetails = "sp_TempChargeInvoiceDetails @cit = '" + cit + "',@qty = '" + qty + "',@unit = '" + unt + "',@product = '" + prod + "',@discPerItem = '" + discPerItem + "',@total = '" + ttl + "' , @price = '" + price + "'";
                    cs.IUD(chargeDetails);
                    cs.disconMy();
                }
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Check you order entry!", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            //    return;
            //}
}
        private void ChargeInvoiceInfo()
        {
            string cii = "";
            string ct = txtChargeTo.Text;
            string tin = txtTin.Text;
            string terms = txtTerms.Text;
            string add = txtAddress.Text;
            string osca = txtOsca.Text;
            string sc = txtSc.Text;
            string bs = txtBusiness.Text;
            decimal disc = Convert.ToDecimal(txtDiscAmt.Text);
            decimal ab = addedByUser.addedBy;
            DateTime da = DateTime.Now;
            decimal discPercent = Convert.ToDecimal(txtDisc.Text);
            decimal gTotal = Convert.ToDecimal(txtGtotal.Text);

            cs.connDB();
            cii = "sp_TempChargeInvoiceInfo @CIT = '" + cit + "',@CT = '" + ct + "' ,@tin = '" + tin + "',@terms = '" + terms + "',@address = '" + add + "',@osca = '" + osca + "',@sc = '" + sc + "',@bs = '" + bs + "' ,@disc = '" + disc + "',@addedBy = '" + ab + "',@dateAdded = '" + da + "',@discPercent = '" + discPercent + "' , @gTotal = '" + gTotal + "'";
            cs.IUD(cii);
            cs.disconMy();
        }
        private void ChargeInvoiceGenId()
        {
            DataTable dt = new DataTable();
            cs.connDB();
            dt = cs.DISPLAY("sp_TempChargeInvoiceGenId");
            cs.disconMy();
            cit = Convert.ToDecimal(dt.Rows[0][0]);
        }
        private void SaveCommand()
        {
            if (dgw.Rows.Count > 1)
            {
                DialogResult res = MessageBox.Show("Do you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        ChargeInvoiceGenId();
                    ChargeInvoiceDetails();
                    ChargeInvoiceInfo();

                    frmRptTempChargeInvoice ftc = new frmRptTempChargeInvoice();
                    if (s_chargeInvoicePrinting.chargeInvoice == 1)
                    {                        
                        ftc.Owner = this;
                        ftc.CIT = cit;
                        ftc.ShowDialog();
                    }
                    else if (s_chargeInvoicePrinting.chargeInvoice == 2)
                    {                        
                        ftc.Owner = this;
                        ftc.CIT = cit;
                        ftc.LoadTempChargeInvoideDetails();
                        ftc.LoadTempChargeInvoiceInfo();
                        ftc.autoPrint_chargeInvoiceReceipt();
                    }
                    else if (s_chargeInvoicePrinting.chargeInvoice == 3)
                    {
                        //.....................
                    }
                  
                    ClearFields();
                }
                    catch (Exception)
                {
                    MessageBox.Show("Check your entry!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Enter order!", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            

           
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             
            SaveCommand();
        }

        private void txtChargeTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ( txtChargeTo.Text == "")
                {
                    CustomerMgt.frmCustomerChargeInvoiceList fcc = new CustomerMgt.frmCustomerChargeInvoiceList();
                    fcc.Owner = this;
                    fcc.ciViewType = 3;
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
                dgw.Focus();
            }
        }

        private void dgw_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            calcTotal();
        }

        private void dgw_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calcTotal();
        }

        private void dgw_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
                                              
        }
    }
}
