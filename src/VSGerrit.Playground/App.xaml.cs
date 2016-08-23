using System.Windows;
using vsgerrit.Features.Configuration;

namespace VSGerrit.Playground
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            new Bootstrapper().Run();
        }
    }
}