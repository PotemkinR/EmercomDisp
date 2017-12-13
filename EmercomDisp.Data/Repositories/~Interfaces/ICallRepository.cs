using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Data.Repositories
{
    public interface ICallRepository
    {
        IEnumerable<Call> GetCalls();
        IEnumerable<Call> GetCallsByCategory(string urgency);
        Call GetCallById(int id);
        IEnumerable<string> GetCategories();
    }
}
