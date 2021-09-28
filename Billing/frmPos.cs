using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Windows.Forms;
using Microsoft.PointOfService;
using System.Threading;

namespace POS.Product_Menu
{
    public partial class frmPos : Form
    {
        #region Variables
        connString cs = new connString();

        //printer
        PosPrinter m_Printer = null;

        string _action = "Insert";
        decimal transactionIDPI = 0;
        decimal transactionID = 0;
        decimal prodQty = 0;
        string productID = "";
        string productDesc = "";
        decimal prodSellingPrice = 0;
        decimal prodDiscPerItem = 0;
        public int suspendNo = 0;
        string ORNO = "";
        string itemCd = "";
        decimal PriceOptID = 0;

        //for prodDailySalesAmt         
        double VatSale = 0;
        double totalVat = 0;
        double vatExSale = 0;
        double totalSale = 0;
        double grossPayable = 0;
        double totalItems = 0;
        double discountAmt = 0;

        //
        decimal readingID = 0;
        int isReaded = 0;

        //product quantity status
        public decimal prodQtyStat = 0;
        decimal prodTempQtyStat = 0;

        //customer details
        public string customerName = "";
        public decimal discountID = 0;
        public string cusDiscID = "";

        public int loadPrinterStatus = 0;
        public int isReceiptHeaderPrinted = 0;
        int isReceiptReprint = 0;
        //----------------------
        //media report
        double mediaReportAmt = 0;
        double prevNrgt = 0;
        double nrgt = 0;
        double cashFundAmt = 0;
        decimal NRGTID = 0;
        string actn = "";

        //for passing of data to cashier ------------
        DataTable passDataGenId = new DataTable();
        decimal passDataId = 0;
        DataTable passDataInfoGenCusNo = new DataTable();
        int cusNo = 0;
        public decimal passDataOrderId = 0;
        //
        //POS Setup
        DataTable dtDupItems = new DataTable();
        int isAllowDupItems = 0;

        //cashier product transaction report
        public string prodTransProdId = "";
        public string prodTransProdDesc = "";
        #endregion


        public frmPos()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (txtItemCode.Text == "=")
            {
                if (dgw.Rows.Count > 0)
                {
                    if (AccType.userAccType == "Cashier")
                    {
                        if (lblTransType.Text == "Charge Invoice")
                        {
                            Billing.frmChrgeInvoice fc = new Billing.frmChrgeInvoice(this);
                            fc.Owner = this;
                            fc.totalCash = Convert.ToDouble(txtTotalPayable_.Text);
                            fc.totalChange = Convert.ToDouble(txtTotalPayable_.Text);
                            fc.ShowDialog();
                        }
                        else // if sales or dr
                        {
                            Billing.frmPosPayment fpp = new Billing.frmPosPayment(this);
                            fpp.txtDueAmt.Text = txtTotalPayable_.Text;
                            fpp.ShowDialog();
                        }

                    }
                    else if (AccType.userAccType == "Clerk")
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to pass this data to cashier?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            if (passDataId == 0)
                            {
                                PassDataGenId();
                            }
                            else
                            {
                                //no action | updating data that passed to the cashier
                            }
                            PassDataToCashier();
                        }
                        else
                        {
                            txtItemCode.Text = "";
                            return;
                        }
                    }

                }
                else
                {
                    string msg = "";
                    if (AccType.userAccType == "Cashier")
                    {
                        msg = "Payment invalid!";
                    }
                    else if (AccType.userAccType == "Clerk")
                    {
                        msg = "Check your order entry!";
                    }
                    MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtItemCode.Text = "";
                    return;
                }

            }
            else
            {
                //no action
            }
        }
        private void PassDataToCashier()
        {
            string dltTempData = "";
            string dltCusDetail = "";
            string passDataToCashier;
            decimal passId = 0;
            decimal qty = 0;
            string pid = "";
            decimal uomId = 0;
            decimal prodDiscount = 0;

            for (int i = 0; i <= dgw.Rows.Count - 1; i++)
            {
                passId = passDataId;
                qty = Convert.ToDecimal(dgw.Rows[i].Cells[0].Value);
                pid = dgw.Rows[i].Cells[6].Value.ToString();
                uomId = Convert.ToDecimal(dgw.Rows[i].Cells[9].Value);
                if (dgw.Rows[i].Cells[4].Value.ToString() == "")
                {
                    prodDiscount = 0;
                }
                else
                {
                    prodDiscount = Convert.ToDecimal(dgw.Rows[i].Cells[4].Value);
                }
                cs.connDB();
                passDataToCashier = "sp_TempPassDataSave @passDataId = '" + passId + "',@prodQty = '" + qty + "',@prodId = '" + pid + "',@prodUomId = '" + uomId + "',@prodDiscount = '" + prodDiscount + "' ";
                cs.IUD(passDataToCashier);
                cs.disconMy();
            }
            cs.connDB();
            dltTempData = "delete from tbl_tempBilling where machineID = '" + cs.machineName + "' and isSuspended = '" + cs.isSuspended + "' and datediff(day,prodDateAdded,'" + DateTime.Now + "')=0";
            cs.IUD(dltTempData);
            cs.disconMy();

            cs.connDB();
            dltCusDetail = "delete tbl_tempBilling_note where machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "' and datediff(day,dateAdded,'" + DateTime.Now + "') =0 ";
            cs.IUD(dltCusDetail);
            cs.disconMy();

            PassDataInfo(); // finally saved the passdatainfo it is the parent record for the pass data details
            clearPosData();
            passDataOrderId = 0;
            lbNote.Items.Clear();
            customerName = "";
            MessageBox.Show("Press [Enter] for the next transaction", "Success message", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void PassDataInfo()
        {
            string dataSave = "";
            PassDataInfoGenCusNo(); // generate customer number when passing data to cashier
            cs.connDB();
            dataSave = "sp_TempPassDataInfoSave @passDataId = '" + passDataId + "', @addedBy = '" + addedByUser.addedBy + "', @dateAdded = '" + DateTime.Now + "', @machineName = '" + cs.machineName + "' , @transactionTypeId = '" + s_transactionType.transactionType + "' , @cusNo = '" + cusNo + "' , @cusName = '" + customerName + "'";
            cs.IUD(dataSave);
            cs.disconMy();

        }
        private void PassDataGenId()
        {
            cs.connDB();
            passDataGenId = cs.DISPLAY("sp_TempPassDataGenId");
            cs.disconMy();
            passDataId = Convert.ToDecimal(passDataGenId.Rows[0][0]);
        }
        private void PassDataInfoGenCusNo()
        {
            DateTime dt = DateTime.Now;
            cs.connDB();
            passDataInfoGenCusNo = cs.DISPLAY("sp_TempPassDataInfoGenCusNo @dateNow = '" + dt + "'");
            cs.disconMy();
            cusNo = Convert.ToInt32(passDataInfoGenCusNo.Rows[0][0]);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtItemCode.Text == "")
                {
                    Billing.frmPosProdSearch fpps = new Billing.frmPosProdSearch(this);
                    fpps.ShowDialog();
                }
                else
                {
                    if (lblTransType.Text == "Charge Invoice")
                    {
                        if (dgw.Rows.Count >= 9)
                        {
                            MessageBox.Show("Charge invoice limits only 9 Items", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            LoadProduct();
                        }
                    }
                    else
                    {
                        LoadProduct();
                    }

                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (txtItemCode.Text != "")
                {
                    txtItemCode.Text = null;
                }
                else
                {
                    //no action
                }
            }
            if (e.KeyCode == Keys.Up)
            {

                if (dgw.Rows.Count > 0)
                {
                    if (dgw.Rows.Count == 1)
                    {
                        dgw.CurrentRow.Selected = true;
                        dgw.Focus();
                        cursorTimer.Stop();
                    }
                    else
                    {
                        dgw.CurrentCell = dgw.Rows[dgw.Rows.Count - 1].Cells[0];
                        dgw.Focus();
                        cursorTimer.Stop();
                    }
                }
                else
                {
                    //no action
                }
            }
        }
        public bool isProdIdFinal ;
        private void LoadProduct()
        {
            DataTable dt = new DataTable();
            
           if (isProdIdFinal == true)
            {
                SearchProductInfo();
                isProdIdFinal = false;
            }
           else
            {
                cs.connDB();
                dt = cs.DISPLAY("declare  @prodId nvarchar(max) = '" + txtItemCode.Text.ToString() + "' select prodID,prodDesc,Convert(varchar(10),prodDateExpired,101) as DateExpired from tbl_prodMaster where prodid like '%' + @prodId +'%'");
                cs.disconMy();
                if (dt.Rows.Count > 1)
                {
                    isProdIdFinal = false; // if there is another the same product with different expiration date
                    Billing.frmShowSameProdId fs = new Billing.frmShowSameProdId();
                    fs.Owner = this;
                    fs.extProdId = txtItemCode.Text.ToString();
                    fs.ShowDialog();
                }
                else
                {
                    isProdIdFinal = true;
                    SearchProductInfo();
                    isProdIdFinal = false;
                }
            }
                
                      
              //this code is not applicable if the cashier wants to print all receipt directly after settling the transaction.
            //if (AccType.userAccType == "Cashier")
            //{
            //    if (receipt_settings.receiptSettings == 1)
            //    {
            //        if (isReceiptHeaderPrinted == 0)
            //        {
            //            try
            //            {
            //                m_Printer.AsyncMode = true;
            //                PrintReceiptCommand("Header");
            //                isReceiptHeaderPrinted = 1;
            //                m_Printer.AsyncMode = false;
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.Message, "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            //no action
            //        }
            //    }
            //    else
            //    {
            //        //no action
            //    }
            //}
            //else
            //{
            //    //no action for clerk; clerk can only order items for casiher to pass
            //}
        }
        #region Logic
        private void SearchProductInfo()
        {
            //check if reading is done
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select readingID from tbl_DailyReadingStatus where z = 1 and x = 1 and datediff(day,dateAdded,'" + DateTime.Now + "') =0   and machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                MessageBox.Show("Reading of this POS already done!, Come again tomorrow", "System message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
            }
            else
            //if not then search the product information
            {
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("getProdMasterData @prodID = '" + txtItemCode.Text + "'");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    prodQtyStat = Convert.ToDecimal(cs.dbSearchData.Rows[0][9]);
                    if (s_prodQuantityStatus.prodQuantityStat == 1) //check onhand quantity
                    {
                        DataTable dt = new DataTable();
                        cs.connDB();
                        dt = cs.DISPLAY("select isnull(sum(prodQty),0) from tbl_tempBilling where prodID = '" + txtItemCode.Text + "' and isSuspended = 0 ");
                        cs.disconMy();
                        if (dt.Rows.Count > 0)
                        {
                            prodTempQtyStat = Convert.ToDecimal(dt.Rows[0][0]);
                        }
                        if (prodQtyStat <= prodTempQtyStat)
                        {
                            MessageBox.Show("Out of stock!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    else
                    {

                    }
                    StoreItemsTemp();
                    prodQtyStat = 0;
                    prodTempQtyStat = 0;

                }
                else
                {
                    MessageBox.Show("Invalid Item code!", "Item validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtItemCode.SelectAll();
                    return;
                }
            }
        }

        private void StoreItemsTemp()
        {
            string action = "Insert";
            string prodID;
            decimal prodUomID;
            decimal prodQty = 1;
            decimal prodDisc = 0;

            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select prodID,prodUomID from tbl_prodMaster where prodID = '" + txtItemCode.Text.Trim() + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                prodID = cs.dbSearchData.Rows[0][0].ToString();
                prodUomID = Convert.ToDecimal(cs.dbSearchData.Rows[0][1].ToString());
                if (isAllowDupItems == 1)
                {
                    cs.connDB();
                    cs.insertData = "tempBilling_DupItems @action = '" + action + "',@prodQty = '" + prodQty + "',@prodID = '" + prodID + "',@prodUomID = '" + prodUomID + "',@prodDiscount = '" + prodDisc + "',@prodAddedBy = '" + addedByUser.addedBy + "',@proDateAdded = '" + DateTime.Now + "',@machineName = '" + Environment.MachineName.ToString() + "',@dateNow = '" + DateTime.Now + "', @transactionTypeID = '" + s_transactionType.transactionType + "' ";
                    cs.IUD(cs.insertData);
                    cs.disconMy();
                }
                else if (isAllowDupItems == 0)
                {
                    cs.connDB();
                    cs.insertData = "tempBilling @action = '" + action + "',@prodQty = '" + prodQty + "',@prodID = '" + prodID + "',@prodUomID = '" + prodUomID + "',@prodDiscount = '" + prodDisc + "',@prodAddedBy = '" + addedByUser.addedBy + "',@proDateAdded = '" + DateTime.Now + "',@machineName = '" + Environment.MachineName.ToString() + "',@dateNow = '" + DateTime.Now + "', @transactionTypeID = '" + s_transactionType.transactionType + "' ";
                    cs.IUD(cs.insertData);
                    cs.disconMy();
                }               
                //show temp billing items               
                showTempBillingItemsList();


                displayLastItemInfo(prodID);
                txtItemCode.Text = "";

            }
            else
            {
                prodID = "";
                prodUomID = 0;
            }
        }
        public void displayLastItemInfo(string prodID)
        {
            itemCd = prodID;
            //search product infotmation for review
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("sp_posProductInfo @machineName = '" + cs.machineName + "' , @prodID = '" + itemCd + "' , @transactionTypeID = '" + s_transactionType.transactionType + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                txtProdInfo.Text = cs.dbSearchData.Rows[0][0].ToString();
            }
            else
            {
                txtProdInfo.Text = "";
            }
        }
        public void showTempBillingItemsList()
        {
            try
            {
                int isSuspend = 0;

                dgw.Rows.Clear();
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("tempBillingItemsList @machineName = '" + Environment.MachineName.ToString() + "', @isSuspended = '" + isSuspend + "', @dateNow = '" + DateTime.Now + "', @transactionTypeID = '" + s_transactionType.transactionType + "'");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    for (int i = 0; i <= cs.dbSearchData.Rows.Count - 1; i++)
                    {
                        dgw.Rows.Add((cs.dbSearchData.Rows[i][0]), cs.dbSearchData.Rows[i][1], cs.dbSearchData.Rows[i][2], cs.dbSearchData.Rows[i][3], cs.dbSearchData.Rows[i][4], cs.dbSearchData.Rows[i][5], cs.dbSearchData.Rows[i][6], cs.dbSearchData.Rows[i][7], cs.dbSearchData.Rows[i][8], cs.dbSearchData.Rows[i][9], cs.dbSearchData.Rows[i][11],cs.dbSearchData.Rows[i][12],cs.dbSearchData.Rows[i][13]);
                         
                    }

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
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        #endregion
        private void dgw_Leave_1(object sender, EventArgs e)
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

        private void dgw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                txtItemCode.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            showQtyDisc(0);
        }
        private void showQtyDisc(int _isDisc)
        {
            if (dgw.Rows.Count > 0)
            {
               
                if (dgw.CurrentRow.Selected != false)
                {
                    quantityPassValue(_isDisc, dgw.CurrentRow.Cells[6].Value.ToString(), 1);
                }
                else
                {
                    quantityPassValue(_isDisc, dgw.Rows[dgw.Rows.Count - 1].Cells[6].Value.ToString(), 0);
                }
            }
            else
            {
                MessageBox.Show("No item found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        private void quantityPassValue(int isDisc, string itemCode, int isSelected)
        {
            Billing.frmPosQty fpq = new Billing.frmPosQty(this);
            fpq.isDiscount = isDisc;
            fpq.txtItemCode.Text = itemCode;
            fpq.prodRecNo = Convert.ToInt32(dgw.CurrentRow.Cells[10].Value.ToString());
            if (isSelected == 1)
            {
                fpq.txtItemName.Text = dgw.CurrentRow.Cells[2].Value.ToString();
                fpq.txtItemPrice.Text = dgw.CurrentRow.Cells[3].Value.ToString();
                fpq.txtDiscount.Text = dgw.CurrentRow.Cells[4].Value.ToString();
                fpq.txtQuantity.Text = dgw.CurrentRow.Cells[0].Value.ToString();
            }
            else
            {
                fpq.txtItemName.Text = dgw.Rows[dgw.Rows.Count - 1].Cells[2].Value.ToString();
                fpq.txtItemPrice.Text = dgw.Rows[dgw.Rows.Count - 1].Cells[3].Value.ToString();
                fpq.txtDiscount.Text = dgw.Rows[dgw.Rows.Count - 1].Cells[4].Value.ToString();
                fpq.txtQuantity.Text = dgw.Rows[dgw.Rows.Count - 1].Cells[0].Value.ToString();
            }

            fpq.txtQuantity.SelectAll();
            fpq.ShowDialog();
        }

        private void quantityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnOptions.PerformClick();
        }

        private void cursorTimer_Tick(object sender, EventArgs e)
        {
            txtItemCode.Focus();
        }

        private void frmPos_Load(object sender, EventArgs e)
        {
         
            AllowDupItemsShow();
            if (posIsClerk.isClerk == 1) //checking if the machine is for clerk only
            {
                if (AccType.userAccType != "Clerk")
                {
                    MessageBox.Show("This machine is for clerk only!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Dispose();
                }
                else
                {
                    LoadBillingImportantInfo();
                };
            }
            else
            {
                LoadBillingImportantInfo();
            }
        }
        private void AllowDupItemsShow()
        {
            cs.connDB();
            dtDupItems = cs.DISPLAY("settings_PosSetupShow");
            cs.disconMy();
            isAllowDupItems = (dtDupItems.Rows.Count > 0 ? Convert.ToInt32(dtDupItems.Rows[0][0].ToString()) : 0);
          
        }
        private void LoadBillingImportantInfo()
        {
            if (AccType.userAccType == "Cashier")
            {
                backgroundWorker1.RunWorkerAsync(0);//start background worker for receipt printer
                showCashFundForm(); // show cash fund form
                dailyReadingStatus(); // insert daily reading status for the day              
            }
            else // if clerk
            {
                //donnot load printer bckground worker for receipt printer for this is clerk only
                //and donnot load cash fund form
                button2.Text = "Pass to cashier";
                HideOtherButtonsForClerkOnly();
            }
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyy");
            txtPosNo.Text = posCompName.compName.ToString() + "-" + posPosDesc.posDesc.ToString();
            lblTransType.Text = s_transactionTypeDesc.transactionTypeDesc;
            txtCashier.Text = posUserName.userName.ToString();
            lblUser.Text = posUserName.userName.ToString();
            lblAccessType.Text = AccType.userAccType;

            showTempBillingItemsList(); // display items in temp billing

            //DisplayUnreadDays(); // show previous unread day

            dgw.DefaultCellStyle.Font = new Font("segoi ui", 15, FontStyle.Bold);
            loadTempBillingNote(); // load customer name and discounts
            calcTotal();
            dgw.RowTemplate.MinimumHeight = 50; // changes row height

            if (s_posItemColor.posItemColor == s_transactionTypeDesc.transactionTypeDesc)
            {
                dgw.DefaultCellStyle.ForeColor = Color.Red;
            }
            else
            {
                //no action
            }
        }
        private void HideOtherButtonsForClerkOnly()
        {
            ordreListToolStripMenuItem.Visible = false;
            salesAdjustmentToolStripMenuItem.Visible = false;
            dailyTransactionsToolStripMenuItem.Visible = false;
            cashierReportToolStripMenuItem.Visible = false;
            cashInOutToolStripMenuItem.Visible = false;
            reprintToolStripMenuItem.Visible = false;
            toolStripSeparator6.Visible = false;
            toolStripSeparator5.Visible = false;
            toolStripSeparator4.Visible = false;
            toolStripSeparator3.Visible = false;
        }
        //public   void DisplayUnreadDays()
        // {
        //     DateTime readDate = new DateTime();
        //     DataTable dtReading = new DataTable();

        //     decimal countReading = 0;
        //     int x = 1;
        //     int z = 1;
        //     cs.connDB();
        //     cs.dbSearchData = cs.DISPLAY("select max(dateadded) from tbl_DailyReadingStatus where machineNo = '" + posMachineNo.machineNo + "' and machineName = '" + cs.machineName + "'");
        //     cs.disconMy();           
        //         readDate = Convert.ToDateTime(cs.dbSearchData.Rows[0][0]);
        //         if (readDate <= DateTime.Now)
        //         {

        //             cs.connDB();
        //             dtReading = cs.DISPLAY("declare @machineName nvarchar(50) = '" + cs.machineName + "' ,@machineNo nvarchar(50) = '" + posMachineNo.machineNo + "' select (select isnull(max(readingCount),0) +1  from tbl_DailyReadingStatus where machineName = @machineName and machineNo = @machineNo ) as a");
        //             cs.disconMy();
        //             countReading = Convert.ToDecimal(dtReading.Rows[0][0]);
        //             genReadingID();

        //             cs.connDB();
        //             cs.insertData = "insert into tbl_DailyReadingStatus (readingID,z,x,readingCount,addedBy,dateAdded,machineName,machineNo,readBy) values('" + readingID + "','" + z + "','" + x + "','" + countReading + "','" + addedByUser.addedBy + "',(select dateadd(day,1,MAX(dateadded)) from tbl_DailyReadingStatus where machineNo = '" + posMachineNo.machineNo + "' and machineName = '" + cs.machineName + "'),'" + cs.machineName + "','" + posMachineNo.machineNo + "','" + addedByUser.addedBy + "')";
        //             cs.IUD(cs.insertData);
        //             cs.disconMy();

        //             DisplayUnreadDays();
        //         cs.connDB();
        //         cs.deleteData = "delete from tbl_DailyReadingStatus where machineName = '" + cs.machineName + "' and  machineNo = '" + posMachineNo.machineNo + "' and datediff(day,dateadded,'" + DateTime.Now + "') <= 0";
        //         cs.IUD(cs.deleteData);
        //         cs.disconMy();

        //         }
        //         else
        //         {
        //             MessageBox.Show("Success", "");
        //             return;
        //         }                                       
        // }
        private void showCashFundForm()
        {
            int CFInOut = 3;
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select cashInOutID from tbl_CashInOUt where inOut = '" + CFInOut + "' and machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "' and datediff(day,dateAdded,'" + DateTime.Now + "') =0 ");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                //no action
            }
            else
            {
                Billing.frmChangeFund fcf = new Billing.frmChangeFund(this);
                fcf.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cursorTimer.Stop();
            Billing.frmPosPLU fpp = new Billing.frmPosPLU(this);
            fpp.ShowDialog();
        }

        private void pLUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPLU.PerformClick();
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {

                if (dgw.CurrentRow.Selected == false)
                {
                    MessageBox.Show("Select Item to void!", "System message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    if (AccType.userAccType == "Administrator")
                    {
                        prodVoid();
                    }
                    else
                    {
                        cursorTimer.Stop();
                        Billing.frmPosProdVoid fpv = new Billing.frmPosProdVoid(this);
                        fpv.voidType = 1; //void product
                        fpv.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("No item to void!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        public void prodVoid()
        {
            cs.connDB();
            cs.deleteData = "delete from tbl_tempBilling where recNo = '" + dgw.CurrentRow.Cells[10].Value.ToString() + "' ";
            cs.IUD(cs.deleteData);
            cs.disconMy();
            prodQtyStat = 0;
            prodTempQtyStat = 0;
            showTempBillingItemsList();
            cursorTimer.Start();
        }
        private void voidTransaction()
        {
            if (dgw.Rows.Count > 0)
            {
                if (AccType.userAccType == "Administrator")
                {
                    voidTransactionCommand();
                }
                else
                {
                    cursorTimer.Stop();
                    Billing.frmPosProdVoid fpv = new Billing.frmPosProdVoid(this);
                    fpv.voidType = 2; // void transaction
                    fpv.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("No transaction!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        public void voidTransactionCommand()
        {
            cs.connDB();
            cs.deleteData = "delete from tbl_tempBilling where machineID = '" + cs.machineName + "' and isSuspended = '" + cs.isSuspended + "'";
            cs.IUD(cs.deleteData);
            cs.disconMy();
            showTempBillingItemsList();
            cursorTimer.Start();
            clearPosData();
            //product quantity
            prodQtyStat = 0;
            prodTempQtyStat = 0;
            passDataOrderId = 0;
            customerName = "";
            lbNote.Items.Clear();
            DeleteTempBillingNote();
        }
        private void DeleteTempBillingNote()
        {
            string dlt = "";
            cs.connDB();
            dlt = "delete from tbl_tempBilling_note where machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "' and datediff(day,dateAdded,'" + DateTime.Now + "') =0 and noteType ='CustomerName'";
            cs.IUD(dlt);
            cs.disconMy();
        }
        private void voidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnVoid.PerformClick();
        }

        private void quantityToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showQtyDisc(1);
        }

        private void discountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDiscount.PerformClick();
        }

        private void discToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDisc.PerformClick();
        }

        private void btnDisc_Click(object sender, EventArgs e)
        {
            showQtyDisc(2);
        }
        private void calcPayment()
        {

            DataTable dt = new DataTable();
            if (dgw.Rows.Count > 0)
            {
                cs.connDB();
                dt = cs.DISPLAY("tempBilling_taxCalculation @machineName = '" + cs.machineName + "' , @dateNow = '" + DateTime.Now + "'");
                cs.disconMy();
                if (dt.Rows.Count > 0)
                {

                    VatSale = Convert.ToDouble(dt.Rows[0][1].ToString());
                    totalVat = Convert.ToDouble(dt.Rows[0][2].ToString());
                    vatExSale = Convert.ToDouble(dt.Rows[0][0].ToString());
                    totalSale = Convert.ToDouble(dt.Rows[0][3].ToString());
                    grossPayable = Convert.ToDouble(dt.Rows[0][4].ToString());
                    totalItems = Convert.ToDouble(dt.Rows[0][5].ToString());

                    txtVatSale.Text = VatSale.ToString("n2");
                    txtVatExemptSale.Text = vatExSale.ToString("n2");
                    txtTotalSale.Text = totalSale.ToString("n2");
                    txtVAT.Text = totalVat.ToString("n2");
                    txtTotalPayable.Text = grossPayable.ToString("n2");
                    txtTotalItems.Text = totalItems.ToString();

                }
                else
                {
                    //clearPosData();
                }
            }
            else
            {
                clearPosData();
            }

        }

        private void dgw_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            calcPayment();
            dgw.FirstDisplayedScrollingRowIndex = dgw.Rows.Count - 1;
        }

        private void dgw_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calcPayment();

        }
        public void saveDailySales(double totalCash, double totalChange)
        {

            GenTransID();
            for (int i = 0; i <= dgw.Rows.Count - 1; i++)
            {
                GenTransIDPI();
                prodQty = Convert.ToDecimal(dgw.Rows[i].Cells[0].Value.ToString());
                productID = dgw.Rows[i].Cells[6].Value.ToString();
                prodSellingPrice = Convert.ToDecimal(dgw.Rows[i].Cells[3].Value.ToString());
                PriceOptID = Convert.ToDecimal(dgw.Rows[i].Cells[8].Value.ToString());
                productDesc = dgw.Rows[i].Cells[2].Value.ToString();
                if (dgw.Rows[i].Cells[4].Value.ToString() == "")
                {
                    prodDiscPerItem = 0;
                }
                else
                {
                    prodDiscPerItem = Convert.ToDecimal(dgw.Rows[i].Cells[4].Value.ToString());
                }
                cs.connDB();
                cs.insertData = "prodDailySales_save @action = '" + _action + "',@transIDPItem = '" + transactionIDPI + "', @transactionID = '" + transactionID + "', @prodQty = '" + prodQty + "', @prodID = '" + productID + "' ,@prodSellingPrice = '" + prodSellingPrice + "',@prodDiscPerItem = '" + prodDiscPerItem + "' ,@prodAddedBy = '" + addedByUser.addedBy + "', @prodDateAdded = '" + DateTime.Now + "', @machineName = '" + cs.machineName + "',@POID = '" + PriceOptID + "',@prodDesc = '" + productDesc + "' ";
                cs.IUD(cs.insertData);
                cs.disconMy();
            }


            //save daily transaction amount to the database

            //generate or number            
            GenOrNo();
            cs.connDB();
            cs.insertData = "prodDailySalesAmt_save @transactionID = '" + transactionID + "',@vatSale = '" + VatSale + "',@vatExSale = '" + vatExSale + "',@totalSale = '" + totalSale + "',@vat12 = '" + totalVat + "',@totalPayable = '" + Convert.ToDouble(txtTotalPayable_.Text) + "' ,@totalCash = '" + totalCash + "',@totalChange = '" + totalChange + "',@addedBy = '" + addedByUser.addedBy + "',@dateAdded = '" + DateTime.Now + "',@machineName = '" + cs.machineName + "', @machineNo = '" + posMachineNo.machineNo + "',@orNo = '" + ORNO + "' , @grossPayable = '" + grossPayable + "',@discountID = '" + discountID + "', @cusDiscID = '" + cusDiscID + "',@transactionTypeID = '" + s_transactionType.transactionType + "',@discountAmt = '" + discountAmt + "'";
            cs.IUD(cs.insertData);
            cs.disconMy();

            //save customer name
            if (customerName == "" && txtDisc.Text == "0")
            {
                //no action
            }
            else
            {
                CustomerDetailSave();
            }
            //delete temp billing to the database     
            cs.connDB();
            cs.deleteData = "delete from tbl_tempBilling where machineID = '" + cs.machineName + "' and isSuspended = '" + cs.isSuspended + "' and datediff(day,prodDateAdded,'" + DateTime.Now + "')=0";
            cs.IUD(cs.deleteData);
            cs.disconMy();

            string upt;
            int Paid = 1;
            cs.connDB();
            upt = "update tbl_TempPassDataInfo set Paid ='" + Paid + "' where PassDataId = '" + passDataOrderId + "'";
            cs.IUD(upt);
            cs.disconMy();


            //print command   
            Action printingDecision = new Action(() =>
            {
                if (receipt_settings.receiptSettings == 1)
                {
                    //printCommand();      this receipt has design using rdlc   

                    //PrintReceiptCommand("Body");   // this receipt is hard coded with OPOS for .net
                    //isReceiptHeaderPrinted = 0;
                    //BWprintRcpt.RunWorkerAsync(0);
                    Billing.frmWaitingform fwf = new Billing.frmWaitingform(this);
                    fwf.ShowDialog();
                }
                else
                {
                    if (lblTransType.Text == "Charge Invoice") // if transaction is charge invoice
                    {

                        //printing charge invoice receipt
                    }
                    else // normal printing preview
                    {
                        Receipt.frmRptReceipt frr = new Receipt.frmRptReceipt();
                        frr.ShowDialog();
                    }
                }
            }
           );
            int isDirNextTrans = 0;
            DataTable dtDirNextTrans = new DataTable();
            cs.connDB();
            dtDirNextTrans = cs.DISPLAY("settins_PosPrintingShow @machineNo = '" + posMachineNo.machineNo + "',@machineName = '" + Environment.MachineName + "'");
            cs.disconMy();         
            if (dtDirNextTrans.Rows.Count > 0)
            {
                isDirNextTrans = Convert.ToInt32(dtDirNextTrans.Rows[0][0].ToString());
            }
            else
            {
                isDirNextTrans = 0;
            }
            if (isDirNextTrans ==1)
            {
                // direct to next transaction
                try
                {
                    OpenDrawer();
                }
                catch (Exception)
                {
                    MessageBox.Show("Cash drawer not found!, transaction already saved.", "Printer Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
               
            }
            else
            {
                printingDecision();
            }
            
            Billing.frmNextTransaction fnt = new Billing.frmNextTransaction(this);
            fnt.ShowDialog();
        }
        private void CustomerDetailSave()
        {
            cs.connDB();
            cs.insertData = "prodDailySales_cusDetailSave @transID = '" + transactionID + "',@cusName = '" + customerName + "',@machineName = '" + cs.machineName + "', @machineNo = '" + posMachineNo.machineNo + "',@dateNow = '" + DateTime.Now + "'";
            cs.IUD(cs.insertData);
            cs.disconMy();
        }


        private void printCommand()
        {
            Receipt.frmRptReceipt frcpt = new Receipt.frmRptReceipt();
            frcpt.displayCustomerReceipt();
            frcpt.rcptParameterData();
            frcpt.reportViewer1.RefreshReport();
            frcpt.autoPrint_CusReceipt();
        }
        private void GenTransIDPI()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(max(transIDPItem),1100000000000000) + 1 as transIDPItem from tbl_prodDailySales");
            cs.disconMy();
            transactionIDPI = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);

        }
        private void GenTransID()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(max(transactionid),1000000000000000) + 1 as transactioniD from tbl_proddailySales");
            cs.disconMy();
            transactionID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);

        }
        private void GenOrNo()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select orNo from tbl_prodDailySalesAmt where machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "' and transactionTypeID = '" + s_transactionType.transactionType + "' ");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                //continue to generate existing or number
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("SELECT distinct RIGHT('0000000000'+CAST(ISNULL(max(orNo),0) + 1 AS VARCHAR),10) FROM tbl_prodDailySalesAmt where machineName = '" + cs.machineName + "' and transactionTypeID = '" + s_transactionType.transactionType + "'");
                cs.disconMy();
                ORNO = cs.dbSearchData.Rows[0][0].ToString();
            }
            else
            {
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("select orNo from tbl_StartOrNo where machineNo = '" + posMachineNo.machineNo + "' and machineName = '" + cs.machineName + "'");
                cs.disconMy();
                ORNO = cs.dbSearchData.Rows[0][0].ToString();
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Billing.frmPosCustName fpc = new Billing.frmPosCustName(this);
            fpc.ShowDialog();
        }
        public void clearPosData()
        {
            transactionID = 0;
            transactionIDPI = 0;
            dgw.Rows.Clear();
            txtVatSale.Text = "0.00";
            txtVatExemptSale.Text = "0.00";
            txtTotalSale.Text = "0.00";
            txtVAT.Text = "0.00";
            txtTotalPayable.Text = "0.00";
            txtItemCode.Text = "";
            txtTotalItems.Text = "0.0";
            txtTotalPayable_.Text = "0.00";
            itemCd = "";
            txtProdInfo.Text = "";
            passDataId = 0;
            isPassed = false;
          
            //customerName = "";
            //lbNote.Items.Clear();

            VatSale = 0;
            totalVat = 0;
            vatExSale = 0;
            totalSale = 0;
            grossPayable = 0;
            totalItems = 0;
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            cntxtOption.Show(btnOptions, btnOptions.Height, 0);
        }

        private void suspendRecallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccType.userAccType == "Administrator")
            {
                suspendCommand();
            }
            else
            {
                Billing.frmPosSuspendValidation fps = new Billing.frmPosSuspendValidation(this);
                fps.ShowDialog();
            }
        }
        public void suspendCommand()
        {
            if (dgw.Rows.Count > 0)
            {
                genSuspendNo();
                cs.connDB();
                cs.insertData = "suspendCommand @machineName = '" + cs.machineName + "',@suspendNo = '" + suspendNo + "',@dateNow = '" + DateTime.Now + "', @transactionTypeID = '" + s_transactionType.transactionType + "'";
                cs.IUD(cs.insertData);
                cs.disconMy();
                showTempBillingItemsList();
                suspendNo = 0;
            }
            else
            {
                MessageBox.Show("Suspend transaction not valid!", "Suspend validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


        }
        private void genSuspendNo()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(max(suspendNo),0) + 1 from tbl_tempBilling where machineID = '" + cs.machineName + "' and transactionTypeID= '" + s_transactionType.transactionType + "' and datediff(day,prodDateAdded,'" + DateTime.Now + "') =0");
            suspendNo = Convert.ToInt32(cs.dbSearchData.Rows[0][0].ToString());
            cs.disconMy();
        }

        private void voidTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            voidTransaction();
        }

        private void recallToolStripMenuItem_Click(object sender, EventArgs e)
        {

            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select recNo from tbl_tempBilling where suspendNo = '" + suspendNo + "' and machineID = '" + cs.machineName + "' and isSuspended = '" + cs.isSuspended + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                clearPosData();
                passDataOrderId = 0;
                cs.connDB();
                cs.updateData = "update tbl_tempBilling set isSuspended = 1 where suspendNo = '" + suspendNo + "' and machineID = '" + cs.machineName + "' and isSuspended ='" + cs.isSuspended + "'";
                cs.IUD(cs.updateData);
                cs.disconMy();
            }
            else
            {
                if (dgw.Rows.Count > 0)
                {
                    DialogResult res;
                    res = MessageBox.Show("Do you want to suspend this current transaction?", "Suspend confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        suspendRecallToolStripMenuItem.PerformClick();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    //no action
                }

            }
            Billing.frmPosRecall fpr = new Billing.frmPosRecall(this);
            fpr.ShowDialog();
        }
        public void dailyReadingStatus()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select readingID from tbl_DailyReadingStatus where datediff(day,dateAdded,'" + DateTime.Now + "') =0  and machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                cs.connDB();
                cs.updateData = "update tbl_dailyReadingStatus set addedBy = '" + addedByUser.addedBy + "', dateAdded = '" + DateTime.Now + "' where  datediff(day,dateAdded,'" + DateTime.Now + "') =0  and machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "' ";
                cs.IUD(cs.updateData);
                cs.disconMy();
            }
            else
            {
                genReadingID();
                cs.connDB();
                cs.insertData = "insert into tbl_dailyReadingStatus (readingID,z,x,addedBy,dateAdded,machineName,machineNo)" +
                                 "values('" + readingID + "',0,0,'" + addedByUser.addedBy + "','" + DateTime.Now + "','" + cs.machineName + "','" + posMachineNo.machineNo + "' )";
                cs.IUD(cs.insertData);
                cs.disconMy();
            }

        }
        private void genReadingID()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(max(readingID),1000000000000000) + 1 from tbl_dailyReadingStatus");
            cs.disconMy();
            readingID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
        }

        private void reprintToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (receipt_settings.receiptSettings == 1)
            {
                //printCommand(); this receipt designed by rdlc
                isReceiptReprint = 1;
                PrintReceiptCommand("Header");
                PrintReceiptCommand("Body");
                isReceiptReprint = 0;
            }
            else
            {
                Receipt.frmRptReceipt frr = new Receipt.frmRptReceipt();
                frr.ShowDialog();
            }
        }

        private void cashInOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Billing.frmPosCashInOut fpc = new Billing.frmPosCashInOut(this);
            fpc.ShowDialog();
        }

        private void readingZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                MessageBox.Show("Finish pending transaction!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                isReading();
                if (isReaded == 1)
                {
                    MessageBox.Show("Transaction closed!", "System message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (isReaded == 0)
                {

                    Billing.frmReadingValidation frv = new Billing.frmReadingValidation(this);
                    frv.isReadingOthersCommand = 0;
                    frv.ShowDialog();

                }
            }

        }
        private void isReading()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select readingID from tbl_dailyReadingStatus where datediff(day,dateAdded,'" + DateTime.Now + "') =0 and machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "' and x =1 and z =1");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                isReaded = 1;
            }
            else
            {
                isReaded = 0;
            }
        }

        private void PosTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");


        }

        private void txtTotalPayable_TextChanged(object sender, EventArgs e)
        {
            //txtHeader.Text = txtTotalPayable.Text;

            calcTotal();


        }
        private void calcTotal()
        {
            double totalAmt = 0;
            double totalAmtPayable = 0;
            totalAmt = grossPayable * ((Convert.ToDouble(txtDisc.Text)) / 100);
            discountAmt = totalAmt;
            totalAmtPayable = grossPayable - totalAmt;
            txtTotalPayable_.Text = totalAmtPayable.ToString("n2");
            txtHeader.Text = txtTotalPayable_.Text;//for header            
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                MessageBox.Show("Current transaction not finished.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (lbNote.Items.Count > 0)
            {
                MessageBox.Show("Remove customers' name/discount to exit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                this.Dispose();
            }
        }

        private void frmPos_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin fl = new frmLogin();
            if (AccType.userAccType == "Cashier")
            {
                PosTimer.Stop();
                this.Dispose();
                fl.Show();
            }
            else if (AccType.userAccType == "Clerk")
            {
                PosTimer.Stop();
                this.Dispose();
                fl.Show();
            }
            else
            {
                PosTimer.Stop();
                this.Dispose();
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void frmPos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                e.Handled = true;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3.PerformClick();
        }
        public void loadTempBillingNote()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("tempBilling_loadNote @machineName = '" + cs.machineName + "', @machineNo = '" + posMachineNo.machineNo + "',@dateNow = '" + DateTime.Now + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                lbNote.Items.Clear();
                for (int i = 0; i <= cs.dbSearchData.Rows.Count - 1; i++)
                {
                    lbNote.Items.Add(cs.dbSearchData.Rows[i][0]);
                }
                cs.connDB();// store customer name in variable when load 
                cs.dbSearchData = cs.DISPLAY("select Note from tbl_TempBilling_note where machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "' and datediff(day,dateAdded,'" + DateTime.Now + "') =0 and noteType = 'CustomerName'");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    customerName = cs.dbSearchData.Rows[0][0].ToString();
                }
                else
                {
                    customerName = "";
                }
                cs.connDB();//store discount in textbox when load                 
                cs.dbSearchData = cs.DISPLAY("select isnull(tcd.discount,0) as 'Discount' ,isnull(tcd.discountID,0) as discountID ,isnull(tcm.cusDiscID,'') as cusDiscID  from tbl_TempBilling_note  tn left join tbl_customer_discount tcd on tn.discountid = tcd.discountid   left join tbl_customer_master tcm on tcd.discountID = tcm.cusDiscType where tn.machineName = '" + cs.machineName + "' and tn.machineNo = '" + posMachineNo.machineNo + "' and datediff(day,tn.dateAdded,'" + DateTime.Now + "') =0 and tn.noteType = 'CustomerDiscount'");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    txtDisc.Text = cs.dbSearchData.Rows[0][0].ToString();
                    discountID = Convert.ToDecimal(cs.dbSearchData.Rows[0][1].ToString());
                    cusDiscID = cs.dbSearchData.Rows[0][2].ToString();
                }
                else
                {
                    txtDisc.Text = "0";
                    discountID = 0;
                    cusDiscID = "";
                }
            }
            else
            {
                txtDisc.Text = "0";
                discountID = 0;
                cusDiscID = "";
                customerName = "";
                lbNote.Items.Clear();
            }
        }

        private void otherDiscountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Billing.OtherDiscounts.frmDiscountList fdl = new Billing.OtherDiscounts.frmDiscountList(this);
            fdl.ShowDialog();
        }
        public bool isPassed = false;
        public void CustomerNameCommand(string act, string sMsg, string cusName, string noteType, string discID, string discCusName, string discRemarks, string discHomeAdd, decimal dDiscountID)
        {
            cs.connDB();
            cs.insertData = "tempBilling_customerName @action = '" + act + "',@cusName = '" + cusName + "',@machineName = '" + cs.machineName + "',@machineNo = '" + posMachineNo.machineNo + "',@dateNow = '" + DateTime.Now + "' , @noteType = '" + noteType + "' , @discID ='" + discID + "', @discCusName = '" + discCusName + "', @discRemarks = '" + discRemarks + "', @discHomeAdd = '" + discHomeAdd + "' ,@discountID = '" + dDiscountID + "' ";
            cs.IUD(cs.insertData);
            cs.disconMy();

            loadTempBillingNote();
            calcTotal();
            if (isPassed)
            {

            }
            else
            {
                MessageBox.Show(sMsg, "System message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtTotalPayable__TextChanged(object sender, EventArgs e)
        {
            txtHeader.Text = txtTotalPayable_.Text;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtPosNo_Click(object sender, EventArgs e)
        {

        }

        private void readingOtherToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Company.frmTansTypeList ft = new Company.frmTansTypeList(this);
            ft.isOtherReadingCommand = 1;
            ft.ShowDialog();
        }


        private void txtPosNo_Click_1(object sender, EventArgs e)
        {

        }
        #region ReceiptPrinterLogic

        public void PrintReceiptCommand(string printType)
        {
            try
            {

                DataTable dtProdDetails = new DataTable();
                string compProp;
                string compName;
                string compTIN;
                string compMIN;
                string compAddress;
                string compPosDesc;
                string compSerialNo;

                //Product variables
                string strHolder = "";
                double pQuantity;
                string pUom;
                string pOperator = " X ";
                double pPrice;
                double pTotal;
                string pProductDesc;
                string prodSoldData = "";
                string itemVolume;
                string cashier = "";
                string cusName = "";
                //product details
                DateTime pDate;
                string pTransactionType;
                string pOrNo;
                string pMachineNo;
                double pSubTotal = 0;
                double pDiscPerItem = 0;
                double pTotalPayable = 0;
                double pTotalCash = 0;
                double pTotalChange = 0;
                double pTotalDiscount = 0;
                double pTotalItems = 0;

                double vatSale = 0;
                double vatExSale = 0;
                double tax = 0;


                int[] RecLineChars = new int[MAX_LINE_WIDTHS] { 0, 0 };

                compProp = posCompProp.compProp;
                compName = posCompName.compName;
                compTIN = posTIN.tin;
                compMIN = posMIN.min;
                compAddress = posAddress.address;
                compPosDesc = posPosDesc.posDesc;
                compSerialNo = posSerialNo.serialNo;

                long lRecLineCharsCount;
                lRecLineCharsCount = GetRecLineChars(ref RecLineChars);


                m_Printer.RecLineChars = RecLineChars[1];
                if (printType == "Header")
                {
                    //Header                                            
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + compProp + " - Prop." + "\n");
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + compName + "\n");
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "VAT Registered TIN: " + compTIN + "\n");
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "MIN: " + compMIN + "\n");
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + compAddress + "\n");
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + compPosDesc + " S/N: " + compSerialNo + "\n");

                    if (isReceiptReprint == 1)
                    {
                        m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "---REPRINT---" + "\n");
                    }
                    else
                    {
                        //no action
                    }
                }
                else
                {
                    if (isReceiptReprint == 1)
                    {
                        //no action
                    }
                    else
                    {
                        //Open drawer command
                        OpenDrawer();
                    }
                    //Get Buying details           
                    cs.connDB();
                    dtProdDetails = cs.DISPLAY("customerReceiptAmt @machineName = '" + cs.machineName + "', @dateNow = '" + DateTime.Now + "', @transactionTypeID = '" + s_transactionType.transactionType + "'");
                    cs.disconMy();
                    if (dtProdDetails.Rows.Count > 0)
                    {
                        pDate = Convert.ToDateTime(dtProdDetails.Rows[0][13]);
                        pTransactionType = dtProdDetails.Rows[0][19].ToString();
                        pMachineNo = dtProdDetails.Rows[0][10].ToString();
                        pOrNo = dtProdDetails.Rows[0][11].ToString();
                        pTotalPayable = Convert.ToDouble(dtProdDetails.Rows[0][5]);
                        pTotalCash = Convert.ToDouble(dtProdDetails.Rows[0][6]);
                        pTotalChange = Convert.ToDouble(dtProdDetails.Rows[0][7]);
                        pTotalDiscount = Convert.ToDouble(dtProdDetails.Rows[0][18]);
                        cashier = dtProdDetails.Rows[0][12].ToString();
                        cusName = dtProdDetails.Rows[0][17].ToString();
                        vatSale = Convert.ToDouble(dtProdDetails.Rows[0][1]);
                        vatExSale = Convert.ToDouble(dtProdDetails.Rows[0][2]);
                        tax = Convert.ToDouble(dtProdDetails.Rows[0][4]);


                        strHolder = MakePrintString(m_Printer.RecLineChars, pDate.ToString("MM/dd/yyy" + " (" + "ddd" + ")" + " hh:mm tt"), pTransactionType);
                        m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|uC" + strHolder + "\n");
                        strHolder = MakePrintString(m_Printer.RecLineChars, "Trx No. " + pMachineNo + "-" + pOrNo, " ");
                        m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|uC" + strHolder);
                        //gives margin
                        m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|30uF");
                        strHolder = MakePrintString(m_Printer.RecLineChars, "ITEM(s)", "TOTAL");
                        m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|bC" + strHolder);
                        //gives margin
                        m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|28uF");

                    }

                    //m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|uC" + compSerialNo + "\u001b|N\n");
                    //Get Buying items data

                    cs.connDB(); 
                    cs.dbSearchData = cs.DISPLAY("customerReceipt @machineName = '" + cs.machineName + "' , @dateNow = '" + DateTime.Now + "', @transactionTypeID = '" + s_transactionType.transactionType + "'");
                    cs.disconMy();
                    if (cs.dbSearchData.Rows.Count > 0)
                    {
                        for (int i = 0; i <= cs.dbSearchData.Rows.Count - 1; i++)
                        {
                            pQuantity = Convert.ToDouble(cs.dbSearchData.Rows[i][2]);
                            pUom = cs.dbSearchData.Rows[i][7].ToString();
                            pPrice = Convert.ToDouble(cs.dbSearchData.Rows[i][4]);
                            pDiscPerItem = Convert.ToDouble(cs.dbSearchData.Rows[i][5]);
                            pTotal = Convert.ToDouble(cs.dbSearchData.Rows[i][6]);
                            pProductDesc = cs.dbSearchData.Rows[i][3].ToString();
                            pSubTotal += pTotal;
                            pTotalItems += pQuantity;
                            if (pDiscPerItem != 0)
                            {
                                itemVolume = " " + pQuantity + " " + pUom + pOperator + pPrice.ToString("n2") + " (" + pDiscPerItem.ToString("n2") + ")";
                            }
                            else
                            {
                                itemVolume = " " + pQuantity + " " + pUom + pOperator + pPrice.ToString("n2");
                            }

                            prodSoldData = MakePrintString(m_Printer.RecLineChars, itemVolume, pTotal.ToString("n2"));
                            m_Printer.PrintNormal(PrinterStation.Receipt, prodSoldData + "\u001b|20uF");

                            var words = pProductDesc.Split();
                            var lines = new List<string> { words[0] };
                            var lineNum = 0;
                            for (int x = 1; x < words.Length; x++)
                            {
                                if (lines[lineNum].Length + words[x].Length + 1 <= 35)
                                    lines[lineNum] += " " + words[x];
                                else
                                {
                                    lines.Add(words[x]);
                                    lineNum++;
                                }
                            }
                            foreach (var line in lines)
                            {
                                m_Printer.PrintNormal(PrinterStation.Receipt, line + "\u001b|20uF");
                            }

                            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|15uF");
                        }
                        m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|10uF");
                    }
                    //Footer
                    strHolder = MakePrintString(m_Printer.RecLineChars, "SUBTOTAL", pSubTotal.ToString("n2"));
                    m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                    strHolder = MakePrintString(m_Printer.RecLineChars, "DISCOUNT", pTotalDiscount.ToString("n2") + "%");
                    m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                    strHolder = MakePrintString(m_Printer.RecLineChars / 2, "G'TOTAL", pTotalPayable.ToString("n2"));
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|bC" + "\u001b|2C" + strHolder + "\n");
                    strHolder = MakePrintString(m_Printer.RecLineChars, "CASH", pTotalCash.ToString("n2"));
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|bC" + strHolder + "\n");
                    strHolder = MakePrintString(m_Printer.RecLineChars, "CHANGE", pTotalChange.ToString("n2"));
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|uC" + strHolder + "\u001b|30uF");

                    strHolder = MakePrintString(m_Printer.RecLineChars, "VAT SALE", vatSale.ToString("n2"));
                    m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                    strHolder = MakePrintString(m_Printer.RecLineChars, "VAT-EXEMPT SALE", vatExSale.ToString("n2"));
                    m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                    strHolder = MakePrintString(m_Printer.RecLineChars, "12% VAT", tax.ToString("n2"));
                    m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\u001b|30uF");

                    strHolder = MakePrintString(m_Printer.RecLineChars, "CASHIER: " + cashier, pTotalItems.ToString() + " Item(s)");
                    m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                    strHolder = MakePrintString(m_Printer.RecLineChars, "SOLD TO: " + cusName.ToString(), "");
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|uC" + strHolder + "\u001b|30uF");
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "INFORMATION SYSTEMS" + "\n");
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "---SERVERS AS YOUR OFFICIAL RECEIPT---" + "\n");
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "Items mentioned above must be accompanied with this sales receipt when returned." + "\n");
                    m_Printer.PrintNormal(PrinterStation.Receipt, "   Shop @" + "\u001b|20uF");
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "\u001b|bC" + "\u001b|2C" + posCompName.compName.ToString());
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|30uF");
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "THANK YOU COME AGAIN!" + "\n");

                    //   \u001b|#fP = Line Feed and Paper cut	
                    m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|fP");

                    //to be continued
                }

                m_Printer.RecLineChars = RecLineChars[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        //Daily Reading       
        public void DailyReadingPrintData(decimal readBy)
        {
            try
            {
                string readingType = "";
                decimal readingCount = 0;
                string noOfTrans = "";
                double grossSales = 0;
                double netSales = 0;
                double NOT = 0;
                double totalTax = 0;
                double totalQty = 0;
                double voidedAmt = 0;
                int noVoidedTrans = 0;
                double totalCashSales = 0;
                double avgSales = 0;
                double totalVatSales = 0;
                int totalVatItems = 0;
                double totalNonVatSales = 0;
                int totalNonVatItems = 0;
                DataTable dtCashInOut = new DataTable();
                DateTime cfDt = DateTime.Now;
                double cfAmt = 0;
                //cash in out
                DateTime dtAdded;
                string cInOutTypeDesc = "";
                string cInOutMemo = "";
                double cInOutAmt = 0;

                string strHolder = "";
                DailyCounterReading();//counter reading
                OpenDrawer();
                PrintReceiptCommand("Header");
                int[] RecLineChars = new int[MAX_LINE_WIDTHS] { 0, 0 };
                long lRecLineCharsCount;
                lRecLineCharsCount = GetRecLineChars(ref RecLineChars);
                m_Printer.RecLineChars = RecLineChars[1];

                //for reading status
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("select readingID from tbl_dailyReadingStatus where datediff(day,dateAdded,'" + DateTime.Now + "')=0 and machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "' and z =0 and x =0");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    readingType = "Z";
                }
                else
                {
                    readingType = "X";
                }
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("select isnull(readingCount,0) from tbl_dailyReadingStatus where datediff(day,dateAdded,'" + DateTime.Now + "') =0 and machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "'");
                cs.disconMy();
                readingCount = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
                //for reading data
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("ReadingCommand @start = '" + DateTime.Now + "',@machineName = '" + cs.machineName + "', @machineNo = '" + posMachineNo.machineNo + "', @dateNow = '" + DateTime.Now + "', @transactionTypeID = '" + s_transactionType.transactionType + "'");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    noOfTrans = cs.dbSearchData.Rows[0][1].ToString();
                    grossSales = Convert.ToDouble(cs.dbSearchData.Rows[0][6]);
                    netSales = Convert.ToDouble(cs.dbSearchData.Rows[0][4]);
                    NOT = Convert.ToDouble(cs.dbSearchData.Rows[0][0]);
                    totalTax = Convert.ToDouble(cs.dbSearchData.Rows[0][5]);
                    totalQty = Convert.ToDouble(cs.dbSearchData.Rows[0][15]);
                    voidedAmt = Convert.ToDouble(cs.dbSearchData.Rows[0][16]);
                    noVoidedTrans = Convert.ToInt32(cs.dbSearchData.Rows[0][17]);
                    totalCashSales = Convert.ToDouble(cs.dbSearchData.Rows[0][9]);
                    avgSales = Convert.ToDouble(cs.dbSearchData.Rows[0][10]);
                    totalVatSales = Convert.ToDouble(cs.dbSearchData.Rows[0][11]);
                    totalVatItems = Convert.ToInt32(cs.dbSearchData.Rows[0][13]);
                    totalNonVatSales = Convert.ToDouble(cs.dbSearchData.Rows[0][12]);
                    totalNonVatItems = Convert.ToInt32(cs.dbSearchData.Rows[0][14]);
                }

                m_Printer.PrintNormal(PrinterStation.Receipt, "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, DateTime.Now.ToString("MMM dd, yyy (ddd) hh:mm tt"), posUserName.userName);
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\u001b|30uF");
                strHolder = MakePrintString(m_Printer.RecLineChars, readingType + " READING", "Trx No. " + noOfTrans);
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "T/M#" + posMachineNo.machineNo, DateTime.Now.ToString("MMM dd, yyy (ddd)"));
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|uC" + strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "Gross Sales", grossSales.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "Net Sales", netSales.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "# Transactions", NOT.ToString());
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "Total Tax", totalTax.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "Total Quantity", totalQty.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "Amount Voided", voidedAmt.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "# Voided", noVoidedTrans.ToString());
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "Total Cash Sales", totalCashSales.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "# Cash Sales", NOT.ToString());
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "# Customer(s)", NOT.ToString());
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "Avg Sales/Trx", avgSales.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "Total Vatable Sales", totalVatSales.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "#Vatable Item(s)", totalVatItems.ToString());
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "Total Non-Vatable Sales", totalNonVatSales.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "#Non-Vatable Item(s)", totalNonVatItems.ToString());
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\u001b|30uF");
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "CASH IN/OUT" + "\u001b|20uF");
                //cash fund data
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("select dateAdded,amount from tbl_CashInOut where machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "' and datediff(day,dateAdded,'" + DateTime.Now + "')=0 and inOut = 3");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    cfDt = Convert.ToDateTime(cs.dbSearchData.Rows[0][0]);
                    cfAmt = Convert.ToDouble(cs.dbSearchData.Rows[0][1]);
                }
                strHolder = MakePrintString(m_Printer.RecLineChars, cfDt.ToString("hh:mm tt") + " CASH" + " CHANGE FUND", cfAmt.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, DateTime.Now.ToString("hh:mm tt") + " CASH" + " SALES", totalCashSales.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");

                cs.connDB();
                dtCashInOut = cs.DISPLAY("readingCashInOut @machineName = '" + cs.machineName + "', @machineNo = '" + posMachineNo.machineNo + "' , @dateNow = '" + DateTime.Now + "'");
                cs.disconMy();
                if (dtCashInOut.Rows.Count > 0)
                {
                    for (int i = 0; i <= dtCashInOut.Rows.Count - 1; i++)
                    {
                        dtAdded = Convert.ToDateTime(dtCashInOut.Rows[i][4]);
                        cInOutTypeDesc = dtCashInOut.Rows[i][3].ToString();
                        cInOutMemo = dtCashInOut.Rows[i][2].ToString();
                        cInOutAmt = Convert.ToDouble(dtCashInOut.Rows[i][1]);
                        strHolder = MakePrintString(m_Printer.RecLineChars, dtAdded.ToString("hh:mm tt") + " " + cInOutTypeDesc + " " + cInOutMemo, cInOutAmt.ToString("n2"));
                        m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                    }
                }
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|30uF" + "\u001b|cA" + "MEDIA REPORT" + "\u001b|20uF");
                //media report data
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("MediaReport @machineName = '" + cs.machineName + "', @machineNo = '" + posMachineNo.machineNo + "' ,@dateNow = '" + DateTime.Now + "'");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    mediaReportAmt = Convert.ToDouble(cs.dbSearchData.Rows[0][0]);
                    prevNrgt = Convert.ToDouble(cs.dbSearchData.Rows[0][2]);
                    cashFundAmt = Convert.ToDouble(cs.dbSearchData.Rows[0][3]);
                }

                strHolder = MakePrintString(m_Printer.RecLineChars, "TOTAL CASH", (totalCashSales + mediaReportAmt).ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "TOTAL", (totalCashSales + mediaReportAmt).ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\u001b|40uF");
                strHolder = MakePrintString(m_Printer.RecLineChars, readingType + " Counter #", readingCount.ToString());
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                if (readingType == "X")
                {
                    //do not print the Non-resettable grand total
                }
                else
                {
                    strHolder = MakePrintString(m_Printer.RecLineChars, "PREVIOUS NRGT", prevNrgt.ToString("n2"));
                    m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                    nrgt = ((mediaReportAmt + prevNrgt + totalCashSales) - cashFundAmt);
                    strHolder = MakePrintString(m_Printer.RecLineChars, "NRGT", nrgt.ToString("n2"));
                    m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                }
                //   \u001b|#fP = Line Feed and Paper cut	
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|fP");

                m_Printer.RecLineChars = RecLineChars[0];

                //NRGTCommand
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("select NRGTID from tbl_NRGT where machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "' and datediff(day,dateAdded,'" + DateTime.Now + "') =0");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    NRGTID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
                    actn = "Update";
                    saveNRGTCommand(readBy);
                }
                else
                {
                    genNRGTID();
                    actn = "Insert";
                    saveNRGTCommand(readBy);
                }
                //update daily reading status
                dailyReadingStatusUpdate(readBy);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        const int MAX_LINE_WIDTHS = 2;
        private long GetRecLineChars(ref int[] RecLineChars)
        {
            long lRecLineChars = 0;
            long lCount;
            int i;

            // Calculate the element count.
            lCount = m_Printer.RecLineCharsList.GetLength(0);

            if (lCount == 0)
            {
                lRecLineChars = 0;
            }
            else
            {
                if (lCount > MAX_LINE_WIDTHS)
                {
                    lCount = MAX_LINE_WIDTHS;
                }

                for (i = 0; i < lCount; i++)
                {
                    RecLineChars[i] = m_Printer.RecLineCharsList[i];
                }
                lRecLineChars = lCount;
            }

            return lRecLineChars;
        }
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
        public void ReleasingPrinter()
        {

            if (m_Printer != null)
            {
                try
                {
                    //Cancel the device
                    m_Printer.DeviceEnabled = false;

                    //Release the device exclusive control right.
                    m_Printer.Release();

                }
                catch (PosControlException)
                {
                }
                finally
                {
                    //Finish using the device.
                    m_Printer.Close();
                }
            }

        }
        public void LoadPrinter()
        {
            //-------------
            //<<<step1>>>--Start
            //Use a Logical Device Name which has been set on the SetupPOS.
            string strLogicalName = "PosPrinter";

            try
            {
                //Create PosExplorer
                PosExplorer posExplorer = new PosExplorer();

                DeviceInfo deviceInfo = null;

                try
                {
                    deviceInfo = posExplorer.GetDevice(DeviceType.PosPrinter, strLogicalName);
                    m_Printer = (PosPrinter)posExplorer.CreateInstance(deviceInfo);

                }
                catch (Exception)
                {
                    return;
                }
                //Open the device
                m_Printer.Open();

                //Get the exclusive control right for the opened device.
                //Then the device is disable from other application.
                m_Printer.Claim(1000);

                //Enable the device.
                m_Printer.DeviceEnabled = true;

            }
            catch (PosControlException)
            {
            }
            //<<<step1>>>--End

        }
        public void OpenDrawer()
        {

            byte[] bytes = new byte[] { 27, 112, 0, 25, 250 };
            m_Printer.PrintNormal(PrinterStation.Receipt, System.Text.ASCIIEncoding.ASCII.GetString(bytes));
        }

        private void saveNRGTCommand(decimal readBy)
        {
            cs.connDB();
            cs.insertData = "NRGTCommand @action = '" + actn + "',@nrgtid = '" + NRGTID + "',@prevNrgt = '" + prevNrgt + "',@nrgt = '" + nrgt + "',@addedBy = '" + addedByUser.addedBy + "',@dateAdded = '" + DateTime.Now + "',@machineName = '" + cs.machineName + "',@machineNo = '" + posMachineNo.machineNo + "'";
            cs.IUD(cs.insertData);
            cs.disconMy();
        }
        private void genNRGTID()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select isnull(max(NRGTID),1000000000000) + 1 from tbl_NRGT");
            cs.disconMy();
            NRGTID = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
        }
        private void dailyReadingStatusUpdate(decimal readBy)
        {
            cs.connDB();
            cs.insertData = "dailyReadingStatusUpdate @machineName = '" + cs.machineName + "' ,@machineNo = '" + posMachineNo.machineNo + "' , @readBy = '" + readBy + "',@dateNow = '" + DateTime.Now + "'";
            cs.IUD(cs.insertData);
            cs.disconMy();
        }
        private void DailyCounterReading()
        {
            decimal countReading = 0;
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("declare @machineName nvarchar(50) = '" + cs.machineName + "' ,@machineNo nvarchar(50) = '" + posMachineNo.machineNo + "' select (select isnull(max(readingCount),0) +1  from tbl_DailyReadingStatus where machineName = @machineName and machineNo = @machineNo ) as a");
            cs.disconMy();
            countReading = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
            cs.connDB();
            cs.updateData = "dailyReadingCounterReading @machineName = '" + cs.machineName + "' ,@machineNo = '" + posMachineNo.machineNo + "' , @dateNow = '" + DateTime.Now + "',@readingCount = '" + countReading + "'";
            cs.IUD(cs.updateData);
            cs.disconMy();
        }
        public void printOthersReadingSummaryCommand(string transTypeDesc, decimal transTypeID, string userFullName)
        {
            double vatSale = 0;
            double vatExSale = 0;
            double totalSale = 0;
            double vat12 = 0;
            double grossPayable = 0;
            double discountAmt = 0;
            double totalPayable = 0;
            string strHolder = "";

            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("sp_ReadingOthers @machineName = '" + cs.machineName + "', @machineNo = '" + posMachineNo.machineNo + "', @transactionTypeID = '" + transTypeID + "', @dateNow = '" + DateTime.Now + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                vatSale = Convert.ToDouble(cs.dbSearchData.Rows[0][0]);
                vatExSale = Convert.ToDouble(cs.dbSearchData.Rows[0][1]);
                totalSale = Convert.ToDouble(cs.dbSearchData.Rows[0][2]);
                vat12 = Convert.ToDouble(cs.dbSearchData.Rows[0][3]);
                grossPayable = Convert.ToDouble(cs.dbSearchData.Rows[0][4]);
                discountAmt = Convert.ToDouble(cs.dbSearchData.Rows[0][5]);
                totalPayable = Convert.ToDouble(cs.dbSearchData.Rows[0][6]);
            }
            PrintReceiptCommand("Header");
            int[] RecLineChars = new int[MAX_LINE_WIDTHS] { 0, 0 };
            long lRecLineCharsCount;
            lRecLineCharsCount = GetRecLineChars(ref RecLineChars);
            m_Printer.RecLineChars = RecLineChars[1];
            strHolder = MakePrintString(m_Printer.RecLineChars, "", "");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\n" + "\u001b|uC" + strHolder + "\u001b|30uF");
            m_Printer.PrintNormal(PrinterStation.Receipt, "Transaction type: " + transTypeDesc + "\u001b|30uF");
            strHolder = MakePrintString(m_Printer.RecLineChars, "VAT Sale", vatSale.ToString("n2"));
            m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
            strHolder = MakePrintString(m_Printer.RecLineChars, "VAT Exempt Sale", vatExSale.ToString("n2"));
            m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
            strHolder = MakePrintString(m_Printer.RecLineChars, "Total Sale", totalSale.ToString("n2"));
            m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
            strHolder = MakePrintString(m_Printer.RecLineChars, "Total TAX", vat12.ToString("n2"));
            m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
            strHolder = MakePrintString(m_Printer.RecLineChars, "Total Gross Payable", grossPayable.ToString("n2"));
            m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
            strHolder = MakePrintString(m_Printer.RecLineChars, "Total Discount Amt.", discountAmt.ToString("n2"));
            m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n\n");
            strHolder = MakePrintString(m_Printer.RecLineChars, "Total Gross Sales", totalPayable.ToString("n2"));
            m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
            strHolder = MakePrintString(m_Printer.RecLineChars, "", "");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|uC" + strHolder + "\u001b|30uF");
            m_Printer.PrintNormal(PrinterStation.Receipt, "Cashier: " + posUserName.userName + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "Printed by: " + userFullName + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "Date: " + DateTime.Now.ToString("MMM, dd, yyy hh:mm:ss tt"));
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|fP");

            m_Printer.RecLineChars = RecLineChars[0];
        }
        public void printCashInOutReceipt(string inOutDesc, double inOutAmt, string inOutMemo)
        {
            string strHolder = "";

            PrintReceiptCommand("Header");
            OpenDrawer();
            int[] RecLineChars = new int[MAX_LINE_WIDTHS] { 0, 0 };
            long lRecLineCharsCount;
            lRecLineCharsCount = GetRecLineChars(ref RecLineChars);
            m_Printer.RecLineChars = RecLineChars[1];
            strHolder = MakePrintString(m_Printer.RecLineChars, "", "");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|uC" + strHolder + "\n");
            strHolder = MakePrintString(m_Printer.RecLineChars, DateTime.Now.ToString("MM/dd/yyy " + "(ddd)"), "");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|uC" + strHolder + "\n\u001b|30uF");
            strHolder = MakePrintString(m_Printer.RecLineChars, "Cash " + inOutDesc, inOutAmt.ToString("n2"));
            m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, inOutMemo + "\u001b|35uF");
            strHolder = MakePrintString(m_Printer.RecLineChars, "Cashier: " + posUserName.userName, DateTime.Now.ToString("hh:mm tt"));
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|uC" + strHolder + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "Powered by: CMJ-ICT" + "\n");

            m_Printer.RecLineChars = RecLineChars[0];
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|fP");
        }
        private void CashierReport()
        {
            double grossSales = 0;
            double netSales = 0;
            int NOT = 0;
            double totalTax = 0;
            double totalQty = 0;
            double totalCashSales = 0;
            double taxExempt = 0;
            DataTable dtCashInOut = new DataTable();
            DateTime dtAdded;
            string cInOutTypeDesc = "";
            string cInOutMemo = "";
            double cInOutAmt = 0;
            DateTime cfDt = DateTime.Now;
            double cfAmt = 0;
            string transactionType = "";

            try
            {
                string strHolder = "";
                PrintReceiptCommand("Header");
                int[] RecLineChars = new int[MAX_LINE_WIDTHS] { 0, 0 };
                long lRecLineCharsCount;
                lRecLineCharsCount = GetRecLineChars(ref RecLineChars);
                m_Printer.RecLineChars = RecLineChars[1];

                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("ReadingCommand   @machinename = '" + cs.machineName + "'  ,@machineNo = '" + posMachineNo.machineNo + "'  ,@dateNow = '" + DateTime.Now + "'  ,@start = '" + DateTime.Now + "' ,@transactiontypeid = '" + s_transactionType.transactionType + "' ");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    grossSales = Convert.ToDouble(cs.dbSearchData.Rows[0][6]);
                    netSales = Convert.ToDouble(cs.dbSearchData.Rows[0][4]);
                    NOT = Convert.ToInt32(cs.dbSearchData.Rows[0][0]);
                    totalTax = Convert.ToDouble(cs.dbSearchData.Rows[0][5]);
                    totalQty = Convert.ToDouble(cs.dbSearchData.Rows[0][15]);
                    totalCashSales = Convert.ToDouble(cs.dbSearchData.Rows[0][9]);
                    transactionType = cs.dbSearchData.Rows[0][18].ToString();
                    taxExempt = Convert.ToDouble(cs.dbSearchData.Rows[0][3]);
                }

                m_Printer.PrintNormal(PrinterStation.Receipt, "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, DateTime.Now.ToString("MMM dd, yyy (ddd) hh:mm tt"), posUserName.userName);
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "CASHIER REPORT" + "\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "TRANSACTION TYPE: " + transactionType.ToString() + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "T/M#" + posMachineNo.machineNo, DateTime.Now.ToString("MMM dd, yyy (ddd)"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "", "");
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|uC" + strHolder + "\u001b|20uF");

                strHolder = MakePrintString(m_Printer.RecLineChars, "Gross Sales", grossSales.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "Net Sales", netSales.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "# Transactions", NOT.ToString());
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "Total Tax", totalTax.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "No Tax", taxExempt.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "Total Quantity", totalQty.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "Total Cash Sales", totalCashSales.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "# Cash Sales", NOT.ToString());
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "# Customers", NOT.ToString());
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n\n");

                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "CASH IN/OUT" + "\u001b|20uF");
                //cash fund data
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("select dateAdded,amount from tbl_CashInOut where machineName = '" + cs.machineName + "' and machineNo = '" + posMachineNo.machineNo + "' and datediff(day,dateAdded,'" + DateTime.Now + "')=0 and inOut = 3");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    cfDt = Convert.ToDateTime(cs.dbSearchData.Rows[0][0]);
                    cfAmt = Convert.ToDouble(cs.dbSearchData.Rows[0][1]);
                }
                strHolder = MakePrintString(m_Printer.RecLineChars, cfDt.ToString("hh:mm tt") + " CASH" + " CHANGE FUND", cfAmt.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, DateTime.Now.ToString("hh:mm tt") + " CASH" + " SALES", totalCashSales.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");

                cs.connDB();
                dtCashInOut = cs.DISPLAY("readingCashInOut @machineName = '" + cs.machineName + "', @machineNo = '" + posMachineNo.machineNo + "' , @dateNow = '" + DateTime.Now + "'");
                cs.disconMy();
                if (dtCashInOut.Rows.Count > 0)
                {
                    for (int i = 0; i <= dtCashInOut.Rows.Count - 1; i++)
                    {
                        dtAdded = Convert.ToDateTime(dtCashInOut.Rows[i][4]);
                        cInOutTypeDesc = dtCashInOut.Rows[i][3].ToString();
                        cInOutMemo = dtCashInOut.Rows[i][2].ToString();
                        cInOutAmt = Convert.ToDouble(dtCashInOut.Rows[i][1]);
                        strHolder = MakePrintString(m_Printer.RecLineChars, dtAdded.ToString("hh:mm tt") + " " + cInOutTypeDesc + " " + cInOutMemo, cInOutAmt.ToString("n2"));
                        m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                    }
                }
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|30uF" + "\u001b|cA" + "MEDIA REPORT" + "\u001b|20uF");
                //media report data
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("MediaReport @machineName = '" + cs.machineName + "', @machineNo = '" + posMachineNo.machineNo + "' ,@dateNow = '" + DateTime.Now + "'");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    mediaReportAmt = Convert.ToDouble(cs.dbSearchData.Rows[0][0]);
                    prevNrgt = Convert.ToDouble(cs.dbSearchData.Rows[0][2]);
                    cashFundAmt = Convert.ToDouble(cs.dbSearchData.Rows[0][3]);
                }

                strHolder = MakePrintString(m_Printer.RecLineChars, "TOTAL CASH", (totalCashSales + mediaReportAmt).ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                strHolder = MakePrintString(m_Printer.RecLineChars, "TOTAL", (totalCashSales + mediaReportAmt).ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, strHolder);
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|fP");
                m_Printer.RecLineChars = RecLineChars[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



        }
        #endregion

        private void frmPos_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReleasingPrinter();
        }

        private void tsReports_Click(object sender, EventArgs e)
        {

        }


        private void lbNote_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
             
        }

        private void openDrawerToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Billing.frmPosSuspendValidation fps = new Billing.frmPosSuspendValidation(this);
            fps.Text = "Cash Drawer Security";
            fps.isDrawerRequest = 1;
            fps.ShowDialog();
        }

        private void tsReports_DoubleClick(object sender, EventArgs e)
        {

        }

        private void txtPosNo_Click_2(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker helperBW = sender as BackgroundWorker;
            int arg = (int)e.Argument;
            e.Result = BackgroundProcessLogicMethod(helperBW, arg);
            if (helperBW.CancellationPending)
            {
                e.Cancel = true;
            }
        }
        private int BackgroundProcessLogicMethod(BackgroundWorker bw, int a)
        {
            int result = 0;
            Thread.Sleep(0);
            LoadPrinter();
            return result;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                string prodID = "";
                if (dgw.CurrentRow.Selected != false)
                {
                    prodID = dgw.CurrentRow.Cells[6].Value.ToString();
                }
                else
                {
                    prodID = dgw.Rows[dgw.Rows.Count - 1].Cells[6].Value.ToString();
                }

                Billing.frmPricingOpt fpo = new Billing.frmPricingOpt(this);
                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("select POID from tbl_prodOptions where prodID = '" + prodID + "' ");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    if (dgw.Rows.Count > 0)
                    {
                        fpo.txtProductCode.Text = prodID;
                        fpo.ShowDialog();
                    }
                    else
                    {
                        //no action
                    }
                }
                else
                {
                    MessageBox.Show("No pricing options available for this product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                //no ction
            }
            
        }

        private void pricingOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button5.PerformClick();
        }

        private void cashierReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CashierReport();
        }

        private void BWprintRcpt_DoWork(object sender, DoWorkEventArgs e)
        {

        }


        private void BWprintRcpt_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void ordreListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }
        #region Load pass data details
        public void LoadPassData()
        {
            DataTable lpd = new DataTable();
            cs.connDB();
            lpd = cs.DISPLAY("sp_temppassdataorderlistdisplay @passDataId = '" + passDataOrderId + "'");
            cs.disconMy();
            if (lpd.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i = 0; i <= lpd.Rows.Count - 1; i++)
                {
                    dgw.Rows.Add((lpd.Rows[i][0]), lpd.Rows[i][1], lpd.Rows[i][2], lpd.Rows[i][3], lpd.Rows[i][4], lpd.Rows[i][5], lpd.Rows[i][6], lpd.Rows[i][7], 0, lpd.Rows[i][8], lpd.Rows[i][9]);
                }
                if (dgw.Rows.Count > 0)
                {
                    dgw.CurrentRow.Selected = false;
                }
                else
                {
                    //no action
                }
            }
            else
            {
                dgw.Rows.Clear();
            }
        }

        #endregion
        #region Save pass data details to tempBilling
        public void passDataSaveTempBilling()
        {
            string action = "insert";
            decimal pqty = 0;
            string pid = "";
            decimal prodDisc = 0;
            decimal prodUomID = 0;

            for (int i = 0; i <= dgw.Rows.Count - 1; i++)
            {
                pqty = Convert.ToDecimal(dgw.Rows[i].Cells[0].Value);
                pid = dgw.Rows[i].Cells[6].Value.ToString();
                prodDisc = Convert.ToDecimal(dgw.Rows[i].Cells[4].Value);
                prodUomID = Convert.ToDecimal(dgw.Rows[i].Cells[9].Value);

                cs.connDB();
                cs.insertData = "tempBilling @action = '" + action + "',@prodQty = '" + pqty + "',@prodID = '" + pid + "',@prodUomID = '" + prodUomID + "',@prodDiscount = '" + prodDisc + "',@prodAddedBy = '" + addedByUser.addedBy + "',@proDateAdded = '" + DateTime.Now + "',@machineName = '" + Environment.MachineName.ToString() + "',@dateNow = '" + DateTime.Now + "', @transactionTypeID = '" + s_transactionType.transactionType + "' ";
                cs.IUD(cs.insertData);
                cs.disconMy();

            }
            dgw.Rows.Clear();
            showTempBillingItemsList();

        }
        #endregion

        private void ordreListToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                MessageBox.Show("Finish/Void ongoing transaction first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                Billing.frmPassDataList fpd = new Billing.frmPassDataList(this);
                fpd.ShowDialog();
            }
        }

        private void txtHeader_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainStatus_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Billing.frmPosVariation frm = new Billing.frmPosVariation(this);
            if (dgw.CurrentRow.Selected  == true)
            {
                frm.txtItemDesc.Text = dgw.CurrentRow.Cells[2].Value.ToString();
                frm.txtPrice.Text =  Convert.ToDecimal(dgw.CurrentRow.Cells[3].Value.ToString()).ToString("n2");
                frm.pRecNo = Convert.ToInt32(dgw.CurrentRow.Cells[10].Value.ToString());
                frm.txtDesc.Text = dgw.CurrentRow.Cells[11].Value.ToString();
                frm.txtQty.Text = dgw.CurrentRow.Cells[12].Value.ToString();
            }
            else
            {
                frm.txtItemDesc.Text = dgw.Rows[dgw.Rows.Count - 1].Cells[2].Value.ToString();
                frm.txtPrice.Text =  Convert.ToDecimal(dgw.Rows[dgw.Rows.Count - 1].Cells[3].Value.ToString()).ToString("n2");
                frm.pRecNo = Convert.ToInt32(dgw.Rows[dgw.Rows.Count - 1].Cells[10].Value.ToString());
                frm.txtDesc.Text = dgw.Rows[dgw.Rows.Count -1].Cells[11].Value.ToString();
                frm.txtQty.Text = dgw.Rows[dgw.Rows.Count -1].Cells[12].Value.ToString();
            }           
            frm.ShowDialog();
        }

        private void productVariationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button6.PerformClick();
        }

        private void productTransactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product_Menu.frmProdSearch frm = new frmProdSearch();
            frm.Owner = this;
            frm.isProdTrans = 2;
            frm.ShowDialog();
        }
        #region Product Transaction Report
        public void prodTransListReport()
        {
            DateTime dt = DateTime.Now;
            string dtTime = "";
            string strHolder = "";
            double ttl = 0;
            double subTotal = 0;
            decimal qty = 0;
            decimal sellPrice = 0;
            string discnt = "";
            string machineId = posMachineNo.machineNo;
            string cmbTransType = lblTransType.Text;
            try
            {


                 PrintReceiptHeader();

                int[] RecLineChars = new int[MAX_LINE_WIDTHS] { 0, 0 };
                long lRecLineCharsCount;
                lRecLineCharsCount = GetRecLineChars(ref RecLineChars);
                m_Printer.RecLineChars = RecLineChars[1];

                strHolder = MakePrintString(m_Printer.RecLineChars, DateTime.Now.ToString("MMM dd, yyy (ddd) hh:mm tt"), posUserName.userName);
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|10uF" + strHolder + "\n" + "\u001b|10uF");
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "-----PRODUCT TRANSACTION REPORT-----" + "\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "TRANSACTION TYPE: " + cmbTransType + "\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "PERIOD: " + DateTime.Now.ToString() + " - " + DateTime.Now.ToString() + "\n\n");

                m_Printer.PrintNormal(PrinterStation.Receipt, prodTransProdDesc + "\n\n");

                cs.connDB();
                cs.dbSearchData = cs.DISPLAY("sp_productTransList @start = '" + DateTime.Now.ToString() + "', @cutOff = '" + DateTime.Now.ToString() + "' ,@machineId = '" + machineId + "' , @transactionType = '" + cmbTransType + "',@prodId = '" + prodTransProdId + "'");
                cs.disconMy();
                if (cs.dbSearchData.Rows.Count > 0)
                {
                    for (int i = 0; i <= cs.dbSearchData.Rows.Count - 1; i++)
                    {

                        dtTime = cs.dbSearchData.Rows[i][1].ToString();
                        ttl = Convert.ToDouble(cs.dbSearchData.Rows[i][7].ToString());
                        qty = Convert.ToDecimal(cs.dbSearchData.Rows[i][4].ToString());
                        sellPrice = Convert.ToDecimal(cs.dbSearchData.Rows[i][5].ToString());
                        discnt = cs.dbSearchData.Rows[i][6].ToString();
                        subTotal += ttl;
                        strHolder = MakePrintString(m_Printer.RecLineChars, dtTime.ToString() + "  " + qty + "  " + sellPrice + " (" + discnt + ")", ttl.ToString("n2"));
                        m_Printer.PrintNormal(PrinterStation.Receipt, strHolder + "\n");
                    }
                }
                strHolder = MakePrintString(m_Printer.RecLineChars, "TOTAL SALES AMT", subTotal.ToString("n2"));
                m_Printer.PrintNormal(PrinterStation.Receipt, "\n" + strHolder + "\n");

                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|fP");
                m_Printer.RecLineChars = RecLineChars[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Printer message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

        }
        private void PrintReceiptHeader()
        {

            string compProp;
            string compName;
            string compTIN;
            string compMIN;
            string compAddress;
            string compPosDesc;
            string compSerialNo;
            compProp = posCompProp.compProp;
            compName = posCompName.compName;
            compTIN = posTIN.tin;
            compMIN = posMIN.min;
            compAddress = posAddress.address;
            compPosDesc = posPosDesc.posDesc;
            compSerialNo = posSerialNo.serialNo;
            int[] RecLineChars = new int[MAX_LINE_WIDTHS] { 0, 0 };
            long lRecLineCharsCount;
            lRecLineCharsCount = GetRecLineChars(ref RecLineChars);
            m_Printer.RecLineChars = RecLineChars[1];
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + compProp + " - Prop." + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + compName + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "VAT Registered TIN: " + compTIN + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + "MIN: " + compMIN + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + compAddress + "\n");
            m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" + compPosDesc + " S/N: " + compSerialNo + "\n");
            m_Printer.RecLineChars = RecLineChars[0];

        }
        #endregion
    }
}
