using EmercomDisp.BLL.Enums;

namespace EmercomDisp.BLL.Services
{
    public interface ILoginService
    {
        LoginResult Login(string userName, string password);
        void Logout();
    }
}