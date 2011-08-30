using System;
using Funq;
using NinjaBone.Api.Operations;
using ServiceStack.Configuration;
using ServiceStack.WebHost.Endpoints;

namespace NinjaBone.Web.Configuration
{
    /// Web Service Singleton AppHost
    internal class ServiceHost : AppHostBase
    {
        private readonly IContainerAdapter adapter;
        //Tell Service Stack the name of your application and where to find your web services
        public ServiceHost(IContainerAdapter adapter)
            : base("Tretton37 Web Services", typeof (Ninjas).Assembly)
        {
            this.adapter = adapter;
        }

        public override void Configure(Container container)
        {
            if (adapter == null)
            {
                throw new ArgumentNullException();
            }

            container.Adapter = adapter;
        }
    }
}