﻿using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ADM_Management_System
{
    public partial class frmUNMARK : Form
    {
        public frmUNMARK()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            var name = myFunctions.GetDelegateName(txtMemberNo.Text);
            lblName.Text = name;
        }

        private void FrmUNMARK_Load(object sender, EventArgs e)
        {

        }
        void UnMark()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                var memberNo = txtMemberNo.Text;
                var mName = myFunctions.GetDelegateName(memberNo);
                var sql = $"INSERT INTO Unmark(Member_No) VALUES('{memberNo}')";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteNonQuery();

                var sql2 = $"DELETE FROM Attendance WHERE Member_No='{memberNo}'";
                var cmd2 = new MySqlCommand(sql2, conn);
                var dr2 = cmd2.ExecuteNonQuery();

                MessageBox.Show(mName + " has been deleted!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var attNo = myFunctions.GetMemberNo(txtMemberNo.Text);

            if (txtMemberNo.Text == attNo)
            {
                UnMark();
            }
            else
            {
                MessageBox.Show("No record exist!");
            }
        }
    }
}
