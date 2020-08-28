using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace BodsData
{
    public class DataLayer
    {
        // initilize  empty connection value that will get value at startup application
        public static string ConnectionString = "";
        // return connection from mysql type
        public static MySqlConnection NewConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
