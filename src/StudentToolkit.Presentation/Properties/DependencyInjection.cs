namespace StudentToolkit.Presentation.Properties;

public static class DependencyInjection
{
    public static Container AddPresentationServices(this Container container)
    {
        container
            .AddViewModels();

        return container;
    }
}
