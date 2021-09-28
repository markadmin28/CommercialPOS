namespace POS.SysMaintenance
{
    partial class frmDbConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDbConfig));
            this.txtServerHost = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtServerHost
            // 
            this.txtServerHost.BackColor = System.Drawing.SystemColors.Info;
            this.txtServerHost.Location = new System.Drawing.Point(98, 12);
            this.txtServerHost.Name = "txtServerHost";
            this.txtServerHost.PasswordChar = '*';
            this.txtServerHost.Size = new System.Drawing.Size(282, 25);
            this.txtServerHost.TabIndex = 24;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Info;
            this.txtUserName.Location = new System.Drawing.Point(98, 39);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PasswordChar = '*';
            this.txtUserName.Size = new System.Drawing.Size(282, 25);
            this.txtUserName.TabIndex = 26;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(11, 42);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(74, 17);
            this.Label2.TabIndex = 30;
            this.Label2.Text = "Username :";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(11, 95);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(70, 17);
            this.Label4.TabIndex = 32;
            this.Label4.Text = "Database :";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(11, 68);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(71, 17);
            this.Label3.TabIndex = 31;
            this.Label3.Text = "Password :";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Info;
            this.txtPassword.Location = new System.Drawing.Point(98, 65);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(282, 25);
            this.txtPassword.TabIndex = 27;
            // 
            // txtDatabase
            // 
            this.txtDatabase.BackColor = System.Drawing.SystemColors.Info;
            this.txtDatabase.Location = new System.Drawing.Point(98, 92);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.PasswordChar = '*';
            this.txtDatabase.Size = new System.Drawing.Size(282, 25);
            this.txtDatabase.TabIndex = 28;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(11, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(83, 17);
            this.Label1.TabIndex = 29;
            this.Label1.Text = "Server Host :";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(297, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 30);
            this.button2.TabIndex = 36;
            this.button2.Text = "&Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(206, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 30);
            this.button1.TabIndex = 35;
            this.button1.Text = "&Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTest
            // 
            this.btnTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTest.Image = ((System.Drawing.Image)(resources.GetObject("btnTest.Image")));
            this.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest.Location = new System.Drawing.Point(117, 123);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(83, 30);
            this.btnTest.TabIndex = 34;
            this.btnTest.Text = "&Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(14, 123);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 30);
            this.button3.TabIndex = 37;
            this.button3.Text = "&Restore";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmDbConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 167);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtServerHost);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.Label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmDbConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database configuration";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDbConfig_FormClosed);
            this.Load += new System.EventHandler(this.frmDbConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.TextBox txtServerHost;
        internal System.Windows.Forms.TextBox txtUserName;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.TextBox txtDatabase;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button button3;
    }
}