namespace StudentToolkit.Navigation.Messages;

public sealed class NavigationMessage : ValueChangedMessage<NavigationModel>
{
    public NavigationMessage(NavigationModel value) : base(value) { }

    public ViewModel? GetDestinationViewModel<TSourceViewModel>()
    {
        if (Value.SourceViewModelType == typeof(TSourceViewModel))
            return Value.DestinationViewModel;

        return null;
    }
}
