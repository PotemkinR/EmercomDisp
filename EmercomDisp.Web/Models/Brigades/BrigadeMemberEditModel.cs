using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EmercomDisp.Web.Models.Brigades
{
    public class BrigadeMemberEditModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string BrigadeName { get; set; }

        public string SelectedBrigadeName { get; set; }

        public IEnumerable<SelectListItem> Brigades { get; set; }
    }
}