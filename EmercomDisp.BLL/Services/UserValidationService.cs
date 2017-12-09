using EmercomDisp.BLL.Providers;
using System;
using System.Linq;

namespace EmercomDisp.BLL.Services
{
    public class UserValidationService : IUserValidationService
    {
        private readonly IUserProvider _userProvider;
        private readonly IPasswordEncryptService _passwordEncryptService;

        public UserValidationService(IUserProvider userProvider,
            IPasswordEncryptService passwordEncryptService)
        {
            _userProvider = userProvider ?? throw new ArgumentNullException("User Provider");
            _passwordEncryptService = passwordEncryptService ?? throw new ArgumentNullException("Password Encrypt Service");
        }
        public bool IsValidUser(string name, string password)
        {
            var passwordHash = _passwordEncryptService.EncryptPassword(password);
            var user = _userProvider.GetUserByName(name);

            if (user != null)
            {
                if (user.Name == name && passwordHash.SequenceEqual(user.PasswordHash))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
