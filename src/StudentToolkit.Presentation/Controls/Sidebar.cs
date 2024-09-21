using System.Windows.Markup;

namespace StudentToolkit.Presentation.Controls;

[ContentProperty("Buttons")]
public class Sidebar : Control
{
    public static readonly DependencyProperty IsHideProperty =
        DependencyProperty.Register(
            nameof(IsHide),
            typeof(bool),
            typeof(Sidebar),
            new PropertyMetadata(true));

    public Sidebar()
    {
        Buttons = new List<SidebarButton>();
    }

    public List<SidebarButton> Buttons { get; set; }

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
