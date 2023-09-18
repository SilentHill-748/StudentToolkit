using System.Windows;

using StudentToolkit.MVVM.Views.Windows;
using StudentToolkit.MVVM.ViewModels;

namespace StudentToolkit;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow(new MainViewModel());

        MainWindow.Show();
    }
}
