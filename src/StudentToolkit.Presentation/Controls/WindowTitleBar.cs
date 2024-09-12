
namespace StudentToolkit.Presentation.Controls;

public class WindowTitleBar : Control
{
#pragma warning disable CS8618
    private Window _hostWindow;
#pragma warning restore CS8618

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(WindowTitleBar),
            new PropertyMetadata(string.Empty));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        _hostWindow = Window.GetWindow(this);
        _hostWindow.MouseLeftButtonDown += (sender, args) => _hostWindow.DragMove();

        GetControlButton("MinimizeButton").Click += OnMinimizeButtonClick;
        GetControlButton("MaximizeButton").Click += OnMaximizeButtonClick;
        GetControlButton("CloseWindowButton").Click += OnCloseWindowButtonClick;
    }

    private Button GetControlButton(string templateName)
    {
        Button? btn = GetTemplateChild(templateName) as Button;

        return btn
            ?? throw new Exception($"Window titlebar control button isn't found by template name: {templateName}");
    }

    private void OnMinimizeButtonClick(object? sender, RoutedEventArgs args)
        => _hostWindow.WindowState = WindowState.Minimized;

    private void OnMaximizeButtonClick(object? sender, RoutedEventArgs args)
    {
        _hostWindow.WindowState = _hostWindow.WindowState == WindowState.Normal
            ? WindowState.Maximized
            : WindowState.Normal;
    }

    private void OnCloseWindowButtonClick(object? sender, RoutedEventArgs args)
        => _hostWindow?.Close();
}
