using MySql.Data.MySqlClient;

namespace ADM_Management_System
{
    internal class DBMYSQLUtils

    {
        public static MySqlConnection GetDBConnection(string host, int port, string database, string username,
            string password)

        {
            // Connection String.
            var connString = "Server=" + host + ";Database=" + database
                             + ";port=" + port + ";User Id=" + username + ";password=" + password + ";AllowUserVariables=True";

            var conn = new MySqlConnection(connString);

            return conn;
        }
    }
}