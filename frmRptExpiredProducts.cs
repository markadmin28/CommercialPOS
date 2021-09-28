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

namespace POS
{
    public partial class frmRptExpiredProducts : Form
    {
        connString cs = new connString();
        public frmRptExpiredProducts()
        {
            InitializeComponent();
        }

        private void frmRptExpiredProducts_Load(object sender, EventArgs e)
        {

            Details();
            LoadExpiredProducts();        
            this.reportViewer1.RefreshReport();
        }
        private void Details()
        {
            Product_Menu.frmExpiredProducts fpe = (Product_Menu.frmExpiredProducts)Owner;

            ReportParameter compName = new ReportParameter("companyName", posCompName.compName);
            ReportParameter compAdd = new ReportParameter("companyAddress", posAddress.address);
            ReportParameter compProp = new ReportParameter("compProp", posCompProp.compProp);
            ReportParameter dt1 = new ReportParameter("date", fpe.date1.Value.ToString("MM/dd/yyy"));
            ReportParameter dt2 = new ReportParameter("date2", fpe.date2.Value.ToString("MM/dd/yyy"));
            ReportParameter usr = new ReportParameter("user", posUserName.userName);

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { compName, compAdd, compProp, dt1, dt2, usr });
        }
        private void LoadExpiredProducts()
        {
            string expData = "";
            Product_Menu.frmExpiredProducts fpe = (Product_Menu.frmExpiredProducts)Owner;

             expData = "sp_prodExpiredProducts @start = '" + fpe.date1.Value + "',@cutOff = '" + fpe.date2.Value + "'";
            //expData = "sp_prodExpiredProducts @start = '1/1/2020',@cutOff = '1/31/2020'";
            SqlCommand COMM = new SqlCommand(expData, cs.cn);
            SqlDataAdapter sqlda = new SqlDataAdapter(COMM);
            cs.connDB();
            posDBDataSet.sp_prodExpiredProducts.Clear();
            sqlda.Fill(posDBDataSet.sp_prodExpiredProducts);
            this.reportViewer1.RefreshReport();
            cs.disconMy();

        }
    }
}
