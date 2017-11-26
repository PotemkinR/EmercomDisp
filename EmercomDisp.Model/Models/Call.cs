using System;
using System.Collections.Generic;

namespace EmercomDisp.Model.Models
{
    public class Call
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string Reason { get; set; }

        public DateTime CallTime { get; set; }

        public DateTime TransferTime { get; set; }

        public DateTime ArriveTime { get; set; }

        public DateTime FinishTime { get; set; }

        public DateTime ReturnTime { get; set; }

        public int BrigadeId { get; set; }

        public int IncidentId { get; set; }

        public string Category { get; set; }
    }
}
