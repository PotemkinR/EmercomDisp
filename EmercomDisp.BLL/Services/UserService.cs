using EmercomDisp.BLL.Providers;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EmercomDisp.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserProvider _userProvider;

        public UserService(IUserProvider userProvider)
        {
            _userProvider = userProvider ?? throw new ArgumentNullException("User Provider");
        }

        public byte[] EncryptPassword(string password)
        {
            var result = string.Empty;
            using (SHA256 hash = SHA256.Create())
            {
                var enc = Encoding.UTF8;
                return hash.ComputeHash(enc.GetBytes(password));
            }
        }

        public bool IsValidUser(string name, string password)
        {
            var passwordHash = EncryptPassword(password);
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
