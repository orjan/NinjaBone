﻿using System.ComponentModel;
using System.Runtime.Serialization;
using ServiceStack.ServiceHost;

namespace NinjaBone.Api.Operations
{
    [DataContract]
    [Description("Tretton37 ninjas")]
    [RestService("/ninjas")]
    public class Ninjas
    {
    }
}