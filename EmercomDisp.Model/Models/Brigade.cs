using System.Collections.Generic;

namespace EmercomDisp.Model.Models
{
    public class Brigade
    {
        public int Id { get; set; }

        public IEnumerable<string> Members { get; set; }
    }
}