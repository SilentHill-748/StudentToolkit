namespace StudentToolkit;

public partial class App : Application
{
    private readonly Container _container = new();

    protected override void OnStartup(StartupEventArgs e)
    {
        AddServices();

        MainWindow = _container.GetInstance<MainWindow>();
        MainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _container.Dispose();

        base.OnExit(e);
    }

    private void AddServices()
    {
        _container.RegisterServices();
    }
}
