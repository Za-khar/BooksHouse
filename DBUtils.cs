using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BooksHouse
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "sql11.freesqldatabase.com";
            int port = 3306;
            string database = "sql11413628";
            string username = "sql11413628";
            string password = "XY6WPACMZV";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
