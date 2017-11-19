using EmercomDisp.Model.Models;
using System.Collections.Generic;

namespace EmercomDisp.BLL.Providers
{
    public interface ICallProvider
    {
        IEnumerable<Call> GetCalls();
    }
}
