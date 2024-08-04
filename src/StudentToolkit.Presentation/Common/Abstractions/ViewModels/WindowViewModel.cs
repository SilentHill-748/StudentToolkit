namespace StudentToolkit.Presentation.Common.Abstractions.ViewModels;

public abstract class WindowViewModel :
    HostViewModel,
    ITitledViewModel
{
    private string _title = string.Empty;

    public Action? Close { get; internal set; }

    public string Title
    {
        get => _title;
        set => Set(ref _title, value);
    }
}
