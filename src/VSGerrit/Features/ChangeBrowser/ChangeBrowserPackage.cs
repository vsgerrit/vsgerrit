using Microsoft.VisualStudio.Shell;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using vsgerrit.Features.Configuration;

namespace vsgerrit.Features.ChangeBrowser
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(ChangeBrowserWindow))]
    [Guid(PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class ChangeBrowserPackage : Package
    {
        public const string PackageGuidString = "7592d207-3716-4a2f-a243-095709fb3eba";

        protected override void Initialize()
        {
            new Bootstrapper().Run();

            ChangeBrowserCommand.Initialize(this);
            base.Initialize();
        }
    }
}