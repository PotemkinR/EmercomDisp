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
        IEnumerable<UserDto> GetUsers();

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        bool UserIsValid(string name, string passwordHash);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        UserDto GetUserByName(string name);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void CreateUser(UserDto user);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void DeleteUser(string name);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        void UpdateUser(UserDto user);
    }
}
