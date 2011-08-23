using System;
using System.Reflection;
using NinjaBone.Api.Operations;
using NinjaBone.Services.Ninja;
using ServiceStack.CacheAccess;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using log4net;

namespace NinjaBone.Api.ServiceInterface
{
    public class NinjasService : RestServiceBase<Ninjas>
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public INinjaService NinjaService { get; set; }

        public override object OnGet(Ninjas request)
        {
            log.Debug("Get ninjas from Service");

            var ninjaResponse = new NinjasResponse
                                    {
                                        Ninjas = NinjaService.GetAllNinjas()
                                    };

            return ninjaResponse;
        }
    }

    public class CachedNinjasService : RestServiceBase<CachedNinjas>
    {
        public ICacheClient CacheClient { get; set; }

        public override object OnGet(CachedNinjas request)
        {
            return base.RequestContext.ToOptimizedResultUsingCache(
                CacheClient, "urn:ninjas", new TimeSpan(0, 1, 0), () =>
                                                                      {
                                                                          var service = ResolveService<NinjasService>();
                                                                          return
                                                                              (NinjasResponse) service.Get(new Ninjas());
                                                                      });
        }
    }
}