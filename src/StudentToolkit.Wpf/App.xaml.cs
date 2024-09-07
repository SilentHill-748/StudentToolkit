using StudentToolkit.Presentation.Mvvm.Model.Main.ViewModels;
using StudentToolkit.Presentation.Mvvm.Model.Main.Views;
using StudentToolkit.Wpf.Extensions;

namespace StudentToolkit.Wpf;

public partial class App : Application
{
    public Container Services { get; } = new Container();

    protected override void OnStartup(StartupEventArgs e)
    {
        ConfigureApp();

        MainWindow = new MainWindow()
        {
            DataContext = Services.GetInstance<MainWindowViewModel>()
        };

        MainWindow.Show();
    }

    private void ConfigureApp()
    {
        this.ConfigureServices();
        this.SetViewToViewModelDataTemplates();
    }
}
