using System;
using System.Runtime.Serialization;

namespace EmercomDisp.Service.Dto.Models
{
    [DataContract]
    public class CallDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Reason { get; set; }

        [DataMember]
        public DateTime CallTime { get; set; }

        [DataMember]
        public string Category { get; set; }

        [DataMember]
        public string IncidentDescription { get; set; }

        [DataMember]
        public string IncidentCause { get; set; }
    }
}
