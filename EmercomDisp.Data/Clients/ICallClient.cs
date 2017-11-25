using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Data.Clients
{
    public interface ICallClient
    {
        IEnumerable<Call> GetCalls();

        IEnumerable<Call> GetCallsByUrgency(string urgency);

        Call GetCallById(int id);

        IEnumerable<string> GetCategories();
    }
}
