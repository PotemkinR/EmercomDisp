using EmercomDisp.Data.Repositories;
using EmercomDisp.Model.Models;
using System;
using System.Collections.Generic;

namespace EmercomDisp.BLL.Providers
{
    public class CallResponseProvider : ICallResponseProvider
    {
        private readonly ICallResponseRepository _callResponseRepository;

        public CallResponseProvider(ICallResponseRepository callResponseRepository)
        {
            _callResponseRepository = callResponseRepository ?? throw new ArgumentNullException("Call Response Repository");
        }

        public CallResponse GetCallResponseById(int id)
        {
            return _callResponseRepository.GetCallResponseById(id);
        }

        public IEnumerable<CallResponse> GetCallResponsesForCall(int callId)
        {
            return _callResponseRepository.GetCallResponsesForCall(callId);
        }

        public void CreateCallResponse(CallResponse callResponse)
        {
            _callResponseRepository.CreateCallResponse(callResponse);
        }

        public void UpdateCallResponse(CallResponse callResponse)
        {
            _callResponseRepository.UpdateCallResponse(callResponse);
        }

        public void DeleteCallResponse(int id)
        {
            _callResponseRepository.DeleteCallResponse(id);
        }
    }
}
