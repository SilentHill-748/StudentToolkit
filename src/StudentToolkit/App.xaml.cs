using System.Threading.Tasks;
using System.Windows;

using StudentToolkit.Configuration;

using DotNetApplication = System.Windows.Application;

namespace StudentToolkit;

public partial class App : DotNetApplication
{
    private readonly AppOptions _options = new();

    public App()
    {
        _options.RegisterCustomExceptionMessages();

        DispatcherUnhandledException += _options.OnExceptionHandler;
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        _options.RegisterServices(e.Args);
        _options.ApplyDataTemplates(Resources);

        await SetStartupViewModelAsync();

        MainWindow = _options.Services.GetInstance<MainWindow>();
        MainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _options.Dispose();
    }

    private async Task SetStartupViewModelAsync()
    {
        Container services = _options.Services;
        
        var groupStore = services.GetInstance<GroupStore>();

        await groupStore.LoadAsync();

        ViewModel startupVm = string.IsNullOrEmpty(groupStore.Group.GroupCode)
            ? services.GetInstance<CreateGroupViewModel>()
            : services.GetInstance<MainViewModel>();

        NavigationService.Navigate<NavigationViewModel>(startupVm);
    }
}
