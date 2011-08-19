using System.Configuration;
using Funq;
using NinjaBone.Service;
using NinjaBone.Service.Operations;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.WebHost.Endpoints;

namespace NinjaBone.Configuration
{
    /// Web Service Singleton AppHost
    public class ServiceHost : AppHostBase
    {
        //Tell Service Stack the name of your application and where to find your web services
        public ServiceHost()
            : base("Tretton37 Web Services", typeof (Ninjas).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            container.Register<ICacheClient>(new MemoryCacheClient());
            container.Register<ISpreadsheetConfiguration>((GoogleSpreadsheetConfiguration) ConfigurationManager.GetSection("google-api"));
        }
    }
}