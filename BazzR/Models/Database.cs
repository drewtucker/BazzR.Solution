using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using BazzrApp;

namespace BazzrApp.Models
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
