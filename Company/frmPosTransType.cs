using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Company
{
    public partial class frmPosTransType : Form
    {
        connString cs = new connString();
        decimal transTypeID = 0;
        string actn = "";

        public frmPosTransType()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmPosTransType_Load(object sender, EventArgs e)
        {
            transactionTypeDisplay();
        }
        private void transactionTypeCommand(string action)
        {
           
                cs.connDB();
                cs.insertData = "sp_transactionType @action = '" + action + "',@transactionType = '" + txtTransTypeDesc.Text + "', @transTypeID = '" + transTypeID + "'";
                cs.IUD(cs.insertData);
                cs.disconMy();
                transactionTypeDisplay();             
            clearFields();
        }
        private void transactionTypeValidate()
        {
            if (transTypeID == 0)
            {
                    actn = "Insert";
                    genTransTypeID();
                    cs.connDB();
                    cs.dbSearchData = cs.DISPLAY("select transactionType from tbl_transactionType where transactionType = '" + txtTransTypeDesc.Text + "'");
                    cs.disconMy();
                    if (cs.dbSearchData.Rows.Count > 0)
                    {
                        MessageBox.Show("Transaction type already existed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clearFields();
                    }
                    else
                    {
                        transactionTypeCommand(actn);
                    }
                }
            else
            {
                actn = "Update";
                transactionTypeCommand(actn);
            }
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            transactionTypeValidate();
        }
        private void transactionTypeDisplay()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("sp_transactionType_display @transactionType = '" + txtTransTypeDesc.Text + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i =0; i <= cs.dbSearchData.Rows.Count -1; i++)
                {
                    dgw.Rows.Add((cs.dbSearchData.Rows[i][0]), cs.dbSearchData.Rows[i][2], cs.dbSearchData.Rows[i][1]);
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
            txtRowNo.Text = dgw.Rows.Count.ToString();
        }
        private void genTransTypeID()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(max(transactionTypeID),1000) + 1 from tbl_transactionType");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                transTypeID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
            }
            else
            {
                transTypeID = 0;
            }
        }
        private void clearFields()
        {
            transTypeID = 0;
            txtTransTypeDesc.Text = "";
            txtTransTypeDesc.Focus();
        }

        private void dgw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (dgw.Rows.Count > 0)
                {
                    dgw.CurrentRow.Selected = false;
                    txtTransTypeDesc.Focus();
                }
                else
                {
                    //no action
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void txtTransTypeDesc_TextChanged(object sender, EventArgs e)
        {
            transactionTypeDisplay();
           
        }

        private void txtTransTypeDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                clearFields();
            }
        }

        private void dgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTransTypeDesc.Text = dgw.CurrentRow.Cells[1].Value.ToString();
            transTypeID = Convert.ToDecimal(dgw.CurrentRow.Cells[2].Value.ToString());
            txtTransTypeDesc.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (transTypeID == 0)
            {
                MessageBox.Show("Select transaction type to remove", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                DialogResult res;
                res = MessageBox.Show("Are you sure you want to remove this transaction type?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes) 
                {
                    actn = "Delete";
                    transactionTypeCommand(actn);
                }
                else
                {
                    return;
                }

           
            }
           
        }
    }
}
