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
    public partial class frmRptClerkReport : Form
    {
        connString cs = new connString();
        public frmRptClerkReport()
        {
            InitializeComponent();
        }

        private void frmRptClerkReport_Load(object sender, EventArgs e)
        {
            LoadClerkReport();
            ParamData();
            this.reportViewer1.RefreshReport();
        }
        private void LoadClerkReport()
        {
            frmClerkReport fc = (frmClerkReport)Owner;

            string loadData = "";           
            string action = "";
            if (fc.cmbTransType.Text == "")
            {
                action = "all";
            }
            else
            {
                action = "specific";
            }           
           loadData ="sp_temppassclerkreport @action = '" + action + "', @start = '" + fc.dateTimePicker1.Value + "', @cutOff = '" + fc.dateTimePicker2.Value + "',@transTypeDesc = '" + fc.cmbTransType.Text.ToString() + "'";
            cs.connDB();
            SqlCommand COMM = new SqlCommand(loadData,cs.cn);
            SqlDataAdapter sqlda = new SqlDataAdapter(COMM);
            posDBDataSet.sp_TempPassClerkReport.Clear();
            sqlda.Fill(posDBDataSet.sp_TempPassClerkReport);
            this.reportViewer1.Refresh();
            cs.disconMy();
        }
        private void ParamData()
        {
            frmClerkReport fc = (frmClerkReport)Owner;
            ReportParameter dt = new ReportParameter("date", fc.dateTimePicker1.Value.ToString("MM/dd/yyy"));
            ReportParameter dt2 = new ReportParameter("date2", fc.dateTimePicker2.Value.ToString("MM/dd/yyy"));
            ReportParameter usr = new ReportParameter("user", posUserName.userName.ToString());
            ReportParameter cn = new ReportParameter("companyName", posCompName.compName.ToString());
            ReportParameter ca = new ReportParameter("companyAddress", posAddress.address.ToString());
            ReportParameter cp = new ReportParameter("compProp", posCompProp.compProp.ToString());
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { dt,dt2,usr,cn,ca,cp});
        }
    }
}
