using System.Windows.Markup;

namespace StudentToolkit.Presentation.Controls;

[ContentProperty("Items")]
public class Sidebar : Control
{
    public static readonly DependencyProperty IsHideProperty =
        DependencyProperty.Register(
            nameof(IsHide),
            typeof(bool),
            typeof(Sidebar),
            new PropertyMetadata(false));

    public Sidebar()
    {
        Items = new List<object>();
    }

    public List<object> Items { get; set; }

    public bool IsHide
    {
        get => (bool)GetValue(IsHideProperty);
        set => SetValue(IsHideProperty, value);
    }

    public override void OnApplyTemplate()
    {
        ((Button)GetTemplateChild("HideButton")).Click +=
            (sender, args) => IsHide = !IsHide;

        base.OnApplyTemplate();
    }
}
