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
    public partial class frmUser : Form
    {
        connString cs = new connString();
        public decimal userID = 0;
        public int isUserActive = 0;
        public frmUser()
        {
            InitializeComponent();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          savingUserData();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            loadAccessForm();
        }
        private void loadAccessForm()
        {
            if (s_allowDeletion.allowDeletion ==1)
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
             
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
             
            
        }
        private void SaveUser()
        {
            
         if (rBtnActive.Checked == true)
            {
                isUserActive = 1;
            }
         else
            {
                isUserActive = 0;
            }

            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select userID from tbl_user where userID = '" + userID + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                cs.connDB();
                cs.updateData = "update tbl_user set userFullName = '" + txtName.Text.Trim() + "',userName = '" + txtUn.Text.Trim() + "',userPassword = '" +  txtUp.Text.Trim() + "', userType = '" + txtut.Text.Trim() + "', userAddedBy = '" + addedByUser.addedBy + "',userDateAdded = '" + DateTime.Now + "', isActive = '" + isUserActive + "' where userID = '" + userID + "' ";
                cs.IUD(cs.updateData);
                cs.disconMy();             
                MessageBox.Show("Updated!", "Database message",MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmUserClear();
            }
            else
            {
                genUserID();
                cs.connDB();
                cs.insertData = ("insert into tbl_user (userID,userFullName,userName,userPassword,userType,userAddedBy,userDateAdded,isActive)values('" + userID + "','" + txtName.Text.Trim() + "','" + txtUn.Text.Trim() + "','" + txtUp.Text.Trim() + "','" + txtut.Text.Trim() + "','" + addedByUser.addedBy + "','" + DateTime.Now + "','" + isUserActive + "')");
                cs.IUD(cs.insertData);
                cs.disconMy();
                MessageBox.Show("Saved!", "Database message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmUserClear();
            }

          
           
        }
        private void genUserID()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(max(userID),1001) + 1 from tbl_user ");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                userID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
            }
            else
            {
                userID = 0;
            }
        }
        public void savingUserData()
        {
            if (txtUn.Text == "" || txtUp.Text == "" || txtcup.Text == "" || txtut.Text == "")
            {
                MessageBox.Show("Please fill important entry!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (txtUp.Text != txtcup.Text)
                {
                    MessageBox.Show("Password mismatch!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    if (userID == 0)
                    {
                        cs.connDB();
                        cs.dbSearchData = cs.DISPLAY("select userID from tbl_user where userName = '" + txtUn.Text.Trim() + "'");
                        cs.disconMy();
                        if (cs.dbSearchData.Rows.Count > 0)
                        {
                            MessageBox.Show("Username already inused!", "Username validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {
                            if (txtut.Text == "Cashier" || txtut.Text == "Encoder" || txtut.Text == "Inventory Management" || txtut.Text == "Administrator" || txtut.Text == "Clerk")
                            {
                                SaveUser();
                            }
                            else
                            {
                                MessageBox.Show("Invalid User Type", "User Type validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txtut.DroppedDown = true;
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (txtut.Text == "Cashier" || txtut.Text == "Encoder" || txtut.Text == "Inventory Management" || txtut.Text == "Administrator" || txtut.Text == "Clerk")
                        {
                            SaveUser();
                        }
                        else
                        {
                            MessageBox.Show("Invalid User Type", "User Type validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtut.DroppedDown = true;
                            return;
                        }
                    }

                                         
                }
            }            
        }
        private void frmUserClear()
        {
            foreach (Control ctrl in this.panel1.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(ComboBox))
                {
                    ctrl.Text = null;
                }
            }
            userID = 0;
            txtName.Focus();
            rBtnActive.Checked = true;
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            frmUserClear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSearchUser fsu = new frmSearchUser(this);
            frmUserClear();
            fsu.ShowDialog();
        }

        private void frmUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteUser();
        }
        private  void deleteUser()
        {
            if (userID == 0)
            {
                MessageBox.Show("Select user to delete!","Validation",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                DialogResult res;
                res = MessageBox.Show("Are you sure you want to remove this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    cs.connDB();
                    cs.updateData = "update tbl_user set isDeleted = 1 where userID = '" + userID + "'";
                    cs.IUD(cs.updateData);
                    cs.disconMy();
                    MessageBox.Show("Deleted!", "Database message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmUserClear();
                }
                else
                {
                    return;
                }
            }
             
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUn.Focus();
            }
        }

        private void txtUn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUp.Focus();
            }
        }

        private void txtUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtcup.Focus();
            }
        }

        private void txtcup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtut.Focus();
            }
        }
    }
    
}
