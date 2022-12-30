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
        foreach (var style in Current.Styles)
        {
            if (style is FluentTheme theme)
            {
                var brushToUse = theme.Mode == FluentThemeMode.Dark ? Brushes.White : Brushes.Black;

                var labelStyle = new Style(x => x.OfType<Label>());
                labelStyle.Setters.Add(new Setter(Label.ForegroundProperty, brushToUse));
                labelStyle.Setters.Add(new Setter(Label.FontSizeProperty, 35.0));

                var textBlockStyle = new Style(x => x.OfType<TextBlock>());
                textBlockStyle.Setters.Add(new Setter(Label.ForegroundProperty, brushToUse));

                var gridSplitterStyle = new Style(x => x.OfType<GridSplitter>());
                gridSplitterStyle.Setters.Add(new Setter(Label.BackgroundProperty, brushToUse));

                stylesToAdd.Add(labelStyle);
                stylesToAdd.Add(textBlockStyle);
                stylesToAdd.Add(gridSplitterStyle);
            }
        }

        stylesToAdd.ForEach(s => Current.Styles.Add(s));
    }
}