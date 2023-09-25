using CommunityToolkit.Mvvm.Messaging.Messages;

namespace StudentToolkit.MVVM.Models.Navigation.Messages;

internal sealed class WindowContentNavigationMessage : ValueChangedMessage<NavigationModel>
{
    public WindowContentNavigationMessage(NavigationModel value) 
        : base(value) { }
}
