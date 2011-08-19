using System;
using System.Configuration;
using System.Reflection;
using Google.GData.Spreadsheets;
using NinjaBone.Service.Models;
using NinjaBone.Service.Operations;
using ServiceStack.CacheAccess;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using log4net;

namespace NinjaBone.Service.ServiceInterface
{
    public class NinjasService : RestServiceBase<Ninjas>
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ISpreadsheetConfiguration SpreadsheetConfiguration { get; set; }

        public override object OnGet(Ninjas request)
        {
            log.Debug("Get ninjas from google");

            var service = new SpreadsheetsService("tretton37-NinjaBook");
            log.Debug(SpreadsheetConfiguration.Username);
            service.setUserCredentials(SpreadsheetConfiguration.Username, SpreadsheetConfiguration.Password);

            ListFeed feed =
                service.Query(new ListQuery(SpreadsheetConfiguration.SpreadsheetKey, "1", "private", "values"));

            var ninjaResponse = new NinjasResponse();

            foreach (ListEntry entry in feed.Entries)
            {
                var ninja = new Ninja
                                {
                                    Name = entry.Elements[0].Value,
                                    Phone = entry.Elements[1].Value
                                };

                ninjaResponse.Ninjas.Add(ninja);
            }

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