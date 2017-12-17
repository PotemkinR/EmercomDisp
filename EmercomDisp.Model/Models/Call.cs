using System;

namespace EmercomDisp.Model.Models
{
    public class Call
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string Reason { get; set; }

        public DateTime CallTime { get; set; }

        public string Category { get; set; }

        public string IncidentDescription { get; set; }

        public string IncidentCause { get; set; }
    }
}
