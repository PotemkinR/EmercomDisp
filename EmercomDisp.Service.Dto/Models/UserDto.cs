using System.Collections.Generic;

namespace EmercomDisp.Service.Dto.Models
{
    public class UserDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public IEnumerable<RoleDto> Roles { get; set; }
    }
}
