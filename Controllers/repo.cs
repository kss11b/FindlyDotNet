using System;
using System.Runtime.Serialization;

namespace WebApiProject
{
    [DataContract(Name="repo")]
    public class Repository
    {
        [DataMember(Name="name")]
        public string Name {get; set;}
    }
}