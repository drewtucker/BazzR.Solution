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
        private string _hashed_password;
        private int _reputation;
        private DateTime _dateRegistered;
        //need to incorporate password

        public User(string username, string email, string firstName, string lastName, DateTime datereg, int rep = 0, int id = 0)
        {
          _id = id;
          _username = username;
          _email = email;
          _firstName = firstName;
          _lastName = lastName;
          _reputation = rep;
          _dateRegistered = datereg;
       }

        public override bool Equals(System.Object otherUser)
        {
          if (!(otherUser is User))
          {
            return false;
          }
          else
          {
            User newUser = (User) otherUser;
            return this.GetId().Equals(newUser.GetId());
          }
            if (!(otherUser is User))
            {
                return false;
            }
            else
            {
                User newUser = (User)otherUser;
                return this.GetId().Equals(newUser.GetId());
            }
       }

        public override int GetHashCode()
        {
            return this.GetId().GetHashCode();
        }

        public string GetName()
        {
            return _username;
        }

        public int GetId()
        {
          return _id;
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
            username.Value = _username;
            cmd.Parameters.Add(username);
            MySqlParameter email = new MySqlParameter();
            email.ParameterName = "@Email";
            email.Value = _email;
            cmd.Parameters.Add(email);
            MySqlParameter firstname = new MySqlParameter();
            firstname.ParameterName = "@FirstName";
            firstname.Value = _firstName;
            cmd.Parameters.Add(firstname);
            MySqlParameter lastname = new MySqlParameter();
            lastname.ParameterName = "@LastName";
            lastname.Value = _lastName;
            cmd.Parameters.Add(lastname);
            MySqlParameter rep = new MySqlParameter();
            rep.ParameterName = "@Rep";
            rep.Value = _reputation;
            cmd.Parameters.Add(rep);
            MySqlParameter date = new MySqlParameter();
            date.ParameterName = "@Date";
            date.Value = _dateRegistered;
            cmd.Parameters.Add(date);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;

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
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM users WHERE id = @UserId;";

            MySqlParameter useridParameter = new MySqlParameter();
            useridParameter.ParameterName = "@UserId";
            useridParameter.Value = this.GetId();
            cmd.Parameters.Add(useridParameter);

            cmd.ExecuteNonQuery();
            if (conn != null)
            {
                conn.Close();
            }
        }

    }
}
