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
    public partial class frmSalesInitializationLoader : Form
    {
        connString cs = new connString();
        public string initializeType = "";
        public frmSalesInitializationLoader()
        {
            InitializeComponent();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;
            for (int j = 0; j < 100000; j++)
            {
                Calculate(j);
                backgroundWorker.ReportProgress((j * 100) / 100000);
            }
        }
        private void Calculate(int i)
        {
            double pow = Math.Pow(i, i);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            InitializeCommand(initializeType);
        }
        private void InitializeCommand(string initType)
        {
            cs.connDB();
            cs.insertData = "sp_initializeProdInventorySales @initializeType = '" + initType + "'";
            cs.IUD(cs.insertData);
            cs.disconMy();
            MessageBox.Show("Sales initialization success", "System message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private void frmSalesInitializationLoader_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            backgroundWorker.RunWorkerAsync();
        }
    }
}
