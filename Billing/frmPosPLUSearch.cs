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
    public partial class frmPosPLUSearch : Form
    {
        connString cs = new connString();
        string prodID = "";
        frmPosPLU fp = null;


        public frmPosPLUSearch(frmPosPLU _fp)
        {
            InitializeComponent();
            fp = _fp;
        }

        private void txtItems_TextChanged(object sender, EventArgs e)
        {
            prodID = "";
            loadProdMasterData();
        }
        #region Logic
        private void loadProdMasterData()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("getProdMasterByDesc @prodDesc = '" + txtItems.Text + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int x = 0; x <= cs.dbSearchData.Rows.Count - 1; x++)
                {
                    dgw.Rows.Add((cs.dbSearchData.Rows[x][0]), cs.dbSearchData.Rows[x][1], cs.dbSearchData.Rows[x][2], cs.dbSearchData.Rows[x][3]);
                    if (Convert.ToDateTime(dgw.Rows[x].Cells[3].Value) <= DateTime.Now && Convert.ToDateTime(dgw.Rows[x].Cells[3].Value) != Convert.ToDateTime("1/1/1990"))
                    {
                        dgw.Rows[x].DefaultCellStyle.ForeColor = Color.Maroon;
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
        #endregion

        private void txtItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (dgw.Rows.Count > 0)
                {
                    dgw.Focus();
                    dgw.Rows[0].Selected = true;
                }
                else
                {
                    txtItems.Focus();
                    txtItems.SelectAll();
                    return;
                }

            }
            if (e.KeyCode == Keys.Escape)
            {
                if (txtItems.Text != "")
                {
                    txtItems.Text = null;
                }
                else
                {
                    this.Dispose();
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (prodID != "")
                {
                    fp.txtItemCode.Text = prodID;
                    this.Dispose();
                }
                else
                {
                    loadProdMasterData();
                }

            }
        }

        private void dgw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtItems.Focus();
                dgw.CurrentRow.Selected = false;
            }
            if (e.KeyCode == Keys.Enter)
            {

                prodID = dgw.CurrentRow.Cells[0].Value.ToString();
                txtItems.Focus();

                txtItems.SelectAll();
                e.SuppressKeyPress = true;
                if (dgw.Rows.Count > 0)
                {
                    dgw.CurrentRow.Selected = false;
                }
                else
                {

                }

            }
        }

        private void frmPosPLUSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
