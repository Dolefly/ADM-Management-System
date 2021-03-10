using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ADM_Management_System
{
    public partial class TransRPT : Form
    {
        MySqlConnection conn = DBUtils.GetDBConnection();
        public TransRPT()
        {
            InitializeComponent();
        }

        private void TransRPT_Load(object sender, EventArgs e)
        {
          GetReport();
            SetTitle();
        }
        void GetReport()
        {
            var sql = "";
            var title = "";
            var admYear = DateTime.Now.Year;
            try
            {
                if (comboBox1.Text == "ALL")
                {
                        sql = "SELECT DATE_FORMAT(Attendance.Date,GET_FORMAT(DATE,'EUR')) AS Date,CONCAT(Register.`Name`, ' _ ', '[', Attendance.Member_No, ']', ' _ ', School.`Name`) AS Narration,Attendance.Amount FROM Attendance INNER JOIN Register ON Attendance.Member_No = Register.TSC_No INNER JOIN School ON School.Tsc_No = Register.TSC_No UNION SELECT DATE_FORMAT(Expense.Date, GET_FORMAT(DATE,'EUR')) AS Date,Expense.Narration,Expense.Amount FROM Expense ORDER BY Date ASC";

                    title = "ALL PAYOUTS - ADM " + admYear;
                }
                else if(comboBox1.Text=="PETTY CASH")
                {
                    sql = "SELECT DATE_FORMAT(Expense.Date,GET_FORMAT(DATE,'EUR')) AS Date,(Expense.Narration) AS Narration,Expense.Amount FROM Expense ORDER BY Expense.Date";
                    title = "PETTY CASH PAYOUTS - ADM " + admYear;
                }
                else if(comboBox1.Text == "DELEGATES")
                {
                    sql = "SELECT DATE_FORMAT(Attendance.Date,GET_FORMAT(DATE,'EUR')) AS Date,CONCAT(Register.`Name`,'_','[',Attendance.Member_No,']','_', School.`Name`) AS Narration, Attendance.Amount FROM Attendance INNER JOIN Register ON Attendance.Member_No = Register.TSC_No INNER JOIN School ON Register.TSC_No = School.Tsc_No;";
                    title = "DELEGATES PAYOUTS - ADM " + admYear;
                }
                else
                {
                    sql = "SELECT DATE_FORMAT(Attendance.Date,GET_FORMAT(DATE,'EUR')) AS Date,CONCAT(Register.`Name`, ' _ ', '[', Attendance.Member_No, ']', ' _ ', School.`Name`) AS Narration,Attendance.Amount FROM Attendance INNER JOIN Register ON Attendance.Member_No = Register.TSC_No INNER JOIN School ON School.Tsc_No = Register.TSC_No UNION SELECT DATE_FORMAT(Expense.Date, GET_FORMAT(DATE,'EUR')) AS Date,Expense.Narration,Expense.Amount FROM Expense ORDER BY Date ASC";
                    title = "ALL PAYOUTS - ADM " + admYear;
                }
                conn.Open();
                MySqlDataAdapter dscmd = new MySqlDataAdapter(sql, conn);
                TransDS ds = new TransDS();
                dscmd.Fill(ds, "Transaction");

                // MessageBox.Show(ds.Tables[1].Rows.Count.ToString());
                conn.Close();


                crtTrans objRpt = new crtTrans();
                objRpt.SetDataSource(ds.Tables[1]);
                objRpt.SummaryInfo.ReportTitle = title;
                crystalReportViewer1.ReportSource = objRpt;
                crystalReportViewer1.Refresh();

                ds.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        void SetTitle()
        {

            crtTrans sTitle = new crtTrans();
            sTitle.SummaryInfo.ReportTitle = "TEST";
           // crystalReportViewer1.ReportSource = sTitle;
           // crystalReportViewer1.Refresh();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetReport();
        }
    }
}
