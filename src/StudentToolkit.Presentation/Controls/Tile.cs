using System.Windows.Markup;

namespace StudentToolkit.Presentation.Controls;

[ContentProperty("Content")]
public class Tile : Control
{
    public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register(
            nameof(Content),
            typeof(object),
            typeof(Tile));

    public object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }
}
