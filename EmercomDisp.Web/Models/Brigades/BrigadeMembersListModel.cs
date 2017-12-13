using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Web.Models.Brigades
{
    public class BrigadeMembersListModel
    {
        public IEnumerable<BrigadeMember> BrigadeMembers { get; set; }
    }
}