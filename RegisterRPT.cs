using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;

namespace ADM_Management_System
{
    public partial class RegisterRPT : Form
    {
        MySqlConnection conn = DBUtils.GetDBConnection();
        public RegisterRPT()
        {
            InitializeComponent();
        }

        private void RegisterRPT_Load(object sender, EventArgs e)
        {
            GetReport();
            
            
            
        }

        void GetReport()
        {
            var sql = "SELECT (Register.TSC_No) AS Member_No,Register.Name,Register.Phone,School.Name AS School,Division.DivisionName AS Division FROM School INNER JOIN Register ON School.Tsc_No = Register.TSC_No INNER JOIN Division ON Register.Division_ID = Division.ID ORDER BY Register.TSC_No";

            conn.Open();
            MySqlDataAdapter dscmd = new MySqlDataAdapter(sql, conn);
            RegisterDS ds = new RegisterDS();
            dscmd.Fill(ds, "Register");
         
           // MessageBox.Show(ds.Tables[1].Rows.Count.ToString());
            conn.Close();

            
            crtRegister objRpt = new crtRegister();
            objRpt.SetDataSource(ds.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
