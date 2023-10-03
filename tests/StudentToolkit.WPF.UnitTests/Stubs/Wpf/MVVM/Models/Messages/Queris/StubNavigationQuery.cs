namespace StudentToolkit.WPF.UnitTests.Stubs.Wpf.MVVM.Models.Messages.Queris;

public sealed class StubNavigationQuery : NavigationQuery<StubNavigationMessage>
{
    public override StubNavigationMessage Execute(ViewModel viewModel)
    {
        return
            new StubNavigationMessage(
                new NavigationModel(viewModel));
    }
}
