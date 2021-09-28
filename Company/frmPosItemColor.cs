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
    public partial class frmPosItemColor : Form
    {
        connString cs = new connString();
        public frmPosItemColor()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRed.Text = "";
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string action = "Insert";
            posItemColor(action); 
        }
        private void posItemColor(string act)
        {
            cs.connDB();
            cs.insertData = "sp_posItemColor @action = '" + act +"'  , @red = '" + txtRed.Text + "'";
            cs.IUD(cs.insertData);
            cs.disconMy();
            MessageBox.Show("Color settings saved", "System message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            return;
        }
        private void displayItemColor(string act)
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("sp_posItemColor @action = '" + act + "', @red = '"+ txtRed.Text + "'  " );
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
               
                txtRed.Text = cs.dbSearchData.Rows[0][0].ToString();
            }
            else
            {
              
                txtRed.Text = "";
            }
        }

        private void frmPosItemColor_Load(object sender, EventArgs e)
        {
            string action = "Display";
            displayItemColor(action);
        }
    }
}
