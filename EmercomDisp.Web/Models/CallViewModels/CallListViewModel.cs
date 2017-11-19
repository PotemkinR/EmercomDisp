using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Web.Models.CallViewModels
{
    public class CallListViewModel
    {
        public IEnumerable<Call> CallList { get; set; }
    }
}