using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Bazzr.Models;

namespace Bazzr.Tests
{
    [TestClass]
    public class TagTests : IDisposable
    {
        public TagTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=bazzr_test;";
        }

        public void Dispose()
        {
            // User.DeleteAll();
            Game.DeleteAll();
            Tag.DeleteAll();
        }

        [TestMethod]
        public void GetName_ReturnsTagName_String()
        {
            string testName = "Action";
            Tag testTag = new Tag(testName);

            string result = testTag.GetName();

            Assert.AreEqual(testName, result);
        }

        [TestMethod]
        public void GetAll_TagsEmptyAtFirst_0()
        {
           int result = Tag.GetAll().Count;
           Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetAll_ReturnsAllTags_TagList()
        {
            Tag testTag1 = new Tag("Action");
            Tag testTag2 = new Tag("Adventure");

            testTag1.Save();
            testTag2.Save();

            List<Tag> newList = new List<Tag> {testTag1, testTag2};
            List<Tag> result = Tag.GetAll();
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Save_SavesTagToDatabase_TagList()
        {
            Tag testTag = new Tag("Action");
            testTag.Save();

            List<Tag> testList = new List<Tag>{testTag};
            List<Tag> resultList = Tag.GetAll();

            CollectionAssert.AreEqual(testList, resultList);
        }

        [TestMethod]
        public void Find_FindsTagInDatabase_User()
        {
            Tag testTag = new Tag("Action");
            testTag.Save();

            Tag foundTag = Tag.Find(testTag.GetId());

            Assert.AreEqual(testTag, foundTag);
        }
    }
}
