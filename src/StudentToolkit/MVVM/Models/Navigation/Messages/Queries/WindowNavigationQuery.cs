namespace StudentToolkit.MVVM.Models.Navigation.Messages.Queries;

public sealed class WindowNavigationQuery : NavigationQuery<WindowContentNavigationMessage>
{
    public override WindowContentNavigationMessage Execute(ViewModel viewModel)
    {
        return
            new WindowContentNavigationMessage(
                new NavigationModel(viewModel));
    }
}
