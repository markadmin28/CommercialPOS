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
    public partial class frmAccessForm : Form
    {
        connString cs = new connString();
        int systemMaintenance = 0;
        int posSetup = 0;
        int systemUser = 0;
        int productMenu = 0;
        int productMaster = 0;
        int productCategory = 0;
        int productUom = 0;
        int productInventory = 0;
        int stockin = 0;
        int stockout = 0;
        int inquiry = 0;
        int transactionList = 0;
        int reports = 0;
        int inventoryReport = 0;
        int openPos = 0;
        int dbConfig = 0;
        int restoreDb = 0;
        int backupDb = 0;
        int annualBegInv = 0;
        int allowDeletion = 0;
        int customerManagement = 0;
        int customerRegistration = 0;
        int discountList = 0;
        int setDiscount = 0;
        int transactionSummaryReport = 0;
        int productMasterlist = 0;
        int readingTrail = 0;
        int salesbook = 0;
        int posMaintenance = 0;
        int initializeProduct_salesInfo = 0;
        int housekeeping = 0;
        int dailyChangeFund = 0;
        public frmAccessForm()
        {
          
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmAccessForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            uncheckCommand();
        }
        private void uncheckCommand()
        {
             foreach (Control ctrl in this.tpAccessControl.Controls)
            {
               if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = false;
                }
            }
        }
        private void CheckCommand()
        {
            foreach (Control ctrl in this.tpAccessControl.Controls)
            {
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = true;
                }
            }
        }
        private void checkingAccess()
        {
            if (checkBox1.Checked == true)
            {
                 systemMaintenance = 1;
            }
            else
            {
                 systemMaintenance = 0;
            }
            if (checkBox2.Checked == true)
            {
                 posSetup = 1;
            }
            else
            {
                 posSetup = 0;
            }
            if (checkBox3.Checked == true)
            {
                 systemUser = 1;
            }
            else
            {
                 systemUser = 0;
            }
            if (checkBox4.Checked == true)
            {
                 productMenu = 1;
            }
            else
            {
                 productMenu = 0;
            }
            if(checkBox5.Checked == true)
            {
                 productMaster = 1;
            }
            else
            {
                 productMaster = 0;
            }
            if (checkBox6.Checked == true)
            {
                 productCategory = 1;
            }
            else
            {
                 productCategory = 0;
            }
            if (checkBox7.Checked == true)
            {
                 productUom = 1;
            }
            else
            {
                 productUom = 0;
            }
            if (checkBox8.Checked == true)
            {
                 productInventory = 1;
            }
            else
            {
                 productInventory = 0;
            }
            if (checkBox9.Checked == true)
            {
                 stockin = 1;
            }
            else
            {
                 stockin = 0;
            }
            if (checkBox10.Checked == true)
            {
                  stockout = 1;
            }
            else
            {
                 stockout = 0;
            }
            if (checkBox11.Checked == true)
            {
                 inquiry = 1;
            }
            else
            {
                 inquiry = 0;
            }
            if (checkBox12.Checked == true)
            {
                 transactionList = 1;
            }
            else
            {
                 transactionList = 0;
            }
            if (checkBox13.Checked == true)
            {
                 reports = 1;
            }
            else
            {
                 reports = 0;
            }
            if (checkBox14.Checked == true)
            {
                 inventoryReport = 1;
            }
            else
            {
                 inventoryReport = 0;
            }
            if (checkBox15.Checked == true)
            {
                 openPos = 1;
            }
            else
            {
                 openPos = 0;
            }
            if (checkBox16.Checked == true)
            {
                 dbConfig = 1;
            }
            else
            {
                 dbConfig = 0;
            }
            if(checkBox17.Checked == true)
            {
                 restoreDb = 1;
            }
            else
            {
                 restoreDb = 0;
            }
            if(checkBox18.Checked == true)
            {
                 backupDb = 1;
            }
            else
            {
                 backupDb = 0;
            }
            if (checkBox19.Checked == true)
            {
                 annualBegInv = 1;
            }
            else
            {
                 annualBegInv = 0;
            }
            if(checkBox20.Checked == true)
            {
                 allowDeletion = 1;
            }
            else
            {
                 allowDeletion = 0;
            }

            if (checkBox21.Checked == true)
            {
                 customerManagement = 1;
            }
             else
            {
                 customerManagement = 0;
            }
            if (checkBox22.Checked == true)
            {
                 customerRegistration = 1;
            }
            else
            {
                 customerRegistration= 0;
            }
            if (checkBox23.Checked == true)
            {
                 discountList= 1;
            }
            else
            {
                 discountList= 0;
            }
            if (checkBox24.Checked == true)
            {
                  setDiscount = 1;
            }
            else
            {
                 setDiscount = 0;
            }
            if (checkBox25.Checked == true)
            {
                 transactionSummaryReport = 1;
            }
            else
            {
                 transactionSummaryReport = 0;
            }
            if (checkBox26.Checked == true)
            {
                productMasterlist = 1;
            }
            else
            {
                productMasterlist = 0;
            }
            if (checkBox28.Checked == true)
            {
                readingTrail = 1;
            }
            else
            {
                readingTrail = 0;
            }
            if (checkBox29.Checked == true)
            {
                salesbook = 1;
            }
            else
            {
                salesbook = 0;
            }
            if (checkBox30.Checked == true)
            {
                posMaintenance= 1;
            }
            else
            {
                posMaintenance = 0;
            }
            if (checkBox31.Checked == true)
            {
                initializeProduct_salesInfo = 1;
            }
            else
            {
                initializeProduct_salesInfo = 0;
            }
            if (checkBox32.Checked == true)
            {
                housekeeping = 1;
            }
            else
            {
                housekeeping = 0;
            }
            if (checkBox33.Checked == true)
            {
                dailyChangeFund = 1;
            }
            else
            {
                dailyChangeFund = 0;
            }
        }
        private void loadAccess()
        {
            if ( systemMaintenance == 1)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }            
            if ( posSetup == 1)
            {
               checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }
            if ( systemUser == 1)
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }
            if ( productMenu == 1)
            {
                checkBox4.Checked = true;
            }
            else
            {
                checkBox4.Checked = false;
            }
            if ( productMaster == 1)
            {
                checkBox5.Checked = true;
            }
            else
            {
                checkBox5.Checked = false;
            }
            if ( productCategory == 1)
            {
                checkBox6.Checked = true;
            }
            else
            {
                checkBox6.Checked = false;
            }
            if ( productUom == 1)
            {
                checkBox7.Checked = true;
            }
            else
            {
                checkBox7.Checked = false;
            }
             
            if ( productInventory == 1)
            {
                checkBox8.Checked = true;
            }
            else
            {
                checkBox8.Checked = false;
            }
            if ( stockin == 1)
            {
               checkBox9.Checked = true;
            }
            else
            {
                checkBox9.Checked = false;
            }
            if ( stockout == 1)
            {
                checkBox10.Checked = true;
            }
            else
            {
                checkBox10.Checked = false;
            }
            if ( inquiry == 1)
            {
                checkBox11.Checked = true;
            }
            else
            {
                checkBox11.Checked = false;
            }
            if ( transactionList == 1)
            {
                checkBox12.Checked = true;
            }
            else
            {
                checkBox12.Checked = false;
            }
            if ( reports == 1)
            {
                checkBox13.Checked = true;
            }
            else
            {
                checkBox13.Checked = false;
            }
            if ( inventoryReport == 1)
            {
                checkBox14.Checked = true;
            }
            else
            {
                checkBox14.Checked = false;
            }
            if ( openPos == 1)
            {
                checkBox15.Checked = true;
            }
            else
            {
                checkBox15.Checked = false;
            }
            if ( dbConfig == 1)
            {
                checkBox16.Checked = true;
            }
            else
            {
                checkBox16.Checked = false;
            }
            if ( restoreDb == 1)
            {
                checkBox17.Checked = true;
            }
            else
            {
                checkBox17.Checked = false;
            }
            if ( backupDb== 1)
            {
                checkBox18.Checked = true;
            }
            else
            {
                checkBox18.Checked = false;
            }
            if ( annualBegInv == 1)
            {
                checkBox19.Checked = true;
            }
            else
            {
                checkBox19.Checked = false;
            }
            if ( allowDeletion == 1)
            {
                checkBox20.Checked = true;
            }
            else
            {
                checkBox20.Checked = false;
            }

            if ( customerManagement ==1)
            {
                checkBox21.Checked = true;
            }
            else
            {
                checkBox21.Checked = false;
            }
            if ( customerRegistration == 1)
            {
                checkBox22.Checked = true;
            }
            else
            {
                checkBox22.Checked = false;
            }
            if ( discountList == 1)
            {
                checkBox23.Checked = true;
            }
            else
            {
                checkBox23.Checked = false;
            }
            if ( setDiscount == 1)
            {
                checkBox24.Checked = true;
            }
            else
            {
                checkBox24.Checked = false;
            }
            if ( transactionSummaryReport == 1)
            {
                checkBox25.Checked = true;
            }
            else
            {
                checkBox25.Checked = false;
            }
            if (productMasterlist ==1)
            {
                checkBox26.Checked = true;
            }
            else
            {
                checkBox26.Checked = false;
            }
            if (readingTrail ==1)
            {
                checkBox28.Checked = true;
            }
            else
            {
                checkBox28.Checked = false;
            }
            if (salesbook ==1)
            {
                checkBox29.Checked = true;
            }
            else
            {
                checkBox29.Checked = false;
            }
            if (posMaintenance ==1)
            {
                checkBox30.Checked = true;
            }
            else
            {
                checkBox30.Checked = false;
            }
            if (initializeProduct_salesInfo ==1)
            {
                checkBox31.Checked = true;
            }
            else
            {
                checkBox31.Checked = false;
            }
            if (housekeeping ==1)
            {
                checkBox32.Checked = true;
            }
            else
            {
                checkBox32.Checked = false;
            }
            if (dailyChangeFund ==1)
            {
                checkBox33.Checked = true;
            }
            else
            {
                checkBox33.Checked = false;
            }
        }
        private void accessformCommand()
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select Access type!", "System message",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                checkingAccess();
                cs.connDB();
                cs.insertData = "settings_access_form @userType = '" + comboBox1.Text + "',@systemMaintenance = '" + systemMaintenance + "' ,@posSetup = '" + posSetup + "',@systemUser = '" + systemUser + "' ,@productMenu = '" + productMenu + "' ,@productMaster = '" + productMaster + "' ,@productCategory = '" + productCategory + "' ,@productUom = '" + productUom + "' " +
                    ",@productInventory  = '" + productInventory + "',@stockin  = '" + stockin + "',@stockout  = '" + stockout + "',@inquiry = '" + inquiry + "' ,@transactionList = '" + transactionList + "' ,@reports = '" + reports + "' ,@inventoryReport = '" +  inventoryReport + "',@addedBy = '" + addedByUser.addedBy + "', @dateAdded = '" + DateTime.Now + "',@openPOS = '" + openPos + "' ," +
                    "@sysDbConfiguration = '" + dbConfig + "', @sysRestoreDB= '" + restoreDb + "', @sysBackupDB = '" + backupDb + "', @annualBegInv = '" + annualBegInv + "',@allowDeletion = '" + allowDeletion + "', @customerManagement = '" + customerManagement + "', @customerRegistration = '" + customerRegistration + "', @discountList = '" + discountList + "', @setDiscount = '" + setDiscount + "',@transactionSummaryReport = '" + transactionSummaryReport + "',  @productMasterlist = '" + productMasterlist + "' ,@readingTrail  = '" + readingTrail + "',@salesbook  = '" + salesbook + "',@posMaintenance	  ='" + posMaintenance + "',@initializeProduct_salesInfo	  ='" + initializeProduct_salesInfo + "',@housekeeping	 = '" + housekeeping + "' ,@dailyChangeFund = '" + dailyChangeFund + "' ";
                cs.IUD(cs.insertData);
                cs.disconMy();
                MessageBox.Show("Saved!", "Database message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            accessformCommand();
        }
        private void loadAccessForm()
        {
            
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("settings_loadAccessForm @userType = '" + comboBox1.Text + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
               
               systemMaintenance = Convert.ToInt32(cs.dbSearchData.Rows[0][1]);
                posSetup = Convert.ToInt32(cs.dbSearchData.Rows[0][2]);
               systemUser = Convert.ToInt32(cs.dbSearchData.Rows[0][3]);
                 productMenu = Convert.ToInt32(cs.dbSearchData.Rows[0][4]);
                productMaster = Convert.ToInt32(cs.dbSearchData.Rows[0][5]);
              productCategory = Convert.ToInt32(cs.dbSearchData.Rows[0][6]);
               productUom = Convert.ToInt32(cs.dbSearchData.Rows[0][7]);
                productInventory = Convert.ToInt32(cs.dbSearchData.Rows[0][8]);
                stockin = Convert.ToInt32(cs.dbSearchData.Rows[0][9]);
                stockout= Convert.ToInt32(cs.dbSearchData.Rows[0][10]);
               inquiry= Convert.ToInt32(cs.dbSearchData.Rows[0][11]);
                transactionList= Convert.ToInt32(cs.dbSearchData.Rows[0][12]);
                reports= Convert.ToInt32(cs.dbSearchData.Rows[0][13]);
                inventoryReport= Convert.ToInt32(cs.dbSearchData.Rows[0][14]);
              openPos= Convert.ToInt32(cs.dbSearchData.Rows[0][15]);
                dbConfig = Convert.ToInt32(cs.dbSearchData.Rows[0][18]);
                restoreDb = Convert.ToInt32(cs.dbSearchData.Rows[0][19]);
              backupDb = Convert.ToInt32(cs.dbSearchData.Rows[0][20]);
              annualBegInv = Convert.ToInt32(cs.dbSearchData.Rows[0][21]);
                allowDeletion = Convert.ToInt32(cs.dbSearchData.Rows[0][22]);
              customerManagement = Convert.ToInt32(cs.dbSearchData.Rows[0][23]);
                customerRegistration = Convert.ToInt32(cs.dbSearchData.Rows[0][24]);
                discountList = Convert.ToInt32(cs.dbSearchData.Rows[0][25]);
               setDiscount = Convert.ToInt32(cs.dbSearchData.Rows[0][26]);
                transactionSummaryReport = Convert.ToInt32(cs.dbSearchData.Rows[0][27]);
                productMasterlist = Convert.ToInt32(cs.dbSearchData.Rows[0][28]);
                readingTrail = Convert.ToInt32(cs.dbSearchData.Rows[0][29]);
                salesbook = Convert.ToInt32(cs.dbSearchData.Rows[0][30]);
                posMaintenance = Convert.ToInt32(cs.dbSearchData.Rows[0][31]);
                initializeProduct_salesInfo = Convert.ToInt32(cs.dbSearchData.Rows[0][32]);
                housekeeping = Convert.ToInt32(cs.dbSearchData.Rows[0][33]);
                dailyChangeFund = Convert.ToInt32(cs.dbSearchData.Rows[0][34]);

            }
            else
            {
                systemMaintenance = 0;
                posSetup = 0;
              systemUser = 0;
              productMenu = 0;
              productMaster = 0;
               productCategory = 0;
                 productUom = 0;
                productInventory = 0;
                stockin = 0;
                stockout = 0;
               inquiry = 0;
               transactionList = 0;
              reports = 0;
               inventoryReport = 0;
              openPos = 0;
              dbConfig = 0;
                restoreDb = 0;
                backupDb = 0;
               annualBegInv = 0;
               allowDeletion = 0;
                customerManagement = 0;
                customerRegistration = 0;
               discountList = 0;
                setDiscount = 0;
                 transactionSummaryReport = 0;
                productMasterlist = 0;
                readingTrail = 0;
                salesbook = 0;
                posMaintenance = 0;
                initializeProduct_salesInfo = 0;
                housekeeping = 0;
                dailyChangeFund = 0;
            }
            loadAccess();
          
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadAccessForm();
        }

        private void frmAccessForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckCommand();
        }
    }
}
