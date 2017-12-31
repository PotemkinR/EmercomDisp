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
        [FaultContract(typeof(SqlFault))]
        IEnumerable<EquipmentDto> GetEquipment();

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        IEnumerable<EquipmentDto> GetEquipmentByCallResponseId(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        EquipmentDto GetEquipmentById(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        void UpdateEquipmentList(IEnumerable<EquipmentDto> equipment, int callResponseId);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        [FaultContract(typeof(ArgumentFault))]
        void CreateEquipment(EquipmentDto equipment);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        [FaultContract(typeof(ArgumentFault))]
        void UpdateEquipment(EquipmentDto equipment);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        void DeleteEquipment(int id);
    }
}
