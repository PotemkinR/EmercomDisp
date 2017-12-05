using EmercomDisp.Data.Clients;
using EmercomDisp.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmercomDisp.BLL.Providers
{
    public class CallProvider:ICallProvider
    {
        private readonly ICallClient _client;

        public CallProvider(ICallClient repository)
        {
            _client = repository ?? throw new ArgumentNullException("repository");
        }

        public IEnumerable<Call> GetCalls()
        {
            return _client.GetCalls().ToList();
        }

        public IEnumerable<Call> GetCallsByCategory(string category)
        {
            return _client.GetCallsByCategory(category);
        }

        public Call GetCallById(int id)
        {
            return _client.GetCallById(id);
        }

        public IEnumerable<string> GetCategories()
        {
            return _client.GetCategories();
        }
    }
}
