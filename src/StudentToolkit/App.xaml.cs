using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

using SimpleInjector;

using StudentToolkit.Domain.Exceptions;
using StudentToolkit.WpfCore;

using DotNetApplication = System.Windows.Application;

namespace StudentToolkit;

public partial class App : DotNetApplication
{
    private readonly Container _container = new();

    public App()
    {
        CustomExceptionMessages.Register<GroupNotFoundException>(UserMessageConstants.GroupNotFound);
        CustomExceptionMessages.Register<ViewModelProviderNotSetException>(UserMessageConstants.NavigationError);
        CustomExceptionMessages.Register<ActivationException>(UserMessageConstants.ActivationException);

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

        MainWindow = _container.GetInstance<MainWindow>();
        MainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _container.Dispose();

        base.OnExit(e);
    }

    private async Task SetStartupViewModelAsync()
    {
        NavigationService.Navigate<NavigationViewModel, MainViewModel>();

        var groupStore = _container.GetInstance<GroupStore>();

        await groupStore.LoadAsync();

        if (string.IsNullOrEmpty(groupStore.Group.GroupCode))
        {
            NavigationService.Navigate<NavigationViewModel, CreateGroupViewModel>();
        }
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
