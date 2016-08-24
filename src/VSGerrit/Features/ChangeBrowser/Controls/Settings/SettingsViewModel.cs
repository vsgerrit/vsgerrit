using Gerrit.Api.Common.Configuration;
using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Windows.Input;
using vsgerrit.Features.ChangeBrowser.Services;

namespace vsgerrit.Features.ChangeBrowser.Controls.Settings
{
    public class SettingsViewModel
    {
        private readonly IApplicationSettingsRepository _applicationSettingsRepository;

        public SettingsViewModel(IApplicationSettingsRepository applicationSettingsRepository)
        {
            _applicationSettingsRepository = applicationSettingsRepository;

            ApplyCommand = new DelegateCommand(_ => HandleApplyCommand(), _ => AreSettingsValid());

            LoadConfiguration();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string GerritApiUrl { get; set; }

        public ICommand ApplyCommand { get; private set; }

        private void HandleApplyCommand()
        {
            _applicationSettingsRepository.SaveGerritConfiguration(new GerritConfiguration(Username, Password, GerritApiUrl));
        }

        private bool AreSettingsValid()
        {
            return !string.IsNullOrWhiteSpace(Username) &&
                   !string.IsNullOrWhiteSpace(Password) &&
                   !string.IsNullOrWhiteSpace(GerritApiUrl);
        }

        private void LoadConfiguration()
        {
            GerritConfiguration configuration;
            try
            {
                configuration = _applicationSettingsRepository.GetGerritConfiguration();
            }
            catch (NotSupportedException)
            {
                configuration = new GerritConfiguration(string.Empty, string.Empty, string.Empty);
            }

            Username = configuration.UserName;
            Password = configuration.Password;
            GerritApiUrl = configuration.GerritApiUrl;
        }
    }
}