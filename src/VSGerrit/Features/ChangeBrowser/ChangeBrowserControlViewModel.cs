using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Runtime.CompilerServices;
using vsgerrit.Features.ChangeBrowser.Controls.ActionsBar;
using vsgerrit.Features.ChangeBrowser.Services;

namespace vsgerrit.Features.ChangeBrowser
{
    [Export(typeof(IChangeBrowserNavigationService))]
    [Export(typeof(ChangeBrowserControlViewModel))]
    public class ChangeBrowserControlViewModel : IChangeBrowserNavigationService, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isSettingsVisible;

        public bool IsSettingsVisible
        {
            get { return _isSettingsVisible; }
            private set
            {
                _isSettingsVisible = value;
                OnPropertyChanged();
            }
        }

        public ActionsBarViewModel ActionsBarViewModel { get; }

        public ChangeBrowserControlViewModel()
        {
            ActionsBarViewModel = new ActionsBarViewModel(this);
        }

        public void NavigateToSettings()
        {
            IsSettingsVisible = true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}