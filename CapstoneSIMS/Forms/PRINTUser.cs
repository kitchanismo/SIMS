using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace CapstoneSIMS.Forms
{
    public partial class PRINTUser : Form
    {
        public PRINTUser()
        {
            InitializeComponent();
        }

        private void PRINTUser_Load(object sender, EventArgs e)
        {
            //using (var con = SQLConnection.GetConnection())
            //{
            //    AdminDBDataSet db = new AdminDBDataSet();


            //    SqlDataAdapter da = new SqlDataAdapter("Select * from admin_customer", con);
            //    da.Fill(db, db.Tables[0].TableName);

            //    ReportDataSource rds = new ReportDataSource("admin_customer", db.Tables[0]);
            //    this.reportViewer1.LocalReport.DataSources.Clear();
            //    this.reportViewer1.LocalReport.DataSources.Add(rds);
            //    this.reportViewer1.LocalReport.Refresh();
            //    this.reportViewer1.RefreshReport();
            //}
        }


       
    }
}
