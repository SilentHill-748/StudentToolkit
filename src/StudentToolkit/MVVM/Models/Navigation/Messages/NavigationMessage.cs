namespace StudentToolkit.MVVM.Models.Navigation.Messages;

public sealed class NavigationMessage(NavigationModel value) 
    : ValueChangedMessage<NavigationModel>(value) 
{
    public ViewModel? GetDestinationViewModel<TSourceViewModel>()
    {
        if (Value.SourceViewModelType == typeof(TSourceViewModel))
            return Value.DestinationViewModel;

        return null;
    }
}
