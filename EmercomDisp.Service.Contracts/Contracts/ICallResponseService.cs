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

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        CallResponseDto GetCallResponseById(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void UpdateCallResponse(CallResponseDto callResponse);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void DeleteCallResponse(int id);
    }
}
