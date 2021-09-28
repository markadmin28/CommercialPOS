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
    public partial class frmPosMaintenanceValidation : Form
    {
        public frmPosMaintenanceValidation()
        {
            InitializeComponent();
        }

        private void txtUn_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void txtUn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtP.Focus();
            }
        }

        private void txtP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUn.Text == "mark" && txtP.Text == ".markadmin_28")
                {
                    txtUn.Focus();
                    txtUn.Text = "";
                    txtP.Text = "";
                    POSMaintenance.frmPosMaintenanceMenu fmm = new frmPosMaintenanceMenu();
                    fmm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Contact the developer", "Account Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            txtUn.Focus();
        }
    }
}
