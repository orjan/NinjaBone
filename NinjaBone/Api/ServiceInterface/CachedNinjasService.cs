using System;
using NinjaBone.Api.Operations;
using ServiceStack.CacheAccess;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace NinjaBone.Api.ServiceInterface
{
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