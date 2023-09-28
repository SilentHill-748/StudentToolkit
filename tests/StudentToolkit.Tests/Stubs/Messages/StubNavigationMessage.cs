namespace StudentToolkit.Tests.Stubs.Messages;

public sealed class StubNavigationMessage : ValueChangedMessage<NavigationModel>
{
    public StubNavigationMessage(NavigationModel value) 
        : base(value) { }
}
