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
    public partial class frmCustomerMenu : Form
    {
        public frmCustomerMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDiscountList fdl = new frmDiscountList();
            fdl.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSetDiscount fsd = new frmSetDiscount();
            fsd.ShowDialog();
        }

        private void btnTransactionList_Click(object sender, EventArgs e)
        {
            frmCustomerReg fcr = new frmCustomerReg();
            fcr.ShowDialog();
        }

        private void frmCustomerMenu_Load(object sender, EventArgs e)
        {
            loadAccess();
        }
        private void loadAccess()
        {
          
            if (s_customerRegistration.customerRegistration == 1)
            {
                btnCusReg.Enabled = true;
            }
            else
            {
                btnCusReg.Enabled = false;
            }
            if (s_discountList.discountList == 1)
            {
                btnDiscList.Enabled = true;
            }
            else
            {
                btnDiscList.Enabled = false;
            }
            if (s_setDiscount.setDiscount == 1)
            {
                btnSetDisc.Enabled = true;
            }
            else
            {
                btnSetDisc.Enabled = false;
            }
        }

        private void frmCustomerMenu_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
       

        private void btnCusReg_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmCustomerChargeInvoice fcc = new frmCustomerChargeInvoice();
            fcc.ShowDialog();
        }
    }
}
