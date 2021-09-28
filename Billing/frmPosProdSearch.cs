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
    public partial class frmPosProdSearch : Form
    {
        connString cs = new connString();
         Product_Menu.frmPos fp = null;
        string prodID = "";

        public frmPosProdSearch( Product_Menu.frmPos _fp)
        {
            InitializeComponent();
            fp = _fp;
        }

        private void txtUomDesc_TextChanged(object sender, EventArgs e)
        {
            prodID = "";
            loadProdMasterData();
        }


        #region Logic
        private void loadProdMasterData()
        {
            try
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
            lblRows.Text = dgw.RowCount.ToString();
            } catch 
            {                
                return;
            }
        }
        #endregion

        private void txtUomDesc_KeyDown(object sender, KeyEventArgs e)
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
                //if (prodID != "")
                //{
                //    fp.isProdIdFinal = true;
                //    fp.txtItemCode.Text = prodID;
                //    this.Dispose();
                //}
                //else
                //{
                    loadProdMasterData();
                   
                   
                //}
              
            }
        }

        private void dgw_Leave(object sender, EventArgs e)
        {
            
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
                if (dgw.Rows.Count > 0)
                {
                    e.SuppressKeyPress = true;
                    prodID = dgw.CurrentRow.Cells[0].Value.ToString();
                    fp.isProdIdFinal = true;
                    fp.txtItemCode.Text = prodID;
                    this.Dispose();
                }
                else
                {
                    //no action
                }
                 
            }
        }

        private void frmPosProdSearch_Load(object sender, EventArgs e)
        {

        }

        private void frmPosProdSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }

}
