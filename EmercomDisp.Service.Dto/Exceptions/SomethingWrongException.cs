using System;
using System.Runtime.Serialization;

namespace EmercomDisp.Service.Dto.Models
{
    [DataContract]
    public class SomethingWrongException : ApplicationException
    {

        public SomethingWrongException(string message) : base(message)
        {
        }
    }
}
