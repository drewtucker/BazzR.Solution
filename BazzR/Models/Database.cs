using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Bazzr;

namespace Bazzr.Models
{
    public class DB
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }
    }
}
