using StudentToolkit.Presentation.Properties;

namespace StudentToolkit.Wpf.Extensions;

public static class DependencyInjectionExtensions
{
    public static void AddServices(this Container container)
    {
        container.AddPresentationServices();
    }
}
