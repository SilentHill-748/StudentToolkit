using System.Windows;
using System.Windows.Threading;

using StudentToolkit.WpfCore;

namespace StudentToolkit.Configuration;

#pragma warning disable CA1822
public class AppOptions : IDisposable
{
    private const string ActivationException = "Произошла кртитическая ошибка! Необходимо переустановить программу!";
    private const string UnhandledException = "Произошла непредвиденная ошибка. Для решения проблемы попробуйте переустановить программу или связаться с автором программы через контакты в меню \'Справка\'!";

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
            NotificationService.Alert("Ошибка инициализации программы", ActivationException);
            
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

    public void GlobalExceptionHandler(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        var logger = Services.GetInstance<ILogger>();
        var currentException = e.Exception;

        if (currentException is DataWrapperException wrappedException)
        {
            string currentExceptionMessage = wrappedException.GetMessageWithData();

            logger.Error(wrappedException.InnerException, currentExceptionMessage);
        }
        else
        {
            NotificationService.Alert("Критическая ошибка!", UnhandledException);

            logger.Fatal(currentException, "Occured an exception that isn't configured.");
        }

        e.Handled = true;
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
