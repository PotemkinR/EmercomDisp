using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Web.Models.Users
{
    public class UserListModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}