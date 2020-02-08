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
    }
}
