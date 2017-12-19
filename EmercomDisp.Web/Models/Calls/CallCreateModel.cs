using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EmercomDisp.Web.Models.Calls
{
    public class CallCreateModel
    {
        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string Reason { get; set; }

        [Display(Name ="Category")]
        public string SelectedCategory { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public string SelectedBrigade { get; set; }
        
        public IEnumerable<SelectListItem> Brigades { get; set; }
    }
}