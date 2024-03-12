using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace StudentToolkit.WpfCore.CustomControls;

[ContentProperty("Content")]
public class TileContentControl : Control
{
    public static readonly DependencyProperty ContentProperty
        = DependencyProperty.Register(nameof(Content), typeof(object), typeof(TileContentControl), new PropertyMetadata(null));

    public object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }
}
