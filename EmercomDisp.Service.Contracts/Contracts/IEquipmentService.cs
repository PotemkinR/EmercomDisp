using EmercomDisp.Service.Dto.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace EmercomDisp.Service.Contracts.Contracts
{
    [ServiceContract]
    public interface IEquipmentService
    {
        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        IEnumerable<EquipmentDto> GetEquipment();

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        EquipmentDto GetEquipmentById(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void CreateEquipment(EquipmentDto equipment);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void UpdateEquipment(EquipmentDto equipment);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void DeleteEquipment(int id);
    }
}
