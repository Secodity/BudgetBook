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

        #region GetNextDuty

        #region Weekly
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
        public void TestOfRegularTransaction_Weekly_YesterdayInitDate()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = Backend.eFrequency.Weekly,
            };
            var nextDuty = transaction.GetNextDuty(new DateOnly(2022, 12, 08));
            Assert.AreEqual(new DateOnly(2022, 12, 14), nextDuty);
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
            Assert.AreEqual(new DateOnly(1566, 06, 13), nextDuty);
        }
        #endregion Weekly

        #region Daily
        [TestMethod]
        public void TestOfRegularTransaction_Daily()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = Backend.eFrequency.Daily,
            };
            var nextDuty = transaction.GetNextDuty(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2022, 12, 22), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Daily_InitDateInFuture()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2099, 05, 06),
                Frequency = Backend.eFrequency.Daily,
            };
            var nextDuty = transaction.GetNextDuty(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2099, 05, 06), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Daily_Today()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 21),
                Frequency = Backend.eFrequency.Daily,
            };
            var nextDuty = transaction.GetNextDuty(new DateOnly(2022, 12, 28));
            Assert.AreEqual(new DateOnly(2022, 12, 29), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Daily_Factor3()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 13),
                Frequency = Backend.eFrequency.Daily,
            };
            var nextDuty = transaction.GetNextDuty(3, new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2022, 12, 24), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Daily_LongTimeAgo()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(1376, 01, 01),
                Frequency = Backend.eFrequency.Daily,
            };
            var nextDuty = transaction.GetNextDuty(new DateOnly(1566, 06, 12));
            Assert.AreEqual(new DateOnly(1566, 06, 13), nextDuty);
        }
        #endregion Daily

        #region EverySecondWeek
        [TestMethod]
        public void TestOfRegularTransaction_EverySecondWeek()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = Backend.eFrequency.EverySecondWeek,
            };
            var nextDuty = transaction.GetNextDuty(new DateOnly(2022, 12, 20));
            Assert.AreEqual(new DateOnly(2022, 12, 21), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_EverySecondWeek_YesterdayInitDate()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = Backend.eFrequency.EverySecondWeek,
            };
            var nextDuty = transaction.GetNextDuty(new DateOnly(2022, 12, 08));
            Assert.AreEqual(new DateOnly(2022, 12, 21), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_EverySecondWeek_InitDateInFuture()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2099, 05, 06),
                Frequency = Backend.eFrequency.EverySecondWeek,
            };
            var nextDuty = transaction.GetNextDuty(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2099, 05, 06), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_EverySecondWeek_Today()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = Backend.eFrequency.EverySecondWeek,
            };
            var nextDuty = transaction.GetNextDuty(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2022, 12, 21), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_EverySecondWeek_Factor3()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 13),
                Frequency = Backend.eFrequency.EverySecondWeek,
            };
            var nextDuty = transaction.GetNextDuty(3, new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2023, 01, 24), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_EverySecondWeek_LongTimeAgo()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(1376, 01, 01),
                Frequency = Backend.eFrequency.EverySecondWeek,
            };
            var nextDuty = transaction.GetNextDuty(new DateOnly(1566, 06, 12));
            Assert.AreEqual(new DateOnly(1566, 06, 20), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_EverySecondWeek_ABitTimeAgo()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 11, 29),
                Frequency = Backend.eFrequency.EverySecondWeek,
            };
            var nextDuty = transaction.GetNextDuty(new DateOnly(2022, 12, 14));
            Assert.AreEqual(new DateOnly(2022, 12, 27), nextDuty);
        }
        #endregion EverySecondWeek

        #endregion GetNextDuty

    }
}
