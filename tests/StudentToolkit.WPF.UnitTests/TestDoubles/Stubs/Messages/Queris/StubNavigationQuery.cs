namespace StudentToolkit.WPF.UnitTests.TestDoubles.Stubs.Messages.Queris;

public sealed class StubNavigationQuery : NavigationQuery<DummyNavigationMessage>
{
    public override DummyNavigationMessage Execute(ViewModel viewModel)
    {
        return
            new DummyNavigationMessage(
                new NavigationModel(viewModel));
    }
}
