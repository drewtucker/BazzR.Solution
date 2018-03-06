using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Bazzr.Models;
using Bazzr;

namespace Bazzr.Tests
{
    [TestClass]
    public class Buy_OfferTests : IDisposable
    {
        public Buy_OfferTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=bazzr_test;";
        }
        public void Dispose()
        {
            Buy_Offer.DeleteAll();
        }
        [TestMethod]
        public void GetAll_DatabaseEmptyAtFirst_0()
        {
            int result = Buy_Offer.GetAll().Count;
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Save_SavesToDatabase_BuyOfferList()
        {
            DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7);
            Buy_Offer testBuy_Offer = new Buy_Offer(0, dt, 0, 0, 0);
            testBuy_Offer.Save();
            List<Buy_Offer> result = Buy_Offer.GetAll();
            List<Buy_Offer> testList = new List<Buy_Offer>{testBuy_Offer};
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Find_FindsBuyOfferInDatabase_BuyOffer()
        {
            DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7);
            Buy_Offer testBuy_Offer = new Buy_Offer(0, dt, 0, 0, 0);
            testBuy_Offer.Save();
            Buy_Offer result = Buy_Offer.Find(testBuy_Offer.GetId());
            Assert.AreEqual(testBuy_Offer, result);
        }
    }
}
