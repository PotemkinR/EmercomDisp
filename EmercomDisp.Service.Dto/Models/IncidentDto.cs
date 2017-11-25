using System.Collections.Generic;

namespace EmercomDisp.Service.Dto.Models
{
    public class IncidentDto
    {
        public int Id { get; set; }

        public string Info { get; set; }

        public IEnumerable<EquipmentDto> Equipment { get; set; }

        public string Cause { get; set; }
    }
}