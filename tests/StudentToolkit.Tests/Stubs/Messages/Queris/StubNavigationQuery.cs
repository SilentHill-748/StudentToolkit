namespace StudentToolkit.Tests.Stubs.Messages.Queris;

public sealed class StubNavigationQuery : NavigationQuery<StubNavigationMessage>
{
    public override StubNavigationMessage Execute(ViewModel viewModel)
    {
        return
            new StubNavigationMessage(
                new NavigationModel(viewModel));
    }
}
