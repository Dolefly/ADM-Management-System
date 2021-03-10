using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;

namespace ADM_Management_System
{
   public class DBUtils
    {

        public static MySqlConnection GetDBConnection()

        {
            var host = "";
            var port = 3306;
            var database="adm";
            var username = "";
            var password = "";
            try
            {
                var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\amsSettings");

                var sIP = key.GetValue("ServerIP").ToString();
                var sPort = int.Parse(key.GetValue("ServerPort").ToString());
                var sUsername = key.GetValue("ServerUsername").ToString();
                var sPass = key.GetValue("ServerPass").ToString();


                host = sIP;
                port = sPort;
                //database = "adm";
                username = sUsername;
                password = sPass;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                return DBMYSQLUtils.GetDBConnection(host, port, database, username, password);
           
        }
        public class RegException : Exception
        {
            public RegException(string message)
               : base(message)
            {
            }
        }
    }

}