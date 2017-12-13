using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EmercomDisp.Web.Models.Brigades
{
    public class BrigadeMemberCreateModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string BrigadeName { get; set; }

        public string SelectedBrigadeName { get; set; }

        public IEnumerable<SelectListItem> Brigades { get; set; }
    }
}