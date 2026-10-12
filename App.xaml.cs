using System;
using System.IO;
using System.Media;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace MediFlow;

public partial class App : Application
{
    private SoundPlayer? _uiClick;
    private Stream? _uiClickStream;

    public App()
    {
        EventManager.RegisterClassHandler(typeof(ButtonBase), ButtonBase.ClickEvent, new RoutedEventHandler(OnAnyButtonClick), true);
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        try
        {
            var resource = GetResourceStream(new Uri("pack://application:,,,/Assets/UI_Click.wav"));
            if (resource != null)
            {
                _uiClickStream = resource.Stream;
                _uiClick = new SoundPlayer(_uiClickStream);
                _uiClick.LoadAsync();
            }
        }
        catch { }
    }

    private void OnAnyButtonClick(object sender, RoutedEventArgs e)
    {
        try { _uiClick?.Play(); } catch { }
    }
}
