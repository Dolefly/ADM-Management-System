﻿using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
        }
        void GetReport()
        {
            var sql = "SELECT (Attendance.Date) AS Date,CONCAT(Register.`Name`, ' _ ', '[', Attendance.Member_No, ']', ' _ ', School.`Name`) AS Narration,Attendance.Amount FROM Attendance INNER JOIN Register ON Attendance.Member_No = Register.TSC_No INNER JOIN School ON School.Tsc_No = Register.TSC_No UNION SELECT e.Date,e.Narration,e.Amount FROM Expense e ORDER BY Date ASC";

            conn.Open();
            MySqlDataAdapter dscmd = new MySqlDataAdapter(sql, conn);
            TransDS ds = new TransDS();
            dscmd.Fill(ds, "Transaction");

            // MessageBox.Show(ds.Tables[1].Rows.Count.ToString());
            conn.Close();


            crtTrans objRpt = new crtTrans();
            objRpt.SetDataSource(ds.Tables[1]);
            crystalReportViewer1.ReportSource = objRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
