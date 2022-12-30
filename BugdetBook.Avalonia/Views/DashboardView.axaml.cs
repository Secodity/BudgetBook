using Avalonia.Controls;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using Avalonia.Markup.Xaml;
using Avalonia.Controls.ApplicationLifetimes;
using BugdetBook.Avalonia.ViewModels;

namespace BugdetBook.Avalonia.Views;

public partial class DashboardView : UserControl
{
    public DashboardView()
    {
        DataContext = new DashboardViewModel();
        InitializeComponent();
        var cbo = this.Find<ComboBox>("cboAccounts");
        if(cbo != null)
        {
            cbo.Items = (DataContext as DashboardViewModel)?.Accounts;
            cbo.SelectedIndex = 0;
        }
    }

}