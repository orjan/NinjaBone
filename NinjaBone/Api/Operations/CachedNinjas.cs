using System.ComponentModel;
using System.Runtime.Serialization;
using ServiceStack.ServiceHost;

namespace NinjaBone.Api.Operations
{
    [DataContract]
    [Description("Tretton37 cached ninjas.")]
    [RestService("/ninjas/cached")]
    public class CachedNinjas
    {
    }
}