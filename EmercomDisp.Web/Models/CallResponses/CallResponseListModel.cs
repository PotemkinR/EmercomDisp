using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Web.Models.CallResponses
{
    public class CallResponseListModel
    {
        public int CallId { get; set; }

        public IEnumerable<CallResponse> CallResponses { get; set; }
    }
}