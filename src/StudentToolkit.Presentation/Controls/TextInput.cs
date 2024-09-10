namespace StudentToolkit.Presentation.Controls;

public class TextInput : TextBox
{
    private bool _isEmpty;
    private string _previousText = string.Empty;

    public static readonly DependencyProperty PlaceholderProperty =
        DependencyProperty.Register(
            nameof(Placeholder),
            typeof(string),
            typeof(TextInput),
            new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty HidePlaceholderIfFocusedProperty =
        DependencyProperty.Register(
            nameof(HidePlaceholderIfFocused),
            typeof(bool),
            typeof(TextInput),
            new PropertyMetadata(false));

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public bool HidePlaceholderIfFocused
    {
        get => (bool)GetValue(HidePlaceholderIfFocusedProperty);
        set => SetValue(HidePlaceholderIfFocusedProperty, value);
    }

    protected override void OnTextChanged(TextChangedEventArgs e)
    {
        _isEmpty = string.IsNullOrEmpty(Text);

        base.OnTextChanged(e);
    }

    protected override void OnGotFocus(RoutedEventArgs e)
    {
        if (_isEmpty)
        {
            Text = _previousText;
        }

        base.OnGotFocus(e);
    }

    protected override void OnLostFocus(RoutedEventArgs e)
    {
        if (HidePlaceholderIfFocused)
        {
            _previousText = Text;

            Text = string.Empty;
        }

        base.OnLostFocus(e);
    }
}
