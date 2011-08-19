using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NinjaBone.Configuration;
using NinjaBone.Service;
using log4net;
using log4net.Config;

namespace NinjaBone
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            var appHost = new ServiceHost();
            appHost.Init();

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

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}