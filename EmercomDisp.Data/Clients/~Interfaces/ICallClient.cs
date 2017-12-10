using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Data.Clients
{
    public interface ICallClient
    {
        IEnumerable<Call> GetCalls();
        IEnumerable<Call> GetCallsByCategory(string urgency);
        Call GetCallById(int id);
        IEnumerable<string> GetCategories();
    }
}
