using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StudentToolkit.MVVM.Views.Controls;

public partial class WindowHeader : UserControl
{
    // Window will never be null.
    private Window? _currentWindow;

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(WindowHeader));

    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(ImageSource), typeof(WindowHeader));

    public WindowHeader()
    {
        InitializeComponent();
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public ImageSource Icon
    {
        get => (ImageSource)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public override void OnApplyTemplate()
    {
        _currentWindow = Window.GetWindow(this);
        
        _currentWindow.SourceInitialized += (sender, args) =>
        {
            new WindowInteropService(_currentWindow)
                .AddWindowProcedureHook();
        };

        base.OnApplyTemplate();
    }

    private void MinimizeWindowBtnClick(object sender, RoutedEventArgs e)
    {
        _currentWindow!.WindowState = WindowState.Minimized;
    }

    private void MaximizeWindowBtnClick(object sender, RoutedEventArgs e)
    {
        _currentWindow!.WindowState = _currentWindow.WindowState == WindowState.Normal
            ? WindowState.Maximized
            : WindowState.Normal;
    }

    private void CloseWindowBtnClick(object sender, RoutedEventArgs e)
    {
        _currentWindow!.Close();
    }

    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
        {
            _currentWindow!.DragMove();
        }
    }
}
