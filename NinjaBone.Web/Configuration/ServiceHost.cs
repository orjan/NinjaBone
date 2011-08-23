using System.Configuration;
using Funq;
using NinjaBone.Api.Operations;
using NinjaBone.Services.Ninja;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.WebHost.Endpoints;

namespace NinjaBone.Web.Configuration
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
            container.Register<INinjaService>(
                new GoogleNinjaService((ISpreadsheetConfiguration) ConfigurationManager.GetSection("google-api")));
            //container.Register<ISpreadsheetConfiguration>();
        }
    }
}