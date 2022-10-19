using System.Threading.Tasks;
using Moq;
using Nuke.SampleApp.Tests.Shared.TestFixtures;
using Nuke.SampleApp.ViewModels;
using Prism.Navigation;
using Prism.Services;
using Xunit;

namespace Nuke.SampleApp.Tests.Unit.ViewModels
{
    public class MainPageViewModelTests : BasePrismViewModelTestFixture
    {
        protected override void RegisterTypes()
        {
            RegisterMock<IPageDialogService>();
            RegisterMock<INavigationService>();
        }

        [Fact]
        public async Task OnNavigateAsync_NavigatesToPageA()
        {
            // Arrange
            var vm = ResolveAndCallOnNavigatedTo<MainPageViewModel>();

            // Act
            await vm.OnNavigateAsync();

            // Assert
            ResolveMock<INavigationService>()
                .Verify(x => x.NavigateAsync("PageA"));
        }

        [Fact]
        public async Task OnDisplayAlertAsync_DisplaysAlert()
        {
            // Arrange
            var vm = Resolve<MainPageViewModel>();

            // Act
            await vm.OnDisplayAlertAsync();

            // Assert
            ResolveMock<IPageDialogService>()
                .Verify(x => x.DisplayAlertAsync("Alert", "Welcome to Xamarin Forms and Prism!", "OK"), Times.Once);
        }
    }
}
