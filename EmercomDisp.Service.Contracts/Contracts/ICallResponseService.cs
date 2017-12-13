using EmercomDisp.Service.Dto.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace EmercomDisp.Service.Contracts.Contracts
{
    [ServiceContract]
    public interface ICallResponseService
    {
        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        IEnumerable<CallResponseDto> GetCallResponsesForCall(int callId);
    }
}
