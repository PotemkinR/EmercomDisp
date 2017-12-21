using EmercomDisp.BLL.Services;
using EmercomDisp.Data.Repositories;
using EmercomDisp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmercomDisp.BLL.Providers
{
    public class CallProvider:ICallProvider
    {
        private readonly ICallRepository _callRepository;
        private readonly ICacheService _cacheService;

        public CallProvider(ICallRepository callRepository,
            ICacheService cacheService)
        {
            _callRepository = callRepository ?? throw new ArgumentNullException("Call Repository");
            _cacheService = cacheService ?? throw new ArgumentNullException("Cache Service");
        }

        public IEnumerable<Call> GetCalls()
        {
            return _callRepository.GetCalls().ToList();
        }

        public IEnumerable<Call> GetCallsByCategory(string category)
        {
            return _callRepository.GetCallsByCategory(category);
        }

        public Call GetCallById(int id)
        {
            return _callRepository.GetCallById(id);
        }

        public IEnumerable<string> GetCategories()
        {
            return _cacheService.GetObjectFromCache("categories", 10, () => _callRepository.GetCategories());
        }

        public int CreateCall(Call call)
        {
            return _callRepository.CreateCall(call);
        }

        public void UpdateCall(Call call)
        {
            _callRepository.UpdateCall(call);
        }

        public void DeleteCall(int id)
        {
            _callRepository.DeleteCall(id);
        }
    }
}
