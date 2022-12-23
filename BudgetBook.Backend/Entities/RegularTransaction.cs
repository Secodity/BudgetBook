using EasyUtilities.Enums;
using EasyUtilities.Helper;

namespace BudgetBook.Backend.Entities;
public class RegularTransaction : Transaction
{
    public DateOnly InitDate { get; init; }
    public eFrequency Frequency { get; init; }
    public DateOnly LastExecuted { get; set; }
    public DateOnly GetNextDueDate(DateOnly referenceDate) => NextDueDateCalculator.GetNextDueDate(InitDate, referenceDate, Frequency);
}
