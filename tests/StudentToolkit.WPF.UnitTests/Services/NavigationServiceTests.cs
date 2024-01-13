using StudentToolkit.Configuration.DI;

namespace StudentToolkit.WPF.UnitTests.Services;

public class NavigationServiceTests
{
    private readonly Container _container;

    public NavigationServiceTests()
    {
        _container = new Container();

        _container.Register<DummyViewModelOne>();
        _container.Register<DummyViewModelTwo>();
        _container.Register<DummyViewModelThree>();

        _container.Verify();

        ViewModelSource.Provider ??= CreateViewModelProvider();
    }

    [Fact]
    public void Navigation_to_ViewModel_by_it_type_is_successful()
    {
        var stubNavigationVm = new StubNavigationViewModel();

        NavigationService.Navigate<StubNavigationViewModel, DummyViewModelOne>();

        Assert.IsType<DummyViewModelOne>(stubNavigationVm.CurrentViewModel);
    }

    [Fact]
    public void Navigation_to_ViewModel_by_instance_is_successful()
    {
        var stubNavigationVm = new StubNavigationViewModel();
        var viewModel = new DummyViewModelOne();

        NavigationService.Navigate<StubNavigationViewModel>(viewModel);

        Assert.IsType<DummyViewModelOne>(stubNavigationVm.CurrentViewModel);
    }

    [Theory]
    [InlineData(typeof(DummyViewModelOne))]
    [InlineData(typeof(DummyViewModelTwo))]
    [InlineData(typeof(DummyViewModelThree))]
    public void Multiple_navigation_by_sequence_of_ViewModel_instances_is_successful(Type viewModelType)
    {
        var stubNavigationVm = new StubNavigationViewModel();
        var viewModel = (ViewModel)_container.GetInstance(viewModelType);

        NavigationService.Navigate<StubNavigationViewModel>(viewModel);

        Assert.IsType(viewModelType, stubNavigationVm.CurrentViewModel);
    }

    [Fact]
    public void Navigation_to_ViewModel_that_is_null_is_throw_ArgumentNullException()
    {

        var stubNavigationVm = new StubNavigationViewModel();

        Assert.Throws<ArgumentNullException>(() =>
            NavigationService.Navigate<StubNavigationViewModel>(null!));
    }

    [Fact]
    public void Navigation_to_ViewModel_that_dont_got_from_view_model_locator_is_throw_ActivationException()
    {
        var stubNavigationViewModel = new StubNavigationViewModel();

        Assert.Throws<ActivationException>(() =>
            NavigationService.Navigate<StubNavigationViewModel, DummyViewModelFour>());
    }

    private Func<Type, ViewModel> CreateViewModelProvider()
    {
        return type => (ViewModel)_container.GetInstance(type);
    }
}
