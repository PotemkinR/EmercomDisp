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
        [FaultContract(typeof(SqlFault))]
        IEnumerable<CallResponseDto> GetCallResponsesForCall(int callId);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        CallResponseDto GetCallResponseById(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        [FaultContract(typeof(ArgumentFault))]
        void CreateCallResponse(CallResponseDto callResponse);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        [FaultContract(typeof(ArgumentFault))]
        void UpdateCallResponse(CallResponseDto callResponse);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        void DeleteCallResponse(int id);
    }
}
