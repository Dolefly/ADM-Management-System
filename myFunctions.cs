using System;
using System.Windows.Forms;
using Microsoft.Win32;
using MySql.Data.MySqlClient;

namespace ADM_Management_System
{
    public class myFunctions
    {
        public static string GetRate()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            string returnValue = null;
            try
            {
                var year = DateTime.Now.ToString("yyyy");
                var sql = $"SELECT Amount FROM Rate WHERE Year='{year}'";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
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
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }

            return returnValue;

        }
        public static string GetRegistrySettings() {
            //opening the subkey  
            string cUser = "";
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\amsSettings");
                if (cUser != "")
                {
                    cUser = key.ToString();
                }
                else
                {
                    MessageBox.Show("No settings Found!");
                    new DBConnector().ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return cUser;
        }
        public static bool IsServerConnected()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();

            using (conn)
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public static string GetDelegateName(string tscNo)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            string returnValue = null;
            try
            {
                var sql = $"SELECT Name FROM Register WHERE TSC_No='{tscNo}'";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    returnValue = dr.GetString("Name");
                    dr.Dispose();

                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }

            return returnValue;
        }

        public static string GetMemberNo(string tscNo)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            string returnValue = null;
            try
            {
                var sql = $"SELECT * FROM Attendance WHERE Member_No='{tscNo}'";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    returnValue = dr.GetString("member_No");
                    dr.Dispose();

                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }

            return returnValue;
        }

        public static string GetRBAC(string Uname, int resourceID)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            string returnValue = null;
            try
            {
                var sql = $"SELECT users.user_name,resource.resource_name FROM users INNER JOIN users_role ON users_role.user_id = users.id INNER JOIN role ON users_role.role_id = role.id INNER JOIN resource_role ON resource_role.role_id = role.id INNER JOIN resource ON resource_role.resource_id = resource.id WHERE users.user_name = '{Uname}' AND resource.id = '{resourceID}'"; 
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    returnValue = dr.GetString("user_name");
                    dr.Dispose();

                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }

            return returnValue;
        }

        //SELECT Table_Schema,Table_Name,Auto_Increment FROM information_schema.`TABLES` WHERE TABLE_SCHEMA = "adm" AND TABLE_NAME="SystemUser";
        public static string GetNextUserID()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            string returnValue = null;
            try
            {
                var adm = "adm";
                // var year = DateTime.Now.ToString("yyyy");
                var sql = $"SELECT Table_Schema,Table_Name,Auto_Increment FROM information_schema.`TABLES` WHERE TABLE_SCHEMA = '{adm}' AND TABLE_NAME='SystemUser'";
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                var dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    returnValue = dr.GetString("Auto_Increment");
                    dr.Dispose();

                }
                else
                {

                    return "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }

            return returnValue;

        }
    }
}
