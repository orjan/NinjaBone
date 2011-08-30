using System;
using System.Collections.Generic;
using System.Reflection;
using MvcMiniProfiler;
using NinjaBone.Api.Operations;
using NinjaBone.Models;
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
        private readonly MiniProfiler profiler;
        // it's ok if this is null

        public NinjasService(INinjaService ninjaService)
        {
            NinjaService = ninjaService;
            profiler = MiniProfiler.Current;
        }

        public INinjaService NinjaService { get; set; }

        public override object OnGet(Ninjas request)
        {
            string message = "Get ninjas from " + NinjaService.GetType().Name;
            log.Debug(message);

            IEnumerable<Ninja> allNinjas;
            using (profiler.Step(message))
            {
                allNinjas = NinjaService.GetAllNinjas();                
            }
            
            var ninjaResponse = new NinjasResponse
                                    {
                                        Ninjas = allNinjas
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