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

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            FIND_MEMBER();
        }
    }
}
