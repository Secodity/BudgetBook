using BudgetBook.Backend.Entities;
using System;

namespace BudgetBook.Test.Entities;

[TestClass]
public class TransactionTests
{
    private const string DUMMY_FROM_GUID = "b3f4791a-af2c-4fba-8616-c4fccb79b9ee";
    private const string DUMMY_TO_GUID = "336f9736-5a8d-427f-a035-fbbbf781ad83";
    [TestMethod]
    public void TestOfTransactionConsturctor_Valid()
    {
        try
        {
            new Transaction()
            {
                OutgoingId = Guid.NewGuid(),
                TargetId = Guid.NewGuid(),
                Amount = 15.25
            };
            new Transaction()
            {
                OutgoingId = Guid.NewGuid(),
                TargetId = Guid.NewGuid(),
                Amount = .25
            };
            new Transaction()
            {
                OutgoingId = Guid.NewGuid(),
                TargetId = Guid.NewGuid(),
                Amount = 15,
                Description = "Test"
            };
            new Transaction()
            {
                OutgoingId = Guid.NewGuid(),
                TargetId = new Guid(),
                Amount = 15
            };
        } catch
        {
            Assert.Fail("There should not be an existing exception.");
        }
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestOfTransactionConstructor_InvalidAmount0()
    {
        new Transaction()
        {
            OutgoingId = Guid.NewGuid(),
            TargetId = Guid.NewGuid(),
            Amount = 0
        };
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestOfTransactionConstructor_InvalidAmountNegative()
    {
        new Transaction()
        {
            OutgoingId = Guid.NewGuid(),
            TargetId = Guid.NewGuid(),
            Amount = -2.25
        };
    }

    [TestMethod]
    public void TestOfTransaction_ToString()
    {
        var transaction = new Transaction()
        {
            OutgoingId = Guid.Parse(DUMMY_FROM_GUID),
            TargetId = Guid.Parse(DUMMY_TO_GUID),
            Amount = 15
        };
        Assert.AreEqual($"From: '{DUMMY_FROM_GUID}' - To: '{DUMMY_TO_GUID}' - Amount: '15.00'", transaction.ToString(), "Transaction_0x01 failed");

        transaction = new Transaction()
        {
            OutgoingId = Guid.Parse(DUMMY_FROM_GUID),
            TargetId = Guid.Parse(DUMMY_TO_GUID),
            Amount = 15,
            Description = "Test"
        };
        Assert.AreEqual($"From: '{DUMMY_FROM_GUID}' - To: '{DUMMY_TO_GUID}' - Amount: '15.00' - Description: Test", transaction.ToString(), "Transaction_0x02 failed");
    }

    [TestMethod]
    public void TestOfTransaction_Equals()
    {
        var transaction1 = new Transaction()
        {
            OutgoingId = Guid.Parse(DUMMY_FROM_GUID),
            TargetId = Guid.Parse(DUMMY_TO_GUID),
            Amount = 15
        };
        var transaction2 = new Transaction()
        {
            OutgoingId = Guid.Parse(DUMMY_FROM_GUID),
            TargetId = Guid.Parse(DUMMY_TO_GUID),
            Amount = 15
        };
        var transaction3 = new Transaction()
        {
            OutgoingId = Guid.Parse(DUMMY_FROM_GUID),
            TargetId = Guid.Parse(DUMMY_TO_GUID),
            Amount = 15,
            Description = "Test"
        };
        var transaction4 = new Transaction()
        {
            OutgoingId = Guid.Parse(DUMMY_FROM_GUID),
            TargetId = Guid.Parse(DUMMY_TO_GUID),
            Amount = 13,
        };
        var transaction5 = new Transaction()
        {
            OutgoingId = Guid.Parse(DUMMY_FROM_GUID),
            TargetId = Guid.NewGuid(),
            Amount = 15,
        };
        var transaction6 = new Transaction()
        {
            OutgoingId = Guid.NewGuid(),
            TargetId = Guid.Parse(DUMMY_TO_GUID),
            Amount = 15,
        };
        string s1 = "Hello World";
        string s2 = $"From: '{DUMMY_FROM_GUID}' - To: '{DUMMY_TO_GUID}' - Amount: '15.00'";

        Assert.IsTrue(transaction1.Equals(transaction2), "Transaction_0x03 failed");
        Assert.IsFalse(transaction1.Equals(transaction3), "Transaction_0x04 failed");
        Assert.IsFalse(transaction1.Equals(transaction4), "Transaction_0x05 failed");
        Assert.IsFalse(transaction1.Equals(transaction5), "Transaction_0x06 failed");
        Assert.IsFalse(transaction1.Equals(transaction5), "Transaction_0x07 failed");
        Assert.IsFalse(transaction1.Equals(s1), "Transaction_0x08 failed");
        Assert.IsFalse(transaction1.Equals(s2), "Transaction_0x09 failed");
    }
}
