using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Housekeeping
{
    public partial class frmChangeFundAmount : Form
    {
        connString cs = new connString();
        frmChangeFundList fcf = null;
        public decimal cashInOutID = 0;    
        public frmChangeFundAmount(frmChangeFundList _fcf)
        {
            InitializeComponent();
            fcf = _fcf;
          
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtChangeAmt.Text = "";
            txtChangeAmt.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ChangeFundCommand();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmChangeFundAmount_Load(object sender, EventArgs e)
        {

        }

        private void txtChangeAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
            if (e.KeyCode == Keys.Enter)
            {               
                btnSave.Focus();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
        private void ChangeFundCommand()
        {
            cs.connDB();
            cs.updateData = "update tbl_CashInOut set amount = '" + txtChangeAmt.Text + "', updatedBy = '" + addedByUser.addedBy + "', dateUpdated = '" + DateTime.Now + "' where cashInOutID = '" + cashInOutID + "'";
            cs.IUD(cs.updateData);
            cs.disconMy();
            fcf.ChangeFundList();
            this.Dispose();
        }

        private void txtChangeAmt_Leave(object sender, EventArgs e)
        {
            if (txtChangeAmt.Text == "")
            {
                txtChangeAmt.Text = "0";
            }
            else
            {
                //no action
            }
        }
    }
}
