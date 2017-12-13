using EmercomDisp.Service.Dto.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace EmercomDisp.Service.Contracts.Contracts
{
    [ServiceContract]
    public interface IVictimsService
    {
        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        IEnumerable<VictimDto> GetVictimsForIncident(int incidentId);
    }
}
