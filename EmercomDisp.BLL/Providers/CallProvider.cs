using EmercomDisp.Data.Repositories;
using EmercomDisp.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmercomDisp.BLL.Providers
{
    public class CallProvider:ICallProvider
    {
        private readonly IRepository _repository;

        public CallProvider(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Call> GetCalls()
        {
            return _repository.GetCalls().ToList();
        }
    }
}
