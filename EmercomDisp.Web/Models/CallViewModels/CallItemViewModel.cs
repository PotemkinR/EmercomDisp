using System;

namespace EmercomDisp.Web.Models.CallViewModels
{
    public class CallItemViewModel
    {
        public int CallId { get; set; }

        public string Address { get; set; }

        public DateTime CallTime { get; set; }
    }
}