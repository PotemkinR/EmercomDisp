using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.BLL.Providers
{
    public interface IUserProvider
    {
        IEnumerable<User> GetUsers();
        User GetUserByName(string name);
        void CreateUser(User user);
        void UpdateUser(User user);
        IEnumerable<string> GetRoles();
    }
}
