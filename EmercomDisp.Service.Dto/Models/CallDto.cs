using System;
using System.Collections.Generic;

namespace EmercomDisp.Service.Dto.Models
{
    public class CallDto
    {
        public int Id { get; set; }

        public string Adress { get; set; }

        public string Reason { get; set; }

        public DateTime CallTime { get; set; }

        public DateTime TransferTime { get; set; }

        public DateTime ArriveTime { get; set; }

        public DateTime FinishTime { get; set; }

        public DateTime ReturnTime { get; set; }

        public IEnumerable<VictimDto> Victims { get; set; }

        public BrigadeDto Brigade { get; set; }

        public IncidentDto Incident { get; set; }

        public string Category { get; set; }
    }
}
