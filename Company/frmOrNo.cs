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
    public partial class frmOrNo : Form
    {
        connString cs = new connString();
        decimal orID = 0;

        public frmOrNo()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOr.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmOrNo_Load(object sender, EventArgs e)
        {
            loadOrStart();
        }
        private void orCommand()
        {
            genOriD();
            cs.connDB();
            cs.insertData = "orStartCommand @orId = '" + orID + "',@orNo = '" + txtOr.Text + "', @addedBy = '" + addedByUser.addedBy + "', @dateAdded = '" + DateTime.Now + "',@machineName ='" + cs.machineName + "',@machineNo = '" + posMachineNo.machineNo + "'";
            cs.IUD(cs.insertData);
            cs.disconMy();
            MessageBox.Show("Saved!", "Database message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            return;
        }
        
        private void genOriD()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(max(orID),1000000) + 1 from tbl_StartOrNo ");
            cs.disconMy();
            orID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
        }
        private void loadOrStart()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select orNo from tbl_StartOrNo where machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                txtOr.Text = cs.dbSearchData.Rows[0][0].ToString();
            }
            else
            {
                txtOr.Text = "";
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            orCommand();
        }

        private void frmOrNo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
