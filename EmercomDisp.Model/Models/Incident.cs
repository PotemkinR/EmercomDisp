using System.Collections.Generic;

namespace EmercomDisp.Model.Models
{
    public class Incident
    {
        public int Id { get; set; }

        public string Info { get; set; }

        public IEnumerable<Equipment> Equipment { get; set; }

        public string Cause { get; set; }
    }
}