using System.Windows;

using StudentToolkit.WpfCore;

namespace StudentToolkit.Configuration;

#pragma warning disable CA1822
public class AppOptions : IDisposable
{
    private const string FailInitializationOfServicesMessage = "Произошла кртитическая ошибка! Необходимо переустановить программу!";
    private const string OccuredUnconfiguredExceptionMessage = "Произошла непредвиденная ошибка. Для решения проблемы попробуйте переустановить программу или связаться с автором программы через контакты в меню \'Справка\'!";

    private bool _disposedValue;

    public AppOptions()
    {
        Services = new Container();
    }

    public Container Services { get; }

    public void RegisterServices(string[] args)
    {
        try
        {
            Services
                .RegisterWpfServices()
                .RegisterApplicationServices(typeof(App).Assembly)
                .RegisterInfrastructureServices(args)
                .Verify();
        }
        catch (Exception ex)
        {
            NotificationService.Alert("Ошибка инициализации программы", FailInitializationOfServicesMessage);
            
            throw ex
                .WrapWithMessage("Application can't register services.")
                .SetDetail("Args", string.Join(',', args));
        }
    }

    public void ApplyDataTemplates(ResourceDictionary appResources)
    {
        var dataTemplates = ViewToViewModelDataTemplateMapper.Map();

        foreach (DataTemplate template in dataTemplates)
        {
            appResources.Add(template.DataTemplateKey, template);
        }
    }

    public void GlobalExceptionHandler(Exception exception)
    {
        var logger = Services.GetInstance<ILogger>();

        if (exception is DataWrapperException wrappedException)
        {
            string currentExceptionMessage = wrappedException.GetMessageWithData();

            logger.Error(wrappedException.InnerException, currentExceptionMessage);
        }
        else
        {
            NotificationService.Alert("Критическая ошибка!", OccuredUnconfiguredExceptionMessage);

            logger.Fatal(exception, "Occured an exception that isn't configured.");
        }
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
