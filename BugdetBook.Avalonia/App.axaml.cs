using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Styling;
using Avalonia.Themes.Fluent;
using BugdetBook.Avalonia.ViewModels;
using BugdetBook.Avalonia.Views;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Reflection.Metadata;

namespace BugdetBook.Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        RefreshStyles();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    public static void RefreshStyles()
    {
        var stylesToAdd = new List<Style>();
        Style labelStyle = null;
        Style textBlockStyle = null;
        Style gridSplitterStyle = null;
        foreach (var style in Application.Current.Styles)
        {
            if (style is FluentTheme theme)
            {
                if (theme.Mode == FluentThemeMode.Dark)
                {
                    labelStyle = new Style(x => x.OfType<Label>());
                    labelStyle.Setters.Add(new Setter(Label.ForegroundProperty, Brushes.White));
                    labelStyle.Setters.Add(new Setter(Label.FontSizeProperty, 35.0));

                    textBlockStyle = new Style(x => x.OfType<TextBlock>());
                    textBlockStyle.Setters.Add(new Setter(Label.ForegroundProperty, Brushes.White));

                    gridSplitterStyle = new Style(x => x.OfType<GridSplitter>());
                    gridSplitterStyle.Setters.Add(new Setter(Label.BackgroundProperty, Brushes.White));
                }
                else
                {
                    labelStyle = new Style(x => x.OfType<Label>());
                    labelStyle.Setters.Add(new Setter(Label.ForegroundProperty, Brushes.Black));
                    labelStyle.Setters.Add(new Setter(Label.FontSizeProperty, 35.0));

                    textBlockStyle = new Style(x => x.OfType<TextBlock>());
                    textBlockStyle.Setters.Add(new Setter(Label.ForegroundProperty, Brushes.Black));

                    gridSplitterStyle = new Style(x => x.OfType<GridSplitter>());
                    gridSplitterStyle.Setters.Add(new Setter(Label.BackgroundProperty, Brushes.Black));
                }
                stylesToAdd.Add(labelStyle);
                stylesToAdd.Add(textBlockStyle);
                stylesToAdd.Add(gridSplitterStyle);
            }
        }

        stylesToAdd.ForEach(s => Application.Current.Styles.Add(s));
    }
}