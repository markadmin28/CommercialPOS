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
    public partial class frmCompany : Form
    {
        connString cs = new connString();
        string newAction = "";
        decimal recID = 0;
        public frmCompany()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void compInfoClear()
        {
            foreach (Control ctrl in tabPage1.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ctrl.Text = null;
                }
            }
            recID = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            compInfoClear();
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            loadCompInfo();
        }
        #region Logic
        private void compInfo(string newAct,string compName,string prop,string TIN,string add)
        {
            cs.connDB();
            cs.insertData = "compInfo @action = '" + newAct + "',@recID = '" + recID + "',@compName = '" + compName + "',@compProp = '" + prop + "',@compTIN = '" + TIN + "' ,@compAdd = '" + add + "',@addedBy = '" + addedByUser.addedBy + "',@dateAdded = '" + DateTime.Now + "' ";
            cs.IUD(cs.insertData);
            cs.disconMy();
            
        }
        private void loadCompInfo()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("compInfoLoad");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                recID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
                txtCompName.Text = cs.dbSearchData.Rows[0][1].ToString();
                txtProp.Text = cs.dbSearchData.Rows[0][2].ToString();
                txtTin.Text = cs.dbSearchData.Rows[0][3].ToString();               
                txtAdd.Text = cs.dbSearchData.Rows[0][4].ToString();
            }
            else
            {
                compInfoClear();
            }
        }
        private void genRecID()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(max(recID),1000000) + 1 as recID from tbl_compInfo");
            recID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
            cs.disconMy();
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult res;             
            if (recID == 0)
            {
                newAction = "Insert";
                res = MessageBox.Show("Are you sure you want to save this company informatin?", "Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    genRecID();
                    compInfo(newAction, txtCompName.Text, txtProp.Text, txtTin.Text, txtAdd.Text);
                    MessageBox.Show("Saved!", "Database message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                res = MessageBox.Show("Are you sure you want to update this company informatin?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    compInfo(newAction, txtCompName.Text, txtProp.Text, txtTin.Text,   txtAdd.Text);
                    MessageBox.Show("Updated!", "Database message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    return;
                }
            }
         
        }

        private void frmCompany_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
