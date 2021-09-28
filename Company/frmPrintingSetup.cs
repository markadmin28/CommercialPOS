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
    public partial class frmPrintingSetup : Form
    {
        connString cs = new connString();

        string actn = "";

     
        public frmPrintingSetup()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmPrintingSetup_Load(object sender, EventArgs e)
        {
             loadSettings();
            checkSettings();
            SettingsPosPrintingShow();
        }
        private void SettingsPosPrintingShow()
        {
            int isDirNextTrans = 0;
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("settins_PosPrintingShow @machineNo = '" + posMachineNo.machineNo + "',@machineName = '" + Environment.MachineName + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                isDirNextTrans = Convert.ToInt32(cs.dbSearchData.Rows[0][0].ToString());
            }
            else
            {
                // no action
            }
            cDirect.Checked = (isDirNextTrans == 1 ? true : false);
        }

        private void frmPrintingSetup_Enter(object sender, EventArgs e)
        {

        }
        private void printingSetupCommand()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select recNo from tbl_settings_printing where machineName = '" + cs.machineName + "' and machineNo = '"  + posMachineNo.machineNo + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                actn = "update";
            }
            else
            {
                actn = "insert";
            }
            //POs Printing
            SettingsPosPrinting(cDirect);
            checkCommand();
            cs.connDB();
            cs.insertData = "settings_printing_setup @action = '" + actn + "', @receipt = '" + receipt_settings.receiptSettings + "', @machineName = '" + cs.machineName + "', @machineNo = '" + posMachineNo.machineNo + "' ";
            cs.IUD(cs.insertData);
            cs.disconMy();
            quantityNotificCommand(); //quantity notification command
            ChargeInvoicePrinting(); // charge invoice printing 
            MessageBox.Show("Saved!", "Database message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        
        private void checkCommand()
        {
            if (radioButton1.Checked == true && radioButton2.Checked == false)
            {
                receipt_settings.receiptSettings = 0;
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == true)
            {
                receipt_settings.receiptSettings = 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            printingSetupCommand();
        }
        private void SettingsPosPrinting(CheckBox ck)
        {

            int dirNextTrans = (ck.Checked == true ? 1 : 0);

            cs.connDB();
            cs.insertData = "settings_PosPrinting @dirNextTrans = '" + dirNextTrans + "',@machineNo = '" + POS.posMachineNo.machineNo + "',@machineName = '" + Environment.MachineName + "' ";
            cs.IUD(cs.insertData);
            cs.disconMy();
        }
        private void quantityNotificCommand()
        {
            
            if (checkNotify.Checked == true)
            {
                s_prodQuantityStatus.prodQuantityStat = 1;
            }
            else
            {
                s_prodQuantityStatus.prodQuantityStat = 0;
            }
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select quantityNotification from tbl_settings_quantityNotification");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                cs.connDB();
                cs.updateData = "update tbl_settings_quantityNotification set quantityNotification = '" + s_prodQuantityStatus.prodQuantityStat + "'";
                cs.IUD(cs.updateData);
                cs.disconMy();
            }
            else
            {
                cs.connDB();
                cs.insertData = "insert into tbl_settings_quantityNotification (quantityNotification)values ('" + s_prodQuantityStatus.prodQuantityStat + "')";
                cs.IUD(cs.insertData);
                cs.disconMy();
            }
        }
        private void ChargeInvoicePrinting()
        {
            string chargeInvoicePrinting = "";
            int printType = 0;
            if (rbtn1.Checked == true)
            {
                printType = 1;
            }
            else if (rbtn2.Checked == true)
            {
                printType = 2;
            }
            else if (rbtn3.Checked == true)
            {
                printType =3;
            }
            else
            {
                printType = 0;
            }

            cs.connDB();
            chargeInvoicePrinting = "settings_chargeInvoicePrinting @printType = '" + printType + "', @machineNo = '" + posMachineNo.machineNo + "' , @machineName = '" + cs.machineName + "'";
            cs.IUD(chargeInvoicePrinting);
            cs.disconMy();
        }
        private void loadSettings()
        {
            DataTable dt = new DataTable();
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(direct_print_receipt,0)  from tbl_settings_printing where machineNo = '" + posMachineNo.machineNo + "' and machineName = '" + cs.machineName + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                receipt_settings.receiptSettings = Convert.ToInt32(cs.dbSearchData.Rows[0][0].ToString());                
            }
            else
            {
                receipt_settings.receiptSettings = 0;
            }
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(quantityNotification,0) from tbl_settings_quantityNotification");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                s_prodQuantityStatus.prodQuantityStat = Convert.ToInt32(cs.dbSearchData.Rows[0][0]);
            }
            else
            {
                s_prodQuantityStatus.prodQuantityStat = 0;
            }
            cs.connDB();
            dt = cs.DISPLAY("select isnull(PrintType ,0) as PrintType  from tbl_SettingsChargeInvoicePrinting where machineNo = '" + posMachineNo.machineNo + "' and machineName = '" + cs.machineName + "'");
            cs.disconMy();
            if (dt.Rows.Count > 0)
            {
                s_chargeInvoicePrinting.chargeInvoice = Convert.ToInt32(dt.Rows[0][0]);
            }
            else
            {
                s_chargeInvoicePrinting.chargeInvoice = 0;
            }
            
            
        }
        private void checkSettings()
        {
            if (receipt_settings.receiptSettings == 0)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
            if (s_prodQuantityStatus.prodQuantityStat == 0)
            {
                checkNotify.Checked = false;
            }
            else
            {
                checkNotify.Checked = true;
            }
            if (s_chargeInvoicePrinting.chargeInvoice == 0) // charge invoice printing
            {
                rbtn1.Checked = false;
                rbtn2.Checked = false;
                rbtn3.Checked = false;
            }
            else if (s_chargeInvoicePrinting.chargeInvoice ==1)
            {
                rbtn1.Checked = true;
                rbtn2.Checked = false;
                rbtn3.Checked = false;
            }
            else if (s_chargeInvoicePrinting.chargeInvoice == 2)
            {
                rbtn1.Checked = false;
                rbtn2.Checked = true;
                rbtn3.Checked = false;
            }
            else if (s_chargeInvoicePrinting.chargeInvoice == 3)
            {
                rbtn1.Checked = false;
                rbtn2.Checked = false;
                rbtn3.Checked = true;
            }
        }

        private void frmPrintingSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
