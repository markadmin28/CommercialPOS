using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.POSMaintenance
{
    public partial class frmInitializeDecision : Form
    {
        public frmInitializeDecision()
        {
            InitializeComponent();
        }

        private void frmInitializeDecision_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            string initType = "";
            if (rbtnIn.Checked == true)
            {
                initType = "InventoryIn";
            }
            else if (rbtnOut.Checked == true)
            {
                initType = "InventoryOut";
            }
            else if (rbtnInOut.Checked == true)
            {
                initType = "InventoryInOut";
            }
            else if (rbtnSales.Checked == true)
            {
                initType = "Sales";
            }
            else if (rbtnSalesInventory.Checked == true)
            {
                initType = "SalesInventory";
            }
            DialogResult res = MessageBox.Show("Backup your database first to secure data and \n avoid data loss, do you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                DialogResult reslt = new DialogResult();
                reslt = MessageBox.Show("Are you sure you want to initialize this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (reslt == DialogResult.Yes)
                {
                    frmSalesInitializationLoader fsi = new frmSalesInitializationLoader();
                    fsi.initializeType = initType;
                    fsi.ShowDialog();
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }
}
