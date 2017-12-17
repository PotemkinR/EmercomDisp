using EmercomDisp.Service.Dto.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace EmercomDisp.Service.Contracts.Contracts
{
    [ServiceContract]
    public interface IBrigadeService
    {
        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        BrigadeDto GetBrigadeForCallResponse(int callResponseId);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        BrigadeDto GetBrigadeById(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        IEnumerable<BrigadeDto> GetBrigades();

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        IEnumerable<BrigadeMemberDto> GetBrigadeMembers();

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        IEnumerable<BrigadeMemberDto> GetBrigadeMembersByBrigadeId(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void UpdateBrigade(BrigadeDto brigade);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void CreateBrigade(BrigadeDto brigade);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void DeleteBrigade(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        BrigadeMemberDto GetBrigadeMemberById(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void UpdateBrigadeMember(BrigadeMemberDto brigadeMember);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void DeleteBrigadeMember(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void CreateBrigadeMember(BrigadeMemberDto brigadeMember);
    }
}
