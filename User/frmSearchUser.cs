using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.User
{
    public partial class frmSearchUser : Form
    {
        connString cs = new connString();
        frmUser fu = null;
        public frmSearchUser(frmUser fu)
        {
            InitializeComponent();
            this.fu = fu;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            loadUserData();
        }
        private void loadUserData()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select  userID ,userFullName ,userName ,(select userFullName from tbl_user where userID = tu.userAddedBy) as [Addedby] ,userDateAdded ,userType ,case when isActive = 1 then 'YES' else 'NO' end as [Active]  ,userAddedBy,userPassword from tbl_user tu where (userFullName like '%" + txtKeyword.Text.Trim() + "%' or userID like '%" + txtKeyword.Text.Trim() + "%' or userName like '%" + txtKeyword.Text.Trim() + "%' or userType like '%" + txtKeyword.Text.Trim() + "%') and isDeleted =0");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i = 0; i <= cs.dbSearchData.Rows.Count -1; i++)
                {
                    dgw.Rows.Add((cs.dbSearchData.Rows[i][0]), cs.dbSearchData.Rows[i][1], cs.dbSearchData.Rows[i][2], cs.dbSearchData.Rows[i][3], cs.dbSearchData.Rows[i][4], cs.dbSearchData.Rows[i][5], cs.dbSearchData.Rows[i][6], cs.dbSearchData.Rows[i][8]);
                }
                if (dgw.Rows.Count > 0)
                {
                    dgw.CurrentRow.Selected = false;
                }
                else
                {

                }
            }
            else
            {
                dgw.Rows.Clear();
            }
            lblRows.Text = dgw.Rows.Count.ToString();
        }

        private void dgw_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void dgw_Leave(object sender, EventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                dgw.CurrentRow.Selected = false;
            }
            else
            {

            }
        }
        private void frmSearchUser_FormClosed(object sender, FormClosedEventArgs e)
        {            
            this.Dispose();
        }
        private void dgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PassValueToUserForm();
        }
        private void PassValueToUserForm()
        {
            string isUserActiveLabel = "";
            fu.userID = Convert.ToDecimal(dgw.CurrentRow.Cells[0].Value);
            fu.txtName.Text = dgw.CurrentRow.Cells[1].Value.ToString();
            fu.txtUn.Text = dgw.CurrentRow.Cells[2].Value.ToString();
            fu.txtut.Text = dgw.CurrentRow.Cells[5].Value.ToString();
            isUserActiveLabel = dgw.CurrentRow.Cells[6].Value.ToString();
            fu.txtUp.Text = dgw.CurrentRow.Cells[7].Value.ToString();
            fu.txtcup.Text = dgw.CurrentRow.Cells[7].Value.ToString();
            if (isUserActiveLabel == "YES")
            {
                fu.rBtnActive.Checked = true;
            }
            else
            {
                fu.rBtnInactive.Checked = true;
            }
            this.Dispose();
        }

        private void frmSearchUser_Load(object sender, EventArgs e)
        {
            loadUserData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (dgw.Rows.Count > 0)
                {
                    dgw.Focus();
                    dgw.CurrentRow.Selected = true;
                }
                else
                {
                    //no action
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (txtKeyword.Text != "")
                {
                    txtKeyword.Text = "";
                }
                else
                {
                    this.Dispose();
                }
            }
        }

        private void dgw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtKeyword.Focus();
                txtKeyword.SelectAll();
            }
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PassValueToUserForm();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtKeyword.Focus();
            txtKeyword.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmUserListRpt fur = new frmUserListRpt();
            fur.userKeyword = txtKeyword.Text;
            fur.ShowDialog();
        }
    }
}
