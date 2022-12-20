using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBook.Backend.Entities;
public class Account
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; init; } = string.Empty;
    public double Balance { get; set; } = 0;
    public List<Transaction> Transactions { get; init; } = new List<Transaction>();
    public bool RestrictDeposits { get; init; } = false;
    public bool RestrictWithdrawls { get; init; } = false;

    public override string ToString()
    {
        return $"Id: '{Id}' - Name: '{Name} - Balance: '{Balance.ToString("0.00")}'";
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Balance, Transactions, RestrictDeposits, RestrictWithdrawls);
    }
    public override bool Equals(object? obj)
    {
        if(obj is not Account) return false;
        return GetHashCode() == ((Account)obj).GetHashCode();
    }
}
