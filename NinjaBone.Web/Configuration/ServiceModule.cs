using System.Configuration;
using Autofac;
using Autofac.Integration.Mvc;
using NinjaBone.Services.Ninja;
using NinjaBone.Services.Skills;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;

namespace NinjaBone.Web.Configuration
{
    public class ServiceModule : Module
    {
        public bool UseDummyService { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.Register(c => new MemoryCacheClient()).As<ICacheClient>().SingleInstance();

            if (UseDummyService)
            {
                builder.Register(c => new DummyNinjaService()).As<INinjaService>();
                builder.RegisterType<DummySkillsService>().As<ISkillsService>();
            } else
            {
                builder.Register(x => (ISpreadsheetConfiguration)ConfigurationManager.GetSection("google-api")).As<ISpreadsheetConfiguration>();
                builder.RegisterType<GoogleNinjaService>().As<INinjaService>();
                builder.RegisterType<GoogleSkillsService>().As<ISkillsService>();
            }
        }
    }
}