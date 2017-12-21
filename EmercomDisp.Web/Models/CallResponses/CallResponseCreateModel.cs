using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EmercomDisp.Web.Models.CallResponses
{
    public class CallResponseCreateModel
    {
        public int CallId { get; set; }

        [Display(Name ="Brigade")]
        public string SelectedBrigade { get; set; }

        public IEnumerable<SelectListItem> Brigades { get; set; }
    }
}