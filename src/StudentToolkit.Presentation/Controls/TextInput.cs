namespace StudentToolkit.Presentation.Controls;

public class TextInput : TextBox
{
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

    public static readonly DependencyProperty IsEmptyProperty =
        DependencyProperty.Register(
            nameof(IsEmpty),
            typeof(bool),
            typeof(TextInput),
            new PropertyMetadata(true));

    public TextInput()
    {
        GotFocus += OnGotFocus;
        LostFocus += OnLostFocus;
    }

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

    public bool IsEmpty
    {
        get => (bool)GetValue(IsEmptyProperty);
        set => SetValue(IsEmptyProperty, value);
    }

    protected override void OnTextChanged(TextChangedEventArgs e)
    {
        IsEmpty = string.IsNullOrEmpty(Text);

        base.OnTextChanged(e);
    }

    private void OnGotFocus(object sender, RoutedEventArgs e)
    {
        if (HidePlaceholderIfFocused)
        {
            _previousText = Text;

            Text = string.Empty;
        }
    }

    private void OnLostFocus(object sender, RoutedEventArgs e)
    {
        if (IsEmpty)
        {
            Text = _previousText;
        }
    }
}
