using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Company
{
    public partial class frmCompanyMenu : Form
    {
        public frmCompanyMenu()
        {
            InitializeComponent();
        }

        private void btnCompInfo_Click(object sender, EventArgs e)
        {
            frmCompany fc = new frmCompany();
            fc.ShowDialog();
        }

        private void btnMaInfo_Click(object sender, EventArgs e)
        {
            frmPosReg fpr = new frmPosReg();
            fpr.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNRGT fn = new frmNRGT();
            fn.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmOrNo fo = new frmOrNo();
            fo.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmPrintingSetup fp = new frmPrintingSetup();
            fp.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAccessForm faf = new frmAccessForm();
            faf.ShowDialog();
        }

        private void frmCompanyMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmPosTransType fptt = new frmPosTransType();
            fptt.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmPosItemColor fpi = new frmPosItemColor();
            fpi.ShowDialog();   
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmPosSetup frm = new frmPosSetup();
            frm.ShowDialog();
        }
    }
}
