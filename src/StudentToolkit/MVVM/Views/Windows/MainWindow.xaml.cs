using System.Windows;

namespace StudentToolkit.MVVM.Views.Windows;

public partial class MainWindow : Window
{
    public MainWindow(NavigationViewModel viewModel)
    {
        InitializeComponent();

        this.DataContext = viewModel;
    }
}
