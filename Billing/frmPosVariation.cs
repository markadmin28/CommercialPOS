using System;
 
using System.Windows.Forms;

namespace POS.Billing
{
    public partial class frmPosVariation : Form
    {
        connString cs = new connString();
        public int pRecNo = 0;
        Product_Menu.frmPos fp = null;
        public frmPosVariation(Product_Menu.frmPos _fp)
        {
            InitializeComponent();
            fp = _fp;
        }

        private void frmPosVariation_Load(object sender, EventArgs e)
        {
           
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            txtQty.Focus();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar)&&(Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')

            {
                e.Handled = true;
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtDesc.Focus();
            }
        }

        private void txtDesc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
            if (e.KeyCode == Keys.Enter)
            {
                // update variation
                tempBillingVar();
                
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtItemDesc_TextChanged(object sender, EventArgs e)
        {

        }
        private void tempBillingVar()
        {

            string actn = "Insert";
            actn = (txtQty.Text == "" && txtDesc.Text == ""? "Delete":"Insert");
            txtQty.Text = (txtQty.Text == "" ? "0" : txtQty.Text);
            cs.connDB();
            cs.insertData = "tempBillingVariation @action = '" + actn + "',@pRecNo = '" + pRecNo + "',@varQty = '" + txtQty.Text + "',@varDesc = '" + txtDesc.Text + "'";
            cs.IUD(cs.insertData);
            cs.disconMy();
            fp.cursorTimer.Start();
            fp.showTempBillingItemsList();
            this.Dispose();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
