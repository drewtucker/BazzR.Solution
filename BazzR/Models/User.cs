using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.MySqlClient;
using Bazzr;

namespace Bazzr.Models
{
    public class User
    {
        
        private int _id;
        private string _username;
        private string _email;
        private string _firstName;
        private string _lastName;
        private int _reputation;
        private DateTime _dateRegistered;

        public int Id { get => _id; set => _id = value; }
        public string Username { get => _username; set => _username = value; }
        public string Email { get => _email; set => _email = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public int Reputation { get => _reputation; set => _reputation = value; }
        public DateTime DateRegistered { get => _dateRegistered; set => _dateRegistered = value; }

        //need to incorporate password

        public User(string username, string email, string firstName, string lastName, DateTime datereg, int rep = 0, int id = 0)
        {
          Id = id;
          Username = username;
          Email = email;
          FirstName = firstName;
          LastName = lastName;
          Reputation = rep;
          DateRegistered = datereg;
       }


        public static List<User> GetAll()
        {
            List<User> allUser = new List<User> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM users;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int userId = rdr.GetInt32(0);
                string userName = rdr.GetString(1);
                string email = rdr.GetString(2);
                string hashed_password = rdr.GetString(3);
                string firstName = rdr.GetString(4);
                string lastName = rdr.GetString(5);
                int rep = rdr.GetInt32(6);
                DateTime date = rdr.GetDateTime(7);

                User newUser = new User(userName, email, firstName, lastName, date, rep, userId);
                allUser.Add(newUser);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allUser;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM users;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO users (username, email, hashed_password, firstname, lastname, rep, date_registered)
                VALUES (@UserName, @Email, @FirstName, @LastName, @Rep, @Date);";

            MySqlParameter username = new MySqlParameter();
            username.ParameterName = "@UserName";
            username.Value = Username;
            cmd.Parameters.Add(username);
            MySqlParameter email = new MySqlParameter();
            email.ParameterName = "@Email";
            email.Value = Email;
            cmd.Parameters.Add(email);
            MySqlParameter firstname = new MySqlParameter();
            firstname.ParameterName = "@FirstName";
            firstname.Value = FirstName;
            cmd.Parameters.Add(firstname);
            MySqlParameter lastname = new MySqlParameter();
            lastname.ParameterName = "@LastName";
            lastname.Value = LastName;
            cmd.Parameters.Add(lastname);
            MySqlParameter rep = new MySqlParameter();
            rep.ParameterName = "@Rep";
            rep.Value = Reputation;
            cmd.Parameters.Add(rep);
            MySqlParameter date = new MySqlParameter();
            date.ParameterName = "@Date";
            date.Value = DateRegistered;
            cmd.Parameters.Add(date);

            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static User Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM users WHERE id = (@searchId);";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int newid = 0;
            string username = "";
            string email = "";
            string hashed_password = "";
            string firstname = "";
            string lastname = "";
            int rep = 0;
            DateTime date_registered = new DateTime (2000, 1, 1, 1, 0, 0);
            while (rdr.Read())
            {
                newid = rdr.GetInt32(0);
                username = rdr.GetString(1);
                email = rdr.GetString(2);
                hashed_password = rdr.GetString(3);
                firstname = rdr.GetString(4);
                lastname = rdr.GetString(5);
                rep = rdr.GetInt32(6);
                date_registered = rdr.GetDateTime(7);
            }
            User foundUser = new User(username, email, firstname, lastname, date_registered, rep, newid);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundUser;
        }

        public void Delete()
        {

        }

    }
}
