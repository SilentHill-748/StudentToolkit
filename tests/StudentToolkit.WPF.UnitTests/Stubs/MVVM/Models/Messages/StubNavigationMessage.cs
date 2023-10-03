namespace StudentToolkit.WPF.UnitTests.Stubs.MVVM.Models.Messages;

public sealed class StubNavigationMessage : ValueChangedMessage<NavigationModel>
{
    public StubNavigationMessage(NavigationModel value)
        : base(value) { }
}
