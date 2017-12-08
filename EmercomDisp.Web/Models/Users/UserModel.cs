using System.Collections.Generic;

namespace EmercomDisp.Web.Models.Users
{
    public class UserModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}