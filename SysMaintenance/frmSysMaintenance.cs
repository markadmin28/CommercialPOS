using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.SysMaintenance
{
    public partial class frmSysMaintenance : Form
    {       
        public frmSysMaintenance()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Are you sure you want to backup the database?", "Database confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                frmDatabaseBackup fdb = new frmDatabaseBackup();
                fdb.action = "backup";
                fdb.ShowDialog();
            }
            else
            {
                return;
            }                           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRestoreDatabase frd = new frmRestoreDatabase();
            frd.ShowDialog();
        }

        private void btnInventoryReport_Click(object sender, EventArgs e)
        {
            frmDbConfig fdb = new frmDbConfig();
            fdb.ShowDialog();
        }

        private void frmSysMaintenance_Load(object sender, EventArgs e)
        {
            loadAccessForm();
        }
        private void loadAccessForm()
        {
            if (s_dbConfig.dbConfig ==1)
            {
                btnDbConfig.Enabled = true;
            }
            else
            {
                btnDbConfig.Enabled = false;
            }
            if (s_restoreDb.restoreDb == 1)
            {
                btnRestoreDb.Enabled = true;
            }
            else
            {
                btnRestoreDb.Enabled = false;
            }
            if (s_backupDb.backupDb ==1)
            {
                btnBackupDb.Enabled = true;
            }
            else
            {
                btnBackupDb.Enabled = false;
            }
        }

        private void frmSysMaintenance_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
