using System;
using System.Collections.Generic;

namespace EmercomDisp.Model.Models
{
    public class Going
    {
        public int Id { get; set; }

        public DateTime TransferTime { get; set; }

        public DateTime ArriveTime { get; set; }

        public DateTime FinishTime { get; set; }

        public DateTime ReturnTime { get; set; }

        public int BrigadeId { get; set; }

        public int IncidentId { get; set; }

        public IEnumerable<string> Equipment { get; set; }
    }
}
