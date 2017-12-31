using System;
using System.ComponentModel.DataAnnotations;
using Foolproof;

namespace EmercomDisp.Web.Models.CallResponses
{
    public class CallResponseEditModel
    {
        public int Id { get; set; }

        public int IncidentId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TransferTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [GreaterThan("TransferTime")]
        public DateTime? ArriveTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [GreaterThan("ArriveTime")]
        public DateTime? FinishTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [GreaterThan("FinishTime")]
        public DateTime? ReturnTime { get; set; }

        public string BrigadeName { get; set; }
    }
}