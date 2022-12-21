using BudgetBook.Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBook.Test.Entities
{
    [TestClass]
    public class RegularTransactionTest
    {

        [TestMethod]
        public void TestOfRegularTransaction_Weekly()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = Backend.eFrequency.Weekly,
            };
            var nextDuty = transaction.GetNextDuty(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2022, 12, 21), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Weekly_InitDateInFuture()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2099, 05, 06),
                Frequency = Backend.eFrequency.Weekly,
            };
            var nextDuty = transaction.GetNextDuty(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2099, 05, 06), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Weekly_Today()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 21),
                Frequency = Backend.eFrequency.Weekly,
            };
            var nextDuty = transaction.GetNextDuty(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2022, 12, 21), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Weekly_Factor3()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 13),
                Frequency = Backend.eFrequency.Weekly,
            };
            var nextDuty = transaction.GetNextDuty(3, new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2023, 01, 03), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Weekly_LongTimeAgo()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(1376, 01, 01),
                Frequency = Backend.eFrequency.Weekly,
            };
            var nextDuty = transaction.GetNextDuty(new DateOnly(1566, 06, 12));
            Assert.AreEqual(new DateOnly(1566, 06, 20), nextDuty);
        }

    }
}
