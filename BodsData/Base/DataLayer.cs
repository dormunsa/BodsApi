using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BodsData
{
    public class DataLayer
    {
        public static string ConnectionString = "";
        //db types
        public static MySqlConnection NewConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
