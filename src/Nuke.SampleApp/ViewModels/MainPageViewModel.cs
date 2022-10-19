using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace Nuke.SampleApp.ViewModels
{
    public class MainPageViewModel : BasePrismViewModel
    {
        private readonly IPageDialogService _dialogs;
        private readonly INavigationService _navigationService;

        public DelegateCommand DisplayAlertCommand { get; }
        public DelegateCommand NavigateCommand { get; }

        public MainPageViewModel(IPageDialogService dialogs,
            INavigationService navigationService)
        {
            _dialogs = dialogs;
            _navigationService = navigationService;

            DisplayAlertCommand = new DelegateCommand(async () => await OnDisplayAlertAsync());
            NavigateCommand = new DelegateCommand(async () => await OnNavigateAsync());
        }

        internal async Task OnDisplayAlertAsync()
        {
            var title = Resources.Strings.WelcomeAlertTitle;
            var message = Resources.Strings.WelcomeAlertMessage;
            var ok = Resources.Strings.OK;

            await _dialogs.DisplayAlertAsync(title, message, ok);
        }

        internal async Task OnNavigateAsync()
        {
            await _navigationService.NavigateAsync("PageA");
        }
    }
}
