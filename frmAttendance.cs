using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ADM_Management_System
{
    public partial class frmAttendance : Form
    {
        MySqlConnection conn = DBUtils.GetDBConnection();
        public frmAttendance()
        {
            InitializeComponent();
        }

        private void frmAttendance_Load(object sender, EventArgs e)
        {
            txtFind.Focus();
            ATTENDANCE();
        }
        void FIND_MEMBER()
        {
            try
            {
                var tsc = txtFind.Text;
                var sql = $"SELECT Register.`Name`,School.`Name` AS School,Division.DivisionName AS Division FROM Register INNER JOIN School ON School.Tsc_No = Register.TSC_No INNER JOIN Division ON Register.Division_ID = Division.ID WHERE Register.TSC_No = '{tsc}'";

                conn.Open();

                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lblDivision.Text = dr.GetString("Division");
                    lblName.Text = dr.GetString("Name");
                    lblSchool.Text = dr.GetString("School");
                }
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
        void ATTENDANCE()
        {
            try
            {
                var sql = "SELECT (Attendance.Date) AS Date,CONCAT(Register.`Name`, ' _ ', '[', Attendance.Member_No, ']', ' _ ', School.`Name`) AS Description,Attendance.Amount FROM Attendance INNER JOIN Register ON Attendance.Member_No = Register.TSC_No INNER JOIN School ON School.Tsc_No = Register.TSC_No ORDER BY Attendance.Date ASC";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var lst = lvAttendance.Items.Add(dr.GetString("Date"));
                    lst.SubItems.Add(dr.GetString("Description"));
                    lst.SubItems.Add(dr.GetString("Amount"));
                }

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

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            FIND_MEMBER();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmDelegate d = new frmDelegate();
            d.btnAddEdit.Text = "NEW";
            d.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            EDIT_DELEGATE();
         
            
        }

        void EDIT_DELEGATE()
        {
            try
            {
                var tsc = txtFind.Text;
                var sql = $"SELECT Register.TSC_No,Register.ID_Number,Register.`Name`,Register.Phone,School.`Name` AS School,Status_Code.`Status`,(Division.DivisionName) AS Division FROM Register INNER JOIN Division ON Register.Division_ID = Division.ID INNER JOIN School ON School.Tsc_No = Register.TSC_No INNER JOIN Status_Code ON Register.`Status` = Status_Code.Status_Code WHERE Register.TSC_No = '{tsc}' ";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    frmDelegate d = new frmDelegate();

                    d.txtName.Text = dr.GetString("Name");
                    d.Text = dr.GetString("Name");
                    d.txtTSC.Text = dr.GetString("TSC_No");
                    d.txtIDNumber.Text = dr.GetString("ID_Number");
                    d.txtPhone.Text = dr.GetString("Phone");
                    d.txtSchool.Text = dr.GetString("School");
                    d.txtDivision.Text = dr.GetString("Division");
                    d.txtStatus.Text = dr.GetString("Status");
                    // d.cmbStatusCode.Text = dr.GetString("Code");

                    d.ShowDialog();
                }
                dr.Dispose();
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
    }
}
