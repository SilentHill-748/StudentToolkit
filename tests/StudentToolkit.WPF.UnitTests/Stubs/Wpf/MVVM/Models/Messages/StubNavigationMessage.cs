namespace StudentToolkit.WPF.UnitTests.Stubs.Wpf.MVVM.Models.Messages;

public sealed class StubNavigationMessage : ValueChangedMessage<NavigationModel>
{
    public StubNavigationMessage(NavigationModel value)
        : base(value) { }
}
