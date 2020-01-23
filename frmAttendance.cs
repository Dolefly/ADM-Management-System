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

            tspRate.Text = GetRate();
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

        public static string GetRate()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            string returnValue = null;
           try
            {
               
                
                var sql = "SELECT Amount FROM Rate WHERE Year='2020'";
                conn.Open();
                var cmd = new MySqlCommand(sql,conn);
                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    returnValue = dr.GetString("Amount");
                    dr.Dispose();
                    
                }
                else
                {
                   return "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return returnValue;
        }

        public static string GetRetired(string TSC_No)//SELECT MEMBER STATUS EITHER RETIRED or WITHDRAWN
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            string retiredValue = null;
            
            try
            {
                var sql = $"SELECT Status FROM Register WHERE TSC_No='{TSC_No}'";
                conn.Open();

                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    retiredValue = dr.GetString("Status");
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
            return retiredValue;
        } 



        void INSERT_ATTENDANCE()
        {
           try
           {
                var myDate = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd");
                var tsc = txtFind.Text;
                var amount = GetRate(); 

                var sql = $"INSERT INTO Attendance(Date,Member_No,Amount) VALUES('{myDate}','{tsc}','{amount}')";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteNonQuery();

                MessageBox.Show(lblName.Text + " marked as present.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }//Mark delegate as present
        void ATTENDANCE()
        {
            try
            {
                var sql = "SELECT (Attendance.Date) AS Date,CONCAT(Register.`Name`, ' _ ', '[', Attendance.Member_No, ']', ' _ ', School.`Name`) AS Description,Attendance.Amount FROM Attendance INNER JOIN Register ON Attendance.Member_No = Register.TSC_No INNER JOIN School ON School.Tsc_No = Register.TSC_No ORDER BY Attendance.Date ASC";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                lvAttendance.Items.Clear();

                while (dr.Read())
                {
                    var lst = lvAttendance.Items.Add(dr.GetString("Date"));
                    lst.SubItems.Add(dr.GetString("Description"));
                   // lst.SubItems.Add(dr.GetString("Amount"));
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

        private void Button1_Click(object sender, EventArgs e)
        {
            var memberNO = txtFind.Text;
            var tsc = GetRetired(memberNO);

            if (tsc =="50")
            {
                MessageBox.Show(lblName.Text + " is retired member");
            }
            else
            {
                if (txtFind.Text != "")
                {
                    if(lblName.Text != "")
                    {
                        INSERT_ATTENDANCE();
                        ATTENDANCE();
                    }
                    else
                    {
                        MessageBox.Show("Member number doesn't exist!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nobody to mark as present!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
