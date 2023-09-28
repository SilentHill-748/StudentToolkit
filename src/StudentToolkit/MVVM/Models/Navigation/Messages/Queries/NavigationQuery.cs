namespace StudentToolkit.MVVM.Models.Navigation.Messages.Queries;

public abstract class NavigationQuery<T>
    where T : ValueChangedMessage<NavigationModel>
{
    public abstract T Execute(ViewModel viewModel);
}
