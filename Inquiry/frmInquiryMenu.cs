using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Inquiry
{
    public partial class frmInquiryMenu : Form
    {
        public frmInquiryMenu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmTransList ft = new frmTransList();
            ft.ShowDialog();
        }

        private void frmInquiryMenu_Load(object sender, EventArgs e)
        {
            loadAccessForm();
        }
        private void loadAccessForm()
        {
            if (s_transactionList.transactionList == 1)
            {
                 btnTransactionList.Enabled = true;
            }
            else
            {
                btnTransactionList.Enabled = false;
            }
            if (s_transactionSummaryReport.transactionSummaryReport == 1)
            {
                btnTransSumRep.Enabled = true;
            }
            else
            {
                btnTransSumRep.Enabled = false;
            }
        }

        private void frmInquiryMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTransactionSummary fts = new frmTransactionSummary();
            fts.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmClerkReport fc = new frmClerkReport();
            fc.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmProdTrans frm = new frmProdTrans();
            frm.ShowDialog();
        }
    }
}
