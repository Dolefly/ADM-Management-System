using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ADM_Management_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void LOGIN()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            var userName = txtUsername.Text;
            var pass = txtPass.Text;
            try
            {
                string sql = $"SELECT * FROM SystemUser WHERE Username='{userName}' AND Pass=MD5('{pass}')";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //frmMain f = new frmMain();
                    // f.tspUser.Text = "ADMIN";
                    lblUserID.Text = dr.GetString("ID");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPass.Clear();
                    txtUsername.Clear();
                    txtUsername.Focus();
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
        private void Button2_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text != "")
            {
                if(txtPass.Text != "")
                {
                    LOGIN();
                }
                else
                {
                    MessageBox.Show("Enter Password", "PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Enter Username", "USERNAME", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();

        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        //This funtion used to pass variable values to mdi parent form
        public string username { get { return txtUsername.Text; } }
        public string userID { get { return lblUserID.Text; } }
    }
}
