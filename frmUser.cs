using System;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ADM_Management_System
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            GetUsers();
            GetRoles();
        }
        void GetRoles()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                var sql = "SELECT * FROM role ORDER BY role_name ASC";
                
                conn.Open();

                var cmd = new MySqlCommand(sql,conn);
                var dr = cmd.ExecuteReader();
                cmbRole.Items.Clear();
                while (dr.Read())
                {
                    cmbRole.Items.Add(dr.GetString("role_name"));
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
        void GetRoleID()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                var roleName = cmbRole.SelectedItem;
                var sql = $"SELECT * FROM role WHERE role_name='{roleName}'";
               // cmbRole.Items.Clear();
                conn.Open();

                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lblRoleID.Text = dr.GetString("id");
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
        public  string uName { get { return txtUsername.Text; } }
        public string UID { get { return lblUserID.Text; } }
        void getSELECTED_USER()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();

            if (lvUsers.SelectedItems.Count > 0)
            {
                var userID = lvUsers.SelectedItems[0].Text;
                try
                {

                    var sql = $"SELECT * FROM SystemUser WHERE ID='{userID}'";
                    conn.Open();
                    var cmd = new MySqlCommand(sql, conn);
                    var dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        txtFirstName.Text = dr.GetString("FirstName");
                        txtLastName.Text= dr.GetString("LastName");
                        txtIDnumber.Text= dr.GetString("ID_Number");
                        txtPhone.Text= dr.GetString("Phone");
                        txtUsername.Text= dr.GetString("Username");
                        lblUserID.Text = dr.GetString("ID");

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
        void GetUsers()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                var sql = "SELECT ID,CONCAT(FirstName,' ',LastName) AS Name FROM SystemUser ORDER BY ID";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();
                lvUsers.Items.Clear();
                while (dr.Read())
                {
                    var list = lvUsers.Items.Add(dr.GetString("ID"));
                   list.SubItems.Add(dr.GetString("Name"));
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

        private void LvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            getSELECTED_USER();
        }

        private void LvUsers_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            getSELECTED_USER();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(lvUsers.SelectedItems.Count > 0)
            {
                frmPassword pw = new frmPassword();
                pw.Text = uName;
                pw.lblIDUser.Text = UID;
                pw.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select user to change password!", "PASSWORD CHANGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        void NewUser()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            var cPass =   txtConfirmPass.Text;
            var fName = txtFirstName.Text;
            var idNumber = txtIDnumber.Text;
            var lName = txtLastName.Text;
            var pass = txtPass.Text;
            var phone = txtPhone.Text;
            var userName = txtUsername.Text;

            var UserID = lblUserID.Text;
            var roleID = lblRoleID.Text;

            try
            {
                var sql = $" INSERT INTO SystemUser(FirstName,LastName,ID_Number,Phone,Username,Pass) VALUES('{fName}','{lName}','{idNumber}','{phone}','{userName}',MD5('{pass}'))";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteNonQuery();

                var sql2 = $"insert into users(id, user_name,password) values('{UserID}', '{userName}',MD5('{pass}'))";
                var cmd2 = new MySqlCommand(sql2, conn);
                var dr2 = cmd2.ExecuteNonQuery();

                var sql3 = $"insert into users_role(user_id, role_id) values('{UserID}', '{roleID}')";
                var cmd3 = new MySqlCommand(sql3, conn);
                var dr3 = cmd3.ExecuteNonQuery();

                MessageBox.Show(fName + " added succesfuly", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnNew_Click(object sender, EventArgs e)
        {
            var NextUserID = myFunctions.GetNextUserID();

            lblUserID.Text = NextUserID;
            EnableFields();
            ClearFields();

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRoleID();
        }
        void EnableFields()
        {
            txtConfirmPass.Enabled = true;
            txtFirstName.Enabled = true;
            txtIDnumber.Enabled = true;
            txtLastName.Enabled = true;
            txtPass.Enabled = true;
            txtPhone.Enabled = true;
            txtUsername.Enabled = true;

            cmbRole.Enabled = true;
           
        }
        void DisableFields()
        {
            txtConfirmPass.Enabled = false;
            txtFirstName.Enabled = false;
            txtIDnumber.Enabled =false;
            txtLastName.Enabled = false;
            txtPass.Enabled = false;
            txtPhone.Enabled = false;
            txtUsername.Enabled = false;

            cmbRole.Enabled = false;
        }
        void ClearFields()
        {

            txtConfirmPass.Clear();
            txtFirstName.Clear();
            txtIDnumber.Clear();
            txtLastName.Clear();
            txtPass.Clear();
            txtPhone.Clear();
            txtUsername.Clear();

            txtFirstName.Focus();

            //cmbRole.Enabled = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            NewUser();
            DisableFields();
        }
    }
}
