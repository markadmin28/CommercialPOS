using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace POS.Billing
{
    public partial class frmWaitingform : Form
    {
         Product_Menu.frmPos fp = null;
        public frmWaitingform(Product_Menu.frmPos _fp)
        {
            InitializeComponent();
             fp = _fp;
        }

        private void frmWaitingform_Load(object sender, EventArgs e)
        {
            pictureBox1.Left = ((this.Width / 2) - (pictureBox1.Width /2)  );
            lblTag.Left = ((this.Width / 2) - (lblTag.Width / 2));          
            lblCompName.Text = posCompName.compName;         
            lblCompAddress.Text = posAddress.address;            
            lblCashier.Text = "Cashier: " +posUserName.userName;
            backgroundWorker1.RunWorkerAsync(0);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker helperBW = sender as BackgroundWorker;
            int arg = (int)e.Argument;
            e.Result = LogicMethod(helperBW, arg);
            if (helperBW.CancellationPending)
            {
                e.Cancel = true;
            }
        }
        private int LogicMethod(BackgroundWorker bw, int a)
        {
            int result = 0;
            Thread.Sleep(0);           
                fp.PrintReceiptCommand("Header");           
            fp.PrintReceiptCommand("Body");   // this receipt is hard coded with OPOS for .net
            fp.isReceiptHeaderPrinted = 0;
            return result;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Dispose();
        }

        private void frmWaitingform_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                e.Handled = false;
            }
        }
    }
}
