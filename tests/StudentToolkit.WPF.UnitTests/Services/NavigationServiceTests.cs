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

        navigationService.NavigateTo<StubNavigatingViewModel, WindowContentNavigationMessage>(new WindowNavigationQuery());

        Assert.NotNull(navigationViewModel.CurrentViewModel);
        Assert.IsNotType<MainViewModel>(navigationViewModel.CurrentViewModel);
        Assert.IsType<StubNavigatingViewModel>(navigationViewModel.CurrentViewModel);
    }

    [Fact]
    public void The_navigation_with_the_not_INavigatingViewModel_is_throw_NavigationDeniedException()
    {
        Dictionary<Type, ViewModel> viewModels = CreateViewModelCollection();
        Func<Type, ViewModel> viewModelResolver = (type) => viewModels[type];
        NavigationService navigationService = new(viewModelResolver);
        NavigationViewModel navigationViewModel = (NavigationViewModel)viewModelResolver(typeof(NavigationViewModel));

        void act() => navigationService.NavigateTo<StubNotNavigatingViewModel, WindowContentNavigationMessage>(new WindowNavigationQuery());

        Assert.Throws<NavigationDeniedException>(act);
    }

    [Fact]
    public void Without_the_navigation_with_message_without_a_handler()
    {
        Dictionary<Type, ViewModel> viewModels = CreateViewModelCollection();
        Func<Type, ViewModel> viewModelResolver = (type) => viewModels[type];
        NavigationService navigationService = new(viewModelResolver);
        NavigationViewModel navigationViewModel = (NavigationViewModel)viewModelResolver(typeof(NavigationViewModel));

        navigationService.NavigateTo<StubNavigatingViewModel, StubNavigationMessage>(new StubNavigationQuery());

        Assert.NotNull(navigationViewModel.CurrentViewModel);
        Assert.IsType<MainViewModel>(navigationViewModel.CurrentViewModel);
        Assert.IsNotType<StubNavigatingViewModel>(navigationViewModel.CurrentViewModel);
    }

    private static Dictionary<Type, ViewModel> CreateViewModelCollection()
    {
        var viewModels = new Dictionary<Type, ViewModel>()
        {
            { typeof(MainViewModel), new MainViewModel() },
            { typeof(StubNavigatingViewModel), new StubNavigatingViewModel() },
            { typeof(StubNotNavigatingViewModel), new StubNotNavigatingViewModel() },
            { typeof(NavigationViewModel), new NavigationViewModel(new MainViewModel()) }
        };

        return viewModels;
    }
}
