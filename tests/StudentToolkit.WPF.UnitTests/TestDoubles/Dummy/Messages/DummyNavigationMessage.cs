namespace StudentToolkit.WPF.UnitTests.TestDoubles.Dummy.Messages;

public sealed class DummyNavigationMessage(NavigationModel value)
    : ValueChangedMessage<NavigationModel>(value)
{ }
