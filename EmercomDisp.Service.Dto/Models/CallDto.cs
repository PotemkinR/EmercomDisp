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
        public DateTime TransferTime { get; set; }

        [DataMember]
        public DateTime ArriveTime { get; set; }

        [DataMember]
        public DateTime FinishTime { get; set; }

        [DataMember]
        public DateTime ReturnTime { get; set; }

        [DataMember]
        public int BrigadeId { get; set; }

        [DataMember]
        public int IncidentId { get; set; }

        [DataMember]
        public string Category { get; set; }
    }
}
