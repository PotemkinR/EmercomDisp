using System.Runtime.Serialization;

namespace EmercomDisp.Service.Dto.Models
{
    [DataContract]
    public class SqlFault
    {
        [DataMember]
        public string Message { get; }

        public SqlFault()
        { }

        public SqlFault(string message)
        {
            message = Message;
        }
    }
}
