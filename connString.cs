using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace POS
{
    class connString
    {
        public static string ServerMySQL;
        public static string UserNameMySQL;
        public static string PwdMySQL;
        public static string DBNameMySQL;
        public string insertData;
        public string updateData;
        public string deleteData;
        public DataTable dbSearchData = new DataTable();
        public SqlConnection cn = new SqlConnection();
        SqlCommand COMM = new SqlCommand();
        public string machineName = Environment.MachineName;
        public int isSuspended = 0;

        public void connDB()
        {
            cn.Close();
            try
            {
                cn.ConnectionString = "Server = '" + ServerMySQL + "';   " + "Database = '" + DBNameMySQL + "'; " + "user id = '" + UserNameMySQL + "'; " + "password = '" + PwdMySQL + "'";
                cn.Open();
            }
            catch
            {
                Interaction.MsgBox("CAN'T CONNECT TO SERVER", MsgBoxStyle.Critical, "System message");
                return;
            }
        }
        public void IUD(string QUERY)
        {
            COMM = new SqlCommand(QUERY, cn);
            cn.Close();
            cn.Open();

            COMM.ExecuteNonQuery();
            cn.Close();
        }
        public void disconMy()
        {
            cn.Close();
            cn.Dispose();
        }
        public DataTable DISPLAY(string QUERY)
        {
            COMM = new SqlCommand(QUERY, cn);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(COMM);
            adp.Fill(dt);
            return dt;
        }
        public static void getStringData()
        {
            string AppName = Application.ProductName;
            try
            {
                DBNameMySQL = Interaction.GetSetting(AppName, "DBSection", "DB_Name", "temp");
                ServerMySQL = Interaction.GetSetting(AppName, "DBSection", "DB_IP", "temp");
                UserNameMySQL = Interaction.GetSetting(AppName, "DBSection", "DB_User", "temp");
                PwdMySQL = Interaction.GetSetting(AppName, "DBSection", "DB_Password", "temp");
            }
            catch
            {
                Interaction.MsgBox("System registry was not established", MsgBoxStyle.Critical);
            }

        }
        public static void SaveData()
        {
            string AppName = Application.ProductName;
            Interaction.SaveSetting(AppName, "DBSection", "DB_Name", DBNameMySQL);
            Interaction.SaveSetting(AppName, "DBSection", "DB_IP", ServerMySQL);
            Interaction.SaveSetting(AppName, "DBSection", "DB_User", UserNameMySQL);
            Interaction.SaveSetting(AppName, "DBSection", "DB_Password", PwdMySQL);
            Interaction.MsgBox("Database connection saved.", MsgBoxStyle.Information);
        }

    }
    static class addedByUser
    {
        private static decimal addedByUserID = 0;
        public static decimal addedBy
        {
            get { return addedByUserID; }
            set { addedByUserID = value; }
        }

    }
    static class AccType
    {
        private static string _userAccType = "";
        public static string userAccType
        {
            get { return _userAccType; }
            set { _userAccType = value; }
        }
    }
    static class posUserName
    {
        private static string _posUserName = "Mark Ryan";
        public static string userName
        {
            get { return _posUserName; }
            set { _posUserName = value; }
        }

    }
    #region for Receipt    
    static class posCompProp
    {
        private static string _compProp = "";
        public static string compProp
        {
            get { return _compProp; }
            set { _compProp = value; }
        }
    }
    static class posCompName
    {
        private static string _compName = "";
        public static string compName
        {
            get { return _compName; }
            set { _compName = value; }
        }
    }
    static class posTIN
    {
        private static string _tin = "";
        public static string tin
        {
            get { return _tin; }
            set { _tin = value; }
        }
    }
    static class posAddress
    {
        private static string _address = "";
        public static string address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
    static class posPosDesc
    {
        private static string _posDesc = "";
        public static string posDesc
        {
            get { return _posDesc; }
            set { _posDesc = value; }
        }
    }
    static class posSerialNo
    {
        private static string _serialNo = "";
        public static string serialNo
        {
            get { return _serialNo; }
            set { _serialNo = value; }
        }
    }
    static class posMIN
    {
        private static string _min = "";
        public static string min
        {
            get { return _min; }
            set { _min = value; }
        }
    }
    static class posMachineNo
    {
        private static string _machineNo = "";
        public static string machineNo
        {
            get { return _machineNo; }
            set { _machineNo = value; }
        }
    }
    static class posIsClerk
    {
        private static int _isClerk = 0;
        public static int isClerk
        {
            get { return _isClerk; }
            set { _isClerk = value; }
        }
    }
    #endregion
    #region settings
    static class receipt_settings
    {
        private static int _receiptSettings = 0;
        public static int receiptSettings
        {
            get { return _receiptSettings; }
            set { _receiptSettings = value; }
        }
    }
    #endregion
    #region access form
    static class s_systemMaintenance
    {
        private static int _systemMaintenance = 0;
        public static int systemMaintenance
        {
            get { return _systemMaintenance; }
            set { _systemMaintenance = value; }
        }
    }
    static class s_posSetup
    {
        private static int _posSetup = 0;
        public static int posSetup
        {
            get { return _posSetup; }
            set { _posSetup = value; }
        }
    }
    static class s_systemUser
    {
        private static int _systemUser = 0;
        public static int systemUser
        {
            get { return _systemUser; }
            set { _systemUser = value; }
        }
    }
    static class s_productMenu
    {
        private static int _productMenu = 0;
        public static int productMenu
        {
            get { return _productMenu; }
            set { _productMenu = value; }
        }
    }
    static class s_productMaster
    {
        private static int _productMaster = 0;
        public static int productMaster
        {
            get { return _productMaster; }
            set { _productMaster = value; }
        }
    }
    static class s_productCategory
    {
        private static int _productCategory = 0;
        public static int productCategory
        {
            get { return _productCategory; }
            set { _productCategory = value; }
        }
    }
    static class s_productUom
    {
        private static int _productUom = 0;
        public static int productUom
        {
            get { return _productUom; }
            set { _productUom = value; }
        }
    }
    static class s_productInventory
    {
        private static int _productInventory = 0;
        public static int productInventory
        {
            get { return _productInventory; }
            set { _productInventory = value; }
        }
    }
    static class s_stockIn
    {
        private static int _stockin = 0;
        public static int stockin
        {
            get { return _stockin; }
            set { _stockin = value; }
        }

    }
    static class s_stockout
    {
        private static int _stockout = 0;
        public static int stockout
        {
            get { return _stockout; }
            set { _stockout = value; }
        }
    }
    static class s_inquiry
    {
        private static int _inquiry = 0;
        public static int inquiry
        {
            get { return _inquiry; }
            set { _inquiry = value; }
        }
    }
    static class s_transactionList
    {
        private static int _transactionList = 0;
        public static int transactionList
        {
            get { return _transactionList; }
            set { _transactionList = value; }
        }
    }
    static class s_reports
    {
        private static int _reports = 0;
        public static int reports
        {
            get { return _reports; }
            set { _reports = value; }
        }
    }
    static class s_inventoryReport
    {
        private static int _inventoryReport = 0;
        public static int inventoryReport
        {
            get { return _inventoryReport; }
            set { _inventoryReport = value; }
        }
    }
    static class s_openPos
    {
        private static int _openPos = 0;
        public static int openPos
        {
            get { return _openPos; }
            set { _openPos = value; }
        }
    }
    static class s_dbConfig
    {
        private static int _dbConfig = 0;
        public static int dbConfig
        {
            get { return _dbConfig; }
            set { _dbConfig = value; }
        }
    }
    static class s_restoreDb
    {
        private static int _restoreDb = 0;
        public static int restoreDb
        {
            get { return _restoreDb; }
            set { _restoreDb = value; }
        }
    }
    static class s_backupDb
    {
        private static int _backupDb = 0;
        public static int backupDb
        {
            get { return _backupDb; }
            set { _backupDb = value; }
        }
    }
    static class s_annualBegInv
    {
        private static int _annualBegInv = 0;
        public static int annualBegInv
        {
            get { return _annualBegInv; }
            set { _annualBegInv = value; }
        }
    }
    static class s_allowDeletion
    {
        private static int _allowDeletion = 0;
        public static int allowDeletion
        {
            get { return _allowDeletion; }
            set { _allowDeletion = value; }
        }
    }
    static class s_prodQuantityStatus
    {
        private static decimal _prodQuantityStat;
        public static decimal prodQuantityStat
        {
            get { return _prodQuantityStat; }
            set { _prodQuantityStat = value; }
        }
    }
    static class s_chargeInvoicePrinting
    {
        private static int _chargeinvoice = 0;
        public static int chargeInvoice
        {
            get { return _chargeinvoice; }
            set { _chargeinvoice = value; }
        }
    }
    static class s_customerManagement
    {
        private static int _customerManagement = 0;
        public static int customerManagement
        {
            get { return _customerManagement; }
            set { _customerManagement = value; }
        }
    }
    static class s_customerRegistration
    {
        private static int _customerRegistration = 0;
        public static int customerRegistration
        {
            get { return _customerRegistration; }
            set { _customerRegistration = value; }
        }
    }
    static class s_discountList
    {
        private static int _discountList = 0;
        public static int discountList
        {
            get { return _discountList; }
            set { _discountList = value; }
        }
    }
    static class s_setDiscount
    {
        private static int _setDiscount = 0;
        public static int setDiscount
        {
            get { return _setDiscount; }
            set { _setDiscount = value; }
        }
    }
    static class s_transactionType
    {
        private static decimal _transactionType = 0;
        public static decimal transactionType
        {
            get { return _transactionType; }
            set { _transactionType = value; }
        }
    }
    static class s_transactionTypeDesc
    {
        private static string _transactionTypeDesc = "";
        public static string transactionTypeDesc
        {
            get { return _transactionTypeDesc; }
            set { _transactionTypeDesc = value; }
        }
    }
    static class s_transactionSummaryReport
    {
        private static int _transactionSummaryReport = 0;
        public static int transactionSummaryReport
        {
            get { return _transactionSummaryReport; }
            set { _transactionSummaryReport = value; }
        }
    }
    static class s_productMasterlist
    {
        private static int _productMasterlist = 0;
        public static int productMasterlist
        {
            get { return _productMasterlist; }
            set { _productMasterlist = value; }
        }
    }
    static class s_readingTrail
    {
        private static int _readingTrail = 0;
        public static int readingTrail
        {
            get { return _readingTrail; }
            set { _readingTrail = value; }
        }
    }
    static class s_salesbook
    {
        private static int _salesbook = 0;
        public static int salesbook
        {
            get { return _salesbook; }
            set { _salesbook = value; }
        }
    }
    static class s_posMaintenance
    {
        private static int _posMaintenance = 0;
        public static int posMaintenance
        {
            get { return _posMaintenance; }
            set { _posMaintenance = value; }
        }
    }
    static class s_initializeProduct_salesInfo
    {
        private static int _initializeProduct_salesInfo = 0;
        public static int initializeProduct_salesInfo
        {
            get { return _initializeProduct_salesInfo; }
            set { _initializeProduct_salesInfo = value; }
        }
    }
    static class s_housekeeping
    {
        private static int _housekeeping = 0;
        public static int housekeeping
        {
            get { return _housekeeping; }
            set { _housekeeping = value; }
        }
    }
    static class s_dailyChangeFund
    {
        private static int _dailyChangeFund = 0;
        public static int dailyChangeFund
        {
            get { return _dailyChangeFund; }
            set { _dailyChangeFund = value; }
        }

    }
 
    #endregion
    #region POS color per item
    static class s_posItemColor
    {
        private static string _posItemColor = "";
        public static string posItemColor
        {
            get { return _posItemColor; }
            set { _posItemColor = value; }
        }
    }
    #endregion

}
