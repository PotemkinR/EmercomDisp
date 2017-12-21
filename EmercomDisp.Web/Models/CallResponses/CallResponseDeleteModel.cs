using System;

namespace EmercomDisp.Web.Models.CallResponses
{
    public class CallResponseDeleteModel
    {
        public int Id { get; set; }

        public int IncidentId { get; set; }

        public DateTime TransferTime { get; set; }

        public string Brigade { get; set; }
    }
}