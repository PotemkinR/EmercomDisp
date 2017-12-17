using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Web.Models.CallResponses
{
    public class CallResponseListModel
    {
        public IEnumerable<CallResponse> CallResponses { get; set; }

        public int UsedEquipmentCount { get; set; }
    }
}