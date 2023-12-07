namespace StudentToolkit.MVVM.Models.Navigation.Messages;

public sealed class WindowContentNavigationMessage(NavigationModel value) 
    : ValueChangedMessage<NavigationModel>(value) 
{ }
