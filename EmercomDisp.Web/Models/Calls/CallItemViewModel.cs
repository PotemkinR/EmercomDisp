using System;

namespace EmercomDisp.Web.Models.Calls
{
    public class CallItemViewModel
    {
        public int CallId { get; set; }

        public string Address { get; set; }

        public string Reason { get; set; }

        public DateTime CallTime { get; set; }

        public string Category { get; set; }

        public string Status { get; set; }
    }
}