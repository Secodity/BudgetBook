using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBook.Backend.Entities;
public class RegularTransaction : Transaction
{
    public DateOnly Date { get; init; }
    public eFrequency Frequency { get; init; }
    public bool IsExecuted { get; set; }

    public DateOnly GetNextDuty()
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        throw new NotImplementedException();
        //return Frequency switch
        //{
            
        //}
    }
}
