using StudentToolkit.Presentation.Mvvm.Model.Main.ViewModels;
using StudentToolkit.Presentation.Mvvm.Model.Main.Views;
using StudentToolkit.Wpf.Extensions;

namespace StudentToolkit.Wpf;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        ConfigureApp();

        MainWindow = new MainWindow()
        {
            DataContext = new MainWindowViewModel()
            {
                HostedViewModel = new MainViewModel()
            }
        };

        MainWindow.Show();
    }

    private void ConfigureApp()
    {
        this.SetViewToViewModelDataTemplates();
    }
}
