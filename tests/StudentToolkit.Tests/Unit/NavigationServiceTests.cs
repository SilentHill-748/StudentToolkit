using StudentToolkit.Tests.Stubs.Wpf.MVVM.Models.Messages;
using StudentToolkit.Tests.Stubs.Wpf.MVVM.ViewModels;

namespace StudentToolkit.Tests.Unit;

public class NavigationServiceTests
{
    private readonly Dictionary<Type, ViewModel> _viewModels;
    private readonly Func<Type, object> _viewModelResolver;

    public NavigationServiceTests()
    {
        _viewModels = new Dictionary<Type, ViewModel>();
        _viewModelResolver = (type) => _viewModels[type];

        InitialViewModels();
    }

    [Fact]
    public void Should_success_navigation()
    {
        // Arrange
        NavigationService navigationService = new(_viewModelResolver);
        NavigationViewModel navigationViewModel = (NavigationViewModel)_viewModelResolver(typeof(NavigationViewModel));

        // Act
        navigationService.NavigateTo<StubNavigatingViewModel, WindowContentNavigationMessage>(new WindowNavigationQuery());

        //Accept
        Assert.NotNull(navigationViewModel.CurrentViewModel);
        Assert.IsNotType<MainViewModel>(navigationViewModel.CurrentViewModel);
        Assert.IsType<StubNavigatingViewModel>(navigationViewModel.CurrentViewModel);
    }

    [Fact]
    public void Should_throw_navigation_denied_exception_by_window_navigate()
    {
        // Arrange
        NavigationService navigationService = new(_viewModelResolver);
        NavigationViewModel navigationViewModel = (NavigationViewModel)_viewModelResolver(typeof(NavigationViewModel));

        // Act
        void act() => navigationService.NavigateTo<StubNotNavigatingViewModel, WindowContentNavigationMessage>(new WindowNavigationQuery());

        //Accept
        Assert.Throws<NavigationDeniedException>(act);
    }

    [Fact]
    public void Should_does_not_throw_navigation_denied_exception_and_does_not_navigating()
    {
        // Arrange
        NavigationService navigationService = new(_viewModelResolver);
        NavigationViewModel navigationViewModel = (NavigationViewModel)_viewModelResolver(typeof(NavigationViewModel));

        // Act
        navigationService.NavigateTo<StubNavigatingViewModel, StubNavigationMessage>(new StubNavigationQuery());

        //Accept
        Assert.NotNull(navigationViewModel.CurrentViewModel);
        Assert.IsType<MainViewModel>(navigationViewModel.CurrentViewModel);
        Assert.IsNotType<StubNavigatingViewModel>(navigationViewModel.CurrentViewModel);
    }

    private void InitialViewModels()
    {
        _viewModels.Add(typeof(MainViewModel), new MainViewModel());
        _viewModels.Add(typeof(StubNavigatingViewModel), new StubNavigatingViewModel());
        _viewModels.Add(typeof(StubNotNavigatingViewModel), new StubNotNavigatingViewModel());
        _viewModels.Add(typeof(NavigationViewModel), new NavigationViewModel(new MainViewModel()));
    }
}
