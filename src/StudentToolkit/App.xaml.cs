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

    protected override void OnStartup(StartupEventArgs e)
    {
        try
        {
            _isSuccessInit = InternalStartup(e.Args);
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

    private bool InternalStartup(string[] args)
    {
        _options.RegisterServices(args);
        _options.ApplyDataTemplates(Resources);

        MainWindow = _options.Services.GetInstance<MainWindow>();
        MainWindow.Show();

        return true;
    }
}
