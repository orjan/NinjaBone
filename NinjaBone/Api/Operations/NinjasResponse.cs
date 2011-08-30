using System.Collections.Generic;
using System.Runtime.Serialization;
using NinjaBone.Models;

namespace NinjaBone.Api.Operations
{
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