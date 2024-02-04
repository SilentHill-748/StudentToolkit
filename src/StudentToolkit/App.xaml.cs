using System.Threading.Tasks;
using System.Windows;

using StudentToolkit.Configuration;

using DotNetApplication = System.Windows.Application;

namespace StudentToolkit;

public partial class App : DotNetApplication
{
    private const string ApplicationInitializationErrorMessage = "Ошибка инициализации! Необходимо переустановить программу! Если проблема повторяется, свяжитесь с автором программы.";

    private readonly AppOptions _options = new();

    public App()
    {
        DispatcherUnhandledException += _options.GlobalExceptionHandler;
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        bool isSuccessInit = false;

        try
        {
            await InternalStartupAsync(e.Args);

            isSuccessInit = true;
        }
        catch
        {
            NotificationService.Alert("Критическая ошибка!", ApplicationInitializationErrorMessage);
            throw;
        }
        finally
        {
            if (!isSuccessInit)
            {
                Shutdown();
            }
        }
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _options.Dispose();
    }

    private async Task InternalStartupAsync(string[] args)
    {
        _options.RegisterServices(args);
        _options.ApplyDataTemplates(Resources);

        await SetStartupViewModelAsync();

        MainWindow = _options.Services.GetInstance<MainWindow>();
        MainWindow.Show();
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
