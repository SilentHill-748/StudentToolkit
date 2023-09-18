using System.Windows;

using StudentToolkit.MVVM.ViewModels;

namespace StudentToolkit.MVVM.Views.Windows;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();

        this.DataContext = viewModel;
    }
}
