using System.Threading.Tasks;
using System.Windows;

using StudentToolkit.MVVM.Stores;

using DotNetApplication = System.Windows.Application;

namespace StudentToolkit;

public partial class App : DotNetApplication
{
    private readonly Container _container = new();

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
