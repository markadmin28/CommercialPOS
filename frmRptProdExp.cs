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
    public partial class frmRptProdExp : Form
    {
        connString cs = new connString();
        public frmRptProdExp()
        {
            InitializeComponent();
        }

        private void frmRptProdExp_Load(object sender, EventArgs e)
        {
            LoadProdExpData();
            Details();
            this.reportViewer1.RefreshReport();
        }
        private void Details()
        {
            Product_Menu.frmProdExpiration fpe = (Product_Menu.frmProdExpiration)Owner;

            ReportParameter compName = new ReportParameter("companyName", posCompName.compName);
            ReportParameter compAdd = new ReportParameter("companyAddress",posAddress.address);
            ReportParameter compProp = new ReportParameter("compProp", posCompProp.compProp);
            ReportParameter dt = new ReportParameter("date", DateTime.Now.ToString("MM/dd/yyy"));
            ReportParameter usr = new ReportParameter("user", posUserName.userName);
            ReportParameter dys = new ReportParameter("days",fpe.txtNoOfDays.Text);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { compName , compAdd,compProp,dt,usr ,dys});
        }
        private void LoadProdExpData()
        {
            int noOfDays = 0;
            string expData = "";
            Product_Menu.frmProdExpiration fpe = (Product_Menu.frmProdExpiration)Owner;
            noOfDays = Convert.ToInt32(fpe.txtNoOfDays.Text);
            


            expData = "sp_prodExpiredProductsDisplay @dateNow = '" + fpe.dtNow.Value + "',@noOfDay = '" + noOfDays + "'";
            SqlCommand COMM = new SqlCommand(expData , cs.cn);
            SqlDataAdapter sqlda = new SqlDataAdapter(COMM);
            cs.connDB();
            posDBDataSet.sp_prodExpiredProductsDisplay.Clear();
            sqlda.Fill(posDBDataSet.sp_prodExpiredProductsDisplay);
            this.reportViewer1.RefreshReport();
            cs.disconMy();

        }

    }
}
