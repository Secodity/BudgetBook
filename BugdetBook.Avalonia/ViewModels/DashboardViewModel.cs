using Avalonia.Controls;
using BudgetBook.Backend.Entities;
using DynamicData;
using DynamicData.Kernel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugdetBook.Avalonia.ViewModels
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            Accounts = __GetAccounts();
            XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = new string [] {"Balance" }, // Accounts.Select(x => x.Name).ToList(),
                    LabelsRotation = 0,
                    SeparatorsPaint = new SolidColorPaint(new SKColor(200, 200, 200)),
                    //SeparatorsAtCenter = false,
                    TicksPaint = new SolidColorPaint(new SKColor(35, 35, 35)),
                    TicksAtCenter = true
                }
            };
        }

        public List<Account> Accounts { get; set; }

        private List<Account> __GetAccounts()
        {
            return new List<Account>
            {
                new Account {Name = "Account 1", Balance = 972.52 },
                new Account {Name = "Account 2", Balance = -451.93 },
                new Account {Name = "Account 3", Balance = 253.91 },
            };
        }

        public ISeries[] Series => __GetRandomSeries();

        private ISeries[] __GetRandomSeries()
        {
            var lst = new List<ISeries>();
            foreach (var account in Accounts)
            {
                lst.Add(new ColumnSeries<double>
                {
                    Name = account.Name,
                    Values = new double[] { account.Balance }
                });
            }
            return lst.ToArray();
        }

        public Axis[] XAxes { get; set; }

    }
}
