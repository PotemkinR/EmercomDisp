using System.Runtime.Serialization;

namespace EmercomDisp.Service.Dto.Models
{
    [DataContract]
    public class BrigadeDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int MemberCount { get; set; }
    }
}