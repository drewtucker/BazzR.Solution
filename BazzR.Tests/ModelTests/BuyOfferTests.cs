using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Bazzr.Models;

namespace Bazzr.Tests
{
    [TestClass]
    public class BuyOfferTests : IDisposable
    {
        public BuyOfferTests()
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
        public void GetGameId_ReturnsGameId_Int()
        {
            Buy_Offer testBuy_Offer = new Buy_Offer(1, new DateTime(2000, 1, 1, 12, 0, 0, 0), 5);

            string result = testBuy_Offer.GetGameId();

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetAll_UsersEmptyAtFirst_0()
        {
           int result = Buy_Offer.GetAll().Count;
           Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetAll_ReturnsAllBuyOffers_BuyOfferList()
        {
            Buy_Offer testBuy_Offer1 = new Buy_Offer(1, new DateTime(2000, 1, 1, 12, 0, 0, 0), 5);
            Buy_Offer testBuy_Offer2 = new Buy_Offer(2, new DateTime(2000, 1, 1, 12, 0, 0, 0), 8);

            testBuy_Offer1.Save();
            testBuy_Offer2.Save();

            List<Buy_Offer> newList = new List<Buy_Offer> {testBuy_Offer1, testBuy_Offer2};
            List<Buy_Offer> result = Buy_Offer.GetAll();
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Save_SavesBuyOfferToDatabase_BuyOfferList()
        {
            Buy_Offer testBuy_Offer = new Buy_Offer(1, new DateTime(2000, 1, 1, 12, 0, 0, 0), 5);
            testBuy_Offer.Save();

            List<Buy_Offer> testList = new List<Buy_Offer>{testBuy_Offer};
            List<Buy_Offer> resultList = Buy_Offer.GetAll();

            CollectionAssert.AreEqual(testList, resultList);
        }

        [TestMethod]
        public void Find_FindsBuyOfferInDatabase_User()
        {
            Buy_Offer testBuy_Offer = new Buy_Offer(1, new DateTime(2000, 1, 1, 12, 0, 0, 0), 5);
            testBuy_Offer.Save();

            testBuy_Offer foundBuy_Offer = testBuy_Offer.Find(testtestBuy_Offer.GetId());

            Assert.AreEqual(testBuy_Offer, foundBuy_Offer);
        }
    }
}

}
