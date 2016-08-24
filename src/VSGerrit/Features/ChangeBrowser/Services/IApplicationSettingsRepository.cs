using Gerrit.Api.Common.Configuration;

namespace vsgerrit.Features.ChangeBrowser.Services
{
    public interface IApplicationSettingsRepository
    {
        GerritConfiguration GetGerritConfiguration();

        void SaveGerritConfiguration(GerritConfiguration gerritConfiguration);
    }
}