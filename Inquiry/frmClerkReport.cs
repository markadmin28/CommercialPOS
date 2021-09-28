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
    public partial class frmClerkReport : Form
    {
        connString cs = new connString();
        public frmClerkReport()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmClerkReport_Load(object sender, EventArgs e)
        {
            transactionTypeDisplay();
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
        private void LoadClerkReport()
        {
            DataTable dt = new DataTable();
            int rowNo = 0;
            string action = "";
            if (cmbTransType.Text == "")
            {
                action = "all";
            }
            else
            {
                action = "specific";
            }

            cs.connDB();
            dt = cs.DISPLAY("sp_temppassclerkreport @action = '" + action + "', @start = '" + dateTimePicker1.Value + "', @cutOff = '" + dateTimePicker2.Value + "' ,@transTypeDesc = '" + cmbTransType.Text.ToString() + "'");
            cs.disconMy();
            if (dt.Rows.Count > 0)
            {
                dgw.Rows.Clear();
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    dgw.Rows.Add((rowNo), dt.Rows[i][1], dt.Rows[i][0], dt.Rows[i][2]);
                    rowNo += 1;
                    dgw.Rows[i].Cells[0].Value = rowNo;
                    dgw.Rows[i].Cells[0].Style.ForeColor = Color.Maroon;
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

        private void button1_Click(object sender, EventArgs e)
        {
            LoadClerkReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmRptClerkReport fc = new frmRptClerkReport();
            fc.Owner = this;
            fc.ShowDialog();
        }
    }
}
