using System;
using System.ComponentModel.DataAnnotations;

namespace EmercomDisp.Web.Models.CallResponses
{
    public class CallResponseEditModel
    {
        public int Id { get; set; }

        public int IncidentId { get; set; }

        [Required]
        public DateTime TransferTime { get; set; }

        [Required]
        public DateTime ArriveTime { get; set; }

        [Required]
        public DateTime FinishTime { get; set; }

        [Required]
        public DateTime ReturnTime { get; set; }

        public string BrigadeName { get; set; }
    }
}