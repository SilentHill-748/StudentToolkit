namespace StudentToolkit.MVVM.Models.Navigation.Messages;

public sealed class WindowContentNavigationMessage : ValueChangedMessage<NavigationModel>
{
    public WindowContentNavigationMessage(NavigationModel value) 
        : base(value) { }
}
