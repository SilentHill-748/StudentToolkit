namespace StudentToolkit.WPF.UnitTests.TestDoubles.Dummy.Messages;

public sealed class DummyNavigationMessage : ValueChangedMessage<NavigationModel>
{
    public DummyNavigationMessage(NavigationModel value)
        : base(value) { }
}
