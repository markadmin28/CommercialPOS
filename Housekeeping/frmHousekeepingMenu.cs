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
    public partial class frmHousekeepingMenu : Form
    {
        public frmHousekeepingMenu()
        {
            InitializeComponent();
        }

        private void btnCashFund_Click(object sender, EventArgs e)
        {
            frmChangeFundList fcf = new frmChangeFundList();
            fcf.ShowDialog();
        }

        private void frmHousekeepingMenu_Load(object sender, EventArgs e)
        {
            LoadAccessForm();
        }
        private void LoadAccessForm()
        {
            if(s_dailyChangeFund.dailyChangeFund ==1)
            {
                btnChangeFund.Enabled = true;
            }
            else
            {
                btnChangeFund.Enabled = false;
            }
        }
    }
}
