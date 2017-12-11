using EmercomDisp.Service.Dto.Models;
using System.ServiceModel;

namespace EmercomDisp.Service.Contracts.Contracts
{
    [ServiceContract]
    public interface IIncidentService
    {
        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        IncidentDto GetIncidentById(int id);
    }
}
