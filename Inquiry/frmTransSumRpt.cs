using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace POS.Inquiry
{
    public partial class frmTransSumRpt : Form
    {
        string searchData;
        frmTransactionSummary fts = null;
        connString cs = new connString();
        SqlCommand COMM = new SqlCommand();
        SqlDataAdapter SQLDA = new SqlDataAdapter();

        public frmTransSumRpt(frmTransactionSummary _fts)
        {
            InitializeComponent();
            fts = _fts;
        }

        private void frmTransSumRpt_Load(object sender, EventArgs e)
        {
            transactionSummaryReport();
            parameterData();
            this.reportViewer1.RefreshReport();
        }
        private void transactionSummaryReport()
        {
            searchData = "sp_inquiry_transactionSummary @dateNow = '" + fts.dateTimePicker1.Value + "', @transactionTypeID = '" + s_transactionType.transactionType + "'";
            dataConn();
        }
        private void dataConn()
        {
            cs.connDB();
            COMM = new SqlCommand(searchData, cs.cn);
            SQLDA = new SqlDataAdapter(COMM);
            posDBDataSet.sp_inquiry_transactionSummary.Clear();
            SQLDA.Fill(posDBDataSet.sp_inquiry_transactionSummary);
            this.reportViewer1.RefreshReport();
            cs.disconMy();
        }
        private void parameterData()
        {
            ReportParameter compName = new ReportParameter("compName", posCompName.compName);
            ReportParameter compAdd = new ReportParameter("compAddress", posAddress.address);
            ReportParameter dt = new ReportParameter("date", fts.dateTimePicker1.Value.ToString());
            ReportParameter compProp = new ReportParameter("compProp",posCompProp.compProp);
            ReportParameter printedBy = new ReportParameter("printedBy", posUserName.userName);            
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { compName, compAdd, dt ,compProp, printedBy});
        }
    }
}
