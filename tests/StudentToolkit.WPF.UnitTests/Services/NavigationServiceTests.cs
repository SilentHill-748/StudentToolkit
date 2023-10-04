namespace StudentToolkit.WPF.UnitTests.Services;

public class NavigationServiceTests
{
    [Fact]
    public void The_navigation_with_the_INavigatingViewModel_and_message_with_a_handler_is_success()
    {
        Dictionary<Type, ViewModel> viewModels = CreateViewModelCollection();
        Func<Type, ViewModel> viewModelResolver = (type) => viewModels[type];
        NavigationService navigationService = new(viewModelResolver);
        NavigationViewModel navigationViewModel = (NavigationViewModel)viewModelResolver(typeof(NavigationViewModel));

        navigationService.NavigateTo<DummyNavigatingViewModel, WindowContentNavigationMessage>(new WindowNavigationQuery());

        Assert.IsNotType<MainViewModel>(navigationViewModel.CurrentViewModel);
        Assert.IsType<DummyNavigatingViewModel>(navigationViewModel.CurrentViewModel);
    }

    [Fact]
    public void The_navigation_with_the_not_INavigatingViewModel_is_throw_NavigationDeniedException()
    {
        Dictionary<Type, ViewModel> viewModels = CreateViewModelCollection();
        Func<Type, ViewModel> viewModelResolver = (type) => viewModels[type];
        NavigationService navigationService = new(viewModelResolver);
        NavigationViewModel navigationViewModel = (NavigationViewModel)viewModelResolver(typeof(NavigationViewModel));

        void act() => navigationService.NavigateTo<DummyNotNavigatingViewModel, WindowContentNavigationMessage>(new WindowNavigationQuery());

        Assert.Throws<NavigationDeniedException>(act);
    }

    [Fact]
    public void Without_the_navigation_with_message_without_a_handler()
    {
        Dictionary<Type, ViewModel> viewModels = CreateViewModelCollection();
        Func<Type, ViewModel> viewModelResolver = (type) => viewModels[type];
        NavigationService navigationService = new(viewModelResolver);
        NavigationViewModel navigationViewModel = (NavigationViewModel)viewModelResolver(typeof(NavigationViewModel));

        navigationService.NavigateTo<DummyNavigatingViewModel, DummyNavigationMessage>(new StubNavigationQuery());

        Assert.IsType<MainViewModel>(navigationViewModel.CurrentViewModel);
        Assert.IsNotType<DummyNavigatingViewModel>(navigationViewModel.CurrentViewModel);
    }

    private static Dictionary<Type, ViewModel> CreateViewModelCollection()
    {
        var viewModels = new Dictionary<Type, ViewModel>()
        {
            { typeof(MainViewModel), new MainViewModel() },
            { typeof(DummyNavigatingViewModel), new DummyNavigatingViewModel() },
            { typeof(DummyNotNavigatingViewModel), new DummyNotNavigatingViewModel() },
            { typeof(NavigationViewModel), new NavigationViewModel(new MainViewModel()) }
        };

        return viewModels;
    }
}
