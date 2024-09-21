using System.Windows.Media;

namespace StudentToolkit.Presentation.Controls;

public class SidebarButton : Button
{
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(
            nameof(Icon),
            typeof(ImageSource),
            typeof(SidebarButton),
            new PropertyMetadata(null));

    public ImageSource Icon
    {
        get => (ImageSource)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
}
