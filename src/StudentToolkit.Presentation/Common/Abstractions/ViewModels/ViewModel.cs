namespace StudentToolkit.Presentation.Common.Abstractions.ViewModels;

public abstract class ViewModel : BindableBase
{
    internal HostViewModel? Owner { get; set; }
}
