using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.BLL.Providers
{
    public interface ICallResponseProvider
    {
        IEnumerable<CallResponse> GetCallResponsesForCall(int callId);
    }
}
