using System.Globalization;
using System.Windows.Data;

namespace StudentToolkit.Presentation.Converters;

public class AddLeftPaddingConverter : IValueConverter
{
    public object Convert(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
    {
        if (value is Thickness padding)
        {
            if (double.TryParse(parameter.ToString(), out double amount))
            {
                padding.Left += amount;
                return padding;
            }
        }

        return value;
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
