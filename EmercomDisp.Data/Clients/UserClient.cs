using EmercomDisp.Data.UserService;
using EmercomDisp.Model.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace EmercomDisp.Data.Clients
{
    public class UserClient : IUserClient
    {
        private readonly ILog _log = LogManager.GetLogger("LOGGER");

        public void CreateUser(User user)
        {
            using (var client = new UserServiceClient())
            {
                try
                {
                    client.Open();

                    var newUser = new UserDto()
                    {
                        Name = user.Name,
                        Email = user.Email,
                        PasswordHash = user.PasswordHash
                    };

                    client.CreateUser(newUser);

                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
        }

        public void DeleteUser(string name)
        {
            throw new NotImplementedException();
        }

        public User GetUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool UserIsValid(string name, byte[] passwordHash)
        {
            throw new NotImplementedException();
        }
    }
}
