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
                var sql = "SELECT Amount FROM Rate WHERE Year='2020'";
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
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\amsSettings");
            return key.ToString();
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
        

    }
}
