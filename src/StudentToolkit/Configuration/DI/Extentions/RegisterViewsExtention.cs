namespace StudentToolkit.Configuration.DI;

public static class RegisterViewsExtention
{
    public static Container RegisterViews(this Container container)
    {
        container.Register<MainWindow>();

        return container;
    }
}
