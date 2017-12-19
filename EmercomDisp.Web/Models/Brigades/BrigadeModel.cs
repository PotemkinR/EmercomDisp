using EmercomDisp.Model.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmercomDisp.Web.Models.Brigades
{
    public class BrigadeModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string BrigadeName { get; set; }

        public IEnumerable<BrigadeMember> Members { get; set; }
    }
}