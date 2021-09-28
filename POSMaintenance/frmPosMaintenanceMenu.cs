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
    public partial class frmPosMaintenanceMenu : Form
    {
        connString cs = new connString();
        public frmPosMaintenanceMenu()
        {
            InitializeComponent();
        }
       

        private void btnInInv_Click(object sender, EventArgs e)
        {
            frmInitializeDecision fid = new frmInitializeDecision();
            fid.ShowDialog();
        }

        private void frmPosMaintenanceMenu_Load(object sender, EventArgs e)
        {
            LoadAccessForm();

        }
        private void LoadAccessForm()
        {
            if (s_initializeProduct_salesInfo.initializeProduct_salesInfo ==1)
            {
                btnInInv.Enabled = true;
            }
            else
            {
                btnInInv.Enabled = false;
            }
        }
    }
}
