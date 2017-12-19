using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmercomDisp.Web.Models.Users
{
    public class UserModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}