using System.Windows;
using System.Windows.Controls;

namespace StudentToolkit.WpfCore.CustomControls;

public class PlaceholderTextBox : TextBox
{
    private string _previousText = string.Empty;

    public static readonly DependencyProperty PlaceholderProperty =
        DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(PlaceholderTextBox), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty IsEmptyProperty =
        DependencyProperty.Register(nameof(IsEmpty), typeof(bool), typeof(PlaceholderTextBox), new PropertyMetadata(true));

    static PlaceholderTextBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(PlaceholderTextBox), new FrameworkPropertyMetadata(typeof(PlaceholderTextBox)));
    }

    public PlaceholderTextBox()
    {
        GotFocus += OnGotFocus;
        LostFocus += OnLostFocus;
    }

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
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

    private void OnLostFocus(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(Text))
            Text = _previousText;
    }

    private void OnGotFocus(object sender, RoutedEventArgs e)
    {
        _previousText = Text;

        Text = string.Empty;
    }
}
