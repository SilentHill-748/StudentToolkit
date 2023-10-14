using System.Threading.Tasks;
using System.Windows;

using StudentToolkit.Infrastructure.Data;

using DotNetApplication = System.Windows.Application;

namespace StudentToolkit;

public partial class App : DotNetApplication
{
    private readonly Container _container = new();
    private readonly IConfiguration _configuration;

    public App()
    {
        _configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        AddServices();
        ApplyDataTemplates();

        await InitializeDatabaseAsync();

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
        _container
            .RegisterWpfServices()
            .RegisterApplicationServices(typeof(App).Assembly)
            .RegisterInfrastructureServices(_configuration)
            .Verify();
    }

    private async Task InitializeDatabaseAsync()
    {
        var initializer = _container.GetInstance<AppDbContextInitializer>();

        await initializer.InitializeAsync();
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
