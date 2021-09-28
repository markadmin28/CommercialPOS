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
    public partial class frmPricingOpt : Form
    {
        Product_Menu.frmPos fp = null;
        connString cs = new connString();
        public frmPricingOpt(Product_Menu.frmPos _fp)
        {
            InitializeComponent();
            fp = _fp;
        }

        private void frmPricingOpt_Load(object sender, EventArgs e)
        {
            ProdOptionsDisplay("Display");

        }
        private void ProdOptionsDisplay(string action)
        {

            string prodDesc = "";
            double price = 0;
            decimal pPoid = 0;                     
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("sp_prodOptions @action = '" + action + "',@POID = 0,@prodID = '" + txtProductCode.Text + "',@prodOptDesc = '',@prodOptPrice = 0,@addedBy = '" + addedByUser.addedBy + "',@dateAdded = '" + DateTime.Now + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i = 0; i <= cs.dbSearchData.Rows.Count - 1; i++)
                {
                    pPoid = Convert.ToDecimal(cs.dbSearchData.Rows[i][0]);
                    price = Convert.ToDouble(cs.dbSearchData.Rows[i][3]);
                    prodDesc = cs.dbSearchData.Rows[i][2].ToString();
                    dgw.Rows.Add((prodDesc), price.ToString("n2"), pPoid);
                }
               
            }
            else
            {
                dgw.Rows.Clear();
            }
        }
        private void PricingOptions()
        {
            cs.connDB();
            cs.updateData = "Update tbl_tempBilling set POID = '" + Convert.ToDecimal(dgw.CurrentRow.Cells[2].Value.ToString()) + "' where prodID = '" + txtProductCode.Text + "' and isSuspended =0 and machineID = '" + cs.machineName + "' ";
            cs.IUD(cs.updateData);
            cs.disconMy();
            fp.showTempBillingItemsList();
        }

        private void dgw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
            if (e.KeyCode == Keys.Enter)
            {
                PricingOptions();
                e.SuppressKeyPress = true;
                this.Dispose();
                
            }
        }
    }
}
