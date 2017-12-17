using System.ComponentModel.DataAnnotations;

namespace EmercomDisp.Web.Models.Victims
{
    public class VictimModel
    {
        public int CallId { get; set; }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Residence { get; set; }

        [Required]
        [Range(18, 200)]
        public int Age { get; set; }
    }
}