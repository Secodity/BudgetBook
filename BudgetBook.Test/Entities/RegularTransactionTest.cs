using BudgetBook.Backend.Entities;
using EasyUtilities.Enums;
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

        #region NextDueDate

        #region Weekly
        [TestMethod]
        public void TestOfRegularTransaction_Weekly()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = eFrequency.Weekly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2022, 12, 21), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Weekly_YesterdayInitDate()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = eFrequency.Weekly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 08));
            Assert.AreEqual(new DateOnly(2022, 12, 14), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Weekly_InitDateInFuture()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2099, 05, 06),
                Frequency = eFrequency.Weekly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2099, 05, 06), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Weekly_Today()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 21),
                Frequency = eFrequency.Weekly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2022, 12, 21), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Weekly_LongTimeAgo()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(1376, 01, 01),
                Frequency = eFrequency.Weekly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(1566, 06, 12));
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
                Frequency = eFrequency.Daily,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2022, 12, 21), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Daily_InitDateInFuture()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2099, 05, 06),
                Frequency = eFrequency.Daily,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2099, 05, 06), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Daily_Today()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 21),
                Frequency = eFrequency.Daily,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 28));
            Assert.AreEqual(new DateOnly(2022, 12, 28), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Daily_LongTimeAgo()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(1376, 01, 01),
                Frequency = eFrequency.Daily,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(1566, 06, 12));
            Assert.AreEqual(new DateOnly(1566, 06, 12), nextDuty);
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
                Frequency = eFrequency.EverySecondWeek,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 20));
            Assert.AreEqual(new DateOnly(2022, 12, 21), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_EverySecondWeek_YesterdayInitDate()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = eFrequency.EverySecondWeek,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 08));
            Assert.AreEqual(new DateOnly(2022, 12, 21), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_EverySecondWeek_InitDateInFuture()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2099, 05, 06),
                Frequency = eFrequency.EverySecondWeek,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2099, 05, 06), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_EverySecondWeek_Today()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = eFrequency.EverySecondWeek,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2022, 12, 21), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_EverySecondWeek_LongTimeAgo()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(1376, 01, 01),
                Frequency = eFrequency.EverySecondWeek,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(1566, 06, 12));
            Assert.AreEqual(new DateOnly(1566, 06, 20), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_EverySecondWeek_ABitTimeAgo()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 11, 29),
                Frequency = eFrequency.EverySecondWeek,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 14));
            Assert.AreEqual(new DateOnly(2022, 12, 27), nextDuty);
        }
        #endregion EverySecondWeek

        #region Monthly
        [TestMethod]
        public void TestOfRegularTransaction_Monthly()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = eFrequency.Monthly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 20));
            Assert.AreEqual(new DateOnly(2023, 01, 07), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Monthly_YesterdayInitDate()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = eFrequency.Monthly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 08));
            Assert.AreEqual(new DateOnly(2023, 01, 07), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Monthly_InitDateInFuture()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2099, 05, 06),
                Frequency = eFrequency.Monthly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2099, 05, 06), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Monthly_Today()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = eFrequency.Monthly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2023, 01, 07));
            Assert.AreEqual(new DateOnly(2023, 01, 07), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Monthly_LongTimeAgo()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(1376, 01, 01),
                Frequency = eFrequency.Monthly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(1566, 06, 12));
            Assert.AreEqual(new DateOnly(1566, 07, 01), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Monthly_ABitTimeAgo()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 11, 29),
                Frequency = eFrequency.Monthly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 14));
            Assert.AreEqual(new DateOnly(2022, 12, 29), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Monthly_MoreDaysThanNextMonth()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 01, 31),
                Frequency = eFrequency.Monthly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 02, 14));
            Assert.AreEqual(new DateOnly(2022, 02, 28), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Monthly_MoreDaysThanNextMonth_LeapYear()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2023, 01, 31),
                Frequency = eFrequency.Monthly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2024, 02, 14));
            Assert.AreEqual(new DateOnly(2024, 02, 29), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Monthly_MoreDaysThanNextMonth_InitOnLeapYearDay()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2024, 02, 28),
                Frequency = eFrequency.Monthly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2024, 03, 01));
            Assert.AreEqual(new DateOnly(2024, 03, 28), nextDuty);
        }
        #endregion Monthly

        #region Quaterly
        [TestMethod]
        public void TestOfRegularTransaction_Quaterly()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = eFrequency.Quaterly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 20));
            Assert.AreEqual(new DateOnly(2023, 03, 07), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Quaterly_YesterdayInitDate()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = eFrequency.Quaterly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 08));
            Assert.AreEqual(new DateOnly(2023, 03, 07), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Quaterly_InitDateInFuture()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2099, 05, 06),
                Frequency = eFrequency.Quaterly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2099, 05, 06), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Quaterly_Today()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = eFrequency.Quaterly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2023, 01, 07));
            Assert.AreEqual(new DateOnly(2023, 01, 07), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Quaterly_LongTimeAgo()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(1376, 01, 01),
                Frequency = eFrequency.Quaterly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(1566, 06, 12));
            Assert.AreEqual(new DateOnly(1566, 07, 01), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Quaterly_MoreDaysThanNextMonth()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 11, 29),
                Frequency = eFrequency.Quaterly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 14));
            Assert.AreEqual(new DateOnly(2023, 02, 28), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Quaterly_ABitTimeAgo()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 01, 31),
                Frequency = eFrequency.Quaterly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 02, 14));
            Assert.AreEqual(new DateOnly(2022, 04, 30), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Quaterly_MoreDaysThanNextMonth_LeapYear()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2023, 01, 31),
                Frequency = eFrequency.Quaterly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2024, 02, 14));
            Assert.AreEqual(new DateOnly(2024, 04, 30), nextDuty);
        }
        #endregion Quaterly

        #region HalfYearly
        [TestMethod]
        public void TestOfRegularTransaction_HalfYearly()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = eFrequency.HalfYearly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 20));
            Assert.AreEqual(new DateOnly(2023, 06, 07), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_HalfYearly_YesterdayInitDate()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = eFrequency.HalfYearly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 08));
            Assert.AreEqual(new DateOnly(2023, 06, 07), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_HalfYearly_InitDateInFuture()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2099, 05, 06),
                Frequency = eFrequency.HalfYearly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2099, 05, 06), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_HalfYearly_Today()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = eFrequency.HalfYearly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2023, 01, 07));
            Assert.AreEqual(new DateOnly(2023, 01, 07), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_HalfYearly_LongTimeAgo()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(1376, 01, 01),
                Frequency = eFrequency.HalfYearly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(1566, 06, 12));
            Assert.AreEqual(new DateOnly(1566, 07, 01), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_HalfYearly_MoreDaysThanNextMonth()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 11, 29),
                Frequency = eFrequency.HalfYearly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 14));
            Assert.AreEqual(new DateOnly(2023, 05, 29), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_HalfYearly_ABitTimeAgo()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 01, 31),
                Frequency = eFrequency.HalfYearly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 02, 14));
            Assert.AreEqual(new DateOnly(2022, 07, 31), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_HalfYearly_MoreDaysThanNextMonth_LeapYear()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2023, 01, 31),
                Frequency = eFrequency.HalfYearly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2024, 02, 14));
            Assert.AreEqual(new DateOnly(2024, 07, 31), nextDuty);
        }
        #endregion HalfYearly

        #region Yearly
        [TestMethod]
        public void TestOfRegularTransaction_Yearly()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = eFrequency.Yearly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 20));
            Assert.AreEqual(new DateOnly(2023, 12, 07), nextDuty);
        }

        [TestMethod]

        public void TestOfRegularTransaction_Yearly_YesterdayInitDate()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = eFrequency.Yearly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 08));
            Assert.AreEqual(new DateOnly(2023, 12, 07), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Yearly_InitDateInFuture()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2099, 05, 06),
                Frequency = eFrequency.Yearly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 21));
            Assert.AreEqual(new DateOnly(2099, 05, 06), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Yearly_Today()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = eFrequency.Yearly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2023, 01, 07));
            Assert.AreEqual(new DateOnly(2023, 01, 07), nextDuty);
        }
        [TestMethod]
        public void TestOfRegularTransaction_Yearly_LongTimeAgo()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(1376, 01, 01),
                Frequency = eFrequency.Yearly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(1576, 06, 12));
            Assert.AreEqual(new DateOnly(1577, 01, 01), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Yearly_MoreDaysThanNextMonth()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 11, 29),
                Frequency = eFrequency.Yearly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 12, 14));
            Assert.AreEqual(new DateOnly(2023, 11, 29), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Yearly_ABitTimeAgo()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 01, 31),
                Frequency = eFrequency.Yearly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2022, 02, 14));
            Assert.AreEqual(new DateOnly(2023, 01, 31), nextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Yearly_MoreDaysThanNextMonth_LeapYear()
        {
            var transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2023, 01, 31),
                Frequency = eFrequency.Yearly,
            };
            var nextDuty = transaction.GetNextDueDate(new DateOnly(2024, 02, 14));
            Assert.AreEqual(new DateOnly(2025, 01, 31), nextDuty);
        }

        #endregion Yearly

        #endregion NextDueDate

    }
}
