namespace StudentToolkit.MVVM.Models.Navigation.Messages;

internal class ControlContentNavigationMessage : ValueChangedMessage<NavigationModel>
{
    public ControlContentNavigationMessage(NavigationModel value) 
        : base(value) { }
}
