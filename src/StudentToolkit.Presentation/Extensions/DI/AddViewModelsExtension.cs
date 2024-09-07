using StudentToolkit.Presentation.Mvvm.Model.Main.ViewModels;

namespace StudentToolkit.Presentation.Extensions.DI;

public static class AddViewModelsExtension
{
    public static Container AddViewModels(this Container container)
    {
        container.Register<MainWindowViewModel>();
        container.Register<MainViewModel>();

        return container;
    }
}
