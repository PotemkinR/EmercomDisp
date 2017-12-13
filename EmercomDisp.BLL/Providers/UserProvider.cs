using EmercomDisp.BLL.Services;
using EmercomDisp.Data.Repositories;
using EmercomDisp.Model.Models;
using System;
using System.Collections.Generic;

namespace EmercomDisp.BLL.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordEncryptService _passwordEncryptService;

        public UserProvider(IUserRepository userRepository,
            IPasswordEncryptService userService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException("User Repository");
            _passwordEncryptService = userService ?? throw new ArgumentNullException("Password Encrypt Service");
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public void CreateUser(User user)
        {
            var newUser = new User()
            {
                Name = user.Name,
                Email = user.Email,
                PasswordHash = _passwordEncryptService.EncryptPassword(user.Password),
                Roles = user.Roles
            };
            _userRepository.CreateUser(newUser);
        }

        public void UpdateUser(User user)
        {
            var newUser = new User()
            {
                Name = user.Name,
                Email = user.Email,
                PasswordHash = _passwordEncryptService.EncryptPassword(user.Password),
                Roles = user.Roles
            };
            _userRepository.UpdateUser(newUser);
        }

        public IEnumerable<string> GetRoles()
        {
            return _userRepository.GetRoles();
        }

        public User GetUserByName(string name)
        {
            return _userRepository.GetUserByName(name);
        }

        public void DeleteUser(string name)
        {
            _userRepository.DeleteUser(name);
        }
    }
}
