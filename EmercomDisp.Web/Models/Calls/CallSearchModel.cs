using System.Collections.Generic;
using System.Web.Mvc;

namespace EmercomDisp.Web.Models.Calls
{
    public class CallSearchModel
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string Category { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}