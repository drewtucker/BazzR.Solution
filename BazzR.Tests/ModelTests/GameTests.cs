using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Bazzr.Models;

namespace Bazzr.Tests
{
    [TestClass]
    public class GameTests : IDisposable
    {
        public GameTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=bazzr_test;";
        }

        public void Dispose()
        {
            //User.DeleteAll();
            Game.DeleteAll();
            Tag.DeleteAll();
        }

        [TestMethod]
        public void GetName_ReturnsGameName_String()
        {
            string testName = "Super Mario World";
            Game testGame = new Game(testName, "SNES", "", "", 0);

            string result = testGame.GetTitle();

            Assert.AreEqual(testName, result);
        }

        [TestMethod]
        public void GetAll_GamesEmptyAtFirst_0()
        {
           int result = Game.GetAll().Count;
           Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetAll_ReturnsAllGames_GameList()
        {
            Game testGame1 = new Game("Super Mario World", "SNES", "", "", 0);
            Game testGame2 = new Game("Zombies Ate My Neighbors", "SNES", "", "", 0);

            testGame1.Save();
            testGame2.Save();

            List<Game> testList = new List<Game> {testGame1, testGame2};
            List<Game> result = Game.GetAll();
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_SavesGameToDatabase_GameList()
        {
            Game testGame = new Game("Super Mario World", "SNES", "", "", 0);
            testGame.Save();

            List<Game> testList = new List<Game>{testGame};
            List<Game> resultList = Game.GetAll();

            CollectionAssert.AreEqual(testList, resultList);
        }

        [TestMethod]
        public void Find_FindsGameInDatabase_Game()
        {
            Game testGame = new Game("Super Mario World", "SNES", "", "", 0);
            testGame.Save();

            Game foundGame = Game.Find(testGame.GetId());

            Assert.AreEqual(testGame, foundGame);
        }

        [TestMethod]
        public void GetTags_RetrievesAllTagsAssociatedWithGame_TagList()
        {
            Game testGame = new Game("Super Mario World", "SNES", "", "", 0);
            testGame.Save();

            Tag newTag1 = new Tag("Action");
            Tag newTag2 = new Tag("Adventure");
            newTag1.Save();
            newTag2.Save();
            testGame.AddTag(newTag1);
            testGame.AddTag(newTag2);

            List<Tag> testTagList = new List<Tag> {newTag1, newTag2};
            List<Tag> resultTagList = testGame.GetTags();

            CollectionAssert.AreEqual(testTagList, resultTagList);
        }

        [TestMethod]
        public void AddTag_AddsTagAssociationToDatabase_TagList()
        {
            Game testGame = new Game("Super Mario World", "SNES", "", "", 0);
            testGame.Save();

            Tag newTag = new Tag("Action");
            newTag.Save();

            testGame.AddTag(newTag);

            List<Tag> testList = new List<Tag>{newTag};
            List<Tag> result = testGame.GetTags();

            CollectionAssert.AreEqual(testList, result);
        }
    }
}
