using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS.SysMaintenance
{
    public partial class frmDatabaseBackup : Form
    {
        connString cs = new connString();        
        string loc = "E:\\POSDB\\backup\\POSDB ";
        public string action = "";
        public string conStringText = "";

        public frmDatabaseBackup()
        {
            InitializeComponent();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;
            for (int j =0; j < 100000; j++ )
            {
                Calculate(j);
                backgroundWorker.ReportProgress((j * 100) / 100000);             
            }
            

        }
        private void Calculate (int i)
        {
            double pow = Math.Pow(i, i);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
           
        }

        private void frmDatabaseBackup_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            if (action == "backup")
            {
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("declare @var varchar(max) = '" + loc + "' + replace(rtrim(convert(char,getdate())), ':',',')+'.bak'; BACKUP DATABASE posDB TO DISK = @var");
                cs.disconMy();
                MessageBox.Show("Database backup successfully saved!", "Database message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else if (action == "restore")
            {
                restoreDBCommand();
            }

        }
        private void restoreDBCommand()
        {
            cs.connDB();
            string database = cs.cn.Database.ToString();
            if (cs.cn.State != ConnectionState.Open)
            {
                cs.cn.Open();
            }
            try
            {
                string sqlStmt2 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand bu2 = new SqlCommand(sqlStmt2, cs.cn);
                bu2.ExecuteNonQuery();

                string sqlStmt3 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + conStringText + "'WITH REPLACE;";
                SqlCommand bu3 = new SqlCommand(sqlStmt3, cs.cn);
                bu3.ExecuteNonQuery();

                string sqlStmt4 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                SqlCommand bu4 = new SqlCommand(sqlStmt4, cs.cn);
                bu4.ExecuteNonQuery();

                MessageBox.Show("Database retored successfully!", "Database message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cs.cn.Close();
                cs.disconMy();
                this.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
