using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBook.Backend.Entities;
public class RegularTransaction : Transaction
{
    public DateOnly InitDate { get; init; }
    public eFrequency Frequency { get; init; }
    public bool IsExecuted { get; set; }

    public DateOnly GetNextDuty()
        => GetNextDuty(1, DateOnly.FromDateTime(DateTime.Now));

    public DateOnly GetNextDuty(DateOnly CurrentDate)
        => GetNextDuty(1, CurrentDate);

    public DateOnly GetNextDuty(int Factor)
      => GetNextDuty(Factor, DateOnly.FromDateTime(DateTime.Now));

    public DateOnly GetNextDuty(int Factor, DateOnly CurrentDate)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        var NextDuty = DateOnly.FromDateTime(DateTime.Now);

        if (InitDate >= today)
            return today;

        switch (Frequency)
        {
            case eFrequency.Daily:
                NextDuty = today.AddDays(1 * Factor);
                break;
            case eFrequency.Weekly:
                NextDuty = __GetNextWeeklyDuty(today, Factor);
                break;
            case eFrequency.EverySecondWeek:
                NextDuty = today.AddDays(14);
                break;
            case eFrequency.Monthly:
                NextDuty = today.AddMonths(1);
                break;
            case eFrequency.Quaterly:
                NextDuty = today.AddMonths(3);
                break;
            case eFrequency.HalfYearly:
                NextDuty = today.AddMonths(6);
                break;
            case eFrequency.Yearly:
                NextDuty = today.AddYears(1);
                break;
        }
        return NextDuty;
    }

    private DateOnly __GetNextWeeklyDuty(DateOnly today, int factor)
    {
        var DayDiff = today.DayNumber - InitDate.DayNumber;

        var Rest = DayDiff % 7;
        var Weeks = DayDiff / 7;
        var WeekRest = Weeks % factor;

        if (Rest == 0)
        {
            if (WeekRest == 0)
                return today;
            else
                return today.AddDays(7 * (factor - WeekRest));
        }
        else
        {
            var NextDuty = today.AddDays(7 - Rest);
            Weeks = (NextDuty.DayNumber - InitDate.DayNumber) / 7;
            WeekRest = Weeks % factor;
            return NextDuty.AddDays(7 * (factor - WeekRest));
        }
    }
}
