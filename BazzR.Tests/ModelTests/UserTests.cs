using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Bazzr.Models;
using System;

namespace Bazzr.Tests
{
  [TestClass]
  public class UserTests: IDisposable
  {
    public UserTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=bazzr_test;";
    }

    public void Dispose()
    {
      User.DeleteAll();
      Game.DeleteAll();
    }

    [TestMethod]
    public void GetAll_DatabaseEmptyAtFirst_0()
    {
    //Arrange, Act
    int result = Game.GetAll().Count;
    //Assert
    Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void GetAll_GetsAllUsersFromTheDataBase_UserList()
    {
      //Arrange
      DateTime dateTime1 = new DateTime(2000, 1, 1, 1, 1, 1);
      DateTime dateTime2 = new DateTime(2000, 1, 1, 1, 1, 1);

      User testUser1 = new User("jdrochon", "jd@gmail.com", "Josh", "Rochon", dateTime1, 99);
      User testUser2 = new User("twick", "twick@gmail.com", "Tyler", "Wickline", dateTime2, 91);
      testUser1.Save();
      testUser2.Save();

      //Act
      int expectedResult = 2;
      int actualResult = User.GetAll().Count;

      //Assert
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void Delete_DeletesIndividualUserFromDataBase_User()
    {
      //Arrange
      DateTime dateTime1 = new DateTime(2000, 1, 1, 1, 1, 1);
      DateTime dateTime2 = new DateTime(2000, 1, 1, 1, 1, 1);
      User testUser1 = new User("a", "b", "c", "d", dateTime1, 45);
      User testUser2 = new User("e", "f", "g", "h", dateTime2, 10);
      testUser1.Save();
      testUser2.Save();
      testUser2.Delete();
      //Act
      int actualResult = User.GetAll().Count;
      int expectedResult = 1;
      //Assert
      Assert.AreEqual(actualResult, expectedResult);
    }

    [TestMethod]
    public void Find_FindsUserInDatabase_User()
    {
        //Arrange
        DateTime dt = new DateTime(2000, 1, 1, 1, 1, 1);
        User testUser = new User("i", "j", "k", "l", dt, 99);
        testUser.Save();
        //Act

        User foundUser = User.Find(testUser.GetEmail());

        //Assert
        Assert.AreEqual(testUser, foundUser);
    }

    [TestMethod]
    public void Edit_UpdatesUserPropertiesInDatabase_User()
    {
      //arrange
      DateTime dt = new DateTime(1999, 11, 25, 09, 11, 10);
      User testUser = new User("m", "n", "o", "p", dt, 10);
      testUser.Save();

      string updateUserName = "Bond77";

      string updateEmail = "Bondo@gmail.com";

      string updateFirstName = "James";
      string updateLastName = "Bond";
      DateTime updateDateRegistered = new DateTime(1999, 11, 25, 09, 10, 10);
      int updateReputation = 32;

      testUser.Edit(updateUserName, updateEmail, updateFirstName, updateLastName, updateDateRegistered, updateReputation);

      string resultUserName = User.Find(testUser.GetEmail()).GetUserName();
      string resultEmail = testUser.GetEmail();
      string resultFirstName = User.Find(testUser.GetEmail()).GetFirstName();
      string resultLastName = User.Find(testUser.GetEmail()).GetLastName();
      DateTime resultDateRegistered = User.Find(testUser.GetEmail()).GetDate();
      int resultReputation = User.Find(testUser.GetEmail()).GetReputation();

      User resultUser = new User(resultUserName, "Bond@gmail.com", resultFirstName, resultLastName, resultDateRegistered, resultReputation);
      resultUser.Save();

      //assert
      Assert.AreEqual(updateUserName, resultUserName);
      Assert.AreEqual(updateEmail, resultEmail);
      Assert.AreEqual(updateFirstName, resultFirstName);
      Assert.AreEqual(updateLastName, resultLastName);
      Assert.AreEqual(updateDateRegistered, resultDateRegistered);
      Assert.AreEqual(updateReputation, resultReputation);
    }

  }
}
