using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EmercomDisp.Service.Dto.Models
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public byte[] PasswordHash { get; set; }

        [DataMember]
        public IList<string> Roles { get; set; }
    }
}
