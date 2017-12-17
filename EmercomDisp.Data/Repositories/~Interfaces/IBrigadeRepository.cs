using EmercomDisp.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmercomDisp.Data.Repositories
{
    public interface IBrigadeRepository
    {
        Brigade GetBrigadeForCallResponse(int callResponseId);
        Brigade GetBrigadeById(int id);
        IQueryable<Brigade> GetBrigades();
        void UpdateBrigade(Brigade brigade);
        void CreateBrigade(Brigade brigade);
        void DeleteBrigade(int id);
        IEnumerable<BrigadeMember> GetBrigadeMembers();
        IEnumerable<BrigadeMember> GetBrigadeMembersByBrigadeId(int id);
        BrigadeMember GetBrigadeMemberById(int id);
        void UpdateBrigadeMember(BrigadeMember brigadeMember);
        void DeleteBrigadeMember(int id);
        void CreateBrigadeMember(BrigadeMember brigadeMember);
    }
}
