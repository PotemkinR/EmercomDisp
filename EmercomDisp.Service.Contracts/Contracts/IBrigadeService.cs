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
        [FaultContract(typeof(SqlFault))]
        BrigadeDto GetBrigadeById(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        IEnumerable<BrigadeDto> GetBrigades();

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        IEnumerable<BrigadeMemberDto> GetBrigadeMembers();

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        IEnumerable<BrigadeMemberDto> GetBrigadeMembersByBrigadeId(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        [FaultContract(typeof(ArgumentFault))]
        void UpdateBrigade(BrigadeDto brigade);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        [FaultContract(typeof(ArgumentFault))]
        void CreateBrigade(BrigadeDto brigade);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        void DeleteBrigade(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        BrigadeMemberDto GetBrigadeMemberById(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        [FaultContract(typeof(ArgumentFault))]
        void UpdateBrigadeMember(BrigadeMemberDto brigadeMember);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        void DeleteBrigadeMember(int id);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        [FaultContract(typeof(ArgumentFault))]
        void CreateBrigadeMember(BrigadeMemberDto brigadeMember);
    }
}
