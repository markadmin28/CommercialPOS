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
    public partial class frmPosReg : Form
    {
        connString cs = new connString();
        string newAction = "";
        decimal posRecID = 0;
        
        public frmPosReg()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            posRegClearFields();
        }
        private void posRegClearFields()
        {
            txtMin.Text = "";
            txtPosDesc.Text = "";
            txtSerialNo.Text = "";
            txtMachineNo.Text = "";
            cmbSm.Text = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int isClerk = 0;
            DialogResult res;
            if (posRecID == 0)
            {
                newAction = "Insert";
                res = MessageBox.Show("Are you sure you want to save this POS Information?", "Confirmatino",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
               if (res == DialogResult.Yes)
                {
                    if (cmbSm.SelectedIndex == 0)
                    {
                        isClerk = 1;
                    }
                    else
                    {
                        isClerk = 0;
                    }
                    genPosRecID();
                    posInfo(newAction, posRecID, txtPosDesc.Text, txtMin.Text, txtMaName.Text,txtSerialNo.Text,txtMachineNo.Text,isClerk);
                    MessageBox.Show("POS Informatin Saved!", "Database message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
               else
                {
                    return;
                }                
            }
            else
            {
                newAction = "Update";
                res = MessageBox.Show("Are you sure you want to update this POS Information?", "Confirmatino", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (cmbSm.SelectedIndex == 0)
                    {
                        isClerk = 1;
                    }
                    else
                    {
                        isClerk = 0;
                    }
                    posInfo(newAction, posRecID, txtPosDesc.Text, txtMin.Text, txtMaName.Text,txtSerialNo.Text,txtMachineNo.Text, isClerk);
                    MessageBox.Show("POS Informatin Updated!", "Database message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    return;
                }
            }
        }
        #region Logic
        private void posInfo(string action,decimal recID, string posDesc, string min,string machineName,string serialNo,string machineNo, int isClerk)
        {
            cs.connDB();
            cs.insertData = "posReg  @action = '" +action + "' ,@recID = '" + recID + "',@posDesc = '"+ posDesc + "',@min = '" + min + "',@machineName = '" + machineName + "',@serialNo = '" + serialNo + "',@addedBy = '" + addedByUser.addedBy + "',@dateAdded = '" + DateTime.Now + "',@machineNo = '" + machineNo + "' , @isClerk = '" + isClerk + "'";
            cs.IUD(cs.insertData);
            cs.disconMy();
        }
        private void posInfoLoad()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select recID,posDesc,MIN,machineName,serialNo,addedBy,dateAdded,machineNo,case when isClerk =0 then 'No' else 'Yes' end as [isClerk] from tbl_posReg where machineName = '" + cs.machineName + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                posRecID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
                txtPosDesc.Text = cs.dbSearchData.Rows[0][1].ToString();
                txtMin.Text = cs.dbSearchData.Rows[0][2].ToString();
                txtMaName.Text = cs.dbSearchData.Rows[0][3].ToString();
                txtSerialNo.Text = cs.dbSearchData.Rows[0][4].ToString();
                txtMachineNo.Text = cs.dbSearchData.Rows[0][7].ToString();
                cmbSm.Text = cs.dbSearchData.Rows[0][8].ToString();
            }
            else
            {
                posRegClearFields();
            }
        }
        private void genPosRecID()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(max(recID),1000000) + 1 as recID from tbl_posReg");
            posRecID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
            cs.disconMy();
        }
        #endregion

        private void frmPosReg_Load(object sender, EventArgs e)
        {
            posInfoLoad();
            txtMaName.Text = cs.machineName;
        }

        private void frmPosReg_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
