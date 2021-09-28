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
    public partial class frmCustomerList : Form
    {
        connString cs = new connString();
        frmCustomerReg fcr = null;
        public frmCustomerList(frmCustomerReg _fcr)
        {
            InitializeComponent();
            fcr = _fcr;
        }

        private void dgw_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            txtRows.Text = dgw.RowCount.ToString();
        }

        private void dgw_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txtRows.Text = dgw.RowCount.ToString();
        }

        private void frmCustomerList_Load(object sender, EventArgs e)
        {
            loadCustomerMaster();
        }
        private void loadCustomerMaster()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("customer_master_displayByKeyword @keyword = '" + txtKeyword.Text + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i = 0; i <= cs.dbSearchData.Rows.Count - 1; i++)
                {
                    dgw.Rows.Add((cs.dbSearchData.Rows[i][0]), cs.dbSearchData.Rows[i][2], cs.dbSearchData.Rows[i][3], cs.dbSearchData.Rows[i][1], cs.dbSearchData.Rows[i][7]);

                    if (dgw.Rows[i].Cells[4].Value.ToString() == "0")
                    {
                        dgw.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    }
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
            loadCustomerMaster();
           
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (txtKeyword.ReadOnly == true)
                {
                    MessageBox.Show("Press [Esc] to load customer or" + "\n" +"Press [Enter] to continue", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    dgw.Focus();
                    dgw.Rows[0].Selected = true;
                }
               
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (txtKeyword.Text != "")
                {
                    txtKeyword.Text = "";
                }
                else
                {
                    this.Dispose();
                }
                txtCusID.Text = "_____";
                txtKeyword.ReadOnly = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (txtKeyword.ReadOnly == true)
                {
                    fcr.txtCusID.Text = txtCusID.Text;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Select customer", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
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
                    txtKeyword.SelectAll();
                }
                else
                {
                    //no action
                }

            }
            if (e.KeyCode == Keys.Enter)
            {
                if (dgw.Rows.Count > 0)
                {
                    txtCusID.Text = dgw.CurrentRow.Cells[3].Value.ToString();
                    txtKeyword.Text = dgw.CurrentRow.Cells[1].Value.ToString();
                    txtKeyword.ReadOnly = true;
                    txtKeyword.Focus();
                    
                    e.SuppressKeyPress = true;
                    


                }
                else
                {
                    //no action
                }
            }
        }
    }
}
