using System.Threading.Tasks;
using System.Windows;

using StudentToolkit.Configuration;

using DotNetApplication = System.Windows.Application;

namespace StudentToolkit;

public partial class App : DotNetApplication
{
    private readonly AppOptions _options = new();

    private bool _isSuccessInit;

    public App()
    {
        DispatcherUnhandledException += AppUnhandledExceptionHandler;
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        try
        {
            _isSuccessInit = await InternalStartupAsync(e.Args);
        }
        catch (Exception ex) when (ex.IsNotWrapped())
        {
            throw ex.WrapWithMessage("Application initialization was finished with an exception.");
        }
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _options.Dispose();
    }
    
    private void AppUnhandledExceptionHandler(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        _options.GlobalExceptionHandler(e.Exception);

        if (!_isSuccessInit)
            Shutdown();

        e.Handled = true;
    }

    private async Task<bool> InternalStartupAsync(string[] args)
    {
        _options.RegisterServices(args);
        _options.ApplyDataTemplates(Resources);

        await SetStartupViewModelAsync();

        MainWindow = _options.Services.GetInstance<MainWindow>();
        MainWindow.Show();

        return true;
    }

    private async Task SetStartupViewModelAsync()
    {
        Container services = _options.Services;
        
        var groupStore = services.GetInstance<IGroupStore>();

        await groupStore.LoadAsync();

        ViewModel startupVm = string.IsNullOrEmpty(groupStore.Group.GroupCode)
            ? services.GetInstance<CreateGroupViewModel>()
            : services.GetInstance<MainViewModel>();

        NavigationService.Navigate<NavigationViewModel>(startupVm);
    }
}
