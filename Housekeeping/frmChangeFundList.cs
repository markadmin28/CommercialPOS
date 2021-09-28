using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Housekeeping
{
    public partial class frmChangeFundList : Form
    {
        connString cs = new connString();
        public frmChangeFundList()
        {
            InitializeComponent();
        }

        private void frmChangeFundList_Load(object sender, EventArgs e)
        {
            ChangeFundList();
        }
        public void ChangeFundList()
        {
            double amt = 0;
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("sp_dailyChangeFundList @dateNow = '" + DateTime.Now + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i =0; i <= cs.dbSearchData.Rows.Count -1; i++)
                {
                    amt = Convert.ToDouble(cs.dbSearchData.Rows[i][2]);
                    dgw.Rows.Add((cs.dbSearchData.Rows[i][5]), cs.dbSearchData.Rows[i][4], cs.dbSearchData.Rows[i][3], cs.dbSearchData.Rows[i][1], amt.ToString("n2"), cs.dbSearchData.Rows[i][0]);
                }
                if (dgw.Rows.Count > 0)
                {
                    dgw.CurrentRow.Selected = false;
                }
                else
                {
                    //no action
                }
                lblRows.Text = dgw.Rows.Count.ToString();
            }
            else
            {
                dgw.Rows.Clear();
            }
        }

        private void dgw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (dgw.Rows.Count > 0)
                {
                    dgw.CurrentRow.Selected = false;
                }
                else
                {
                    //no action
                }
            }
         
        }
        private void PassValue()
        {
            if (dgw.Rows.Count > 0)
            {
                if (dgw.CurrentRow.Selected == true)
                {
                    frmChangeFundAmount fca = new frmChangeFundAmount(this);
                    fca.txtChangeAmt.Text = dgw.CurrentRow.Cells[4].Value.ToString();
                    fca.cashInOutID = Convert.ToDecimal(dgw.CurrentRow.Cells[5].Value);
                    fca.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Select specific data", "System message",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
               
            }
            else
            {
                //no action
            }          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {           
                PassValue();           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PassValue();
        }
    }
}
