using System.Windows;

using DotNetApplication = System.Windows.Application;

namespace StudentToolkit;

public partial class App : DotNetApplication
{
    private readonly Container _container = new();

    protected override void OnStartup(StartupEventArgs e)
    {
        AddServices(e.Args);
        ApplyDataTemplates();

        MainWindow = _container.GetInstance<MainWindow>();
        MainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _container.Dispose();

        base.OnExit(e);
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
