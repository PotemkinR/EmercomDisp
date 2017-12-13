using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Data.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserByName(string name);
        void CreateUser(User user);
        void DeleteUser(string name);
        void UpdateUser(User user);
        IEnumerable<string> GetRoles();
    }
}
