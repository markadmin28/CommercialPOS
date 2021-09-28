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
    public partial class frmPosCustName : Form
    {
        connString cs = new connString();
        string action = "";
        string msg = "";
        Product_Menu.frmPos fp = null;
        string nNoteType = "CustomerName";
        string nullValue = "";
        decimal discountID = 0;

        public frmPosCustName(Product_Menu.frmPos _fp)
        {
            InitializeComponent();
            fp = _fp;
        }

        private void txtCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (txtCash.Text != "")
                {
                    txtCash.Text = "";
                }
                else
                {
                    this.Dispose();
                }
                
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCash.Text != "")
                {
                    action = "Insert";
                    msg = "Customers' name saved!";
                }
                else
                {
                    action = "Delete";
                    msg = "Customers' name deleted!";
                }
                fp.customerName = txtCash.Text; //store customer name in customer name variable
                fp.CustomerNameCommand(action , msg, txtCash.Text, nNoteType,nullValue, nullValue, nullValue, nullValue,0);
                this.Dispose();
            }
            
        }
        
        private void frmPosCustName_Load(object sender, EventArgs e)
        {
            action = "Display";
            loadCustomerName(action);
        }
        private void loadCustomerName(string act)
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("tempBilling_customerName @action = '" + act + "', @cusName = '" + txtCash.Text + "', @machineName = '" + cs.machineName + "', @machineNo = '" + posMachineNo.machineNo + "', @dateNow = '" + DateTime.Now + "', @discID = '" + nullValue + "', @discCusName = '" + nullValue + "', @discRemarks = '" + nullValue + "', @discHomeAdd = '" + nullValue + "',@discountID = '" + discountID + "' ");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                txtCash.Text = cs.dbSearchData.Rows[0][0].ToString();
            }
            else
            {
                txtCash.Text = "";
            }
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            var txt = (TextBox)sender;
            if (txt.Text.StartsWith(" "))
            {
                txt.Text = "";
            }
            
        }
    }
}
