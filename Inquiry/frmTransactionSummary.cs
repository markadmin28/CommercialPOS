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
    public partial class frmTransactionSummary : Form
    {
        connString cs = new connString();
        public frmTransactionSummary()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void transListSummary()
        {
            double vatSale = 0;
            double vatExSale = 0;
            double totalSale = 0;
            double vat = 0;
            double grossPayable = 0;
            double grossSales = 0;
            double totalCash = 0;
            double totalChange = 0;
            double totalDiscountAmt = 0;
            double totalCostSales = 0;

            loadTransactionTypeID();
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("sp_inquiry_transactionSummary @dateNow = '" + dateTimePicker1.Value + "', @transactionTypeID = '" + s_transactionType.transactionType + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i =0; i <= cs.dbSearchData.Rows.Count -1; i++)
                {
                    dgw.Rows.Add((cs.dbSearchData.Rows[i][0]), cs.dbSearchData.Rows[i][1], cs.dbSearchData.Rows[i][2], cs.dbSearchData.Rows[i][3], cs.dbSearchData.Rows[i][4], cs.dbSearchData.Rows[i][5], cs.dbSearchData.Rows[i][6], cs.dbSearchData.Rows[i][7], cs.dbSearchData.Rows[i][8], cs.dbSearchData.Rows[i][9], cs.dbSearchData.Rows[i][10], cs.dbSearchData.Rows[i][11],cs.dbSearchData.Rows[i][12]);

                    vatSale += Convert.ToDouble(dgw.Rows[i].Cells[3].Value);
                    vatExSale += Convert.ToDouble(dgw.Rows[i].Cells[4].Value);
                    totalSale += Convert.ToDouble(dgw.Rows[i].Cells[5].Value);
                    vat += Convert.ToDouble(dgw.Rows[i].Cells[6].Value);
                    grossPayable += Convert.ToDouble(dgw.Rows[i].Cells[7].Value);

                    grossSales += Convert.ToDouble(dgw.Rows[i].Cells[9].Value);
                    totalCash += Convert.ToDouble(dgw.Rows[i].Cells[10].Value);
                    totalChange += Convert.ToDouble(dgw.Rows[i].Cells[11].Value);
                    totalDiscountAmt += Convert.ToDouble(dgw.Rows[i].Cells[8].Value);
                    totalCostSales += Convert.ToDouble(dgw.Rows[i].Cells[12].Value);
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
                MessageBox.Show("No data found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            txtVatSale.Text = vatSale.ToString("n2");
            txtVatExSale.Text = vatExSale.ToString("n2");
            txtTotalSale.Text = totalSale.ToString("n2");
            txtVat.Text = vat.ToString("n2");
            txtGrossPayable.Text = grossPayable.ToString("n2");
            txtGrossSales.Text = grossSales.ToString("n2");
            txtTotalCash.Text = totalCash.ToString("n2");
            txtTotalChange.Text = totalChange.ToString("n2");
            txtDiscAmt.Text = totalDiscountAmt.ToString("n2");
            ttlCostSales.Text = totalCostSales.ToString("n2");
        }
        private void transactionTypeDisplay()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("sp_transactionType_display @transactionType = ''");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                cmbTransType.Items.Clear();
                for (int i = 0; i <= cs.dbSearchData.Rows.Count - 1; i++)
                {
                    cmbTransType.Items.Add(cs.dbSearchData.Rows[i][2]);
                }
            }
            else
            {
                cmbTransType.Items.Clear();
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            transListSummary();
        }
        private void loadTransactionTypeID()
        {
            cs.connDB();
            cs.dbSearchData = cs.DISPLAY("select transactionTypeID from tbl_transactionType where transactionType = '" + cmbTransType.Text + "'");
            cs.disconMy();
            if (cs.dbSearchData.Rows.Count > 0)
            {
                s_transactionType.transactionType = Convert.ToDecimal(cs.dbSearchData.Rows[0][0]);
            }
            else
            {
                s_transactionType.transactionType = 0;
            }
        }

        private void frmTransactionSummary_Load(object sender, EventArgs e)
        {
            transactionTypeDisplay();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dgw.Rows.Clear();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
            frmTransSumRpt ftsr = new frmTransSumRpt(this);
            ftsr.ShowDialog();
        }

        private void btnCancel_Leave(object sender, EventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                dgw.Focus();
                dgw.CurrentRow.Selected = true;
            }
            else
            {
                //no action
            }
          
        }

        private void dgw_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgw.Rows.Count > 0)
            {
                dgw.CurrentRow.Selected = false;
                dateTimePicker1.Focus();
            }
        }

        private void dgw_Leave(object sender, EventArgs e)
        {
            dateTimePicker1.Focus();
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
}
