using System.Runtime.Serialization;

namespace EmercomDisp.Service.Dto.Models
{
    [DataContract]
    public class ConnectionFault
    {
        [DataMember]
        public string Message { get; set; }

        public ConnectionFault()
        { }

        public ConnectionFault(string message)
        {
            Message = message;
        }
    }
}
