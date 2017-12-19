using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.BLL.Providers
{
    public interface ICallResponseProvider
    {
        CallResponse GetCallResponseById(int id);
        IEnumerable<CallResponse> GetCallResponsesForCall(int callId);
        void CreateCallResponse(CallResponse callResponse);
        void UpdateCallResponse(CallResponse callResponse);
        void DeleteCallResponse(int id);
    }
}
