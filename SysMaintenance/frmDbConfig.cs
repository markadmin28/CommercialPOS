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
using Microsoft.VisualBasic;

namespace POS.SysMaintenance
{
    public partial class frmDbConfig : Form
    {
        private string TstServerMySQL;
       
        private string TstUserNameMySQL;
        private string TstPwdMySQL;
        private string TstDBNameMySQL;
        connString cs = new connString();

        public frmDbConfig()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmDbConfig_Load(object sender, EventArgs e)
        {
            //this.Location = new Point(178, 127);
            txtServerHost.Text = connString.ServerMySQL;
            
            txtUserName.Text = connString.UserNameMySQL;
            txtPassword.Text = connString.PwdMySQL;
            txtDatabase.Text = connString.DBNameMySQL;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TstServerMySQL = txtServerHost.Text;            
            TstUserNameMySQL = txtUserName.Text;
            TstPwdMySQL = txtPassword.Text;
            TstDBNameMySQL = txtDatabase.Text;

            try
            {
                cs.cn.ConnectionString = "Server = '" + TstServerMySQL + "';  " + "Database = '" + TstDBNameMySQL + "'; " + "user id = '" + TstUserNameMySQL + "'; " + "password = '" + TstPwdMySQL + "'";
                cs.cn.Open();

                connString.DBNameMySQL = txtDatabase.Text;
                connString.ServerMySQL = txtServerHost.Text;
                connString.UserNameMySQL = txtUserName.Text;

                connString.PwdMySQL = txtPassword.Text;

                connString.SaveData();
                this.Close();
            }
            catch
            {
                Interaction.MsgBox("The system failed to establish a connection", MsgBoxStyle.Critical, "Database Settings");
            }
            cs.disconMy();
            //save database
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //Test database connection

            TstServerMySQL = txtServerHost.Text;            
            TstUserNameMySQL = txtUserName.Text;
            TstPwdMySQL = txtPassword.Text;
            TstDBNameMySQL = txtDatabase.Text;


            try
            {
                cs.cn.ConnectionString = "Server = '" + TstServerMySQL + "';    " + "Database = '" + TstDBNameMySQL + "'; " + "user id = '" + TstUserNameMySQL + "'; " + "password = '" + TstPwdMySQL + "'";


                cs.cn.Open();
                Interaction.MsgBox("Test connection successful", MsgBoxStyle.Information, "Database Settings");

            }
            catch
            {
                Interaction.MsgBox("The system failed to establish a connection", MsgBoxStyle.Critical, "Database Settings");
            }
            cs.disconMy();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SysMaintenance.frmRestoreDatabase frd = new frmRestoreDatabase();
            frd.ShowDialog();
        }

        private void frmDbConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
