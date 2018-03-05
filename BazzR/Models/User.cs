using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bazzr;

namespace Bazzr.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        private int id;
        private string _username;
        private string _email;
        private string _firstName;
        private string _lastName;
        //need to incorporate password

        public User(string username, string email, string firstName, string lastName, int id = 0)
        {
            _id = id;
            _username = username;
            _email = email;
            _firstName = firstName;
            _lastName = lastName;
        }

        public override bool Equals(System.Object otherUser)
        {
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

        public void Save()
        {
            //save user to database
        }

        public static List<User> GetAll()
        {
            //update - get all users from database
            List<User> allUsers = new List<User> { };
            return allUsers;
        }

        //public void Edit(string newName, etc.)
        //edit username / other options in database
    }
}
