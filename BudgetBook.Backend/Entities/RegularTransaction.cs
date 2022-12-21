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

    public DateOnly GetNextDuty(DateOnly currentDate)
        => GetNextDuty(1, currentDate);

    public DateOnly GetNextDuty(int factor)
      => GetNextDuty(factor, DateOnly.FromDateTime(DateTime.Now));

    public DateOnly GetNextDuty(int factor, DateOnly currentDate)
    {
        var today = DateOnly.FromDateTime(DateTime.Now);
        var nextDuty = DateOnly.FromDateTime(DateTime.Now);

        if (InitDate >= today)
            return InitDate;

        switch (Frequency)
        {
            case eFrequency.Daily:
                nextDuty = today.AddDays(1 * factor);
                break;
            case eFrequency.Weekly:
                nextDuty = __GetNextWeeklyDuty(today, factor);
                break;
            case eFrequency.EverySecondWeek:
                nextDuty = today.AddDays(14);
                break;
            case eFrequency.Monthly:
                nextDuty = today.AddMonths(1);
                break;
            case eFrequency.Quaterly:
                nextDuty = today.AddMonths(3);
                break;
            case eFrequency.HalfYearly:
                nextDuty = today.AddMonths(6);
                break;
            case eFrequency.Yearly:
                nextDuty = today.AddYears(1);
                break;
        }
        return nextDuty;
    }

    private DateOnly __GetNextWeeklyDuty(DateOnly today, int factor)
    {
        var dayDiff = today.DayNumber - InitDate.DayNumber;

        var rest = dayDiff % 7;
        var weeks = dayDiff / 7;
        var weekRest = weeks % factor;

        if (rest == 0)
        {
            if (weekRest == 0)
                return today;
            else
                return today.AddDays(7 * (factor - weekRest));
        }
        else
        {
            var nextDuty = today.AddDays(7 - rest);
            weeks = (nextDuty.DayNumber - InitDate.DayNumber) / 7;
            weekRest = weeks % factor;
            return nextDuty.AddDays(7 * (factor - weekRest));
        }
    }
}
