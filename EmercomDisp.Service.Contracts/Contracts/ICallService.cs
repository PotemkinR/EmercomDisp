using EmercomDisp.Service.Dto.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace EmercomDisp.Service.Contracts.Contracts
{
    [ServiceContract]
    public interface ICallService
    {
        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        IEnumerable<CallDto> GetCalls();

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        IEnumerable<CallDto> GetCallsByCategory(string urgency);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        CallDto GetCallById(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        IEnumerable<string> GetCategories();

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void UpdateCall(CallDto call);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void DeleteCall(int id);
    }
}
