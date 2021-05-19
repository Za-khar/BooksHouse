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
            string host = "db4free.net";
            int port = 3306;
            string database = "bookshouse";
            string username = "zakhar_vadim";
            string password = "pf[fh9684188";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
