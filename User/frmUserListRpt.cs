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

namespace POS.User
{
    public partial class frmUserListRpt : Form
    {
        string searchData = "";
        public string userKeyword = "";
        connString cs = new connString();
        public frmUserListRpt()
        {
            InitializeComponent();
        }

        private void frmUserListRpt_Load(object sender, EventArgs e)
        {
            CompInfoParameter();
            UserList(userKeyword);          
            this.reportViewer1.RefreshReport();
        }
        private void UserList(string keyword)
        {
            searchData = "select  userID ,userFullName ,userName ,(select userFullName from tbl_user where userID = tu.userAddedBy) as [Addedby] ,userDateAdded ,userType ,case when isActive = 1 then 'YES' else 'NO' end as [Active]  ,userAddedBy,userPassword from tbl_user tu where (userFullName like '%" + keyword + "%' or userID like '%" + keyword + "%' or userName like '%" + keyword + "%' or userType like '%" + keyword + "%') and isDeleted =0";
            DataConn();
        }
        private void DataConn()
        {
           
            SqlCommand COMM = new SqlCommand(searchData, cs.cn);
            SqlDataAdapter SQLDA = new SqlDataAdapter(COMM);
            cs.connDB();
            this.posDBDataSet.tbl_userList.Clear();
            SQLDA.Fill(posDBDataSet.tbl_userList);
            this.reportViewer1.RefreshReport();
            cs.disconMy();
        }
        private void CompInfoParameter()
        {
            ReportParameter compName = new ReportParameter("companyName",posCompName.compName);
            ReportParameter compAddress = new ReportParameter("companyAddress", posAddress.address);
            ReportParameter compProp = new ReportParameter("compProp", posCompProp.compProp);
            ReportParameter datePrinted = new ReportParameter("datePrinted", DateTime.Now.ToString());
            ReportParameter printedBy = new ReportParameter("printedBy", posUserName.userName);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { compName,compAddress,compProp,datePrinted,printedBy});
        }

        private void frmUserListRpt_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
