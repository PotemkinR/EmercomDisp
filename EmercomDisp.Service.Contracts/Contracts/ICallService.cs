using EmercomDisp.Service.Dto.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace EmercomDisp.Service.Contracts.Contracts
{
    [ServiceContract]
    public interface ICallService
    {
        [OperationContract]
        IEnumerable<CallDto> GetCalls();

        [OperationContract]
        IEnumerable<CallDto> GetCallsByCategory(string urgency);

        [OperationContract]
        CallDto GetCallById(int id);

        [OperationContract]
        IEnumerable<string> GetCategories();
    }
}
