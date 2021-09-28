using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Billing
{
    public partial class frmPassDataList : Form
    {
        connString cs = new connString();
        DataTable orderList = new DataTable();

        Product_Menu.frmPos fp = null;
        public frmPassDataList(Product_Menu.frmPos _fp)
        {
            InitializeComponent();
            fp = _fp;
        }

        private void frmPassDataList_Load(object sender, EventArgs e)
        {
            loadOrderList();
        }
        private void loadOrderList()
        {
            DateTime dt = DateTime.Now;
            DataTable ol = new DataTable();
            ol = orderList;
            
            cs.connDB();
            ol = cs.DISPLAY("sp_temppassdatatransdisplay @dt = '" + dt + "' , @transTypeID = '" + s_transactionType.transactionType + "'");
            cs.disconMy();
            if (ol.Rows.Count > 0)
            {
                dgvOl.Rows.Clear();
                for (int i =0; i <= ol.Rows.Count -1; i++)
                {
                    dgvOl.Rows.Add((ol.Rows[i][0]),ol.Rows[i][1], ol.Rows[i][2],ol.Rows[i][3], ol.Rows[i][4]);
                }                
            }
            else
            {
                dgvOl.Rows.Clear();
            }
            
        }

        private void dgvOl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                this.Dispose();
            }
            if (e.KeyCode == Keys.Enter)
            {
                
                    if (dgvOl.Rows.Count > 0)
                    {

                        if (dgvOl.CurrentRow.Cells[4].Value.ToString() == "")
                        {
                            //no action
                        }
                        else
                        {
                            string action = "Insert";
                            string msg = "";
                            string nNoteType = "CustomerName";
                            string nullValue = "";
                            fp.isPassed = true;
                      
                            fp.customerName = dgvOl.CurrentRow.Cells[4].Value.ToString();
                            fp.CustomerNameCommand(action, msg, fp.customerName, nNoteType, nullValue, nullValue, nullValue, nullValue, 0);
                        }

                        fp.passDataOrderId = Convert.ToDecimal(dgvOl.CurrentRow.Cells[3].Value);
                        fp.LoadPassData();
                        fp.passDataSaveTempBilling();

                        this.Dispose();
                    }
                    else
                    {
                        //no action
                    }
                               
            }
        }

        private void frmPassDataList_Activated(object sender, EventArgs e)
        {
            loadOrderList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadOrderList();
        }

        private void dgvOl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
