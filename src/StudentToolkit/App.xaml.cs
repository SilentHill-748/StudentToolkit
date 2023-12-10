using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

using StudentToolkit.Domain.Exceptions;
using StudentToolkit.WpfCore;
using StudentToolkit.WpfCore.Exceptions;

using DotNetApplication = System.Windows.Application;

namespace StudentToolkit;

public partial class App : DotNetApplication
{
    private readonly Container _container = new();

    public App()
    {
        CustomExceptionMessages.Register<GroupNotFoundException>(UserMessageConstants.GroupNotFound);

        DispatcherUnhandledException += OnUnhandledExceptionCatched;
    }

    private void OnUnhandledExceptionCatched(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        var logger = _container.GetInstance<ILogger>();
        var exception = e.Exception;

        var logMessage = $"{exception.Source}: {exception.Message}";
        var userMessage = CustomExceptionMessages.GetMessage(exception);

        logger.Fatal(exception, logMessage);

        NotificationService.Alert("Критическая ошибка!", userMessage);
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        AddServices(e.Args);
        ApplyDataTemplates();

        await SetStartupViewModelAsync();

        MainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _container.Dispose();

        base.OnExit(e);
    }

    private async Task SetStartupViewModelAsync()
    {
        var groupStore = _container.GetInstance<GroupStore>();

        await groupStore.LoadAsync();

        ViewModel startupVm = string.IsNullOrEmpty(groupStore.Group.GroupCode)
            ? _container.GetInstance<CreateGroupViewModel>()
            : _container.GetInstance<MainViewModel>();

        var navigationVm = new NavigationViewModel(startupVm);

        MainWindow = new MainWindow(navigationVm);
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
        var dataTemplates = ViewToViewModelDataTemplateMapper.Map();

        foreach (DataTemplate template in dataTemplates)
        {
            Resources.Add(template.DataTemplateKey, template);
        }
    }
}
