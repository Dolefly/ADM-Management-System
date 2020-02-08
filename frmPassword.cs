using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ADM_Management_System
{
    public partial class frmPassword : Form
    {
        public frmPassword()
        {
            InitializeComponent();
        }

        private void FrmPassword_Load(object sender, EventArgs e)
        {
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SAVE_PASSWORD();
        }
        void SAVE_PASSWORD()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                var oldPass = txtOldPassword.Text;
                var userID = lblIDUser.Text;
                var sql = $" SELECT * FROM SystemUser WHERE ID='{userID}' AND Pass=md5('{oldPass}')";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dr.Dispose();
                    var newPass = txtNewPass.Text;
                    var confirmPass = txtConfirmPass.Text;
                    var userName = this.Text;
                    // var ID = lblIDUser.Text;

                    if (newPass != confirmPass)
                    {
                        MessageBox.Show("Passwords does not match,kindly check and try again!", "PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        try
                        {
                            var sql2 = $"UPDATE SystemUser Set Pass=md5('{confirmPass}') WHERE ID='{userID}'";
                            var cmd2 = new MySqlCommand(sql2, conn);
                            var dr2 = cmd2.ExecuteNonQuery();
                            MessageBox.Show(this.Text + " password has been changed successfully!", "PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                else
                {
                    MessageBox.Show("Wrong old password,try again!", "OLD PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }
    }
}
