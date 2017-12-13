using System.ComponentModel.DataAnnotations;

namespace EmercomDisp.Web.Models.Brigades
{
    public class BrigadeModel
    {
        public int Id { get; set; }

        [Required]
        public string BrigadeName { get; set; }
    }
}