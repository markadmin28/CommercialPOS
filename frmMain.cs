using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class frmMain : Form
    {
         connString cs = new connString();
       
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyy");
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainTimer.Stop();
             this.Dispose();
            frmLogin fl = new frmLogin();
            fl.Show(); 
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            User.frmUser fUser = new User.frmUser();
            fUser.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Product_Menu.frmProductMenu fpm = new Product_Menu.frmProductMenu();
            fpm.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Inventory.frmInventoryMenu fi = new Inventory.frmInventoryMenu();
            fi.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Reports.frmReportMenu fm = new Reports.frmReportMenu();
            fm.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

            frmTransactionsMenu ft = new frmTransactionsMenu();
            ft.ShowDialog();
              
        }

        private void ToolStripButton7_Click(object sender, EventArgs e)
        {
            Inquiry.frmInquiryMenu fi = new Inquiry.frmInquiryMenu();
            fi.ShowDialog();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pOSSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Company.frmCompanyMenu fcm = new Company.frmCompanyMenu();
            fcm.ShowDialog();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
        #region access form section
        public void loadAccessForm()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("settings_loadAccessForm @userType = '" + AccType.userAccType + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                s_systemMaintenance.systemMaintenance = Convert.ToInt32(cs.dbSearchData.Rows[0][1]);
                s_posSetup.posSetup = Convert.ToInt32(cs.dbSearchData.Rows[0][2]);
                s_systemUser.systemUser = Convert.ToInt32(cs.dbSearchData.Rows[0][3]);
                s_productMenu.productMenu = Convert.ToInt32(cs.dbSearchData.Rows[0][4]);
                s_productMaster.productMaster = Convert.ToInt32(cs.dbSearchData.Rows[0][5]);
                s_productCategory.productCategory = Convert.ToInt32(cs.dbSearchData.Rows[0][6]);
                s_productUom.productUom = Convert.ToInt32(cs.dbSearchData.Rows[0][7]);
                s_productInventory.productInventory = Convert.ToInt32(cs.dbSearchData.Rows[0][8]);
                s_stockIn.stockin = Convert.ToInt32(cs.dbSearchData.Rows[0][9]);
                s_stockout.stockout = Convert.ToInt32(cs.dbSearchData.Rows[0][10]);
                s_inquiry.inquiry = Convert.ToInt32(cs.dbSearchData.Rows[0][11]);
                s_transactionList.transactionList = Convert.ToInt32(cs.dbSearchData.Rows[0][12]);
                s_reports.reports = Convert.ToInt32(cs.dbSearchData.Rows[0][13]);
                s_inventoryReport.inventoryReport = Convert.ToInt32(cs.dbSearchData.Rows[0][14]);
                s_openPos.openPos = Convert.ToInt32(cs.dbSearchData.Rows[0][15]);
                s_dbConfig.dbConfig = Convert.ToInt32(cs.dbSearchData.Rows[0][18]);
                s_restoreDb.restoreDb = Convert.ToInt32(cs.dbSearchData.Rows[0][19]);
                s_backupDb.backupDb = Convert.ToInt32(cs.dbSearchData.Rows[0][20]);
                s_annualBegInv.annualBegInv = Convert.ToInt32(cs.dbSearchData.Rows[0][21]);
                s_allowDeletion.allowDeletion = Convert.ToInt32(cs.dbSearchData.Rows[0][22]);
                s_customerManagement.customerManagement = Convert.ToInt32(cs.dbSearchData.Rows[0][23]);
                s_customerRegistration.customerRegistration = Convert.ToInt32(cs.dbSearchData.Rows[0][24]);
                s_discountList.discountList= Convert.ToInt32(cs.dbSearchData.Rows[0][25]);
                s_setDiscount.setDiscount = Convert.ToInt32(cs.dbSearchData.Rows[0][26]);
                s_transactionSummaryReport.transactionSummaryReport = Convert.ToInt32(cs.dbSearchData.Rows[0][27]);
                s_posMaintenance.posMaintenance= Convert.ToInt32(cs.dbSearchData.Rows[0][31]);
                s_housekeeping.housekeeping = Convert.ToInt32(cs.dbSearchData.Rows[0][33]);
                s_productMasterlist.productMasterlist = Convert.ToInt32(cs.dbSearchData.Rows[0][28]);
                s_readingTrail.readingTrail = Convert.ToInt32(cs.dbSearchData.Rows[0][29]);
                s_salesbook.salesbook = Convert.ToInt32(cs.dbSearchData.Rows[0][30]);
                s_initializeProduct_salesInfo.initializeProduct_salesInfo = Convert.ToInt32(cs.dbSearchData.Rows[0][32]);
                s_dailyChangeFund.dailyChangeFund = Convert.ToInt32(cs.dbSearchData.Rows[0][34]);
            }
            else
            {
                s_systemMaintenance.systemMaintenance = 0;
                s_posSetup.posSetup = 0;
                s_systemUser.systemUser = 0;
                s_productMenu.productMenu = 0;
                s_productMaster.productMaster = 0;
                s_productCategory.productCategory = 0;
                s_productUom.productUom = 0;
                s_productInventory.productInventory = 0;
                s_stockIn.stockin = 0;
                s_stockout.stockout = 0;
                s_inquiry.inquiry = 0;
                s_transactionList.transactionList = 0;
                s_reports.reports = 0;
                s_inventoryReport.inventoryReport = 0;
                s_openPos.openPos = 0;
                s_dbConfig.dbConfig = 0;
                s_restoreDb.restoreDb = 0;
                s_backupDb.backupDb = 0;
                s_annualBegInv.annualBegInv = 0;
                s_allowDeletion.allowDeletion = 0;
                s_customerManagement.customerManagement = 0;
                s_customerRegistration.customerRegistration = 0;
                s_discountList.discountList = 0;
                s_setDiscount.setDiscount = 0;
                s_transactionSummaryReport.transactionSummaryReport = 0;
                s_posMaintenance.posMaintenance= 0;
                s_housekeeping.housekeeping = 0;
                s_productMasterlist.productMasterlist = 0;
                s_readingTrail.readingTrail = 0;
                s_salesbook.salesbook =0;
                s_initializeProduct_salesInfo.initializeProduct_salesInfo = 0;
                s_dailyChangeFund.dailyChangeFund = 0;
            }
            loadAccess();


        }
        private void loadAccess()
        {                        
            if (s_systemMaintenance.systemMaintenance == 1)
            {
               sSystemMaintenance.Enabled = true;
            }
            else
            {
                sSystemMaintenance.Enabled = false;
            }
            if (s_posSetup.posSetup == 1)
            {
                sPosSetup.Enabled= true;
            }
            else
            {
                sPosSetup.Enabled = false;
            }
            if (s_systemUser.systemUser == 1)
            {
                tsSystemUser.Enabled = true;
                f1.Enabled = true;
            }
            else
            {
                tsSystemUser.Enabled = false;
                f1.Enabled = false;
            }
            if (s_productMenu.productMenu == 1)
            {
                tsProductMenu.Enabled = true;
                f3.Enabled = true;
            }
            else
            {
                tsProductMenu.Enabled = false;
                f3.Enabled = false;
            }                                     

            if (s_productInventory.productInventory == 1)
            {
                tsProductInventory.Enabled = true;
                f4.Enabled = true;
            }
            else
            {
                tsProductInventory.Enabled = false;
                f4.Enabled = false;
            }
            
            
            if (s_inquiry.inquiry == 1)
            {
                tsInquiry.Enabled = true;
                f5.Enabled = true;
            }
            else
            {
                tsInquiry.Enabled = false;
                f5.Enabled = false;
            }
             
            if (s_reports.reports == 1)
            {
                tsReports.Enabled = true;
                f6.Enabled = true;
            }
            else
            {
                tsReports.Enabled = false;
                f6.Enabled = false;
            }
                         
            if (s_openPos.openPos == 1)
            {
                tsOpenPos.Enabled = true;
                f7.Enabled = true;
            }
            else
            {
                tsOpenPos.Enabled = false;
                f7.Enabled = false;
            }

            if (s_customerManagement.customerManagement ==1)
            {
                tCustomer.Enabled = true;
                f2.Enabled = true;
            }
            else
            {
                tCustomer.Enabled = false;
                f2.Enabled = false;
            }
            if(s_posMaintenance.posMaintenance == 1)
            {
                tsPosMaintenance.Enabled = true;
                f8.Enabled = true;
            }
            else
            {
                tsPosMaintenance.Enabled = false;
                f8.Enabled = false;
            }
            if (s_housekeeping.housekeeping ==1)
            {
                tsHousekeeping.Enabled = true;
                f9.Enabled = true;
            }
            else
            {
                tsHousekeeping.Enabled = false;
                f9.Enabled = false;
            }
        }
        #endregion

        private void sSystemMaintenance_Click(object sender, EventArgs e)
        {
            SysMaintenance.frmSysMaintenance fsm = new SysMaintenance.frmSysMaintenance();
            fsm.ShowDialog();
        }

        private void tCustomer_Click(object sender, EventArgs e)
        {
            CustomerMgt.frmCustomerMenu fc = new CustomerMgt.frmCustomerMenu();
            fc.ShowDialog();
        }

        private void MainMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                tsSystemUser.PerformClick();
            }
            if (e.KeyCode == Keys.F2)
            {
                tCustomer.PerformClick();
            }
            if (e.KeyCode == Keys.F3)
            {
                tsProductMenu.PerformClick();
            }
            if (e.KeyCode == Keys.F4)
            {
                tsProductInventory.PerformClick();
            }
            if (e.KeyCode == Keys.F5)
            {
                tsInquiry.PerformClick();
            }
            if (e.KeyCode == Keys.F6)
            {
                tsReports.PerformClick();
            }
            if (e.KeyCode == Keys.F7)
            {
                tsOpenPos.PerformClick();
            }
            if (e.KeyCode == Keys.F8)
            {
                tsPosMaintenance.PerformClick();
            }
            if (e.KeyCode == Keys.F9)
            {
                tsHousekeeping.PerformClick();
            }
        }

        private void tsPosMaintenance_Click(object sender, EventArgs e)
        {
            POSMaintenance.frmPosMaintenanceValidation fpm = new POSMaintenance.frmPosMaintenanceValidation();
            fpm.ShowDialog();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Housekeeping.frmHousekeepingMenu fhm = new Housekeeping.frmHousekeepingMenu();
            fhm.ShowDialog();
        }

        private void systemUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsSystemUser.PerformClick();
        }

        private void customerManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tCustomer.PerformClick();
        }

        private void f3ProductMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsProductMenu.PerformClick();
        }

        private void f4InquiryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsProductInventory.PerformClick();
        }

        private void f5InquiryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsInquiry.PerformClick();
        }

        private void f6ReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsReports.PerformClick();
        }

        private void f7OpenPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsOpenPos.PerformClick();   
        }

        private void f8POSMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsPosMaintenance.PerformClick();
        }

        private void f9HousekeepingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsHousekeeping.PerformClick();
        }
    }
}
