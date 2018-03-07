
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Bazzr.Models;
using Bazzr;

namespace Bazzr.Tests
{
    [TestClass]
    public class Sell_TransactionTests : IDisposable
    {
        public Sell_TransactionTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=bazzr_test;";
        }
        public void Dispose()
        {
            Sell_Transaction.DeleteAll();
        }
        [TestMethod]
        public void GetAll_DatabaseEmptyAtFirst_0()
        {
            int result = Sell_Transaction.GetAll().Count;
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Save_SavesToDatabase_Sell_TransactionList()
        {
            DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7);
            Sell_Transaction testSell_Transaction = new Sell_Transaction(1, 2, "a", dt, "b", 3, 0);
            testSell_Transaction.Save();
            List<Sell_Transaction> result = Sell_Transaction.GetAll();
            List<Sell_Transaction> testList = new List<Sell_Transaction>{testSell_Transaction};
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Find_FindsSell_TransactionInDatabase_Sell_Transaction()
        {
            DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7);
            Sell_Transaction testSell_Transaction = new Sell_Transaction(1, 2, "a", dt, "b", 3, 0);
            testSell_Transaction.Save();
            Sell_Transaction result = Sell_Transaction.Find(testSell_Transaction.GetId());
            Assert.AreEqual(testSell_Transaction, result);
        }

        [TestMethod]
        public void Edit_EditChangesSell_Transaction_Sell_Transaction()
        {
            DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7);
            DateTime dt2 = new DateTime(2008, 1, 2, 3, 4, 5);
            Sell_Transaction testSell_Transaction = new Sell_Transaction(1, 2, "a", dt, "b", 3, 0);
            testSell_Transaction.Save();
            testSell_Transaction.Edit(4, 5, "c", dt2, "d", 6);
            Sell_Transaction result = Sell_Transaction.Find(testSell_Transaction.GetId());
            Assert.AreEqual(4, result.GetGameId());
            Assert.AreEqual(5, result.GetUserIdSeller());
            Assert.AreEqual("c", result.GetStatus());
            Assert.AreEqual(dt2, result.GetDate());
            Assert.AreEqual("d", result.GetGamePhoto());
            Assert.AreEqual(6, result.GetUserIdBuyer());
        }

        [TestMethod]
        public void Delete_DeleteRemovesSell_Transaction_Sell_TransactionList()
        {
            DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7);
            Sell_Transaction testSell_Transaction = new Sell_Transaction(1, 2, "a", dt, "b", 3, 0);
            testSell_Transaction.Save();
            testSell_Transaction.Delete();
            List<Sell_Transaction> testList = new List<Sell_Transaction>{};
            List<Sell_Transaction> result = Sell_Transaction.GetAll();
            CollectionAssert.AreEqual(testList, result);
        }
    }
}
