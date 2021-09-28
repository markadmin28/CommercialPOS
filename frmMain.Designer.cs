namespace POS
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.MainMenu = new System.Windows.Forms.ToolStrip();
            this.tsSystemUser = new System.Windows.Forms.ToolStripButton();
            this.tCustomer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsProductMenu = new System.Windows.Forms.ToolStripButton();
            this.tsProductInventory = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsInquiry = new System.Windows.Forms.ToolStripButton();
            this.tsReports = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsOpenPos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPosMaintenance = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsHousekeeping = new System.Windows.Forms.ToolStripButton();
            this.MainMenuStrip_ = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSystemMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.sPosSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f1 = new System.Windows.Forms.ToolStripMenuItem();
            this.f2 = new System.Windows.Forms.ToolStripMenuItem();
            this.f3 = new System.Windows.Forms.ToolStripMenuItem();
            this.f4 = new System.Windows.Forms.ToolStripMenuItem();
            this.f5 = new System.Windows.Forms.ToolStripMenuItem();
            this.f6 = new System.Windows.Forms.ToolStripMenuItem();
            this.f7 = new System.Windows.Forms.ToolStripMenuItem();
            this.f8 = new System.Windows.Forms.ToolStripMenuItem();
            this.f9 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAccessType = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.MainMenu.SuspendLayout();
            this.MainMenuStrip_.SuspendLayout();
            this.MainStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.AutoSize = false;
            this.MainMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MainMenu.BackgroundImage")));
            this.MainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainMenu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSystemUser,
            this.tCustomer,
            this.toolStripSeparator1,
            this.tsProductMenu,
            this.tsProductInventory,
            this.toolStripSeparator2,
            this.tsInquiry,
            this.tsReports,
            this.toolStripSeparator5,
            this.tsOpenPos,
            this.toolStripSeparator3,
            this.tsPosMaintenance,
            this.toolStripSeparator6,
            this.tsHousekeeping});
            this.MainMenu.Location = new System.Drawing.Point(0, 27);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1291, 70);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "ToolStrip1";
            // 
            // tsSystemUser
            // 
            this.tsSystemUser.AutoSize = false;
            this.tsSystemUser.BackColor = System.Drawing.Color.Transparent;
            this.tsSystemUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsSystemUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsSystemUser.Image = ((System.Drawing.Image)(resources.GetObject("tsSystemUser.Image")));
            this.tsSystemUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsSystemUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSystemUser.Name = "tsSystemUser";
            this.tsSystemUser.Size = new System.Drawing.Size(95, 70);
            this.tsSystemUser.Text = "System user";
            this.tsSystemUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsSystemUser.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tsSystemUser.ToolTipText = "Press F1 to open \"System user form\"";
            this.tsSystemUser.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // tCustomer
            // 
            this.tCustomer.AutoSize = false;
            this.tCustomer.BackColor = System.Drawing.Color.Transparent;
            this.tCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tCustomer.Image = ((System.Drawing.Image)(resources.GetObject("tCustomer.Image")));
            this.tCustomer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tCustomer.Name = "tCustomer";
            this.tCustomer.Size = new System.Drawing.Size(105, 70);
            this.tCustomer.Text = "Customer mgt";
            this.tCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tCustomer.ToolTipText = "Press F2  to open \"Customer management menu\"";
            this.tCustomer.Click += new System.EventHandler(this.tCustomer_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 70);
            // 
            // tsProductMenu
            // 
            this.tsProductMenu.AutoSize = false;
            this.tsProductMenu.BackColor = System.Drawing.Color.Transparent;
            this.tsProductMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsProductMenu.Image = ((System.Drawing.Image)(resources.GetObject("tsProductMenu.Image")));
            this.tsProductMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsProductMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsProductMenu.Name = "tsProductMenu";
            this.tsProductMenu.Size = new System.Drawing.Size(105, 70);
            this.tsProductMenu.Text = "Product menu";
            this.tsProductMenu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsProductMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tsProductMenu.ToolTipText = "Press F3 to open \"Product menu\"";
            this.tsProductMenu.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // tsProductInventory
            // 
            this.tsProductInventory.AutoSize = false;
            this.tsProductInventory.BackColor = System.Drawing.Color.Transparent;
            this.tsProductInventory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsProductInventory.Image = ((System.Drawing.Image)(resources.GetObject("tsProductInventory.Image")));
            this.tsProductInventory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsProductInventory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsProductInventory.Name = "tsProductInventory";
            this.tsProductInventory.Size = new System.Drawing.Size(130, 70);
            this.tsProductInventory.Text = "Product inventory";
            this.tsProductInventory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsProductInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tsProductInventory.ToolTipText = "Press F4 to open \"Product Inventory menu\"";
            this.tsProductInventory.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 70);
            // 
            // tsInquiry
            // 
            this.tsInquiry.AutoSize = false;
            this.tsInquiry.BackColor = System.Drawing.Color.Transparent;
            this.tsInquiry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsInquiry.Image = ((System.Drawing.Image)(resources.GetObject("tsInquiry.Image")));
            this.tsInquiry.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsInquiry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsInquiry.Name = "tsInquiry";
            this.tsInquiry.Size = new System.Drawing.Size(90, 70);
            this.tsInquiry.Text = "Inquiry";
            this.tsInquiry.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsInquiry.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tsInquiry.ToolTipText = "Press F5 to open \"Inquiry menu\"";
            this.tsInquiry.Click += new System.EventHandler(this.ToolStripButton7_Click);
            // 
            // tsReports
            // 
            this.tsReports.AutoSize = false;
            this.tsReports.BackColor = System.Drawing.Color.Transparent;
            this.tsReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsReports.Image = ((System.Drawing.Image)(resources.GetObject("tsReports.Image")));
            this.tsReports.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsReports.Name = "tsReports";
            this.tsReports.Size = new System.Drawing.Size(90, 70);
            this.tsReports.Text = "Reports";
            this.tsReports.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsReports.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tsReports.ToolTipText = "Press F6 to open \"Reports menu\"";
            this.tsReports.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 70);
            // 
            // tsOpenPos
            // 
            this.tsOpenPos.AutoSize = false;
            this.tsOpenPos.BackColor = System.Drawing.Color.Transparent;
            this.tsOpenPos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsOpenPos.Image = ((System.Drawing.Image)(resources.GetObject("tsOpenPos.Image")));
            this.tsOpenPos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsOpenPos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOpenPos.Name = "tsOpenPos";
            this.tsOpenPos.Size = new System.Drawing.Size(110, 70);
            this.tsOpenPos.Text = "Transactions";
            this.tsOpenPos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsOpenPos.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tsOpenPos.ToolTipText = "Press F7 to open \"Open POS\"";
            this.tsOpenPos.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 70);
            // 
            // tsPosMaintenance
            // 
            this.tsPosMaintenance.AutoSize = false;
            this.tsPosMaintenance.BackColor = System.Drawing.Color.Transparent;
            this.tsPosMaintenance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsPosMaintenance.Image = ((System.Drawing.Image)(resources.GetObject("tsPosMaintenance.Image")));
            this.tsPosMaintenance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsPosMaintenance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPosMaintenance.Name = "tsPosMaintenance";
            this.tsPosMaintenance.Size = new System.Drawing.Size(140, 70);
            this.tsPosMaintenance.Text = "PMS Maintenance";
            this.tsPosMaintenance.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsPosMaintenance.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tsPosMaintenance.ToolTipText = "Press F8 to open \"POS Maintenance\"";
            this.tsPosMaintenance.Click += new System.EventHandler(this.tsPosMaintenance_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 70);
            // 
            // tsHousekeeping
            // 
            this.tsHousekeeping.AutoSize = false;
            this.tsHousekeeping.BackColor = System.Drawing.Color.Transparent;
            this.tsHousekeeping.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsHousekeeping.Image = ((System.Drawing.Image)(resources.GetObject("tsHousekeeping.Image")));
            this.tsHousekeeping.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsHousekeeping.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsHousekeeping.Name = "tsHousekeeping";
            this.tsHousekeeping.Size = new System.Drawing.Size(120, 70);
            this.tsHousekeeping.Text = "Housekeeping";
            this.tsHousekeeping.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsHousekeeping.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.tsHousekeeping.ToolTipText = "Press F9 to open \"Housekeeping menu\"";
            this.tsHousekeeping.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // MainMenuStrip_
            // 
            this.MainMenuStrip_.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MainMenuStrip_.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.f1,
            this.f2,
            this.f3,
            this.f4,
            this.f5,
            this.f6,
            this.f7,
            this.f8,
            this.f9});
            this.MainMenuStrip_.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip_.Name = "MainMenuStrip_";
            this.MainMenuStrip_.Size = new System.Drawing.Size(1291, 27);
            this.MainMenuStrip_.TabIndex = 3;
            this.MainMenuStrip_.Text = "menuStrip";
            this.MainMenuStrip_.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MainMenuStrip_ItemClicked);
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sSystemMaintenance,
            this.sPosSetup,
            this.toolStripSeparator4,
            this.logoutToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(46, 23);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // sSystemMaintenance
            // 
            this.sSystemMaintenance.Image = ((System.Drawing.Image)(resources.GetObject("sSystemMaintenance.Image")));
            this.sSystemMaintenance.Name = "sSystemMaintenance";
            this.sSystemMaintenance.Size = new System.Drawing.Size(205, 24);
            this.sSystemMaintenance.Text = "System Maintenance";
            this.sSystemMaintenance.Click += new System.EventHandler(this.sSystemMaintenance_Click);
            // 
            // sPosSetup
            // 
            this.sPosSetup.Image = ((System.Drawing.Image)(resources.GetObject("sPosSetup.Image")));
            this.sPosSetup.Name = "sPosSetup";
            this.sPosSetup.Size = new System.Drawing.Size(205, 24);
            this.sPosSetup.Text = "POS Setup";
            this.sPosSetup.Click += new System.EventHandler(this.pOSSetupToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(202, 6);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("logoutToolStripMenuItem.Image")));
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // f1
            // 
            this.f1.Name = "f1";
            this.f1.Size = new System.Drawing.Size(114, 23);
            this.f1.Text = "F1 System user";
            this.f1.Click += new System.EventHandler(this.systemUserToolStripMenuItem_Click);
            // 
            // f2
            // 
            this.f2.Name = "f2";
            this.f2.Size = new System.Drawing.Size(185, 23);
            this.f2.Text = "F2 Customer management";
            this.f2.Click += new System.EventHandler(this.customerManagementToolStripMenuItem_Click);
            // 
            // f3
            // 
            this.f3.Name = "f3";
            this.f3.Size = new System.Drawing.Size(127, 23);
            this.f3.Text = "F3 Product menu";
            this.f3.Click += new System.EventHandler(this.f3ProductMenuToolStripMenuItem_Click);
            // 
            // f4
            // 
            this.f4.Name = "f4";
            this.f4.Size = new System.Drawing.Size(150, 23);
            this.f4.Text = "F4 Product inventory";
            this.f4.Click += new System.EventHandler(this.f4InquiryToolStripMenuItem_Click);
            // 
            // f5
            // 
            this.f5.Name = "f5";
            this.f5.Size = new System.Drawing.Size(83, 23);
            this.f5.Text = "F5 Inquiry";
            this.f5.Click += new System.EventHandler(this.f5InquiryToolStripMenuItem_Click);
            // 
            // f6
            // 
            this.f6.Name = "f6";
            this.f6.Size = new System.Drawing.Size(87, 23);
            this.f6.Text = "F6 Reports";
            this.f6.Click += new System.EventHandler(this.f6ReportsToolStripMenuItem_Click);
            // 
            // f7
            // 
            this.f7.Name = "f7";
            this.f7.Size = new System.Drawing.Size(115, 23);
            this.f7.Text = "F7 Transactions";
            this.f7.Click += new System.EventHandler(this.f7OpenPOSToolStripMenuItem_Click);
            // 
            // f8
            // 
            this.f8.Name = "f8";
            this.f8.Size = new System.Drawing.Size(151, 23);
            this.f8.Text = "F8 PMS Maintenance";
            this.f8.Click += new System.EventHandler(this.f8POSMaintenanceToolStripMenuItem_Click);
            // 
            // f9
            // 
            this.f9.Name = "f9";
            this.f9.Size = new System.Drawing.Size(127, 23);
            this.f9.Text = "F9 Housekeeping";
            this.f9.Click += new System.EventHandler(this.f9HousekeepingToolStripMenuItem_Click);
            // 
            // MainStatus
            // 
            this.MainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblUser,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.lblAccessType,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.lblDate,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel7,
            this.lblTime});
            this.MainStatus.Location = new System.Drawing.Point(0, 388);
            this.MainStatus.Name = "MainStatus";
            this.MainStatus.Size = new System.Drawing.Size(1291, 28);
            this.MainStatus.TabIndex = 4;
            this.MainStatus.Text = "MainStatus";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(60, 23);
            this.toolStripStatusLabel1.Text = "User :";
            // 
            // lblUser
            // 
            this.lblUser.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblUser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(149, 23);
            this.lblUser.Text = "Mark Ryan G. Morales";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(12, 23);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripStatusLabel3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel3.Image")));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(103, 23);
            this.toolStripStatusLabel3.Text = "Access type :";
            // 
            // lblAccessType
            // 
            this.lblAccessType.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblAccessType.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblAccessType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAccessType.Name = "lblAccessType";
            this.lblAccessType.Size = new System.Drawing.Size(75, 23);
            this.lblAccessType.Text = "Developer";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(12, 23);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripStatusLabel5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel5.Image")));
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(61, 23);
            this.toolStripStatusLabel5.Text = "Date :";
            // 
            // lblDate
            // 
            this.lblDate.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblDate.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(71, 23);
            this.lblDate.Text = "2/2/2019";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(12, 23);
            this.toolStripStatusLabel6.Text = "|";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripStatusLabel7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel7.Image")));
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(61, 23);
            this.toolStripStatusLabel7.Text = "Time :";
            // 
            // lblTime
            // 
            this.lblTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblTime.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(73, 23);
            this.lblTime.Text = "12:33 PM";
            // 
            // MainTimer
            // 
            this.MainTimer.Enabled = true;
            this.MainTimer.Interval = 1000;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 416);
            this.Controls.Add(this.MainStatus);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.MainMenuStrip_);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Point of Sales System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.MainMenuStrip_.ResumeLayout(false);
            this.MainMenuStrip_.PerformLayout();
            this.MainStatus.ResumeLayout(false);
            this.MainStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.ToolStrip MainMenu;
        internal System.Windows.Forms.ToolStripButton tsSystemUser;
        internal System.Windows.Forms.ToolStripButton tsProductMenu;
        internal System.Windows.Forms.ToolStripButton tsProductInventory;
        internal System.Windows.Forms.ToolStripButton tsReports;
        internal System.Windows.Forms.ToolStripButton tsOpenPos;
        internal System.Windows.Forms.ToolStripButton tsInquiry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.MenuStrip MainMenuStrip_;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sSystemMaintenance;
        private System.Windows.Forms.ToolStripMenuItem sPosSetup;
        private System.Windows.Forms.StatusStrip MainStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripStatusLabel lblUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        public System.Windows.Forms.ToolStripStatusLabel lblAccessType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel lblDate;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel lblTime;
        private System.Windows.Forms.Timer MainTimer;
        internal System.Windows.Forms.ToolStripButton tCustomer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        internal System.Windows.Forms.ToolStripButton tsPosMaintenance;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        internal System.Windows.Forms.ToolStripButton tsHousekeeping;
        private System.Windows.Forms.ToolStripMenuItem f1;
        private System.Windows.Forms.ToolStripMenuItem f2;
        private System.Windows.Forms.ToolStripMenuItem f3;
        private System.Windows.Forms.ToolStripMenuItem f4;
        private System.Windows.Forms.ToolStripMenuItem f5;
        private System.Windows.Forms.ToolStripMenuItem f6;
        private System.Windows.Forms.ToolStripMenuItem f7;
        private System.Windows.Forms.ToolStripMenuItem f8;
        private System.Windows.Forms.ToolStripMenuItem f9;
    }
}