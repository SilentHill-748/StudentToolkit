using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace StudentToolkit.WpfCore.CustomControls;

[ContentProperty(nameof(Field))]
public class InputField : Control
{
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(object),
            typeof(InputField),
            new PropertyMetadata(null));

    public static readonly DependencyProperty FieldProperty =
        DependencyProperty.Register(
            nameof(Field),
            typeof(object),
            typeof(InputField),
            new PropertyMetadata(null));

    public object Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public object Field
    {
        get => GetValue(FieldProperty);
        set => SetValue(FieldProperty, value);
    }
}
