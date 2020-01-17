using Microsoft.Win32;
using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ADM_Management_System
{
    public partial class DBConnector : Form
    {
        public DBConnector()
        {
            InitializeComponent();
        }
        private void CheckDBSettings()
        {
            var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\amsSettings");

            if (key != null)
            {
                var sIP = key.GetValue("ServerIP").ToString();
                var sPort = int.Parse(key.GetValue("ServerPort").ToString());
                var sUsername = key.GetValue("ServerUsername").ToString();
                var sPass = key.GetValue("ServerPass").ToString();

                var conn = DBUtils.GetDBConnection();

                try
                {
                    txtPass.Text = sPass;
                    txtIP.Text = sIP;
                    txtPort.Text = sPort.ToString();
                    txtUsername.Text = sUsername;

                    //MessageBox.Show("Success");
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Error: " + ex.Message);
                    MessageBox.Show("Connection Failed!" + ex.Message, "DB STATUS");
                }
            }
            else
            {
                MessageBox.Show("No DB Settings found! Kindly Setup before your continue");
            }
        }
        private void SaveDBSettings()
        {
            var IP = txtIP.Text;
            var PORT = txtPort.Text;
            var USERNAME = txtUsername.Text;
            var PASS = txtPass.Text;

            try
            {
                var key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\amsSettings");
                key.SetValue("ServerIP", IP);
                key.SetValue("ServerPort", PORT);
                key.SetValue("ServerUsername", USERNAME);
                key.SetValue("ServerPass", PASS);
                key.Close();

                MessageBox.Show("Settings Saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtIP.Text != "")
            {
                if (txtPort.Text != "")
                {
                    if (txtUsername.Text != "")
                    {
                        if (txtPass.Text != "")
                        {
                            SaveDBSettings();

                            DISABLETEXTBOX();

                            btnEdit.Enabled = true;

                            btnSave.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Please enter PASSWORD!", "PASSWORD");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter USERNAME!", "USERNAME");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter PORT Number!", "PORT NUMBER");
                }
            }
            else
            {
                MessageBox.Show("Please enter IP Address!", "IP ADDRESS");
            }
        }
        #region ENABLE/DISABLE TEXTBOSES
        void enableTextBoxes()
        {
            txtIP.ReadOnly = false;
            txtPass.ReadOnly = false;
            txtUsername.ReadOnly = false;
            txtPort.ReadOnly = false;
        }

        void DISABLETEXTBOX()
        {
            txtIP.ReadOnly = true;
            txtPass.ReadOnly = true;
            txtUsername.ReadOnly = true;
            txtPort.ReadOnly = true;
        }
        #endregion
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            enableTextBoxes();

            btnSave.Enabled = true;

            btnEdit.Enabled = false;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE", true);
                //deleting 'someKey'
                key.DeleteSubKey("amsSettings");

                key.Close();
                MessageBox.Show("Settings removed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            CheckDBSettings();
        }

        private void BtnTestServer_Click(object sender, EventArgs e)
        {
            try
            {
                var ip = txtIP.Text;
                var port = txtPort.Text;
                var username = txtUsername.Text;
                var pass = txtPass.Text;
                if (ip != "")
                {
                    if (port != "")
                    {
                        if (username != "")
                        {
                            if (pass != "")
                            {
                                string connetionString = null;
                                MySqlConnection cnn;
                                connetionString =
                                    $"server='{ip}';database=airtimeDB;uid='{username}';pwd='{pass}';port='{port}';";
                                cnn = new MySqlConnection(connetionString);
                                try
                                {
                                    cnn.Open();
                                    MessageBox.Show("Success! ");
                                    cnn.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Can not open connection! " + ex.Message);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Provide Password!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Provide username!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Provide Port Number!");
                    }

                }
                else
                {
                    MessageBox.Show("Provide Server Address or use localhost");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void DBConnector_Load(object sender, EventArgs e)
        {
            CheckDBSettings();
            if (txtIP.Text == "")
            {
                btnEdit.Text = "New";
            }
        }
    }
}
