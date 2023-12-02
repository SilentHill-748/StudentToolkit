using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

using StudentToolkit.Domain.Exceptions;
using StudentToolkit.MVVM.Stores;
using StudentToolkit.WpfCore.Common.Constants;
using StudentToolkit.WpfCore.Exceptions;

using DotNetApplication = System.Windows.Application;

namespace StudentToolkit;

public partial class App : DotNetApplication
{
    private readonly Container _container = new();

    public App()
    {
        CustomExceptionMessages.Register<GroupNotFoundException>(ExceptionMessageConstants.GroupNotFound);

        DispatcherUnhandledException += OnUnhandledExceptionCatched;
    }

    private void OnUnhandledExceptionCatched(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        var logger = _container.GetInstance<ILogger>();
        var exception = e.Exception;

        var logMessage = $"{exception.Source}: {exception.Message}";
        var userMessage = CustomExceptionMessages.GetMessage(exception);

        logger.Fatal(exception, logMessage);

        DialogService.ShowNotification("Критическая ошибка!", userMessage, NotificationIcon.Error);
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        AddServices(e.Args);
        ApplyDataTemplates();

        var startupVm = await GetStartupViewModelAsync();

        MainWindow = new MainWindow(
            new NavigationViewModel(startupVm));

        MainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _container.Dispose();

        base.OnExit(e);
    }

    private async Task<ViewModel> GetStartupViewModelAsync()
    {
        var store = _container.GetInstance<GroupStore>();

        await store.LoadAsync();

        if (string.IsNullOrEmpty(store.Group.GroupCode))
        {
            return _container.GetInstance<CreateGroupViewModel>();
        }

        return _container.GetInstance<MainViewModel>();
    }

    private void AddServices(string[] args)
    {
        _container
            .RegisterWpfServices()
            .RegisterApplicationServices(typeof(App).Assembly)
            .RegisterInfrastructureServices(args)
            .Verify();
    }

    private void ApplyDataTemplates()
    {
        var dataTemplates = _container
            .GetInstance<DataTemplateService>()
            .GenerateDataTemplates();

        foreach (DataTemplate template in dataTemplates)
        {
            Resources.Add(template.DataTemplateKey, template);
        }
    }
}
