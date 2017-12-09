using EmercomDisp.Model.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace EmercomDisp.BLL
{
    public class UserPrincipal : IPrincipal
    {
        public string UserName { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public IIdentity Identity
        {
            get; private set;
        }

        public UserPrincipal(string userName)
        {
            Identity = new GenericIdentity(userName);
        }

        public bool IsInRole(string role)
        {
            return Roles.Contains(role);
        }
    }
}
