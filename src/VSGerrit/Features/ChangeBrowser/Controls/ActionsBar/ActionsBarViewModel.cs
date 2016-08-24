using Microsoft.VisualStudio.PlatformUI;
using System.Windows.Input;
using vsgerrit.Features.ChangeBrowser.Services;

namespace vsgerrit.Features.ChangeBrowser.Controls.ActionsBar
{
    public class ActionsBarViewModel
    {
        private readonly IChangeBrowserNavigationService _navigationService;

        public ICommand NavigateToSetingsCommand { get; set; }

        public ActionsBarViewModel()
        {
        }

        public ActionsBarViewModel(IChangeBrowserNavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateToSetingsCommand = new DelegateCommand(_ => HandleNavigateToSettingsCommand(), _ => true);
        }

        private void HandleNavigateToSettingsCommand()
        {
            _navigationService.ToggleSettingsVisibility();
        }
    }
}