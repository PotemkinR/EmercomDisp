using EmercomDisp.BLL.Services;
using EmercomDisp.Data.Clients;
using EmercomDisp.Model.Models;
using System;

namespace EmercomDisp.BLL.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserClient _userClient;
        private readonly IPasswordEncryptService _passwordEncryptService;

        public UserProvider(IUserClient userClient,
            IPasswordEncryptService userService)
        {
            _userClient = userClient ?? throw new ArgumentNullException("User Client");
            _passwordEncryptService = userService ?? throw new ArgumentNullException("Password Encrypt Service");
        }

        public void CreateUser(User user)
        {
            var newUser = new User()
            {
                Name = user.Name,
                Email = user.Email,
                PasswordHash = _passwordEncryptService.EncryptPassword(user.Password)
            };
            _userClient.CreateUser(newUser);
        }

        public User GetUserByName(string name)
        {
            return _userClient.GetUserByName(name);
        }
    }
}
