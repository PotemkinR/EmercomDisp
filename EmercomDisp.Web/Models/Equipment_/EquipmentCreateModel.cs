using System.ComponentModel.DataAnnotations;

namespace EmercomDisp.Web.Models.Equipment_
{
    public class EquipmentCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}