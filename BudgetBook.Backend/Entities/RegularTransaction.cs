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

    public DateOnly GetNextDuty(DateOnly dateFrom)
        => GetNextDuty(1, dateFrom);

    public DateOnly GetNextDuty(int factor)
      => GetNextDuty(factor, DateOnly.FromDateTime(DateTime.Now));

    public DateOnly GetNextDuty(int factor, DateOnly dateFrom)
    {
        var nextDuty = DateOnly.FromDateTime(DateTime.Now);

        if (InitDate >= dateFrom)
            return InitDate;

        switch (Frequency)
        {
            case eFrequency.Daily:
                nextDuty = dateFrom.AddDays(1 * factor);
                break;
            case eFrequency.Weekly:
                nextDuty = __GetNextWeeklyDuty(dateFrom, factor);
                break;
            case eFrequency.EverySecondWeek:
                nextDuty = dateFrom.AddDays(14);
                break;
            case eFrequency.Monthly:
                nextDuty = dateFrom.AddMonths(1);
                break;
            case eFrequency.Quaterly:
                nextDuty = dateFrom.AddMonths(3);
                break;
            case eFrequency.HalfYearly:
                nextDuty = dateFrom.AddMonths(6);
                break;
            case eFrequency.Yearly:
                nextDuty = dateFrom.AddYears(1);
                break;
        }
        return nextDuty;
    }

    private DateOnly __GetNextWeeklyDuty(DateOnly dateFrom, int factor)
    {
        var dayDiff = dateFrom.DayNumber - InitDate.DayNumber;

        var rest = dayDiff % 7;
        var weeks = dayDiff / 7;
        var weekRest = weeks % factor;

        if (rest == 0)
        {
            if (weekRest == 0)
                return dateFrom;
            else
                return dateFrom.AddDays(7 * (factor - weekRest));
        }
        else
        {
            var nextDuty = dateFrom.AddDays(7 - rest);
            weeks = (nextDuty.DayNumber - InitDate.DayNumber) / 7;
            weekRest = weeks % factor;
            return nextDuty.AddDays(7 * (factor - weekRest));
        }
    }
}
