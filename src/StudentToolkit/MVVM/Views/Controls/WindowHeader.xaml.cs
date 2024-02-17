using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StudentToolkit.MVVM.Views.Controls;

public partial class WindowHeader : UserControl
{
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

    private void MinimizeWindowBtnClick(object sender, RoutedEventArgs e)
    {
        GetParentWindow().WindowState = WindowState.Minimized;
    }

    private void MaximizeWindowBtnClick(object sender, RoutedEventArgs e)
    {
        Window window = GetParentWindow();

        window.WindowState = window.WindowState is WindowState.Normal ?
            WindowState.Maximized :
            WindowState.Normal;
    }

    private void CloseWindowBtnClick(object sender, RoutedEventArgs e)
    {
        GetParentWindow().Close();
    }

    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
        {
            GetParentWindow().DragMove();
        }
    }

    private Window GetParentWindow()
        => Window.GetWindow(this);
}
