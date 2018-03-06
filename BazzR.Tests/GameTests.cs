using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BazzrApp.Models;

namespace BazzrApp.Tests
{
    [TestClass]
    public class StylistTests : IDisposable
    {
        public StylistTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=bazzr;";
        }

        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
            Specialty.DeleteAll();
        }

        [TestMethod]
        public void GetName_ReturnsGameName_String()
        {
            string testName = "Super Mario World";
            Game testGame = new Game(testName, "SNES");

            string result = testGame.GetName();

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
            string gameName1 = "Super Mario World";
            string gameName2 = "Zombies Ate My Neighbors";

            Game newGame1 = new Game(gameName1, "SNES");
            Game newGame2 = new Game(gameName2, "SNES");

            newGame1.Save();
            newGame2.Save();

            List<Game> newList = new List<Game> {newGame1, newGame2};
            List<Game> result = Game.GetAll();
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Save_SavesGameToDatabase_GameList()
        {
            Game newGame = new Game("Super Mario World", "SNES");
            testGame.Save();

            List<Game> testList = new List<Game>{testGame};
            List<Game> resultList = Game.GetAll();

            CollectionAssert.AreEqual(testList, resultList);
        }


        [TestMethod]
        public void Find_FindsGameInDatabase_Game()
        {
            Game newGame = new Game("Super Mario World", "SNES");
            testGame.Save();

            Game foundGame = Game.Find(testGame.GetId());

            Assert.AreEqual(testGame, foundGame);
        }
    }
}
