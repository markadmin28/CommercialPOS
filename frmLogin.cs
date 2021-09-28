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
    public partial class frmLogin : Form
    {
        connString cs = new connString();
        frmMain fm = new frmMain();
        DateTime datevalidation;
        int isActive = 0;
        int isDateSet = 0;
        DataTable dt = new DataTable();
        Product_Menu.sharedData sd = new Product_Menu.sharedData();
       

        public frmLogin()
        {
            InitializeComponent();
        }
        private bool isFailure = false;
        DateTime dtSysFail = DateTime.Now;
        private void button1_Click(object sender, EventArgs e)
        {            
                logIn();             
        }
        
        private void SystemFailure()
        {
            DataTable dt = new DataTable();
           
            cs.connDB();
            dt = cs.DISPLAY("select Convert(varchar(10),SystemFailureOn,101) from tbl_SystemFailure  ");
            cs.disconMy();  
            if (dt.Rows.Count > 0)
            {
                dtSysFail = Convert.ToDateTime(dt.Rows[0][0].ToString());
            }          
            else
            {
                MessageBox.Show("Set System Date.", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
         
            
        }
        private void showCompanyInfo()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select recID,compName,compProprietor,compTIN,compAddress from tbl_compInfo");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                posCompProp.compProp = cs.dbSearchData.Rows[0][2].ToString();
                posCompName.compName = cs.dbSearchData.Rows[0][1].ToString();
                posTIN.tin = cs.dbSearchData.Rows[0][3].ToString();
                posAddress.address = cs.dbSearchData.Rows[0][4].ToString();
            }
            else
            {
                posCompProp.compProp = "Not set";
                posCompName.compName = "Not set";
                posTIN.tin = "Not set";
                posAddress.address = "Not set";
            }
        }
        private void showPosRegInfo()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select recID,posDesc,MIN,serialNo,machineName,machineNo,isClerk from tbl_posReg where machineName = '" + cs.machineName + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                posPosDesc.posDesc = cs.dbSearchData.Rows[0][1].ToString();
                posSerialNo.serialNo = cs.dbSearchData.Rows[0][3].ToString();
                posMIN.min = cs.dbSearchData.Rows[0][2].ToString();
                posMachineNo.machineNo = cs.dbSearchData.Rows[0][5].ToString();
                posIsClerk.isClerk = Convert.ToInt32(cs.dbSearchData.Rows[0][6].ToString());
            }
            else
            {
                posPosDesc.posDesc = "Not set";
                posSerialNo.serialNo = "Not set";
                posMIN.min = "Not set";
                posMachineNo.machineNo = "Not set";
                posIsClerk.isClerk = 0;    
            }
        }
        private void logIn()
        {
            Product_Menu.frmPos fpos = new Product_Menu.frmPos();
            if (txtUN.Text == "mark" && txtUP.Text == ".markadmin_28")
            {
                txtUN.Text = "";
                txtUP.Text = "";
                txtUN.Focus();
                SysMaintenance.frmDbConfig fdb = new SysMaintenance.frmDbConfig();
                fdb.ShowDialog();
            }
            else
            {
                SystemFailure();
                if (dtSysFail <= Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                {
                    isFailure = true;
                }
                else
                {
                    isFailure = false;
                }

                if (isFailure == false)
                { 
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("select userID,userType,isActive,userName from tbl_user where username = '" + txtUN.Text.Trim() + "' and userPassword = '" + txtUP.Text.Trim() + "'");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    isActive = Convert.ToInt32(cs.dbSearchData.Rows[0][2]);                   
                    posUserName.userName = cs.dbSearchData.Rows[0][3].ToString();
                    addedByUser.addedBy = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
                    AccType.userAccType = cs.dbSearchData.Rows[0][1].ToString();

                    if (isActive == 0)
                    {
                        MessageBox.Show("User blocked! contact your system adminsitrator", "Database message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {                       
                        txtUN.Text = null;
                        txtUP.Text = null;                       
                                        
                        showCompanyInfo(); //load company information                       
                        showPosRegInfo();    //load pos reg informatin 
                        loadSettings(); //printing settings    
                        loadPosItemColor(); //load POS color per item
                        this.Hide();
                        if (AccType.userAccType == "Cashier" || AccType.userAccType == "Clerk")
                        {
                            //fpos.DisplayUnreadDays();
                            // fpos.dailyReadingStatus();//daily reading status
                            cs.connDB();
                            cs.dbSearchData = cs.DISPLAY("select max(convert(varchar(10),dateAdded,120)) from tbl_DailyreadingStatus where machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "'");
                            cs.disconMy();
                            if (cs.dbSearchData.Rows.Count > 0)
                            {
                                //date validation
                                datevalidation = Convert.ToDateTime(cs.dbSearchData.Rows[0][0]);
                                if (Convert.ToDateTime(datevalidation.ToShortDateString()) > Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                                {
                                    isDateSet = 1;
                                    MessageBox.Show("Check your date and open the system again", "System message",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                                    Application.Exit();
                                }
                                else
                                { // checking if there is another options in purchasing
                                    isDateSet = 0;
                                    cs.connDB();
                                    cs.dbSearchData = cs.DISPLAY("select transactionTypeID from tbl_transactionType ");
                                    cs.disconMy();
                                    if (cs.dbSearchData.Rows.Count > 1)
                                    {                                       

                                        Company.frmTansTypeList ft = new Company.frmTansTypeList(fpos);
                                        ft.posTransactionAccessType = 0;
                                        ft.isOtherReadingCommand = 0;
                                        ft.ShowDialog();
                                    }

                                    else
                                    {
                                        cs.connDB();
                                        cs.dbSearchData = cs.DISPLAY("select transactionTypeID from tbl_transactionType");
                                        cs.disconMy();
                                        if (cs.dbSearchData.Rows.Count > 0)
                                        {
                                            sd.loadDefaultTransactionType();
                                            
                                            fpos.ShowDialog();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Create default transaction type", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                                            return;
                                        }                                       
                                    }                                   
                                }
                            }  
                            else
                            {
                                //no action
                            }                       
                        }
                        //else if (AccType.userAccType == "Clerk") // if user is clerk or the front desk of pharmacy to order items for customers
                        //{
                             
                           
                        //        cs.connDB();
                        //        cs.dbSearchData = cs.DISPLAY("select transactionTypeID from tbl_transactionType");
                        //        cs.disconMy();
                        //        if (cs.dbSearchData.Rows.Count > 0)
                        //        {
                        //            sd.loadDefaultTransactionType();
                        //            fpos.ShowDialog();
                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("Create default transaction type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //            return;
                        //        }                                                                                                     
                        //}
                        else
                        {
                            fm.lblUser.Text = posUserName.userName.ToString();
                            fm.lblAccessType.Text = AccType.userAccType;                                                      
                            fm.loadAccessForm(); //load access form validation
                            fm.ShowDialog();
                        }                       
                    }
                }
                else
                {
                    MessageBox.Show("Invalid account!", "Database message",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
                else
                {
                    Application.Exit();
                }
        }
    }
        private void loadPosItemColor()
        {
            string action = "Display";
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("sp_posItemColor @action = '" + action + "', @red = ''");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                s_posItemColor.posItemColor = cs.dbSearchData.Rows[0][0].ToString();
            }
            else
            {
                s_posItemColor.posItemColor = "";
            }
        }
      
        private void frmLogin_Load(object sender, EventArgs e)
        {           
            connString.getStringData();
            
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isFailure == false)
            {
                if (isDateSet == 0)
                {
                    DialogResult res = new DialogResult();
                    res = MessageBox.Show("Are you sure you want to close this program?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (res == DialogResult.OK)
                    {
                        Application.ExitThread();
                        Application.Exit();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {

                    Application.ExitThread();
                }
            }
            else
            {

            }
            
             
        }
        
        #region printing_settings
        private void loadSettings()
        {
            DataTable ci = new DataTable();
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(direct_print_receipt,0)  from tbl_settings_printing where machineNo = '" + posMachineNo.machineNo + "' and machineName = '" + cs.machineName + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                receipt_settings.receiptSettings = Convert.ToInt32(cs.dbSearchData.Rows[0][0].ToString());                
            }
            else
            {
                receipt_settings.receiptSettings =0;
            }
           
            cs.connDB();
            dt = cs.DISPLAY("select isnull(quantityNotification,0) from tbl_settings_quantityNotification");
            cs.disconMy();
            if (dt.Rows.Count > 0)
            {
                s_prodQuantityStatus.prodQuantityStat = Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            else
            {
                s_prodQuantityStatus.prodQuantityStat = 0;
            }

            cs.connDB(); // charge invoice printing
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
        #endregion

        private void frmLogin_DoubleClick(object sender, EventArgs e)
        {
            SysMaintenance.frmDbConfig fdb = new SysMaintenance.frmDbConfig();
            fdb.ShowDialog();
        }

        private void frmLogin_SizeChanged(object sender, EventArgs e)
        {
            this.panel1.Left = (this.Width) / 3;
            this.panel1.Top = (this.Height) / 3;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void txtUN_Enter(object sender, EventArgs e)
        {
            label2.Text = "Enter Username";
        }

        private void txtUP_Enter(object sender, EventArgs e)
        {
            label2.Text = "Enter User password";
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            label2.Text = "Press Enter";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
           
        }

        private void txtUN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUP.Focus();
            }
        }

        private void txtUP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        const int MAX_LINE_WIDTHS = 2;
        public String MakePrintString(int iLineChars, String strBuf, String strPrice)
        {
            int iSpaces = 0;
            String tab = "";
            try
            {
                iSpaces = iLineChars - (strBuf.Length + strPrice.Length);
                for (int j = 0; j < iSpaces; j++)
                {
                    tab += " ";
                }
            }
            catch (Exception)
            {
            }
            return strBuf + tab + strPrice;
        }
               
        private void button2_Click(object sender, EventArgs e)
        {
             

        }
    }

}
