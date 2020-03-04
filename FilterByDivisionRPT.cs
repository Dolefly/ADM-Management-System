using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ADM_Management_System
{
    public partial class FilterByDivisionRPT : Form
    {
        public FilterByDivisionRPT()
        {
            InitializeComponent();
        }

        private void FilterByDivisionRPT_Load(object sender, EventArgs e)
        {
            GetReport();
        }
        void GetReport()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            var DivID = lblDivisionID.Text;
            var sql = $"SELECT (Register.TSC_No) AS Member_No,Register.Name,Register.Phone,School.Name AS School,Division.DivisionName AS Division FROM School INNER JOIN Register ON School.Tsc_No = Register.TSC_No INNER JOIN Division ON Register.Division_ID = Division.ID WHERE Register.Division_ID='{DivID}' ORDER BY Register.TSC_No";

            conn.Open();
            MySqlDataAdapter dscmd = new MySqlDataAdapter(sql, conn);
            FilterByDivision ds = new FilterByDivision();
            dscmd.Fill(ds, "Register");

            // MessageBox.Show(ds.Tables[1].Rows.Count.ToString());
            conn.Close();


            crtFilterByDivision objRpt = new crtFilterByDivision();
            objRpt.SetDataSource(ds.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
