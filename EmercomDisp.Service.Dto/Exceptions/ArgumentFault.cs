using System.Runtime.Serialization;

namespace EmercomDisp.Service.Dto.Models
{
    [DataContract]
    public class ArgumentFault
    {
        [DataMember]
        public string Message { get; set; }

        public ArgumentFault()
        { }

        public ArgumentFault(string message)
        {
            Message = message;
        }
    }
}
