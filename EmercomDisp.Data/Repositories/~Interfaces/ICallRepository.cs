using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Data.Repositories
{
    public interface ICallRepository
    {
        IEnumerable<Call> GetCalls();
        IEnumerable<Call> GetCallsByCategory(string category);
        Call GetCallById(int id);
        IEnumerable<string> GetCategories();
        int CreateCall(Call call);
        void UpdateCall(Call call);
        void DeleteCall(int id);
    }
}
