using System.Security.Cryptography;
using System.Text;

namespace EmercomDisp.BLL.Services
{
    public  class PasswordEncryptService : IPasswordEncryptService
    {
        public byte[] EncryptPassword(string password)
        {
            var result = string.Empty;
            using (SHA256 hash = SHA256.Create())
            {
                var enc = Encoding.UTF8;
                return hash.ComputeHash(enc.GetBytes(password));
            }
        } 
    }
}
