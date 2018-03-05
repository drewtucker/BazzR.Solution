using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Bazzr.Models;

namespace Bazzr.Tests
{
    [TestClass]
    public class UserTests : IDisposable
    {
        public UserTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=bazzr;";
        }

        public void Dispose()
        {
            User.DeleteAll();
            Game.DeleteAll();
            Tag.DeleteAll();
        }

        [TestMethod]
        public void GetName_ReturnsUsername_String()
        {
            string testName = "Bob";
            User testUser = new User(testName, "bob@gmail.com", "Bob", "Smith");

            string result = testUser.GetName();

            Assert.AreEqual(testName, result);
        }

        [TestMethod]
        public void GetAll_UsersEmptyAtFirst_0()
        {
           int result = User.GetAll().Count;
           Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetAll_ReturnsAllUsers_UserList()
        {
            string userName1 = "Super Mario World";
            string gameName2 = "Zombies Ate My Neighbors";

            User testUser1 = new User("Bob", "bob@gmail.com", "Bob", "Smith");
            User testUser2 = new User("Chuck", "chuck@gmail.com", "Charles", "Smith");

            newGame1.Save();
            newGame2.Save();

            List<User> newList = new List<User> {testUser1, testUser2};
            List<User> result = User.GetAll();
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Save_SavesUserToDatabase_UserList()
        {
            User testUser = new User("Bob", "bob@gmail.com", "Bob", "Smith");
            testUser.Save();

            List<User> testList = new List<User>{testUser};
            List<User> resultList = User.GetAll();

            CollectionAssert.AreEqual(testList, resultList);
        }

        [TestMethod]
        public void Find_FindsUserInDatabase_User()
        {
            User testUser = new User("Bob", "bob@gmail.com", "Bob", "Smith");
            testUser.Save();

            User foundUser = User.Find(testUser.GetId());

            Assert.AreEqual(testUser, foundUser);
        }
    }
}

}
