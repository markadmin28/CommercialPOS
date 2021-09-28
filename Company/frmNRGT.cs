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
    public partial class frmNRGT : Form
    {
        connString cs = new connString();
        decimal NRGTID = 0;
        string actn = "";
        double Nrgt = 0;
        double prevNrgt = 0;

        public frmNRGT()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            NrgtClearFields();
        }
        private void NrgtClearFields()
        {
            txtPN.Text = "";
            txtN.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            txtPN.Focus();
        }
        private void saveNrgtCommand()
        {
            cs.connDB();
            cs.insertData = "NRGTcommand @action = '" + actn + "',@nrgtid = '" + NRGTID + "',@prevNrgt = '" + Convert.ToDouble(txtPN.Text) + "',@nrgt = '" + Convert.ToDouble(txtN.Text) + "',@addedBy = '" + addedByUser.addedBy + "',@dateAdded = '" + DateTime.Now + "',@machineName = '" + cs.machineName + "',@machineNo = '"  + posMachineNo.machineNo + "'";
            cs.IUD(cs.insertData);
            cs.disconMy();
        }
        private void NrgtCommand()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select NRGTID from tbl_NRGT where machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                actn = "Update";
                saveNrgtCommand();
                MessageBox.Show("NRGT Updated!", "Database message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                actn = "Insert";
                genNRGTID();
                saveNrgtCommand();
                MessageBox.Show("NRGT Saved!", "Database message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void loadNrgtData()
        {

            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select NRGTID,prevNRGT,NRGT from tbl_NRGT where machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                NRGTID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
                prevNrgt = Convert.ToDouble(cs.dbSearchData.Rows[0][1]) ;
                Nrgt = Convert.ToDouble(cs.dbSearchData.Rows[0][2]) ;

                txtPN.Text = prevNrgt.ToString("n2");
                txtN.Text = Nrgt.ToString("n2");
            }
            else
            {
                NRGTID = 0;
                txtPN.Text = "0";
                txtN.Text = "0";
            }
        }
        private void genNRGTID()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(max(NRGTID),1000000000000) + 1 from tbl_NRGT");
            cs.disconMy();
            NRGTID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NrgtCommand();
        }

        private void frmNRGT_Load(object sender, EventArgs e)
        {
            loadNrgtData();
        }

        private void txtPN_Leave(object sender, EventArgs e)
        {
          
            prevNrgt = Convert.ToDouble(txtPN.Text);
            txtPN.Text = prevNrgt.ToString("n2");
        }

        private void txtN_Leave(object sender, EventArgs e)
        {
          
            Nrgt = Convert.ToDouble(txtN.Text);
            txtN.Text = Nrgt.ToString("n2");
        }

        private void frmNRGT_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
