using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Billing
{
    public partial class frmShowSameProdId : Form
    {
        connString cs = new connString();
        public string extProdId = "";
        public frmShowSameProdId()
        {
            InitializeComponent();
        }

        private void dgw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (dgw.Rows.Count > 0)
                {
                    this.Dispose();
                }
                else
                {
                    //no action
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (dgw.Rows.Count > 0)
                {
                    Product_Menu.frmPos fp = (Product_Menu.frmPos)Owner;
                    fp.isProdIdFinal = true;
                    fp.txtItemCode.Text = dgw.CurrentRow.Cells[0].Value.ToString();
                    this.Dispose();
                }
                else
                {
                    //no action
                }
            }
        }

        private void frmShowSameProdId_Load(object sender, EventArgs e)
        {
            DisplaySameProdId();
        }
        private void DisplaySameProdId()
        {
            DataTable dt = new DataTable();
            cs.connDB();
            dt = cs.DISPLAY("declare  @prodId nvarchar(max) = '" + extProdId + "' select prodID,prodDesc,Convert(varchar(10),prodDateExpired,101) as DateExpired from tbl_prodMaster where prodid like '%' + @prodId +'%'");
            cs.disconMy();
            if (dt.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i =0; i <= dt.Rows.Count -1; i++ )
                {
                    dgw.Rows.Add((dt.Rows[i][0]), dt.Rows[i][1], dt.Rows[i][2]);
                }
                 
            }
            else
            {
                dgw.Rows.Clear();
            }
        }
    }
}
