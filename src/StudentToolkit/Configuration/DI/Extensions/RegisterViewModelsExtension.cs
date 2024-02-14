using StudentToolkit.MVVM.ViewModels.Presentation.GroupInfo;

namespace StudentToolkit.Configuration.DI.Extensions;

public static class RegisterViewModelsExtension
{
    public static Container RegisterViewModels(this Container container)
    {
        container.RegisterSingleton<MainViewModel>();
        container.Register<CreateGroupViewModel>();
        container.Register<AboutViewModel>();
        container.Register<GroupNotFoundViewModel>();

        return container;
    }
}
