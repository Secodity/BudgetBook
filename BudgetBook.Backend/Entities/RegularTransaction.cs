using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
                nextDuty = __GetNextWeeklyDuty(dateFrom, factor, 14);
                break;
            case eFrequency.Monthly:
                nextDuty = __GetNextMonthlyDuty(dateFrom, factor);
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
        => __GetNextWeeklyDuty(dateFrom, factor, 7);
    private DateOnly __GetNextWeeklyDuty(DateOnly dateFrom, int factor, int alternativeWeekSize)
    {
        var dayDiff = dateFrom.DayNumber - InitDate.DayNumber;

        var rest = dayDiff % alternativeWeekSize;
        var weeks = dayDiff / alternativeWeekSize;
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
            var nextDuty = dateFrom.AddDays(alternativeWeekSize - rest);

            if (factor > 1)
            {
                weeks = (nextDuty.DayNumber - InitDate.DayNumber) / alternativeWeekSize;
                weekRest = weeks % factor;
            }

            if (weekRest == 0) //If InitDate is in First Period
                return nextDuty;

            return nextDuty.AddDays(alternativeWeekSize * (factor - weekRest));
        }
    }

    private DateOnly __GetNextMonthlyDuty(DateOnly dateFrom, int factor)
    {
        var initDay = InitDate.Day;
        var fromDay = dateFrom.Day;
        if (initDay == fromDay)
            return dateFrom;
        dateFrom = __IncrementMonth(dateFrom, fromDay < initDay ? factor - 1 : factor);
        var maxDaysForDateFrom = DateTime.DaysInMonth(dateFrom.Year, dateFrom.Month);
        if (fromDay < initDay)
        {
            if (initDay <= maxDaysForDateFrom)
                return new DateOnly(dateFrom.Year, dateFrom.Month, initDay);
            else
                return new DateOnly(dateFrom.Year, dateFrom.Month, maxDaysForDateFrom);
        }
        else
        {
            if (initDay <= maxDaysForDateFrom)
                return new DateOnly(dateFrom.Year, dateFrom.Month, initDay);
            else
                return new DateOnly(dateFrom.Year, dateFrom.Month, maxDaysForDateFrom);
        }
    }

    private DateOnly __IncrementMonth(DateOnly dateFrom, int factor)
    {
        var newMonth = dateFrom.Month + factor;
        var newYear = dateFrom.Year;
        while (newMonth > 12)
        {
            newYear++;
            newMonth -= 12;
        }
        var maxDay = DateTime.DaysInMonth(newYear, newMonth);
        return new DateOnly(newYear, newMonth, dateFrom.Day >= maxDay ? maxDay : dateFrom.Day);
    }

}
