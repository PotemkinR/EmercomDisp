using EmercomDisp.Model.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace EmercomDisp.Service.Contracts.Contracts
{
    [ServiceContract]
    public interface ICallService
    {
        [OperationContract]
        IEnumerable<Call> GetCalls();

        [OperationContract]
        IEnumerable<Call> GetCallsByCategory(string urgency);

        [OperationContract]
        Call GetCallById(int id);

        [OperationContract]
        IEnumerable<string> GetCategories();
    }
}
