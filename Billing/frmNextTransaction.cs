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
    public partial class frmNextTransaction : Form
    {
        Product_Menu.frmPos fp = null;
        public frmNextTransaction(Product_Menu.frmPos _fp)
        {
            InitializeComponent();
            fp = _fp;
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
             
           
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            this.Dispose();
        }

        private void frmNextTransaction_FormClosed(object sender, FormClosedEventArgs e)
        {
            fp.clearPosData();
            fp.txtDisc.Text = "0";
            fp.discountID = 0;
            fp.cusDiscID = "";
            fp.lbNote.Items.Clear();
            fp.customerName = "";
           
            this.Dispose();
        }
    }
}
