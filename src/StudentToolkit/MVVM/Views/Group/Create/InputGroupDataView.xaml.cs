using System.Windows;
using System.Windows.Controls;

namespace StudentToolkit.MVVM.Views.Group.Create;

public partial class InputGroupDataView : UserControl
{
    private readonly Thickness _maximizedWindowContentMargin;
    private readonly Thickness _normalWindowContentMargin;

    private Window? _currentWindow;

    public InputGroupDataView()
    {
        InitializeComponent();

        _maximizedWindowContentMargin = new Thickness(350, 10, 350, 10);
        _normalWindowContentMargin = new Thickness(100, 10, 100, 10);
    }

    private void OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        _currentWindow ??= Window.GetWindow(this);

        if (_currentWindow.WindowState is WindowState.Maximized)
        {
            ContentGrid.Margin = _maximizedWindowContentMargin;
            GroupCodeInputTb.MaxWidth = double.PositiveInfinity;
        }
        else
        {
            ContentGrid.Margin = _normalWindowContentMargin;
            GroupCodeInputTb.MaxWidth = 350;
        }
    }
}
