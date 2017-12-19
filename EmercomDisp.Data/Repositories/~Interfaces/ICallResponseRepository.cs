using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.Data.Repositories
{
    public interface ICallResponseRepository
    {
        CallResponse GetCallResponseById(int id);
        IEnumerable<CallResponse> GetCallResponsesForCall(int callId);
        void CreateCallResponse(CallResponse callResponse);
        void UpdateCallResponse(CallResponse callResponse);
        void DeleteCallResponse(int id);
    }
}
