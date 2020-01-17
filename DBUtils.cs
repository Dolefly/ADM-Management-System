using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;

namespace ADM_Management_System
{
   public class DBUtils
    {

        public static MySqlConnection GetDBConnection()

        {
           
                var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\amsSettings");

                var sIP = key.GetValue("ServerIP").ToString();
                var sPort = int.Parse(key.GetValue("ServerPort").ToString());
                var sUsername = key.GetValue("ServerUsername").ToString();
                var sPass = key.GetValue("ServerUsername").ToString();


                var host = sIP;
                var port = sPort;
                var database = "adm";
                var username = sUsername;
                var password = sPass;

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