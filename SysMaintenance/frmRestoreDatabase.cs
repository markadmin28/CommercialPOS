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
    public partial class frmRestoreDatabase : Form
    {
        connString cs = new connString();
        public frmRestoreDatabase()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER Database backup files|*.bak";
            dlg.Title = "Database restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtDb.Text = dlg.FileName;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            frmDatabaseBackup fdb = new frmDatabaseBackup();
            fdb.action = "restore";
            fdb.conStringText = txtDb.Text;
            fdb.ShowDialog();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmRestoreDatabase_Load(object sender, EventArgs e)
        {

        }

        private void frmRestoreDatabase_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
