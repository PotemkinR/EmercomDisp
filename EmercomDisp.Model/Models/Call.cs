using System;
using System.Collections.Generic;

namespace EmercomDisp.Model.Models
{
    public class Call
    {
        public int Id { get; set; }

        public string Adress { get; set; }

        public string Reason { get; set; }

        public DateTime CallTime { get; set; }

        public DateTime TransferTime { get; set; }

        public DateTime ArriveTime { get; set; }

        public DateTime FinishTime { get; set; }

        public DateTime ReturnTime { get; set; }

        public IEnumerable<Victim> Victims { get; set; }

        public Brigade Brigade { get; set; }

        public Incident Incident { get; set; }

        public UrgencyEnum Category { get; set; }
    }
}
