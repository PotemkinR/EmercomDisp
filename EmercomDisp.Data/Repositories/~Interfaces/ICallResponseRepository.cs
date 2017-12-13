using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Data.Repositories
{
    public interface ICallResponseRepository
    {
        IEnumerable<CallResponse> GetCallResponsesForCall(int callId);
    }
}
