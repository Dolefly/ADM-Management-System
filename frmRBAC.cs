using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace ADM_Management_System
{
    public partial class frmRBAC : Form
    {
        public frmRBAC()
        {
            InitializeComponent();
        }

        private void FrmRBAC_Load(object sender, EventArgs e)
        {
            GetUserNames();
            GetRoles();
            GetPrivileges();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
        void GetRoles()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                var sql = "SELECT * FROM role ORDER BY role_name ASC";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                cmbRole.Items.Clear();
                while (dr.Read())
                {
                    cmbRole.Items.Add(dr.GetString("role_Name"));

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
        void GetUserNames()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                var sql = "SELECT * FROM SystemUser ORDER BY Username ASC";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                cmbUserName.Items.Clear();
                while (dr.Read())
                {
                    cmbUserName.Items.Add(dr.GetString("Username"));

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
        void GetPrivileges()
        {

            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                var sql = "SELECT * FROM resource ORDER BY resource_name ASC";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                lvPrivileges.Items.Clear();
                while (dr.Read())
                {
                    var lv = lvPrivileges.Items.Add(dr.GetString("resource_name"));
                 

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
    }
}
