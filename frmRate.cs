﻿using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ADM_Management_System
{
    public partial class frmRate : Form
    {
        public frmRate()
        {
            InitializeComponent();
        }

        private void frmRate_Load(object sender, EventArgs e)
        {

        }
        void SAVE()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                
                var year = txtYear.Text;
                var amount = txtAmount.Text;
                var sql = $"INSERT INTO Rate(Year,Amount) VALUES('{year}','{amount}') ON DUPLICATE KEY UPDATE Amount='{amount}'";
                conn.Open();

                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteNonQuery();

                MessageBox.Show(year + " " + amount + " saved succesfully");
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SAVE();
        }
    }
}