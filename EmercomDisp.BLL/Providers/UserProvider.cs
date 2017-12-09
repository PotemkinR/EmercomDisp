using EmercomDisp.BLL.Services;
using EmercomDisp.Data.Clients;
using EmercomDisp.Model.Models;
using System;

namespace EmercomDisp.BLL.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserClient _userClient;
        private readonly IUserService _userService;

        public UserProvider(IUserClient userClient,
            IUserService userService)
        {
            _userClient = userClient ?? throw new ArgumentNullException();
            _userService = userService ?? throw new ArgumentNullException();
        }

        public void CreateUser(User user)
        {
            var newUser = new User()
            {
                Name = user.Name,
                Email = user.Email,
                PasswordHash = _userService.EncryptPassword(user.Password)
            };
            _userClient.CreateUser(newUser);
        }

        public User GetUserByName(string name)
        {
            return _userClient.GetUserByName(name);
        }
    }
}
