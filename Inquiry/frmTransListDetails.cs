using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Inquiry
{
    public partial class frmTransListDetails : Form
    {
        connString cs = new connString();
        public int voidStat = 0;
        string voidStatus = "";

        frmTransList ft = null;

        public frmTransListDetails( frmTransList _ft)
        {
            InitializeComponent();
            ft = _ft;
        }

        private void frmTransListDetails_Load(object sender, EventArgs e)
        {
            if (dgw.Rows.Count >0)
            {
                dgw.CurrentRow.Selected = false;
            }
            else
            {
                //no action
            }
            if (voidStat == 1)
            {
                btnVoid.Text = "Unvoi&d";
                voidStatus = "unvoid";
                lblVoid.Show();
            }
            else
            {
                btnVoid.Text = "Voi&d";
                voidStatus = "void";
                lblVoid.Visible = false;
            }
        
        }
        public void transListDetails(decimal transID)
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("inquiry_transactionListDetails @transID = '" + transID + "' ");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i =0; i<= cs.dbSearchData.Rows.Count -1; i++)
                {
                    dgw.Rows.Add((cs.dbSearchData.Rows[i][0]),cs.dbSearchData.Rows[i][3], cs.dbSearchData.Rows[i][4], cs.dbSearchData.Rows[i][5], cs.dbSearchData.Rows[i][6], cs.dbSearchData.Rows[i][7], cs.dbSearchData.Rows[i][8]);
                }
                    
            }
            else
            {
                dgw.Rows.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmTransListDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void dgw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dgw.CurrentRow.Selected = false;
            }
            else
            {
                //no action
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printingCommand();
        }
        private void printingCommand()
        {            
            if (receipt_settings.receiptSettings == 1) // checking if access is direct print or not
            {
                string voidLabel = "";
                if (voidStat == 1)
                {
                    voidLabel = "***Voided!***";
                }
                else
                {
                    voidLabel = "";
                }
                try
                {
                    ft.CustomerReceiptPrintData(Convert.ToDecimal(txtTransID.Text), voidLabel);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {              
                Receipt.frmRptReceipt frcpt = new Receipt.frmRptReceipt();
                if (voidStat == 1)
                {
                    frcpt.voidStatus = "***Voided!***";
                }
                else
                {
                    frcpt.voidStatus = "";
                }
                frcpt.transID = Convert.ToDecimal(txtTransID.Text);
                frcpt.cusRcptType = 1;              
                frcpt.ShowDialog();
            }

        }
        private void printCommand()
        {
           Receipt.frmRptReceipt frcpt = new Receipt.frmRptReceipt();
            if (voidStat == 1)
            {
                frcpt.voidStatus = "***Voided!***";
            }
            else
            {
                frcpt.voidStatus = "";
            }
            frcpt.transID = Convert.ToDecimal(txtTransID.Text);
            frcpt.cusRcptType= 1;
            frcpt.displayCustomerReceipt();
            frcpt.rcptParameterData();
            frcpt.reportViewer1.RefreshReport();
            frcpt.autoPrint_CusReceipt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            voidCommand();
        }
        
        private void voidCommand()
        {
            DialogResult res;

            if (voidStat == 1)
            {
                res = MessageBox.Show("Are you sure you want to unvoid this transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    cs.connDB();
                    cs.updateData = "prodDailySales_void @Action = '" + voidStatus + "',@transID = '" + txtTransID.Text + "'";
                    cs.IUD(cs.updateData);
                    cs.disconMy();
                    MessageBox.Show("Transaction unvoided", "Database message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Dispose();
                    ft.button1.PerformClick();
                }
                else
                {
                    return;
                }
            }
            else
            {
                res = MessageBox.Show("Are you sure you want to void this transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    cs.connDB();
                    cs.updateData = "prodDailySales_void @Action = '" + voidStatus + "',@transID = '" + txtTransID.Text + "'";
                    cs.IUD(cs.updateData);
                    cs.disconMy();
                    MessageBox.Show("Transaction voided", "Database message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    voidStat = 1;
                    if (receipt_settings.receiptSettings == 1)
                    {
                        //direct print
                        printCommand();
                    }
                    else
                    {
                        //print preview
                        printingCommand();
                    }
                    
                    this.Dispose();
                    ft.button1.PerformClick();
                }
                else
                {
                    return;
                }
            }
        }
      
    }
}
