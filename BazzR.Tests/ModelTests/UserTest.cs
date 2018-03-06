using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Bazzr.Models;
using Bazzr;

namespace Bazzr.Tests
{
    [TestClass]
    public class UserTests : IDisposable
    {
        public UserTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=bazzr_test;";
        }
        public void Dispose()
        {
            User.DeleteAll();
        }
        [TestMethod]
        public void GetAll_DatabaseEmptyAtFirst_0()
        {
            int result = User.GetAll().Count;
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Save_SavesToDatabase_UserList()
        {
            DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7);
            User testUser = new User("KSmith", "k@a.com", "Kevin", "Smith", "password", dt, 0, 1);
            testUser.Save();
            List<User> result = User.GetAll();
            List<User> testList = new List<User>{testUser};
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Find_FindsUserInDatabase_User()
        {
            DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7);
            User testUser = new User("KSmith", "k@a.com", "Kevin", "Smith", "password", dt, 0, 1);
            testUser.Save();
            User result = User.Find(testUser.GetId());
            Assert.AreEqual(testUser, result);
        }
    }
}
