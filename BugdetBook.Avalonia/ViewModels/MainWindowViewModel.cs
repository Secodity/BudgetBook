
using Avalonia;
using Avalonia.Themes.Fluent;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BugdetBook.Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private bool m_DarkModeChecked;

    public MainWindowViewModel()
    {
        m_DarkModeChecked = true;
    }

    public bool DarkModeChecked
    {
        get
        {
            return m_DarkModeChecked;
        }
        set
        {
            m_DarkModeChecked = value;
            var resourceEntry = Application.Current.Styles.FirstOrDefault(s => s.GetType() == typeof(FluentTheme));
            if(resourceEntry != null)
            {
                var theme = resourceEntry as FluentTheme;
                if (value)
                    theme.Mode = FluentThemeMode.Dark;
                else
                    theme.Mode = FluentThemeMode.Light;
                App.RefreshStyles();
            }
        }
    }
}
