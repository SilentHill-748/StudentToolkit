namespace StudentToolkit.Tests.Unit;

public class NavigationServiceTests
{
    [Fact]
    public void Should_success_navigation()
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
    public void Should_throw_navigation_denied_exception_by_window_navigate()
    {
        Dictionary<Type, ViewModel> viewModels = CreateViewModelCollection();
        Func<Type, ViewModel> viewModelResolver = (type) => viewModels[type];
        NavigationService navigationService = new(viewModelResolver);
        NavigationViewModel navigationViewModel = (NavigationViewModel)viewModelResolver(typeof(NavigationViewModel));

        void act() => navigationService.NavigateTo<StubNotNavigatingViewModel, WindowContentNavigationMessage>(new WindowNavigationQuery());

        Assert.Throws<NavigationDeniedException>(act);
    }

    [Fact]
    public void Should_does_not_throw_navigation_denied_exception_and_does_not_navigating()
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
