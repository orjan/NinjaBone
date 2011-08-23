using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using NinjaBone.Models;
using ServiceStack.ServiceHost;

namespace NinjaBone.Api.Operations
{
    [DataContract]
    [Description("Tretton37 ninjas")]
    [RestService("/ninjas")]
    public class Ninjas
    {
    }

    [DataContract]
    [Description("Tretton37 cached ninjas.")]
    [RestService("/ninjas/cached")]
    public class CachedNinjas
    {
    }

    [DataContract]
    public class NinjasResponse
    {
        public NinjasResponse()
        {
            Ninjas = new List<Ninja>();
        }

        [DataMember]
        public IEnumerable<Ninja> Ninjas { get; set; }
    }
}