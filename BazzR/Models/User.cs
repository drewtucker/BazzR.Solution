using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Identity;
using BasicAuthentication.ViewModels;
using BasicAuthentication.Models;
using Bazzr;
namespace Bazzr.Models
{
    
    public class User
    {
         public static User ThisUser(string thisEmail)
        {
            return User.Find(thisEmail);
        }
        private string _id;
        private string _userName;
        private string _email;
        private string _firstName;
        private string _lastName;
        private DateTime _dateRegistered;
        private int _reputation;
        //need to incorporate password

        public User(string username, string email, string firstName, string lastName, DateTime datereg, int rep = 0, string id = "0")
        {
          _id = id;
          _userName = username;
          _email = email;
          _firstName = firstName;
          _lastName = lastName;
          _dateRegistered = datereg;
          _reputation = rep;
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
            return this.GetEmail().Equals(newUser.GetEmail());
          }
            if (!(otherUser is User))
            {
                return false;
            }
            else
            {
                User newUser = (User)otherUser;
                return this.GetEmail().Equals(newUser.GetEmail());
            }
       }

        public override int GetHashCode()
        {
            return this.GetId().GetHashCode();
        }

        public string GetId()
        {
          return _id;
        }

        public string GetUserName()
        {
            return _userName;
        }

        public string GetEmail()
        {
          return _email;
        }

        public string GetFirstName()
        {
          return _firstName;
        }

        public string GetLastName()
        {
          return _lastName;
        }

        public DateTime GetDate()
        {
          return _dateRegistered;
        }

        public int GetReputation()
        {
          return _reputation;
        }

        public static List<User> GetAll()
        {
            List<User> allUsers = new List<User> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM users;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                string userId = rdr.GetString(0);
                string userName = rdr.GetString(1);
                string email = rdr.GetString(2);
                string firstName = rdr.GetString(3);
                string lastName = rdr.GetString(4);
                DateTime date = rdr.GetDateTime(5);
                int rep = rdr.GetInt32(6);


                User newUser = new User(userName, email, firstName, lastName, date, rep, userId);
                allUsers.Add(newUser);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allUsers;
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
            cmd.CommandText = @"INSERT INTO users (username, email, firstname, lastname, date_registered, rep, id)
                VALUES (@UserName, @Email, @FirstName, @LastName, @Date, @Rep, @Id);";

            MySqlParameter username = new MySqlParameter();
            username.ParameterName = "@UserName";
            username.Value = _userName;
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
            MySqlParameter date = new MySqlParameter();
            date.ParameterName = "@Date";
            date.Value = _dateRegistered;
            cmd.Parameters.Add(date);
            MySqlParameter rep = new MySqlParameter();
            rep.ParameterName = "@Rep";
            rep.Value = _reputation;
            cmd.Parameters.Add(rep);
            MySqlParameter id = new MySqlParameter();
            id.ParameterName = "@Id";
            id.Value = _id;
            cmd.Parameters.Add(id);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Edit(string newUserName, string newEmail, string newFirstName, string newLastName, DateTime newDateRegisted, int newReputation)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"UPDATE users SET username = @newUserName, email = @newEmail, firstname = @newFirstName, lastname = @newLastName, date_registered = @newDate, rep = @newRep WHERE email=@email;";

          MySqlParameter thisEmail = new MySqlParameter();
          thisEmail.ParameterName = "@email";
          thisEmail.Value = _email;

          MySqlParameter updateUserName = new MySqlParameter();
          updateUserName.ParameterName = "@newUserName";
          updateUserName.Value = newUserName;

          MySqlParameter updateEmail = new MySqlParameter();
          updateEmail.ParameterName = "@newEmail";
          updateEmail.Value = newEmail;

          MySqlParameter updateFirstName = new MySqlParameter();
          updateFirstName.ParameterName = "@newFirstName";
          updateFirstName.Value = newFirstName;

          MySqlParameter updateLastName = new MySqlParameter();
          updateLastName.ParameterName = "newLastName";
          updateLastName.Value = newLastName;

          MySqlParameter updateDateRegistered = new MySqlParameter();
          updateDateRegistered.ParameterName = "@newDate";
          updateDateRegistered.Value = newDateRegisted;

          MySqlParameter updateReputation = new MySqlParameter();
          updateReputation.ParameterName = "@newRep";
          updateReputation.Value = newReputation;


          cmd.Parameters.Add(updateUserName);
          cmd.Parameters.Add(updateEmail);
          cmd.Parameters.Add(updateFirstName);
          cmd.Parameters.Add(updateLastName);
          cmd.Parameters.Add(updateDateRegistered);
          cmd.Parameters.Add(updateReputation);

          cmd.Parameters.Add(thisEmail);

          cmd.ExecuteNonQuery();
          _userName = newUserName;
          _email = newEmail;
          _firstName = newFirstName;
          _lastName = newLastName;
          _dateRegistered = newDateRegisted;
          _reputation = newReputation;

          conn.Close();
          if(conn != null)
          {
            conn.Dispose();
          }

        }

        public static User Find(string thisEmail)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM users WHERE email = (@searchEmail);";
            MySqlParameter searchEmail = new MySqlParameter();
            searchEmail.ParameterName = "@searchEmail";
            searchEmail.Value = thisEmail;
            cmd.Parameters.Add(searchEmail);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            string newid = "0";
            string username = "";
            string email = "";
            string firstname = "";
            string lastname = "";
            DateTime date_registered = new DateTime(2000, 1, 1, 1, 0, 0);
            int rep = 0;

            while (rdr.Read())
            {
                newid = rdr.GetString(0);
                username = rdr.GetString(1);
                email = rdr.GetString(2);
                firstname = rdr.GetString(3);
                lastname = rdr.GetString(4);
                date_registered = rdr.GetDateTime(5);
                rep = rdr.GetInt32(6);

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
            cmd.CommandText = @"DELETE FROM users WHERE email = @UserEmail;";

            MySqlParameter useridParameter = new MySqlParameter();
            useridParameter.ParameterName = "@UserEmail";
            useridParameter.Value = this.GetEmail();
            cmd.Parameters.Add(useridParameter);

            cmd.ExecuteNonQuery();
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
