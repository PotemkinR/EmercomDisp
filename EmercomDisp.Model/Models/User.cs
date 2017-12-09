using System.Collections.Generic;

namespace EmercomDisp.Model.Models
{
    public class User
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public byte[] PasswordHash { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
