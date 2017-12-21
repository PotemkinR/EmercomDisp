using EmercomDisp.Model.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EmercomDisp.Web.Models.Calls
{
    public class CallListViewModel
    {
        public IEnumerable<Call> CallList { get; set; }
    }
}