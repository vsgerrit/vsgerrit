using Prism.Mef;
using System.ComponentModel.Composition.Hosting;

namespace vsgerrit.Features.Configuration
{
    public class Bootstrapper : MefBootstrapper
    {
        protected override void ConfigureAggregateCatalog()
        {
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
        }
    }
}