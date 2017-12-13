using System.ComponentModel.DataAnnotations;

namespace EmercomDisp.Web.Models.Equipment_
{
    public class EquipmentEditModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}