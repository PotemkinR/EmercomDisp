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
        [FaultContract(typeof(SqlFault))]
        IEnumerable<CallDto> GetCalls();

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        [FaultContract(typeof(ArgumentFault))]
        IEnumerable<CallDto> GetCallsByCategory(string category);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        CallDto GetCallById(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        IEnumerable<string> GetCategories();

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        [FaultContract(typeof(ArgumentFault))]
        int CreateCall(CallDto call);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        [FaultContract(typeof(ArgumentFault))]
        void UpdateCall(CallDto call);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        void DeleteCall(int id);
    }
}
