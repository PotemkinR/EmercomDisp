using System.Collections.Generic;

namespace EmercomDisp.Model.Models
{
    public class Brigade
    {
        public int Id { get; set; }

        public IEnumerable<BrigadeMember> Members { get; set; }
    }
}