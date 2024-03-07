using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace StudentToolkit.WpfCore.CustomControls;

[ContentProperty("Items")]
public class SideBar : Control
{
    public static readonly DependencyProperty ContentVisibilityProperty =
        DependencyProperty.Register("ContentVisibility", typeof(Visibility), typeof(SideBar));
    public static readonly DependencyProperty HideProperty =
        DependencyProperty.Register("Hide", typeof(bool), typeof(SideBar));

    static SideBar()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(SideBar), new FrameworkPropertyMetadata(typeof(SideBar)));
    }

    public SideBar()
    {
        Items = [];
    }

    public List<object> Items { get; set; }

    public Visibility ContentVisibility
    {
        get => (Visibility)GetValue(ContentVisibilityProperty);
        set => SetValue(ContentVisibilityProperty, value);
    }

    public bool Hide
    {
        get => (bool)GetValue(HideProperty);
        set => SetValue(HideProperty, value);
    }

    public override void OnApplyTemplate()
    {
        if (Hide)
            ContentVisibility = Visibility.Collapsed;

        Button hideBtn = (Button)GetTemplateChild("hideBtn");

        hideBtn.Click += OnHideBtnClick;
    }

    private void OnHideBtnClick(object sender, RoutedEventArgs e)
    {
        ContentVisibility = Hide ?
            Visibility.Visible :
            Visibility.Collapsed;

        Hide = !Hide;
    }
}
