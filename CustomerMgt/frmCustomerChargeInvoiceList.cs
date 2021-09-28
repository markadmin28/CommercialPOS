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
    public partial class frmCustomerChargeInvoiceList : Form
    {
        connString cs = new connString();
        public int ciViewType = 0; //1 = Billing | 2 = Charge Invoice Management | 3 = Temporaty Charge Invoice

        public frmCustomerChargeInvoiceList()
        {
            InitializeComponent();
        }

        private void frmCustomerChargeInvoiceList_Load(object sender, EventArgs e)
        {
            LoadCustomerChargeInvoiceInfo();
        }
        private void LoadCustomerChargeInvoiceInfo()
        {
            DataTable dt = new DataTable();
            string keyword = txtKeyword.Text;
            int rowNum = 0;

            cs.connDB();
            dt = cs.DISPLAY("sp_CustomerChargeInvoiceDisplayList @cusName = '" + keyword + "'");
            cs.disconMy();
            if (dt.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i =0;i <= dt.Rows.Count -1; i++)
                {
                    dgw.Rows.Add((rowNum), dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], dt.Rows[i][5], dt.Rows[i][6], dt.Rows[i][7]);
                    rowNum += 1;
                    dgw.Rows[i].Cells[0].Value = rowNum;
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

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            LoadCustomerChargeInvoiceInfo();
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (txtKeyword.Text == "")
                {
                    this.Dispose();
                }
                else
                {
                    txtKeyword.Text = "";
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (dgw.Rows.Count > 0)
                {
                    dgw.Focus();
                    dgw.CurrentRow.Selected = true;
                }
                else
                {
                    //no action
                }
            }
        }

        private void dgw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (dgw.Rows.Count > 0)
                {
                    dgw.CurrentRow.Selected = false;
                    txtKeyword.Focus();
                }
                else
                {
                    //no action
                }
            }
            if (e.KeyCode== Keys.Enter)
            {        
                if (ciViewType == 1) // billing
                {
                    Billing.frmChrgeInvoice fc = (Billing.frmChrgeInvoice)Owner;
                    if (dgw.Rows.Count > 0)
                    {
                        e.SuppressKeyPress = true;                        
                        fc.txtChargeTo.Text = dgw.CurrentRow.Cells[2].Value.ToString();
                        fc.txtTin.Text = dgw.CurrentRow.Cells[3].Value.ToString();
                        fc.txtTerms.Text = dgw.CurrentRow.Cells[4].Value.ToString();
                        fc.txtAddress.Text = dgw.CurrentRow.Cells[5].Value.ToString();
                        fc.txtOsca.Text = dgw.CurrentRow.Cells[6] .Value.ToString();
                        fc.txtSc.Text = dgw.CurrentRow.Cells[7].Value.ToString();
                        fc.txtBusiness.Text = dgw.CurrentRow.Cells[8].Value.ToString();
                        this.Dispose();

                    }
                    else
                    {
                        //no action
                    }
                }   
                else if (ciViewType == 2) // Charge invoice management
                {
                    frmCustomerChargeInvoice fc = (frmCustomerChargeInvoice)Owner;
                    if (dgw.Rows.Count > 0)
                    {
                        e.SuppressKeyPress = true;
                        fc.ciid = Convert.ToDecimal(dgw.CurrentRow.Cells[1].Value.ToString());
                        fc.txtChargeTo.Text = dgw.CurrentRow.Cells[2].Value.ToString();
                        fc.txtTin.Text = dgw.CurrentRow.Cells[3].Value.ToString();
                        fc.txtTerms.Text = dgw.CurrentRow.Cells[4].Value.ToString();
                        fc.txtAddress.Text = dgw.CurrentRow.Cells[5].Value.ToString();
                        fc.txtOsca.Text = dgw.CurrentRow.Cells[6].Value.ToString();
                        fc.txtSc.Text = dgw.CurrentRow.Cells[7].Value.ToString();
                        fc.txtBusiness.Text = dgw.CurrentRow.Cells[8].Value.ToString();
                        this.Dispose();

                    }
                    else
                    {
                        //no action
                    }
                }
                else if (ciViewType == 3) // Temp charge Invoice
                {
                    frmTempChargeInvoice fc = (frmTempChargeInvoice)Owner;
                    if (dgw.Rows.Count > 0)
                    {
                        e.SuppressKeyPress = true;                      
                        fc.txtChargeTo.Text = dgw.CurrentRow.Cells[2].Value.ToString();
                        fc.txtTin.Text = dgw.CurrentRow.Cells[3].Value.ToString();
                        fc.txtTerms.Text = dgw.CurrentRow.Cells[4].Value.ToString();
                        fc.txtAddress.Text = dgw.CurrentRow.Cells[5].Value.ToString();
                        fc.txtOsca.Text = dgw.CurrentRow.Cells[6].Value.ToString();
                        fc.txtSc.Text = dgw.CurrentRow.Cells[7].Value.ToString();
                        fc.txtBusiness.Text = dgw.CurrentRow.Cells[8].Value.ToString();
                        this.Dispose();

                    }
                    else
                    {
                        //no action
                    }
                }

            }
        }

        private void dgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgw.Rows.Count > 0)
                {
                    SendKeys.Send("{Enter}");
                }
                else
                {
                    //no action
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Select data properly!", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
               
            }
           
        }
    }
}
