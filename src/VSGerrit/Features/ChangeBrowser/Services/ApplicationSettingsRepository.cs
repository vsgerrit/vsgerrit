using Gerrit.Api.Common.Configuration;
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Settings;
using System.ComponentModel.Composition;

namespace vsgerrit.Features.ChangeBrowser.Services
{
    [Export(typeof(IApplicationSettingsRepository))]
    public class ApplicationSettingsRepository : IApplicationSettingsRepository
    {
        private const string GerritSettingsCollectionName = "gerritSettings";
        private const string UserNameKey = "UserName";
        private const string PasswordKey = "Password";
        private const string GerritApiUrlKey = "GerritApiUrl";

        public void SaveGerritConfiguration(GerritConfiguration configuration)
        {
            var settingsStore = GetWritableSettingsStore();

            if (!settingsStore.CollectionExists(GerritSettingsCollectionName))
            {
                settingsStore.CreateCollection(GerritSettingsCollectionName);
            }

            settingsStore.SetString(GerritSettingsCollectionName, UserNameKey, configuration.UserName);
            settingsStore.SetString(GerritSettingsCollectionName, PasswordKey, configuration.Password);
            settingsStore.SetString(GerritSettingsCollectionName, GerritApiUrlKey, configuration.Password);
        }

        public GerritConfiguration GetGerritConfiguration()
        {
            var settingsStore = GetWritableSettingsStore();

            return new GerritConfiguration(
                settingsStore.GetString(GerritSettingsCollectionName, UserNameKey, string.Empty),
                settingsStore.GetString(GerritSettingsCollectionName, PasswordKey, string.Empty),
                settingsStore.GetString(GerritSettingsCollectionName, GerritApiUrlKey, string.Empty));
        }

        private static WritableSettingsStore GetWritableSettingsStore()
        {
            return new ShellSettingsManager(ServiceProvider.GlobalProvider).GetWritableSettingsStore(SettingsScope.UserSettings);
        }
    }
}