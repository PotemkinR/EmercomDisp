using System;
using System.Collections.Generic;

namespace EmercomDisp.Model.Models
{
    public class CallResponse
    {
        public int Id { get; set; }

        public DateTime TransferTime { get; set; }

        public DateTime ArriveTime { get; set; }

        public DateTime FinishTime { get; set; }

        public DateTime ReturnTime { get; set; }

        public string BrigadeName { get; set; }

        public int IncidentId { get; set; }

        public IEnumerable<string> Equipment { get; set; }
    }
}
