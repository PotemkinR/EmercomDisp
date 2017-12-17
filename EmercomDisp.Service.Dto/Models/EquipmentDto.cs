using System.Runtime.Serialization;

namespace EmercomDisp.Service.Dto.Models
{
    [DataContract]
    public class EquipmentDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
