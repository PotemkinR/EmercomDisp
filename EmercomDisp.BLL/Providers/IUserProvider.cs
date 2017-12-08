using EmercomDisp.Model.Models;

namespace EmercomDisp.BLL.Providers
{
    public interface IUserProvider
    {
        User GetUserByName(string name);
        void CreateUser(User user);
        bool IsValidUser(string userName, string password);
    }
}
