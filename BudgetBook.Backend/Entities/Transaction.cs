using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBook.Backend.Entities;
public class Transaction
{
    private double _InternalAmount;

    public Guid OutgoingId { get; init; }
    public Guid TargetId { get; init; }
    public double Amount { 
        get => _InternalAmount;
        init
        {
            if (value <= 0)
                throw new ArgumentException("The value can't be below or equal to 0.", nameof(Amount));
            _InternalAmount = value;
        }
    }
    public string Description { get; init; } = string.Empty;

    public override string ToString()
    {
        return $"From: '{OutgoingId}' - To: '{TargetId}' - Amount: '{Amount.ToString("0.00")}'{(Description.Equals(string.Empty) ? "" : $" - Description: {Description}")}";
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(OutgoingId, TargetId, Amount, Description);
    }
    public override bool Equals(object? obj)
    {
        if (obj is not Transaction) return false;
        return GetHashCode() == ((Transaction)obj).GetHashCode();
    }
}
