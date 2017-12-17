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
        VictimDto GetVictimById(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        IEnumerable<VictimDto> GetVictimsByIncidentId(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void AddVictim(VictimDto victim, int callId);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void UpdateVictim(VictimDto victim);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void DeleteVictim(int id);
    }
}
