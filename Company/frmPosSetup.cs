using System;
 
using System.Data;
 
using System.Windows.Forms;

namespace POS.Company
{
    public partial class frmPosSetup : Form
    {
        connString cs = new connString();
       
        public frmPosSetup()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            posSetup(checkAllow);
        }
        
        private void posSetup(CheckBox ck)
        {
           
            int isAllow = 0;
            isAllow = (ck.Checked == true ? 1 : 0);
            cs.connDB();
            cs.insertData = "settings_posSetup @allowDupItems = '" + isAllow + "'";
            cs.IUD(cs.insertData);         
            cs.disconMy();
            MessageBox.Show("POS Setup successfully saved","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            return;

        }

        private void frmPosSetup_Load(object sender, EventArgs e)
        {
            posSetupShow();
        }
        private void posSetupShow()
        {
            int isAllow = 0;
            
            DataTable dt = new DataTable();
            cs.connDB();
            dt = cs.DISPLAY("settings_PosSetupShow");           
            cs.disconMy();
            isAllow = (dt.Rows.Count > 0? Convert.ToInt32(dt.Rows[0][0].ToString()) : 0);
            checkAllow.Checked = (isAllow == 0 ? false:true);
                                 
        }
    }
}
