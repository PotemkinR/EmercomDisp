using System.Collections.Generic;

namespace EmercomDisp.Service.Dto.Models
{
    public class BrigadeDto
    {
        public int Id { get; set; }

        public IEnumerable<int> BrigadeMembersId { get; set; }
    }
}