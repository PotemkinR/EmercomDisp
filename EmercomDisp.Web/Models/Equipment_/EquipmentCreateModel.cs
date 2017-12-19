using System.ComponentModel.DataAnnotations;

namespace EmercomDisp.Web.Models.Equipment_
{
    public class EquipmentCreateModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}