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
            // User.DeleteAll();
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
        public void Edit_UpdatesGamePropertiesInDatabase_Game()
        {
          //arrange
          Game testGame = new Game("Zelda", "SNES", "Great game", "dummyURL", 100, 0);
          testGame.Save();

          string updateTitle = "The Legend of Zelda";
          string updatePlatform = "Super Nintendo";
          string updateDescription = "Cutting edge graphics";
          string updatePhotopath = "dumbURL";
          int updateMetascore = 98;

          testGame.Edit(updateTitle, updatePlatform, updateDescription, updatePhotopath, updateMetascore);

          string resultTitle = Game.Find(testGame.GetId()).GetTitle();
          string resultPlatform = Game.Find(testGame.GetId()).GetPlatform();
          string resultDescription = Game.Find(testGame.GetId()).GetDescription();
          string resultPhotoPath = Game.Find(testGame.GetId()).GetPhotoPath();
          int resultMetascore = Game.Find(testGame.GetId()).GetMetaScore();

          Game resultGame = new Game(resultTitle, resultPlatform, resultDescription, resultPhotoPath, resultMetascore);
          resultGame.Save();

          //assert
          Assert.AreEqual(updateTitle, resultTitle);
          Assert.AreEqual(updatePlatform, resultPlatform);
          Assert.AreEqual(updateDescription, resultDescription);
          Assert.AreEqual(updatePhotopath, resultPhotoPath);
          Assert.AreEqual(updateMetascore, resultMetascore);
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

        [TestMethod]
        public void Score_Scores3forSingleWordMatch_3()
        {
            Game testGame = new Game("Tetris", "SNES", "", "", 0);
            testGame.Save();
            string query = "Tetris";
            int score = testGame.Score(query);
            Assert.AreEqual(2, score);
        }

        [TestMethod]
        public void Score_Scores0forNoMatch_0()
        {
            Game testGame = new Game("Super Mario World", "SNES", "", "", 0);
            testGame.Save();
            string query = "Tetris";
            int score = testGame.Score(query);
            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void Score_Scores2forPartMatch_2()
        {
            Game testGame = new Game("Dark Souls 3", "SNES", "", "", 0);
            testGame.Save();
            string query = "Dark Horizon";
            int score = testGame.Score(query);
            Assert.AreEqual(1, score);
        }

        [TestMethod]
        public void Search_EmptyForNoMatch_GameList()
        {
            Game testGame = new Game("Dark Souls 3", "SNES", "", "", 0);
            testGame.Save();
            string query = "Tetris";
            List<Game> resultList = Game.Search(query);
            List<Game> testList = new List<Game>{};
            CollectionAssert.AreEqual(testList, resultList);
        }

        [TestMethod]
        public void Search_TwoForTwoMatches_GameList()
        {
            Game testGame = new Game("Dark Souls 3", "SNES", "", "", 0);
            testGame.Save();
            Game testGame2 = new Game("Dark Souls 2", "SNES", "", "", 0);
            testGame2.Save();
            Game testGame3 = new Game("Super Mario World", "SNES", "", "", 0);
            testGame3.Save();
            string query = "Dark Souls 2";
            List<Game> resultList = Game.Search(query);
            List<Game> testList = new List<Game>{testGame2, testGame};
            CollectionAssert.AreEqual(testList, resultList);
        }

        [TestMethod]
        public void Search_FourMatchesInFive_GameList()
        {
            Game testGame = new Game("Dark Souls 3", "SNES", "", "", 0);
            testGame.Save();
            Game testGame2 = new Game("Dark Souls", "SNES", "", "", 0);
            testGame2.Save();
            Game testGame3 = new Game("Super Mario World", "SNES", "", "", 0);
            testGame3.Save();
            Game testGame4 = new Game("Perfect Dark", "Xbox", "", "", 0);
            testGame4.Save();
            Game testGame5 = new Game("Dark Souls", "Xbox", "", "", 0);
            testGame5.Save();
            string query = "Dark";
            List<Game> resultList = Game.Search(query);
            List<Game> testList = new List<Game>{testGame, testGame2, testGame4, testGame5};
            CollectionAssert.AreEqual(testList, resultList);
        }

        [TestMethod]
        public void Search_FourMatchesInFiveReordered_GameList()
        {
            Game testGame = new Game("Perfect Dark", "Xbox", "", "", 0);
            testGame.Save();
            Game testGame2 = new Game("Dark Souls 3", "SNES", "", "", 0);
            testGame2.Save();
            Game testGame3 = new Game("Dark Souls", "SNES", "", "", 0);
            testGame3.Save();
            Game testGame4 = new Game("Super Mario World", "SNES", "", "", 0);
            testGame4.Save();
            Game testGame5 = new Game("Dark Souls", "Xbox", "", "", 0);
            testGame5.Save();
            string query = "Dark Souls";
            List<Game> resultList = Game.Search(query);
            List<Game> testList = new List<Game>{testGame3, testGame5, testGame2, testGame};
            CollectionAssert.AreEqual(testList, resultList);
        }
    }
}
