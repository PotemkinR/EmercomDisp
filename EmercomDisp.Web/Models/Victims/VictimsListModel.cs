using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Web.Models.Victims
{
    public class VictimsListModel
    {
        public int CallId { get; set; }
        public IEnumerable<Victim> Victims { get; set; }
    }
}