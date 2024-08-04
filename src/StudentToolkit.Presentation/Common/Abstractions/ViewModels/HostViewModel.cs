namespace StudentToolkit.Presentation.Common.Abstractions.ViewModels;

public abstract class HostViewModel : ViewModel
{
    private ViewModel? _hostedViewModel;

    public ViewModel? HostedViewModel
    {
        get => _hostedViewModel;
        set
        {
            if (value is not null)
            {
                value.Owner = this;
            }

            Set(ref _hostedViewModel, value);
        }
    }
}
