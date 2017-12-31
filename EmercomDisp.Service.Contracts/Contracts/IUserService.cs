using EmercomDisp.Service.Dto.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace EmercomDisp.Service.Contracts.Contracts
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        IEnumerable<UserDto> GetUsers();

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        [FaultContract(typeof(ArgumentFault))]
        UserDto GetUserByName(string name);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        [FaultContract(typeof(ArgumentFault))]
        void CreateUser(UserDto user);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        [FaultContract(typeof(ArgumentFault))]
        void DeleteUser(string name);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        [FaultContract(typeof(ArgumentFault))]
        void UpdateUser(UserDto user);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(SqlFault))]
        IEnumerable<string> GetRoles();
    }
}
