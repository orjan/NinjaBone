using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using NinjaBone.Services.Ninja;
using NinjaBone.Web.Configuration;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using log4net;
using log4net.Config;

namespace NinjaBone.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        private ServiceHost appHost;

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{file}.manifest");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("api/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            XmlConfigurator.Configure();

            ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Debug("Application Start");

            AreaRegistration.RegisterAllAreas();

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof (MvcApplication).Assembly);
            builder.Register(c => new MemoryCacheClient()).As<ICacheClient>().SingleInstance();
            builder.Register(c => new DummyNinjaService()).As<INinjaService>();

            IContainer container = builder.Build();

            var autoFacAdapter = new AutoFacAdapter(container);
            appHost = new ServiceHost(autoFacAdapter);
            appHost.Init();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}