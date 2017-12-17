using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmercomDisp.Web.Models.Calls
{
    public class CallEditModel
    {
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Reason { get; set; }

        public DateTime CallTime { get; set; }

        public string IncidentDescription { get; set; }

        public string IncidentCause { get; set; }

        public string SelectedCategory { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}