using System.ComponentModel.DataAnnotations;

namespace EmercomDisp.Web.Models.Equipment_
{
    public class EquipmentEditModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}