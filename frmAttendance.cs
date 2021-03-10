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
            GetAttendance();
            getExpenses();
            var myRate = GetRate();
            if (myRate != "")
            {
                tspRate.Text = GetRate();
            }
            else
            {
                DialogResult rs = MessageBox.Show("It seems payment Rate has not been set, Click YES to set now or Click NO to set later!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(rs == DialogResult.Yes)
                {
                    frmRate fr = new frmRate();
                    fr.ShowDialog();
                }
                    else if (rs == DialogResult.No)
                {

                }
            }
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
                if (dr.Read())
                {
                    lblDivision.Text = dr.GetString("Division");
                    lblName.Text = dr.GetString("Name");
                    lblSchool.Text = dr.GetString("School");
                }
                else
                {
                    lblName.Text = "";
                    lblDivision.Text = "";
                    lblSchool.Text = "";
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
        }//Main Method

        public static string GetRate()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            var rate = DateTime.Now.Year;
            string returnValue = null;
           try
            {
                
                var sql = $"SELECT Amount FROM Rate WHERE Year='{rate}'";
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
        }//Payout rates for delegates sitting allowances

        public static string GetStatus(string TSC_No)//SELECT MEMBER STATUS EITHER RETIRED or WITHDRAWN
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

                MessageBox.Show(lblName.Text + " successfuly marked!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
            catch(Exception ex) {
                MessageBox.Show(lblName.Text + " has already been marked as present!","Confirmation",MessageBoxButtons.OK,MessageBoxIcon.Error  );
            }
            finally
            {
                conn.Close();
            }
        }//Mark delegate as present
        void GetAttendance()
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
                    var lst = lvAttendance.Items.Add(dr.GetDateTime("Date").ToString("dd/MM/yyyy"));
                    lst.SubItems.Add(dr.GetString("Description"));
                    //lst.SubItems.Add(dr.GetString("Amount"));
                }
                dr.Dispose();

                var sql2 = "SELECT COUNT(*) AS Delegates FROM Attendance";
                var cmd2 = new MySqlCommand(sql2, conn);
                var dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {
                    tspDelegates.Text = dr2.GetString("Delegates");
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
        void Find_Attendance()
        {
            var tsc = txtLookUP.Text;
            try
            {
                var sql = $"SELECT (Attendance.Date) AS Date,CONCAT(Register.`Name`, ' _ ', '[', Attendance.Member_No, ']', ' _ ', School.`Name`) AS Description,Attendance.Amount FROM Attendance INNER JOIN Register ON Attendance.Member_No = Register.TSC_No INNER JOIN School ON School.Tsc_No = Register.TSC_No WHERE Attendance.Member_No='{tsc}' ORDER BY Attendance.Date ASC";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                lvAttendance.Items.Clear();

                if (dr.Read())
                {
                    var lst = lvAttendance.Items.Add(dr.GetDateTime("Date").ToString("dd/MM/yyyy"));
                    lst.SubItems.Add(dr.GetString("Description"));
                    //lst.SubItems.Add(dr.GetString("Amount"));
                }
                else
                {
                    MessageBox.Show("No records found for Member No:"+ tsc + " , Check and try again!","Confirmation",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                dr.Dispose();

                var sql2 = "SELECT COUNT(*) AS Delegates FROM Attendance";
                var cmd2 = new MySqlCommand(sql2, conn);
                var dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {
                    tspDelegates.Text = dr2.GetString("Delegates");
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
        }

        void FindExpenses()
        {
            var amount = txtLookUP.Text;
            try
            {
                var sql = $"SELECT Expense.Date,Expense.Narration,Expense.Amount FROM Expense WHERE Expense.Amount ='{amount}'";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                lvExpense.Items.Clear();

                while(dr.Read())
                {
                    var lst = lvExpense.Items.Add(dr.GetDateTime("Date").ToString("dd/MM/yyyy"));
                    lst.SubItems.Add(dr.GetString("Narration"));
                    lst.SubItems.Add(dr.GetString("Amount"));
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
        }

        void getExpenses()
        {
            try
            {
                var sql = "SELECT Expense.Date,Expense.Narration,Expense.Amount FROM Expense ORDER BY Expense.Date ASC";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                lvExpense.Items.Clear();

                while (dr.Read())
                {
                    var lst = lvExpense.Items.Add(dr.GetDateTime("Date").ToString("dd/MM/yyyy"));
                    lst.SubItems.Add(dr.GetString("Narration"));
                    lst.SubItems.Add(dr.GetString("Amount"));
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
            var tsc = GetStatus(memberNO);

            if (tsc =="50")
            {
                MessageBox.Show(lblName.Text + " is retired member","Confirmation",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            
            else if (tsc == "20")
            {
                MessageBox.Show(lblName.Text + " has WITHDRAWN for the society!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tsc == "30")
            {
                MessageBox.Show(lblName.Text + " has been TRANSFERED and no longer our delegate!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (tsc == "40")
            {
                MessageBox.Show(lblName.Text + " is a DECEASED member!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(tsc == "10")
            {
                if (txtFind.Text != "")
                {
                    if(lblName.Text != "")
                    {
                        INSERT_ATTENDANCE();
                        GetAttendance();
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

        private void TxtFind_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            frmExpense ex = new frmExpense();
            ex.ShowDialog();
        }

        private void TxtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtLookUP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            TransRPT tr = new TransRPT();
            tr.ShowDialog();
        }

        private void LvAttendance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvAttendance.SelectedItems.Count > 0)
            {
                btnUnMark.Enabled = true;
            }
            else
            {
                btnUnMark.Enabled = false;
            }
          
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetAttendance();
            getExpenses();
        }

        private void BtnLookUp_Click(object sender, EventArgs e)
        {
            if (txtLookUP.Text != "")
            {
                if (cmbType.Text == "")
                {
                    MessageBox.Show("Select filter type first!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (cmbType.Text == "DELEGATE")
                {
                    Find_Attendance();
                }
                else if (cmbType.Text == "TRANSACTION")
                {
                    FindExpenses();
                }
            }
            else
            {
                MessageBox.Show("Enter value to find", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnUnMark_Click(object sender, EventArgs e)
        {
            frmUNMARK un = new frmUNMARK();
            btnUnMark.Enabled = false;
            un.ShowDialog();
            
        }
    }
}
