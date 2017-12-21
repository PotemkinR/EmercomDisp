using System.ComponentModel.DataAnnotations;

namespace EmercomDisp.Web.Models.Calls
{
    public class CallCloseModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string IncidentDescription { get; set; }

        [Required]
        [StringLength(100)]
        public string IncidentCause { get; set; }
    }
}