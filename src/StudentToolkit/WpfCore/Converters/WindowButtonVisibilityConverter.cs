using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StudentToolkit.WpfCore.Converters;

public class WindowButtonVisibilityConverter : IValueConverter
{
    public object Convert(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
    {
        WindowButton button = GetWindowButtonFromParameter(parameter);
        ResizeMode resizeMode = (ResizeMode)value;

        return CreateVisibility(resizeMode, button);
    }

    public object ConvertBack(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }

    private static WindowButton GetWindowButtonFromParameter(object parameter)
    {
        Enum.TryParse(typeof(WindowButton), (string)parameter, out var button);

        if (button is null)
            return WindowButton.Maximize;

        return (WindowButton)button;
    }

    private static Visibility CreateVisibility(ResizeMode resizeMode, WindowButton button)
    {
        return resizeMode switch
        {
            ResizeMode.NoResize => Visibility.Collapsed,

            ResizeMode.CanMinimize =>
                button == WindowButton.Minimize ?
                    Visibility.Visible :
                    Visibility.Collapsed,

            _ => Visibility.Visible
        };
    }
}
