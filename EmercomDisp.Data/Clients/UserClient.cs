using EmercomDisp.Data.UserService;
using EmercomDisp.Model.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
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
                        PasswordHash = user.PasswordHash,
                        Roles = user.Roles.Cast<string>().ToArray()                        
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

        public IEnumerable<string> GetRoles()
        {
            var roles = new List<string>();
            using (var client = new UserServiceClient())
            {
                try
                {
                    client.Open();
                    var rolesDto = client.GetRoles();
                    if (rolesDto != null)
                    {
                        foreach (var role in rolesDto)
                        {
                            roles.Add(role);
                        }
                    }
                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
            return roles;
        }

        public User GetUserByName(string name)
        {
            var user = new User();
            using (var client = new UserServiceClient())
            {
                try
                {
                    client.Open();

                    var userDto = client.GetUserByName(name);

                    if (userDto != null)
                    {
                        user.Name = userDto.Name;
                        user.PasswordHash = userDto.PasswordHash;
                        user.Email = userDto.Email;
                        user.Roles = userDto.Roles;
                    }
                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            var users = new List<User>();
            using (var client = new UserServiceClient())
            {
                try
                {
                    client.Open();
                    var usersDto = client.GetUsers();
                    if (usersDto != null)
                    {
                        foreach (var userDto in usersDto)
                        {
                            var user = new User()
                            {
                                Name = userDto.Name,
                                Email = userDto.Email
                            };
                            users.Add(user);
                        }
                    }
                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
            return users;
        }

        public void UpdateUser(User user)
        {
            using (var client = new UserServiceClient())
            {
                try
                {
                    client.Open();

                    var updatedUser = new UserDto()
                    {
                        Name = user.Name,
                        Email = user.Email,
                        PasswordHash = user.PasswordHash,
                        Roles = user.Roles?.Cast<string>().ToArray()
                    };

                    client.UpdateUser(updatedUser);

                    client.Close();
                }
                catch (FaultException<ConnectionFault> e)
                {
                    _log.Error(e.Message);
                }
            }
        }
    }
}
