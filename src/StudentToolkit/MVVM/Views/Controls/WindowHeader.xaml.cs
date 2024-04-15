using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using StudentToolkit.WpfCore.Common.Helpers;

namespace StudentToolkit.MVVM.Views.Controls;

public partial class WindowHeader : UserControl
{
    private Window _currentWindow;
    private Point _leftMouseButtonDownPoint;
    private bool _isMoving;

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(WindowHeader));

    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(WindowHeader));

    public WindowHeader()
    {
        InitializeComponent();

        // Default value was changed into OnApplyTemplate method.
        _currentWindow = System.Windows.Application.Current.MainWindow;
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

    private static (double DeltaX, double DeltaY) GetDeltaBetweenTwoPoints(Point point1, Point point2)
    {
        double deltaX = Math.Abs(point1.X - point2.X);
        double deltaY = Math.Abs(point1.Y - point2.Y);

        return (deltaX, deltaY);
    }

    private void MinimizeWindowBtnClick(object sender, RoutedEventArgs e)
        => _currentWindow.WindowState = WindowState.Minimized;

    private void MaximizeWindowBtnClick(object sender, RoutedEventArgs e)
        => ChangeWindowState();

    private void CloseWindowBtnClick(object sender, RoutedEventArgs e)
        => _currentWindow.Close();

    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        _isMoving = true;

        _leftMouseButtonDownPoint = WinApiHelper.GetMousePositionToScreen();
    }

    private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        => _isMoving = false;

    private void OnMouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed && _isMoving)
        {
            Point currentMouseMovePoint = WinApiHelper.GetMousePositionToScreen();

            var (DeltaX, DeltaY) = GetDeltaBetweenTwoPoints(_leftMouseButtonDownPoint, currentMouseMovePoint);

            if (DeltaX > 1 || DeltaY > 1)
            {
                if (_currentWindow.WindowState == WindowState.Maximized)
                {
                    ChangeWindowState();

                    Rect screenArea = WinApiHelper.GetCurrentMonitorArea();

                    SetWindowPosition(screenArea, currentMouseMovePoint);
                }

                _currentWindow.DragMove();
            }
        }
    }

    private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        _isMoving = false;

        Point lastClickPoint = WinApiHelper.GetMousePositionToScreen();

        var (DeltaX, DeltaY) = GetDeltaBetweenTwoPoints(_leftMouseButtonDownPoint, lastClickPoint);

        if (DeltaX < 2 || DeltaY < 2)
        {
            if (e.ChangedButton == MouseButton.Left)
                ChangeWindowState();
        }

        e.Handled = true;
    }

    private void SetWindowPosition(Rect screenSize, Point mousePosition)
    {
        double centerWidthOfWindow = _currentWindow.Width / 2;
        double leftBound = screenSize.Left + centerWidthOfWindow;
        double rightBound = screenSize.Right - centerWidthOfWindow;

        _currentWindow.Left =
            mousePosition.X < leftBound
                ? Math.Max(mousePosition.X, leftBound) - centerWidthOfWindow
                : Math.Min(mousePosition.X, rightBound) - centerWidthOfWindow;

        _currentWindow.Top = screenSize.Top;
    }

    private void ChangeWindowState()
    {
        WindowState windowState = _currentWindow.WindowState;

        if (maximizeWindowBtn.Visibility == Visibility.Visible)
        {
            _currentWindow.WindowState = windowState is WindowState.Normal
                ? WindowState.Maximized
                : WindowState.Normal;
        }
    }
}
