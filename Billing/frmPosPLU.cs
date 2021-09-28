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
    public partial class frmPosPLU : Form
    {
        connString cs = new connString();
        Product_Menu.frmPos fp = null;
        public frmPosPLU(Product_Menu.frmPos _fp)
        {
            InitializeComponent();
            fp = _fp;
          
        }
      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmPosPLU_Load(object sender, EventArgs e)
        {
             
        }

        private void frmPosPLU_Enter(object sender, EventArgs e)
        {
         
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            txtItemCode.Focus();
        }

        private void frmPosPLU_FormClosed(object sender, FormClosedEventArgs e)
        {
            fp.cursorTimer.Start();
            this.Dispose();                    
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {

        }
       

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtItemCode.Text == "")
                {
                    frmPosPLUSearch fp = new frmPosPLUSearch(this);
                    fp.ShowDialog();
                }
                else
                {
                    showProductInfo(txtItemCode.Text.Trim());
                }
                
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void txtItemCode_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void showProductInfo(string prodID)
        {

            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("getProdMasterData @prodID = '" + prodID + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                txtItemName.Text = cs.dbSearchData.Rows[0][1].ToString();
                txtItemPrice.Text = cs.dbSearchData.Rows[0][3].ToString();
                txtUnit.Text = cs.dbSearchData.Rows[0][6].ToString();
                txtCat.Text = cs.dbSearchData.Rows[0][5].ToString();
                txtOnhand.Text = cs.dbSearchData.Rows[0][9].ToString();
            }
            else
            {
                txtItemName.Text = "";
                txtItemPrice.Text = "";
                txtUnit.Text = "";
                txtCat.Text = "";
                txtOnhand.Text = "";
                txtItemCode.SelectAll();
                MessageBox.Show("Item not found!", "Database message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            txtItemCode.SelectAll();
        }

        private void txtItemCode_Leave(object sender, EventArgs e)
        {
            txtItemCode.Focus();
        }
    }
}
