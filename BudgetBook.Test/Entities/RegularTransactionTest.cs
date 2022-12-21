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
        public void TestOfRegularTransaction_Month()
        {
            var Transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 07),
                Frequency = Backend.eFrequency.Weekly,
            };
            var NextDuty = Transaction.GetNextDuty(DateOnly.FromDateTime(DateTime.Now));
            Assert.AreEqual(new DateOnly(2022, 12, 21), NextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Month_InFuture()
        {
            var Transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2099, 05, 06),
                Frequency = Backend.eFrequency.Weekly,
            };
            var NextDuty = Transaction.GetNextDuty(DateOnly.FromDateTime(DateTime.Now));
            Assert.AreEqual(DateOnly.FromDateTime(DateTime.Now), NextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Month_Today()
        {
            var Transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = DateOnly.FromDateTime(DateTime.Now),
                Frequency = Backend.eFrequency.Weekly,
            };
            var NextDuty = Transaction.GetNextDuty(DateOnly.FromDateTime(DateTime.Now));
            Assert.AreEqual(DateOnly.FromDateTime(DateTime.Now), NextDuty);
        }

        [TestMethod]
        public void TestOfRegularTransaction_Month_Factor3()
        {
            var Transaction = new RegularTransaction()
            {
                Amount = 13,
                InitDate = new DateOnly(2022, 12, 13),
                Frequency = Backend.eFrequency.Weekly,
            };
            var NextDuty = Transaction.GetNextDuty(3, DateOnly.FromDateTime(DateTime.Now));
            Assert.AreEqual(new DateOnly(2023, 01, 03), NextDuty);
        }

    }
}
