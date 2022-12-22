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
                nextDuty = __GetNextDailyDuty(dateFrom, factor);
                //nextDuty = dateFrom.AddDays(1 * (factor - 1));
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
                nextDuty = __GetNextMonthlyDuty(dateFrom, factor * 3);
                break;
            case eFrequency.HalfYearly:
                nextDuty = __GetNextMonthlyDuty(dateFrom, factor * 6);
                break;
            case eFrequency.Yearly:
                nextDuty = __GetNextMonthlyDuty(dateFrom, factor * 12);
                break;
        }
        return nextDuty;
    }

    private DateOnly __GetNextDailyDuty(DateOnly dateFrom, int factor)
    {
        var dayDiff = dateFrom.DayNumber - InitDate.DayNumber;
        var rest = dayDiff % factor;
        return dateFrom.AddDays(factor > 1 ? factor - rest : 0);
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


        var monthsBetween = __CountMonthsBetween(dateFrom, InitDate);
        var monthRest = monthsBetween == 0 ? factor : monthsBetween % factor;

        if (monthRest < 0)
            throw new Exception("Month rest cannot be less than zero, please check");
        else if (monthRest != 0 /*|| factor == 1*/)
            dateFrom = __IncrementMonth(dateFrom, monthsBetween == 0 ? monthRest : factor - monthRest);

        var maxDaysForDateFrom = DateTime.DaysInMonth(dateFrom.Year, dateFrom.Month);
        if (initDay <= maxDaysForDateFrom)
            return new DateOnly(dateFrom.Year, dateFrom.Month, initDay);
        else
            return new DateOnly(dateFrom.Year, Frequency == eFrequency.Yearly ? InitDate.Month : dateFrom.Month, maxDaysForDateFrom);
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

    private int __CountMonthsBetween(DateOnly dateOne, DateOnly dateTwo)
    {
        if (dateOne == dateTwo)
            return 0;

        int months = 0;

        //dateOne = new DateOnly(2023, 5, 17);
        //dateTwo = new DateOnly(2022, 11, 15);
        if (dateOne > dateTwo)
        {
            if (dateOne.Year != dateTwo.Year)
                months = (12 - dateTwo.Month) + dateOne.Month;
            else
                return dateOne.Month - dateTwo.Month;


            months += (dateOne.Year - (dateTwo.Year + 1)) * 12;
        }
        else
        {
            if (dateOne.Year != dateTwo.Year)
                months = (12 - dateOne.Month) + dateTwo.Month;
            else
                return dateTwo.Month - dateOne.Month;
            months += (dateTwo.Year - (dateOne.Year + 1)) * 12;
        }
        return months;
    }

}
