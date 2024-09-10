namespace StudentToolkit.Presentation.Controls;

public class InputField : Control
{
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(object),
            typeof(InputField));

    public static readonly DependencyProperty FieldProperty =
        DependencyProperty.Register(
            nameof(Field),
            typeof(object),
            typeof(InputField));

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
