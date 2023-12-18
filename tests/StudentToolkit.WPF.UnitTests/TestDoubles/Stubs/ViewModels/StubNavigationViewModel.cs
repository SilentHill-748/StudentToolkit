using CommunityToolkit.Mvvm.Messaging;

namespace StudentToolkit.WPF.UnitTests.TestDoubles.Stubs.ViewModels;

public class StubNavigationViewModel : ViewModel
{
    public StubNavigationViewModel()
    {
        WeakReferenceMessenger.Default.Register<NavigationMessage>(this, (recipient, message) =>
        {
            CurrentViewModel = message.GetDestinationViewModel<StubNavigationViewModel>() ?? CurrentViewModel;
        });
    }

    public ViewModel? CurrentViewModel { get; set; }
}
