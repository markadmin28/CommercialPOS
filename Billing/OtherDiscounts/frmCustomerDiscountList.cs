using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Billing.OtherDiscounts
{
    public partial class frmCustomerDiscountList : Form
    {
        connString cs = new connString();

        public frmCustomerDiscountList()
        {
            InitializeComponent();
        }
        private void LoadCustomerDiscountLists()
        {           
            DataTable loadCustomerDiscountLists = new DataTable();
            DataTable dt = loadCustomerDiscountLists;
            string dd = "";
            int rowNum = 0;
            frmDiscountList fcl = (frmDiscountList)Owner;
            dd = fcl.cmbDisc.Text;
             
            cs.connDB();
            dt = cs.DISPLAY("sp_CustomerDiscountListDisplay @discountDesc = '" + dd + "' , @cusName = '" + txtKeyword.Text + "'");
            cs.disconMy();
            if (dt.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i =0; i <= dt.Rows.Count -1; i++)
                {
                    dgw.Rows.Add((rowNum), dt.Rows[i][0], dt.Rows[i][1]);
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
            LoadCustomerDiscountLists();
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
            frmDiscountList fcl = (frmDiscountList)Owner;
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
            if (e.KeyCode == Keys.Enter)
            {               
                e.SuppressKeyPress = true;
                fcl.txtDiscID.Text = dgw.CurrentRow.Cells[1].Value.ToString();
                this.Dispose();
            }
        }

        private void frmCustomerDiscountList_Load(object sender, EventArgs e)
        {
            LoadCustomerDiscountLists();
        }
    }
}
