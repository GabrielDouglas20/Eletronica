using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_1.Data
{
    internal class Database

    {
        private static string connectionString = "server=localhost;database=eletronica;uid=root;pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}

