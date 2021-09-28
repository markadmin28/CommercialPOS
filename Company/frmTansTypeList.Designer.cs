namespace POS.Company
{
    partial class frmTansTypeList
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
            this.cmbTransList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbTransList
            // 
            this.cmbTransList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTransList.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTransList.FormattingEnabled = true;
            this.cmbTransList.Location = new System.Drawing.Point(12, 12);
            this.cmbTransList.Name = "cmbTransList";
            this.cmbTransList.Size = new System.Drawing.Size(315, 33);
            this.cmbTransList.TabIndex = 1;
            this.cmbTransList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTransList_KeyDown);
            // 
            // frmTansTypeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 65);
            this.Controls.Add(this.cmbTransList);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmTansTypeList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Transaction Type";
            this.Load += new System.EventHandler(this.frmTansTypeList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox cmbTransList;
    }
}