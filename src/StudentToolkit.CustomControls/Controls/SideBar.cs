using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace StudentToolkit.CustomControls.Controls;

[ContentProperty("Items")]
public class SideBar : Control
{
    public static readonly DependencyProperty ContentVisibilityProperty =
        DependencyProperty.Register("ContentVisibility", typeof(Visibility), typeof(SideBar));

    private bool _isHidden;

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

    public override void OnApplyTemplate()
    {
        if (ContentVisibility is Visibility.Collapsed)
            _isHidden = true;

        Button hideBtn = (Button)GetTemplateChild("hideBtn");

        hideBtn.Click += OnHideBtnClick;
    }

    private void OnHideBtnClick(object sender, RoutedEventArgs e)
    {
        ContentVisibility = _isHidden ?
            Visibility.Visible :
            Visibility.Collapsed;

        _isHidden = !_isHidden;
    }
}
