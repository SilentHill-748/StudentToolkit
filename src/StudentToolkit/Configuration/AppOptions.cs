using System.Windows;
using System.Windows.Threading;

using SimpleInjector;

using StudentToolkit.Domain.Exceptions;
using StudentToolkit.WpfCore;

namespace StudentToolkit.Configuration;

#pragma warning disable CA1822
public class AppOptions : IDisposable
{
    private bool _disposedValue;

    public AppOptions()
    {
        Services = new Container();
    }

    public Container Services { get; }

    public void RegisterServices(string[] args)
    {
        Services
            .RegisterWpfServices()
            .RegisterApplicationServices(typeof(App).Assembly)
            .RegisterInfrastructureServices(args)
            .Verify();
    }

    public void ApplyDataTemplates(ResourceDictionary appResources)
    {
        var dataTemplates = ViewToViewModelDataTemplateMapper.Map();

        foreach (DataTemplate template in dataTemplates)
        {
            appResources.Add(template.DataTemplateKey, template);
        }
    }

    public void GlobalExceptionHandler(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        var logger = Services.GetInstance<ILogger>();
        var exception = e.Exception;

        var logMessage = $"{exception.Source}: {exception.Message}";
        var userMessage = CustomExceptionMessages.GetMessage(exception);

        logger.Fatal(exception, logMessage);

        NotificationService.Alert("Критическая ошибка!", userMessage);
    }

    public void RegisterCustomExceptionMessages()
    {
        CustomExceptionMessages.Register<GroupNotFoundException>(UserMessageConstants.GroupNotFound);
        CustomExceptionMessages.Register<ViewModelProviderNotSetException>(UserMessageConstants.NavigationError);
        CustomExceptionMessages.Register<ActivationException>(UserMessageConstants.ActivationException);
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                Services.Dispose();
            }

            _disposedValue = true;
        }
    }
}
