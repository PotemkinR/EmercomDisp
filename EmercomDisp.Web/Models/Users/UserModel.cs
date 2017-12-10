using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmercomDisp.Web.Models.Users
{
    public class UserModel
    {
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}