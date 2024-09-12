using System.Globalization;
using System.Windows.Data;

namespace StudentToolkit.Presentation.Converters;

public class Bool2VisibilityConverter : IValueConverter
{
    public Bool2VisibilityConverter()
    {
        True = Visibility.Visible;
        False = Visibility.Collapsed;
    }

    public Visibility True { get; set; }
    public Visibility False { get; set; }

    public object Convert(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
    {
        if (value is bool boolValue)
        {
            return boolValue ? True : False;
        }

        return Visibility.Collapsed;
    }

    public object ConvertBack(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }
}
