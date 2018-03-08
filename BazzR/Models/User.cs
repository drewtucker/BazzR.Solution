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
        
        private string _id;
        private string _username;
        private string _email;
        private string _firstName;
        private string _lastName;
        private int _reputation;
        private DateTime _dateRegistered;

        public string Id { get => _id; set => _id = value; }
        public string Username { get => _username; set => _username = value; }
        public string Email { get => _email; set => _email = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public int Reputation { get => _reputation; set => _reputation = value; }
        public DateTime DateRegistered { get => _dateRegistered; set => _dateRegistered = value; }

        public User(string username, string email, string firstName, string lastName, DateTime datereg, int rep = 0, string id = "0")
        {
          Id = id;
          Username = username;
          Email = email;
          FirstName = firstName;
          LastName = lastName;
          Reputation = rep;
          DateRegistered = datereg;
       }
    }
}
