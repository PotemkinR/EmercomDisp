using System;
using System.Runtime.Serialization;

namespace EmercomDisp.Service.Dto.Models
{
    [DataContract]
    public class CallResponseDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime TransferTime { get; set; }

        [DataMember]
        public DateTime ArriveTime { get; set; }

        [DataMember]
        public DateTime FinishTime { get; set; }

        [DataMember]
        public DateTime ReturnTime { get; set; }

        [DataMember]
        public string BrigadeName { get; set; }

        [DataMember]
        public int IncidentId { get; set; }
    }
}
