using System.Collections.Generic;
using System.Reflection;
using MvcMiniProfiler;
using NinjaBone.Api.Operations;
using NinjaBone.Models;
using NinjaBone.Services.Ninja;
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
}