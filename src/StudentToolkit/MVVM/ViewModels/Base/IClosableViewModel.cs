namespace StudentToolkit.MVVM.ViewModels.Base;

public interface IClosableViewModel
{
    Action? Close { get; set; }
}
